using System;

namespace Asam.Ppc.Infrastructure.Domain.Exceptions
{
    [Serializable]
    public class RecordNotFoundException : DataAccessException
    {
        public RecordNotFoundException()
        {
        }

        public RecordNotFoundException(string message)
            : base(message)
        {
        }

        public RecordNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}