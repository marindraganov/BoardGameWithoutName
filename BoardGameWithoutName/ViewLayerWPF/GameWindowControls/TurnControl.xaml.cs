namespace ViewLayerWPF.GameWindowControls
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Media;
    using System.Windows.Shapes;

    using GameLogic.Game;

    /// <summary>
    /// Interaction logic for TurnControl.xaml
    /// </summary>
    public partial class TurnControl : UserControl
    {
        private Game game;

        public TurnControl(Game game)
        {
            this.InitializeComponent();
            this.game = game;
            this.ShowPlayersColors();
        }

        private void ShowPlayersColors()
        {
            foreach (var player in this.game.Players)
            {
                Rectangle rect = new Rectangle();
                rect.Width = 17;
                rect.Height = 8;
                rect.Margin = new Thickness(0, 0, 7, 0);
                rect.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString(player.Color.Name);
                Binding binding = new Binding("IsInTheGame")
                {
                    Converter = new BooleanToVisibilityConverter(),
                    Source = player
                };
                rect.SetBinding(Rectangle.VisibilityProperty, binding);
                PlayersColors.Children.Add(rect);
            }
        }

        private void EndTurnBtnClick(object sender, RoutedEventArgs e)
        {
            this.game.EndOfTurn();
        }
    }
}
