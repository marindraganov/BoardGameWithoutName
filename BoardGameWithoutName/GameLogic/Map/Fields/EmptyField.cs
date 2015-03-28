namespace GameLogic.Map.Fields
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    // this field do not offer any actions to players
    class EmptyField : Field
    {
        public EmptyField(string name, Color color, int pos)
            : base(name, color, pos)
        {
        }
    }
}
