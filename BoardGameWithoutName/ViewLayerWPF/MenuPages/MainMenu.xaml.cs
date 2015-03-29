namespace ViewLayerWPF.MenuPages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            this.InitializeComponent();
        }

        private void NewGameBtnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Window.MainWindowFrame.Source = new Uri("MenuPages/NewGameMenu.xaml", UriKind.Relative);
        }

        private void SettingsBtnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Window.MainWindowFrame.Source = new Uri("MenuPages/GameSettingsMenu.xaml", UriKind.Relative);
        }

        private void QuitBtnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ResumeGameBtnClick(object sender, RoutedEventArgs e)
        {
            GameWindow.Window.Show();
            MainWindow.Window.Hide();
        }

        private void SaveBtnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Save Button Do Not Work :)");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (GameWindow.Window == null)
            {
                ResumeBtn.IsEnabled = false;
            }
            else
            {
                ResumeBtn.IsEnabled = true;
            }
        }
    }
}
