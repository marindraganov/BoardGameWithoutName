namespace GameLogic.Map.Fields
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using GameLogic.Map;

    public class Street : Field
    {
        private StreetBuilding building;

        public Street(string name, Neighbourhood neighbourhood, int row, int column)
            : base(name, neighbourhood.Color, row, column)
        {
            neighbourhood.Streets.Add(this);
        }

        public Neighbourhood Neighbouhood { get; private set; }
    }
}
