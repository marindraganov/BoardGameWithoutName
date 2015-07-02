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
    using GameLogic.Map.Fields.Institutions;

    public class Street : Field
    {
        private Player owner;
        private StreetBuilding building;
        private bool isDamaged;
        private bool isProtected;

        public Street(string name, Neighbourhood neighbourhood, int row, int column, int price)
            : base(name, neighbourhood.Color, row, column)
        {
            this.Price = price;
            neighbourhood.Streets.Add(this);
            this.Neighbourhood = neighbourhood;
            this.IsDamaged = false;
            this.IsProtected = false;
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

        public bool IsDamaged
        {
            get
            {
                return this.isDamaged;
            }

            private set
            {
                this.isDamaged= value;
                OnPropertyChanged(null);
            }
        }

        public bool IsProtected
        {
            get
            {
                return this.isProtected;
            }

            internal set
            {
                this.isProtected = value;
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
            if (this.Owner == null || !this.Owner.OnTheMove)
            {
                GameMessages.Instance.LastMessage = "You have to be owner of this street to be able to repair the building!";
                return;
            }

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

                if (this.Building.Stability >= 100)
                {
                    IsDamaged = false;
                }
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
                return (int)(this.Price * GlobalConst.HousePriceCoefficient * 0.06);
            }
            else if (this.Building.Type == TypeOfBuilding.Hotel)
            {
                return (int)(this.Price * GlobalConst.HotelPriceCoefficient * 0.06);
            }
            else if (this.Building.Type == TypeOfBuilding.Palace)
            {
                return (int)(this.Price * GlobalConst.PalacePriceCoefficient * 0.06);
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

            if (this.Owner == null || !this.Owner.OnTheMove)
            {
                GameMessages.Instance.LastMessage = "You have to be owner of this street to be able to build and upgrade!";
            }

            if (this.Owner.Money < this.BuildingPrice)
            {
                GameMessages.Instance.LastMessage = "You do not have enough money to update the property!";
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
            if (this.Building == null || this.IsProtected)
            {
                return;
            }

            if (this.Building.Stability <= damage)
            {
                this.Building = null;
                this.IsDamaged = false;
            }
            else
            {
                this.Building.Stability -= damage;

                if (this.Building.Stability < 100)
                {
                    this.IsDamaged = true;
                }
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

        internal void UpdateProtectionStatus()
        {
            bool isProtected = false;

            if (this.Owner != null)
            {
                foreach (var insurance in this.Owner.Insurances)
                {
                    if (insurance.Type == InsuranceType.Property)
                    {
                        isProtected = true;
                    }
                }
            }

            this.IsProtected = isProtected;
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
