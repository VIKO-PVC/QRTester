namespace Model
{
    public class ImageOperation
    {
        public Image Image { get; set; }
        public CheckImageStatus CheckStatus { get; set; }
    }

    public class RotateOperation : ImageOperation
    {
        public int RotateAngle { get; set; }
    }

    public class CornerOperation : ImageOperation
    {

    }

    public class MarkerOperation : ImageOperation
    {

    }
}
