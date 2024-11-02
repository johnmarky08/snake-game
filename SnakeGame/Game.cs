using System.Text;
using static System.Console;

namespace SnakeGame
{
    public class Game
    {
        private bool gameOver = false;
        private int score = 0;
        private int totalScore = 0;
        private readonly Fruit fruit = new();
        private Direction direction = Direction.STOP;

        private readonly StringBuilder buffer = new();

        public class Map
        {
            public static readonly Point End = new((int)Configuration.WIDTH, (int)Configuration.HEIGHT);
        }

        public class Fruit
        {
            public Point Position { get; set; }
        }

        public void Run()
        {
            CursorVisible = false;
            SpawnFruit();

            while (!gameOver)
            {
                DrawToBuffer();
                Draw();
                Input();
                Logic();
                Thread.Sleep((int)Configuration.SPEED);
            }

            PlayAgain();
        }

        public void PlayAgain()
        {
            Clear();

            bool playAgain = false;
            while (!playAgain)
            {
                WriteLine("\r\n░██████╗░░█████╗░███╗░░░███╗███████╗  ░█████╗░██╗░░░██╗███████╗██████╗░\r\n██╔════╝░██╔══██╗████╗░████║██╔════╝  ██╔══██╗██║░░░██║██╔════╝██╔══██╗\r\n██║░░██╗░███████║██╔████╔██║█████╗░░  ██║░░██║╚██╗░██╔╝█████╗░░██████╔╝\r\n██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░  ██║░░██║░╚████╔╝░██╔══╝░░██╔══██╗\r\n╚██████╔╝██║░░██║██║░╚═╝░██║███████╗  ╚█████╔╝░░╚██╔╝░░███████╗██║░░██║\r\n░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝  ░╚════╝░░░░╚═╝░░░╚══════╝╚═╝░░╚═╝");

                WriteLine("\n\nDeveloped by: John Marky Dev");
                WriteLine($"\nYour Current Score: {score}");
                WriteLine($"Your Total Score: {totalScore}");

                WriteLine("\nDo you want to play again?");
                WriteLine("Press \"R\" to Restart.");
                WriteLine("Press \"E\" to Exit.");

                ConsoleKey pressedKey = ReadKey(true).Key;
                if (pressedKey == ConsoleKey.R) playAgain = true;
                else if ((pressedKey == ConsoleKey.E) || (pressedKey == ConsoleKey.Escape)) return;

                Clear();
            }

            gameOver = false;
            score = 0;

            Positions.Clear();
            Positions.Add(new Point(Map.End.X / 2, Map.End.Y / 2));

            direction = Direction.STOP;
            SpawnFruit();
            Run();
        }



        public List<Point> Positions { get; set; } = [];

        public void Move(Direction direction)
        {
            for (int i = Positions.Count - 1; i > 0; i--) Positions[i] = Positions[i - 1];
            switch (direction)
            {
                case Direction.UP:
                    {
                        Positions[0] += Point.Up;
                        break;
                    }
                case Direction.DOWN:
                    {
                        Positions[0] += Point.Down;
                        break;
                    }
                case Direction.RIGHT:
                    {
                        Positions[0] += Point.Right;
                        break;
                    }
                case Direction.LEFT:
                    {
                        Positions[0] += Point.Left;
                        break;
                    }
            }
        }

        private void SpawnFruit()
        {
            bool canSpawn = true;
            do
            {
                Random random = new();
                int x = random.Next(1, Map.End.X - 1);
                int y = random.Next(1, Map.End.Y - 1);

                fruit.Position = new Point(x, y);

                for (int i = 0; i < Positions.Count; i++)
                {
                    if (fruit.Position == Positions[i]) canSpawn = false;
                }
            }
            while (!canSpawn);
        }

        private void Logic()
        {
            Move(direction);
            CheckCollision();
            EatFruit();
        }

        private void EatFruit()
        {
            if (Positions[0] == fruit.Position)
            {
                SpawnFruit();
                Positions.Add(new Point(Positions[^1].X, Positions[^1].Y));
                score += 10;
                totalScore += 10;
            }
        }

        private void CheckCollision()
        {
            if (Positions[0].X <= 0 || Positions[0].X >= Map.End.X - 1 || Positions[0].Y <= 0 || Positions[0].Y >= Map.End.Y - 1)
                gameOver = true;

            for (int i = 2; i < Positions.Count; i++)
            {
                if (Positions[0] == Positions[i]) gameOver = true;
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
                        if (direction != Direction.DOWN) direction = Direction.UP;
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                    case ConsoleKey.NumPad5:
                        if (direction != Direction.UP) direction = Direction.DOWN;
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                    case ConsoleKey.NumPad6:
                        if (direction != Direction.LEFT) direction = Direction.RIGHT;
                        break;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                    case ConsoleKey.NumPad4:
                        if (direction != Direction.RIGHT) direction = Direction.LEFT;
                        break;
                    case ConsoleKey.Escape:
                        gameOver = true;
                        break;
                }
            }
        }

        private void DrawToBuffer()
        {
            buffer.Clear();
            for (int y = 0; y < Map.End.Y; y++)
            {
                for (int x = 0; x < Map.End.X; x++)
                {
                    if (x == 0 || x == Map.End.X - 1 || y == 0 || y == Map.End.Y - 1)
                    {
                        buffer.Append((char)Configuration.WALL_TOKEN);
                    }
                    else if (x == fruit.Position.X && y == fruit.Position.Y)
                    {
                        buffer.Append((char)Configuration.FRUIT_TOKEN);
                    }
                    else if (x == Positions[0].X && y == Positions[0].Y)
                    {
                        buffer.Append((char)Configuration.SNAKE_HEAD);
                    }
                    else if (Positions.Contains(new Point(x, y)))
                    {
                        if (Positions.IndexOf(new Point(x, y)) == Positions.Count - 1)
                        {
                            buffer.Append((char)Configuration.SNAKE_TAIL);
                        }
                        else
                        {
                            buffer.Append((char)Configuration.SNAKE_BODY);
                        }
                    }
                    else
                    {
                        buffer.Append(' ');
                    }
                }
                buffer.AppendLine();
            }
        }

        private void Draw()
        {
            SetCursorPosition(0, 0);
            Write(buffer.ToString());
            SetColors();
            DrawScoreAndGuides();
        }

        private void DrawScoreAndGuides()
        {
            int guides = (int)Configuration.WIDTH / 2;
            int dash = guides - 6;
            int meaning = dash - 2;


            SetCursorPosition(0, Map.End.Y);
            Write($"Your Score: {score}");

            SetCursorPosition(Map.End.X - guides, Map.End.Y);
            WriteLine("W | ^");

            SetCursorPosition(Map.End.X - guides, Map.End.Y + 1);
            WriteLine("A | <");

            SetCursorPosition(Map.End.X - guides, Map.End.Y + 2);
            WriteLine("S | v");

            SetCursorPosition(Map.End.X - guides, Map.End.Y + 3);
            WriteLine("D | >");

            for (int i = 0; i < 4; i++)
            {
                SetCursorPosition(Map.End.X - dash, Map.End.Y + i);
                WriteLine("-");
            }

            SetCursorPosition(Map.End.X - meaning, Map.End.Y);
            WriteLine("Go Up");

            SetCursorPosition(Map.End.X - meaning, Map.End.Y + 1);
            WriteLine("Go Left");

            SetCursorPosition(Map.End.X - meaning, Map.End.Y + 2);
            WriteLine("Go Down");

            SetCursorPosition(Map.End.X - meaning, Map.End.Y + 3);
            WriteLine("Go Right");
        }

        private void SetColors()
        {
            ForegroundColor = (ConsoleColor)Configuration.WALL_COLOR;
            for (int x = 0; x < Map.End.X; x++)
            {
                SetCursorPosition(x, 0);
                Write((char)Configuration.WALL_TOKEN);
                SetCursorPosition(x, Map.End.Y - 1);
                Write((char)Configuration.WALL_TOKEN);
            }

            for (int y = 1; y < Map.End.Y - 1; y++)
            {
                SetCursorPosition(0, y);
                Write((char)Configuration.WALL_TOKEN);
                SetCursorPosition(Map.End.X - 1, y);
                Write((char)Configuration.WALL_TOKEN);
            }

            ForegroundColor = (ConsoleColor)Configuration.FRUIT_COLOR;
            SetCursorPosition(fruit.Position.X, fruit.Position.Y);
            Write((char)Configuration.FRUIT_TOKEN);

            ForegroundColor = (ConsoleColor)Configuration.SNAKE_COLOR;
            for (int i = 0; i < Positions.Count; i++)
            {
                var segment = Positions[i];
                SetCursorPosition(segment.X, segment.Y);
                if (i == 0)
                {
                    Write((char)Configuration.SNAKE_HEAD);
                }
                else if (i == Positions.Count - 1)
                {
                    Write((char)Configuration.SNAKE_TAIL);
                }
                else
                {
                    Write((char)Configuration.SNAKE_BODY);
                }
            }

            ResetColor();
        }
    }
}
