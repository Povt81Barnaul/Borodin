using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;

namespace PSMP_Kursovik
{
    class GraphicsMy
    {

        private Form1 mainForm;
        private List<Station> ListStation;
        private Rebro[] rebro;
        private List<Train> trains; 
        public GraphicsMy(Form1 main, List<Station> listStation, Rebro[] Rebro,  List<Train> Trains )
        {
            mainForm = main;
            ListStation = listStation;
            rebro = Rebro;
            trains = Trains;
        }
        public void RenderingTest()
        {

            int x = 400;
            int y = 250;
            Bitmap bmp = new Bitmap(800, 500);
            Graphics g = Graphics.FromImage(bmp);

            g.Clear(Color.White);

            g.DrawEllipse(new Pen(Color.Blue), 30, 30, 740, 440);
            g.DrawEllipse(new Pen(Color.Black, 5), x, y, 2, 2);

            for (int i = 0; i < ListStation.Count; i++)
            {
                g.DrawEllipse(new Pen(Color.Green, 6), x + ListStation[i].Coordinate.X, y + ListStation[i].Coordinate.Y, 5, 5);
                g.DrawString(ListStation[i].name, new Font("Arial", 14), new SolidBrush(Color.Black), x + ListStation[i].Coordinate.X, y + ListStation[i].Coordinate.Y);

            }
            for (int i = 0; i < rebro.Count(); i++)
            {
                g.DrawLine(new Pen(Color.Gray, 1), x + rebro[i].FirstPointG.X, y + rebro[i].FirstPointG.Y,
                               x + rebro[i].SecondPointG.X, y + rebro[i].SecondPointG.Y);
            }

            
            this.mainForm.pictureBox.Image = bmp;
            //mainForm.pictureBox.Refresh();
            //mainForm.pictureBox.Update();
            //mainForm.pictureBox.Image = bmp;
            g.Dispose();
        }
        public void Refresh()
        {

            while (true)
            {

                //System.Threading.Thread.Sleep(100);
                int x = 400;
                int y = 250;
                Bitmap bmp = new Bitmap(800, 500);
                Graphics g = Graphics.FromImage(bmp);

                g.DrawEllipse(new Pen(Color.Blue), 30, 30, 740, 440);
                g.DrawEllipse(new Pen(Color.Black, 5), x, y, 2, 2);
                
                for (int i = 0; i < trains.Count; i++)
                {
                    g.DrawEllipse(new Pen(Color.Red, 10), x + trains[i].NextCoordinate.X, y + trains[i].NextCoordinate.Y, 5, 5);
                    g.DrawString(trains[i].TrainName, new Font("Arial", 12), new SolidBrush(Color.Black), x + trains[i].NextCoordinate.X -20, y + trains[i].NextCoordinate.Y - 20);
                    for (int j = 0; j < trains[i].path.Count-1; j++)
                    {
                        g.DrawLine(new Pen(Color.Purple, 2), x + 2 + trains[i].path[j].X, y + 2 + trains[i].path[j].Y, x + 2 + trains[i].path[j+1].X, y + 2 + trains[i].path[j+1].Y);
                    }
                }

                for (int i = 0; i < rebro.Count(); i++)
                {
                    g.DrawLine(new Pen(Color.Gray, 1), x + rebro[i].FirstPointG.X, y + rebro[i].FirstPointG.Y,
                               x + rebro[i].SecondPointG.X, y + rebro[i].SecondPointG.Y);
                }

                for (int i = 0; i < ListStation.Count; i++)
                {
                    g.DrawEllipse(new Pen(Color.Green, 6), x + ListStation[i].Coordinate.X, y + ListStation[i].Coordinate.Y, 5, 5);
                    g.DrawString(ListStation[i].name, new Font("Arial", 14), new SolidBrush(Color.Black), x + ListStation[i].Coordinate.X, y + ListStation[i].Coordinate.Y);

                }

                    mainForm.BeginInvoke(new Action(() => mainForm.pictureBox.Image = bmp));
                    g.Dispose();
             
                
            }
            
        }

        
    }
}
