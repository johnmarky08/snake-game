using static System.Console;

namespace SnakeGame
{
    public class Snake
    {
        private readonly char snakeHead = (char)Configurations.SNAKE_HEAD;
        private readonly char snakeBody = (char)Configurations.SNAKE_BODY;
        private readonly char snakeTail = (char)Configurations.SNAKE_TAIL;
        private readonly ConsoleColor snakeColor = (ConsoleColor)Configurations.SNAKE_COLOR;

        public List<Point> Positions { get; set; } = [];

        public void DrawSnake()
        {
            ForegroundColor = snakeColor;

            for (int i = 0; i < Positions.Count; i++)
            {
                SetCursorPosition(Positions[i].x, Positions[i].y);
                if (i == 0) Write(snakeHead);
                else if (i == (Positions.Count - 1)) Write(snakeTail);
                else Write(snakeBody);
            }
            ResetColor();
        }

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