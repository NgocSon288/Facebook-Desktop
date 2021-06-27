using Facebook.Data.Infrastructure;
using Facebook.Data.Repositories;
using Facebook.Model.Models;
using System.Collections.Generic;

namespace Facebook.Service.Service
{
    public interface IFileColorService
    {
        FileColor Insert(FileColor entity);

        void Update(FileColor entity);

        void Delete(FileColor entity);

        void Delete(int id);

        IEnumerable<FileColor> GetAll();

        IEnumerable<FileColor> GetAllPaging(int page, int pageSize, out int totalRow);

        FileColor GetByID(int id);

        void SaveChanges();
    }

    public class FileColorService : IFileColorService
    {
        private readonly IFileColorRepository _fileColorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FileColorService(IFileColorRepository fileColorRepository, IUnitOfWork unitOfWork)
        {
            this._fileColorRepository = fileColorRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(FileColor entity)
        {
            _fileColorRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _fileColorRepository.Delete(id);
        }

        public IEnumerable<FileColor> GetAll()
        {
            return _fileColorRepository.GetAll();
        }

        public IEnumerable<FileColor> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _fileColorRepository.GetMultiPaging(ad => true, out totalRow, page, pageSize);
        }

        public FileColor GetByID(int id)
        {
            return _fileColorRepository.GetSingleById(id);
        }

        public FileColor Insert(FileColor entity)
        {
            return _fileColorRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(FileColor entity)
        {
            _fileColorRepository.Update(entity);
        }
    }
}