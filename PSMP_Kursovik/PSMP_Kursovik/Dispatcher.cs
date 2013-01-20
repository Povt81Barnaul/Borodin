using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PSMP_Kursovik
{
    class Dispatcher
    {
        public event MyDel stopThear;
        private List<Thread> _threads;
        private readonly List<Train> _trains;
        private List<Rebro> _rebros;
        public Queue oQueue, QueueTr;
        public List<string> Inroad;
        public Dispatcher()
        {
            
        }
        public Dispatcher(List<Thread> threads,List<Train> trains,List<Rebro> rebros )
        {
            _threads = threads;
            _trains = trains;
            _rebros = rebros;
            oQueue = new Queue();
            QueueTr = Queue.Synchronized(oQueue); 
            Inroad = new List<string>();
        }
        private Train GetTrain(string name)
        {
            return _trains.FirstOrDefault(t => t.TrainName == name);
        }
        /// <summary>
        /// Запускает движения поезда можду станциями.
        /// </summary>
        /// <param name="train"></param>
        private void StartTrain(Train train)
        {
            var thread = new Thread(train.GoToLine);
            thread.Start();
            Inroad.Add(QueueTr.Dequeue().ToString());
        }
        /// <summary>
        /// Функция регулирования движения поездов от станции к станции.
        /// </summary>
        public void Function()
        {
            Train trainInRoad,trainInStation;
            foreach (Train tr in _trains)
            {
                QueueTr.Enqueue(tr.TrainName);
            }
            bool flag = false;
            while (!(QueueTr.Count==0 && Inroad.Count ==0)) 
            {
                while (QueueTr.Count > 0)
                {
                    trainInStation = GetTrain(QueueTr.Peek().ToString());
                    if (Inroad.Count>0)
                    {
                        lock (Inroad)
                        {
                            for (int i = 0; i < Inroad.Count; i++)
                            {
                                flag = false;
                                trainInRoad = GetTrain(Inroad[i]);
                                if (trainInStation.nowPointG.Name == trainInRoad.nowPointG.Name 
                                    || trainInStation.nowPointG.Name == trainInRoad.inPointG.Name)
                                {
                                    if (trainInStation.inPointG.Name == trainInRoad.inPointG.Name 
                                        ||trainInStation.inPointG.Name == trainInRoad.nowPointG.Name)
                                    {
                                        QueueTr.Enqueue(QueueTr.Dequeue());
                                        flag = true;
                                        break;

                                    }    
                                }


                            }
                        }
                        if (!flag) StartTrain(trainInStation);

                    }
                    else
                    {
                       StartTrain(trainInStation);
                    }

                }
                System.Threading.Thread.Sleep(30);
            }
            if (stopThear != null)
                stopThear();

        }
    }
}
