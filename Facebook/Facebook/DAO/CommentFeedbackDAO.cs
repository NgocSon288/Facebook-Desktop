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

        List<CommentFeedback> GetByCommentID(int commnentID);

        CommentFeedback GetByID(int id);

        bool Create(CommentFeedback commentFeedback);

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

        public bool Create(CommentFeedback commentFeedback)
        {
            try
            {
                // add ram
                commentFeedbacks.Add(commentFeedback);

                // add db
                _commentFeedbackService.Insert(commentFeedback);

                // save db
                SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<CommentFeedback> GetAll()
        {
            return _commentFeedbackService.GetAll().ToList();
        }

        public List<CommentFeedback> GetByCommentID(int commnentID)
        {
            return commentFeedbacks.Where(c => c.CommentID == commnentID).ToList();
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
