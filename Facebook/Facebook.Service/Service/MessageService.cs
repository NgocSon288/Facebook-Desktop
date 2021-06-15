using Facebook.Data.Infrastructure;
using Facebook.Data.Repositories;
using Facebook.Model.Models;
using System.Collections.Generic;

namespace Facebook.Service.Service
{
    public interface IMessageService
    {
        Message Insert(Message entity);

        void Update(Message entity);

        void Delete(Message entity);

        void Delete(int id);

        IEnumerable<Message> GetAll();

        IEnumerable<Message> GetAllPaging(int page, int pageSize, out int totalRow);

        Message GetByID(int id);

        void SaveChanges();
    }

    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MessageService(IMessageRepository messageRepository, IUnitOfWork unitOfWork)
        {
            this._messageRepository = messageRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(Message entity)
        {
            _messageRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _messageRepository.Delete(id);
        }

        public IEnumerable<Message> GetAll()
        {
            return _messageRepository.GetAll();
        }

        public IEnumerable<Message> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _messageRepository.GetMultiPaging(ad => true, out totalRow, page, pageSize);
        }

        public Message GetByID(int id)
        {
            return _messageRepository.GetSingleById(id);
        }

        public Message Insert(Message entity)
        {
            return _messageRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Message entity)
        {
            _messageRepository.Update(entity);
        }
    }
}