using Facebook.Data.Infrastructure;
using Facebook.Data.Repositories;
using Facebook.Model.Models;
using System.Collections.Generic;

namespace Facebook.Service.Service
{
    public interface ICommentService
    {
        Comment Insert(Comment entity);

        void Update(Comment entity);

        void Delete(Comment entity);

        void Delete(int id);

        IEnumerable<Comment> GetAll();

        IEnumerable<Comment> GetAllPaging(int page, int pageSize, out int totalRow);

        Comment GetByID(int id);

        void SaveChanges();
    }

    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(ICommentRepository profileRepository, IUnitOfWork unitOfWork)
        {
            this._commentRepository = profileRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(Comment entity)
        {
            _commentRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _commentRepository.Delete(id);
        }

        public IEnumerable<Comment> GetAll()
        {
            return _commentRepository.GetAll();
        }

        public IEnumerable<Comment> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _commentRepository.GetMultiPaging(ad => true, out totalRow, page, pageSize);
        }

        public Comment GetByID(int id)
        {
            return _commentRepository.GetSingleById(id);
        }

        public Comment Insert(Comment entity)
        {
            return _commentRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Comment entity)
        {
            _commentRepository.Update(entity);
        }
    }
}