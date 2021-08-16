using Content.Persistence.NHibernate.Transactions.Behaviors;
using NHibernate;
using System;

namespace Content.Persistence.NHibernate.Sessions
{
    public class ExpectCommitScopedSessionProvider : ScopedSessionProviderBase, IExpectCommit
    {
        public ExpectCommitScopedSessionProvider(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        public void PerformCommit()
        {
            if (Disposed)
                throw new InvalidOperationException("Object already disposed");

            try
            {
                CommitTransaction();
            }
            catch
            {
                RollbackTransaction();

                throw;
            }
            finally
            {
                Dispose();
            }
        }
    }
}
