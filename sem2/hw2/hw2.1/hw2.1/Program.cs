using System;

namespace hw2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List();
            Commands commands = new Commands();
            var command = 1;

            while (command != 0)
            {
                commands.PrintCommands();
                command = int.Parse(Console.ReadLine());
                commands.CommandExecution(list, command);
            }
        }
    }
}
