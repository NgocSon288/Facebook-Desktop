using Facebook.Data.Infrastructure;
using Facebook.Model.Models;

namespace Facebook.Data.Repositories
{
    public interface ICommentFeedbackRepository : IRepository<CommentFeedback>
    {
    }

    public class CommentFeedbackRepository : RepositoryBase<CommentFeedback>, ICommentFeedbackRepository
    {
        public CommentFeedbackRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}