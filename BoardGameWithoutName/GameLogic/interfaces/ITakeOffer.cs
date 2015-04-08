namespace GameLogic.Interfaces
{
    using System.Collections.Generic;

    using GameLogic.Map.Fields.Institutions;

    public interface ITakeOffer
    {
        Offer Offer { get; set; }
    }
}
