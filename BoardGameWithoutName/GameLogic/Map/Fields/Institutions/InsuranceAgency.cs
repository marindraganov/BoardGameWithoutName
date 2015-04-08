namespace GameLogic.Map.Fields.Institutions
{
    using System.Drawing;

    using GameLogic.Map;
    using GameLogic.Interfaces;
    
    public abstract class InsuranceAgency : Field, IMakeOffer
    {
        public InsuranceAgency(string name, Color color, int row, int col)
            : base(name, color, row, col)
        {
        }

        //public abstract void MakeOffer(ITakeInsuranceOffer offerReciever);

        public void MakeOffer(ITakeOffer offerReciever)
        {
            if (offerReciever is ITakeInsurance)
            {
                offerReciever.Offer = CreateInsuranceOffer(offerReciever as ITakeInsurance);
            }
        }

        protected abstract Offer CreateInsuranceOffer(ITakeInsurance takeInsurance);
    }
}
