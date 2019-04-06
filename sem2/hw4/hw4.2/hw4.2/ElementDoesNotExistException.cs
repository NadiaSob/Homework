using System;

namespace hw4._2
{
    /// <summary>
    /// Exception that is thrown when trying to delete not existing element from list.
    /// </summary>
    [Serializable]
    public class ElementDoesNotExistException : InvalidOperationException
    {
        public ElementDoesNotExistException() { }
        public ElementDoesNotExistException(string massege) : base(massege) { }
        public ElementDoesNotExistException(string message, Exception inner)
            : base(message, inner) { }
        protected ElementDoesNotExistException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
