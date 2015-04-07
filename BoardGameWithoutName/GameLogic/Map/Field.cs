namespace GameLogic.Map
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;

    using GameLogic.Game;
    using System.ComponentModel;

    public abstract class Field : INotifyPropertyChanged
    {
        private bool canBePath;
        private string can ="not";

        public Field(string name, Color color, int row, int column)
        {
            this.Name = name;
            this.Color = color;
            this.Row = row;
            this.Column = column;

            this.NextFields = new List<Field>();
            this.PrevFields = new List<Field>();
            this.Players = new List<Player>();
            this.CanBePath = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Field> NextFields { get; internal set; }

        public List<Field> PrevFields { get; internal set; }

        public Color Color { get; private set; }

        public string Name { get; private set; }

        public List<Player> Players { get; internal set; }

        public int Row { get; private set; }

        public int Column { get; private set; }

        public bool CanBePath
        {
            get
            {
                return this.canBePath;
            }

            internal set
            {
                this.canBePath = value;
                this.OnPropertyChanged("CanBePath");
            }
        }

        public string Can
        {

            get
            {
                return this.can;
            }

            internal set
            {
                this.can = value;
                this.OnPropertyChanged(null);
            }
        }

        internal void Visit(Player player)
        {
            this.Players.Add(player);
        }

        internal void Leave(Player player)
        {
            this.Players.Remove(player);
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}