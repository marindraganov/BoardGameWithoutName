namespace GameLogic.Game
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Text;
   
    using GameLogic.GlobalConst;
    using GameLogic.Interfaces;
    using GameLogic.Map;
    using GameLogic.Map.Fields;

    public class Player : INotifyPropertyChanged
    {
        public static readonly Color[] Colors =
            new[] { Color.DarkCyan, Color.DarkSalmon, Color.DarkKhaki, Color.DarkSlateBlue, Color.Purple, Color.Gray };

        private Field field;
        private int healthStatus;
        private int moneyStatus; 
   
        internal Player(string namePlayer, Field field, Color color)
        {
            this.HealthStatus = GlobalConst.InitialHealth;
            this.Money = GlobalConst.InitialMoney;

            this.Field = field;
            this.Name = namePlayer;
            this.Color = color;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Field Field
        {
            get
            {
                return this.field;
            }
            // TODO private after movement is implemented
            set
            {
                this.field = value;
                this.OnPropertyChanged(null);
            }
        }

        public int Money { get; private set; }

        public int HealthStatus
        {
            get
            {
                return this.healthStatus;
            }

            private set
            {
                this.healthStatus = value;
                this.OnPropertyChanged(null);
            }
        }

        public string Name { get; private set; }

        public Color Color { get; private set; }

        public void TakeHealth(int value)
        {
            this.HealthStatus -= value;
            
            if (this.HealthStatus < 10)
            {
                this.HealthStatus = 10;
            }
        }

        internal void MoveTo(Field targetField)
        {
            this.Field.Leave(this);
            this.Field = targetField;
            targetField.Visit(this);

            //  if (targetField is Street) 
            //  {
            //    var streetStepOn = targetField as Street;
            //    if (streetStepOn.Owner != null && streetStepOn.Owner!=this) 
            //    {
            //        PayRent(streetStepOn);
            //    }
            //    else if (streetStepOn.Neighbourhood.Owner ==this) 
            //    {
            //        BuildHouse(streetStepOn);
            //    }
            //    else
            //    {
            //        Buy(streetStepOn.Price);
            //    }
            //  }
        }

        internal void BuyStreeet()
        {
            if (this.Field is Street)
            {
                Street street = this.Field as Street;

                if (this.Money >= street.Price && street.Owner == null)
                {
                    this.Money -= street.Price;
                    street.Owner = this;
                }
            }
        }

        internal void Build(Street street)
        {
            if (this == street.Neighbourhood.Owner &&
                this.Money >= street.BuildingPrice)
            {
                this.Money -= street.BuildingPrice;
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void PayRent(Street currentStreet)
        {
            currentStreet.Owner.moneyStatus += currentStreet.Rent;
            this.Money = this.Money - currentStreet.Rent;
        }
    }
}
