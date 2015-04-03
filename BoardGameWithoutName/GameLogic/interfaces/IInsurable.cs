namespace GameLogic.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using GameLogic.Game;
    using GameLogic.Map.Fields;

    public interface IInsurable
    {
        public void CreatePlayerInsurance(Player player);

        public void CreateBuldingInsurance(StreetBuilding building);
    }
}
