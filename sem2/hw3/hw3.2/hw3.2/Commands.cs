using System;

namespace hw3._2
{
    /// <summary>
    /// Interaction with user and execution of commands entered by user.
    /// </summary>
    class Commands
    {
        /// <summary>
        /// Prints names of hash functions that user can use in hash table.
        /// </summary>
        public void PrintChoiceOfHash()
        {
            Console.WriteLine("Choose hash function that will be used in hash table:");
            Console.WriteLine("1 - PJW hash function");
            Console.WriteLine("2 - FNV hash function");
            Console.WriteLine("3 - Jenkins hash function");
            Console.WriteLine("Enter the number of chosen hash function");
        }

        public IHash ChooseHash(int command)
        {
            switch (command)
            {
                case 1:
                    return new PJWHash();
                case 2:
                    return new FNVHash();
                case 3:
                    return new JenkinsHash();
                default:
                    throw new FormatException("Incorrect command");
            }
        }

        /// <summary>
        /// Prints commands that user can enter.
        /// </summary>
        public void PrintCommands()
        {
            Console.WriteLine("Commands:");
            Console.WriteLine("0 - exit");
            Console.WriteLine("1 - add new element in hash table");
            Console.WriteLine("2 - delete element from hash table");
            Console.WriteLine("3 - check if the element of hash table exists");
            Console.WriteLine("4 - print hash table");
            Console.WriteLine("Enter the command");
        }

        /// <summary>
        /// Performs an action depending on the entered command.
        /// </summary>
        /// <param name="hashTable">Hash table to work with.</param>
        /// <param name="command">Command entered by user.</param>
        public void DoCommand(IHashTable hashTable, int command)
        {
            switch (command)
            {
                case 0:
                    break;

                case 1:
                    {
                        Console.WriteLine("Enter the data of element you want to add");
                        var data = Console.ReadLine();

                        if (!hashTable.Add(data))
                        {
                            Console.WriteLine("The element with the given data already exists");
                        }
                        break;
                    }

                case 2:
                    Console.WriteLine("Enter the data of element you want to delete");
                    {
                        var data = Console.ReadLine();

                        if (!hashTable.Delete(data))
                        {
                            Console.WriteLine("The element with the given data does not exists");
                        }
                        break;
                    }

                case 3:
                    {
                        Console.WriteLine("Enter the data of hash table element");
                        var data = Console.ReadLine();

                        if (hashTable.Exists(data))
                        {
                            Console.WriteLine("The element with the given data exists");
                        }
                        else
                        {
                            Console.WriteLine("The element with the given data does not exists");
                        }
                        break;
                    }

                case 4:
                    Console.WriteLine("The hash table:");
                    hashTable.Print();
                    break;

                default:
                    Console.WriteLine("The command you entered is incorrect");
                    break;
            }
        }
    }
}
