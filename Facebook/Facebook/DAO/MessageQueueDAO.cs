using Facebook.Model.Models;
using Facebook.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Facebook.DAO
{
    public interface IMessageQueueDAO
    {
        List<MessageQueue> GetAll();

        MessageQueue GetByID(int id);

        List<MessageQueue> GetByUserID(int ownID);

        MessageQueue GetByMultipID(int ownID, int senderID, int receiverID);

        bool Create(MessageQueue messageQueue);

        bool Create(List<MessageQueue> messageQueues);

        bool Delete(MessageQueue messageQueue);

        bool DeleteMultip(List<MessageQueue> messageQueues);

        bool CheckIsQueue(int UserCurrent, int messageID);

        bool SaveChanges();
    }

    public class MessageQueueDAO : IMessageQueueDAO
    {
        private readonly IMessageQueueService _messageQueueService;

        public MessageQueueDAO(IMessageQueueService messageQueueService)
        {
            this._messageQueueService = messageQueueService;
        }

        public bool CheckIsQueue(int UserCurrent, int messageID)
        {
            var mqs = GetByUserID(UserCurrent);

            return mqs.Any(m => m.ReceiverID == UserCurrent && m.MessageID == messageID);
        }

        public bool Create(MessageQueue messageQueue)
        {
            try
            {
                // add db
                _messageQueueService.Insert(messageQueue);

                // save
                SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Create(List<MessageQueue> messageQueues)
        {
            try
            {
                // add db
                foreach (var item in messageQueues)
                {
                    _messageQueueService.Insert(item);
                }

                // save
                SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(MessageQueue messageQueue)
        {
            try
            {
                // update db
                _messageQueueService.Delete(messageQueue);

                // save
                SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteMultip(List<MessageQueue> messageQueues)
        {
            try
            {
                // update db
                foreach (var item in messageQueues)
                {
                    _messageQueueService.Delete(item);
                }

                // save
                SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<MessageQueue> GetAll()
        {
            return _messageQueueService.GetAll().ToList();
        }

        public MessageQueue GetByID(int id)
        {
            return GetAll().FirstOrDefault(p => p.ID == id);
        }

        public MessageQueue GetByMultipID(int ownID, int senderID, int receiverID)
        {
            return GetAll().FirstOrDefault(m => m.OwnID == ownID && m.ReceiverID == receiverID && m.SenderID == senderID);
        }

        /// <summary>
        /// Danh sách các công việc
        /// </summary>
        /// <param name="ownID"></param>
        /// <returns></returns>
        public List<MessageQueue> GetByUserID(int ownID)
        {
            return _messageQueueService.GetAll().Where(m => m.OwnID == ownID).ToList();
        }

        public bool SaveChanges()
        {
            try
            {
                _messageQueueService.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}