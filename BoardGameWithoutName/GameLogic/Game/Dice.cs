namespace GameLogic.Game
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Timers;

    public class Dice : INotifyPropertyChanged
    {
        public static readonly Dice Instance = new Dice();
        private static Random rand;
        private int valueDice;

        private Dice()
        {
            rand = new Random();
            //this.valueDice = 0;
        }

        public int ValueDice
        {
            get 
            {
                int curentDiceValue = valueDice;
                this.valueDice = 0;
                return curentDiceValue;
            }

           private set
            {
                if (this.valueDice == 0)
                {
                    this.valueDice = value;
                }
                OnPropertyChanged(null);
            }
        }

        public void ManuallySetValue(int value)
        {
            // dice value is incorrect or already set
            if (value < 2 || value > 12 )
            {
                return;
            }
            else
            {
                this.ValueDice = value;
            }
        }

        public void Roll()
        {
            this.ValueDice = rand.Next(2, 13);
        }

        //public void RollingTheDice()
        //{
        //    Timer atimer = new Timer(100);
        //    //string side = string.Empty;
        //    atimer.Elapsed += (s, e) =>
        //    {
        //        TimerDiceRoll.ReturnDiceSide();

        //    };
        //    atimer.Start();
        //    //int count = 0;
        //    //while (count != 10000)
        //    //{
        //    //    count++;
        //    //}
        //    //while (Console.Read() != 'q')
        //    //{
        //    //    ;    // do nothing...
        //    //}
        //}

        internal void Clear()
        {
            this.valueDice = 0;
            OnPropertyChanged(null);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
