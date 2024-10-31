using static System.Console;

namespace SnakeGame
{
    public class Map
    {
        public static readonly Point End = new(30, 25);

        private readonly char wallToken = '#';
        private readonly ConsoleColor wallColor = ConsoleColor.Gray;

        public void DrawMap()
        {
            ForegroundColor = wallColor;

            for (int x = 0; x < End.x; x++)
            {
                SetCursorPosition(x, 0);
                Write(wallToken);
                SetCursorPosition(x, End.y - 1);
                Write(wallToken);
            }

            for (int y = 0; y < End.y; y++)
            {
                SetCursorPosition(0, y);
                Write(wallToken);
                SetCursorPosition(End.x - 1, y);
                Write(wallToken);
            }

            ResetColor();
        }
    }
}