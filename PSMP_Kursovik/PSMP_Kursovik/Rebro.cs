using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSMP_Kursovik
{
    /// <summary>
    /// Класс, реализующий ребро
    /// </summary>
    class Rebro
    {
        public PointG FirstPointG { get; private set; }
        public PointG SecondPointG { get; private set; }
        public float Weight { get; private set; }
        public bool Activity = false;
        /// <summary>
        /// Задаем ребро.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="valueOfWeight"></param>
        /// <returns></returns>
        public Rebro(PointG first, PointG second, float valueOfWeight)
        {
            FirstPointG = first;
            SecondPointG = second;
            Weight = valueOfWeight;
        }
    }
}
