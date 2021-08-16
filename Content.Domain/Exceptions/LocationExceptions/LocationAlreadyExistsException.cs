using System;
using System.Runtime.Serialization;

namespace Content.Domain.Exceptions.LocationExceptions
{
    [Serializable]
    public class LocationAlreadyExistsException : Exception
    {
        private const string DefaultMessage = "A location with this name already exists";

        public LocationAlreadyExistsException() : base(DefaultMessage) { }

        public LocationAlreadyExistsException(string message) : base(message) { }

        public LocationAlreadyExistsException(string message, Exception inner) : base(message, inner) { }

        public LocationAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
