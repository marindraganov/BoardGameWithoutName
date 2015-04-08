using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Interfaces
{
    interface IHealthDamageable : IHealth
    {
        void TakeHealth(int healthDamage);
    }
}
