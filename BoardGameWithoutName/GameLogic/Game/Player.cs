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

    public class Player : INotifyPropertyChanged, IMovable, IHealthDamageable, ITakeInsurance, ITakeCredit, ITakeOffer, IHealable
    {
        public static readonly Color[] Colors =
            new[] { Color.Red, Color.Gold, Color.CornflowerBlue, Color.Chartreuse, Color.DarkOrchid, Color.Gray, Color.Yellow };

        private Field field;
        private Offer offer;
        private int healthStatus;
        private int money;
        private bool isInsured;
   
        internal Player(string namePlayer, Field field, Color color)
        {
            this.HealthStatus = GlobalConst.InitialHealth;
            this.Money = GlobalConst.InitialMoney;
            this.Insurances = new List<Insurance>();
            this.Credits = new List<Credit>();

            this.Field = field;
            field.Visit(this);
            this.Name = namePlayer;
            this.Color = color;
            this.IsInsured = false;
            this.IsInTheGame = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Field Field
        {
            get
            {
                return this.field;
            }

            private set
            {
                this.field = value;
                this.OnPropertyChanged(null);
            }
        }

        public bool IsInTheGame { get; internal set; }

        public int Money
        {
            get
            {
                return this.money;
            }

            private set
            {
                this.money = value;
                this.OnPropertyChanged(null);
            }
        }

        public int Credit 
        {
            get
            {
                int sum = 0;

                foreach (var credit in this.Credits)
                {
                    sum += credit.Amount * credit.PaymentsRemainig;
                }

                return sum;
            }
        }

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

        public bool OnTheMove { get; internal set; }

        public Color Color { get; private set; }

        public List<Credit> Credits { get; set; }

        public List<Insurance> Insurances { get; private set; }

        public Offer Offer 
        { 
            get
            {
                return this.offer;
            }

            set
            {
                this.offer = value;
                this.OnPropertyChanged(null);
            }
        }

        public bool IsInsured
        {
            get
            {
                return this.isInsured;
            }

            set
            {
                this.isInsured = value;
                this.OnPropertyChanged(null);
            }
        }

        public void TakeHealth(int value)
        {
            if (this.IsInsured)
            {
                return;
            }

            this.HealthStatus -= value;
            
            if (this.HealthStatus < 10)
            {
                this.HealthStatus = 10;
            }
        }

        public void MoveTo(Field targetField)
        {
            if (GameMap.PathContainsStart(this.Field, targetField))
            {
                this.TakePayment(GlobalConst.StartReward);
                this.ReduceInsurancesPeriodBy(1);
                this.PayCredits();

                if (this.Money < 0)
                {
                    this.IsInTheGame = false;
                    GameMessages.Instance.LastMessage = 
                        string.Format(
                        "{0} is out of the game because his/her money balance was negative when pass through the start!",
                        this.Name);
                }
            }

            this.Heal();

            this.Field.Leave(this);
            this.Field = targetField;
            targetField.Visit(this);
        }

        public void Heal(int health)
        {
            if (health < 0)
            {
                return;
            }

            this.HealthStatus += health;
        }

        public void Pay(int amount)
        {
            this.Money -= amount;
        }

        public void TakePayment(int amount)
        {
            this.Money += amount;
        }

        public void AddInsurance(Insurance insurance)
        {
            this.Insurances.Add(insurance);
        }

        public void ReduceInsurancesPeriodBy(int value)
        {
            for (int i = this.Insurances.Count - 1; i >= 0; i--)
            {
                var insurance = this.Insurances[i];

                insurance.ValidityRemaining -= value;

                if (insurance.ValidityRemaining <= 0)
                {
                    this.Insurances.Remove(insurance);
                }
            }
        }

        public void PayCredits()
        {
            for (int i = this.Credits.Count - 1; i >= 0; i--)
            {
                var credit = this.Credits[i];

                this.Money -= credit.PaymentAmount;
                credit.PaymentsRemainig--;

                if (credit.PaymentsRemainig == 0)
                {
                    this.Credits.Remove(credit);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("Name: {0}", this.Name);
            builder.AppendLine();
            builder.AppendFormat("Money: {0}", this.Money);
            builder.AppendLine();
            builder.AppendFormat("Credit: {0}", this.Credit);

            return builder.ToString();
        }

        public void BuyStreeet(Street street)
        {
            if (this.Field is Street && this.Field == street)
            {
                if (this.Money >= street.Price && street.Owner == null)
                {
                    this.Pay(street.Price);
                    street.Owner = this;
                }
                else
                {
                    GameMessages.Instance.LastMessage = "You don't have enough money!";
                }
            }
        }

        public void Build(Street street)
        {
            if ////(this == street.Neighbourhood.Owner && TODO may be :)
                (this.Money >= street.BuildingPrice)
            {
                street.Build();
            }
            else
            {
                GameMessages.Instance.LastMessage = "You don't have enough money!";
            }
        }

        internal void UpdateInsuraneceStatus()
        {
            bool insured = false;

            foreach (var insurance in this.Insurances)
            {
                if (insurance.Type == InsuranceType.Health)
                {
                    insured = true;
                }
            }

            this.IsInsured = insured;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void Heal()
        {
            if (this.HealthStatus < 100)
            {
                this.HealthStatus += 10;
            }
        }
    }
}
