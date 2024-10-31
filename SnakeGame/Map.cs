using static System.Console;

namespace SnakeGame
{
    public class Map
    {
        public int EndX => 30;
        public int EndY => 25;

        private char wallToken = '#';
        private ConsoleColor wallColor = ConsoleColor.Gray;

        public void DrawMap()
        {
            ForegroundColor = wallColor;

            for (int x = 0; x < EndX; x++)
            {
                SetCursorPosition(x, 0);
                Write(wallToken);
                SetCursorPosition(x, EndY - 1);
                Write(wallToken);
            }

            for (int y = 0; y < EndY; y++)
            {
                SetCursorPosition(0, y);
                Write(wallToken);
                SetCursorPosition(EndX - 1, y);
                Write(wallToken);
            }

            ResetColor();
        }
    }
}