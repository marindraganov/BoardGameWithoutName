using GameLogic;
using GameLogic.Game;
using GameLogic.Map;
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

        public GameWindow(Game game)
        {
            InitializeComponent();
            GameWindow.instance = this;
            this.Game = game;
            InitializeGame();
        }

        private void InitializeGame()
        {
            InitializePlayersInfo(this.Game.Players);
            InitializeMap(this.Game.Map);
            PlayerTokenControl player = new PlayerTokenControl(this.Game.Players[0]);
            MapHolder.Children.Add(player);
            
        }

        private void InitializeMap(GameMap map)
        {
            MapControl mapControl = new MapControl(map);
            MapHolder.Children.Add(mapControl);
        }

        public static GameWindow Window
        {
            get
            {
                return instance;
            }
        }

        public Game Game { get; set; }

        private void MainMenuBtnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow.Window.MainWindowFrame.Source = new Uri("MenuPages/MainMenu.xaml", UriKind.Relative);
            MainWindow.Window.Show();
        }

        private void TestBtnClick(object sender, RoutedEventArgs e)
        {
            this.Game.Players[0].TakeHealth(10);
            this.Game.Players[0].Field = this.Game.Players[0].Field.NextFields[0];
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void InitializePlayersInfo(List<Player> players)
        {
            foreach (var player in players)
            {
                PlayerInfoControl playerInfo = new PlayerInfoControl(player);
                PlayersInfoBar.Children.Add(playerInfo);
            }     
        }
    }
}