namespace GameLogic.Map.Fields.Institutions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Offer 
    {
        protected bool isValid;

        public Offer()
        {
            this.isValid = true;
        }

        public abstract void Accept();
    }
}
