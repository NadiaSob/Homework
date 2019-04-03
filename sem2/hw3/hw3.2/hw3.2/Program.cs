using System;

namespace hw3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = new Commands();

            commands.PrintChoiceOfHash();

            var command = int.Parse(Console.ReadLine());
            var hash = commands.ChooseHash(command);
            var hashTable = new HashTable(hash);

            while (command != 0)
            {
                commands.PrintCommands();
                command = int.Parse(Console.ReadLine());
                commands.CommandExecution(hashTable, command);
            }
        }
    }
}
