using System;
using System.Collections.Generic;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter five strings");

            var array = new string[5];
            var sortedSet = new SortedSet();

            for (var i = 0; i < 5; ++i)
            {
                array[i] = Console.ReadLine();
                string[] words = array[i].Split(' ');

                var list = new List<string>();
                foreach (var word in words)
                {
                    list.Add(word);
                }
                sortedSet.AddElement(list);
            }

            Console.WriteLine("Sorted set:");
            sortedSet.PrintSet();
        }
    }
}
