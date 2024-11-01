namespace SnakeGame
{
    public enum Configuration
    {
        WIDTH = 60,
        HEIGHT = 30,
        WALL_TOKEN = '#',
        FRUIT_TOKEN = '%',
        SNAKE_HEAD = '@',
        SNAKE_BODY = 'O',
        SNAKE_TAIL = 'o',
        WALL_COLOR = ConsoleColor.Gray,
        FRUIT_COLOR = ConsoleColor.Red,
        SNAKE_COLOR = ConsoleColor.Green
    }

    public enum Direction
    {
        STOP, UP, DOWN, RIGHT, LEFT
    }
}
