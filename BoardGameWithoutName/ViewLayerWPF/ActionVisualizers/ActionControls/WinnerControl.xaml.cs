namespace ViewLayerWPF.ActionVisualizers.ActionControls
{
    using System;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;

    using GameLogic.Game;

    /// <summary>
    /// Interaction logic for WinControl.xaml
    /// </summary>
    public partial class WinnerControl : UserControl
    {
        public WinnerControl(Player winner)
        {
            InitializeComponent();
            this.DataContext = winner;
        }

        private void BackToMenuClick(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
            GameWindow.Window.Hide();
            MainWindow.Window.MainWindowFrame.Source = new Uri("MenuPages/MainMenu.xaml", UriKind.Relative);
            MainWindow.Window.Show();
        }
    }
}
