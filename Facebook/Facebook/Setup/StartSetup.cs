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

        public void SetUp(IPostStatusDAO postStatusDAO, IFileColorDAO fileColorDAO)
        {
            this._postStatusDAO = postStatusDAO;
            this._fileColorDAO = fileColorDAO;

            // Setup PostStatus
            SetUpPostStatus();

            // Setup Extension File
            SetUpExtensionFile();
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

            if (data == null || data.Count <= 0)
            {
                var fileColors = new List<Model.Models.FileColor>();

                foreach (var item in ExtensionIcon.ExtensionList)
                {
                    fileColors.Add(new Model.Models.FileColor()
                    {
                        ColorName = null,
                        ExtensionName = item.Category,
                        Extension = StringHelper.StringListToString(item.Exts)
                    });
                }

                _fileColorDAO.InsertReange(fileColors);

                // default
                _fileColorDAO.Insert(new Model.Models.FileColor()
                {
                    ColorName = null,
                    Extension = "*",
                    ExtensionName = "All"
                });
            }
        }
    }
}
