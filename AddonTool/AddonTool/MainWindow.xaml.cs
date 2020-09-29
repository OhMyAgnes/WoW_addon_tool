using System.Windows;
using System.Windows.Controls;

using System.Windows.Navigation;

namespace AddonTool
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //
        bool Naviga;

        private void DMSkinWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void DMSkinWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Naviga = true;

            AddonsView.IsChecked = true;
            ChangeView_Click(AddonsView, e);
        }

        private void ChangeView_Click(object sender, RoutedEventArgs e)
        {
            Naviga = true;

            RadioButton rb = sender as RadioButton;
            Naviga = true;
            switch (rb.Name.ToString())
            {
                case "AddonsView":
                    Frame.Content = PageClass.addonsView;
                    PageClass.LoadAddonsViewCount++;
                    break;
                //case "WTFMoveView":
                //    Frame.Content = PageClass.aligment;
                //    PageClass.aligmentPageCount++;
                //    break;
                //case "SystemPage":
                //    Frame.Content = pageClass.systemPage;
                //    pageClass.systemPageCount++;
                //    break;
                case "SettingView":
                    Frame.Content = PageClass.settingView;
                    PageClass.LoadSettingViewCount++;
                    break;
            }
        }
        private void Frame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (!Naviga)
            {
                e.Cancel = true;
            }
            Naviga = false;
        }
    }


}
