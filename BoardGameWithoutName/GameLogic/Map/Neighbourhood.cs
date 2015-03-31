namespace GameLogic.Map
{
    using GameLogic.Game;
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
            this.Streets = new List<Street>();
        }

        internal List<Street> Streets {get; set;}

        public Player Owner
        {
            get
            {
                var owners=Streets.Select(street => street.Owner);
                var ownerFirst = owners.ElementAt(0);
                foreach (var owner in owners)
                {
                    if (owner != ownerFirst) return null;
                }
                return ownerFirst;
            }
        }

        public Color Color { get; set; }

        public string Name { get; set; }
    }
}
