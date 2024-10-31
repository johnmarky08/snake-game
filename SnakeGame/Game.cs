using System.Runtime.InteropServices;
using static System.Console;

namespace SnakeGame
{
    public class Game
    {
        private bool gameOver = false;
        private int score = 0;
        readonly Snake snake = new();
        readonly Map map = new();
        readonly Fruit fruit = new();
        private Direction direction = Direction.STOP;

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
                Thread.Sleep(100);
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
            snake.Move(direction);
            CheckCollision();
            EatFruit();
        }

        private void EatFruit()
        {
            if (snake.Positions[0] == fruit.Position)
            {
                SpawnFruit();
                snake.Positions.Add(new Point(snake.Positions[^1].x, snake.Positions[^1].y));
                score += 10;
            }
        }

        private void CheckCollision()
        {
            if (snake.Positions[0].x <= 0 || snake.Positions[0].x >= Map.End.x - 1 || snake.Positions[0].y <= 0 || snake.Positions[0].y >= Map.End.y - 1) gameOver = true;
            
            for (int i = 2; i < snake.Positions.Count; i++)
            {
                if (snake.Positions[0] == snake.Positions[i]) gameOver = true;
            }
        }

        private void Input()
        {
            if (KeyAvailable)
            {
                ConsoleKey key;
                do
                {
                    key = ReadKey(true).Key;
                } while (KeyAvailable);

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                    case ConsoleKey.NumPad8:
                        {
                            if (direction != Direction.DOWN) direction = Direction.UP;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                    case ConsoleKey.NumPad5:
                        {
                            if (direction != Direction.UP) direction = Direction.DOWN;
                            break;
                        }
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                    case ConsoleKey.NumPad6:
                        {
                            if (direction != Direction.LEFT) direction = Direction.RIGHT;
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                    case ConsoleKey.NumPad4:
                        {
                            if (direction != Direction.RIGHT) direction = Direction.LEFT;
                            break;
                        }
                }
            }
        }

        private void Draw()
        {
            Clear();
            map.DrawMap();
            fruit.DrawFruit();
            snake.DrawSnake();
            DrawScore();
        }

        private void DrawScore()
        {
            SetCursorPosition(0, Map.End.y);
            Write($"Your Score: {score}");
        }
    }
}