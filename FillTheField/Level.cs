using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillTheField
{
    public class Level
    {
        private List<GameObject> _content;
        public List<GameObject> Content => _content;

        public Level()
        {
            _content = new List<GameObject>();
        }
    }
}
