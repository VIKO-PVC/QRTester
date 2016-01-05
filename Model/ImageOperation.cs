using System;

namespace Model
{
    public abstract class ImageOperation
    {
        public Image Image { get; set; }
        public CheckImageStatus CheckStatus { get; set; }
        public ImageOperation InnerOperation { get; set; }

        protected string GetStatusString()
        {
            var statusString = String.Empty;

            switch (CheckStatus)
            {
                case CheckImageStatus.NotCheckYet:
                {
                    statusString = "Netikrinta";
                    break;
                    }
                case CheckImageStatus.QrRecognitionFailed:
                    {
                        statusString = "QR simbolis nenuskaitytas";
                        break;
                    }
                case CheckImageStatus.QrRecognitionSuccessful:
                    {
                        statusString = "QR simbolis nuskaitytas sėkmingai";
                        break;
                    }
                case CheckImageStatus.WrongQrValueRead:
                    {
                        statusString = "Nuskaitytas neteisinga QR simbolio reikšmė";
                        break;
                    }
                default:
                    {
                        statusString = "Netikrinta";
                        break;
                    }
            }

            return statusString;
        }
    }

    public class RotateOperation : ImageOperation
    {
        public int RotateAngle { get; set; }
        public override string ToString()
        {
            return String.Format("Pasukimo operacija. Kampas: {0} laipsnių. Rezultatas: {1}", RotateAngle, GetStatusString());
        }
    }

    public class CornerOperation : ImageOperation
    {
        public int TopPositionPercent { get; set; }

        public int SidePositionPercent { get; set; }

        public override string ToString()
        {
            return String.Format("Kampo nuplėšimo operacija. Viršaus pozicija: {0}% Šono pozicija: {1}% Rezultatas: {2}", 
                TopPositionPercent, SidePositionPercent, GetStatusString());
        }
    }

    public class MarkerOperation : ImageOperation
    {
        public int TopPositionPercent { get; set; }

        public int BottomPositionPercent { get; set; }

        public override string ToString()
        {
            return String.Format("Ištepimo markeriu operacija. Viršaus pozicija: {0}% Apačios pozicija: {1}% Rezultatas: {2}",
                   TopPositionPercent, BottomPositionPercent, GetStatusString());
        }
    }
    public class NoiseOperation : ImageOperation
    {
        public int Intensity { get; set; }

        public override string ToString()
        {
            return String.Format("Gauso triukšmo operacija. Intensyvumas: {0}‰ Rezultatas: {1}",
                   Intensity, GetStatusString());
        }
    }
    public class BlurOperation : ImageOperation
    {
        public int Intensity { get; set; }

        public override string ToString()
        {
            return String.Format("Išblukimo operacija. Intensyvumas: {0}% Rezultatas: {1}",
                   Intensity, GetStatusString());
        }
    }
    public class BrightnessOperation : ImageOperation
    {
        public int Intensity { get; set; }

        public override string ToString()
        {
            return String.Format("Apšvietimo operacija. {2}: {0}% Rezultatas: {1}",
                   Math.Round(Intensity < 0 ? Intensity * -1 : Intensity / 2.55), GetStatusString(), Intensity > 0 ? "Šviesinimas" : "Tamsinimas");
        }
    }
}
