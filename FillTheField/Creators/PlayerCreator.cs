using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillTheField
{
    public class PlayerCreator : ICreator
    {
        public GameObject CreateGameObject(Point position) => new Player(position);

    }
}
