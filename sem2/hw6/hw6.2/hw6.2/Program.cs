using System;

namespace hw6._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.WriteLine("Welcome to my game!");
            Console.WriteLine("Use arrow keys to move the character.");
            Console.WriteLine("Try not to crash into walls.");
            Console.WriteLine("If you want to exit game, press Esc.");
            Console.WriteLine("Press Enter to start.");

            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine("Press Enter to start!");
            }

            var eventLoop = new EventLoop();
            var game = new Game("..\\..\\Map.txt");

            game.PrintMap();

            eventLoop.UpHandler += game.OnUp;
            eventLoop.DownHandler += game.OnDown;
            eventLoop.LeftHandler += game.OnLeft;
            eventLoop.RightHandler += game.OnRight;

            eventLoop.UpHandler += game.ChangeMap;
            eventLoop.DownHandler += game.ChangeMap;
            eventLoop.LeftHandler += game.ChangeMap;
            eventLoop.RightHandler += game.ChangeMap;

            try
            {
                eventLoop.Run();
            }
            catch (CrashingIntoWallException)
            {
                Console.Clear();
                Console.WriteLine("Oops, you failed...");
            }
        }
    }
}
