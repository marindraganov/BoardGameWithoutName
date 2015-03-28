namespace GameLogic.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Game;
    using Map.Fields;
    interface IInsurable
    {
        public void createPlayerInsurance(Player player);

        public void createBuldingInsurance(StreetBuilding building);

    }
}
