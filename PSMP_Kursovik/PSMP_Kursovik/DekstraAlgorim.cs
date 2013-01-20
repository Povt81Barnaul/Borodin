using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSMP_Kursovik
{
    /// <summary>
    /// Реализация алгоритма Дейкстры. Содержит матрицу смежности в виде массивов вершин и ребер
    /// </summary>
    internal class DekstraAlgorim
    {

        public PointG[] PointGs { get; private set; }
        public Rebro[] rebra { get; private set; }
        public PointG BeginPointG { get; private set; }

        public DekstraAlgorim(PointG[] PointGsOfgrath, Rebro[] rebraOfgrath)
        {
            PointGs = PointGsOfgrath;
            rebra = rebraOfgrath;
        }

        /// <summary>
        /// Запуск алгоритма расчета
        /// </summary>
        /// <param name="beginp"></param>
        public void AlgoritmRun(PointG beginp)
        {
            if (this.PointGs.Count() == 0 || this.rebra.Count() == 0)
            {
                throw new DekstraException("Массив вершин или ребер не задан!");
            }
            else
            {
                BeginPointG = beginp;
                OneStep(beginp);
                foreach (PointG PointG in PointGs)
                {
                    PointG anotherP = GetAnotherUncheckedPointG();
                    if (anotherP != null)
                    {
                        OneStep(anotherP);
                    }
                    else
                    {
                        break;
                    }

                }
            }

        }

        /// <summary>
        /// Метод, делающий один шаг алгоритма. Принимает на вход вершину
        /// </summary>
        /// <param name="beginPointG"></param>
        public void OneStep(PointG beginPointG)
        {
            foreach (PointG nextp in Pred(beginPointG))
            {
                if (nextp.IsChecked == false) //не отмечена
                {
                    float newmetka;
                    try
                    {
                        newmetka = beginPointG.ValueMetka + GetMyRebro(nextp, beginPointG).Weight;
                    }
                    catch (Exception)
                    {
                        newmetka = beginPointG.ValueMetka;
                    }
                    
                    if (nextp.ValueMetka > newmetka)
                    {
                        nextp.ValueMetka = newmetka;
                        nextp.predPointG = beginPointG;
                    }
                    else
                    {

                    }
                }
            }
            beginPointG.IsChecked = true; //вычеркиваем
        }

        /// <summary>
        /// Поиск соседей для вершины. Для неориентированного графа ищутся все соседи.
        /// </summary>
        /// <param name="currPointG"></param>
        /// <returns></returns>
        private IEnumerable<PointG> Pred(PointG currPointG)
        {
            IEnumerable<PointG> firstPointGs = from ff in rebra
                                               where ff.FirstPointG == currPointG
                                               select ff.SecondPointG;
            IEnumerable<PointG> secondPointGs = from sp in rebra
                                                where sp.SecondPointG == currPointG
                                                select sp.FirstPointG;
            IEnumerable<PointG> totalPointGs = firstPointGs.Concat<PointG>(secondPointGs);
            return totalPointGs;
        }

        /// <summary>
        /// Получаем ребро, соединяющее 2 входные точки
        /// </summary>
        /// <param name="Первая вершина"></param>
        /// <param name="Вторая вершина"></param>
        /// <returns></returns>
        public Rebro GetMyRebro(PointG a, PointG b)
        {
        //ищем ребро по 2 точкам
            IEnumerable<Rebro> myr = from reb in rebra
                                     where
                                         (reb.FirstPointG == a & reb.SecondPointG == b) ||
                                         (reb.SecondPointG == a & reb.FirstPointG == b)
                                     select reb;
            if (myr.Count() > 1 || myr.Count() == 0)
            {
                return null;
                throw new DekstraException("Не найдено ребро между соседями!");
            }
            else
            {
                return myr.First();
            }
        }

        /// <summary>
        /// Получаем очередную неотмеченную вершину, "ближайшую" к заданной.
        /// </summary>
        /// <returns></returns>
        private PointG GetAnotherUncheckedPointG()
        {
            IEnumerable<PointG> PointGsuncheck = from p in PointGs where p.IsChecked == false select p;
            if (PointGsuncheck.Count() != 0)
            {
                float minVal = PointGsuncheck.First().ValueMetka;
                PointG minPointG = PointGsuncheck.First();
                foreach (PointG p in PointGsuncheck)
                {
                    if (p.ValueMetka < minVal)
                    {
                        minVal = p.ValueMetka;
                        minPointG = p;
                    }
                }
                return minPointG;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Получаем минимальный путь.
        /// </summary>
        /// <param name="end"></param>
        /// <returns>Вершина до которой проложить путь</returns>
        public List<PointG> MinPath1(PointG end)
        {
            List<PointG> listOfPointGs = new List<PointG>();
            PointG tempp = end;
            while (tempp != this.BeginPointG)
            {
                if (tempp == null)
                {
                    return listOfPointGs;
                }
                listOfPointGs.Add(tempp);
                tempp = tempp.predPointG;
            }
            listOfPointGs.Add(tempp);
            return listOfPointGs;
        }
    }

    /// <summary>
    /// для печати графа
    /// </summary>
    internal static class PrintGrath
    {
        public static List<string> PrintAllPointGs(DekstraAlgorim da)
        {
            List<string> retListOfPointGs = new List<string>();
            foreach (PointG p in da.PointGs)
            {
                retListOfPointGs.Add(string.Format("PointG name={0}, PointG value={1}, predok={2}", p.Name, p.ValueMetka,
                                                   p.predPointG.Name ?? "нет предка"));
            }
            return retListOfPointGs;
        }

        public static List<string> PrintAllMinPaths(DekstraAlgorim da)
        {
            List<string> retListOfPointGsAndPaths = new List<string>();
            foreach (PointG p in da.PointGs)
            {

                if (p != da.BeginPointG)
                {
                    string s = string.Empty;
                    foreach (PointG p1 in da.MinPath1(p))
                    {
                        s += string.Format("{0} ", p1.Name);
                    }
                    retListOfPointGsAndPaths.Add(string.Format("PointG ={0},MinPath from {1} = {2}", p.Name,
                                                               da.BeginPointG.Name, s));
                }

            }
            return retListOfPointGsAndPaths;
        }
    }

    internal class DekstraException : ApplicationException
    {
        public DekstraException(string message)
            : base(message)
        {
        }
    }
}