namespace Model
{
    public class Image
    {
        public System.Drawing.Image Picture { get; set; }

        public Image Copy()
        {
            var copy = new Image();
            copy.Picture = Picture;

            return copy;
        }
    }
}
