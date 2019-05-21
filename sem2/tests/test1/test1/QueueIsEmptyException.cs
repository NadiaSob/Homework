using System;

namespace test1
{
    /// <summary>
    /// Exception that is thrown when trying to dequeue from the empty priotity queue.
    /// </summary>
    [Serializable]
    public class QueueIsEmptyException : InvalidOperationException
    {
        public QueueIsEmptyException() { }
        public QueueIsEmptyException(string massege) : base(massege) { }
        public QueueIsEmptyException(string message, Exception inner) : base(message, inner) { }
        protected QueueIsEmptyException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
