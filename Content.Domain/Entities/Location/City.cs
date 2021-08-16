using Domain.Entities.Abstraction;
using System;

namespace Content.Domain.Entities.Location
{
    public class City : IEntity
    {
        [Obsolete("Only for reflection", true)]
        public City() 
        {
            
        }

        public City(string name, Country country)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            Name = name;
            Country = country ?? throw new ArgumentNullException(nameof(country));
        }


        public virtual long Id { get; private set; }

        public virtual string Name { get; private set; }

        public virtual Country Country { get; private set; }
    }
}
