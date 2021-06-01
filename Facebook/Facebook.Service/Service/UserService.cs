using Facebook.Data.Infrastructure;
using Facebook.Data.Repositories;
using Facebook.Model.Models;
using System.Collections.Generic;

namespace Facebook.Service.Service
{
    public interface IUserService
    {
        User Insert(User entity);

        void Update(User entity);

        void Delete(User entity);

        void Delete(int id);

        IEnumerable<User> GetAll();

        IEnumerable<User> GetAllPaging(int page, int pageSize, out int totalRow);

        User GetByID(int id);

        void SaveChanges();
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(User entity)
        {
            _userRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public IEnumerable<User> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _userRepository.GetMultiPaging(ad => ad.Status.Value, out totalRow, page, pageSize);
        }

        public User GetByID(int id)
        {
            return _userRepository.GetSingleById(id);
        }

        public User Insert(User entity)
        {
            return _userRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(User entity)
        {
            _userRepository.Update(entity);
        }
    }
}