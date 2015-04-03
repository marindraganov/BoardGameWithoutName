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
        private int value;

        private Dice()
        {
            rand = new Random();
            this.value = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

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

                this.OnPropertyChanged(null);
            }
        }

        public void ManuallySetValue(int value)
        {
            // dice value is incorrect or already set
            if (value < 2 || value > 12)
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
            if (this.Value != 0)
            {
                return;
            }

            this.Value = rand.Next(2, 13);
        }

        internal void Clear()
        {
            this.value = 0;
            this.OnPropertyChanged(null);
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
