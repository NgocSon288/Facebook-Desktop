namespace Facebook.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}