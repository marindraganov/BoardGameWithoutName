using GameLogic.Game;
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

namespace ViewLayerWPF.ActionVisualizers.ActionControls
{
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
