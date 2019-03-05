using System;

namespace hw2._1
{
    /// <summary>
    /// Interaction with user and execution of commands entered by user.
    /// </summary>
    class Commands : ICommands
    {
        /// <summary>
        /// Prints commands that user can enter.
        /// </summary>
        public void PrintCommands()
        {
            Console.WriteLine("Commands:");
            Console.WriteLine("0 - exit");
            Console.WriteLine("1 - add new element in list by its position");
            Console.WriteLine("2 - delete element from list by its position");
            Console.WriteLine("3 - get size of the list");
            Console.WriteLine("4 - check if the list is empty");
            Console.WriteLine("5 - get data of list's element by its position");
            Console.WriteLine("6 - set data of list's element by its position");
            Console.WriteLine("7 - print list");
            Console.WriteLine("Enter the command");
        }

        /// <summary>
        /// Performs an action depending on the entered command.
        /// </summary>
        /// <param name="list">List to work with.</param>
        /// <param name="command">Command entered by user.</param>
        public void CommandExecution(List list, int command)
        {
            var data = 0;
            var position = 0;
            switch (command)
            {
                case 0:
                    break;

                case 1:
                    Console.WriteLine("Enter the position of element in list");
                    position = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the data");
                    data = int.Parse(Console.ReadLine());

                    if (!list.AddElement(position, data))
                    {
                        Console.WriteLine("The position you entered is incorrect");
                    }
                    break;

                case 2:
                    Console.WriteLine("Enter the position of element you'd like to delete");
                    position = int.Parse(Console.ReadLine());
                    if (!list.DeleteElement(position))
                    {
                        Console.WriteLine("The position you entered is incorrect");
                    }
                    break;

                case 3:
                    Console.WriteLine($"Size of the list is {list.Size}");
                    break;

                case 4:
                    if (list.IsEmpty())
                    {
                        Console.WriteLine("The list is empty");
                    }
                    else
                    {
                        Console.WriteLine("The list is not empty");
                    }
                    break;

                case 5:
                    Console.WriteLine("Enter the position of element in list");
                    position = int.Parse(Console.ReadLine());

                    data = list.GetData(position);

                    if (data == ' ')
                    {
                        Console.WriteLine("The position you entered is incorrect");
                    }
                    else
                    {
                        Console.WriteLine($"Data of the element in position {position} is {list.GetData(position)}");
                    }
                    break;

                case 6:
                    Console.WriteLine("Enter the position of element in list");
                    position = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the data");
                    data = int.Parse(Console.ReadLine());

                    if (!list.SetData(position, data))
                    {
                        Console.WriteLine("The position you entered is incorrect");
                    }
                    break;

                case 7:
                    if (list.IsEmpty())
                    {
                        Console.WriteLine("The list is empty");
                    }
                    else
                    {
                        list.PrintList();
                    }
                    break;

                default:
                    Console.WriteLine("The command you entered is incorrect");
                    break;
            }
        }
    }
}
