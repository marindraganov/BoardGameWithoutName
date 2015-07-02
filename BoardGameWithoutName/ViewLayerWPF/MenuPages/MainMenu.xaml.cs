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
        private static MediaPlayer audioPlayer = new MediaPlayer();

        public MainMenu()
        {
            this.InitializeComponent();
        }

        private void PlayIntroSound()
        {
            if (!AudioPlayer.HasAudio)
            {
                AudioPlayer.Open(new Uri("Media/Sounds/MPR.mp3", UriKind.Relative));
                AudioPlayer.MediaEnded += new EventHandler(AP_MediaEnded);
                AudioPlayer.Volume = 0.3f;
            }

            AudioPlayer.Play();
        }

        private void AP_MediaEnded(object sender, EventArgs e)
        {

            AudioPlayer.Position = new TimeSpan(0, 0, 0);
            AudioPlayer.Play();
        }

        public static MediaPlayer AudioPlayer
        {
            get
            { 
                return audioPlayer; 
            }
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
            if (GameWindow.Window == null)
            {
                MessageBoxResult result = MessageBox.Show("You have to create game first!", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                if (result == MessageBoxResult.OK)
                {
                    e.Handled = true;
                }
            }
            else
            {
                AudioPlayer.Pause();
                GameWindow.Window.Show();
                MainWindow.Window.Hide();
            }
        }

        private void SaveBtnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Save Button Do Not Work :)");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.PlayIntroSound();
        }
    }
}
