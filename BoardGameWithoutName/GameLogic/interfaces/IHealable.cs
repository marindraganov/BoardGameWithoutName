using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Interfaces
{
    interface IHealable
    {
        int HealthStatus { get; }

        void Heal(int health);
    }
}
