using static System.Console;

namespace SnakeGame
{
    public class Fruit
    {
        public Point Position {  get; set; }
        
        private readonly char fruitToken = '%';
        private readonly ConsoleColor fruitColor = ConsoleColor.Red;

        public void DrawFruit()
        {
            ForegroundColor = fruitColor;
            SetCursorPosition(Position.x, Position.y);
            Write(fruitToken);
            ResetColor();
        }
    }
}
