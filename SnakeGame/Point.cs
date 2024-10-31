namespace SnakeGame
{
    public class Point(int x, int y)
    {
        public int x { get; set; } = x;
        public int y { get; set; } = y;

        public static readonly Point? zero;
    }
}
