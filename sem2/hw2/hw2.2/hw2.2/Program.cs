using System;

namespace hw2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashTable = new HashTable();
            var commands = new Commands();
            var command = 1;

            while (command != 0)
            {
                commands.PrintCommands();
                command = int.Parse(Console.ReadLine());
                commands.CommandExecution(hashTable, command);
            }
        }
    }
}
