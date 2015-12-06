namespace Model
{
    public class ImageOperation
    {
        public Image Image { get; set; }
        public OperationType OperationType { get; set; }
        public CheckImageStatus CheckStatus { get; set; }
        public int AdditionalData { get; set; }

    }

    public enum OperationType
    {
        ROTATE,
        CORNER,
        MARKER
    }
}
