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
using System.Windows.Threading;
using System.Threading;
using ViewLayerWPF.ActionVisualizers;
using System.ComponentModel;

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
            this.DataContext = game;

            GameWindow.instance = this;
            this.Game = game;
            InitializeGame();
        }

        private void InitializeGame()
        {
            InitializePlayersInfo(this.Game.Players);
            InitializeMap(this.Game.Map, this.Game.CurrPlayer);
            InitializePlayerTokens(this.Game.Players);
            InitializeDice(this.Game.Dice);
            InitializeTurnBar(this.Game);
            foreach (var player in this.Game.Players)
            {
                player.PropertyChanged += Player_PropertyChanged;
            }
        }

        private void InitializeTurnBar(GameLogic.Game.Game game)
        {
            TurnControl playerTurnControl = new TurnControl(game);
            TurnBar.Children.Add(playerTurnControl);
        }

        private void InitializeDice(Dice dice)
        {
            DiceControl diceControl = new DiceControl(dice);
            DiceHolder.Children.Add(diceControl);
        }

        private void InitializePlayerTokens(List<Player> players)
        {
            for (int i = players.Count - 1; i >= 0; i--)
            {
                PlayerTokenControl playerToken = new PlayerTokenControl(players[i], i);
                MapHolder.Children.Add(playerToken);
            }
        }

        private void InitializeMap(GameMap map, Player player)
        {
            MapControl mapControl = new MapControl(this.Game);
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
            // all code here is just for test
            this.Game.Players[0].TakeHealth(10);
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
                PlayersInfoHolder.Children.Add(playerInfo);
            }
        }

        private void Game_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
                //this.Game.CurrPlayer.PropertyChanged += Offer_PropertyChanged;
                //this.Game.CurrPlayer.PropertyChanged = null;
        }

        private void Player_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.Game.CurrPlayer.Offer != null && this.Game.CurrPlayer.Offer.IsValid)
            {
                OfferVizualizer.Instance.Show(this.Game.CurrPlayer.Offer);
            }
        }
    }
}