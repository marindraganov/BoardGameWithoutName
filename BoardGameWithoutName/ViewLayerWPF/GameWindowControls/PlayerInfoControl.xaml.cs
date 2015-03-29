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
using System.Drawing;

namespace ViewLayerWPF.GameWindowControls
{
    /// <summary>
    /// Interaction logic for PlayersInfo.xaml
    /// </summary>
    public partial class PlayerInfoControl : UserControl
    {
        public PlayerInfoControl(Player player)
        {
            InitializeComponent();
            this.DataContext = player;
            this.NameLabel.Content = player.Name + " ▩";
            this.NameLabel.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(player.Color.Name);
        }
    }
}
