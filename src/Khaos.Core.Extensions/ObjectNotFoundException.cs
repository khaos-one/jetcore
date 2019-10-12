using System;

namespace Khaos.Core.Extensions
{
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException()
        { }

        public ObjectNotFoundException(string message) 
            : base(message)
        { }

        public ObjectNotFoundException(string message, Exception innerException) 
            : base(message, innerException)
        { }
    }
    
    public class ObjectNotFoundException<TKey> 
        : ObjectNotFoundException, IIdentifiable<TKey>
    {
        public TKey Id { get; set; }

        public ObjectNotFoundException(TKey id)
        {
            Id = id;
        }

        public ObjectNotFoundException(TKey id, string message)
            : base(message)
        {
            Id = id;
        }

        public ObjectNotFoundException(TKey id, string message, Exception innerException)
            : base(message, innerException)
        {
            Id = id;
        }
    }
}