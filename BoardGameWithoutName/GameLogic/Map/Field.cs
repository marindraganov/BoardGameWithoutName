namespace GameLogic.Map
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;

    using GameLogic.Game;

    public abstract class Field
    {
        public Field(string name, Color color, int row, int column)
        {
            this.Name = name;
            this.Color = color;
            this.Row = row;
            this.Column = column;

            this.NextFields = new List<Field>();
            this.Players = new List<Player>();
        }

        public virtual List<Field> NextFields { get; internal set; }

        public Color Color { get; private set; }

        public string Name { get; private set; }

        public List<Player> Players { get; internal set; }

        internal void Visit(Player player)
        {
            this.Players.Add(player);
        }

        internal void Leave(Player player)
        {
            this.Players.Remove(player);
        }

        public int Row { get; private set; }

        public int Column { get; private set; }
    }
}