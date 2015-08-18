namespace ViewLayerWPF.GameWindowControls
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Media;

    using GameLogic.Game;
    
    /// <summary>
    /// Interaction logic for PlayerTokenControl.xaml
    /// </summary>
    public partial class PlayerTokenControl : UserControl
    {
        private Player player;
        private int turn;

        public PlayerTokenControl(Player player, int turn)
        {
            this.InitializeComponent();
            this.DataContext = player;
            this.player = player;
            this.turn = turn;
            this.SetPositions();
            this.SetColor();

            player.PropertyChanged += this.Position_PropertyChanged;
            MapControl.SizeChnged += this.SetPositions;
        }

        private void Position_PropertyChanged(object sender, EventArgs e)
        {
            this.SetPositions();
        }

        private void SetPositions()
        {
            int currCol = this.player.Field.Column;
            int cols = MapControl.Cols;
            double width = MapControl.Width;
            double xPos = ((currCol + 0.5) * (width / cols)) - 25 + (this.turn * 8);
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
            Panel.SetZIndex(this.TokenCanvas, 10 - this.turn);
        }
    }
}
