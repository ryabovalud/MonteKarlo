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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
                       
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DrawTable();
        }

        private int Count = Form1.Count, yes = 0, no = 0, in_home = Form1.in_home;

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        public bool[] P_home = Form1.P_home;
        public bool[] P_to_Home = Form1.P_to_Home;

        void DrawTable()
        {
            for (int i = 0; i < Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
                if (P_home[i] == true)
                {
                    dataGridView1.Rows[i].Cells[2].Value = "Да";
                    dataGridView1.Rows[i].Cells[2].Style.BackColor = Color.Green;
                    yes++;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[2].Value = "Нет";
                    dataGridView1.Rows[i].Cells[2].Style.BackColor = Color.Red;
                    no++;
                }

                if (P_to_Home[i] == true)
                {
                    dataGridView1.Rows[i].Cells[1].Value = "Да";
                    dataGridView1.Rows[i].Cells[1].Style.BackColor = Color.Green;
                    yes++;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[1].Value = "Нет";
                    dataGridView1.Rows[i].Cells[1].Style.BackColor = Color.Red;
                    no++;
                }

            }
            textBox1.Text = yes.ToString() + " раз";
            textBox3.Text = no.ToString() + " раз";
            textBox2.Text = in_home.ToString() + " раз";
            textBox4.Text = ((in_home*1.0) / Count + "%").ToString();
            textBox5.Text = ((yes*1.0) / Count + "%").ToString();
        }

        
    }
}
