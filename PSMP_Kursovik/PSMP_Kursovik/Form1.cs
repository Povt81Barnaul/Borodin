using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace PSMP_Kursovik
{
    delegate void MyDel();
    public partial class Form1 : Form
    {
        List<Thread> threads = new List<Thread>();
        List<Station> ListStation = new List<Station>();
        private List<Train> listTrain = new List<Train>();
        private Rebro[] rebro;//Ребра
        private List<Rebro> ListRebro; 
        private PointG[] tops;//Вершины
        private GraphicsMy graphics;
        private Thread threadGraphic;
        private Thread DisThread;
        public Form1()
        {
            InitializeComponent();
            GUIController.setForm(this);
        }
        /// <summary>
        /// Генерируем граф
        /// </summary>
        /// <returns></returns>
        private void GenerateGraph()
        {
            int stationCount = Convert.ToInt32(numericStationCount.Value);
            var rend1 = new Random(System.DateTime.Now.Millisecond);
            var rend2 = new Random(System.DateTime.Now.Second + System.DateTime.Now.Millisecond);
            int rebroCount = rend1.Next(((stationCount * stationCount - 1) / 6), ((stationCount * stationCount - 1) / 3));
            rebro = new Rebro[rebroCount+1];
            ListRebro = new List<Rebro>();
            //d = sqrt (x1 – x2)^2 + (y1 – y2)^2
            int r1,
                r2;
            bool flag = false;
            for (int i = 0; i <= rebroCount; i++)
            {
                flag = false;
                while (true)
                {
                    r1 = rend1.Next(0, stationCount);
                    r2 = rend2.Next(0, stationCount);
                    if (r1 != r2)
                    {
                        if (i == 0)
                        {
                            ListRebro.Add(new Rebro(tops[r1], tops[r2],
                                                    (float)
                                                    Math.Sqrt(
                                                        Math.Pow(
                                                            ListStation[r1].Coordinate.X - ListStation[r2].Coordinate.X,
                                                            2) +
                                                        Math.Pow(
                                                            ListStation[r1].Coordinate.Y - ListStation[r2].Coordinate.Y,
                                                            2))));
                            
                            //rebro[i] = new Rebro(tops[r1], tops[r2], (float)Math.Sqrt(Math.Pow(ListStation[r1].Coordinate.X - ListStation[r2].Coordinate.X, 2) +
                                                                                //Math.Pow(ListStation[r1].Coordinate.Y - ListStation[r2].Coordinate.Y, 2)));
                            break;
                        }

                        for (int j = 0; j < i; j++)
                        {
                            if (!(ListRebro[j].FirstPointG == tops[r1] && ListRebro[j].SecondPointG == tops[r2]) &&
                                !(ListRebro[j].FirstPointG == tops[r2] && ListRebro[j].SecondPointG == tops[r1]))
                            {
                                ListRebro.Add(new Rebro(tops[r1], tops[r2],
                                                    (float)
                                                    Math.Sqrt(
                                                        Math.Pow(
                                                            ListStation[r1].Coordinate.X - ListStation[r2].Coordinate.X,
                                                            2) +
                                                        Math.Pow(
                                                            ListStation[r1].Coordinate.Y - ListStation[r2].Coordinate.Y,
                                                            2))));
                                flag = true;
                                break;
                            }

                        }

                    }
                    if (flag) break;
                }
            }

            for (int i = 0; i < stationCount; i++)
            {
                flag = false;
                for (int j = 0; j < ListRebro.Count; j++)
                {
                    if (ListRebro[j].FirstPointG == tops[i] || ListRebro[j].SecondPointG == tops[i])
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    int I;
                    if (i < stationCount-1)
                        I = i + 1;
                    else
                        I = i - 1;
                    ListRebro.Add(new Rebro(tops[i], tops[I],
                                                    (float)
                                                    Math.Sqrt(
                                                        Math.Pow(
                                                            ListStation[i].Coordinate.X - ListStation[I].Coordinate.X,
                                                            2) +
                                                        Math.Pow(
                                                            ListStation[i].Coordinate.Y - ListStation[I].Coordinate.Y,
                                                            2))));
                    rebroCount++;
                }
            }
            rebro = ListRebro.ToArray();
        }
        /// <summary>
        /// Обработчики собитий, вызывается после завершения работы диспетчира.
        /// </summary>
        private void Handler()
        {
            StopThreads();
        } 
        /// <summary>
        /// Завершение всех потоков.
        /// </summary>
        private void StopThreads()
        {
            //mainForm.BeginInvoke(new Action(() => mainForm.pictureBox.Image = bmp));
            buttonStart.BeginInvoke(new Action(() => buttonStart.Enabled = true));
            buttonCreate.BeginInvoke(new Action(() => buttonCreate.Enabled = true));// buttonCreate.Enabled = true;
            listTrain.Clear();
            threadGraphic.Abort();
            threadGraphic.Join();
            DisThread.Abort();
            DisThread.Join();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            buttonCreate.Enabled = false;
            int stationCount = Convert.ToInt32(numericStationCount.Value);
            int trainCount = Convert.ToInt32(numericTrainCount.Value);
            // пример =) new System.Threading.Thread(delegate() { MyMetod(2, 2); }).Start();
            #region Потоки

            for (int i = 0; i < trainCount; i++)
            {
                int t1, t2;
                var rend1 = new Random(System.DateTime.Now.Millisecond);
                bool flag = true;
                if (checkBoxRend.Checked)
                {
                    while (flag)
                    {
                        flag = true;
                        t1 = rend1.Next(0, stationCount);
                        t2 = rend1.Next(0, stationCount);
                        if (t1 != t2)
                        {
                            listTrain.Add(new Train(tops[t1], tops[t2]));
                            listTrain[i].GetPath(tops, rebro);
                            //listTrain[i].MyEvent +=new MyDel(Handler);
                            listTrain[i].SetTrainName(i.ToString(CultureInfo.InvariantCulture));
                            flag = false;
                        }
                    }
                }
                else
                {
                    t1 = Convert.ToInt32(dataGridViewTrain.Rows[i].Cells[1].Value);
                    t2 = Convert.ToInt32(dataGridViewTrain.Rows[i].Cells[2].Value);
                    if (t1!=t2)
                    {
                        listTrain.Add(new Train(tops[t1], tops[t2]));
                        listTrain[i].GetPath(tops, rebro);
                        //listTrain[i].MyEvent += new MyDel(Handler);
                        listTrain[i].SetTrainName(i.ToString(CultureInfo.InvariantCulture));
                    }
                }

            }
            Dispatcher dis=new Dispatcher(listTrain);
            dis.stopThear += new MyDel(Handler);
            foreach (var t in listTrain)
            {
                t.MyDispatcher = dis;
            }
            DisThread = new Thread(dis.Function);
            DisThread.Start();
            #endregion
            graphics = new GraphicsMy(this, ListStation, rebro,listTrain);
            //graphics.RenderingTest();
            threadGraphic = new Thread(graphics.Refresh);
            threadGraphic.Name = "Graphic";
            //graphics.stopThreads += new MyDelTr(StopThreads);
            threadGraphic.Start();   
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopThreads();
            //textBox1.Text = "ls: " +ListStation.Count.ToString() + " lt:" + listTrain.Count.ToString() + " lthr:" + threads.Count.ToString();

        }

        private void Create_Click(object sender, EventArgs e)
        {
            ListStation.Clear();
            listTrain.Clear();
            threads.Clear();
            int stationCount = Convert.ToInt32(numericStationCount.Value);
            int trainCount = Convert.ToInt32(numericTrainCount.Value);
            double alfa = 0;
            double stepAlfa = 360 / stationCount * Math.PI / 180;
            int A_widht = 370;
            int B_height = 220;
            double radius;
            tops = new PointG[stationCount];
            for (int i = 0; i < stationCount; i++)
            {
                radius = B_height * A_widht /
                         Math.Sqrt(B_height * B_height * Math.Cos(alfa) * Math.Cos(alfa) +
                                   A_widht * A_widht * Math.Sin(alfa) * Math.Sin(alfa));
                ListStation.Add(new Station(new Point(Convert.ToInt32(radius * Math.Cos(alfa)), Convert.ToInt32(-radius * Math.Sin(alfa))),
                    i.ToString()));

                tops[i] = new PointG(999, false, (i).ToString(CultureInfo.InvariantCulture),
                                     Convert.ToInt32(radius * Math.Cos(alfa)), Convert.ToInt32(-radius * Math.Sin(alfa)));
                alfa += stepAlfa;
            }
            //dataGridViewTrain.Rows.Add(trainCount);
            dataGridViewTrain.Rows.Clear();
            ((DataGridViewComboBoxColumn)dataGridViewTrain.Columns[1]).Items.Clear();
            ((DataGridViewComboBoxColumn)dataGridViewTrain.Columns[2]).Items.Clear();
            //var cell = new DataGridViewComboBoxCell();
            //GridItemCollection It;
            for (int i = 0; i < stationCount; i++)
            {
                ((DataGridViewComboBoxColumn)dataGridViewTrain.Columns[1]).Items.Add(ListStation[i].name);
                ((DataGridViewComboBoxColumn)dataGridViewTrain.Columns[2]).Items.Add(ListStation[i].name);
            }
            for (int i = 0; i < trainCount; i++)
            {
                
                //((DataGridViewComboBoxColumn)dataGridViewTrain.Columns[1]).Items.Add(ListStation[i].name);
                //((DataGridViewComboBoxColumn)dataGridViewTrain.Columns[2]).Items.Add(ListStation[i].name);
                dataGridViewTrain.Rows.Add();
                dataGridViewTrain[0, i].Value = i + 1;
            }

            GenerateGraph();
            graphics = new GraphicsMy(this, ListStation, rebro, listTrain);
            graphics.RenderingTest();
        }
    }
}
