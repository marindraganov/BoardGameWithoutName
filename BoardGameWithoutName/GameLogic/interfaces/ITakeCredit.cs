namespace GameLogic.Interfaces
{
    using System.Collections.Generic;

    using GameLogic.Map.Fields.Institutions;
    
    public interface ITakeCredit : IPay, IGetPayment
    {
        List<Credit> Credits { get; set; }

        void PayCredits();
    }
}
