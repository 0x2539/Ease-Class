using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proiect
{
    public partial class Matrici : Form
    {
        int[] aMatrici = new int[200];
        int[] solMatrici = new int[200];
        int[] a2Matrici = new int[200];
        int[] sol2Matrici = new int[200];
        int[] rezMatrici = new int[200];
        int[] rez2Matrici = new int[200];
        Label[] lb1Matrici = new Label[10000];
        Label[] lb2Matrici = new Label[10000];
        int n1Matrici, m1Matrici, pozxMatrici = 0, pozyMatrici = 0,
            last1Matrici = 0, last2Matrici = 0, last3Matrici = 0, last4Matrici = 0;
        int n2Matrici, m2Matrici;

        public Matrici()
        {
            InitializeComponent();
        }

        private void button2_ClickMatrici(object sender, EventArgs e)
        {
            bool tr = false;
            string u = "qwertyuiopasfdghjklzxcvbnm";
            for (int o = 0; o < textBox1Matrici.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox1Matrici.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            if (tr == true)
            {
                MessageBox.Show("Introduceti numai numere!");
            }
            if(tr==false)
            if (textBox3Matrici.Text != "" && textBox4Matrici.Text != "" &&
                textBox3Matrici.Text != "(k)" && textBox4Matrici.Text != "(n)")
            {
                if (last2Matrici != 0)
                {
                    button5Matrici.PerformClick();
                    /*
                    for (int i = 0; i <= last2; i++)
                    {
                        lb2Matrici[i] = new Label();
                        lb2Matrici[i].Hide();
                    }*/
                }
                n2Matrici = Convert.ToInt32(textBox4Matrici.Text);
                m2Matrici = Convert.ToInt32(textBox3Matrici.Text);
                if (n2Matrici >= m2Matrici)
                {
                    /*if (last2 != 0)
                    {
                        for (int i = 0; i < last2; i++)
                        {
                            lb2Matrici[i] = new Label();
                            lb2Matrici[i].Hide();
                        }
                    }*/

                    lb2Matrici[0] = new Label();
                    this.lb2Matrici[0].AutoSize = true;
                    this.lb2Matrici[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lb2Matrici[0].Location = new System.Drawing.Point(label1Matrici.Location.X, label1Matrici.Location.Y);
                    this.lb2Matrici[0].Name = "label1";
                    this.lb2Matrici[0].Size = new System.Drawing.Size(35, 13);
                    this.lb2Matrici[0].TabIndex = 0;
                    this.lb2Matrici[0].Text = "1";
                    lb2Matrici[0].BackColor = System.Drawing.Color.Transparent;
                    Controls.Add(lb2Matrici[0]);
                    lb2Matrici[0].Show();
                    pozxMatrici = lb2Matrici[0].Location.X;
                    pozyMatrici = lb2Matrici[0].Location.Y;

                    for (int i = 1; i <= n2Matrici; i++)
                    {
                        a2Matrici[i] = new int();
                        a2Matrici[i] = i;
                    }
                    last2Matrici = 0;
                    back2Matrici(1);

                }
                else
                {
                    MessageBox.Show("n trebuie să fie mai mare decât k!");
                }
            }
            else
            {
                MessageBox.Show("Introduceți pe n si pe k!");
            }
        }
        public int valid2Matrici(int k)
        {
            int i;
            for (i = 1; i <= k - 1; i++)
                if (sol2Matrici[i] == sol2Matrici[k])
                    return 0;
            return 1;
        }
        int numaraMatrici = 0;

        public void back2Matrici(int k)
        {
            int i;
            if (k == m2Matrici + 1)
            {
                int uy = lb2Matrici[0].Location.X;

                for (i = 1; i <= m2Matrici; i++)
                {
                    lb2Matrici[numaraMatrici * m2Matrici + i] = new Label();
                    this.lb2Matrici[numaraMatrici * m2Matrici + i].AutoSize = true;
                    this.lb2Matrici[numaraMatrici * m2Matrici + i].Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lb2Matrici[numaraMatrici * m2Matrici + i].BackColor = System.Drawing.Color.Transparent;
                    if (i != 1)
                    {
                        this.lb2Matrici[numaraMatrici * m2Matrici + i].Location = new System.Drawing.Point(this.lb2Matrici[numaraMatrici * m2Matrici + i - 1].Location.X + 30, pozyMatrici);
                    }
                    else
                    {
                        lb2Matrici[numaraMatrici * m2Matrici + i].Location = new Point(pozxMatrici, pozyMatrici);
                    }
                    rez2Matrici[numaraMatrici * m2Matrici + i] = new int();
                    this.lb2Matrici[numaraMatrici * m2Matrici + i].Name = "label1";
                    this.lb2Matrici[numaraMatrici * m2Matrici + i].Size = new System.Drawing.Size(35, 13);
                    this.lb2Matrici[numaraMatrici * m2Matrici + i].TabIndex = 0;
                    this.lb2Matrici[numaraMatrici * m2Matrici + i].Text = a2Matrici[sol2Matrici[i]].ToString();
                    Controls.Add(lb2Matrici[numaraMatrici * m2Matrici + i]);
                    last2Matrici = numaraMatrici * m2Matrici + i;
                    lb2Matrici[last2Matrici].Show();
                }
                pozxMatrici = lb2Matrici[0].Location.X;
                pozyMatrici += 30;
                richTextBox1Matrici.Text += '\n';

                numaraMatrici++;
            }
            else
                for (i = 1; i <= n2Matrici; i++)
                {
                    sol2Matrici[k] = new int();
                    sol2Matrici[k] = i;
                    if (valid2Matrici(k) != 0)
                        back2Matrici(k + 1);
                }
        }

        int valid1Matrici(int k)
        {
            int i;

            if (solMatrici[k - 1] >= solMatrici[k] && k > 1) return 0;
            return 1;
        }
        void back1Matrici(int k)
        {
            int i;
            if (k == m1Matrici + 1)
            {

                for (i = 1; i <= m1Matrici; i++)
                {
                    lb1Matrici[numaraMatrici * m1Matrici + i] = new Label();
                    this.lb1Matrici[numaraMatrici * m1Matrici + i].AutoSize = true;
                    lb1Matrici[numaraMatrici * m1Matrici + i].BackColor = System.Drawing.Color.Transparent;
                    this.lb1Matrici[numaraMatrici * m1Matrici + i].Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    if (i != 1)
                    {
                        this.lb1Matrici[numaraMatrici * m1Matrici + i].Location = new System.Drawing.Point(this.lb1Matrici[numaraMatrici * m1Matrici + i - 1].Location.X + 30, pozyMatrici);
                    }
                    else
                    {
                        lb1Matrici[numaraMatrici * m1Matrici + i].Location = new Point(pozxMatrici, pozyMatrici);
                    }
                    rez2Matrici[numaraMatrici * m2Matrici + i] = new int();
                    this.lb1Matrici[numaraMatrici * m1Matrici + i].Name = "label1";
                    this.lb1Matrici[numaraMatrici * m1Matrici + i].Size = new System.Drawing.Size(35, 13);
                    this.lb1Matrici[numaraMatrici * m1Matrici + i].TabIndex = 0;
                    this.lb1Matrici[numaraMatrici * m1Matrici + i].Text = aMatrici[solMatrici[i]].ToString();
                    Controls.Add(lb1Matrici[numaraMatrici * m1Matrici + i]);
                    richTextBox1Matrici.Text += aMatrici[solMatrici[i]].ToString() + ' ';
                    last1Matrici = numaraMatrici * m1Matrici + i;
                    lb1Matrici[last1Matrici].Show();
                }
                pozxMatrici = lb1Matrici[0].Location.X;
                pozyMatrici += 30;
                richTextBox1Matrici.Text += '\n';

                numaraMatrici++;
            }
            else for (i = 1; i <= n1Matrici; i++)
                {
                    solMatrici[k] = i;
                    if (valid1Matrici(k) != 0) back1Matrici(k + 1);
                }
        }

        private void button1_ClickMatrici(object sender, EventArgs e)
        {
            bool tr = false;
            string u = "qwertyuiopasfdghjklzxcvbnm";
            for (int o = 0; o < textBox1Matrici.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox1Matrici.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            if (tr == true)
            {
                MessageBox.Show("Introduceti numai numere!");
            }
            if(tr==false)
            if (textBox1Matrici.Text != "" && textBox2Matrici.Text != "" &&
                textBox1Matrici.Text != "(k)" && textBox2Matrici.Text != "(n)")
            {
                if (last1Matrici != 0)
                {
                    button4Matrici.PerformClick();/*
                    for (int i = 0; i <= last1; i++)
                    {
                        lb1Matrici[i] = new Label();
                        lb1Matrici[i].Hide();
                    }*/
                }
                n1Matrici = Convert.ToInt32(textBox2Matrici.Text);
                m1Matrici = Convert.ToInt32(textBox1Matrici.Text);
                if (n1Matrici >= m1Matrici)
                {
                    /*if (last1 != 0)
                    {
                        for (int i = 0; i < last1; i++)
                        {
                            lb1Matrici[i] = new Label();
                            lb1Matrici[i].Hide();
                        /
                    }*/

                    lb1Matrici[0] = new Label();
                    this.lb1Matrici[0].AutoSize = true;
                    this.lb1Matrici[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lb1Matrici[0].Location = new System.Drawing.Point(label8Matrici.Location.X, label8Matrici.Location.Y);
                    this.lb1Matrici[0].Name = "label1";
                    this.lb1Matrici[0].Size = new System.Drawing.Size(35, 13);
                    this.lb1Matrici[0].TabIndex = 0;
                    this.lb1Matrici[0].Text = "1";
                    lb1Matrici[0].BackColor = System.Drawing.Color.Transparent;
                    Controls.Add(lb1Matrici[0]);
                    pozxMatrici = lb1Matrici[0].Location.X;
                    pozyMatrici = lb1Matrici[0].Location.Y;
                    lb1Matrici[0].Show();
                    for (int i = 1; i <= n1Matrici; i++)
                    {
                        aMatrici[i] = new int();
                        aMatrici[i] = i;
                    }
                    last1Matrici = 0;
                    back1Matrici(1);
                }
                else
                {
                    MessageBox.Show("n trebuie să fie mai mare decât k!");
                }
            }
            else
            {
                MessageBox.Show("Introduceți pe n si pe k!");
            }
        }
        private void button3_ClickMatrici(object sender, EventArgs e)
        {

        }

        private void textBox1_ClickMatrici(object sender, EventArgs e)
        {
            if (textBox1Matrici.Text == "(k)")
            {
                textBox1Matrici.Text = "";
            }
            else
                if (textBox1Matrici.Text != "(k)")
                {
                    textBox1Matrici.Select(0, textBox1Matrici.Text.Length);
                }
        }

        private void textBox2_ClickMatrici(object sender, EventArgs e)
        {
            if (textBox2Matrici.Text == "(n)")
            {
                textBox2Matrici.Text = "";
            }
            else
                if (textBox2Matrici.Text != "(n)")
                {
                    textBox2Matrici.Select(0, textBox2Matrici.Text.Length);
                }
        }

        private void textBox5_ClickMatrici(object sender, EventArgs e)
        {
            if (textBox5Matrici.Text == "(n)")
            {
                textBox5Matrici.Text = "";
            }
            else
                if (textBox5Matrici.Text != "(n)")
                {
                    textBox5Matrici.Select(0, textBox5Matrici.Text.Length);
                }
        }

        private void textBox5_LeaveMatrici(object sender, EventArgs e)
        {
            if (textBox5Matrici.Text == "")
            {
                textBox5Matrici.Text = "(n)";
            }
        }

        private void textBox3_LeaveMatrici(object sender, EventArgs e)
        {
            if (textBox3Matrici.Text == "")
            {
                textBox3Matrici.Text = "(k)";
            }
        }

        private void textBox4_LeaveMatrici(object sender, EventArgs e)
        {
            if (textBox4Matrici.Text == "")
            {
                textBox4Matrici.Text = "(n)";
            }
        }

        private void textBox2_LeaveMatrici(object sender, EventArgs e)
        {
            if (textBox2Matrici.Text == "")
            {
                textBox2Matrici.Text = "(n)";
            }
        }

        private void textBox1_LeaveMatrici(object sender, EventArgs e)
        {
            if (textBox1Matrici.Text == "")
            {
                textBox1Matrici.Text = "(k)";
            }
        }

        private void button4_ClickMatrici(object sender, EventArgs e)
        {
            try
            {
                if (last1Matrici != 0)
                {
                    for (int i = 0; i <= last1Matrici; i++)
                    {
                        lb1Matrici[i].Hide();
                    }
                    last1Matrici = 0;
                }
            }
            catch
            {
            }
        }

        private void button5_ClickMatrici(object sender, EventArgs e)
        {
            try
            {
                if (last2Matrici != 0)
                {
                    for (int i = 0; i <= last2Matrici; i++)
                    {
                        lb2Matrici[i].Hide();
                    }
                    last2Matrici = 0;
                }
            }
            catch
            {
            }
        }

        private void textBox3_ClickMatrici(object sender, EventArgs e)
        {
            if (textBox3Matrici.Text == "(k)")
            {
                textBox3Matrici.Text = "";
            }
            else
                if (textBox3Matrici.Text != "(k)")
                {
                    textBox3Matrici.Select(0, textBox3Matrici.Text.Length);
                }
        }

        private void textBox4_ClickMatrici(object sender, EventArgs e)
        {
            if (textBox4Matrici.Text == "(n)")
            {
                textBox4Matrici.Text = "";
            }
            else
                if (textBox4Matrici.Text != "(n)")
                {
                    textBox4Matrici.Select(0, textBox4Matrici.Text.Length);
                }
        }



    }
}
