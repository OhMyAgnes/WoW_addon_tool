using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AddonTool
{
    /// <summary>
    /// MainPage.xaml 的交互逻辑
    /// </summary>
    public partial class MainPage : Page
    {
        private string loadPicturePath;
        private string algorithmPath;
        List<string> ImageFile = new List<string>();

        public MainPage()
        {
            InitializeComponent();
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ImageListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtLoadImage_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            fbd.SelectedPath = string.IsNullOrEmpty(loadPicturePath) ? "" : loadPicturePath;

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                loadPicturePath = fbd.SelectedPath;
                ImageFile.Clear();
                TbImageFile.Text = fbd.SelectedPath;
                ImageFile = Directory.GetDirectories(fbd.SelectedPath).ToList();
                if (ImageFile.Count <= 0)
                {
                    MessageBox.Show("选择的文件夹里面没有其余子文件夹");
                    return;
                }

                TbImageFile.Text = ImageFile[0];

            }
        }

        private void BtLoadRecipe_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.InitialDirectory = algorithmPath;
            ofd.Filter = "算法文件（*.txt)|*.txt|所有文件|*.*";
            ofd.FilterIndex = 1;
            ofd.Title = "打开算法文件";
            ofd.RestoreDirectory = true;

            ofd.FileName = algorithmPath.Substring(algorithmPath.LastIndexOf('\\') + 1);

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                algorithmPath = TbRecipeFile.Text = ofd.FileName;

                //算法文件处理……

            }
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //loadPicturePath = ConfigurationManager.AppSettings["loadPicturePath"];
            //algorithmPath = ConfigurationManager.AppSettings["algorithmPath"];

        }

        private void MainPage_LostFocus(object sender, RoutedEventArgs e)
        {
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //config.AppSettings.Settings["loadPicturePath"].Value = loadPicturePath;
            //config.AppSettings.Settings["algorithmPath"].Value = algorithmPath;
            //config.Save(ConfigurationSaveMode.Modified);
            //ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
