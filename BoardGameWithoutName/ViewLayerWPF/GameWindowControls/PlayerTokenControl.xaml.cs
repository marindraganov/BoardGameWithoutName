using GameLogic.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private Player player;
        int turn;

        public PlayerTokenControl(Player player, int turn)
        {
            InitializeComponent();
            this.DataContext = player;
            this.player = player;
            this.turn = turn;
            SetPositions();
            SetColor();

            player.PropertyChanged += Position_PropertyChanged;
            MapControl.sizeChnged += SetPositions;
        }

        private void Position_PropertyChanged(object sender, EventArgs e)
        {
            SetPositions();
        }

        private void SetPositions()
        {
            int currCol = this.player.Field.Column;
            int cols = MapControl.Cols;
            double width = MapControl.Width;
            double xPos = (currCol + 0.5) * (width / cols) - 25 + this.turn * 8;
            PlayerToken.SetValue(Canvas.LeftProperty, xPos);

            int currRow = this.player.Field.Row;
            int rows = MapControl.Rows;
            double heigth = MapControl.Height;
            double yPos = (heigth / rows * currRow) - 5;
            PlayerToken.SetValue(Canvas.TopProperty, yPos);
        }

        private void SetColor()
        {
            PlayerToken.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString(this.player.Color.Name);
            Panel.SetZIndex(TokenCanvas,  10 - this.turn);
        }
    }
}
