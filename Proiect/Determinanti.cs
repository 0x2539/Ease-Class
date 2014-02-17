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
    public partial class Determinanti : Form
    {
        Graphics g;
        Pen pen = new Pen(Color.Black);

        public Determinanti()
        {
            InitializeComponent();
            timer1Determinanti.Start();

            button2.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x1 = Convert.ToDouble(textBox1Determinanti.Text);
            double y1 = Convert.ToDouble(textBox2Determinanti.Text);
            double z1 = Convert.ToDouble(textBox3Determinanti.Text);
            double x2 = Convert.ToDouble(textBox4Determinanti.Text);
            double y2 = Convert.ToDouble(textBox5Determinanti.Text);
            double z2 = Convert.ToDouble(textBox6Determinanti.Text);
            double x3 = Convert.ToDouble(textBox7Determinanti.Text);
            double y3 = Convert.ToDouble(textBox8Determinanti.Text);
            double z3 = Convert.ToDouble(textBox9Determinanti.Text);
            double rasp = 0;

            bool tr = false;
            string u = "qwertyuiopasfdghjklzxcvbnm";
            for (int o = 0; o < textBox1Determinanti.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox1Determinanti.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }

            for (int o = 0; o < textBox2Determinanti.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox2Determinanti.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }

            for (int o = 0; o < textBox3Determinanti.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox3Determinanti.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }

            for (int o = 0; o < textBox4Determinanti.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox4Determinanti.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }

            for (int o = 0; o < textBox5Determinanti.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox5Determinanti.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }

            for (int o = 0; o < textBox6Determinanti.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox6Determinanti.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }

            for (int o = 0; o < textBox7Determinanti.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox7Determinanti.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }

            for (int o = 0; o < textBox8Determinanti.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox8Determinanti.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }

            for (int o = 0; o < textBox9Determinanti.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox9Determinanti.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }

            if (tr == false)
            {
                rasp = x1 * y2 * z3 + x2 * y3 * z1 + x3 * y1 * z2 - z1 * x3 * y2 - z2 * y3 * x1 - z3 * x2 * y1;
                label3Determinanti.Text = rasp.ToString();
            }
            else
            {
                label3Determinanti.Text = "Introduceti numai numere!";
            }
        }

        private void Determinanti_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.DrawLine(pen, textBox1Determinanti.Location.X - 10, textBox1Determinanti.Location.Y - 10,
                textBox1Determinanti.Location.X - 10, textBox1Determinanti.Location.Y + 80);
            g.DrawLine(pen, textBox1Determinanti.Location.X + 138, textBox1Determinanti.Location.Y - 10,
                textBox1Determinanti.Location.X + 138, textBox1Determinanti.Location.Y + 80);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button2.PerformClick();
            timer1Determinanti.Stop();
        }

        private void Determinanti_Load(object sender, EventArgs e)
        {

        }

    }
}
