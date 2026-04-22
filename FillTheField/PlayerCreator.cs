using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillTheField
{
    public class PlayerCreator : Creator
    {
        public override Player CreateGameObject(Point position) => new Player(position);
    }
}
