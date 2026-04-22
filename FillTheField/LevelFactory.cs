using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillTheField
{
    public class LevelFactory
    {
        private Level _currentLevel;
        private WallCreator wallCreator;
        private PlayerCreator playerCreator;

        public LevelFactory(WallCreator wallCreator, PlayerCreator playerCreator)
        {
            this.wallCreator = wallCreator;
            this.playerCreator = playerCreator;
        }

        public void AddWall(Point pos)
        {
            _currentLevel.Content.Add(wallCreator.CreateGameObject(pos));
        }

        public void AddPlayer(Point pos)
        {

            _currentLevel.Content.Add(playerCreator.CreateGameObject(pos));
        }

        public Level Level1()
        {
            _currentLevel = new Level();
            AddWall(new Point(0, 0));
            AddWall(new Point(0, 1));
            AddWall(new Point(1, 0));
            AddWall(new Point(1, 1));
            AddPlayer(new Point(4, 1));
            return _currentLevel;
        }
        public Level Level2()
        {
            _currentLevel = new Level();
            AddWall(new Point(1, 1));
            AddWall(new Point(1, 2));
            AddWall(new Point(1, 3));
            AddWall(new Point(1, 4));
            AddPlayer(new Point(4, 4));
            return _currentLevel;
        }

        public Level Level3()
        {
            _currentLevel = new Level();
            AddWall(new Point(0, 0));
            AddWall(new Point(0, 1));
            AddWall(new Point(0, 2));
            AddWall(new Point(3, 1));
            AddWall(new Point(3, 2));
            AddWall(new Point(5, 2));
            AddWall(new Point(4, 4));
            AddWall(new Point(1, 4));
            AddPlayer(new Point(2, 1));
            return _currentLevel;
        }

        public Level Level4()
        {
            _currentLevel = new Level();
            AddWall(new Point(2, 2));
            AddPlayer(new Point(3, 2));
            return _currentLevel;
        }

        public Level Level5()
        {
            _currentLevel = new Level();
            AddWall(new Point(1, 1));
            AddWall(new Point(2, 1));
            AddWall(new Point(3, 1));
            AddWall(new Point(4, 1));
            AddWall(new Point(1, 4));
            AddWall(new Point(2, 4));
            AddWall(new Point(3, 4));
            AddWall(new Point(4, 4));
            AddPlayer(new Point(1, 3));
            return _currentLevel;
        }
        public Level Level6()
        {
            _currentLevel = new Level();
            AddWall(new Point(1, 1));
            AddWall(new Point(2, 1));
            AddWall(new Point(3, 1));
            AddWall(new Point(4, 1));
            AddWall(new Point(0, 3));
            AddWall(new Point(0, 4));
            AddWall(new Point(0, 5));
            AddWall(new Point(3, 3));
            AddPlayer(new Point(3, 2));
            return _currentLevel;
        }

    }
}
