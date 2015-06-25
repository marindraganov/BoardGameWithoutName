﻿namespace GameLogic.Map.Fields
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

    public class Street : Field // , IBuyable
    {
        public Street(string name, Neighbourhood neighbourhood, int row, int column, int price)
            : base(name, neighbourhood.Color, row, column)
        {
            this.Price = price;
            neighbourhood.Streets.Add(this);
        }

        public StreetBuilding Building { get; private set; }

        public int BuildingPrice
        {
            get
            {
                return this.PriceOfNextBuilding();
            }
        }

        public Player Owner { get; set; }

        public Neighbourhood Neighbourhood { get; private set; }

        public int Price { get; private set; }

        public int Rent
        {
            get
            {
                return CalculateRent();
            }
        }

        public int PriceOfNextBuilding()
        {
            if (this.Building == null)
            {
                if (this.Owner == null)
                {
                    return 0;
                }

                return (int)(this.Price * GlobalConst.HousePriceCoefficient);
            }
            else if (this.Building.Type == TypeOfBuilding.House)
            {
                return (int)(this.Price * GlobalConst.HotelPriceCoefficient);
            }
            else if (this.Building.Type == TypeOfBuilding.Hotel)
            {
                return (int)(this.Price * GlobalConst.PalacePriceCoefficient);
            }

            return 0;
        }

        internal void Build()
        {
            if (this.Owner.Money < this.BuildingPrice)
            {
                return;
            }

            if (this.Building == null)
            {
                this.Owner.Pay(this.BuildingPrice);
                this.Building = new StreetBuilding();
            }
            else
            {
                if (this.Building.Type == TypeOfBuilding.Palace)
                {
                    GameMessages.Instance.LastMessage = "The palace is the most advanced building you can build.";
                    return;
                }

                this.Owner.Pay(this.BuildingPrice);
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
        
        private int CalculateRent()
        {
            if (this.Owner == null)
            {
                return 0;
            }
            else
            {
                if (this.Building == null)
                {
                    return (int)(this.Price * 0.1);
                }
                else if (this.Building.Type == TypeOfBuilding.House)
                {
                    return (int)(this.Price * 0.3);
                }
                else if (this.Building.Type == TypeOfBuilding.Hotel)
                {
                    return (int)(this.Price * 0.65);
                }
                else if (this.Building.Type == TypeOfBuilding.Palace)
                {
                    return (int)(this.Price * 1.1);
                }
                else
                {
                    return 0;
                }
            }
        }

        internal void GetRent(Player player)
        {
            player.Pay(this.Rent);
            this.Owner.TakePayment(this.Rent);

            string message = string.Format("{0} pay ${1} to from {2} street.", player.Name, this.Owner.Name, this.Rent);
            GameMessages.Instance.LastMessage = message;
        }
    }
}
