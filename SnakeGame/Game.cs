using static System.Console;

namespace SnakeGame
{
    public class Game
    {
        private bool gameOver = false;
        Snake snake = new Snake();
        Map map = new Map();

        public void Run()
        {
            CursorVisible = false;
            InitSnake();

            while (!gameOver)
            {
                Draw();
                Input();
                Logic();
                Thread.Sleep(200);
            }
        }

        private void InitSnake()
        {
            snake?.X?.Add(map.EndX / 2);
            snake?.Y?.Add(map.EndY / 2);
        }

        private void Logic()
        {

        }

        private void Input()
        {

        }

        private void Draw()
        {
            Clear();
            map.DrawMap();
            snake.DrawSnake();
        }
    }
}