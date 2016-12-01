using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHouse
{
    public class House
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Presents { get; set; }

        public House() : this(0, 0) { }
        public House(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
