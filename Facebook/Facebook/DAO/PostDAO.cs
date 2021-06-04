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

        Post GetByID(int id);

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

        public List<Post> GetAll()
        {
            return _postService.GetAll().ToList();
        }

        public Post GetByID(int id)
        {
            return posts.FirstOrDefault(p => p.ID == id);
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
