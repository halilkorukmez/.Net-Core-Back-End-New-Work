using System;
using System.Runtime.Serialization;

namespace Core.Utilities;

public class AspectException : Exception
{
    public AspectException() { }

    public AspectException(string message) : base(message) { }

    public AspectException(string message, Exception innerException) : base(message, innerException) { }

    public AspectException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}