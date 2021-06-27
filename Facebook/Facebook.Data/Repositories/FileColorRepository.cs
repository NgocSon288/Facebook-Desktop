using Facebook.Data.Infrastructure;
using Facebook.Model.Models;

namespace Facebook.Data.Repositories
{
    public interface IFileColorRepository : IRepository<FileColor>
    {
    }

    public class FileColorRepository : RepositoryBase<FileColor>, IFileColorRepository
    {
        public FileColorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}