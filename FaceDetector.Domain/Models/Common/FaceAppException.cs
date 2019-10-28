using System;
using System.Runtime.Serialization;


namespace FaceDetector.Domain.Models.Common
{
    public class FaceAppException : Exception
    {
        public int? HttpStatusCode { get; set; } = null;

        public FaceAppException() : base() { }

        public FaceAppException(string message) : base(message) { }

        public FaceAppException(string message, int httpStatusCode) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }

        public FaceAppException(string message, Exception innerException) : base(message, innerException) { }

        protected FaceAppException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}
