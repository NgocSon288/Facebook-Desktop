using Facebook.Data.Infrastructure;
using Facebook.Model.Models;

namespace Facebook.Data.Repositories
{
    public interface IPostStatusRepository : IRepository<PostStatus>
    {
    }

    public class PostStatusRepository : RepositoryBase<PostStatus>, IPostStatusRepository
    {
        public PostStatusRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}