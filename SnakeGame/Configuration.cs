namespace SnakeGame
{
    public enum Configuration
    {
        SPEED = 200,
        WIDTH = 40,
        HEIGHT = 35,
        WALL_TOKEN = '"',
        FRUIT_TOKEN = '$',
        SNAKE_HEAD = '@',
        SNAKE_BODY = 'O',
        SNAKE_TAIL = 'o',
        WALL_COLOR = ConsoleColor.Gray,
        FRUIT_COLOR = ConsoleColor.Red,
        SNAKE_COLOR = ConsoleColor.Green,
    }

    public enum Direction
    {
        STOP, UP, DOWN, RIGHT, LEFT
    }
}
