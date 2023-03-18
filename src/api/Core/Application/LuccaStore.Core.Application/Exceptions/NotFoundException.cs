using System.Runtime.Serialization;

namespace LuccaStore.Core.Application.Exceptions
{
    [Serializable]
    public class NotFoundException : CommonException
    {
        public NotFoundException(string message)
           : base(message)
        {
        }

        public NotFoundException(string message, string errorCode)
            : base(message, errorCode)
        {
        }

        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public NotFoundException(string message, string errorCode, Exception innerException)
            : base(message, errorCode, innerException)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
