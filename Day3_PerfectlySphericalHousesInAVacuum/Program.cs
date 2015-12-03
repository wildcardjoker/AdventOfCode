using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibHouse;

namespace Day3_PerfectlySphericalHousesInAVacuum
{
    class Program
    {
        private static List<House> _houses = new List<House>();

        static void Main(string[] args)
        {
            string directions = ">";
            
        }

        static int Move(House house, char direction)
        {
            int x = house.X;
            int y = house.Y;

            switch (direction)
            {
                case '^':
                    return ++y;
                case 'v':
                    return --y;
                case '>':
                    return ++x;
                case '<':
                default:
                    return --x;
            }
        }
    }
}
