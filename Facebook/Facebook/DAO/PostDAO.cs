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
        Task<List<Post>> GetAll();

        Task<List<Post>> GetByUserID(int userID);

        Task<List<Post>> GetByUserIDByHomePage(int userID);     // Home page

        Task<List<Post>> GetByUserIDByFriendPageHaveFriendShip(int userID);     // Friend page, have friendShip

        Task<List<Post>> GetByUserIDByFriendPageNoFriendShip(int userID);     // Friend page, have friendShip

        Post GetByID(int id);

        bool Create(Post post);

        bool Delete(Post post);

        bool SaveChanges();
    }

    public class PostDAO : IPostDAO
    {
        private readonly IPostService _postService;

        private List<Post> posts;

        public PostDAO(IPostService postService)
        {
            this._postService = postService;
            Load();
        }

        private async Task Load()
        {
            posts = await GetAll();
        }

        public bool Create(Post post)
        {
            try
            {
                // insert ram
                posts.Add(post);

                var a = posts.Count;

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

        public bool Delete(Post post)
        {
            try
            {
                posts.Remove(post);

                _postService.Delete(post);

                SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Post>> GetAll()
        {
            return _postService.GetAll().OrderByDescending(p => p.CreatedAt).ToList();
        }

        public Post GetByID(int id)
        {
            return posts.FirstOrDefault(p => p.ID == id);
        }

        public async Task<List<Post>> GetByUserID(int userID)
        {
            return posts.Where(p => p.User.ID == userID).ToList().OrderByDescending(p => p.CreatedAt).ToList();
        }

        public async Task<List<Post>> GetByUserIDByHomePage(int userID)
        {
            // các bài post công khai
            var result = posts.Where(p => p.PostStatusID == 1 || true || p.User.ID == userID);

            return result.OrderByDescending(p => p.CreatedAt).ToList();
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

        public async Task<List<Post>> GetByUserIDByFriendPageHaveFriendShip(int userID)
        {
            return posts.Where(p => p.User.ID == userID)
                .Where(p => p.PostStatusID == 1 || p.PostStatusID == 2).ToList().OrderByDescending(p => p.CreatedAt).ToList();
        }

        public async Task<List<Post>> GetByUserIDByFriendPageNoFriendShip(int userID)
        {
            return posts.Where(p => p.User.ID == userID)
                .Where(p => p.PostStatusID == 1).ToList().OrderByDescending(p => p.CreatedAt).ToList();
        }
    }
}
