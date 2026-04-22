using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillTheField
{
    public abstract class Creator
    {
        public abstract GameObject CreateGameObject(Point position);
    }
}
