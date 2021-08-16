using Content.Domain.Entities.Contents;
using Content.Domain.Entities.Location;
using Domain.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Content.Domain.Entities.Users
{
    public class User : IEntity 
    {
        private readonly ICollection<ContentBase> _contents = new HashSet<ContentBase>();

        private User() { }

        public User(string email, City city)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException("The value cannot be empty or a space", nameof(email));

            Email = email;
            City = city ?? throw new ArgumentNullException(nameof(city));
        }

        public long Id { get; private set; }

        public string Email { get; private set; }

        public City City { get; private set; }

        public IEnumerable<ContentBase> Contents => _contents.AsQueryable();

        protected internal void AddContent(ContentBase content)
        {
            _contents.Add(content);
        }
    }
}
