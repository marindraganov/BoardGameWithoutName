namespace GameLogic.Game
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Dice
    {
        public static readonly Dice Instance = new Dice();
        private Random rand;
        private int diceValue;

        private Dice()
        {
            this.rand = new Random();
        }

        public int DiceValue
        {
            get
            {
                int curentDiceValue = this.diceValue;
                this.diceValue = 0;
                return curentDiceValue; 
            }
            private
            set
            {
               this.diceValue=value ;
            }
        }

        public void ManuallySetDiceValue(int value)
        {
            // dice value is incorrect or already set
            if (value < 2 || value > 12 )
            {
                return;
            }
            else
            {
                this.DiceValue = value;
                
            }
        }

        public void Roll()
        {
            this.diceValue = this.rand.Next(2, 13);
        }

        public void RollingTheDice()
        {
            System.Timers.Timer atimer = new System.Timers.Timer(1000);

            atimer.Elapsed += (s, e) =>
            {
                TimerDiceRoll.ReturnDiceSide();
            };
            atimer.Start();
            while (Console.Read() != 'q')
            {
                
            }
        }

        internal void Clear()
        {
            this.diceValue = 0;
        }
    }
}
