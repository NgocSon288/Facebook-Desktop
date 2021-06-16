using Facebook.Data.Infrastructure;
using Facebook.Model.Models;

namespace Facebook.Data.Repositories
{
    public interface IMessageSettingRepository : IRepository<MessageSetting>
    {
    }

    public class MessageSettingRepository : RepositoryBase<MessageSetting>, IMessageSettingRepository
    {
        public MessageSettingRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}