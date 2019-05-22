using System;

namespace hw4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new UniqueList();
            var commands = new Commands();
            var command = 1;

            while (command != 0)
            {
                commands.PrintCommands();
                command = int.Parse(Console.ReadLine());
                commands.DoCommand(list, command);
            }
        }
    }
}
