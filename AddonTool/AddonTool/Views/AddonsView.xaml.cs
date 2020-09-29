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
    /// AddonsView.xaml 的交互逻辑
    /// </summary>
    public partial class AddonsView : Page
    {
        public AddonsView()
        {
            InitializeComponent();
        }

        List<string> m_addon_list;

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ImageListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddonsView_Loaded(object sender, RoutedEventArgs e)
        {
            //loadPicturePath = ConfigurationManager.AppSettings["loadPicturePath"];
            //algorithmPath = ConfigurationManager.AppSettings["algorithmPath"];

        }

        private void AddonsView_LostFocus(object sender, RoutedEventArgs e)
        {
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //config.AppSettings.Settings["loadPicturePath"].Value = loadPicturePath;
            //config.AppSettings.Settings["algorithmPath"].Value = algorithmPath;
            //config.Save(ConfigurationSaveMode.Modified);
            //ConfigurationManager.RefreshSection("appSettings");
        }

        private void BtFlashAddon_Click(object sender, RoutedEventArgs e)
        {
            DirectoryInfo AddonPath = new DirectoryInfo(FileClass.GameFolder + FileClass.AddonFolder);

            if (!AddonPath.Exists)
            {
                MessageBox.Show("插件目录不存在！");
                return;
            }

            List<DirectoryInfo> AddonList = AddonPath.GetDirectories().ToList();

            List<string> RemainList = new List<string>();
            List<string> RemoveList = new List<string>();

            char[] tokens = { '-','_' };
            foreach (var addonCur in AddonList)
                RemainList.Add(addonCur.Name.Split(tokens).Length > 1 ? addonCur.Name.Split(tokens)[0] : addonCur.Name);

            foreach (var nameCur in RemainList)
            {
                foreach (var nameNext in RemainList)
                {
                    if (nameNext.Equals(nameCur))
                        continue;
                    if (nameNext.Contains(nameCur))
                        RemoveList.Add(nameNext);
                    if (nameCur.Contains(nameNext))
                        RemoveList.Add(nameCur);
                }
            }
            foreach (var remove in RemoveList)
                RemainList.Remove(remove);

            m_addon_list = RemainList.Distinct().ToList();
        }
        private void BtGameFolder_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            fbd.SelectedPath = string.IsNullOrEmpty(FileClass.GameFolder) ? "" : FileClass.GameFolder;

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                // TbImageFile.Text = fbd.SelectedPath;
                List<string> filelist = Directory.GetFiles(fbd.SelectedPath).ToList();

                bool WrongFolder = true;
                foreach (var s in filelist)
                    if (s.Contains("World of Warcraft Launcher.exe"))
                        WrongFolder = false;

                if(WrongFolder)
                {
                    MessageBox.Show("错误,请选择World of Warcraft Launcher.exe所在的文件夹！");
                    return;
                }

                FileClass.GameFolder = fbd.SelectedPath;
                return;
            }
        }
    }
}
