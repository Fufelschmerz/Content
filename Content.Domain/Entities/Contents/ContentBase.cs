using Content.Domain.Entities.Users;
using Content.Domain.Enums.Content;
using Content.Domain.ValueObjects.ContentComponets;
using Domain.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Content.Domain.Entities.Contents
{
    public abstract class ContentBase : IEntity
    {
        private readonly ICollection<Rating> _ratings = new HashSet<Rating>();

        protected ContentBase()
        {

        }

        protected ContentBase(string name, Categories category)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            Name = name;
            Category = category;
        }

        public long Id { get; private set; }

        public string Name { get; private set; }

        public Categories Category { get; private set; }

        public IEnumerable<Rating> Ratings => _ratings.AsQueryable();

        protected internal void RateContent(User user, int evalution)
        {
            var rating = new Rating(user, evalution);

            _ratings.Add(rating);
        }
    }
}
