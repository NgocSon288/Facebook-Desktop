using Facebook.Model.Models;
using Facebook.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.DAO
{
    public interface IPostStatusDAO
    {
        List<PostStatus> GetAll();

        PostStatus GetByID(int id);

        bool InsertRange(List<PostStatus> postStatuses);

        bool SaveChanges();
    }

    public class PostStatusDAO : IPostStatusDAO
    {
        private readonly IPostStatusService _postStatusService;

        private List<PostStatus> postStatuss;

        public PostStatusDAO(IPostStatusService postStatusService)
        {
            this._postStatusService = postStatusService;

            postStatuss = GetAll();
        }

        public List<PostStatus> GetAll()
        {
            return _postStatusService.GetAll().ToList();
        }

        public PostStatus GetByID(int id)
        {
            return postStatuss.FirstOrDefault(p => p.ID == id);
        }

        public bool InsertRange(List<PostStatus> postStatuses)
        {
            try
            {
                foreach (var item in postStatuses)
                {
                    _postStatusService.Insert(item);
                }

                _postStatusService.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SaveChanges()
        {
            try
            {
                _postStatusService.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
