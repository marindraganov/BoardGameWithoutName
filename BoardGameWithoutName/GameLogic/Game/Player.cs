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
        private readonly string name;
        private Field field;
        private int healthStatus;
        private int moneyStatus;

        private int[] countOfRolls; // Every Player have 1 Attempt fo roll a dice.

        public Player(string namePlayer, Field field)
        {
            this.HealthStatus = GlobalConst.InitialHealth;
            this.MoneyStatus = GlobalConst.InitialMoney;

            this.Field = field;
            this.Name = namePlayer;
        }

        public Field Field { get; set; }

        public int MoneyStatus { get; private set; }

        public decimal HealthStatus { get; private set; }

        public string Name { get; private set; }
    }
}
