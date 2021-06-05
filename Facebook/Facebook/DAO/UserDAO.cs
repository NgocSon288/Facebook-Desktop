using Facebook.Common;
using Facebook.Data.Infrastructure;
using Facebook.Data.Repositories;
using Facebook.Helper;
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

        User GetByUsername(string username);

        int Login(string username, string password);

        Task<int> Register(string name, string username, string password, string email);

        int ForgetPassword(string username, string password, string email);

        bool SaveChanges();
    }

    public class UserDAO : IUserDAO
    {
        private readonly IUserService _userService;
        private readonly IProfileDAO _profileDAO;

        private List<User> users;

        public UserDAO(IUserService userService, IProfileDAO profileDAO)
        {
            this._userService = userService;
            this._profileDAO = profileDAO;

            users = GetAll();
        }

        /// <summary>
        /// -1 = Tài khoản không hợp lệ
        /// -2 = Email không hợp lệ
        /// 0 = Lỗi server
        /// 1 = Ok
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public int ForgetPassword(string username, string password, string email)
        {
            try
            {
                var user = GetByUsername(username);

                if (user == null)
                {
                    return -1;
                }

                if (!string.Equals(email, user.Email, StringComparison.OrdinalIgnoreCase))
                {
                    return -2;
                }

                var passwordHashed = MD5Helper.CreateMD5(password);

                // cập nhật DB
                user.Password = passwordHashed;
                _userService.SaveChanges();

                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<User> GetAll()
        {
            return _userService.GetAll().ToList();
        }

        /// <summary>
        /// Get user dựa vào tài khoản
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User GetByUsername(string username)
        {
            return users.FirstOrDefault(u => string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// -1 = Tài khoản hoặc mật khẩu không hợp lệ
        /// 0 = Tài khoản hoặc mật khẩu không hợp lệ
        /// 1 = Ok
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Login(string username, string password)
        {
            var user = GetByUsername(username);

            if (user == null)
            {
                return -1;
            }

            if (!MD5Helper.Verify(user.Password, password))
            {
                return 0;
            }

            return 1;
        }

        /// <summary>
        /// -2 = Tài khoản đã  có người  sữ dụng
        /// -1 = Email không hợp lệ
        /// 0 = Lỗi server
        /// 1 = Ok
        /// </summary>
        /// <param name="name"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<int> Register(string name, string username, string password, string email)
        {
            try
            {
                var emailValid = await VerifyEmailHelper.Verify(email);

                if (!emailValid)
                {
                    return -1;
                }

                var userCheck = GetByUsername(username);

                if (userCheck != null)
                {
                    return -2;
                }

                var passwordHashed = MD5Helper.CreateMD5(password);
                // Insert into data base
                var user = new User()
                {
                    Name = name,
                    Username = username,
                    Password = passwordHashed,
                    Email = email
                };

                // Email trong profile vào user
                var profile = new Profile()
                {
                    Email = email
                };

                user.Profile = profile;

                _userService.Insert(user);
                _userService.SaveChanges();

                // Insert vào RAM
                users.Add(user);

                // refresh ram profile
                _profileDAO.Refresh();

                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool SaveChanges()
        {
            try
            {
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
