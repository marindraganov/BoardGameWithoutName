namespace GameLogic.Interfaces
{
    using System.Collections.Generic;

    using GameLogic.Game;
    using GameLogic.Map.Fields;
    using GameLogic.Map.Fields.Institutions;  

    public interface ITakeInsurance : IPay
    {
        List<Insurance> Insurances { get; }

        void AddInsurance(Insurance insurance);

        void ReduceInsurancesPeriodBy(int value);
    }
}
