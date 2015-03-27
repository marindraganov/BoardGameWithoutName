namespace GameLogic.Map
{
    using GameLogic.Map.Fields;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Neighbourhood
    {
        public Neighbourhood(string name, Color color)
        {
            this.Name = name;
            this.Color = color;
        }

        internal List<Street> Streets { get; set; }

        public Color Color { get; set; }

        public string Name { get; set; }
    }
}
