namespace GameLogic.Game
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using GameLogic.Game;
    using GameLogic.Map;
    using GameLogic.Map.Fields;
    using GameLogic.Map.Fields.Institutions;
    using Interfaces;
    
    public class Game : INotifyPropertyChanged
    {
        private bool currPlayerMoved;
        private PathSetter pathSetter;
        private Player currPlayer;

        public Game(string[] playersNames, string mapName, GameSettings settings)
        {
            if (playersNames.Count() < 2 || playersNames.Count() > 6)
            {
                throw new ArgumentException("The number of players must be between 2 and 6!");
            }

            this.currPlayerMoved = false;

            this.Map = GameMap.GetMapByName(mapName);
            this.Players = new List<Player>();
            this.InitializePlayers(playersNames, this.Players, this.Map.Start);
            this.CurrPlayer = this.Players[0];
            this.Dice = Dice.Instance;
            this.pathSetter = new PathSetter(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Player> Players { get; private set; }

        // the player who's turn is now
        public Player CurrPlayer 
        { 
            get
            {
                return this.currPlayer;
            }

            private set
            {
                this.currPlayer = value;
                this.OnPropertyChanged(null);
            }
        }

        public Dice Dice { get; private set; }

        public GameMap Map { get; private set; }

        public void MoveCurrPlayer(Field targetField)
        {
            if (this.Dice.Value == 0 || this.currPlayerMoved ||
                !GameMap.FieldCanBeReached(this.CurrPlayer.Field, targetField, this.Dice.Value))
            {
                return;
            }
            else
            {
                this.CurrPlayer.MoveTo(targetField);
                this.currPlayerMoved = true;
            }
        }

        public void CurrPlayerBuyStreet()
        {
            this.CurrPlayer.BuyStreeet();
        }

        public void EndOfTurn()
        {
            this.currPlayerMoved = false;
            int currPlayerTurnIndex = this.Players.IndexOf(this.CurrPlayer);

            // it was last player turn
            if (currPlayerTurnIndex == this.Players.Count - 1)
            {
                this.EndOfCicle();
            }

            int nextPlayerIndex = (currPlayerTurnIndex + 1) % this.Players.Count;
            this.CurrPlayer = this.Players[nextPlayerIndex];
            this.Dice.Clear();
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void EndOfCicle()
        {
            return;
        }

        private void InitializePlayers(string[] playersNames, List<Player> players, Field start)
        {
            for (int i = 0; i < playersNames.Length; i++)
            {
                players.Add(new Player(playersNames[i], start, Player.Colors[i]));
            }
        }
    }
}