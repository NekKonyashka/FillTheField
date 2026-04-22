using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillTheField
{
    public interface ICreator
    {
        GameObject CreateGameObject(Point position);
    }
}
