using Facebook.Data.Infrastructure;
using Facebook.Model.Models;

namespace Facebook.Data.Repositories
{
    public interface IMessageQueueRepository : IRepository<MessageQueue>
    {
    }

    public class MessageQueueRepository : RepositoryBase<MessageQueue>, IMessageQueueRepository
    {
        public MessageQueueRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}