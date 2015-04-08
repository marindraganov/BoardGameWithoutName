namespace GameLogic.Map.Fields.Institutions
{
    using GameLogic.Interfaces;

    public class CreditOffer : Offer
    {
        private ITakeCredit creditTaker;

        public CreditOffer(Credit credit, ITakeCredit creditTaker)
            : base()
        {
            this.creditTaker = creditTaker;
            this.Credit = credit;
        }

        public Credit Credit { get; set; }

        public override void Accept()
        {
            if (this.isValid)
            {
                 this.creditTaker.TakePayment(this.Credit.Amount);
                 this.creditTaker.Credits.Add(this.Credit);
                 this.isValid = false;
            }
        }
    }
}