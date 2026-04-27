using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace FillTheField
{
    internal class PlayerTrack : GameObject
    {
        public PlayerTrack(Point position) : base(position)
        {
            Object.Fill = (Brush)new BrushConverter().ConvertFromString("#8E48D4");
            Panel.SetZIndex(Object, -1);
        }
    }
}
