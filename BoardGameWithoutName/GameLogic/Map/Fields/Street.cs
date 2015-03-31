namespace GameLogic.Map.Fields
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GameLogic.Game;
    using GameLogic.Map;

    public class Street : Field
    {
        public StreetBuilding building;

        public Street(string name, Neighbourhood neighbourhood, int row, int column)
            : base(name, neighbourhood.Color, row, column)
        {
           neighbourhood.Streets.Add(this);
        }

        public Player Owner { get; set; }

        public Neighbourhood Neighbourhood { get; private set; }

        public int Price { get; set; }

        public int Rent { get; set; }
    }
}
