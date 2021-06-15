using Facebook.Model.Models;
using Facebook.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Facebook.DAO
{
    public interface IMessageDAO
    {
        List<Message> GetAll();

        Message GetByID(int id);

        List<Message> GetByMultipUserID(int senderID, int receiverID);

        Message GetLastCommentByUserID(int userA, int userB);

        bool Create(Message message);

        bool SaveChanges();

        void RefreshData();
    }

    public class MessageDAO : IMessageDAO
    {
        private readonly IMessageService _messageService;

        private List<Message> messages;

        public MessageDAO(IMessageService messageService)
        {
            this._messageService = messageService;

            messages = GetAll();
        }

        public bool Create(Message message)
        {
            try
            {
                // ad ram
                messages.Add(message);

                // ad db
                _messageService.Insert(message);

                // save 
                SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Message> GetAll()
        {
            return _messageService.GetAll().ToList();
        }

        public Message GetByID(int id)
        {
            return GetAll().FirstOrDefault(p => p.ID == id);
        }

        public List<Message> GetByMultipUserID(int senderID, int receiverID)
        {
            var senderMess = messages.Where(m => m.SenderID == senderID).Where(m => m.ReceiverID == receiverID);
            var receiverMess = messages.Where(m => m.SenderID == receiverID).Where(m => m.ReceiverID == senderID);

            return senderMess.Union(receiverMess).OrderBy(m => m.CreatedAt).ToList();
        }

        public Message GetLastCommentByUserID(int userA, int userB)
        {
            var senderMess = messages.Where(m => m.SenderID == userA && m.ReceiverID == userB).OrderByDescending(m => m.ID).ToList();
            var receiverMess = messages.Where(m => m.SenderID == userB && m.ReceiverID == userA).OrderByDescending(m => m.ID).ToList();

            if (senderMess != null && receiverMess != null && senderMess.Count > 0 && receiverMess.Count > 0)
            {
                if (senderMess[0].ID > receiverMess[0].ID)
                {
                    return senderMess[0];
                }
                else
                {
                    return receiverMess[0];
                }
            }

            if (senderMess != null && senderMess.Count > 0)
            {
                return senderMess[0];
            }

            if (receiverMess != null && receiverMess.Count > 0)
            {
                return receiverMess[0];
            }

            return null;
        }

        public void RefreshData()
        {
            messages = GetAll();
        }

        public bool SaveChanges()
        {
            try
            {
                _messageService.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}