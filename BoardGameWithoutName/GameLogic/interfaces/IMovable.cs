using GameLogic.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Interfaces
{
    public interface IMovable
    {
        Field Field { get; }

        void MoveTo(Field target);
    }
}
