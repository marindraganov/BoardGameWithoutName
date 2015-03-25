namespace GameLogic.Map.Fields
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Street : Field
    {
        private StreetBuilding building;

        public Street(string name, Color color)
            : base(name, color)
        {
        }

        public Neighbourhood Neighbouhood { get; private set; }
    }
}
