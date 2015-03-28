namespace GameLogic.Map.Fields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public enum TypeOfBuilding
    {
        House,
        Hotel,
        Palace
    }
    public class StreetBuilding
    {
        public TypeOfBuilding CurrentType { get; set; }
        
        private StreetBuilding()
        {

        }

        
        public int Price { get; set; }
        public int Rent { get; set; }
        
        public int Update() 
        {
            switch (CurrentType) 
            {
                case TypeOfBuilding.House: return 150 ;
                case TypeOfBuilding.Hotel: return 300;
                case TypeOfBuilding.Palace:return 0;
            }
            return 0;
        }
        
    }
}