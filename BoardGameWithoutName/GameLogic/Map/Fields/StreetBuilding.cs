namespace GameLogic.Map.Fields
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;

    using GameLogic.GlobalConst;

    public enum TypeOfBuilding
    {
        House,
        Hotel,
        Palace
    }

    public class StreetBuilding : INotifyPropertyChanged
    {
        private TypeOfBuilding type;
        private int stability;

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
                this.OnPropertyChanged(null);
            }
        }

        public int Stability
        {
            get
            {
                return this.stability;
            }

            internal set
            {
                this.stability = value;
                this.OnPropertyChanged(null);
            }
        }
        
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