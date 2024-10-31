using static System.Console;

namespace SnakeGame
{
    public class Game
    {
        private readonly bool gameOver = false;
        readonly Snake snake = new();
        readonly Map map = new();
        readonly Fruit fruit = new();

        public void Run()
        {
            CursorVisible = false;
            snake.Positions.Add(new Point(Map.End.x / 2, Map.End.y / 2));
            SpawnFruit();

            while (!gameOver)
            {
                Draw();
                Input();
                Logic();
                Thread.Sleep(200);
            }
        }

        private void SpawnFruit()
        {
            bool canSpawn = true;
            do
            {
                Random random = new();
                int x = random.Next(1, Map.End.x - 1);
                int y = random.Next(1, Map.End.y - 1);

                fruit.Position = new Point(x, y);

                for (int i = 0; i < snake.Positions.Count; i++)
                {
                    if (fruit.Position == snake.Positions[i]) canSpawn = false;
                }
            }
            while (!canSpawn);
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
            fruit.DrawFruit();
            snake.DrawSnake();
        }
    }
}