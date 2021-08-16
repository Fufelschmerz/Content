namespace Content.Persistence.NHibernate.Transactions.Behaviors
{
    public interface IExpectCommit
    {
        void PerformCommit();
    }
}
