using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace FillTheField
{
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down,
        None
    }
    public class Player : GameObject
    {
        public bool InMove { get; set; } = false;
        public Point StartPos;
        private double _currentX = 0;
        private double _currentY = 0;

        public event EventHandler<PlayerPositionArgs> ChangedPosition;
        public event EventHandler OnDefeatOrVictoryCheck;
        public Player(Point position) : base(position)
        {
            StartPos = position;
            Object.Fill = (Brush)new BrushConverter().ConvertFromString("#8E48D4");
            Object.Name = "Player";
            Object.StrokeThickness = 10;
            Object.Stroke = (Brush)new BrushConverter().ConvertFromString("#8E48B0");
        }

        public void Reset()
        {
            _position = StartPos;
            _currentX = 0;
            _currentY = 0;
            var transform = new TranslateTransform();
            transform.X = _currentX;
            transform.Y = _currentY;
            Object.RenderTransform = transform;
        }
        public async void MoveAsync(float dist,Direction dir)
        {
            var transform = new TranslateTransform();
            transform.X = _currentX;
            transform.Y = _currentY;
            Object.RenderTransform = transform;

            if (dist == 0)
            {
                return;
            }
            InMove = true;

            var k = (sbyte)(dist / Math.Abs(dist));
            float counter = 0;
            float time = 0.2f;
            float speed = dist / time / 60.0f;
            float elapsed = 1.0f / 60.0f;
            float path = dir == Direction.Left || dir == Direction.Right ?
                (float)GameObject.ObjectWidth : (float)GameObject.ObjectHeight;

            while (time >= elapsed && InMove)
            {
                if (dir == Direction.Right || dir == Direction.Left)
                {
                    transform.X -= speed;
                }
                else
                {
                    transform.Y -= speed;
                }

                counter += Math.Abs(speed);
                time -= elapsed;
                if (counter >= path)
                {
                    counter -= path;
                    
                    if (dir == Direction.Right || dir == Direction.Left)
                    {
                        _position.x -= k;
                    }
                    else
                    {
                        _position.y -= k;
                    }
                    ChangedPosition?.Invoke(this, new PlayerPositionArgs(this.Position));
                }
                _currentX = transform.X;
                _currentY = transform.Y;
                await Task.Delay(16);
            }
            OnDefeatOrVictoryCheck?.Invoke(this, null);
            InMove = false;
        }
    }
}
