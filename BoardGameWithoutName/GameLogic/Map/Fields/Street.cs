namespace GameLogic.Map.Fields
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using GameLogic.Map;
    using GameLogic.Game;

    public class Street : Field
    {
        public StreetBuilding building;
        public Player Owner { get; set; }
        public Street(string name, Neighbourhood neighbourhood, int row, int column)
            : base(name, neighbourhood.Color, row, column)
        {
            
        }
        public int Price { get; set; }
        public int Rent { get; set; }
        public Neighbourhood Neighbourhood { get; private set; }

        
    }
}
