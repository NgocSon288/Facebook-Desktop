using Facebook.Model.Models;
using Facebook.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.DAO
{
    public interface IPostDAO
    {
        List<Post> GetAll();

        List<Post> GetByUserID(int userID);

        Post GetByID(int id);

        bool Create(Post post);

        bool SaveChanges();
    }

    public class PostDAO : IPostDAO
    {
        private readonly IPostService _postService;

        private List<Post> posts;

        public PostDAO(IPostService postService)
        {
            this._postService = postService;

            posts = GetAll();
        }

        public bool Create(Post post)
        {
            try
            {
                // insert ram
                posts.Add(post);

                // insert db
                _postService.Insert(post);

                // save db
                _postService.SaveChanges();


                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Post> GetAll()
        {
            return _postService.GetAll().OrderByDescending(p => p.CreatedAt).ToList();
        }

        public Post GetByID(int id)
        {
            return posts.FirstOrDefault(p => p.ID == id);
        }

        public List<Post> GetByUserID(int userID)
        {
            return posts.Where(p => p.User.ID == userID).ToList();
        }

        public bool SaveChanges()
        {
            try
            {
                _postService.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
