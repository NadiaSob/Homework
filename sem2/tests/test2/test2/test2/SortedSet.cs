using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2
{
    /// <summary>
    /// Realisation of sorted set.
    /// </summary>
    public class SortedSet
    {
        public SortedSet()
        {
            comparer = new Comparer<List<string>>();
            Size = 0;
        }

        private class Element
        {
            public List<string> Data { get; set; }
            public Element Next { get; set; }
            public int Position { get; set; }

            public Element(List<string> data, Element next)
            {
                Data = data;
                Next = next;
            }
        }

        private Element head;

        private readonly IComparer<List<string>> comparer;

        /// <summary>
        /// Number of elements in set.
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Checks is set is empty.
        /// </summary>
        /// <returns>True if the set is empty, else false.</returns>
        public bool IsEmpty() => head == null;

        /// <summary>
        /// Adds element in the correct set position.
        /// </summary>
        /// <param name="data">Element to add.</param>
        public void AddElement(List<string> data)
        {
            var newElement = new Element(data, null);

            if (IsEmpty())
            {
                head = newElement;
                ++Size;
                return;
            }

            Element nextElement = head;
            Element previousElement = null;

            while (nextElement != null && comparer.Compare(newElement.Data, nextElement.Data) == 1)
            {
                ++nextElement.Position;
                --newElement.Position;
                previousElement = nextElement;
                nextElement = previousElement.Next;
            }
            if (nextElement != head)
            {
                newElement.Next = nextElement;
                previousElement.Next = newElement;
            }
            else
            {
                newElement.Next = head;
                head = newElement;
            }
            ++Size;
        }

        /// <summary>
        /// Prints sorted set.
        /// </summary>
        public void PrintSet()
        {
            if (!IsEmpty())
            {
                var elementToPrint = head;

                while (elementToPrint != null)
                {
                    for (var i = 0; i < elementToPrint.Data.Count; ++i)
                    {
                        Console.Write($"{elementToPrint.Data[i]} ");
                    }
                    Console.WriteLine();
                    elementToPrint = elementToPrint.Next;
                }
            }
        }
    }
}
