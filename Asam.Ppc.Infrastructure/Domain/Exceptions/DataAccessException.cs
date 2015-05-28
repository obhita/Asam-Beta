using System;
using System.Runtime.Serialization;

namespace Asam.Ppc.Infrastructure.Domain.Exceptions
{
    [Serializable]
    public class DataAccessException : Exception
    {
        protected DataAccessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public DataAccessException()
        {
        }

        public DataAccessException(string message)
            : base(message)
        {
        }

        public DataAccessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}