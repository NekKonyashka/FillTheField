using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillTheField
{
    internal class PlayerTrackCreator : Creator
    {
        public override GameObject CreateGameObject(Point position)
        {
            return new PlayerTrack(position);
        }
    }
}
