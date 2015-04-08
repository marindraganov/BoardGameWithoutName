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
    using GameLogic.Map.Fields.Institutions;

    public class Player : INotifyPropertyChanged, IMovable, IHealthDamageable, ITakeInsurance, ITakeCredit, ITakeOffer
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
            this.Credit = 0;
            this.Insurances = new List<Insurance>();
            this.Credits = new List<Credit>();

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

        public int Credit { get; private set; }

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

        public List<Credit> Credits { get; set; }

        public List<Insurance> Insurances { get; private set; }

        public Offer Offer { get; set; }

        public void TakeHealth(int value)
        {
            this.HealthStatus -= value;
            
            if (this.HealthStatus < 10)
            {
                this.HealthStatus = 10;
            }
        }

        public void MoveTo(Field targetField)
        {
            this.Field.Leave(this);
            this.Field = targetField;
            targetField.Visit(this);
        }

        public void Pay(int amount)
        {
            this.moneyStatus -= amount;
        }

        public void TakePayment(int amount)
        {
            this.moneyStatus -= amount;
        }

        public void AddInsurance(Insurance insurance)
        {
            this.Insurances.Add(insurance);
        }

        public void ReduceInsurancesPeriodBy(int value)
        {
            foreach (var insurance in this.Insurances)
            {
                insurance.ValidityRemaining -= value;

                if (insurance.ValidityRemaining <= 0)
                {
                    this.Insurances.Remove(insurance);
                }
            }
        }

        public void PayCredits()
        {
            foreach (var credit in this.Credits)
            {
                this.Money -= credit.PaymentAmount;
                credit.PaymentsRemainig--;
            }
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
    }
}
