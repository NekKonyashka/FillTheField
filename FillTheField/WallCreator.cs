using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillTheField
{
    public class WallCreator : Creator
    {
        public override Wall CreateGameObject(Point position) => new Wall(position);
    }
}
