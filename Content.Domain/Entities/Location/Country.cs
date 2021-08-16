using Domain.Entities.Abstraction;
using System;

namespace Content.Domain.Entities.Location
{
    public class Country : IEntity
    {
        [Obsolete("Only for reflection", true)]
        public Country() 
        {
            
        }

        public Country(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            Name = name;
        }

        public virtual long Id { get; private set; }

        public virtual string Name { get; private set; }
    }
}
