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
    public partial class Calculator : Form
    {
        public string ecuatie, copie;
        public double rezultat;
        public bool rezultatCalculat = false;

        public Calculator()
        {
            InitializeComponent();
            radioButton1.Select();
        }

        public void golesteTot_Click(object sender, EventArgs e)
        {
            RezultatInput.Clear();
            rezultatCalculat = false;
        }

        public void add0_Click(object sender, EventArgs e)
        {
            addCharacter('0');
        }

        public void addPoint_Click(object sender, EventArgs e)
        {
            addCharacter('.');
        }

        public void add1_Click(object sender, EventArgs e)
        {
            addCharacter('1');
        }

        public void add2_Click(object sender, EventArgs e)
        {
            addCharacter('2');
        }

        public void add3_Click(object sender, EventArgs e)
        {
            addCharacter('3');
        }

        public void add4_Click(object sender, EventArgs e)
        {
            addCharacter('4');
        }

        public void add5_Click(object sender, EventArgs e)
        {
            addCharacter('5');
        }

        public void add6_Click(object sender, EventArgs e)
        {
            addCharacter('6');
        }

        public void add7_Click(object sender, EventArgs e)
        {
            addCharacter('7');
        }

        public void add8_Click(object sender, EventArgs e)
        {
            addCharacter('8');
        }

        public void add9_Click(object sender, EventArgs e)
        {
            addCharacter('9');
        }

        public void addMinus_Click(object sender, EventArgs e)
        {
            addCharacter('-');
        }

        public void addPlus_Click(object sender, EventArgs e)
        {
            addCharacter('+');
        }

        public void addInmultire_Click(object sender, EventArgs e)
        {
            addCharacter('*');
        }

        public void addImpartire_Click(object sender, EventArgs e)
        {
            addCharacter('/');
        }

        public void addParanteza2_Click(object sender, EventArgs e)
        {
            addCharacter('(');
        }

        public void addParanteza1_Click(object sender, EventArgs e)
        {
            addCharacter(')');
        }

        public void stergeCaracter_Click(object sender, EventArgs e)
        {
            //←
            RezultatInput.Text += Math.PI;
            //if (textBoxRezultatInput.Text.Length > 0)
            //textBoxRezultatInput.Text = textBoxRezultatInput.Text.Substring(0, textBoxRezultatInput.Text.Length - 1);
        }

        public void calculeazaRezultat_Click(object sender, EventArgs e)
        {
            bool tr = false;
            string u = "qwertyuiopasfdghjklzxcvbnm";
            for (int o = 0; o < RezultatInput.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (RezultatInput.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            if (tr == false)
            {
                faCalcule();
                int invalid = copie.IndexOf('=');
                if (invalid == -1)
                {
                    RezultatInput.Text = copie + " = " + rezultat.ToString();
                }
                else
                {
                    RezultatInput.Text = "Eroare!";
                }
            }
            else
            {
                RezultatInput.Text = "Introduceti doar numere!";
            }
        }

        public void addCharacter(char c)
        {
            if (rezultatCalculat)
            {
                RezultatInput.Clear();
                RezultatInput.Text += rezultat;
                rezultatCalculat = false;
            }
            RezultatInput.Text += c;
        }

        public void faCalcule()
        {
            ecuatie = RezultatInput.Text.ToString();
            copie = ecuatie;
            try
            {
                ScriereaPoloneza sc = new ScriereaPoloneza();
                rezultat = Convert.ToDouble(sc.calculeazaToateParantezele(ecuatie));
                ecuatie = rezultat.ToString();
            }
            catch
            {
                ecuatie = "Eroare!";
            }
            finally
            {
                rezultatCalculat = true;
                RezultatInput.Text = ecuatie;
            }
        }

        public void calculeaza1pex_Click(object sender, EventArgs e)
        {
            faCalcule();
            try
            {
                rezultat = 1 / rezultat;
                rezultatCalculat = true;
                RezultatInput.Text = rezultat.ToString();
            }
            catch
            {
            }
        }

        public void calculeazaPutere2_Click(object sender, EventArgs e)
        {
            faCalcule();
            try
            {
                rezultat = rezultat * rezultat;
                rezultatCalculat = true;
                RezultatInput.Text = rezultat.ToString();
            }
            catch
            {
            }
        }

        public void calculeazaPutere3_Click(object sender, EventArgs e)
        {
            faCalcule();
            try
            {
                rezultat = rezultat * rezultat * rezultat;
                rezultatCalculat = true;
                RezultatInput.Text = rezultat.ToString();
            }
            catch
            {
            }
        }

        public void calculeazaFactorial_Click(object sender, EventArgs e)
        {
            faCalcule();
            try
            {
                double rez = 1;
                if (rezultat > 0)
                {
                    for (int i = 1; i <= rezultat; i++)
                        rez *= i;
                }
                rezultat = rez;
                rezultatCalculat = true;
                RezultatInput.Text = rezultat.ToString();
            }
            catch { }
        }

        public void calculeazaRadical_Click(object sender, EventArgs e)
        {
            faCalcule();
            try
            {
                double rez = 0;
                if (rezultat > 0)
                {
                    rez = Math.Sqrt(rezultat);
                }
                rezultat = rez;
                rezultatCalculat = true;
                RezultatInput.Text = rezultat.ToString();
            }
            catch { }
        }

        public void calculeazaCos_Click(object sender, EventArgs e)
        {
            faCalcule();
            try
            {
                double rez = 0;
                if (rezultat > 0)
                {
                    rez = Math.Cos(rezultat);
                }
                rezultat = rez;
                rezultatCalculat = true;
                RezultatInput.Text = rezultat.ToString();
            }
            catch { }
        }

        public void calculeazaSinus_Click(object sender, EventArgs e)
        {
            faCalcule();
            try
            {
                double rez = 0;
                if (rezultat > 0)
                {
                    rez = Math.Sin(rezultat);
                }
                rezultat = rez;
                rezultatCalculat = true;
                RezultatInput.Text = rezultat.ToString();
            }
            catch { }
        }

        public void calculeazaCotangenta_Click(object sender, EventArgs e)
        {
            faCalcule();
            try
            {
                double rez = 0;
                if (rezultat > 0)
                {
                    rez = Math.Cos(rezultat) / Math.Sin(rezultat);
                }
                rezultat = rez;
                rezultatCalculat = true;
                RezultatInput.Text = rezultat.ToString();
            }
            catch { }
        }

        public void calculeazaTangenta_Click(object sender, EventArgs e)
        {
            faCalcule();
            try
            {
                double rez = 0;
                if (rezultat > 0)
                {
                    rez = Math.Tan(rezultat);
                }
                rezultat = rez;
                rezultatCalculat = true;
                RezultatInput.Text = rezultat.ToString();
            }
            catch { }
        }
    }
}
