using System;

namespace hw2._3
{
    /// <summary>
    /// First-In-First-Out data container for integer elements.
    /// </summary>
    public class Stack : IStack
    {
        private class StackElement
        {
            public int Data { get; set; }
            public StackElement Next { get; set; }
        }

        private StackElement head = null;

        /// <summary>
        /// Checks if stack has no elements in it.
        /// </summary>
        /// <returns>True if stack is empty, else false.</returns>
        public bool IsEmpty() => head == null;

        /// <summary>
        /// Adds new element in the top of the stack.
        /// </summary>
        /// <param name="data">Element to add.</param>
        public void Push(int data)
        {
            var newElement = new StackElement()
            {
                Next = head,
                Data = data
            };

            head = newElement;
        }

        /// <summary>
        /// Gets element from a top of the stack and removes it.
        /// </summary>
        /// <returns>Element that was on the top of the stack or ' ' if it is empty.</returns>
        public int Pop()
        {
            if (IsEmpty())
            {
                return ' ';
            }

            var temp = head.Data;
            head = head.Next;
            return temp;
        }
    }
}
