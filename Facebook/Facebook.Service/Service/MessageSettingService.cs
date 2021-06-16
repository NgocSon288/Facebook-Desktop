using Facebook.Data.Infrastructure;
using Facebook.Data.Repositories;
using Facebook.Model.Models;
using System.Collections.Generic;

namespace Facebook.Service.Service
{
    public interface IMessageSettingService
    {
        MessageSetting Insert(MessageSetting entity);

        void Update(MessageSetting entity);

        void Delete(MessageSetting entity);

        void Delete(int id);

        IEnumerable<MessageSetting> GetAll();

        IEnumerable<MessageSetting> GetAllPaging(int page, int pageSize, out int totalRow);

        MessageSetting GetByID(int id);

        void SaveChanges();
    }

    public class MessageSettingService : IMessageSettingService
    {
        private readonly IMessageSettingRepository _messageSettingRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MessageSettingService(IMessageSettingRepository messageSettingRepository, IUnitOfWork unitOfWork)
        {
            this._messageSettingRepository = messageSettingRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(MessageSetting entity)
        {
            _messageSettingRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _messageSettingRepository.Delete(id);
        }

        public IEnumerable<MessageSetting> GetAll()
        {
            return _messageSettingRepository.GetAll();
        }

        public IEnumerable<MessageSetting> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _messageSettingRepository.GetMultiPaging(ad => true, out totalRow, page, pageSize);
        }

        public MessageSetting GetByID(int id)
        {
            return _messageSettingRepository.GetSingleById(id);
        }

        public MessageSetting Insert(MessageSetting entity)
        {
            return _messageSettingRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(MessageSetting entity)
        {
            _messageSettingRepository.Update(entity);
        }
    }
}