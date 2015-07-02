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
    using GameLogic.Disasters;
    using GameLogic.GlobalConst;

using System.Threading;
    
    public class Game : INotifyPropertyChanged
    {
        private bool currPlayerMoved;
        private PathSetter pathSetter;
        private int turnDurationSeconds;
        private bool pause;
        private Disaster lastDisaster;
        private DisasterGenerator disasterGenerator;
        private GameMessages messages;
        private Player currPlayer;
        private Player winner;

        public Game(string[] playersNames, string mapName, GameSettings settings)
        {
            if (playersNames.Count() < GlobalConst.MinNumberOfPlayers || playersNames.Count() > GlobalConst.MaxNumberOfPlayers)
            {
                throw new ArgumentException(string.Format(
                    "The number of players must be between {0} and {1}!",
                    GlobalConst.MinNumberOfPlayers,
                    GlobalConst.MaxNumberOfPlayers
                    ));
            }

            this.GameTimer = new GameTimer(this,settings.GameDurationMinutes, settings.TurnDurationSeconds, EndOfTurn);
            this.currPlayerMoved = false;
            this.Pause = false;

            this.Map = GameMap.GetMapByName(mapName);
            this.Players = new List<Player>();
            this.InitializePlayers(playersNames, this.Players, this.Map.Start);
            this.CurrPlayer = this.Players[0];
            this.Dice = Dice.Instance;
            this.Dice.Reset();
            this.Messages = GameMessages.Instance;
            this.pathSetter = new PathSetter(this);
            this.disasterGenerator = new DisasterGenerator(this.Map);  
            this.disasterGenerator.SetConditions();
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
                if(this.currPlayer != null)
                {
                    this.currPlayer.OnTheMove = false;
                }

                this.currPlayer = value;
                this.currPlayer.OnTheMove = true;
                this.OnPropertyChanged(null);
            }
        }

        public Player Winner
        {
            get
            {
                return this.winner;
            }

            private set
            {
                this.winner = value;
                this.OnPropertyChanged(null);
            }
        }

        public Dice Dice { get; private set; }

        public int MoveValue
        {
            get
            {
                if (this.CurrPlayer.HealthStatus >= 100)
                {
                    return this.Dice.Value;
                }
                else if(this.Dice.Value == 0)
                {
                    return 0;
                }
                else
                {
                    int value = this.Dice.Value - (100 - this.CurrPlayer.HealthStatus)/10;
                    return (value < 1) ? 1 : value;
                }
            }
        }

        public GameMessages Messages { get; private set; }

        public GameTimer GameTimer { get; private set; }

        public bool Pause 
        {
            get
            {
                return this.pause;
            }

            set
            {
                this.pause = value;
                
                if (value == true)
                {
                    this.GameTimer.Pause();
                }
                else if (value == false)
                {
                    this.GameTimer.Resume();
                }
            }
        }

        public GameMap Map { get; private set; }

        public DisasterGenerator DisasterGenerator
        {
            get
            {
                return this.disasterGenerator;
            }
        }

        public DisasterConditions Conditions
        {
            get
            {
                return this.disasterGenerator.Conditions;
            }
        }

        public bool MoveCurrPlayer(Field targetField)
        {
            if (this.Dice.Value == 0 || this.currPlayerMoved ||
                !GameMap.FieldCanBeReached(this.CurrPlayer.Field, targetField, this.MoveValue))
            {
                return false;
            }
            else
            {
                this.CurrPlayer.MoveTo(targetField);
                this.currPlayerMoved = true;
                return true;
            }
        }

        public void EndOfTurn()
        {
            if (currPlayerMoved == false)
            {
                GameMessages.Instance.LastMessage = "You can not end your turn before move!";
                return;
            }
            else if (this.GameTimer.TurnDurationLeftSeconds == 0)
            {
                GameMessages.Instance.LastMessage = string.Format(
                    "{0} was charged ${1}, because didn't finish his/her turn in time!",
                    this.CurrPlayer.Name,
                    GlobalConst.SlowMoveFine);

                this.currPlayer.Pay(GlobalConst.SlowMoveFine);
            }

            foreach (var player in this.Players)
            {
                player.UpdateInsuraneceStatus();
            }

            foreach (var field in this.Map)
            {
                if (field is Street)
                {
                    (field as Street).UpdateProtectionStatus();
                }
            }

            if(CheckForWinner())
            {
                return;
            }

            SetNextPlayer();
            
            this.Dice.Clear();
            this.GameTimer.NewTurn();
        }

        private bool CheckForWinner()
        {
            List<Player> playersInTheGame = new List<Player>();

            foreach (var player in this.Players)
            {
                if (player.IsInTheGame)
                {
                    playersInTheGame.Add(player);
                }
            }

            if(playersInTheGame.Count == 1)
            {
                if (this.CurrPlayer != playersInTheGame[0])
                {
                    this.CurrPlayer = playersInTheGame[0];
                }

                this.Winner = playersInTheGame[0];
                return true;
            }

            if (this.GameTimer.GameDurationLeftMinutes == 0)
            {
                Player mostRich = this.Players[0];

                foreach (var player in this.Players)
                {
                    if ((player.Money - player.Credit) > (mostRich.Money - mostRich.Credit))
                    {
                        mostRich = player;
                    }
                }

                this.Winner = mostRich;
                return true;
            }

            return false;
        }

        private void SetNextPlayer()
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

            if(!this.currPlayer.IsInTheGame)
            {
                SetNextPlayer();
            }
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
            this.disasterGenerator.Generate();
            this.disasterGenerator.SetConditions();
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