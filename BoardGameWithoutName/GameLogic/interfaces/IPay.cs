using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Interfaces
{
    public interface IPay
    {
        int Money { get; }

        void Pay(int amount);
    }
}
