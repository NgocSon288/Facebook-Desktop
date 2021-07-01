using Facebook.Model.Models;
using Facebook.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.DAO
{
    public interface ICommentDAO
    {
        List<Comment> GetAll();

        List<Comment> GetByPostID(int postID);

        Comment GetByID(int id);

        bool Create(Comment comment);

        bool SaveChanges();
    }

    public class CommentDAO : ICommentDAO
    {
        private readonly ICommentService _commentService;

        private List<Comment> comments;

        public CommentDAO(ICommentService commentService)
        {
            this._commentService = commentService;

            comments = GetAll();
        }

        public bool Create(Comment comment)
        {
            try
            {
                // add ram
                comments.Add(comment);

                // add db
                _commentService.Insert(comment);

                SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Comment> GetAll()
        {
            try
            {
                return _commentService.GetAll().ToList();
            }
            catch (Exception)
            {
                return new List<Comment>();
            }
        }

        public Comment GetByID(int id)
        {
            return comments.FirstOrDefault(p => p.ID == id);
        }

        public List<Comment> GetByPostID(int postID)
        {
            return comments.Where(c => c.PostID == postID).ToList();
        }

        public bool SaveChanges()
        {
            try
            {
                _commentService.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
