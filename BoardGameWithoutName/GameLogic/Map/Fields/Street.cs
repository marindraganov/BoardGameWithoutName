namespace GameLogic.Map.Fields
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using GameLogic.Game;
    using GameLogic.GlobalConst;
    using GameLogic.Interfaces;
    using GameLogic.Map;

    public class Street : Field //, IBuyable
    {
        public Street(string name, Neighbourhood neighbourhood, int row, int column)
            : base(name, neighbourhood.Color, row, column)
        {
           neighbourhood.Streets.Add(this);
        }

        public Street(string name, Neighbourhood neighbourhood, int row, int column, int price)
            : this(name, neighbourhood, row, column)
        {
            this.Price = price;
        }

        public StreetBuilding Building { get; private set; }

        public int BuildingPrice
        {
            get
            {
                return this.PriceOfNextBuilding(this.Price);
            }
        }

        public Player Owner { get; set; }

        public Neighbourhood Neighbourhood { get; private set; }

        public int Price { get; private set; }

        public int Rent { get; private set; }

        public int PriceOfNextBuilding(int streetPrice)
        {
            if (this.Building == null)
            {
                return (int)(streetPrice * GlobalConst.HousePriceCoefficient);
            }
            else if (this.Building.Type == TypeOfBuilding.House)
            {
                return (int)(streetPrice * GlobalConst.HotelPriceCoefficient);
            }
            else if (this.Building.Type == TypeOfBuilding.Hotel)
            {
                return (int)(streetPrice * GlobalConst.PalacePriceCoefficient);
            }

            return 0;
        }

        internal void Build()
        {
            if (this.Building == null)
            {
                this.Building = new StreetBuilding();
            }
            else
            {
                this.Building.Update();
            }
        }

        internal void HitBuilding(int damage)
        {
            if (this.Building.Stability <= damage)
            {
                this.Building = null;
            }
            else
            {
                this.Building.Stability -= damage;
            }
        }
    }
}
