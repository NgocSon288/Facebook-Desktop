using Facebook.Data.Infrastructure;
using Facebook.Data.Repositories;
using Facebook.Model.Models;
using Facebook.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.DAO
{
    public interface IUserDAO
    {
        List<User> GetAll();

        bool TestInsert(User user);
    }

    public class UserDAO : IUserDAO
    {
        private readonly IUserService _userService;

        public UserDAO(IUserService userService)
        {
            this._userService = userService;

            //this._userService = new UserService();
        }

        public List<User> GetAll()
        {
            return _userService.GetAll().ToList();
        }

        public bool TestInsert(User user)
        {
            try
            {
                _userService.Insert(user);
                _userService.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
