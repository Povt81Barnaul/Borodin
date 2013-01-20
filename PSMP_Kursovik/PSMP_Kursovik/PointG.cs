using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSMP_Kursovik
{
    /// <summary>
    /// Класс, реализующий вершину графа
    /// </summary>
    class PointG
    {
        public float ValueMetka { get; set; }
        public string Name { get; private set; }
        public bool IsChecked { get; set; }
        public PointG predPointG { get; set; }
        public object SomeObj { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public PointG(int value, bool ischecked)
        {
            ValueMetka = value;
            IsChecked = ischecked;
            predPointG = new PointG();
        }
        public PointG(int value, bool ischecked, string name, int x,int y)
        {
            ValueMetka = value;
            IsChecked = ischecked;
            Name = name;
            X = x;
            Y = y;
            predPointG = new PointG();
        }
        public PointG()
        {
        }
    }
}
