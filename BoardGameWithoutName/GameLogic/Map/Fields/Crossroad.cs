namespace GameLogic.Map.Fields
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Crossroad : Field
    {
        public Crossroad(string name, Color color, int row, int col)
            : base(name, color, row, col)
        {
        }
    }
}
