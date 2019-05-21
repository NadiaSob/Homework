using System;

namespace test1
{
    /// <summary>
    /// Interaction with user and execution of commands entered by user.
    /// </summary>
    public class Commands
    {
        /// <summary>
        /// Prints commands that user can enter.
        /// </summary>
        public void PrintCommands()
        {
            Console.WriteLine("Commands:");
            Console.WriteLine("0 - exit");
            Console.WriteLine("1 - add new element in queue");
            Console.WriteLine("2 - return element with the highest priority and delete it");
            Console.WriteLine("3 - print queue");
            Console.WriteLine("Enter the command");
        }

        /// <summary>
        /// Performs an action depending on the entered command.
        /// </summary>
        /// <param name="queue">Priority queue to work with.</param>
        /// <param name="command">Command entered by user.</param>
        public void DoCommand(PriorityQueue queue, int command)
        {
            switch (command)
            {
                case 0:
                    break;

                case 1:
                    {
                        Console.WriteLine("Enter the priority of element in list");
                        var priority = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the data");
                        var data = Console.ReadLine();

                        queue.Enqueue(data, priority);
                        break;
                    }

                case 2:
                    {
                        Console.WriteLine(queue.Dequeue());
                        break;
                    }

                case 3:
                    {
                        queue.PrintQueue();
                        break;
                    }

                default:
                    Console.WriteLine("The command you entered is incorrect.");
                    break;
            }
        }
    }
}
