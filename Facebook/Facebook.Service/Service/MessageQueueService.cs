using Facebook.Data.Infrastructure;
using Facebook.Data.Repositories;
using Facebook.Model.Models;
using System.Collections.Generic;

namespace Facebook.Service.Service
{
    public interface IMessageQueueService
    {
        MessageQueue Insert(MessageQueue entity);

        void Update(MessageQueue entity);

        void Delete(MessageQueue entity);

        void Delete(int id);

        IEnumerable<MessageQueue> GetAll();

        IEnumerable<MessageQueue> GetAllPaging(int page, int pageSize, out int totalRow);

        MessageQueue GetByID(int id);

        void SaveChanges();
    }

    public class MessageQueueService : IMessageQueueService
    {
        private readonly IMessageQueueRepository _messageQueueRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MessageQueueService(IMessageQueueRepository messageQueueRepository, IUnitOfWork unitOfWork)
        {
            this._messageQueueRepository = messageQueueRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(MessageQueue entity)
        {
            _messageQueueRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _messageQueueRepository.Delete(id);
        }

        public IEnumerable<MessageQueue> GetAll()
        {
            return _messageQueueRepository.GetAll();
        }

        public IEnumerable<MessageQueue> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _messageQueueRepository.GetMultiPaging(ad => true, out totalRow, page, pageSize);
        }

        public MessageQueue GetByID(int id)
        {
            return _messageQueueRepository.GetSingleById(id);
        }

        public MessageQueue Insert(MessageQueue entity)
        {
            return _messageQueueRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(MessageQueue entity)
        {
            _messageQueueRepository.Update(entity);
        }
    }
}