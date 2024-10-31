using static System.Console;

namespace SnakeGame
{
    public class Fruit
    {
        public Point Position {  get; set; }
        
        private readonly char fruitToken = (char)Configurations.FRUIT_TOKEN;
        private readonly ConsoleColor fruitColor = (ConsoleColor)Configurations.FRUIT_COLOR;

        public void DrawFruit()
        {
            ForegroundColor = fruitColor;
            SetCursorPosition(Position.x, Position.y);
            Write(fruitToken);
            ResetColor();
        }
    }
}
