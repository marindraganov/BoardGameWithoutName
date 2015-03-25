namespace GameLogic.Game
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using GameLogic.Map;


    using GlobalConst;
    public class Player
    {
        Field field;

      
        private string name;
   
        private Direction directionPlayer;
        private decimal healthStatus;
        private decimal moneyStatus;

     
        private int[] countOfRolls; // Every Player have 1 Attempt fo roll a dice.

        public Player(string namePlayer,Field fieldStart)
        {

            this.Field = fieldStart;
            this.DirectionPlayer = Direction.Down;
            this.HealthStatus = GlobalConstOfAbilities.powerHealt;
            this.Name = namePlayer;
            this.MoneyStatus = GlobalConstOfAbilities.monyValues;
           
        }

        public Field Field
        {
            get { return field; }
            set { field = value; }
        }

        public decimal MoneyStatus
        {
            get { return moneyStatus; }
            set { moneyStatus = value; }
        }

        public decimal HealthStatus
        {
            get { return healthStatus; }
            set { healthStatus = value; }
        }

       
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        internal Direction DirectionPlayer
        {
            get { return directionPlayer; }
            set { directionPlayer = value; }
        }

        internal RollDice RollDice
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

   

    }
}
