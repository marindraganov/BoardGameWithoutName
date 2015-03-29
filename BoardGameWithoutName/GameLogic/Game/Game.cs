namespace GameLogic.Game
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
       
    using GameLogic.Fields;
    using GameLogic.Fields.Institutions;
    using GameLogic.Game;
    using GameLogic.Map;
    using Interfaces;

    public class Game : IRollScoreRouls
    {
        // when the dice is roll there will be calculation of the points player gets from that roll.
        // public virtual CalculateRollScore(IEnumerable<IRollScoreRouls<int>> results)
        // {
        // }
        public Game(string[] playersNames, GameMap map, GameSettings settings)
        {
            if (playersNames.Count() < 2 || playersNames.Count() > 6)
            {
                throw new ArgumentException("The number of players must be between 2 and 6!");
            }

            this.Players = new List<Player>();
            this.InitializePlayers(playersNames, this.Players, map.Start);

            this.CurrPlayer = this.Players[0];
            this.Dice = Dice.Instance;
            this.Map = map;
        }

        public List<Player> Players { get; private set; }

        // the player who's turn is now
        public Player CurrPlayer { get; private set; }

        public Dice Dice { get; private set; }

        public GameMap Map { get; private set; }

        public void MoveCurrPlayer(Field targetField)
        {
            if (Dice.DiceValue == 0 ||
                !GameMap.FieldCanBeReached(this.CurrPlayer.Field, targetField, this.Dice.DiceValue))
            {
                return;
            }
            else
            {
                this.CurrPlayer.MyTurn(targetField);
                this.Dice.Clear();
            }
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