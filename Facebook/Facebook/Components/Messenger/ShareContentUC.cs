using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook.Components.Messenger
{
    public partial class ShareContentUC : UserControl
    {
        public delegate void UpdateThemeColor();
        public event UpdateThemeColor OnUpdateThemeColor;

        private List<string> fileNames;
        private List<string> imagePaths;

        private ShareFilesUC shareFilesUC;
        private ShareImagesUC shareImagesUC;

        private ShareSettingUC shareSettingUC;

        public ShareContentUC(List<string> fileNames, List<string> imagePaths)
        {
            InitializeComponent();

            this.fileNames = fileNames;
            this.imagePaths = imagePaths;

            Load();
        }

        #region  Methods

        new private void Load()
        {
            flpContent.Controls.Clear();

            LoadAvatar();

            LoadSetting();

            LoadShareFiles();

            LoadShareImages();
        }

        private void LoadAvatar()
        {
            var shareAvatarUC = new ShareAvatarUC();

            flpContent.Controls.Add(shareAvatarUC);
        }

        private void LoadSetting()
        {
            shareSettingUC = new ShareSettingUC()
            {
                Left = 0,
                Margin = new Padding(0, 0, 0, 0)
            };
            shareSettingUC.OnUpdateThemeColor += () => OnUpdateThemeColor?.Invoke();

            flpContent.Controls.Add(shareSettingUC);
        }

        public void SetThemeColor()
        {
            shareSettingUC.SetThemeColor();
        }

        private void LoadShareFiles()
        {
            shareFilesUC = new ShareFilesUC(fileNames);

            flpContent.Controls.Add(shareFilesUC);
        }

        private void LoadShareImages()
        {
            shareImagesUC = new ShareImagesUC(imagePaths);

            flpContent.Controls.Add(shareImagesUC);
        }

        public void AddFileAndImages(List<string> fileNames, List<string> imagePaths)
        {
            shareFilesUC.AddFile(fileNames);
            shareImagesUC.AddImages(imagePaths);
        }

        #endregion
    }
}
