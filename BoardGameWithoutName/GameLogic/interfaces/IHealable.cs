namespace GameLogic.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IHealable
    {
        int HealthStatus { get; }

        void Heal(int health);
    }
}
