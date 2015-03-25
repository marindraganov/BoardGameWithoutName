namespace GameLogic.Map
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;

    public abstract class Field
    {
        public Field(string name, Color color)
        {
            this.Name = name;
            this.Color = color;
        }

        public Color Color { get; private set; }

        public string Name { get; private set; }
    }
}