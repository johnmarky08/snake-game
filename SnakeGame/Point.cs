namespace SnakeGame
{
    public struct Point(int x, int y)
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;

        public static Point Zero => new(0, 0);
        public static Point One => new(1, 1);
        public static Point Up => new(0, -1);
        public static Point Down => new(0, 1);
        public static Point Right => new(1, 0);
        public static Point Left => new(-1, 0);

        public static Point operator +(Point a, Point b) => new(a.X + b.X, a.Y + b.Y);
        public static Point operator +(Point p, int num) => new(p.X + num, p.Y + num);
        public static Point operator -(Point a, Point b) => new(a.X - b.X, a.Y - b.Y);
        public static Point operator -(Point p, int num) => new(p.X - num, p.Y - num);
        public static Point operator *(Point a, Point b) => new(a.X * b.X, a.Y * b.Y);
        public static Point operator *(Point p, int num) => new(p.X * num, p.Y * num);
        public static Point operator /(Point a, Point b)
        {
            if (b.X == 0 || b.Y == 0) throw new DivideByZeroException("Cannot divide by Zero!");
            return new(a.X / b.X, a.Y / b.Y);
        }
        public static Point operator /(Point p, int num)
        {
            if (num == 0) throw new DivideByZeroException("Cannot divide by Zero!");
            return new(p.X / num, p.Y / num);
        }

        public static bool operator ==(Point a, Point b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(Point a, Point b) => a.X != b.X || a.Y != b.Y;

        public override readonly bool Equals(object? obj)
        {
            if(obj == null || !GetType().Equals(obj.GetType())) return false;

            Point p = (Point) obj;
            return this == p;
        }

        public override readonly int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
