using System.Runtime.Serialization;

namespace Example.Platform.Persistence
{
    public class RecordNotFoundException<TKey> : Exception
        where TKey : struct, IEquatable<TKey>   
    {
        public RecordNotFoundException()
        {
        }

        public RecordNotFoundException(TKey key) : base($"Record not found with id: {key}")
        {

        }

        public RecordNotFoundException(string? message) : base(message)
        {
        }

        public RecordNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RecordNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
