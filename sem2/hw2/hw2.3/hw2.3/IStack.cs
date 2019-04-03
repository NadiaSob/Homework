using System;

namespace hw2._3
{
    /// <summary>
    /// Stack interface.
    /// </summary>
    public interface IStack
    {
        /// <summary>
        /// Checks if stack has no elements in it.
        /// </summary>
        /// <returns>True if stack is empty, else false.</returns>
        bool IsEmpty();

        /// <summary>
        /// Adds new element in the top of the stack.
        /// </summary>
        /// <param name="data">Element to add.</param>
        void Push(int data);

        /// <summary>
        /// Gets element from a top of the stack and removes it.
        /// </summary>
        /// <returns>Element that was on the top of the stack.</returns>
        int Pop();
    }
}
