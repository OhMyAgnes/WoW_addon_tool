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

            MainPage.IsChecked = true;
            ChangeView_Click(MainPage, e);
        }

        private void ChangeView_Click(object sender, RoutedEventArgs e)
        {
            Naviga = true;

            RadioButton rb = sender as RadioButton;
            Naviga = true;
            switch (rb.Name.ToString())
            {
                case "MainPage":
                    Frame.Content = PageClass.mainPage;
                    PageClass.LoadMainPageCount++;
                    break;
                //case "Alignment":
                //    Frame.Content = PageClass.aligment;
                //    PageClass.aligmentPageCount++;
                //    break;
                //case "SystemPage":
                //    Frame.Content = pageClass.systemPage;
                //    pageClass.systemPageCount++;
                //    break;
                //case "TestPage":
                //    Frame.Content = pageClass.testPage;
                //    pageClass.testPageCount++;
                //    break;
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
