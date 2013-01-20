using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PSMP_Kursovik
{
    class Station
    {  
        public Point Coordinate { get;private set; }
        public string name { get;private set; }
        public Station(Point StationCoordinate , string Name)
        {
            Coordinate = StationCoordinate;
            name = Name;
        }
    }
}
