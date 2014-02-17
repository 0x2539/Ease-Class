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
    public partial class Triunghi : Form
    {

        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Triunghi));

        //PictureBox[] pbTriunghi = new PictureBox[100];
        public Triunghi()
        {
            Hide();
            InitializeComponent();
            Show();
        }

        private void button1_ClickTriunghi(object sender, EventArgs e)
        {
            bool tr = false;
            string u = "qwertyuiopasfdghjklzxcvbnm";
            for (int o = 0; o < textBox1TriunghiAB.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox1TriunghiAB.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            for (int o = 0; o < textBox2TriunghiBC.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox2TriunghiBC.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            for (int o = 0; o < textBox3TriunghiCA.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox3TriunghiCA.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            if (tr == true)
            {
                MessageBox.Show("Introduceti numai numere!");
            }
            if(true==false)
            if (textBox1TriunghiAB.Text != "" && textBox2TriunghiBC.Text != "" && textBox3TriunghiCA.Text != "")
            {
                label4Triunghi.Text = (Convert.ToDouble(textBox1TriunghiAB.Text) + Convert.ToDouble(textBox2TriunghiBC.Text) + Convert.ToDouble(textBox3TriunghiCA.Text)).ToString();
                label5Triunghi.Text = (Convert.ToDouble(label4Triunghi.Text) / 2).ToString();
                label6Triunghi.Text = HeronTriunghi(Convert.ToDouble(textBox1TriunghiAB.Text), Convert.ToDouble(textBox2TriunghiBC.Text), Convert.ToDouble(textBox3TriunghiCA.Text)).ToString();

                label10Triunghi.Text = textBox1TriunghiAB.Text;
                label11Triunghi.Text = textBox2TriunghiBC.Text;
                label12Triunghi.Text = textBox3TriunghiCA.Text;

                label4Triunghi.Show();
                label5Triunghi.Show();
                label6Triunghi.Show();
                label10Triunghi.Show();
                label11Triunghi.Show();
                label12Triunghi.Show();
            }
            else
                if ((textBox1TriunghiAB.Text == "" && textBox2TriunghiBC.Text == "" && textBox3TriunghiCA.Text == "") ||
                        (textBox1TriunghiAB.Text == "0" && textBox2TriunghiBC.Text == "0" && textBox3TriunghiCA.Text == "0"))
                {
                    MessageBox.Show("Introduceți toate datele!");
                }
        }

        public static double arieTriunghi(double x1, double y1, double x2, double y2, double x3, double y3)//(Point A, Point B, Point C)
        {
            return Convert.ToDouble(Math.Abs((x1 * y2) + (x2 * y3) + (x3 * y1) - (y2 * x3) - (y3 * x1) - (y1 * x2))) / 2.0;
        }

        public static double HeronTriunghi(double A, double B, double C)
        {
            double p, a, b, c;
            p = (A + B + C) / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public static double distantaTriunghi(double x1, double y1, double x2, double y2)//(Point A, Point B)
        {
            return Math.Round(Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)), 2);
        }

        int pozTriunghi = -1;

        private void button3_ClickTriunghi(object sender, EventArgs e)
        {
            bool tr = false;
            string u = "qwertyuiopasfdghjklzxcvbnm";
            for (int o = 0; o < textBox4TriunghiX1.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox4TriunghiX1.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }

            for (int o = 0; o < textBox5TriunghiY1.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox5TriunghiY1.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            for (int o = 0; o < textBox6TriunghiX2.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox6TriunghiX2.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            for (int o = 0; o < textBox7TriunghiY2.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox7TriunghiY2.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            for (int o = 0; o < textBox8TriunghiX3.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox8TriunghiX3.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            for (int o = 0; o < textBox9TriunghiY3.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox9TriunghiY3.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            
            if (tr == true)
            {
                MessageBox.Show("Itroduceti numai numere!");
            }
            if (tr == false)
            {
                if ((textBox4TriunghiX1.Text == "0" && textBox5TriunghiY1.Text == "0" && textBox6TriunghiX2.Text == "0" &&
                       textBox7TriunghiY2.Text == "0" && textBox8TriunghiX3.Text == "0" && textBox9TriunghiY3.Text == "0") ||
                   (textBox4TriunghiX1.Text == "(x)" || textBox5TriunghiY1.Text == "(y)" || textBox6TriunghiX2.Text == "(x)" ||
                           textBox7TriunghiY2.Text == "(y)" || textBox8TriunghiX3.Text == "(x)" || textBox9TriunghiY3.Text == "(y)"))
                {
                    MessageBox.Show("Introduceți toate datele!");
                }
                else
                    if (textBox4TriunghiX1.Text != "" && textBox5TriunghiY1.Text != "" && textBox6TriunghiX2.Text != "" &&
                            textBox7TriunghiY2.Text != "" && textBox8TriunghiX3.Text != "" && textBox9TriunghiY3.Text != "" &&
                        textBox4TriunghiX1.Text != "(x)" && textBox5TriunghiY1.Text != "(y)" && textBox6TriunghiX2.Text != "(x)" &&
                            textBox7TriunghiY2.Text != "(y)" && textBox8TriunghiX3.Text != "(x)" && textBox9TriunghiY3.Text != "(y)")
                    {
                        label36Triunghi.Show();
                        label35Triunghi.Show();
                        label32Triunghi.Show();


                        double xa1 = Convert.ToDouble(textBox5TriunghiY1.Text) - Convert.ToDouble(textBox7TriunghiY2.Text);
                        a1Triunghi.Text = xa1.ToString() + 'x';
                        double xb1 = Convert.ToDouble(textBox6TriunghiX2.Text) - Convert.ToDouble(textBox4TriunghiX1.Text);
                        b1Triunghi.Text = xb1.ToString();
                        double xc1 = Convert.ToDouble(textBox4TriunghiX1.Text) * Convert.ToDouble(textBox7TriunghiY2.Text) - Convert.ToDouble(textBox5TriunghiY1.Text) * Convert.ToDouble(textBox6TriunghiX2.Text);
                        c1Triunghi.Text = xc1.ToString();
                        a1Triunghi.Show();

                        if (b1Triunghi.Text[0] == '-')
                        {
                            a1Triunghi.Text += " - " + b1Triunghi.Text + 'y';

                            if (c1Triunghi.Text[0] == '-')
                            {
                                a1Triunghi.Text += " - " + c1Triunghi.Text + " = 0";
                            }
                            else
                            {
                                a1Triunghi.Text += " + " + c1Triunghi.Text + " = 0";
                            }
                        }
                        else
                        {
                            a1Triunghi.Text += " + " + b1Triunghi.Text + 'y';

                            if (c1Triunghi.Text[0] == '-')
                            {
                                a1Triunghi.Text += " - " + c1Triunghi.Text + " = 0";
                            }
                            else
                            {
                                a1Triunghi.Text += " + " + c1Triunghi.Text + " = 0";
                            }
                        }

                        double xa2 = Convert.ToDouble(textBox7TriunghiY2.Text) - Convert.ToDouble(textBox9TriunghiY3.Text);
                        a2Triunghi.Text = xa2.ToString() + 'x';
                        double xb2 = Convert.ToDouble(textBox8TriunghiX3.Text) - Convert.ToDouble(textBox6TriunghiX2.Text);
                        b2Triunghi.Text = xb2.ToString();
                        double xc2 = Convert.ToDouble(textBox6TriunghiX2.Text) * Convert.ToDouble(textBox9TriunghiY3.Text) - Convert.ToDouble(textBox7TriunghiY2.Text) * Convert.ToDouble(textBox8TriunghiX3.Text);
                        c2Triunghi.Text = xc2.ToString();
                        a2Triunghi.Show();


                        if (b2Triunghi.Text[0] == '-')
                        {
                            a2Triunghi.Text += " - " + b2Triunghi.Text + 'y';

                            if (c2Triunghi.Text[0] == '-')
                            {
                                a2Triunghi.Text += " - " + c2Triunghi.Text + " = 0";
                            }
                            else
                            {
                                a2Triunghi.Text += " + " + c2Triunghi.Text + " = 0";
                            }
                        }
                        else
                        {
                            a2Triunghi.Text += " + " + b2Triunghi.Text + 'y';

                            if (c2Triunghi.Text[0] == '-')
                            {
                                a2Triunghi.Text += " - " + c2Triunghi.Text + " = 0";
                            }
                            else
                            {
                                a2Triunghi.Text += " + " + c2Triunghi.Text + " = 0";
                            }
                        }


                        double xa3 = Convert.ToDouble(textBox5TriunghiY1.Text) - Convert.ToDouble(textBox9TriunghiY3.Text);
                        a3Triunghi.Text = xa3.ToString() + 'x';
                        double xb3 = Convert.ToDouble(textBox8TriunghiX3.Text) - Convert.ToDouble(textBox4TriunghiX1.Text);
                        b3Triunghi.Text = xb3.ToString();
                        double xc3 = Convert.ToDouble(textBox4TriunghiX1.Text) * Convert.ToDouble(textBox9TriunghiY3.Text) - Convert.ToDouble(textBox5TriunghiY1.Text) * Convert.ToDouble(textBox8TriunghiX3.Text);
                        c3Triunghi.Text = xc3.ToString();
                        a3Triunghi.Show();


                        if (b3Triunghi.Text[0] == '-')
                        {
                            a3Triunghi.Text += " - " + b3Triunghi.Text + 'y';

                            if (c3Triunghi.Text[0] == '-')
                            {
                                a3Triunghi.Text += " - " + c3Triunghi.Text + " = 0";
                            }
                            else
                            {
                                a3Triunghi.Text += " + " + c3Triunghi.Text + " = 0";
                            }
                        }
                        else
                        {
                            a3Triunghi.Text += " + " + b3Triunghi.Text + 'y';

                            if (c3Triunghi.Text[0] == '-')
                            {
                                a3Triunghi.Text += " - " + c3Triunghi.Text + " = 0";
                            }
                            else
                            {
                                a3Triunghi.Text += " + " + c3Triunghi.Text + " = 0";
                            }
                        }


                        label32Triunghi.Text = Convert.ToDouble(xa1 * Convert.ToDouble(textBox4TriunghiX1.Text) + xb1 * Convert.ToDouble(textBox5TriunghiY1.Text)).ToString();
                        label35Triunghi.Text = Convert.ToDouble(xa2 * Convert.ToDouble(textBox6TriunghiX2.Text) + xb2 * Convert.ToDouble(textBox7TriunghiY2.Text)).ToString();
                        label36Triunghi.Text = Convert.ToDouble(xa3 * Convert.ToDouble(textBox8TriunghiX3.Text) + xb3 * Convert.ToDouble(textBox9TriunghiY3.Text)).ToString();

                        label49Triunghi.Text = ((-1) * (xa1 / xb1)).ToString();
                        label50Triunghi.Text = ((-1) * (xa2 / xb2)).ToString();
                        label51Triunghi.Text = ((-1) * (xa3 / xb3)).ToString();
                        label49Triunghi.Show();
                        label50Triunghi.Show();
                        label51Triunghi.Show();


                        //textBox10.Location = new Point(Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));
                        //textBox11.Location = new Point(Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text));
                        //textBox12.Location = new Point(Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox9.Text));
                        label4Triunghi.Text = (distantaTriunghi(Convert.ToDouble(textBox4TriunghiX1.Text), Convert.ToDouble(textBox5TriunghiY1.Text), Convert.ToDouble(textBox6TriunghiX2.Text), Convert.ToDouble(textBox7TriunghiY2.Text)) +
                                        distantaTriunghi(Convert.ToDouble(textBox4TriunghiX1.Text), Convert.ToDouble(textBox5TriunghiY1.Text), Convert.ToDouble(textBox8TriunghiX3.Text), Convert.ToDouble(textBox9TriunghiY3.Text)) +
                                        distantaTriunghi(Convert.ToDouble(textBox6TriunghiX2.Text), Convert.ToDouble(textBox7TriunghiY2.Text), Convert.ToDouble(textBox8TriunghiX3.Text), Convert.ToDouble(textBox9TriunghiY3.Text))).ToString();
                        label6Triunghi.Text = (arieTriunghi(Convert.ToDouble(textBox4TriunghiX1.Text), Convert.ToDouble(textBox5TriunghiY1.Text), Convert.ToDouble(textBox6TriunghiX2.Text), Convert.ToDouble(textBox7TriunghiY2.Text), Convert.ToDouble(textBox8TriunghiX3.Text), Convert.ToDouble(textBox9TriunghiY3.Text))).ToString();
                        double x;
                        x = (double)(1.0 / 3);
                        label5Triunghi.Text = (Convert.ToDouble(label4Triunghi.Text) / 2).ToString();

                        label10Triunghi.Text = distantaTriunghi(Convert.ToDouble(textBox4TriunghiX1.Text), Convert.ToDouble(textBox5TriunghiY1.Text), Convert.ToDouble(textBox6TriunghiX2.Text), Convert.ToDouble(textBox7TriunghiY2.Text)).ToString();
                        label11Triunghi.Text = distantaTriunghi(Convert.ToDouble(textBox4TriunghiX1.Text), Convert.ToDouble(textBox5TriunghiY1.Text), Convert.ToDouble(textBox8TriunghiX3.Text), Convert.ToDouble(textBox9TriunghiY3.Text)).ToString();
                        label12Triunghi.Text = distantaTriunghi(Convert.ToDouble(textBox6TriunghiX2.Text), Convert.ToDouble(textBox7TriunghiY2.Text), Convert.ToDouble(textBox8TriunghiX3.Text), Convert.ToDouble(textBox9TriunghiY3.Text)).ToString();

                        label4Triunghi.Show();
                        label5Triunghi.Show();
                        label6Triunghi.Show();
                        label10Triunghi.Show();
                        label11Triunghi.Show();
                        label12Triunghi.Show();
                    }

            }
        }

        private void button4_ClickTriunghi(object sender, EventArgs e)
        {
            bool tr = false;
            string u = "qwertyuiopasfdghjklzxcvbnm";
            for (int o = 0; o < textBox4TriunghiX1.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox4TriunghiX1.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }

            for (int o = 0; o < textBox5TriunghiY1.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox5TriunghiY1.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            for (int o = 0; o < textBox6TriunghiX2.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox6TriunghiX2.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            for (int o = 0; o < textBox7TriunghiY2.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox7TriunghiY2.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            for (int o = 0; o < textBox8TriunghiX3.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox8TriunghiX3.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            for (int o = 0; o < textBox9TriunghiY3.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox9TriunghiY3.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }

            if (tr == true)
            {
                MessageBox.Show("Itroduceti numai numere!");
            }
            if (tr == false)
            {
                if ((textBox4TriunghiX1.Text == "(x)" || textBox5TriunghiY1.Text == "(y)" || textBox6TriunghiX2.Text == "(x)" ||
                           textBox7TriunghiY2.Text == "(y)" || textBox8TriunghiX3.Text == "(x)" || textBox9TriunghiY3.Text == "(y)") ||
                  (textBox4TriunghiX1.Text == "0" && textBox5TriunghiY1.Text == "0" && textBox6TriunghiX2.Text == "0" &&
                           textBox7TriunghiY2.Text == "0" && textBox8TriunghiX3.Text == "0" && textBox9TriunghiY3.Text == "0"))
                {
                    MessageBox.Show("Introduceți coordonatele tuturor punctelor!");
                }
                else
                {
                    Desen1 de = new Desen1(textBox4TriunghiX1.Text, textBox6TriunghiX2.Text, textBox8TriunghiX3.Text, textBox5TriunghiY1.Text, textBox7TriunghiY2.Text, textBox9TriunghiY3.Text);
                    de.Show();
                }
            }
        }

        private void triunghi_Load(object sender, EventArgs e)
        {
            Hide();
            Show();
        }

        private void button2_ClickTriunghi(object sender, EventArgs e)
        {
            textBox1TriunghiAB.Clear();
            textBox2TriunghiBC.Clear();
            textBox2TriunghiBC.Clear();
        }

        private void button5_ClickTriunghi(object sender, EventArgs e)
        {
            textBox4TriunghiX1.Text = "(x)";
            textBox5TriunghiY1.Text = "(y)";
            textBox6TriunghiX2.Text = "(x)";

            textBox7TriunghiY2.Text = "(y)";
            textBox8TriunghiX3.Text = "(x)";
            textBox9TriunghiY3.Text = "(y)";
        }

        private void textBox4_ClickTriunghi(object sender, EventArgs e)
        {
            if (textBox4TriunghiX1.Text == "(x)")
            {
                textBox4TriunghiX1.Text = "";
            }
            else
                if (textBox4TriunghiX1.Text != "(x)")
                {
                    textBox4TriunghiX1.Select(0, textBox4TriunghiX1.Text.Length);
                }
        }

        private void textBox6_ClickTriunghi(object sender, EventArgs e)
        {
            if (textBox6TriunghiX2.Text == "(x)")
            {
                textBox6TriunghiX2.Text = "";
            }
            else
                if (textBox6TriunghiX2.Text != "(x)")
                {
                    textBox6TriunghiX2.Select(0, textBox6TriunghiX2.Text.Length);
                }
        }

        private void textBox9_ClickTriunghi(object sender, EventArgs e)
        {
            if (textBox9TriunghiY3.Text == "(y)")
            {
                textBox9TriunghiY3.Text = "";
            }
            else
                if (textBox9TriunghiY3.Text != "")
                    if (textBox9TriunghiY3.Text != "(y)")
                    {
                        textBox9TriunghiY3.Select(0, textBox9TriunghiY3.Text.Length);
                    }
        }

        private void textBox7_ClickTriunghi(object sender, EventArgs e)
        {
            if (textBox7TriunghiY2.Text == "(y)")
            {
                textBox7TriunghiY2.Text = "";
            }
            else
                if (textBox7TriunghiY2.Text != "(y)")
                {
                    textBox7TriunghiY2.Select(0, textBox7TriunghiY2.Text.Length);
                }

        }

        private void textBox5_ClickTriunghi(object sender, EventArgs e)
        {
            if (textBox5TriunghiY1.Text == "(y)")
            {
                textBox5TriunghiY1.Text = "";
            }
            else
                if (textBox5TriunghiY1.Text != "(y)")
                {
                    textBox5TriunghiY1.Select(0, textBox5TriunghiY1.Text.Length);
                }
        }

        private void textBox8_ClickTriunghi(object sender, EventArgs e)
        {
            if (textBox8TriunghiX3.Text == "(x)")
            {
                textBox8TriunghiX3.Text = "";
            }
            else
                if (textBox8TriunghiX3.Text != "(x)")
                {
                    textBox8TriunghiX3.Select(0, textBox8TriunghiX3.Text.Length);
                }
        }

        private void textBox8_LeaveTriunghi(object sender, EventArgs e)
        {
            if (textBox8TriunghiX3.Text == "")
            {
                textBox8TriunghiX3.Text = "(x)";
            }
        }

        private void textBox6_LeaveTriunghi(object sender, EventArgs e)
        {
            if (textBox6TriunghiX2.Text == "")
            {
                textBox6TriunghiX2.Text = "(x)";
            }
        }

        private void textBox4_LeaveTriunghi(object sender, EventArgs e)
        {
            if (textBox4TriunghiX1.Text == "")
            {
                textBox4TriunghiX1.Text = "(x)";
            }
        }

        private void textBox5_LeaveTriunghi(object sender, EventArgs e)
        {
            if (textBox5TriunghiY1.Text == "")
            {
                textBox5TriunghiY1.Text = "(y)";
            }
        }

        private void textBox7_LeaveTriunghi(object sender, EventArgs e)
        {
            if (textBox7TriunghiY2.Text == "")
            {
                textBox7TriunghiY2.Text = "(y)";
            }
        }

        private void textBox9_LeaveTriunghi(object sender, EventArgs e)
        {
            if (textBox9TriunghiY3.Text == "")
            {
                textBox9TriunghiY3.Text = "(y)";
            }
        }


    }
}


