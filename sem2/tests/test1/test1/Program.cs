using System;

namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new PriorityQueue();
            var commands = new Commands();
            var command = 1;

            while (command != 0)
            {
                commands.PrintCommands();
                command = int.Parse(Console.ReadLine());
                commands.DoCommand(queue, command);
            }
        }
    }
}
