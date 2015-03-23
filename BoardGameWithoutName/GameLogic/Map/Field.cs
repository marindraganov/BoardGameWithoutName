namespace GameLogic.MapElements
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    
    public abstract class Field
    {
        public readonly Color Color;
        List<NextField> nextFields;
    }
}
