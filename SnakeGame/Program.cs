#pragma warning disable SYSLIB1054
using System.Runtime.InteropServices;
using static SnakeGame.Game;

namespace SnakeGame
{
    internal class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_MAXIMIZE = 3;

        static void Main()
        {
            IntPtr consoleWindow = GetConsoleWindow();

            if (consoleWindow != IntPtr.Zero)
            {
                ShowWindow(consoleWindow, SW_MAXIMIZE);
            }
            else
            {
                Console.WriteLine("Failed to get console window handle.");
            }

            bool pressed = false;
            while (!pressed)
            {
                Console.WriteLine("\r\n░██████╗███╗░░██╗░█████╗░██╗░░██╗███████╗  ░██████╗░░█████╗░███╗░░░███╗███████╗\r\n██╔════╝████╗░██║██╔══██╗██║░██╔╝██╔════╝  ██╔════╝░██╔══██╗████╗░████║██╔════╝\r\n╚█████╗░██╔██╗██║███████║█████═╝░█████╗░░  ██║░░██╗░███████║██╔████╔██║█████╗░░\r\n░╚═══██╗██║╚████║██╔══██║██╔═██╗░██╔══╝░░  ██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░\r\n██████╔╝██║░╚███║██║░░██║██║░╚██╗███████╗  ╚██████╔╝██║░░██║██║░╚═╝░██║███████╗\r\n╚═════╝░╚═╝░░╚══╝╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝  ░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝");
                Console.WriteLine("\n\nDeveloped by: John Marky Dev");
                Console.WriteLine("\n> Press \"S\" to start the game!");
                Console.WriteLine("> Press \"E\" to exit.");
                Console.CursorVisible = false;

                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.S) pressed = true;
                else if ((key == ConsoleKey.E) || (key == ConsoleKey.Escape)) return;

                Console.Clear();
            }

            var game = new Game();

            game.Positions.Add(new Point(Map.End.X / 2, Map.End.Y / 2));
            game.Run();
        }
    }
}
