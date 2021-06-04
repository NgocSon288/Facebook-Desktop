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

        Comment GetByID(int id);

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

        public List<Comment> GetAll()
        {
            return _commentService.GetAll().ToList();
        }

        public Comment GetByID(int id)
        {
            return comments.FirstOrDefault(p => p.ID == id);
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
