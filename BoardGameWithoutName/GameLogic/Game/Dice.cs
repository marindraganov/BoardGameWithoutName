namespace GameLogic.Game
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Dice : INotifyPropertyChanged
    {
        public static readonly Dice Instance = new Dice();
        private static Random rand;
        private int value;

        private Dice()
        {
            rand = new Random();
            this.value = 0;
        }

        public int Value
        {
            get 
            {
                return this.value;
            }

            private set
            {
                if (this.value == 0)
                {
                    this.value = value;
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
                this.Value = value;
            }
        }

        public void Roll()
        {
            this.Value = rand.Next(2, 13);
        }

        //public void RollingTheDice()
        //{
            //System.Timers.Timer atimer = new System.Timers.Timer(100);
            //string side = string.Empty;
            //atimer.Elapsed += (s, e) =>
            //{
            //     TimerDiceRoll.ReturnDiceSide();
            
            //};
            //atimer.Start();
            //int count = 0;
            //while (count != 10000)
            //{
            //    count++;
            //}
        //}

        internal void Clear()
        {
            this.value = 0;
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
