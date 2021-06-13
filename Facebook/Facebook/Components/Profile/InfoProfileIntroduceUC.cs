using Facebook.Configure.Autofac;
using Facebook.DAO;
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
using static Facebook.Components.Profile.PostListProfileUC;

namespace Facebook.Components.Profile
{
    public partial class InfoProfileIntroduceUC : UserControl
    {
        public delegate void ClickProfileFriend(User user);
        public delegate void HeightChaned();
        public event ClickProfileFriend OnClickProfileFriend;
        public event HeightChaned OnHeightChanged;

        private User user;
        private PAGE page;

        private InfoProfileUC infoProfileUC;
        private PostListProfileUC postListProfileUC;

        public InfoProfileIntroduceUC(User user, PAGE page = PAGE.PROFILE)
        {
            InitializeComponent();

            this.user = user;
            this.page = page;

            Load();
        }

        #region Methods

        new private void Load()
        {
            LoadLeft();

            LoadRight();

            UpdateHeight();
        }

        private void LoadLeft()
        {
            infoProfileUC = new InfoProfileUC(AutofacFactory<IProfileDAO>.Get(), user);   // InfoUC có width bao nhiêu cũng được
            //pnlMainContent.Height = infoProfileUC.Height;   // gán giá height của InfoUC cho pnl chứa nó, vì flp có thể scroll theo độ dày các con bên trong
            this.Height = infoProfileUC.Height;
            infoProfileUC.OnHeightChanged += () => UpdateHeight();

            pnlLeft.Controls.Add(infoProfileUC);
            infoProfileUC.Dock = DockStyle.Top;

        }

        private void LoadRight()
        {
            // Have friendship or no hava firendship thi cần làm xong chức năng kết bạn

            postListProfileUC = new PostListProfileUC(AutofacFactory<IPostDAO>.Get(), user, page);
            postListProfileUC.OnHeightChanged += () => UpdateHeight();
            postListProfileUC.OnClickProfileFriend += (u) => OnClickProfileFriend?.Invoke(u);

            pnlRight.Controls.Add(postListProfileUC);
            postListProfileUC.Dock = DockStyle.Top;
            UpdateHeight();
        }

        private void UpdateHeight()
        {
            this.Height = infoProfileUC.Height > postListProfileUC.Height ? infoProfileUC.Height : postListProfileUC.Height;
            OnHeightChanged?.Invoke();
        }

        #endregion


        #region Events


        #endregion
    }
}
