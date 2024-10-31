using static System.Console;

namespace SnakeGame
{
    public class Snake
    {
        private char snakeHead = '@';
        private char snakeBody = 'O';
        private char snakeTail = 'o';
        private ConsoleColor snakeColor = ConsoleColor.Green;

        public List<int>? X { get; set; }
        public List<int>? Y { get; set; }

      public void DrawSnake()
        {
            X = new List<int>();
            Y = new List<int>();

            ForegroundColor = snakeColor;

            for (int i = 0; i < X.Count; i++)
            {
                SetCursorPosition(X[i], Y[i]);
                if (i == 0) Write(snakeHead);
                else if (i == (X.Count - 1)) Write(snakeTail);
                else Write(snakeBody);
            }
            ResetColor();
        }
    }
}