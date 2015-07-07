namespace GameLogic.Disasters
{   
    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Threading.Tasks;

    using GameLogic.Map;

    public class DisasterGenerator : INotifyPropertyChanged
    {
        private static Random rnd = new Random();
        private GameMap map;
        private Disaster lastDisaster;

        internal DisasterGenerator(GameMap map)
        {
            this.map = map;
            this.Conditions = new DisasterConditions();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public DisasterConditions Conditions { get; private set; }

        public Disaster LastDisaster
        {
            get
            {
                return this.lastDisaster;
            }

            internal set
            {
                this.lastDisaster = value;
                this.OnPropertyChanged(null);
            }
        }

        public void SetConditions()
        {
            this.Conditions.ChanceForAssault = rnd.Next(90);
            this.Conditions.ChanceForEarthquake = rnd.Next(90);
            this.Conditions.ChanceForVirus = rnd.Next(90);
        }

        internal void Generate()
        {
            string[] disasterNames = new string[]
            {
                "None", 
                "Assault",
                "Earthquake",
                "Virus"
            };

            int[] possibilities = new int[4];

            possibilities[0] = 0;
            possibilities[1] = this.Conditions.ChanceForAssault + possibilities[0];
            possibilities[2] = this.Conditions.ChanceForEarthquake + possibilities[1];
            possibilities[3] = this.Conditions.ChanceForVirus + possibilities[2];

            int low = 0;
            int maxPossible = possibilities[3];

            // example
            // possibilities = [270, 300, 360, 400];
            // our possibility interval is 0 to 400

            int rndValueInPosibilityInterval = rnd.Next(0, maxPossible);
            int disasterNameIndex = 0;

            for (int i = 0; i < possibilities.Length; i++)
            {
                if (rndValueInPosibilityInterval > low && rndValueInPosibilityInterval < possibilities[i])
                {
                    disasterNameIndex = i;
                    break;
                }
            }

            string disasterName = disasterNames[disasterNameIndex];

            if (disasterNameIndex == 0)
            {
                this.LastDisaster = null;
            }
            else
            {
                Field rndField = GameMap.GetRandomField(this.map);

                if (disasterNameIndex == 1)
                {
                    this.LastDisaster = new Assault(rndField);
                }
                else if (disasterNameIndex == 2)
                {
                    this.LastDisaster = new Earthquake(rndField);
                }
                else if (disasterNameIndex == 3)
                {
                    this.LastDisaster = new Virus(rndField);
                }
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
