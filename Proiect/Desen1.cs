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
    public partial class Desen1 : Form
    {

        public Graphics line1;
        public Pen myPen1;

        public Graphics line2;
        public Pen myPen2;

        public Graphics line3;
        public Pen myPen3;

        public Graphics line4;
        public SolidBrush myPen4;

        public Graphics line5;
        public SolidBrush myPen5;
        public SolidBrush myPen6;
        public SolidBrush myPen7;
        public SolidBrush myPen8;


        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Triunghi));

        int poz = -1, x = 0, nr, nr1, nr2, y, pre1, pre2, pre3, numar, anterior = 0, x11, x22, x33, y11, y22, y33;
        double nr3;
        string a = "", b = "", s = "", s2 = "";
        double putere, putere2;

        PictureBox[] pb = new PictureBox[201];

        PictureBox[] pb2 = new PictureBox[201];
        public Desen1(string x1, string x2, string x3, string y1, string y2, string y3)
        {
            InitializeComponent();

            myPen1 = new Pen(Color.Black);
            line1 = Sistemul.CreateGraphics();

            myPen2 = new Pen(Color.Red);
            line2 = Sistemul.CreateGraphics();

            myPen3 = new Pen(Color.Green);
            line3 = Sistemul.CreateGraphics();

            myPen4 = new SolidBrush(Color.Blue);
            line4 = Sistemul.CreateGraphics();

            myPen5 = new SolidBrush(Color.Red);
            line5 = Sistemul.CreateGraphics();

            myPen6 = new SolidBrush(Color.Green);
            myPen7 = new SolidBrush(Color.Blue);
            myPen8 = new SolidBrush(Color.Red);

            //Triunghi tr = new Triunghi();

            pictureBox2.BringToFront();
            pictureBox3.BringToFront();
            pictureBox4.BringToFront();
            pictureBox5.BringToFront();
            pictureBox6.BringToFront();
            pictureBox7.BringToFront();

            pb[0] = new PictureBox();
            this.pb[0].Image = global::Proiect.Properties.Resources.cm;
            this.pb[0].Location = new System.Drawing.Point(pictureBox2.Location.X, pictureBox2.Location.Y);
            this.pb[0].Name = "pb" + 3;
            this.pb[0].Size = new System.Drawing.Size(pictureBox2.Size.Width, pictureBox2.Size.Height);
            this.pb[0].TabIndex = 111;
            this.pb[0].TabStop = false;
            Controls.Add(pb[0]);
            pb[0].BringToFront();

            pb[1] = new PictureBox();
            this.pb[1].Image = global::Proiect.Properties.Resources.cm0_1;
            this.pb[1].Location = new System.Drawing.Point(pictureBox4.Location.X, pictureBox4.Location.Y);
            this.pb[1].Name = "pb" + 3;
            this.pb[1].Size = new System.Drawing.Size(pictureBox4.Size.Width, pictureBox4.Size.Height);
            this.pb[1].TabIndex = 111;
            this.pb[1].TabStop = false;
            Controls.Add(pb[1]);
            pb[1].BringToFront();

            pb[2] = new PictureBox();
            this.pb[2].Image = global::Proiect.Properties.Resources.cm0_1;
            this.pb[2].Location = new System.Drawing.Point(pictureBox4.Location.X + 3, pictureBox4.Location.Y);
            this.pb[2].Name = "pb" + 3;
            this.pb[2].Size = new System.Drawing.Size(pictureBox4.Size.Width, pictureBox4.Size.Height);
            this.pb[2].TabIndex = 111;
            this.pb[2].TabStop = false;
            Controls.Add(pb[2]);

            for (int i = 3; i <= 100; i++)
            {
                pb[i] = new PictureBox();
                this.pb[i].Location = new System.Drawing.Point(pb[i - 1].Location.X + 3, pb[i - 1].Location.Y);
                this.pb[i].Name = "pb" + i;
                this.pb[i].Size = new System.Drawing.Size(3, 32);
                this.pb[i].TabIndex = 111;
                this.pb[i].TabStop = false;

                if (i % 5 != 0 && i % 10 != 0)
                {
                    this.pb[i].Image = global::Proiect.Properties.Resources.cm0_1;
                }
                else
                    if (i % 5 == 0 && i % 10 != 0)
                    {
                        this.pb[i].Image = global::Proiect.Properties.Resources.cm0_5;
                    }
                    else
                        if (i % 10 == 0)
                        {
                            this.pb[i].Image = global::Proiect.Properties.Resources.cm;
                        }
                Controls.Add(pb[i]);
                pb[i].BringToFront();
            }

            pb2[0] = new PictureBox();
            this.pb2[0].Image = global::Proiect.Properties.Resources.cm90;
            this.pb2[0].Location = new System.Drawing.Point(pictureBox5.Location.X, pictureBox5.Location.Y);
            this.pb2[0].Name = "pb2" + 103;
            this.pb2[0].Size = new System.Drawing.Size(32, 3);
            this.pb2[0].TabIndex = 111;
            this.pb2[0].TabStop = false;
            Controls.Add(pb2[0]);
            pb2[0].BringToFront();

            pb2[1] = new PictureBox();
            this.pb2[1].Image = global::Proiect.Properties.Resources.cm900_1;
            this.pb2[1].Location = new System.Drawing.Point(pictureBox7.Location.X + 12, pictureBox7.Location.Y);
            this.pb2[1].Name = "pb2" + 104;
            this.pb2[1].Size = new System.Drawing.Size(32, 3);
            this.pb2[1].TabIndex = 111;
            this.pb2[1].TabStop = false;
            Controls.Add(pb2[1]);
            pb2[1].BringToFront();

            pb2[2] = new PictureBox();
            this.pb2[2].Image = global::Proiect.Properties.Resources.cm900_1;
            this.pb2[2].Location = new System.Drawing.Point(pictureBox7.Location.X + 12, pictureBox7.Location.Y - 3);
            this.pb2[2].Name = "pb2" + 105;
            this.pb2[2].Size = new System.Drawing.Size(32, 3);
            this.pb2[2].TabIndex = 111;
            this.pb2[2].TabStop = false;
            Controls.Add(pb2[2]);
            pb2[2].BringToFront();

            for (int i = 3; i <= 100; i++)
            {
                pb2[i] = new PictureBox();
                this.pb2[i].Location = new System.Drawing.Point(pictureBox7.Location.X, pb2[i - 1].Location.Y - 3);
                this.pb2[i].Name = "pb2" + i;
                this.pb2[i].Size = new System.Drawing.Size(32, 3);
                this.pb2[i].TabIndex = 111;
                this.pb2[i].TabStop = false;

                if (i % 5 != 0 && i % 10 != 0)
                {
                    this.pb2[i].Location = new System.Drawing.Point(pictureBox7.Location.X + 12, pb2[i - 1].Location.Y - 3);
                    this.pb2[i].Image = global::Proiect.Properties.Resources.cm900_1;
                }
                else
                    if (i % 5 == 0 && i % 10 != 0)
                    {
                        this.pb2[i].Image = global::Proiect.Properties.Resources.cm900_5;
                        this.pb2[i].Location = new Point(pictureBox7.Location.X + 4, this.pb2[i].Location.Y);
                    }
                    else
                        if (i % 10 == 0)
                        {
                            this.pb2[i].Image = global::Proiect.Properties.Resources.cm90;
                        }
                Controls.Add(pb2[i]);
                pb2[i].BringToFront();
            }





            if (poz != -1)
            {
                if (poz % 5 != 0)
                {
                    this.pb[poz].Image = global::Proiect.Properties.Resources.cm0_1;
                }
                else
                    if (poz % 5 == 0 && poz % 10 != 0)
                    {
                        this.pb[poz].Image = global::Proiect.Properties.Resources.cm0_5;
                    }
                    else
                        if (poz % 10 == 0)
                        {
                            this.pb[poz].Image = global::Proiect.Properties.Resources.cm;
                        }
            }

            x = 0;
            s = x1;
            s2 = "";
            s = s.Replace(',', '.');
            y = s.IndexOf('.');
            nr = 0;
            pre1 = 0;
            pre2 = 0;
            pre3 = 0;

            if (y != -1)
            {
                for (int i = 0; i < y; i++)
                {
                    s2 += s[i];
                }
                pre1 = Convert.ToInt32(s2.ToString());
                s2 = "";
                for (int i = y + 1; i < s.Length; i++)
                {
                    s2 += s[i];
                }
                pre2 = Convert.ToInt32(s2.ToString());
                string lla;
                if (pre1 != 0)
                {
                    lla = pre1.ToString() + pre2.ToString();
                    nr = Convert.ToInt32(lla);
                }
                else
                {
                    lla = pre2.ToString();
                    x = 1;
                    nr = Convert.ToInt32(lla);
                }
            }
            else
                if (y == -1)
                {
                    pre1 = Convert.ToInt32(s);
                    pre2 = 0;
                    nr = pre1;
                    //textBox13.Text = nr.ToString();
                }
            a = nr.ToString();
            b = "";
            nr1 = nr;
            nr2 = nr;
            putere = Math.Pow(10, a.Length - 1);

            nr1 = nr / Convert.ToInt32(putere);
            nr2 = nr % Convert.ToInt32(putere);

            b = nr2.ToString();

            putere2 = Math.Pow(10, b.Length - 1);

            b = (nr2 / Convert.ToInt32(putere2)).ToString() + '.' + (nr2 % Convert.ToInt32(putere2)).ToString();

            nr3 = Math.Round(Convert.ToDouble(b));
            numar = nr1 * 10 + Convert.ToInt32(nr3);

            if (x == 0)
            {
                if (numar % 5 != 0)
                {
                    this.pb[numar].Image = global::Proiect.Properties.Resources.cm0_1red;
                    poz = numar;
                    x11 = numar;
                }
                else
                    if (numar % 5 == 0 && numar % 10 != 0)
                    {
                        this.pb[numar].Image = global::Proiect.Properties.Resources.cm0_5red;
                        poz = numar;
                        x11 = numar;
                    }
                    else
                        if (numar % 10 == 0)
                        {
                            this.pb[numar].Image = global::Proiect.Properties.Resources.cmred;
                            poz = numar;
                            x11 = numar;
                        }
            }
            else
                if (x != 0)
                {
                    string ff = (numar / 10).ToString() + '.' + (numar % 10).ToString();
                    double lala = Math.Round(Convert.ToDouble(ff));
                    lala = Convert.ToInt32(lala);
                    if (lala % 5 != 0)
                    {
                        this.pb[Convert.ToInt32(lala)].Image = global::Proiect.Properties.Resources.cm0_1red;
                        x1= numar.ToString();
                        poz = Convert.ToInt32(lala);
                        x11 = Convert.ToInt32(lala);
                    }
                    else
                        if (lala % 5 == 0)
                        {
                            this.pb[Convert.ToInt32(lala)].Image = global::Proiect.Properties.Resources.cm0_5red;
                            x1= numar.ToString();
                            poz = Convert.ToInt32(lala);
                            x11 = Convert.ToInt32(lala);
                        }
                }

            x = 0;
            s = x2;
            s2 = "";
            s = s.Replace(',', '.');
            y = s.IndexOf('.');
            nr = 0;
            pre1 = 0;
            pre2 = 0;
            pre3 = 0;

            if (y != -1)
            {
                for (int i = 0; i < y; i++)
                {
                    s2 += s[i];
                }
                pre1 = Convert.ToInt32(s2.ToString());
                s2 = "";
                for (int i = y + 1; i < s.Length; i++)
                {
                    s2 += s[i];
                }
                pre2 = Convert.ToInt32(s2.ToString());
                string lla;
                if (pre1 != 0)
                {
                    lla = pre1.ToString() + pre2.ToString();
                    nr = Convert.ToInt32(lla);
                }
                else
                {
                    lla = pre2.ToString();
                    x = 1;
                    nr = Convert.ToInt32(lla);
                }
            }
            else
                if (y == -1)
                {
                    pre1 = Convert.ToInt32(s);
                    pre2 = 0;
                    nr = pre1;
                }
            a = nr.ToString();
            b = "";
            nr1 = nr;
            nr2 = nr;
            putere = Math.Pow(10, a.Length - 1);

            nr1 = nr / Convert.ToInt32(putere);
            nr2 = nr % Convert.ToInt32(putere);

            b = nr2.ToString();

            putere2 = Math.Pow(10, b.Length - 1);

            b = (nr2 / Convert.ToInt32(putere2)).ToString() + '.' + (nr2 % Convert.ToInt32(putere2)).ToString();

            nr3 = Math.Round(Convert.ToDouble(b));
            numar = nr1 * 10 + Convert.ToInt32(nr3);

            if (x == 0)
            {
                if (numar % 5 != 0)
                {
                    this.pb[numar].Image = global::Proiect.Properties.Resources.cm0_1red;
                    poz = numar;
                    x22 = numar;
                }
                else
                    if (numar % 5 == 0 && numar % 10 != 0)
                    {
                        this.pb[numar].Image = global::Proiect.Properties.Resources.cm0_5red;
                        poz = numar;
                        x22 = numar;
                    }
                    else
                        if (numar % 10 == 0)
                        {
                            this.pb[numar].Image = global::Proiect.Properties.Resources.cmred;
                            poz = numar;
                            x22 = numar;
                        }
            }
            else
                if (x != 0)
                {
                    string ff = (numar / 10).ToString() + '.' + (numar % 10).ToString();
                    double lala = Math.Round(Convert.ToDouble(ff));
                    lala = Convert.ToInt32(lala);
                    if (lala % 5 != 0)
                    {
                        this.pb[Convert.ToInt32(lala)].Image = global::Proiect.Properties.Resources.cm0_1red;
                        x2= numar.ToString();
                        poz = Convert.ToInt32(lala);
                        x22 = Convert.ToInt32(lala);
                    }
                    else
                        if (lala % 5 == 0)
                        {
                            this.pb[Convert.ToInt32(lala)].Image = global::Proiect.Properties.Resources.cm0_5red;
                            x2= numar.ToString();
                            poz = Convert.ToInt32(lala);
                            x22 = Convert.ToInt32(lala);
                        }
                }

            x = 0;
            s = x3;
            s2 = "";
            s = s.Replace(',', '.');
            y = s.IndexOf('.');
            nr = 0;
            pre1 = 0;
            pre2 = 0;
            pre3 = 0;

            if (y != -1)
            {
                for (int i = 0; i < y; i++)
                {
                    s2 += s[i];
                }
                pre1 = Convert.ToInt32(s2.ToString());
                s2 = "";
                for (int i = y + 1; i < s.Length; i++)
                {
                    s2 += s[i];
                }
                pre2 = Convert.ToInt32(s2.ToString());
                string lla;
                if (pre1 != 0)
                {
                    lla = pre1.ToString() + pre2.ToString();
                    nr = Convert.ToInt32(lla);
                }
                else
                {
                    lla = pre2.ToString();
                    x = 1;
                    nr = Convert.ToInt32(lla);
                }
            }
            else
                if (y == -1)
                {
                    pre1 = Convert.ToInt32(s);
                    pre2 = 0;
                    nr = pre1;
                }
            a = nr.ToString();
            b = "";
            nr1 = nr;
            nr2 = nr;
            putere = Math.Pow(10, a.Length - 1);

            nr1 = nr / Convert.ToInt32(putere);
            nr2 = nr % Convert.ToInt32(putere);

            b = nr2.ToString();

            putere2 = Math.Pow(10, b.Length - 1);

            b = (nr2 / Convert.ToInt32(putere2)).ToString() + '.' + (nr2 % Convert.ToInt32(putere2)).ToString();

            nr3 = Math.Round(Convert.ToDouble(b));
            numar = nr1 * 10 + Convert.ToInt32(nr3);

            if (x == 0)
            {
                if (numar % 5 != 0)
                {
                    this.pb[numar].Image = global::Proiect.Properties.Resources.cm0_1red;
                    poz = numar;
                    x33 = numar;
                }
                else
                    if (numar % 5 == 0 && numar % 10 != 0)
                    {
                        this.pb[numar].Image = global::Proiect.Properties.Resources.cm0_5red;
                        poz = numar;
                        x33 = numar;
                    }
                    else
                        if (numar % 10 == 0)
                        {
                            this.pb[numar].Image = global::Proiect.Properties.Resources.cmred;
                            poz = numar;
                            x33 = numar;
                        }
            }
            else
                if (x != 0)
                {
                    string ff = (numar / 10).ToString() + '.' + (numar % 10).ToString();
                    double lala = Math.Round(Convert.ToDouble(ff));
                    lala = Convert.ToInt32(lala);
                    if (lala % 5 != 0)
                    {
                        this.pb[Convert.ToInt32(lala)].Image = global::Proiect.Properties.Resources.cm0_1red;
                        x3= numar.ToString();
                        poz = Convert.ToInt32(lala);
                        x33 = Convert.ToInt32(lala);
                    }
                    else
                        if (lala % 5 == 0)
                        {
                            this.pb[Convert.ToInt32(lala)].Image = global::Proiect.Properties.Resources.cm0_5red;
                            x3= numar.ToString();
                            poz = Convert.ToInt32(lala);
                            x33 = Convert.ToInt32(lala);
                        }
                }
            x = 0;
            s = y1;
            s2 = "";
            s = s.Replace(',', '.');
            y = s.IndexOf('.');
            nr = 0;
            pre1 = 0;
            pre2 = 0;
            pre3 = 0;

            if (y != -1)
            {
                for (int i = 0; i < y; i++)
                {
                    s2 += s[i];
                }
                pre1 = Convert.ToInt32(s2.ToString());
                s2 = "";
                for (int i = y + 1; i < s.Length; i++)
                {
                    s2 += s[i];
                }
                pre2 = Convert.ToInt32(s2.ToString());
                string lla;
                if (pre1 != 0)
                {
                    lla = pre1.ToString() + pre2.ToString();
                    nr = Convert.ToInt32(lla);
                }
                else
                {
                    lla = pre2.ToString();
                    x = 1;
                    nr = Convert.ToInt32(lla);
                }
            }
            else
                if (y == -1)
                {
                    pre1 = Convert.ToInt32(s);
                    pre2 = 0;
                    nr = pre1;
                }
            a = nr.ToString();
            b = "";
            nr1 = nr;
            nr2 = nr;
            putere = Math.Pow(10, a.Length - 1);

            nr1 = nr / Convert.ToInt32(putere);
            nr2 = nr % Convert.ToInt32(putere);

            b = nr2.ToString();

            putere2 = Math.Pow(10, b.Length - 1);

            b = (nr2 / Convert.ToInt32(putere2)).ToString() + '.' + (nr2 % Convert.ToInt32(putere2)).ToString();

            nr3 = Math.Round(Convert.ToDouble(b));
            numar = nr1 * 10 + Convert.ToInt32(nr3);

            if (x == 0)
            {
                if (numar % 5 != 0)
                {
                    this.pb2[numar].Image = global::Proiect.Properties.Resources.cm0_1red90;
                    poz = numar;
                    y11 = numar;
                }
                else
                    if (numar % 5 == 0 && numar % 10 != 0)
                    {
                        this.pb2[numar].Image = global::Proiect.Properties.Resources.cm0_5red90;
                        poz = numar;
                        y11 = numar;
                    }
                    else
                        if (numar % 10 == 0)
                        {
                            this.pb2[numar].Image = global::Proiect.Properties.Resources.cmred90;
                            poz = numar;
                            y11 = numar;
                        }
            }
            else
                if (x != 0)
                {
                    string ff = (numar / 10).ToString() + '.' + (numar % 10).ToString();
                    double lala = Math.Round(Convert.ToDouble(ff));
                    lala = Convert.ToInt32(lala);
                    if (lala % 5 != 0)
                    {
                        this.pb2[Convert.ToInt32(lala)].Image = global::Proiect.Properties.Resources.cm0_1red90;
                        y1= numar.ToString();
                        poz = Convert.ToInt32(lala);
                        y11 = Convert.ToInt32(lala);
                    }
                    else
                        if (lala % 5 == 0)
                        {
                            this.pb2[Convert.ToInt32(lala)].Image = global::Proiect.Properties.Resources.cm0_5red90;
                            y1= numar.ToString();
                            poz = Convert.ToInt32(lala);
                            y11 = Convert.ToInt32(lala);
                        }
                }

            x = 0;
            s = y2;
            s2 = "";
            s = s.Replace(',', '.');
            y = s.IndexOf('.');
            nr = 0;
            pre1 = 0;
            pre2 = 0;
            pre3 = 0;

            if (y != -1)
            {
                for (int i = 0; i < y; i++)
                {
                    s2 += s[i];
                }
                pre1 = Convert.ToInt32(s2.ToString());
                s2 = "";
                for (int i = y + 1; i < s.Length; i++)
                {
                    s2 += s[i];
                }
                pre2 = Convert.ToInt32(s2.ToString());
                string lla;
                if (pre1 != 0)
                {
                    lla = pre1.ToString() + pre2.ToString();
                    nr = Convert.ToInt32(lla);
                }
                else
                {
                    lla = pre2.ToString();
                    x = 1;
                    nr = Convert.ToInt32(lla);
                }
            }
            else
                if (y == -1)
                {
                    pre1 = Convert.ToInt32(s);
                    pre2 = 0;
                    nr = pre1;
                }
            a = nr.ToString();
            b = "";
            nr1 = nr;
            nr2 = nr;
            putere = Math.Pow(10, a.Length - 1);

            nr1 = nr / Convert.ToInt32(putere);
            nr2 = nr % Convert.ToInt32(putere);

            b = nr2.ToString();

            putere2 = Math.Pow(10, b.Length - 1);

            b = (nr2 / Convert.ToInt32(putere2)).ToString() + '.' + (nr2 % Convert.ToInt32(putere2)).ToString();

            nr3 = Math.Round(Convert.ToDouble(b));
            numar = nr1 * 10 + Convert.ToInt32(nr3);

            if (x == 0)
            {
                if (numar % 5 != 0)
                {
                    this.pb2[numar].Image = global::Proiect.Properties.Resources.cm0_1red90;
                    poz = numar;
                    y22 = numar;
                }
                else
                    if (numar % 5 == 0 && numar % 10 != 0)
                    {
                        this.pb2[numar].Image = global::Proiect.Properties.Resources.cm0_5red90;
                        poz = numar;
                        y22 = numar;
                    }
                    else
                        if (numar % 10 == 0)
                        {
                            //this.pb2[numar].Location = new Point(this.pb2[numar].Location.X + 40, this.pb2[numar].Location.Y);
                            this.pb2[numar].Image = global::Proiect.Properties.Resources.cmred90;
                            poz = numar;
                            y22 = numar;
                        }
            }
            else
                if (x != 0)
                {
                    string ff = (numar / 10).ToString() + '.' + (numar % 10).ToString();
                    double lala = Math.Round(Convert.ToDouble(ff));
                    lala = Convert.ToInt32(lala);
                    if (lala % 5 != 0)
                    {
                        this.pb2[Convert.ToInt32(lala)].Image = global::Proiect.Properties.Resources.cm0_1red90;
                        y2= numar.ToString();
                        poz = Convert.ToInt32(lala);
                        y22 = Convert.ToInt32(lala);
                    }
                    else
                        if (lala % 5 == 0)
                        {
                            this.pb2[Convert.ToInt32(lala)].Image = global::Proiect.Properties.Resources.cm0_5red90;
                            y2= numar.ToString();
                            poz = Convert.ToInt32(lala);
                            y22 = Convert.ToInt32(lala);
                        }
                }








            x = 0;
            s = y3;
            s2 = "";
            s = s.Replace(',', '.');
            y = s.IndexOf('.');
            nr = 0;
            pre1 = 0;
            pre2 = 0;
            pre3 = 0;

            if (y != -1)
            {
                for (int i = 0; i < y; i++)
                {
                    s2 += s[i];
                }
                pre1 = Convert.ToInt32(s2.ToString());
                s2 = "";
                for (int i = y + 1; i < s.Length; i++)
                {
                    s2 += s[i];
                }
                pre2 = Convert.ToInt32(s2.ToString());
                string lla;
                if (pre1 != 0)
                {
                    lla = pre1.ToString() + pre2.ToString();
                    nr = Convert.ToInt32(lla);
                }
                else
                {
                    lla = pre2.ToString();
                    x = 1;
                    nr = Convert.ToInt32(lla);
                }
            }
            else
                if (y == -1)
                {
                    pre1 = Convert.ToInt32(s);
                    pre2 = 0;
                    nr = pre1;
                }
            a = nr.ToString();
            b = "";
            nr1 = nr;
            nr2 = nr;
            putere = Math.Pow(10, a.Length - 1);

            nr1 = nr / Convert.ToInt32(putere);
            nr2 = nr % Convert.ToInt32(putere);

            b = nr2.ToString();

            putere2 = Math.Pow(10, b.Length - 1);

            b = (nr2 / Convert.ToInt32(putere2)).ToString() + '.' + (nr2 % Convert.ToInt32(putere2)).ToString();

            nr3 = Math.Round(Convert.ToDouble(b));
            numar = nr1 * 10 + Convert.ToInt32(nr3);

            if (x == 0)
            {
                if (numar % 5 != 0)
                {
                    this.pb2[numar].Image = global::Proiect.Properties.Resources.cm0_1red90;
                    poz = numar;
                    y33 = numar;
                }
                else
                    if (numar % 5 == 0 && numar % 10 != 0)
                    {
                        this.pb2[numar].Image = global::Proiect.Properties.Resources.cm0_5red90;
                        poz = numar;
                        y33 = numar;
                    }
                    else
                        if (numar % 10 == 0)
                        {
                            this.pb2[numar].Image = global::Proiect.Properties.Resources.cmred90;
                            poz = numar;
                            y33 = numar;
                        }
            }
            else
                if (x != 0)
                {
                    string ff = (numar / 10).ToString() + '.' + (numar % 10).ToString();
                    double lala = Math.Round(Convert.ToDouble(ff));
                    lala = Convert.ToInt32(lala);
                    if (lala % 5 != 0)
                    {
                        this.pb2[Convert.ToInt32(lala)].Image = global::Proiect.Properties.Resources.cm0_1red90;
                        y3= numar.ToString();
                        poz = Convert.ToInt32(lala);
                        y33 = Convert.ToInt32(lala);
                    }
                    else
                        if (lala % 5 == 0)
                        {
                            this.pb2[Convert.ToInt32(lala)].Image = global::Proiect.Properties.Resources.cm0_5red90;
                            y3= numar.ToString();
                            poz = Convert.ToInt32(lala);
                            y33 = Convert.ToInt32(lala);
                        }
                }




            line1.DrawLine(myPen1, pb[x11].Location.X, pb[y11].Location.Y, pb2[x22].Location.X, pb2[y22].Location.Y);
            line1.DrawLine(myPen2, pb[x11].Location.X, pb[y11].Location.Y, pb2[x33].Location.X, pb2[y33].Location.Y);
            line1.DrawLine(myPen3, pb[x22].Location.X, pb[y22].Location.Y, pb2[x33].Location.X, pb2[y33].Location.Y);



        }

        private void button1_Click(object sender, EventArgs e)
        {

            float[] liniute = { 5, 3, 5, 3 };
            Pen redPen = new Pen(Color.Red);
            Pen bluePen = new Pen(Color.Blue);
            Pen greenPen = new Pen(Color.Green);
            
            redPen.DashPattern = liniute;
            greenPen.DashPattern = liniute;
            bluePen.DashPattern = liniute;

            /*
            int m1 = x11, m2 = x22, m3 = x33, m4 = y11, m5 = y22, m6 = y33;
            while (m1 - 2 >= 0)
            {
                line1.DrawLine(myPen2, pb[x11].Location.X - 69, pb2[m1].Location.Y - 24, pb[x11].Location.X - 69, pb2[m1 - 1].Location.Y - 24);
                m1 = m1 - 2;
            }
            while (m2 - 2 >= 0)
            {
                line1.DrawLine(myPen2, pb[x22].Location.X - 69, pb2[m2].Location.Y - 24, pb[x22].Location.X - 69, pb2[m2 - 1].Location.Y - 24);
                m2 = m2 - 2;
            }
            while (m3 - 2 >= 0)
            {
                line1.DrawLine(myPen2, pb[x33].Location.X - 69, pb2[m3].Location.Y - 24, pb[x33].Location.X - 69, pb2[m3 - 1].Location.Y - 24);
                m3 = m3 - 2;
            }
            while (m4 - 2 >= 0)
            {
                line1.DrawLine(myPen2, pb[m4].Location.X - 69, pb2[y11].Location.Y - 24, pb[m4 - 1].Location.X - 69, pb2[y11].Location.Y - 24);
                m4 = m4 - 2;
            }
            while (m5 - 2 >= 0)
            {
                line1.DrawLine(myPen2, pb[m5].Location.X - 69, pb2[y22].Location.Y - 24, pb[m5 - 1].Location.X - 69, pb2[y22].Location.Y - 24);
                m5 = m5 - 2;
            }
            while (m6 - 2 >= 0)
            {
                line1.DrawLine(myPen2, pb[m6].Location.X - 69, pb2[y33].Location.Y - 24, pb[m6 - 1].Location.X - 69, pb2[y33].Location.Y - 24);
                m6 = m6 - 2;
            }

            */
            line1.FillEllipse(myPen5, pb[x11].Location.X - 73, pb2[y11].Location.Y - 27, 7, 7);
            line1.FillEllipse(myPen6, pb[x22].Location.X - 73, pb2[y22].Location.Y - 27, 7, 7);
            line1.FillEllipse(myPen7, pb[x33].Location.X - 73, pb2[y33].Location.Y - 27, 7, 7);
            
            line1.DrawLine(redPen, new Point(pb[x11].Location.X - 69, pb2[y11].Location.Y - 24), new Point(pb[x11].Location.X - 69, pb2[0].Location.Y - 24));
            line1.DrawLine(greenPen, new Point(pb[x22].Location.X - 69, pb2[y22].Location.Y - 24), new Point(pb[x22].Location.X - 69, pb2[0].Location.Y - 24));
            line1.DrawLine(bluePen, new Point(pb[x33].Location.X - 69, pb2[y33].Location.Y - 24), new Point(pb[x33].Location.X - 69, pb2[0].Location.Y - 24));
            line1.DrawLine(redPen, new Point(pb[x11].Location.X - 69, pb2[y11].Location.Y - 24), new Point(pb[0].Location.X - 69, pb2[y11].Location.Y - 24));
            line1.DrawLine(greenPen, new Point(pb[x22].Location.X - 69, pb2[y22].Location.Y - 24), new Point(pb[0].Location.X - 69, pb2[y22].Location.Y - 24));
            line1.DrawLine(bluePen, new Point(pb[x33].Location.X - 69, pb2[y33].Location.Y - 24), new Point(pb[0].Location.X - 69, pb2[y33].Location.Y - 24));
            
            line1.DrawLine(myPen1, pb[x11].Location.X - 69, pb2[y11].Location.Y - 24, pb[x22].Location.X - 69, pb2[y22].Location.Y - 24);
            line2.DrawLine(myPen1, pb[x11].Location.X - 69, pb2[y11].Location.Y - 24, pb[x33].Location.X - 69, pb2[y33].Location.Y - 24);
            line3.DrawLine(myPen1, pb[x22].Location.X - 69, pb2[y22].Location.Y - 24, pb[x33].Location.X - 69, pb2[y33].Location.Y - 24);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1.PerformClick();
            timer1.Stop();
        }

    }
}
