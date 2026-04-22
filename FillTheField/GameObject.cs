using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FillTheField
{
    public abstract class GameObject
    {
        private static double _objectWidth;
        private static double _objectHeight;

        public static double ObjectWidth => _objectWidth;
        public static double ObjectHeight => _objectHeight;

        private Rectangle _object;
        public Rectangle Object => _object;

        protected Point _position;
        public Point Position => _position;

        public GameObject(Point position)
        {
            _object = new Rectangle() { Width = _objectWidth, Height = _objectHeight, SnapsToDevicePixels = true };
            _position = position;
            Grid.SetColumn(_object, position.x);
            Grid.SetRow(_object, position.y);
        }

        public static void SetObjectSize(double width,double height)
        {
            _objectHeight = height;
            _objectWidth = width;
        }
    }
}
