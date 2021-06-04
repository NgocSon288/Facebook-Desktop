using Facebook.Data.Infrastructure;
using Facebook.Data.Repositories;
using Facebook.Model.Models;
using System.Collections.Generic;

namespace Facebook.Service.Service
{
    public interface IPostStatusService
    {
        PostStatus Insert(PostStatus entity);

        void Update(PostStatus entity);

        void Delete(PostStatus entity);

        void Delete(int id);

        IEnumerable<PostStatus> GetAll();

        IEnumerable<PostStatus> GetAllPaging(int page, int pageSize, out int totalRow);

        PostStatus GetByID(int id);

        void SaveChanges();
    }

    public class PostStatusService : IPostStatusService
    {
        private readonly IPostStatusRepository _postStatusRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostStatusService(IPostStatusRepository profileRepository, IUnitOfWork unitOfWork)
        {
            this._postStatusRepository = profileRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(PostStatus entity)
        {
            _postStatusRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _postStatusRepository.Delete(id);
        }

        public IEnumerable<PostStatus> GetAll()
        {
            return _postStatusRepository.GetAll();
        }

        public IEnumerable<PostStatus> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _postStatusRepository.GetMultiPaging(ad => true, out totalRow, page, pageSize);
        }

        public PostStatus GetByID(int id)
        {
            return _postStatusRepository.GetSingleById(id);
        }

        public PostStatus Insert(PostStatus entity)
        {
            return _postStatusRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(PostStatus entity)
        {
            _postStatusRepository.Update(entity);
        }
    }
}