using System;

namespace hw4._2
{
    /// <summary>
    /// Interaction with user and execution of commands entered by user.
    /// </summary>
    class Commands
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
            Console.WriteLine("3 - delete element from list by its data");
            Console.WriteLine("4 - get size of the list");
            Console.WriteLine("5 - check if the list is empty");
            Console.WriteLine("6 - get data of list's element by its position");
            Console.WriteLine("7 - set data of list's element by its position");
            Console.WriteLine("8 - print list");
            Console.WriteLine("Enter the command");
        }

        /// <summary>
        /// Performs an action depending on the entered command.
        /// </summary>
        /// <param name="list">List to work with.</param>
        /// <param name="command">Command entered by user.</param>
        public void DoCommand(IList list, int command)
        {
            try
            {
                switch (command)
                {
                    case 0:
                        break;

                    case 1:
                        {
                            Console.WriteLine("Enter the position of element in list");
                            var position = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter the data");
                            var data = Console.ReadLine();

                            list.AddElement(position, data);
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine("Enter the position of element you'd like to delete");
                            var position = int.Parse(Console.ReadLine());

                            list.DeleteElementByPosition(position);
                            break;
                        }

                    case 3:
                        {
                            Console.WriteLine("Enter the element you'd like to delete");
                            var data = Console.ReadLine();

                            list.DeleteElementByData(data);
                            break;
                        }

                    case 4:
                        Console.WriteLine($"Size of the list is {list.Size}.");
                        break;

                    case 5:
                        if (list.IsEmpty())
                        {
                            Console.WriteLine("The list is empty");
                        }
                        else
                        {
                            Console.WriteLine("The list is not empty");
                        }
                        break;

                    case 6:
                        {
                            Console.WriteLine("Enter the position of element in list");
                            var position = int.Parse(Console.ReadLine());

                            var data = list.GetData(position);

                            Console.WriteLine($"Data of the element in position {position} is {list.GetData(position)}");
                            break;
                        }

                    case 7:
                        {
                            Console.WriteLine("Enter the position of element in list");
                            var position = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter the data");
                            var data = Console.ReadLine();

                            list.SetData(position, data);
                            break;
                        }

                    case 8:
                        if (list.IsEmpty())
                        {
                            Console.WriteLine("The list is empty.");
                        }
                        else
                        {
                            list.PrintList();
                        }
                        break;

                    default:
                        Console.WriteLine("The command you entered is incorrect.");
                        break;
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("The position you entered is incorrect.");
            }
            catch(ElementAlreadyExistsException)
            {
                Console.WriteLine("This element already exists.");
            }
            catch (ElementDoesNotExistException)
            {
                Console.WriteLine("The element is not found.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Something you entered is incorrect.");
            }
        }
    }
}
