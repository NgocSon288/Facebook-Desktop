using Facebook.Data.Infrastructure;
using Facebook.Data.Repositories;
using Facebook.Model.Models;
using System.Collections.Generic;

namespace Facebook.Service.Service
{
    public interface IPostService
    {
        Post Insert(Post entity);

        void Update(Post entity);

        void Delete(Post entity);

        void Delete(int id);

        IEnumerable<Post> GetAll();

        IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow);

        Post GetByID(int id);

        void SaveChanges();
    }

    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IPostRepository profileRepository, IUnitOfWork unitOfWork)
        {
            this._postRepository = profileRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(Post entity)
        {
            _postRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll();
        }

        public IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(ad => true, out totalRow, page, pageSize);
        }

        public Post GetByID(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public Post Insert(Post entity)
        {
            return _postRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post entity)
        {
            _postRepository.Update(entity);
        }
    }
}