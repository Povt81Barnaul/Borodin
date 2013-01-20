using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSMP_Kursovik
{
    class Train
    {
        //public event MyDel MyEvent; 

        private Point StartCoordinate, FinishCoordinate ;
        public Point NextCoordinate { get; private set; }
        public PointG beginPointG, endPointG, nowPointG, inPointG;
        public List<PointG> path { get; private set; }
        public String TrainName;
        public Dispatcher MyDispatcher { get; set; }
        private int m1;
        private double lamda;
        private double lenght;
        public Train(Point StartXY, Point FinishXY)
        {
            StartCoordinate = new Point(StartXY.X,StartXY.Y);
            FinishCoordinate = new Point(FinishXY.X,FinishXY.Y);
            NextCoordinate = new Point(StartXY.X, StartXY.Y);
        }

        public Train(PointG begin, PointG end)
        {
            beginPointG = nowPointG = begin;
            endPointG = end;
            StartCoordinate = new Point(begin.X,begin.Y);
            FinishCoordinate= new Point(end.X,end.Y);
            NextCoordinate = new Point(begin.X, begin.Y);

        }

        public void SetTrainName(string name)
        {
            TrainName = name;
        }

        /// <summary>
        /// Получаем маршрут.
        /// </summary>
        public void GetPath(PointG[] pointGs,Rebro[] rebros)
        {
            
            foreach (PointG point in pointGs)
            {
                point.ValueMetka = point == beginPointG ? 0 : 999;
                point.IsChecked = false;
            }
            DekstraAlgorim da = new DekstraAlgorim(pointGs,rebros);
            da.AlgoritmRun(beginPointG);
            path = da.MinPath1(endPointG);
            inPointG = path[path.Count - 2];
            FinishCoordinate.X = path[path.Count - 2].X;
            FinishCoordinate.Y = path[path.Count - 2].Y;
        }


        public Point GetNextCoordinate()
        {
            if ( Math.Sqrt(Math.Pow(FinishCoordinate.X - NextCoordinate.X,2) +  Math.Pow(FinishCoordinate.Y - NextCoordinate.Y,2)) < 30)
            {

                for (int i = path.Count-1; i >= 0; i--)
                {
                    if ((path[i].Name == nowPointG.Name) && (path[0].predPointG.Name != nowPointG.Name) )
                    {
                        try
                        {
                            if (path.Count == 2) 
                            {
                                return null;
                            }
                            else
                            {
                                nowPointG = path[i - 1];
                                StartCoordinate.X = NextCoordinate.X = path[i - 1].X;
                                StartCoordinate.Y = NextCoordinate.Y = path[i - 1].Y;
                                FinishCoordinate.X = path[i - 2].X;
                                FinishCoordinate.Y = path[i - 2].Y;
                            }
                            //FinishCoordinate.X = path[i - 2].X;
                            //FinishCoordinate.Y = path[i - 2].Y;
                            lenght =
                                Math.Sqrt(Math.Pow(FinishCoordinate.X - NextCoordinate.X, 2) +
                                          Math.Pow(FinishCoordinate.Y - NextCoordinate.Y, 2));
                            m1 = 10;
                            lamda = m1 / (lenght - m1);
                            break;
                        }
                        catch (Exception)
                        {
                            return null;
                            //break;
                        }
                    }
                    if (path[i].Name == nowPointG.Name && path[0].predPointG.Name == nowPointG.Name)
                    {
                        return null;
                    }
                }   
            }
            try
            {
                NextCoordinate.X = (int) ((StartCoordinate.X + lamda*FinishCoordinate.X)/(1 + lamda));
                NextCoordinate.Y = (int) ((StartCoordinate.Y + lamda*FinishCoordinate.Y)/(1 + lamda));
                m1 += 10;
                lamda = m1 / (lenght - m1);
                //lamda += steplamda + steplamda;
                return NextCoordinate; 
            }
            catch (Exception)
            {
                return null;
            }                
        }
        private int GetNextCoordinateForLine()
        {
            double temp = Math.Sqrt(Math.Pow(FinishCoordinate.X - NextCoordinate.X, 2) +
                                 Math.Pow(FinishCoordinate.Y - NextCoordinate.Y, 2));
            if (temp < 50)
                temp = 49;
            if (
                Math.Sqrt(Math.Pow(FinishCoordinate.X - NextCoordinate.X, 2) +
                          Math.Pow(FinishCoordinate.Y - NextCoordinate.Y, 2)) < 30)
            {
                if (path.Count > 2)
                {
                    if (path[1].Name == nowPointG.Name)
                        return 0;
                    for (int i = path.Count - 1; i >= 0; i--)
                    {
                        if ((path[i].Name == nowPointG.Name) && (path[1].Name != nowPointG.Name))
                        {
                            try
                            {
                                nowPointG = path[i - 1];
                                StartCoordinate.X = NextCoordinate.X = path[i - 1].X;
                                StartCoordinate.Y = NextCoordinate.Y = path[i - 1].Y;
                                inPointG = path[i - 2];
                                FinishCoordinate.X = path[i - 2].X;
                                FinishCoordinate.Y = path[i - 2].Y;
                                return 2;
                            }
                            catch (Exception)
                            {
                                return 0;
                                //break;
                            }
                        }
                    }
                }
                else
                    return 0;
            }
            try
            {
                NextCoordinate.X = (int)((StartCoordinate.X + lamda * FinishCoordinate.X) / (1 + lamda));
                NextCoordinate.Y = (int)((StartCoordinate.Y + lamda * FinishCoordinate.Y) / (1 + lamda));
                m1 += 10;
                lamda = m1 / (lenght - m1);
                //lamda += steplamda + steplamda;
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }                
        }
        public void Go()
        {
            m1 = 10;
            lenght =
                Math.Sqrt(Math.Pow(FinishCoordinate.X - NextCoordinate.X, 2) +
                          Math.Pow(FinishCoordinate.Y - NextCoordinate.Y, 2));
            lamda = m1 / (lenght - m1);
            while (true)
            {
                System.Threading.Thread.Sleep(50);
                
                if (GetNextCoordinate()==null)
                    break;
                
            }
        }
        public void GoToLine()
        {
            m1 = 10;
            lenght =
                Math.Sqrt(Math.Pow(FinishCoordinate.X - NextCoordinate.X, 2) +
                          Math.Pow(FinishCoordinate.Y - NextCoordinate.Y, 2));
            lamda = m1 / (lenght - m1);
            int writeQueue;
            while (true)
            {
                System.Threading.Thread.Sleep(50);
                writeQueue = GetNextCoordinateForLine();
                if(writeQueue==0 || writeQueue == 2)
                    break;
            }
            lock (MyDispatcher.Inroad)
            {
                MyDispatcher.Inroad.Remove(TrainName);    
            }
            if (writeQueue == 2)
                MyDispatcher.QueueTr.Enqueue(TrainName);
                
            
        }
    }

}
