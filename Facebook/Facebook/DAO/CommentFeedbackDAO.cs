using Facebook.Model.Models;
using Facebook.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.DAO
{
    public interface ICommentFeedbackDAO
    {
        List<CommentFeedback> GetAll();

        CommentFeedback GetByID(int id);

        bool SaveChanges();
    }

    public class CommentFeedbackDAO : ICommentFeedbackDAO
    {
        private readonly ICommentFeedbackService _commentFeedbackService;

        private List<CommentFeedback> commentFeedbacks;

        public CommentFeedbackDAO(ICommentFeedbackService commentFeedbackService)
        {
            this._commentFeedbackService = commentFeedbackService;

            commentFeedbacks = GetAll();
        }

        public List<CommentFeedback> GetAll()
        {
            return _commentFeedbackService.GetAll().ToList();
        }

        public CommentFeedback GetByID(int id)
        {
            return commentFeedbacks.FirstOrDefault(p => p.ID == id);
        }

        public bool SaveChanges()
        {
            try
            {
                _commentFeedbackService.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
