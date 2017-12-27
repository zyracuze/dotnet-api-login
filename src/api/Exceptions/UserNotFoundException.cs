using System;
using System.Runtime.Serialization;

namespace api.Exceptions
{
    [Serializable]
    public class UserNotFoundException : Exception, ISerializable
    {
        protected UserNotFoundException(SerializationInfo info, StreamingContext context){}
        public UserNotFoundException(string message) : base(message) { }
    }
}