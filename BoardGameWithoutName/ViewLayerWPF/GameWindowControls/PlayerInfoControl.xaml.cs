namespace ViewLayerWPF.GameWindowControls
{
    using System.Windows.Controls;
    using System.Windows.Media;

    using GameLogic.Game;

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
