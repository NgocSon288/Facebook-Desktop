using Facebook.Data.Infrastructure;
using Facebook.Data.Repositories;
using Facebook.Model.Models;
using System.Collections.Generic;

namespace Facebook.Service.Service
{
    public interface IProfileService
    {
        Profile Insert(Profile entity);

        void Update(Profile entity);

        void Delete(Profile entity);

        void Delete(int id);

        IEnumerable<Profile> GetAll();

        IEnumerable<Profile> GetAllPaging(int page, int pageSize, out int totalRow);

        Profile GetByID(int id);

        void SaveChanges();
    }

    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProfileService(IProfileRepository profileRepository, IUnitOfWork unitOfWork)
        {
            this._profileRepository = profileRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(Profile entity)
        {
            _profileRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _profileRepository.Delete(id);
        }

        public IEnumerable<Profile> GetAll()
        {
            return _profileRepository.GetAll();
        }

        public IEnumerable<Profile> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _profileRepository.GetMultiPaging(ad => true, out totalRow, page, pageSize);
        }

        public Profile GetByID(int id)
        {
            return _profileRepository.GetSingleById(id);
        }

        public Profile Insert(Profile entity)
        {
            return _profileRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Profile entity)
        {
            _profileRepository.Update(entity);
        }
    }
}