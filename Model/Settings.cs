﻿namespace Model
{
    public class Settings
    {
        public string ImageUploadUrl { get; set; }
        public string RequestType { get; set; }
        public int? SuccessReponseCode { get; set; }
        public string SuccessHtmlFragment { get; set; }
        public float MarkerWidth { get; set; }
        public Image UploadedImage { get; set; }
        public Image CurrentImage { get; set; }
        public TestPacketSettings TestPacketSettings { get; set; }

        public Settings()
        {
            ImageUploadUrl = "http://zxing.org/w/decode";
            RequestType = "POST";
            SuccessHtmlFragment = "Decode Succeeded</h1>";
            MarkerWidth = 15;
            TestPacketSettings = new TestPacketSettings()
            {
                RotationStep = 15,
                MarkerStartStep = 10,
                MarkerEndStep = 10,
                CornerTopStep = 5,
                CornerTopBoundary = 25,
                CornerSideStep = 5,
                CornerSideBoundary = 25
            };
        }
    }

    public class TestPacketSettings
    {
        public int RotationStep { get; set; }

        public int MarkerStartStep { get; set; }
        public int MarkerEndStep { get; set; }

        public int CornerTopStep { get; set; }
        public int CornerTopBoundary { get; set; }
        public int CornerSideStep { get; set; }
        public int CornerSideBoundary { get; set; }
    }
}

