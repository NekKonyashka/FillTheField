using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FillTheField
{
    public class Wall : GameObject
    {
        public Wall(Point position) : base(position)
        {
            Object.Fill = (Brush)new BrushConverter().ConvertFromString("#FF4B4B4B");
        }
    }
}
