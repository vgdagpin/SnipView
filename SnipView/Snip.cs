namespace SnipView
{
    public class Snip
    {
        public Guid ID { get; set; }
        public Size Size { get; set; }
        public Point Location { get; set; }
        public Image Image { get; set; } = null!;
    }
}
