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
    /// Interaction logic for GameSettingsMenu.xaml
    /// </summary>
    public partial class GameSettingsMenu : Page
    {
        public GameSettingsMenu()
        {
            this.InitializeComponent();
        }

        private void BackToMainBtnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Window.MainWindowFrame.Source = new Uri("MenuPages/MainMenu.xaml", UriKind.Relative);
        }

        private void MuteAllBtnClick(object sender, RoutedEventArgs e)
        {
            sliderMusicVolume.Value = 0;
            sliderSounds.Value = 0;
        }

       
    }
}
