using Facebook.Common;
using Facebook.DAO;
using Facebook.Helper;
using Facebook.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook.Components.Drive.Folders.Share
{
    public partial class UserShareListUC : UserControl
    {
        private readonly IUserDAO _userDAO;
        private readonly IFolderDAO _folderDAO;

        List<User> users;
        List<UserShareItemUC> userShareItems;
        List<int> userShares;   // danh sách các user đã được share

        public UserShareListUC(IUserDAO userDAO, IFolderDAO folderDAO)
        {
            InitializeComponent();

            this._userDAO = userDAO;
            this._folderDAO = folderDAO;

            Load();
        }

        #region Methods

        new private void Load()
        {
            users = _userDAO.GetAll(); // tất cả user
            userShareItems = new List<UserShareItemUC>();
            userShares = StringHelper.StringToIntList(DriveFolderItemUC.CurrentFolderItemUCFocus.folder.ShareList);

            var friends = StringHelper.StringToIntList(Constants.UserSession.Friend);
            var parentRootShares = _folderDAO.GetAll().Where(f => f.ParentID == null && f.IsShareRoot).ToList();    // danh sách các folder là root share

            users = users.Join(friends, u => u.ID, f => f, (u, f) => u).ToList();

            foreach (var item in users)
            {
                var itemUC = new UserShareItemUC(item, userShares.Contains(item.ID));
                itemUC.OnClickShareOrUnShare += (isShare) =>
                {
                    var parentRootShare = parentRootShares.FirstOrDefault(pr => pr.UserID == item.ID);// parentRootShare của thằng được share
                    var focusFolder = DriveFolderItemUC.CurrentFolderItemUCFocus.folder; // folder được focus, sẽ được share cho người khác

                    // nếu isShare = true, túc là chưa có trong share, add vào cả 2
                    if (isShare)
                    {
                        parentRootShare.ChildrenID = string.IsNullOrEmpty(parentRootShare.ChildrenID) ? focusFolder.ID.ToString() : parentRootShare.ChildrenID + Constants.SEPERATE_CHAR + focusFolder.ID;    //  add thêm folder vào parentRootShare của user được share
                        focusFolder.ShareList = string.IsNullOrEmpty(focusFolder.ShareList) ? item.ID.ToString() : focusFolder.ShareList + Constants.SEPERATE_CHAR + item.ID; // add thêm user được share vào
                    }
                    else
                    {
                        var lsChild = StringHelper.StringToIntList(parentRootShare.ChildrenID);
                        lsChild.Remove(focusFolder.ID);
                        parentRootShare.ChildrenID = StringHelper.IntListToString(lsChild); // remove focus folder ra

                        var lsFolder = StringHelper.StringToIntList(focusFolder.ShareList);
                        lsFolder.Remove(item.ID);
                        focusFolder.ShareList = StringHelper.IntListToString(lsFolder); // remove user ra khỏi ShareList
                    }

                    _folderDAO.SaveChanges();
                };

                flpContent.Controls.Add(itemUC);
                userShareItems.Add(itemUC);
            }

            this.BackColor = Constants.MAIN_BACK_COLOR;
        }

        public void FilterFriend(string text)
        {
            text = text.Trim();

            if (text == "Tên bạn bè..." || string.IsNullOrEmpty(text))
            {
                userShareItems.ForEach(i => i.Visible = true);
            }
            else
            {
                userShareItems.ForEach(i => i.Visible = CompareStringHelper.Contanins(i.user.Name, text));
            }
        }

        #endregion
    }
}
