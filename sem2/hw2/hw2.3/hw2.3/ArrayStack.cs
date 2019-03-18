using System;

namespace hw2._3
{
    /// <summary>
    /// First-in-first-out container for integer values.
    /// </summary>
    public class ArrayStack : IStack
    {
        private const int size = 2;
        private int[] array;
        private int top;

        /// <summary>
        /// Creates new array stack.
        /// </summary>
        public ArrayStack()
        {
            array = new int[size];
        }
        
        /// <summary>
        /// Checks if stack has no elements in it.
        /// </summary>
        /// <returns>True if stack is empty, else false.</returns>
        public bool IsEmpty() => top == 0;

        /// <summary>
        /// Adds new element in the top of the stack.
        /// </summary>
        /// <param name="data">Element to add.</param>
        public void Push(int data)
        {
            if (top + 1 >= array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }

            ++top;
            array[top] = data;
        }

        /// <summary>
        /// Gets element from a top of the stack and removes it.
        /// </summary>
        /// <returns>Element that was on the top of the stack or ' ' if it is empty.</returns>
        public int Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Attempt to get element from the empty stack");
            }

            int result = array[top];
            --top;
            return result;
        }
    }
}
