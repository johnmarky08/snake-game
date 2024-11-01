using static System.Console;

namespace SnakeGame
{
    public class Snake
    {
        public List<Point> Positions { get; set; } = [];

        public void Move(Direction direction)
        {
            for (int i = Positions.Count - 1; i > 0; i--) Positions[i] = Positions[i - 1];
            switch (direction)
            {
                case Direction.UP:
                    {
                        Positions[0] += Point.Up;
                        break;
                    }
                case Direction.DOWN:
                    {
                        Positions[0] += Point.Down;
                        break;
                    }
                case Direction.RIGHT:
                    {
                        Positions[0] += Point.Right;
                        break;
                    }
                case Direction.LEFT:
                    {
                        Positions[0] += Point.Left;
                        break;
                    }
            }
        }
    }
}