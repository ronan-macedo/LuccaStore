using System.Runtime.Serialization;

namespace LuccaStore.Core.Application.Exceptions
{
    [Serializable]
    public class AuthorizationException : CommonException
    {
        public AuthorizationException(string message)
           : base(message)
        {
        }

        public AuthorizationException(string message, string errorCode)
            : base(message, errorCode)
        {
        }

        public AuthorizationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public AuthorizationException(string message, string errorCode, Exception innerException)
            : base(message, errorCode, innerException)
        {
        }

        protected AuthorizationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
