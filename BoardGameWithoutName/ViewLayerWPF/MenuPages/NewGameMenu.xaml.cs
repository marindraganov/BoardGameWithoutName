namespace ViewLayerWPF.MenuPages
{
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

    using GameLogic;
    using GameLogic.Game;
    using GameLogic.Map;

    /// <summary>
    /// Interaction logic for NewGameMenu.xaml
    /// </summary>
    public partial class NewGameMenu : Page
    {
        public NewGameMenu()
        {
            this.InitializeComponent();
        }

        public int NumberOfPlayers
        {
            get
            {
                int numberOfPlayers = 2;
                int.TryParse(NumberOfPlayersInput.SelectionBoxItem.ToString(), out numberOfPlayers);

                return numberOfPlayers;
            }
        }

        private void BackToMainBtnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Window.MainWindowFrame.Source = new Uri("MenuPages/MainMenu.xaml", UriKind.Relative);
        }

        private void CreateGameBtnClick(object sender, RoutedEventArgs e)
        {
            Game game = new Game(GetPlayersNames(), MapName.SelectionBoxItem.ToString(), new GameSettings());
            GameWindow gameWindow = new GameWindow(game);
            gameWindow.Show();
            MainWindow.Window.Hide();
        }

        private void NumberOfPlayersInput_DropDownClosed(object sender, EventArgs e)
        {
            int numberOfPlayers = 2;
            int.TryParse(NumberOfPlayersInput.SelectionBoxItem.ToString(), out numberOfPlayers);

            for (int i = 2; i < NamesInput.Children.Count; i++)
            {
                if (i >= numberOfPlayers)
                {
                    NamesInput.Children[i].Visibility = Visibility.Collapsed;
                }
                else
                {
                    NamesInput.Children[i].Visibility = Visibility.Visible;
                }
            }
        }

        private string[] GetPlayersNames()
        {
            int numberOfPlayers = this.NumberOfPlayers;

            string[] names = new string[numberOfPlayers];

            for (int i = 0; i < numberOfPlayers; i++)
            {
                names[i] = (NamesInput.Children[i] as TextBox).Text;
            }

            return names;
        }
    }
}