using System;

namespace hw6._2
{
    /// <summary>
    /// Exception that is thrown when player crashes into the wall.
    /// </summary>
    [Serializable]
    public class CrashingIntoWallException : InvalidOperationException
    {
        public CrashingIntoWallException() { }
        public CrashingIntoWallException(string massege) : base(massege) { }
        public CrashingIntoWallException(string message, Exception inner) : base(message, inner) { }
        protected CrashingIntoWallException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
