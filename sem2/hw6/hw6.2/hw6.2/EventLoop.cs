using System;

namespace hw6._2
{
    /// <summary>
    /// Class reacting to user's actions.
    /// </summary>
    public class EventLoop
    {
        public event EventHandler<EventArgs> UpHandler = (sender, args) => { };
        public event EventHandler<EventArgs> DownHandler = (sender, args) => { };
        public event EventHandler<EventArgs> LeftHandler = (sender, args) => { };
        public event EventHandler<EventArgs> RightHandler = (sender, args) => { };

        /// <summary>
        /// Does certain actions depending on the key pressed by user.
        /// </summary>
        public void Run()
        {
            while (true)
            {
                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        UpHandler(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.DownArrow:
                        DownHandler(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.LeftArrow:
                        LeftHandler(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.RightArrow:
                        RightHandler(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.Escape:
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        return;
                }
            }
        }
    }
}
