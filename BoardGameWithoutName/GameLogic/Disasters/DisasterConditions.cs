namespace GameLogic.Disasters
{
    using System.ComponentModel;

    public class DisasterConditions : INotifyPropertyChanged
    {
        private int chanceForAssault;
        private int chanceForVirus;
        private int chanceForEarthquake;

        internal DisasterConditions()
        {
            this.ChanceForAssault = 0;
            this.ChanceForVirus = 0;
            this.ChanceForEarthquake = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int ChanceForAssault 
        { 
            get
            {
                return this.chanceForAssault;
            }

            internal set
            {
                this.chanceForAssault = value;
                this.OnPropertyChanged(null);
            }
        }

        public int ChanceForVirus
        {
            get
            {
                return this.chanceForVirus;
            }

            internal set
            {
                this.chanceForVirus = value;
                this.OnPropertyChanged(null);
            }
        }

        public int ChanceForEarthquake
        {
            get
            {
                return this.chanceForEarthquake;
            }

            internal set
            {
                this.chanceForEarthquake = value;
                this.OnPropertyChanged(null);
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
    }
}
