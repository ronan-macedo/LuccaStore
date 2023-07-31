using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace LuccaStore.Core.Application.Exceptions
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class InvalidParametersException : CommonException
    {
        public InvalidParametersException(string message)
           : base(message)
        {
        }

        public InvalidParametersException(string message, string errorCode)
            : base(message, errorCode)
        {
        }

        public InvalidParametersException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public InvalidParametersException(string message, string errorCode, Exception innerException)
            : base(message, errorCode, innerException)
        {
        }

        protected InvalidParametersException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
