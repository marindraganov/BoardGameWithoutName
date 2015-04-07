using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Map.Fields
{
    class Hospital : Field
    {
        public Hospital(string name, Color color, int row, int col)
            : base(name, color, row, col)
        {
        }
    }
}
