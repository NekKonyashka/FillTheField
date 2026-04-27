using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FillTheField
{
    public class GameManeger
    {
        private SoundPlayer _soundPlayer = new SoundPlayer("./res/0aa11347485b7a0.wav");
        private MainWindow _window;
        private LevelFactory _factory;
        private Player _player;
        private Grid _grid;
        private Queue<Level> _levels;

        public GameManeger(MainWindow window)
        {
            _window = window;
            _grid = window.MyGrid;
            _factory = new LevelFactory(new WallCreator(), new PlayerCreator());
            _levels = new Queue<Level>();
        }
        public void Move(Key key)
        {
            if (_player.InMove)
            {
                return;
            }
            var tempPoint = _player.Position;
            float dist = 0;
            Direction dir = Direction.None;
            switch (key)
            {
                case Key.W:
                    {
                        dir = Direction.Up;
                        dist = -(float)GameObject.ObjectHeight;
                        do
                        {
                            --tempPoint.y;
                            dist += (float)GameObject.ObjectHeight;
                        } while (!IsCollider(tempPoint) && tempPoint.y > -1);
                        break;
                    }
                case Key.A:
                    {
                        dir = Direction.Left;
                        dist = -(float)GameObject.ObjectWidth;
                        do
                        {
                            --tempPoint.x;
                            dist += (float)GameObject.ObjectWidth;
                        } while (!IsCollider(tempPoint) && tempPoint.x > -1);
                        break;
                    }
                case Key.D:
                    {
                        dir = Direction.Right;
                        dist = (float)GameObject.ObjectWidth;
                        do
                        {
                            ++tempPoint.x;
                            dist -= (float)GameObject.ObjectWidth;
                        } while (!IsCollider(tempPoint) && tempPoint.x < _grid.RowDefinitions.Count);
                        break;
                    }
                case Key.S:
                    {
                        dir = Direction.Down;
                        dist = (float)GameObject.ObjectHeight;
                        do
                        {
                            ++tempPoint.y;
                            dist -= (float)GameObject.ObjectHeight;
                        } while (!IsCollider(tempPoint) && tempPoint.y < _grid.ColumnDefinitions.Count);
                        break;
                    }
            }
            if(dist == 0 || dir == Direction.None)
            {
                return;
            }
            _soundPlayer.Play();
            _player.MoveAsync(dist, dir);
        }
        public bool IsCollider(Point pos)
        {
            foreach (Rectangle item in _grid.Children.OfType<Rectangle>())
            {
                if (item.Name == "Player")
                {
                    continue;
                }

                int row = Grid.GetRow(item);
                int column = Grid.GetColumn(item);

                if (pos.y == row && pos.x == column)
                {
                    return true;
                }
            }
            return false;
        }



        public void LoadLevels()
        {
            _levels.Enqueue(_factory.Level1());
            _levels.Enqueue(_factory.Level2());
            _levels.Enqueue(_factory.Level3());
            _levels.Enqueue(_factory.Level4());
            _levels.Enqueue(_factory.Level5());
            _levels.Enqueue(_factory.Level6());
            _levels.Enqueue(_factory.Level7());
            _levels.Enqueue(_factory.Level8());
            _levels.Enqueue(_factory.Level9());
            _levels.Enqueue(_factory.Level10());
            _levels.Enqueue(_factory.Level11());
            _levels.Enqueue(_factory.Level12());
            _levels.Enqueue(_factory.Level13());
            _levels.Enqueue(_factory.Level14());
            _levels.Enqueue(_factory.Level15());
            _levels.Enqueue(_factory.Level16());
            _levels.Enqueue(_factory.Level17());
            _levels.Enqueue(_factory.Level18());
            _levels.Enqueue(_factory.Level19());
            _levels.Enqueue(_factory.Level20());
            _levels.Enqueue(_factory.Level21());
            _levels.Enqueue(_factory.Level22());
            _levels.Enqueue(_factory.Level23());
            _levels.Enqueue(_factory.Level24());
            _levels.Enqueue(_factory.Level25());
        }

        public void ConstructLevel()
        {
            _grid.Children.Clear();
            var currentLevel = _levels.Peek();
            foreach (var obj in currentLevel.Content)
            {
                _grid.Children.Add(obj.Object);
            }
            _player = currentLevel.Content.OfType<Player>().FirstOrDefault();
            Player_ChangedPosition(this, new PlayerPositionArgs(_player.Position));
            _player.ChangedPosition += Player_ChangedPosition;
            _player.OnDefeatOrVictoryCheck += Player_OnDefeatOrVictoryCheck;
        }
        public void RestartLevel()
        {
            _grid.Children.Clear();
            _player.InMove = false;
            var currentLevel = _levels.Peek();
            _player.Reset();
            foreach (var obj in currentLevel.Content)
            {
                _grid.Children.Add(obj.Object);
            }
            Player_ChangedPosition(this, new PlayerPositionArgs(_player.Position));
        }

        private void Player_OnDefeatOrVictoryCheck(object? sender, EventArgs e)
        {
            if (_grid.Children.OfType<Rectangle>().Count() == 37)
            {
                _levels.Dequeue();
                _window.Win();
                return;
            }
            (sbyte x, sbyte y)[] directions = { (0, 1), (0, -1), (-1, 0), (1, 0) };

            foreach (var direction in directions)
            {
                var temp_pos = new Point() { 
                    x = (sbyte)(_player.Position.x + direction.x),
                    y = (sbyte)(_player.Position.y + direction.y) 
                };

                if (!IsCollider(temp_pos) && temp_pos.y >= 0 &&
                    temp_pos.y < _grid.RowDefinitions.Count &&
                    temp_pos.x >= 0 && temp_pos.x < _grid.ColumnDefinitions.Count)
                {
                    return;
                }
            }
            _window.Defeat();
        }


        private void Player_ChangedPosition(object? sender, PlayerPositionArgs e)
        {
            var trackcr = new PlayerTrackCreator();
            _grid.Children.Add(trackcr.CreateGameObject(e.Point).Object);
        }
    }
}
