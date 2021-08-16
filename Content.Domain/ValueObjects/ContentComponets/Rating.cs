using Content.Domain.Entities.Users;
using Domain.ValueObjects.Abstraction;
using System;

namespace Content.Domain.ValueObjects.ContentComponets
{
    public class Rating : IValueObjectWithId
    {
        private Rating() { }

        protected internal Rating(User user, int evaluation)
        {
            if (evaluation > 5 || evaluation < 1)
                throw new ArgumentOutOfRangeException(nameof(evaluation));

            Evaluation = evaluation;
            User = user ?? 
                throw new ArgumentNullException(nameof(user)); ;
        }

        public long Id { get; private set; }

        public User User { get; private set; }

        public int Evaluation { get; private set; }
    }
}
