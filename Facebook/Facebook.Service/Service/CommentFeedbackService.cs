using Facebook.Data.Infrastructure;
using Facebook.Data.Repositories;
using Facebook.Model.Models;
using System.Collections.Generic;

namespace Facebook.Service.Service
{
    public interface ICommentFeedbackService
    {
        CommentFeedback Insert(CommentFeedback entity);

        void Update(CommentFeedback entity);

        void Delete(CommentFeedback entity);

        void Delete(int id);

        IEnumerable<CommentFeedback> GetAll();

        IEnumerable<CommentFeedback> GetAllPaging(int page, int pageSize, out int totalRow);

        CommentFeedback GetByID(int id);

        void SaveChanges();
    }

    public class CommentFeedbackService : ICommentFeedbackService
    {
        private readonly ICommentFeedbackRepository _commentFeedbackRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CommentFeedbackService(ICommentFeedbackRepository profileRepository, IUnitOfWork unitOfWork)
        {
            this._commentFeedbackRepository = profileRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(CommentFeedback entity)
        {
            _commentFeedbackRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _commentFeedbackRepository.Delete(id);
        }

        public IEnumerable<CommentFeedback> GetAll()
        {
            return _commentFeedbackRepository.GetAll();
        }

        public IEnumerable<CommentFeedback> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _commentFeedbackRepository.GetMultiPaging(ad => true, out totalRow, page, pageSize);
        }

        public CommentFeedback GetByID(int id)
        {
            return _commentFeedbackRepository.GetSingleById(id);
        }

        public CommentFeedback Insert(CommentFeedback entity)
        {
            return _commentFeedbackRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(CommentFeedback entity)
        {
            _commentFeedbackRepository.Update(entity);
        }
    }
}