namespace GameLogic.Map.Fields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using GameLogic.GlobalConst;

    public enum TypeOfBuilding
    {
        House,
        Hotel,
        Palace
    }

    public class StreetBuilding
    {
        internal StreetBuilding()
        {
            this.Type = TypeOfBuilding.House;
            this.Stability = 100;
        }

        public TypeOfBuilding Type { get; private set; }

        public int Stability { get; set; }
        
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
    }
}