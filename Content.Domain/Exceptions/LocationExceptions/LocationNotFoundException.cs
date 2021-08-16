using System;
using System.Runtime.Serialization;

namespace Content.Domain.Exceptions.LocationExceptions
{
    [Serializable]
    public class LocationNotFoundException : Exception
    {
        private const string DefaultMessage = "Location not found";

        public LocationNotFoundException() : base(DefaultMessage) { }

        public LocationNotFoundException(string message) : base(message) { }

        public LocationNotFoundException(string message, Exception inner) : base(message, inner) { }

        public LocationNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
