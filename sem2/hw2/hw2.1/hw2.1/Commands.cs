using System;

namespace hw2._1
{
    class Commands
    {
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

        bool IsCorrectPositionToAdd(List list, int position) => position > 0 && position <= list.size + 1;

        bool IsCorrectPosition(List list, int position) => position > 0 && position <= list.size;

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
                    if (!IsCorrectPositionToAdd(list, position))
                    {
                        Console.WriteLine("The position you entered is incorrect");
                        break;
                    }

                    Console.WriteLine("Enter the data");
                    data = int.Parse(Console.ReadLine());

                    list.AddElement(position, data);
                    break;

                case 2:
                    Console.WriteLine("Enter the position of element you'd like to delete");
                    position = int.Parse(Console.ReadLine());
                    if (!IsCorrectPosition(list, position))
                    {
                        Console.WriteLine("The position you entered is incorrect");
                        break;
                    }

                    list.DeleteElement(position);
                    break;

                case 3:
                    Console.WriteLine($"Size of the list is {list.size}");
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
                    if (!IsCorrectPosition(list, position))
                    {
                        Console.WriteLine("The position you entered is incorrect");
                        break;
                    }

                    Console.WriteLine($"Data of the element in position {position} is {list.GetData(position)}");
                    break;

                case 6:
                    Console.WriteLine("Enter the position of element in list");
                    position = int.Parse(Console.ReadLine());
                    if (!IsCorrectPosition(list, position))
                    {
                        Console.WriteLine("The position you entered is incorrect");
                        break;
                    }

                    Console.WriteLine("Enter the data");
                    data = int.Parse(Console.ReadLine());

                    list.SetData(position, data);
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
            return;
        }
    }
}
