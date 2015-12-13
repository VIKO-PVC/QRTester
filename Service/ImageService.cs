using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using Model;
using Image = Model.Image;

namespace Service
{
    public static class ImageService
    {
        public static Settings Settings { get; set; }
        public static Stack<ImageOperation> PendingImageOperations { get; set; }
        public static Stack<ImageOperation> ExecutedImageOperations { get; set; }

        public static Image GetPicture(Stream fileStream)
        {
            var bitmapFromStream = new Bitmap(fileStream);
            fileStream.Close();

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

        public static Image RotateImage(int angle, Image image)
        {
            var bitmap = image.Picture;

            http://stackoverflow.com/questions/14184700/how-to-rotate-image-x-degrees-in-c
            angle = angle % 360;
            if (angle > 180)
                angle -= 360;

            var sin = (float)Math.Abs(Math.Sin(angle * Math.PI / 180.0)); // this function takes radians
            var cos = (float)Math.Abs(Math.Cos(angle * Math.PI / 180.0)); // this one too
            var newImgWidth = sin * bitmap.Height + cos * bitmap.Width;
            var newImgHeight = sin * bitmap.Width + cos * bitmap.Height;
            var originX = 0f;
            var originY = 0f;

            if (angle > 0)
            {
                if (angle <= 90)
                    originX = sin * bitmap.Height;
                else
                {
                    originX = newImgWidth;
                    originY = newImgHeight - sin * bitmap.Width;
                }
            }
            else
            {
                if (angle >= -90)
                    originY = sin * bitmap.Width;
                else
                {
                    originX = newImgWidth - sin * bitmap.Height;
                    originY = newImgHeight;
                }
            }

            var newImage = new Bitmap((int)newImgWidth, (int)newImgHeight, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(newImage);
            graphics.TranslateTransform(originX, originY); // offset the origin to our calculated values
            graphics.RotateTransform(angle); // set up rotate
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            graphics.DrawImageUnscaled(bitmap, 0, 0); // draw the image at 0, 0
            graphics.Dispose();

            // TODO: Enable sending .bmp's?
            using (MemoryStream memoryStream = new MemoryStream())
            {
                newImage.Save(memoryStream, ImageFormat.Png);
                newImage = new Bitmap(memoryStream);
            }

            return new Image()
            {
                Picture = newImage
            };
        }

        public static Image DrawMarkerLine(float topPositionPercentage, float bottomPositionPercentage, Color markerColor, Image image)
        {
            var bitmap = image.Picture;
            var topXPosition = (int) (bitmap.Width*topPositionPercentage/100);
            var bottomXPosition = (int) (bitmap.Width*bottomPositionPercentage/100);

            var newImage = new Bitmap(bitmap);
            var graphics = Graphics.FromImage(newImage);
            graphics.DrawLine(new Pen(markerColor, Settings.MarkerWidth), topXPosition, 0, bottomXPosition, bitmap.Height);
            graphics.Dispose();

            // TODO: Enable sending .bmp's?
            using (MemoryStream memoryStream = new MemoryStream())
            {
                newImage.Save(memoryStream, ImageFormat.Png);
                newImage = new Bitmap(memoryStream);
            }

            return new Image()
            {
                Picture = newImage
            };
        }

        /*public static Image CutImageCorned(int maxLength, Image image)
        {
            var bitmap = image.Picture;
            var separatorColor = Color.Red;
            
            var newImage = new Bitmap(bitmap);
            var graphics = Graphics.FromImage(newImage);
            graphics.DrawLine(new Pen(separatorColor, 15),(int)(bitmap.Width * 0.75), bitmap.Height, bitmap.Width, (int)(bitmap.Height * 0.75));
            graphics.Dispose();

            // TODO: Enable sending .bmp's?
            using (MemoryStream memoryStream = new MemoryStream())
            {
                newImage.Save(memoryStream, ImageFormat.Png);
                newImage = new Bitmap(memoryStream);
            }

            return new Image()
            {
                Picture = newImage
            };
        }*/

        public static void ExecuteTopmostImageOperation()
        {
            var currentOperation = PendingImageOperations.Pop();
            Image transformedImage = null;

            if (currentOperation is RotateOperation)
            {
                transformedImage = RotateImage(((RotateOperation)currentOperation).RotateAngle, currentOperation.Image);
            }
            else if (currentOperation is CornerOperation)
            {
                //transformedImage = CutImageCorned(10, currentOperation.Image);
                //TODO: Logic
            }
            else if (currentOperation is MarkerOperation)
            {
                var markerOperation = (MarkerOperation) currentOperation;
                transformedImage = DrawMarkerLine(markerOperation.TopPositionPercent, markerOperation.BottomPositionPercent, Color.Black, currentOperation.Image);
            }

            Settings.CurrentImage = transformedImage;
            ExecutedImageOperations.Push(currentOperation);
        }

        public static int GetRotationAngle(int inputAngle)
        {
            var a =
                ExecutedImageOperations.Where(item => item is RotateOperation).Sum(item => ((RotateOperation) item).RotateAngle);
            return (a + inputAngle) % 360;
        }
    }
}
