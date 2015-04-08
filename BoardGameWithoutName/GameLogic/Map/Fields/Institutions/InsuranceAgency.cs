namespace GameLogic.Map.Fields.Institutions
{
    using System.Drawing;

    using GameLogic.Interfaces;
    using GameLogic.Map;
    
    public abstract class InsuranceAgency : Field, IMakeOffer
    {
        public InsuranceAgency(string name, Color color, int row, int col)
            : base(name, color, row, col)
        {
        }

        public void MakeOffer(ITakeOffer offerReciever)
        {
            if (offerReciever is ITakeInsurance)
            {
                offerReciever.Offer = this.CreateInsuranceOffer(offerReciever as ITakeInsurance);
            }
        }

        protected abstract Offer CreateInsuranceOffer(ITakeInsurance takeInsurance);
    }
}
