using Facebook.Model.Models;
using Facebook.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.DAO
{
    public interface IMessageSettingDAO
    {
        List<MessageSetting> GetAll();

        MessageSetting GetByMultipID(int userID1, int userID2);

        bool Create(MessageSetting messageSetting);

        bool Delete(MessageSetting messageSetting);

        bool SaveChanges();
    }

    public class MessageSettingDAO : IMessageSettingDAO
    {
        private readonly IMessageSettingService _messageSettingService;

        public MessageSettingDAO(IMessageSettingService messageSettingService)
        {
            this._messageSettingService = messageSettingService;
            Load();
        }

        private void Load()
        {
        }

        public bool Create(MessageSetting messageSetting)
        {
            try
            {
                // insert db
                _messageSettingService.Insert(messageSetting);

                // save db
                _messageSettingService.SaveChanges();


                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(MessageSetting messageSetting)
        {
            try
            {
                _messageSettingService.Delete(messageSetting);

                SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<MessageSetting> GetAll()
        {
            return _messageSettingService.GetAll().ToList();
        }

        public bool SaveChanges()
        {
            try
            {
                _messageSettingService.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public MessageSetting GetByMultipID(int userID1, int userID2)
        {
            return _messageSettingService.GetAll().FirstOrDefault(m => (m.User1.ID == userID1 && m.User2.ID == userID2) || (m.User1.ID == userID2 && m.User2.ID == userID1));
        }
    }
}
