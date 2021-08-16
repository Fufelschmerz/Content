using Domain.ValueObjects.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Domain.ValueObjects.ContentComponets
{
    public class Photo : IValueObject 
    {
        private Photo() { }

        protected internal Photo(string photoUrl)
        {
            if (photoUrl == null)
                throw new ArgumentNullException(nameof(photoUrl));

            PhotoUrl = photoUrl;
        }

        public Guid Id { get; private set; }

        public string PhotoUrl { get; private set; }
    }
}
