using Facebook.Data.Infrastructure;
using Facebook.Model.Models;

namespace Facebook.Data.Repositories
{
    public interface IFolderRepository : IRepository<Folder>
    {
    }

    public class FolderRepository : RepositoryBase<Folder>, IFolderRepository
    {
        public FolderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}