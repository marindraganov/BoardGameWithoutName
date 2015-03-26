namespace GameLogic.Game
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Dice
    {
        internal static readonly Dice Instance = new Dice();
        private Random rand;
        private int diceValue;

        private Dice()
        {
            this.rand = new Random();
        }

        public int Value { get; private set; }

        public void ManuallySetDiceValue(int value)
        {
            // dice value is incorrect or already set
            if (value < 2 || value > 12 || this.diceValue != 0)
            {
                return;
            }
            else
            {
                this.Value = value;
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
    }
}
