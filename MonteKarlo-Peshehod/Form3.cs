using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonteKarlo_Peshehod
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
              }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            //Рисуем город
            for (int i = 0; i < Form1.Cite_Size; i++)
                for (int j = 0; j < Form1.Cite_Size; j++)
                    e.Graphics.FillRectangle(Brushes.LightPink, 5 + 30 * i, 5 + 30 * j, 25, 25);
            //рисуем бар
            e.Graphics.FillRectangle(Brushes.Black, 30*Form1.X_bar, 30 * Form1.Y_bar, 7, 7);
            //рисуем дом
            e.Graphics.FillRectangle(Brushes.Yellow, 30 * Form1.X_home, 30 * Form1.Y_home, 7, 7);
            System.Threading.Thread.Sleep(3000);

            int N = Form1.N;
            //Рисуем путь человечка
            for (int i = 0; i < N; i++)
            {
                e.Graphics.FillRectangle(Brushes.HotPink, 30 * Form1.Go_HomeX[i], 30 * Form1.Go_HomeY[i], 5, 5);

                System.Threading.Thread.Sleep(1000);
                if (i == 0)
                    e.Graphics.FillRectangle(Brushes.Black, 30 * Form1.X_bar, 30 * Form1.Y_bar, 7, 7);
                if (Form1.Go_HomeX[i] < Form1.Go_HomeX[i + 1])
                {
                    for (int j  = 5;j<=30;j+=5)
                    {
                        e.Graphics.FillRectangle(Brushes.HotPink, 30 * Form1.Go_HomeX[i] + j, 30 * Form1.Go_HomeY[i], 5, 5);
                        System.Threading.Thread.Sleep(50);
                        e.Graphics.FillRectangle(Brushes.BlueViolet, 30 * Form1.Go_HomeX[i] +j , 30 * Form1.Go_HomeY[i], 5, 5);
                    }
                        
                }
                else if (Form1.Go_HomeX[i] > Form1.Go_HomeX[i + 1])
                {
                    for (int j = 5; j <= 30; j += 5)
                    {
                        e.Graphics.FillRectangle(Brushes.HotPink, 30 * Form1.Go_HomeX[i] - j, 30 * Form1.Go_HomeY[i], 5, 5);
                        System.Threading.Thread.Sleep(50);
                        e.Graphics.FillRectangle(Brushes.BlueViolet, 30 * Form1.Go_HomeX[i] - j, 30 * Form1.Go_HomeY[i], 5, 5);
                    }
                        
                }
                else if (Form1.Go_HomeY[i] < Form1.Go_HomeY[i + 1])
                {
                    for (int j = 5; j <= 30; j += 5)
                    {
                        e.Graphics.FillRectangle(Brushes.HotPink, 30 * Form1.Go_HomeX[i], 30 * Form1.Go_HomeY[i] + j, 5, 5);
                        System.Threading.Thread.Sleep(50);
                        e.Graphics.FillRectangle(Brushes.BlueViolet, 30 * Form1.Go_HomeX[i], 30 * Form1.Go_HomeY[i] + j, 5, 5);
                    }
                        
                }
                else if (Form1.Go_HomeY[i] > Form1.Go_HomeY[i + 1])
                {
                    for (int j = 5; j <= 30; j += 5)
                    {
                        e.Graphics.FillRectangle(Brushes.HotPink, 30 * Form1.Go_HomeX[i], 30 * Form1.Go_HomeY[i] - j, 5, 5);
                        System.Threading.Thread.Sleep(50);
                        e.Graphics.FillRectangle(Brushes.BlueViolet, 30 * Form1.Go_HomeX[i], 30 * Form1.Go_HomeY[i] -j, 5, 5);
                    }
                        
                }

                e.Graphics.FillRectangle(Brushes.HotPink, 30 * Form1.Go_HomeX[i+1], 30 * Form1.Go_HomeY[i+1], 5, 5);


            }

            e.Graphics.FillRectangle(Brushes.Red, 30 * Form1.Go_HomeX[N], 30 * Form1.Go_HomeY[N], 7, 7);




        }

    }
}
