using static System.Console;

namespace SnakeGame
{
    public class Snake
    {
        private readonly char snakeHead = '@';
        private readonly char snakeBody = 'O';
        private readonly char snakeTail = 'o';
        private readonly ConsoleColor snakeColor = ConsoleColor.Green;

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
    }
}