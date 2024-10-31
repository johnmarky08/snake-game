using System.ComponentModel.DataAnnotations;

namespace SnakeGame
{
    public struct Point(int x, int y)
    {
        public int x { get; set; } = x;
        public int y { get; set; } = y;

        public static Point Zero => new(0, 0);
        public static Point One => new(1, 1);
        public static Point Up => new(0, -1);
        public static Point Down => new(0, 1);
        public static Point Right => new(1, 0);
        public static Point Left => new(-1, 0);

        public static Point operator +(Point a, Point b) => new(a.x + b.x, a.y + b.y);
        public static Point operator +(Point p, int num) => new(p.x + num, p.y + num);
        public static Point operator -(Point a, Point b) => new(a.x - b.x, a.y - b.y);
        public static Point operator -(Point p, int num) => new(p.x - num, p.y - num);
        public static Point operator *(Point a, Point b) => new(a.x * b.x, a.y * b.y);
        public static Point operator *(Point p, int num) => new(p.x * num, p.y * num);
        public static Point operator /(Point a, Point b)
        {
            if (b.x == 0 || b.y == 0) throw new DivideByZeroException("Cannot divide by Zero!");
            return new(a.x / b.x, a.y / b.y);
        }
        public static Point operator /(Point p, int num)
        {
            if (num == 0) throw new DivideByZeroException("Cannot divide by Zero!");
            return new(p.x / num, p.y / num);
        }

        public static bool operator ==(Point a, Point b) => a.x == b.x && a.y == b.y;
        public static bool operator !=(Point a, Point b) => a.x != b.x || a.y != b.y;

        public override readonly bool Equals(object? obj)
        {
            if(obj == null || !GetType().Equals(obj.GetType())) return false;

            Point p = (Point) obj;
            return this == p;
        }

        public override readonly int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }
    }
}
