using NHibernate;

namespace Content.Persistence.NHibernate.Sessions.Abstraction
{
    public interface ISessionProvider
    {
        ISession CurrentSession { get; }
    }
}
