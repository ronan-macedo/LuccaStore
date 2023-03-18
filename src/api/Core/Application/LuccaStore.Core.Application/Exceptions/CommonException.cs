using System.Runtime.Serialization;

namespace LuccaStore.Core.Application.Exceptions
{
    [Serializable]
    public class CommonException : Exception
    {
        public string? ErrorCode { get; set; }

        public virtual bool IsTransient { get; set; }

        public CommonException()
        {
        }

        public CommonException(string message)
            : base(message)
        {
        }

        public CommonException(string message, string errorCode)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public CommonException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public CommonException(string message, string errorCode, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }

        protected CommonException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ErrorCode = info.GetString("ErrorCode");
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue("ErrorCode", ErrorCode);
            base.GetObjectData(info, context);
        }
    }
}
