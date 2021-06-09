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

namespace Facebook.Components.Profile
{
    public partial class InfoProfileFriendsUC : UserControl
    {
        private User user;

        public InfoProfileFriendsUC(User user)
        {
            InitializeComponent();

            this.user = user;

            Load();
        }

        #region Methods

        new private void Load()
        {

        }

        #endregion

        #region Events


        #endregion
    }
}
