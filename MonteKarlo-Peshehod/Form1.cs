using System;
using System.Windows.Forms;

namespace MonteKarlo_Peshehod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Сколько раз проводим эксперимент
        public static int Count, KVARTAL, Cite_Size = 100;
        /// Колличество кварталов, которые должен пройти человечек
        public static int N, N_paint;

        // Начальные и конечные координаты человечка
        public static int X_bar, Y_bar, X_home, Y_home;
        private int X_end, Y_end;
        private double value;
        // Задаём вероятности поворота на Север, Юг, Запад, Восток СУММА должна равняться 100
        private double   P1, P2, P3, P4;

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {    
        }
        // Массив для хранения значений - доберёться до дома или нет
        public static bool[] P_home, P_to_Home;

        
        public static int in_home;

        // Массив для хранения координат пути человечка
        public static int[] Go_HomeX, Go_HomeY;

        private void Button1_Click(object sender, EventArgs e)
        {
            in_home = 0;
            N = Convert.ToInt32(textBox2.Text);
            Count = Convert.ToInt32(textBox1.Text);
            KVARTAL = Convert.ToInt32(textBox9.Text);

            P1 = Convert.ToDouble(textBox8.Text) * 100;
            P2 = P1 + Convert.ToDouble(textBox7.Text)*100;
            P3 = P2 + Convert.ToDouble(textBox6.Text)*100;
            P4 = P3 + Convert.ToDouble(textBox5.Text)*100;

            N_paint = Convert.ToInt32(textBox10.Text);

            X_bar = Convert.ToInt32(textBox3.Text);
            Y_bar = Convert.ToInt32(textBox4.Text);
            X_home = X_bar; Y_home = Y_bar;
            P_home = new bool[Count];
            P_to_Home = new bool[Count];
            Go_HomeX = new int[N+1];
            Go_HomeY = new int[N+1];
            Go_HomeX[0] = X_bar; Go_HomeY[0] = Y_bar;
            Random random = new Random();

            //Цикл по количеству экспериментов
            for (int i = 0; i < Count; i++)
            {
                
                X_end = X_bar; Y_end = Y_bar;

                for (int j = 0; j < N; j++) //Цикл для прохода по кварталам
                {
                    
                    value = random.Next(0, 101);//Получаем число для подсчёта вероятности

                    if (value <= P1) // Идём вниз
                    {
                        Y_end += 1;
                        if (Y_end > Cite_Size)
                        {
                            Y_end--;    j--;
                        }
                    }

                    else if (P1 < value && value <= P2) // Идём вверх
                    {
                        Y_end -= 1;
                        if (Y_end < 0)
                        {
                            Y_end++; j--;
                        }
                    }
                    else if (P2 < value && value <= P3) // Идём влево
                    {
                        X_end -= 1;
                        if (X_end < 0)
                        {
                            X_end++; j--;
                        }
                    }
                    else if (P3 < value && value <= P4) // Идём Вправo
                    {
                        X_end += 1;
                        if (X_end > Cite_Size)
                        {
                            X_end--; j--;
                        }
                    }
                    
                    if (i == N_paint - 1)
                    {
                        Go_HomeX[j+1] = X_end; Go_HomeY[j+1] = Y_end;
                    }
                }
                

                //Заполняем массив дошёл/недошёл до дома
                if ((Math.Abs(X_home - X_end) + Math.Abs(Y_home - Y_end)) <= KVARTAL)
                    P_home[i] = true;
                else
                    P_home[i] = false;
                if ((X_home == X_end) && (Y_home == Y_end))
                {
                    in_home++; P_to_Home[i] = true;
                }
                else
                    P_to_Home[i] = false;
            }
            Form2 f2 = new Form2();
            f2.Show();
        }






        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }


       


       
    }


}
