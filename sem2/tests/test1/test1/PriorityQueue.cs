using System;

namespace test1
{
    /// <summary>
    /// Queue data structure where each element has a priority associated with it.
    /// </summary>
    public class PriorityQueue
    {
        private class Element
        {
            public string Data { get; set; }
            public int Priority { get; set; }
            public Element Next;

            public Element(string data, int priority)
            {
                Data = data;
                Priority = priority;
            }
        }

        private Element head;

        /// <summary>
        /// Checks if the priority queue has no elements in it.
        /// </summary>
        /// <returns>True if the priority queue is empty, else false.</returns>
        public bool IsEmpty() => head == null;

        /// <summary>
        /// Adds new queue element in the correct place depending on the given priority.
        /// </summary>
        /// <param name="data">Element to add.</param>
        /// <param name="priority">Priority of the element.</param>
        public void Enqueue(string data, int priority)
        {
            var newElement = new Element(data, priority);
            
            if (IsEmpty())
            {
                head = newElement;
                return;
            }

            if (head.Priority < priority)
            {
                newElement.Next = head;
                head = newElement;
                return;
            }

            Element previous = head;
            Element current = head.Next;

            while (current != null && current.Priority >= priority)
            {
                previous = current;
                current = current.Next;
            }

            newElement.Next = current;
            previous.Next = newElement;
        }


        /// <summary>
        /// Returns element with the highest priority and removes it from the queue.
        /// </summary>
        /// <returns>Queue element with the highest priority</returns>
        public string Dequeue()
        {
            if (IsEmpty())
            {
                throw new QueueIsEmptyException();
            }

            Element temp = head;
            head = head.Next;

            return temp.Data;
        }

        /// <summary>
        /// Prints the queue шn descending order of priority.
        /// </summary>
        public void PrintQueue()
        {
            Element current = head;

            while (current != null)
            {
                Console.Write($"{current.Data} ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
}
