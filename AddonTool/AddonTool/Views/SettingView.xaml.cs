using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using AddonTool.ViewModels.Domins;
using System.IO;
using MaterialDesignThemes.Wpf;
using System.Windows.Forms;
using System;
using DataIO.Addons.Controller;
using AddonTool.ViewModels.Domins.Concrete;

namespace AddonTool
{
    /// <summary>
    /// SettingView.xaml 的交互逻辑
    /// </summary>
    public partial class SettingView : Page
    {
        public SettingView()
        {
            InitializeComponent();

            addonController = new AddonsControllerFactory().CreateAddonController();
            settingsManager = domainFactory.CreateSettingsManager();
            FolderClass = new FolderClass();
            TbFolderPath.DataContext = FolderClass;
        }

        private DomainFactory domainFactory = new DomainFactory();
        private ISettingsManager settingsManager;

        IAddonController addonController;
        FolderClass FolderClass;

        private void SettingView_LostFocus(object sender, RoutedEventArgs e)
        {
            if(CanSaveSettings(FolderClass.FolderPath))
            {
                SaveSettings(FolderClass.FolderPath);
            }
        }

        private void SettingView_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCurrentSettings();
        }

        private void BtChoseFolder_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.ShowNewFolderButton = false;
            folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            folderDialog.Description = "选择 _retail_ 文件夹...";


            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                string tempPath = addonController.GetAddonsFolderPath(folderDialog.SelectedPath);
                if (!string.IsNullOrWhiteSpace(tempPath))
                {
                    FolderClass.FolderPath = tempPath;
                }
                else
                {
                   // DisplayNotification("请选择正确的文件夹.");
                }
            }
        }
        public void LoadCurrentSettings()
        {
            FolderClass.FolderPath = settingsManager.AddonsFolder;
        }

        //Return false if the settings are invalid
        public bool CanSaveSettings(string folderPath)
        {
            if (!string.IsNullOrWhiteSpace(folderPath))
                return true;

            return false;
        }

        public void SaveSettings(string folderPath)
        {
            settingsManager.AddonsFolder = folderPath;

            //DisplayNotification("设置已保存!");
        }

    }
}
