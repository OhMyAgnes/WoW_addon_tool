using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DataIO.Addons.Controller;
using DataIO.Addons.Controller.Concrete;
using DataIO.Addons.Models.Concrete;

using AddonTool.ViewModels.Domins.Concrete;
using AddonTool.ViewModels.Domins;
using System.Collections.ObjectModel;
using System.Threading.Tasks;


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

            RemoveAddonsCommand = domainFactory.CreateCommand(RemoveAddons);
            addonController = addonControllerFactory.CreateAddonController();

            settingsManager = domainFactory.CreateSettingsManager();

            if ((Addons == null) && settingsManager.AddonsFolder != currentAddonFolder)
                LoadAddons();

        }

        private AddonsControllerFactory addonControllerFactory = new AddonsControllerFactory();
        private AddonController addonController;

        private DomainFactory domainFactory = new DomainFactory();
        private ISettingsManager settingsManager;

        private ObservableCollection<AddonInfo> Addons;
        public ObservableCollection<AddonInfo> AddonsFiltered
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(SearchTerm))
                    return new ObservableCollection<AddonInfo>(Addons.Where(addon => addon.Title.ToLower().Contains(SearchTerm.ToLower())));

                return Addons;
            }
        }

        public string SearchTerm { get; set; }

        //The folder all addons are currently loaded from. Saved in case user changes the folder during runtime. (then we reload the addons). 
        public string currentAddonFolder { get; set; }

        public Command RemoveAddonsCommand { get; set; }


        public bool ShowSettingsPrompt
        {
            get
            {
                return string.IsNullOrWhiteSpace(settingsManager.AddonsFolder);
            }
        }

        public object SettingsPrompt { get; set; }




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

            AddonListView.ItemsSource = Addons;


            if ((Addons == null) && settingsManager.AddonsFolder != currentAddonFolder)
                LoadAddons();

        }

        public void LoadAddons()
        {
            try
            {
                var addons = addonController.GetAddons(settingsManager.AddonsFolder);
                Addons = new ObservableCollection<AddonInfo>(addons);

                currentAddonFolder = settingsManager.AddonsFolder;
            }
            catch (Exception)
            {
               // DisplayNotification($"\"{settingsManager.AddonsFolder}\" is not a valid World of Warcraft root folder.");
            }
        }
        public void RemoveAddons(object selectedAddons)
        {
            IEnumerable<AddonInfo> addonsCollection = (selectedAddons as IEnumerable<object>).Select(o => o as AddonInfo);

            if (!addonsCollection.Any())
                return;

            bool uninstallConfirmed = true;

            string addonNames = string.Join(",\n", addonsCollection.Select(o => o.Title));

            //if the show uninstall confirmation settings is enabled, display the yes/no dialog.


            if (uninstallConfirmed)
            {
                addonController.RemoveAddons(addonsCollection);
               // Addons.Remove((i,x)=> {addonsCollection[i] => x});

                //because RemoveRange doesn't call the Set method in the Addons property, we need to notifyofpropertychange here.
                //NotifyOfPropertyChange(() => Addons);
                //NotifyOfPropertyChange(() => AddonsFiltered);
            }

        }

        public async void FileDropped(DragEventArgs e)
        {
            string[] fileNames = (string[])e.Data.GetData("FileDrop");

            await InstallAddon(fileNames);
        }

        private async Task InstallAddon(string[] fileNames)
        {
  
            try
            {
                
                foreach (string fileName in fileNames)
                    await addonController.InstallAddon(fileName, settingsManager.AddonsFolder);

                LoadAddons();


            }
            catch (Exception ex)
            {
                //DisplayNotification("Please select a valid addon Zip archive to install");
                //DisplayNotification(ex.Message);
            }
            finally
            {
               // DisplayProgressbar = "Collapsed";
            }
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
            LoadAddons();
            ///
            //DirectoryInfo AddonPath = new DirectoryInfo(FileClass.GameFolder + FileClass.AddonFolder);

            //if (!AddonPath.Exists)
            //{
            //    MessageBox.Show("插件目录不存在！");
            //    return;
            //}

            //List<DirectoryInfo> AddonList = AddonPath.GetDirectories().ToList();

            //List<string> RemainList = new List<string>();
            //List<string> RemoveList = new List<string>();

            //char[] tokens = { '-','_' };
            //foreach (var addonCur in AddonList)
            //    RemainList.Add(addonCur.Name.Split(tokens).Length > 1 ? addonCur.Name.Split(tokens)[0] : addonCur.Name);

            //foreach (var nameCur in RemainList)
            //{
            //    foreach (var nameNext in RemainList)
            //    {
            //        if (nameNext.Equals(nameCur))
            //            continue;
            //        if (nameNext.Contains(nameCur))
            //            RemoveList.Add(nameNext);
            //        if (nameCur.Contains(nameNext))
            //            RemoveList.Add(nameCur);
            //    }
            //}
            //foreach (var remove in RemoveList)
            //    RemainList.Remove(remove);

            //m_addon_list = RemainList.Distinct().ToList();
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
