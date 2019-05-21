using System;

namespace hw4._2
{
    /// <summary>
    /// Exception that is thrown when trying to add already existing element in list.
    /// </summary>
    [Serializable]
    public class ElementAlreadyExistsException : InvalidOperationException
    {
        public ElementAlreadyExistsException() { }
        public ElementAlreadyExistsException(string massege) : base(massege) { }
        public ElementAlreadyExistsException(string message, Exception inner)
            : base(message, inner) { }
        protected ElementAlreadyExistsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) 
            : base(info, context) { }
    }
}
