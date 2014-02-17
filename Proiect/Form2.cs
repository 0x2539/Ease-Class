using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using WMPLib;

namespace Proiect.Nivele_utilizatori
{
    public partial class Form2 : Form
    {
        BazaDate bd = new BazaDate();
        //LogIn log = new LogIn();
        string conect;
        string nume;
        public Form2(string x, string y)
        {
            InitializeComponent();
            //if (bd.conectat == 1 || bd.conectat==2)
            //{
            conect = x;
            nume = y;
            linkLabel1.Text = x;
            if(x=="Profesor")
            {
                linkLabel3.Show();
            }
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Profil profil = new Profil();
            profil.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = new Form1();
            form.Visible = true;
            Hide();
            //Register register = new Register();
            
            //register.Show();
        }

        


        private void scrieTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdaugaTestMatematica adaugaTestMate = new AdaugaTestMatematica();
            adaugaTestMate.Show();
        }

        private void adaugaTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdaugaTestMatematica adaugaTestMate = new AdaugaTestMatematica();
            adaugaTestMate.Show();
        }

        private void testeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VeziTesteMatematica testeMate = new VeziTesteMatematica("da", "lalal");
            testeMate.Show();
        }

        private void lectiiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LectiiMate f3 = new LectiiMate();
            f3.Show();
        }

        private void matematicaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VeziTesteMate testeMate = new VeziTesteMate("da", "lala");
            testeMate.Show();
        }

        private void testeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lectiiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void matematicaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AdaugaTestMatematica adaugaTestMate = new AdaugaTestMatematica();
            adaugaTestMate.Show();
        }

        private void matematicaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            VeziLectiiMatematica f3 = new VeziLectiiMatematica("da");
            f3.Show();
        }

        private void adaugaLectiiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void matematicaToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            AdaugaLectieMatematica adauga = new AdaugaLectieMatematica();
            adauga.Show();
        }

        private void fizicaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            VeziLectiiFizica fizica2 = new VeziLectiiFizica("da");
            fizica2.Show();
        }

        private void fizicaToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            AdaugaLectieFizica fizica = new AdaugaLectieFizica();
            fizica.Show();
        }

        private void chimieToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            AdaugaLectieChimie chimie = new AdaugaLectieChimie();
            chimie.Show();
        }

        private void informaticaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AdaugaLectieInformatica info = new AdaugaLectieInformatica();
            info.Show();
        }

        private void chimieToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            VeziLectiiChimie chimie2 = new VeziLectiiChimie("da");
            chimie2.Show();
        }

        private void informaticaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            VeziLectiiInformatica info2 = new VeziLectiiInformatica("da");
            info2.Show();
        }

        private void fizicaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AdaugaTestFizica fizica2 = new AdaugaTestFizica();
            fizica2.Show();
        }

        private void chimieToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AdaugaTestChimie chimie2 = new AdaugaTestChimie();
            chimie2.Show();
        }

        private void informaticaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AdaugaTestInformatica info2 = new AdaugaTestInformatica();
            info2.Show();
        }

        private void fizicaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VeziTesteFizica fizica3 = new VeziTesteFizica("da", "lala");
            fizica3.Show();
        }

        private void chimieToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VeziTesteChimie chimie3 = new VeziTesteChimie("da", "lala");
            chimie3.Show();
        }

        private void informaticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VeziTesteInformatica info3 = new VeziTesteInformatica("da", "lala");
            info3.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void adaugaLectieToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void matematicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VeziTesteMate testeMate = new VeziTesteMate("da", "lala");
            testeMate.Show();
        }

        private void fizicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VeziTesteFizica testeFizica = new VeziTesteFizica("da", "lala");
            testeFizica.Show();
        }

        private void chimieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VeziTesteChimie testeChimie = new VeziTesteChimie("da", "lalala");
            testeChimie.Show();
        }

        private void informaticaToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            VeziTesteInformatica testeInformatica = new VeziTesteInformatica("da", "lala");
            testeInformatica.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (conect == "Elev")
            {
                ElevMatematica elev = new ElevMatematica(nume);
                elev.Show();
            }
            else
            {
                ProfesorMatematica prof = new ProfesorMatematica();
                prof.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (conect == "Elev")
            {
                ElevFizica elev = new ElevFizica(nume);
                elev.Show();
            }
            else
            {
                ProfesorFizica prof = new ProfesorFizica();
                prof.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (conect == "Elev")
            {
                ElevChimie elev = new ElevChimie(nume);
                elev.Show();
            }
            else
            {
                ProfesorChimie prof = new ProfesorChimie();
                prof.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (conect == "Elev")
            {
                ElevInformatica elev = new ElevInformatica(nume);
                elev.Show();
            }
            else
            {
                ProfesorInformatica prof = new ProfesorInformatica();
                prof.Show();
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NoteElevi note = new NoteElevi();
            note.Show();
        }

        



    }
}
