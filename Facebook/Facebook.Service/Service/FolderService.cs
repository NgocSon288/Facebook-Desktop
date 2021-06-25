using Facebook.Data.Infrastructure;
using Facebook.Data.Repositories;
using Facebook.Model.Models;
using System.Collections.Generic;

namespace Facebook.Service.Service
{
    public interface IFolderService
    {
        Folder Insert(Folder entity);

        void Update(Folder entity);

        void Delete(Folder entity);

        void Delete(int id);

        IEnumerable<Folder> GetAll();

        IEnumerable<Folder> GetAllPaging(int page, int pageSize, out int totalRow);

        Folder GetByID(int id);

        void SaveChanges();
    }

    public class FolderService : IFolderService
    {
        private readonly IFolderRepository _folderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FolderService(IFolderRepository profileRepository, IUnitOfWork unitOfWork)
        {
            this._folderRepository = profileRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(Folder entity)
        {
            _folderRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _folderRepository.Delete(id);
        }

        public IEnumerable<Folder> GetAll()
        {
            return _folderRepository.GetAll();
        }

        public IEnumerable<Folder> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _folderRepository.GetMultiPaging(ad => true, out totalRow, page, pageSize);
        }

        public Folder GetByID(int id)
        {
            return _folderRepository.GetSingleById(id);
        }

        public Folder Insert(Folder entity)
        {
            return _folderRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Folder entity)
        {
            _folderRepository.Update(entity);
        }
    }
}