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
        public static List<ActionLogEntry> ActionLog { get; set; }

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

            if (image.Picture.RawFormat.Equals(ImageFormat.Png))
            {
                imageFormat = "png";
            }
            else if (image.Picture.RawFormat.Equals(ImageFormat.Jpeg))
            {
                var picture = new Bitmap(image.Picture, image.Picture.Width, image.Picture.Height);
                using (var memoryStream = new MemoryStream())
                {
                    picture.Save(memoryStream, ImageFormat.Png);
                    picture = new Bitmap(memoryStream);
                    image.Picture = picture;
                }
                
                imageFormat = "png";
            }
            else
            {
                ActionLog.Add(new ActionLogEntry()
                {
                    Id = Guid.NewGuid(),
                    Description = "Blogas paveiksliuko formatas"
                });

                return CheckImageStatus.NotCheckYet;
            }
            
            var response = HttpUploadFile(image, "f", "image/" + imageFormat);

            if (IsResponseValid(response))
            {
                return CheckImageStatus.QrRecognitionSuccessful;
            }

            return CheckImageStatus.QrRecognitionFailed;
        }

        public static HttpWebResponse HttpUploadFile(Image image, string paramName, string contentType)
        {
            string boundary = "---------------------------" + (DateTime.Now.Ticks - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).Ticks);
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(Settings.ImageUploadUrl);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = Settings.RequestType;
            wr.KeepAlive = true;

            Stream rs = wr.GetRequestStream();
            
            rs.Write(boundarybytes, 0, boundarybytes.Length);
            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, "a.png", contentType);
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
            catch (Exception exception)
            {
                ActionLog.Add(new ActionLogEntry()
                {
                    Id = Guid.NewGuid(),
                    Description = "Klaida siunčiant QR simbolio tikrinimo užklausą: " + exception.Message
                });
            }

            return response;
        }

        public static bool IsResponseValid(HttpWebResponse response)
        {
            if (response == null)
            {
                return false;
            }

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

        public static Image GenerateNoise(int permille, Image image)
        {
            var newImage = new Bitmap(image.Picture);

            Random rng = new Random();
            var totalcount = 0;
            var hitCount = 0;

            for (int x = 0; x < newImage.Width; x++)
            {
                for (int y = 0; y < newImage.Height; y++)
                {
                    totalcount++;
                    var chance = rng.Next(1, 1000);
                    var color = rng.Next(0, 2);
                    if (color == 1)
                    {
                        color = 255;
                    }
                    else
                    {
                        color = 0;
                    }

                    if (chance <= permille)
                    {
                        hitCount++;
                        newImage.SetPixel(x, y, Color.FromArgb(255, color, color, color));
                    }
                }
            }

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
            var topXPosition = (int) (image.Picture.Width*topPositionPercentage/100);
            var bottomXPosition = (int) (image.Picture.Width*bottomPositionPercentage/100);

            return DrawMarkerLine(new Point(topXPosition, 0), new Point(bottomXPosition, image.Picture.Height), markerColor, Settings.MarkerWidth, image);
        }


        public static Image DrawMarkerLine(Point start, Point end, Color markerColor, float markerWidth, Image image)
        {
            var bitmap = image.Picture;

            var newImage = new Bitmap(bitmap);
            var graphics = Graphics.FromImage(newImage);
            graphics.DrawLine(new Pen(markerColor, markerWidth), start.X, start.Y, end.X, end.Y);
            graphics.Dispose();
            
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

        public static Image CutImageCorner(int topPositionPercentage, int sidePositionPercentage, Image image)
        {
            var topPosition = image.Picture.Width * topPositionPercentage / 100;
            var sidePosition = image.Picture.Width * sidePositionPercentage / 100;
            
            var bitmapWithBoundary = (Bitmap)DrawMarkerLine(new Point(topPosition, 0), new Point(0, sidePosition), Color.Red,
                1, image).Picture;
            
            var currentPoint = new Point(0, 0);
            
            while (bitmapWithBoundary.GetPixel(0, currentPoint.Y).ToArgb() != Color.Red.ToArgb())
            {
                while (bitmapWithBoundary.GetPixel(currentPoint.X, currentPoint.Y).ToArgb() != Color.Red.ToArgb())
                {
                    bitmapWithBoundary.SetPixel(currentPoint.X, currentPoint.Y, Color.Black);
                    currentPoint.X++;
                }

                while (bitmapWithBoundary.GetPixel(currentPoint.X, currentPoint.Y).ToArgb() == Color.Red.ToArgb())
                {
                    bitmapWithBoundary.SetPixel(currentPoint.X, currentPoint.Y, Color.Black);
                    currentPoint.X++;
                }

                currentPoint.Y++;
                currentPoint.X = 0;
            }
            
            return new Image()
            {
                Picture = bitmapWithBoundary
            }; ;
        }

        public static void ExecuteTopmostImageOperation()
        {
            var initialOperation = PendingImageOperations.Pop();
            var currentOperation = initialOperation;

            try
            {
                while (currentOperation != null)
                {
                    Settings.CurrentImage = ExecuteOperation(currentOperation);

                    if (currentOperation.InnerOperation != null)
                    {
                        currentOperation.InnerOperation.Image = Settings.CurrentImage;
                    }

                    currentOperation = currentOperation.InnerOperation;
                }
            }
            catch (Exception)
            {
                Settings.CurrentImage = Settings.UploadedImage;
            }
            
            ExecutedImageOperations.Push(initialOperation);
        }

        private static Image ExecuteOperation(ImageOperation operation)
        {

            Image transformedImage = null;

            if (operation is RotateOperation)
            {
                transformedImage = RotateImage(((RotateOperation)operation).RotateAngle, operation.Image);
            }
            else if (operation is CornerOperation)
            {
                var cornerOperation = (CornerOperation)operation;
                transformedImage = CutImageCorner(cornerOperation.TopPositionPercent, cornerOperation.SidePositionPercent, operation.Image);

            }
            else if (operation is MarkerOperation)
            {
                var markerOperation = (MarkerOperation)operation;
                transformedImage = DrawMarkerLine(markerOperation.TopPositionPercent, markerOperation.BottomPositionPercent, Color.Black, operation.Image);
            }
            else if (operation is NoiseOperation)
            {
                var noiseOperation = (NoiseOperation)operation;
                transformedImage = GenerateNoise(noiseOperation.Intensity, operation.Image);
            }

            return transformedImage;
        }

        public static int GetRotationAngle(int inputAngle)
        {
            var a =
                ExecutedImageOperations.Where(item => item is RotateOperation).Sum(item => ((RotateOperation) item).RotateAngle);
            return (a + inputAngle) % 360;
        }

        public static void SetUpTestPacket()
        {
            for (int i = Settings.TestPacketSettings.RotationStep; i <= 360; i += Settings.TestPacketSettings.RotationStep)
            {
                PendingImageOperations.Push(new RotateOperation()
                {
                    CheckStatus = CheckImageStatus.NotCheckYet,
                    Image = Settings.CurrentImage,
                    RotateAngle = i
                });     
            }

            for (int i = Settings.TestPacketSettings.MarkerStartStep; i <= 100; i += Settings.TestPacketSettings.MarkerStartStep)
            {
                for (int j = Settings.TestPacketSettings.MarkerEndStep; j <= 100; j += Settings.TestPacketSettings.MarkerEndStep)
                {
                    PendingImageOperations.Push(new MarkerOperation()
                    {
                        CheckStatus = CheckImageStatus.NotCheckYet,
                        Image = Settings.CurrentImage,
                        TopPositionPercent = i,
                        BottomPositionPercent = j
                    });
                }
            }

            for (int i = Settings.TestPacketSettings.CornerTopStep; i <= Settings.TestPacketSettings.CornerTopBoundary; i += Settings.TestPacketSettings.CornerTopStep)
            {
                for (int j = Settings.TestPacketSettings.CornerSideStep; j <= Settings.TestPacketSettings.CornerSideBoundary; j += Settings.TestPacketSettings.CornerSideStep)
                {
                    PendingImageOperations.Push(new CornerOperation()
                    {
                        CheckStatus = CheckImageStatus.NotCheckYet,
                        Image = Settings.CurrentImage,
                        TopPositionPercent = i,
                        SidePositionPercent = j
                    });
                }
            }

            //TODO: Add noise operations
        }

        public static void LogLastOperation()
        {
            var lastOperation = ExecutedImageOperations.Peek();
            var logEntry = new ActionLogEntry()
            {
                Id = Guid.NewGuid(),
                Description = lastOperation.ToString(),
                Image = Settings.CurrentImage.Copy()
            };

            ActionLog.Add(logEntry);
        }
    }
}
