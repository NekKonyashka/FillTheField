using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillTheField
{
    internal class PlayerTrackCreator : ICreator
    {
        public GameObject CreateGameObject(Point position) => new PlayerTrack(position);

    }
}
