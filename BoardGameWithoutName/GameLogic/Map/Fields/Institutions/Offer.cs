namespace GameLogic.Map.Fields.Institutions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Offer 
    {
        public Offer(string institution)
        {
            this.Institution = institution;
            this.IsValid = true;
        }

        public bool IsValid { get; protected set; }

        public string Institution { get; private set; }

        public abstract void Accept();

        public void Deny()
        {
            this.IsValid = false;
        }
    }
}
