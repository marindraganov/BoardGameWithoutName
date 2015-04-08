namespace GameLogic.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using GameLogic.Map.Fields.Institutions;

    public interface IMakeOffer
    {
        void MakeOffer(ITakeOffer offerReciever);
    }
}
