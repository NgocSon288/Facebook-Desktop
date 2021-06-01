namespace Facebook.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private FacebookDBContext dbContext;

        public FacebookDBContext Init()
        {
            return dbContext ?? (dbContext = new FacebookDBContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}