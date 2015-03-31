using GameLogic.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ViewLayerWPF.GameWindowControls
{
    /// <summary>
    /// Interaction logic for PlayerTokenControl.xaml
    /// </summary>
    public partial class PlayerTokenControl : UserControl
    {
        public PlayerTokenControl(Player player)
        {
            InitializeComponent();
            this.DataContext = player;
        }

        private void TokenCanvas_SizeChanged(object sender, EventArgs e)
        {
            //Thread.Sleep(50);
            RecalculatePlayersPositions();
        }

        private void TokenCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            RecalculatePlayersPositions();
        }

        private void RecalculatePlayersPositions()
        {
            if (PlayerToken != null)
            {
                PlayerToken.GetBindingExpression(Canvas.TopProperty).UpdateTarget();
                PlayerToken.GetBindingExpression(Canvas.LeftProperty).UpdateTarget();
            }
        }
    }
}
