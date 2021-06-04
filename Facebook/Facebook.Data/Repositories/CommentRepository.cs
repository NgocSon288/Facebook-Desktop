using Facebook.Data.Infrastructure;
using Facebook.Model.Models;

namespace Facebook.Data.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
    }

    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}