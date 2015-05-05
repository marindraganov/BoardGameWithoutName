using System.ComponentModel;
namespace GameLogic.Disasters
{
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
                return chanceForAssault;
            }

            internal set
            {
                this.chanceForAssault = value;
                OnPropertyChanged(null);
            }
        }

        public int ChanceForVirus
        {
            get
            {
                return chanceForVirus;
            }

            internal set
            {
                this.chanceForVirus = value;
                OnPropertyChanged(null);
            }
        }

        public int ChanceForEarthquake
        {
            get
            {
                return chanceForEarthquake;
            }

            internal set
            {
                this.chanceForEarthquake = value;
                OnPropertyChanged(null);
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
