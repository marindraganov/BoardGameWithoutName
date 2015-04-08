namespace GameLogic.Map.Fields.Institutions
{
    using GameLogic.Interfaces;

    public class CreditOffer : Offer
    {
        private ITakeCredit creditTaker;

        public CreditOffer(string instituionName, Credit credit, ITakeCredit creditTaker)
            : base(instituionName)
        {
            this.creditTaker = creditTaker;
            this.Credit = credit;
        }

        public Credit Credit { get; set; }

        public override void Accept()
        {
            if (this.IsValid)
            {
                 this.IsValid = false;
                 this.creditTaker.Credits.Add(this.Credit);
                 this.creditTaker.TakePayment(this.Credit.Amount); 
            }
        }
    }
}