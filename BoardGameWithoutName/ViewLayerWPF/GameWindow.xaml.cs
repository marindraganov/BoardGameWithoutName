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

namespace ViewLayerWPF
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private static GameWindow instance;
        CancellationTokenSource cts;
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
        public static string ReturnDiceSide()
        {
            Dice dice = Dice.Instance;
            dice.Roll();
            return dice.DiceValue.ToString();

        }

        private void DoSomeWork()
        {

            System.Timers.Timer atimer = new System.Timers.Timer(100);
            string side = string.Empty;
            atimer.Elapsed += (s, e) =>
            {
                DIceRoling();
            };
            atimer.Start();
            int count = 0;
            while (count != 5)
            {
                count++;
                if(count==5)
                {
                    break;
                }
            }

        }

        private void DIceRoling()
        {

         
           

                    DiceTextBox.Dispatcher.Invoke((Action)(() =>
                      {
                          DiceTextBox.Clear();
                          DiceTextBox.Text += ReturnDiceSide();

                      }),DispatcherPriority.Normal,cts.Token);
          


        }
           

    
             
    
        

        private void Button_RoolClick(object sender, RoutedEventArgs ex)
        {
            CancellationTokenSource source = new CancellationTokenSource();


            Task.Run(() => DoSomeWork(), source.Token);


            //this.Game.Dice.RollingTheDice();
        }



        private void StopChecked(object sender, RoutedEventArgs e)
        {

        }

        private void Roll_ButtonCliced(object sender, RoutedEventArgs e)
        {
            cts = new CancellationTokenSource();

            StopRadioButon.IsChecked = false;
            try
            {
                Task.Run(() => DoSomeWork(), cts.Token);


            }
            catch (Exception)
            {

                throw;
            }

        }

        private void Ende(object sender, RoutedEventArgs e)
        {
            cts.Dispose();
        }



    }
}