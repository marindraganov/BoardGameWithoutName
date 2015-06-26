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
    using System.ComponentModel;

    public class Street : Field
    {
        private Player owner;
        private StreetBuilding building;

        public Street(string name, Neighbourhood neighbourhood, int row, int column, int price)
            : base(name, neighbourhood.Color, row, column)
        {
            this.Price = price;
            neighbourhood.Streets.Add(this);
            this.Neighbourhood = neighbourhood;
        }

        public StreetBuilding Building 
        {
            get
            {
                return this.building;
            }

            private set
            {
                this.building = value;
                OnPropertyChanged(null);
            }
        }

        public bool ActionPerTurnIsMade { get; private set; }

        public int BuildingPrice
        {
            get
            {
                return this.PriceOfNextBuilding();
            }
        }

        public Player Owner
        {
            get
            { 
                return this.owner; 
            }
            set
            {
                this.owner = value;
                this.ActionPerTurnIsMade = true;
                OnPropertyChanged(null);
            }
        }

        public Neighbourhood Neighbourhood { get; private set; }

        public int Price { get; private set; }

        public int Rent
        {
            get
            {
                return CalculateRent();
            }
        }

        public void Rapair()
        {
            if (this.building == null || this.building.Stability >= 100
                || this.owner.Money < this.RepairPrice())
            {
                if (this.owner.Money < this.RepairPrice())
                {
                    GameMessages.Instance.LastMessage = "You do not have enought money to repair this buildig!";
                }

                return;
            }
            else
            {
                this.Building.Stability += 10;
                this.Owner.Pay(this.RepairPrice());
            }
        }

        public int RepairPrice()
        {
            if (this.Building == null || this.Building.Stability == 100)
            {
                return 0;
            }
            else if (this.Building.Type == TypeOfBuilding.House)
            {
                return (int)(this.Price * GlobalConst.HousePriceCoefficient * 0.6);
            }
            else if (this.Building.Type == TypeOfBuilding.Hotel)
            {
                return (int)(this.Price * GlobalConst.HotelPriceCoefficient * 0.6);
            }
            else if (this.Building.Type == TypeOfBuilding.Palace)
            {
                return (int)(this.Price * GlobalConst.HotelPriceCoefficient * 0.6);
            }

            return 0;
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
            this.ActionPerTurnIsMade = true;

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
            if (this.Building == null)
            {
                return;
            }

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
                    if (this.Owner != this.Neighbourhood.Owner)
                    {
                        return (int)(this.Price * 0.08);
                    }
                    else
                    {
                        return (int)(this.Price * 0.12);
                    }
                    
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

        internal void GetRent(IPay player)
        {
            player.Pay(this.Rent);
            this.Owner.TakePayment(this.Rent);

            string message = string.Format("{0} pay ${1} to {2} from {3} street.", player.Name, this.Rent, this.Owner.Name, this.Name);
            GameMessages.Instance.LastMessage = message;
        }
    }
}
