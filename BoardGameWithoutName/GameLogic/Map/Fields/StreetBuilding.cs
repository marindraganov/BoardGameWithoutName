namespace GameLogic.Map.Fields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StreetBuilding
    {

        private string nameBuilding;

        private StreetBuilding()
        {

        }

        public string NameBuilding
        {
            get
            {
                return this.nameBuilding;
            }
            private set
            {
                this.nameBuilding = value;
            }
        }
    }
}