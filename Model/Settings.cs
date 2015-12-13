namespace Model
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

        public Settings()
        {
            ImageUploadUrl = "http://zxing.org/w/decode";
            RequestType = "POST";
            SuccessHtmlFragment = "Decode Succeeded</h1>";
            MarkerWidth = 15;
        }
    }
}
