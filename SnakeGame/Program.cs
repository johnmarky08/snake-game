using System.Runtime.InteropServices;

namespace SnakeGame
{
    internal class Program
    {
        static void Main()
        {
            Console.SetWindowSize((int)Configurations.WIDTH, (int)Configurations.HEIGHT + 1);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) Console.SetBufferSize((int)Configurations.WIDTH, (int)Configurations.HEIGHT + 1);

            var game = new Game();
            game.Run();
        }
    }
}
