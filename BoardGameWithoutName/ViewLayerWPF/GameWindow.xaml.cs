namespace ViewLayerWPF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;

    using GameLogic;
    using GameLogic.Disasters;
    using GameLogic.Game;
    using GameLogic.Map;
    using ViewLayerWPF.ActionVisualizers;
    using ViewLayerWPF.GameWindowControls;

    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private static GameWindow instance;
       
        public GameWindow(Game game)
        {
            this.InitializeComponent();
            this.DataContext = game;

            GameWindow.instance = this;
            this.Game = game;
            this.InitializeGame();
        }

        public static GameWindow Window
        {
            get
            {
                return instance;
            }
        }

        public Game Game { get; set; }

        private void InitializeGame()
        {
            this.InitializePlayersInfo(this.Game.Players);
            this.InitializeMap(this.Game.Map, this.Game.CurrPlayer);
            this.InitializePlayerTokens(this.Game.Players);
            this.InitializeConditions(this.Game.Conditions);
            this.InitializeDice(this.Game.Dice);
            this.InitializeTurnBar(this.Game);

            foreach (var player in this.Game.Players)
            {
                player.PropertyChanged += this.Player_PropertyChanged;
            }

            this.Game.Messages.PropertyChanged += this.Messages_PropertyChanged;
            this.Game.DisasterGenerator.PropertyChanged += this.LastDisaster_PropertyChanged;
            this.Game.PropertyChanged += this.Winner_PropertyChanged;
        }

        private void InitializeMap(GameMap map, Player player)
        {
            MapControl mapControl = new MapControl(this.Game);
            MapHolder.Children.Add(mapControl);
        }

        private void InitializeConditions(DisasterConditions disasterConditions)
        {
            ConditionsControl conditionsControl = new ConditionsControl(disasterConditions);
            ConditionsHolder.Children.Add(conditionsControl);
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

        private void MainMenuBtnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow.Window.MainWindowFrame.Source = new Uri("MenuPages/MainMenu.xaml", UriKind.Relative);
            MainWindow.Window.Show();
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

        private void Player_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.Game.CurrPlayer.Offer != null && this.Game.CurrPlayer.Offer.IsValid)
            {
                Visualizer.Instance.ShowOffer(this.Game.CurrPlayer.Offer);
            }
        }

        private void Messages_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string message = this.Game.Messages.LastMessage;
            if (message != null && message != string.Empty)
            {
                GameMessageVisualizer.Instance.Show(message);
            }
        }

        private void LastDisaster_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.Game.DisasterGenerator.LastDisaster != null)
            {
                Visualizer.Instance.ShowDisaster(this.Game.DisasterGenerator.LastDisaster);
            }   
        }

        private void Winner_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.Game.Winner != null)
            {
                Visualizer.Instance.ShowWinWindow(this.Game.Winner);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Game.Players[1].TakeHealth(10);
        }
    }
}