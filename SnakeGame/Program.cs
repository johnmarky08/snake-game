using System.Runtime.InteropServices;

namespace SnakeGame
{
    internal class Program
    {
        static void Main()
        {
            int width = (int)Configurations.WIDTH;
            int height = (int)Configurations.HEIGHT + 1;

            Console.SetWindowSize(width, height);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) Console.SetBufferSize(width, height);

            int bufferWidth = Console.BufferWidth;
            int bufferHeight = Console.BufferHeight;

            int left = (bufferWidth - width) / 2;
            int top = (bufferHeight - height) / 2;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) Console.SetWindowPosition(left, top);

            var game = new Game();
            game.Run();
        }
    }
}
