using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using Model;
using Image = Model.Image;

namespace Service
{
    public static class ImageService
    {
        public static Settings Settings { get; set; }
        public static Stack<ImageOperation> ImageOperations { get; set; }

        public static Image GetPicture(Stream fileStream)
        {
            var bitmapFromStream = new Bitmap(fileStream);
            fileStream.Close();
            /*
            var bitmap = new Bitmap(bitmapFromStream.Width, bitmapFromStream.Height, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.DrawImage(bitmapFromStream, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
            }*/

            var image = new Image()
            {
                Picture = bitmapFromStream
            };

            return image;
        }

        public static CheckImageStatus CheckImage(Image image)
        {
            var imageFormat = String.Empty;

            if (image.Picture.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
            {
                imageFormat = "png";
            }
            else
            {
                // TODO: Logging
                return CheckImageStatus.NotCheckYet;
            }

            // http://stackoverflow.com/questions/566462/upload-files-with-httpwebrequest-multipart-form-data
            var response = HttpUploadFile(Settings.ImageUploadUrl, image, "f", "image/" + imageFormat);

            if (IsResponseValid(response, Settings))
            {
                return CheckImageStatus.QrRecognitionSuccessful;
            }

            return CheckImageStatus.QrRecognitionFailed;
        }

        public static HttpWebResponse HttpUploadFile(string url, Image image, string paramName, string contentType)
        {
            string boundary = "---------------------------" + (DateTime.Now.Ticks - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).Ticks);
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;

            Stream rs = wr.GetRequestStream();
            
            rs.Write(boundarybytes, 0, boundarybytes.Length);
            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, "a.png", contentType); // TODO: Change file name
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);
            
            int bytesRead;
            byte[] buffer = new byte[4096];
            var memoryStream = new MemoryStream();
            image.Picture.Save(memoryStream, image.Picture.RawFormat);
            memoryStream.Position = 0;

            while ((bytesRead = memoryStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Write(System.Text.Encoding.ASCII.GetBytes("--"), 0, System.Text.Encoding.ASCII.GetBytes("--").Length);

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)wr.GetResponse();
            }
            catch (Exception)
            {
                // TODO: Logging
            }

            return response;
        }

        public static bool IsResponseValid(HttpWebResponse response, Settings settings)
        {
            if (!String.IsNullOrEmpty(Settings.SuccessHtmlFragment))
            {   
                Stream responseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream);
                string responseHtml = streamReader.ReadToEnd();
                if (responseHtml.Contains(Settings.SuccessHtmlFragment))
                {
                    return true;
                }

                return false;
            }

            if (Settings.SuccessReponseCode.HasValue && (int)response.StatusCode == Settings.SuccessReponseCode.Value)
            {
                return true;
            }

            return false;
        }

        public static void RotateImage2(int angle)
        {
            var currentImage = Settings.CurrentImage.Picture;
            Bitmap rotatedImage = new Bitmap(currentImage.Width, currentImage.Height);
            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                g.TranslateTransform(currentImage.Width / 2, currentImage.Height / 2); //set the rotation point as the center into the matrix
                g.RotateTransform(angle); //rotate
                g.TranslateTransform(-currentImage.Width / 2, -currentImage.Height / 2); //restore rotation point into the matrix
                g.DrawImage(currentImage, new Point(0, 0)); //draw the image on the new bitmap
            }

            Settings.CurrentImage.Picture = rotatedImage;
        }


        public static void RotateImage(int angle)
        {
            var currentImage = Settings.CurrentImage.Picture;

            http://stackoverflow.com/questions/14184700/how-to-rotate-image-x-degrees-in-c
            angle = angle % 360;
            if (angle > 180)
                angle -= 360;

            var pf = currentImage.PixelFormat;

            var sin = (float)Math.Abs(Math.Sin(angle * Math.PI / 180.0)); // this function takes radians
            var cos = (float)Math.Abs(Math.Cos(angle * Math.PI / 180.0)); // this one too
            var newImgWidth = sin * currentImage.Height + cos * currentImage.Width;
            var newImgHeight = sin * currentImage.Width + cos * currentImage.Height;
            var originX = 0f;
            var originY = 0f;

            if (angle > 0)
            {
                if (angle <= 90)
                    originX = sin * currentImage.Height;
                else
                {
                    originX = newImgWidth;
                    originY = newImgHeight - sin * currentImage.Width;
                }
            }
            else
            {
                if (angle >= -90)
                    originY = sin * currentImage.Width;
                else
                {
                    originX = newImgWidth - sin * currentImage.Height;
                    originY = newImgHeight;
                }
            }

            var newImage = new Bitmap((int)newImgWidth, (int)newImgHeight, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(newImage);
            //graphics.Clear(bkColor);
            graphics.TranslateTransform(originX, originY); // offset the origin to our calculated values
            graphics.RotateTransform(angle); // set up rotate
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            graphics.DrawImageUnscaled(currentImage, 0, 0); // draw the image at 0, 0
            graphics.Dispose();

            Settings.CurrentImage.Picture = newImage;
        }

        public static void ExecuteTopmostImageOperation()
        {
            var currentOperation = ImageOperations.Pop();

            if (currentOperation.OperationType == OperationType.ROTATE)
            {
                RotateImage(currentOperation.AdditionalData);
            }
            else if (currentOperation.OperationType == OperationType.MARKER)
            {
                //TODO: Logic
            }
            else if (currentOperation.OperationType == OperationType.CORNER)
            {
                //TODO: Logic
            }
        }
    }
}
