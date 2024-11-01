#pragma warning disable SYSLIB1054
using System.Runtime.InteropServices;

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

            var game = new Game();
            game.Run();
        }
    }
}
