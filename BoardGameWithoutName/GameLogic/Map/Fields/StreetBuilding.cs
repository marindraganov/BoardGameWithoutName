namespace GameLogic.Map.Fields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using GameLogic.GlobalConst;
    using System.ComponentModel;

    public enum TypeOfBuilding
    {
        House,
        Hotel,
        Palace
    }

    public class StreetBuilding : INotifyPropertyChanged
    {
        private TypeOfBuilding type;

        internal StreetBuilding()
        {
            this.Type = TypeOfBuilding.House;
            this.Stability = 100;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public TypeOfBuilding Type
        {
            get
            {
                return this.type;
            }

            private set
            {
                this.type = value;
                OnPropertyChanged(null);
            }
        }

        public int Stability { get; internal set; }
        
        internal void Update() 
        {
            if (this.Type == TypeOfBuilding.House)
            {
                this.Type = TypeOfBuilding.Hotel;
            }
            else if (this.Type == TypeOfBuilding.Hotel)
            {
                this.Type = TypeOfBuilding.Palace;
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