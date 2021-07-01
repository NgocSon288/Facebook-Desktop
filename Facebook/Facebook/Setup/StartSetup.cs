using Facebook.Common;
using Facebook.DAO;
using Facebook.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Setup
{
    public class StartSetup
    {
        private IPostStatusDAO _postStatusDAO;
        private IFileColorDAO _fileColorDAO;
        private IFolderDAO _folderDAO;
        private IUserDAO _userDAO;

        public void SetUp(IPostStatusDAO postStatusDAO, IFileColorDAO fileColorDAO, IFolderDAO folderDAO, IUserDAO userDAO)
        {
            this._postStatusDAO = postStatusDAO;
            this._fileColorDAO = fileColorDAO;
            this._folderDAO = folderDAO;
            this._userDAO = userDAO;

            // Setup PostStatus
            SetUpPostStatus();

            // Setup Extension File
            SetUpExtensionFile();

            // SetUpDriveParent
            SetUpDriveParent();
        }

        public void SetUpPostStatus()
        {
            // Kiểm tra có thể setup không
            var data = _postStatusDAO.GetAll();

            if (data == null || data.Count <= 0)
            {
                _postStatusDAO.InsertRange(new List<Model.Models.PostStatus>()
                {
                    new Model.Models.PostStatus()
                    {
                        Name = "public",DisplayName="Công khai", Description="Mọi người trên hoặc ngoài Facebook"
                    },
                    new Model.Models.PostStatus()
                    {
                        Name = "friend",DisplayName="Bạn bè", Description="Bạn bè của bạn trên Facebook"
                    },
                    new Model.Models.PostStatus()
                    {
                        Name = "private",DisplayName="Chỉ mình tôi", Description="Chỉ một mình bạn nhìn thấy"
                    }
                });
            }
        }

        public void SetUpExtensionFile()
        {
            // kiểm tra có thể setup không
            var data = _fileColorDAO.GetAll();
            var userID = Constants.UserSession.ID;

            if (data == null || data.Count <= 0 || !data.Any(f => f.UserID == userID))
            {
                var fileColors = new List<Model.Models.FileColor>();

                foreach (var item in ExtensionIcon.ExtensionList)
                {
                    fileColors.Add(new Model.Models.FileColor()
                    {
                        ColorName = null,
                        ExtensionName = item.Category,
                        Extension = StringHelper.StringListToString(item.Exts),
                        UserID = userID
                    });
                }

                _fileColorDAO.InsertReange(fileColors);

                // default
                _fileColorDAO.Insert(new Model.Models.FileColor()
                {
                    ColorName = null,
                    Extension = "*",
                    ExtensionName = "All",
                    UserID = userID
                });
            }
        }

        public void SetUpDriveParent()
        {
            // Thiết lập 2 Folder parent root, và parent share root
            var fds = _folderDAO.GetAll().Where(f => f.ParentID == null).ToList();      // danh sách các folder là parent, hoặc parentShare
            var us = _userDAO.GetAll();     // danh sách các user

            var ls = new List<Model.Models.Folder>();

            //kiểm tra mỗi user phải có 2 folder, nếu không thì tạo  tương ứng với user đó
            foreach (var u in us)
            {
                var pRoot = fds.FirstOrDefault(f => f.UserID == u.ID && !f.IsShareRoot);  // null là chưa có
                var pShareRoot = fds.FirstOrDefault(f => f.UserID == u.ID && f.IsShareRoot);

                if (pRoot == null)
                {
                    ls.Add(new Model.Models.Folder()
                    {
                        ChildrenID = "",
                        ColorName = "",
                        Files = "",
                        IsPublic = false,
                        IsShareRoot = false,
                        Name = u.Name,
                        ParentID = null,
                        ShareList = "",
                        UserID = u.ID
                    });
                }

                if (pShareRoot == null)
                {
                    ls.Add(new Model.Models.Folder()
                    {
                        ChildrenID = "",
                        ColorName = "",
                        Files = "",
                        IsPublic = false,
                        IsShareRoot = true,
                        Name = u.Name,
                        ParentID = null,
                        ShareList = "",
                        UserID = u.ID
                    });
                }
            }

            _folderDAO.CreateRange(ls);
        }
    }
}
