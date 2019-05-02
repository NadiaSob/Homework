using System;

namespace hw6._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventLoop = new EventLoop();
            var game = new Game("..\\..\\Map.txt");

            eventLoop.UpHandler += game.OnUp;
            eventLoop.DownHandler += game.OnDown;
            eventLoop.LeftHandler += game.OnLeft;
            eventLoop.RightHandler += game.OnRight;

            eventLoop.Run();
        }
    }
}
