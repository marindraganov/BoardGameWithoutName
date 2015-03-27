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
using System.Windows.Shapes;

using ViewLayerWPF.GameWindowControls;

namespace ViewLayerWPF
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private static GameWindow instance;

        private GameWindow()
        {
            InitializeComponent();
        }

        public static GameWindow Window {
            get 
            {
                if (instance == null)
                {
                    instance = new GameWindow();
                }
                return instance;
            }
        }

        private void MainMenuBtnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow.Window.MainWindowFrame.Source = new Uri("MenuPages/MainMenu.xaml", UriKind.Relative);
            MainWindow.Window.Show();
        }

        private void TestBtnClick(object sender, RoutedEventArgs e)
        {
            PlayerInfoControl playerInfo = new PlayerInfoControl();
            PlayersInfoBar.Children.Add(playerInfo);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
