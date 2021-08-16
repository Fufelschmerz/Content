using System;
using System.Runtime.Serialization;

namespace Content.Domain.Exceptions.UserExceptions
{
    [Serializable]
    public class UserAlreadyExistsException : Exception
    {
        private const string DefaultMessage = "A user with such an e-mail already exists";

        public UserAlreadyExistsException() : base(DefaultMessage) { }

        public UserAlreadyExistsException(string message) : base(message) { }

        public UserAlreadyExistsException(string message, Exception inner) : base(message, inner) { }

        public UserAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
