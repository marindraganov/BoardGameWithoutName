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
            this.sliderMusicVolume.Value = MainMenu.AudioPlayer.Volume;
        }

        // Getting MusicVolume and SoundsVolume slider values into double variables
        public double MusicVolume { get; set; }

        public double GameSoundsVolume { get; set; }

        // boolean value for checkbox - allowing real dice
        public bool AllowRealDice { get; set; }

        public void RealDiceCheck_Checked(object sender, RoutedEventArgs e)
        {
            this.AllowRealDice = true;
           ////AllowRealDice = RealDiceCheck.IsChecked.Value;
        }

        private void MuteAllBtnClick(object sender, RoutedEventArgs e)
        {
            sliderMusicVolume.Value = 0;
            sliderSounds.Value = 0;
        }

        private void BackToMainBtnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Window.MainWindowFrame.Source = new Uri("MenuPages/MainMenu.xaml", UriKind.Relative);
        }

        private void RealDiceCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            this.AllowRealDice = false;
            ////AllowRealDice = RealDiceCheck.IsChecked.Value;
        }

        private void SliderMusicVolumeValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.MusicVolume = sliderMusicVolume.Value;
            MainMenu.AudioPlayer.Volume = this.MusicVolume;
        }

        private void SliderSoundsValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.GameSoundsVolume = sliderSounds.Value;
        }
    }
}
