using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Proiect
{
    public partial class NewListaLectiiSiTeste : Form
    {
        Button[] testele = new Button[140];
        int nrTeste = 0;
        
        Button[] lectiile = new Button[140];
        int nrLectii = 0;

        Label[] detaliiTest = new Label[140];
        Label[] noteTest = new Label[140];
        Label[] detaliiLectie = new Label[140];

        bool[] areNota = new bool[140];

        int x1 = 187, y1 = 12;
        int x2 = 571, y2 = 12;

        string numeleMateriei = "";
        string tipUtilizator = "";//prof-profesor, da-elev, orice altceva Vizitator

        string mut = "nimic";//retine care panel mut cand fac swype

        string ExistaLectii = "da", ExistaTeste = "da";
        string userName = "";

        public NewListaLectiiSiTeste(string Materie, string utilizator, string numeUtilizator)
        {
            InitializeComponent();
            
            this.Text = "Testele si lectia de la " + Materie;
            userName = numeUtilizator;
            numeleMateriei = Materie;
            tipUtilizator = utilizator;
            //ascund butoanele de adaugare de teste si lectii in caz ca utilizatorul nu este profesor
            if (tipUtilizator != "Profesor")
            {
                AdaugaLectieListaLectiiSiTesteButton.Hide();
                AdaugaTesteListaLectiiSiTesteButton.Hide();
            }
            
            

            //incarc testele ********************

            try
            {

                DirectoryInfo dir1 = new DirectoryInfo(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\");

                string[] teste = Directory.GetDirectories(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\");
                int directoryCount = Directory.GetDirectories(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\").Length;
                
                


                //string[] teste = richTextBox1.Text.Split('\n');
                nrTeste = teste.Length + 1;
                //MessageBox.Show((teste.Length - 1).ToString());
                for (int i = 0; i < nrTeste - 1; i++)
                {
                    areNota[i] = new bool();
                    areNota[i] = false;
                    //vad care este numele testului
                    string numeTest = new DirectoryInfo(teste[i]).Name;

                    testele[i] = new Button();
                    testele[i].Text = numeTest;
                    testele[i].AutoSize = true;
                    testele[i].AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                    testele[i].Size = new System.Drawing.Size(61, 23);

                    //creez un label in care trec detaliile testului
                    detaliiTest[i] = new Label();

                    //daca exista detalii despre test le incarc
                    if (File.Exists(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + numeTest + "\\detalii"))
                    {
                        DetaliileListaLectiiSiTeste.Text = "";
                        DetaliileListaLectiiSiTeste.LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + numeTest + "\\detalii", RichTextBoxStreamType.PlainText);
                        detaliiTest[i].Text = DetaliileListaLectiiSiTeste.Text;
                        if (DetaliileListaLectiiSiTeste.Text == "")
                        {
                            detaliiTest[i].Text = "Nu exista detalii despre acest test!";
                        }
                    }
                    else
                    {
                        detaliiTest[i].Text = "Nu exista detalii despre acest test!";
                    }
                    detaliiTest[i].AutoSize = true;
                    detaliiTest[i].Size = new System.Drawing.Size(35, 13);

                    if (i == 0)
                    {
                        testele[i].Location = new System.Drawing.Point(button1ListaLectiiSiTeste.Location.X + 5,
                                                                        button1ListaLectiiSiTeste.Location.Y);
                    }
                    else
                    {
                        testele[i].Location = new System.Drawing.Point(button1ListaLectiiSiTeste.Location.X + 5,
                                                                        testele[i - 1].Location.Y + 35);
                    }

                    testele[i].TabIndex = 1;
                    testele[i].UseVisualStyleBackColor = true;

                    testele[i].Click += new System.EventHandler(this.button1_Click);
                    panel1ListaLectiiSiTeste.Controls.Add(testele[i]);

                    detaliiTest[i].Location = new Point(testele[i].Location.X + testele[i].Width + 10,
                                                        testele[i].Location.Y + 5);
                    
                    panel1ListaLectiiSiTeste.Controls.Add(detaliiTest[i]);
                }

            }
            catch
            {
                ExistaTeste = "nu";
            }


            //incarc lectiile *********************

            try
            {

                DirectoryInfo dir2 = new DirectoryInfo(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\");

                string[] lectii = Directory.GetDirectories(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\");
                //int directoryCount = Directory.GetDirectories(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\").Length;


                //string[] lectii = richTextBox1.Text.Split('\n');
                nrLectii = lectii.Length + 1;

                for (int i = 0; i < nrLectii - 1; i++)
                {
                    //vad care este numele testului
                    string numeLectie = new DirectoryInfo(lectii[i]).Name;

                    lectiile[i] = new Button();
                    lectiile[i].Text = numeLectie;
                    lectiile[i].AutoSize = true;
                    lectiile[i].AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                    lectiile[i].Size = new System.Drawing.Size(61, 23);

                    //creez un label in care trec detaliile testului
                    detaliiLectie[i] = new Label();

                    //daca exista detalii despre test le incarc
                    if (File.Exists(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + numeLectie + "\\detalii"))
                    {
                        DetaliileListaLectiiSiTeste.Text = "";
                        DetaliileListaLectiiSiTeste.LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + numeLectie + "\\detalii", RichTextBoxStreamType.PlainText);
                        detaliiLectie[i].Text = DetaliileListaLectiiSiTeste.Text;
                        if (DetaliileListaLectiiSiTeste.Text == "")
                        {
                            detaliiLectie[i].Text = "Nu exista detalii despre aceasta lectie!";
                        }
                    }
                    else
                    {
                        detaliiLectie[i].Text = "Nu exista detalii despre aceasta lectie!";
                    }
                    detaliiLectie[i].AutoSize = true;
                    detaliiLectie[i].Size = new System.Drawing.Size(35, 13);

                    if (i == 0)
                    {
                        lectiile[i].Location = new System.Drawing.Point(button1ListaLectiiSiTeste.Location.X + 5,
                                                                        button1ListaLectiiSiTeste.Location.Y);
                    }
                    else
                    {
                        lectiile[i].Location = new System.Drawing.Point(button1ListaLectiiSiTeste.Location.X + 5,
                                                                        testele[i - 1].Location.Y + 35);
                    }

                    lectiile[i].TabIndex = 1;
                    lectiile[i].UseVisualStyleBackColor = true;

                    lectiile[i].Click += new System.EventHandler(this.button2_Click);
                    panel2ListaLectiiSiTeste.Controls.Add(lectiile[i]);

                    detaliiLectie[i].Location = new Point(lectiile[i].Location.X + lectiile[i].Width + 10,
                                                        lectiile[i].Location.Y + 5);

                    panel2ListaLectiiSiTeste.Controls.Add(detaliiLectie[i]);
                }

                selectNote();
            }
            catch
            {
                ExistaLectii = "nu";
            }
            panel3ListaLectiiSiTeste.BringToFront();
        }

        public void selectNote()
        {
            if (tipUtilizator == "Elev")
            {
                BazaDate bd = new BazaDate();

                //noteMaterie va reprezenta ce se afla in baza de date:  numele testului: nota/punctajul total;
                string[] noteMaterie = bd.selectNoteMaterie(userName, numeleMateriei).Split(';');
                //materie va reprezenta numele testului
                string[] materie = new string[noteMaterie.Length];
                //note va reprezenta nota luata la test
                string[] note = new string[noteMaterie.Length];

                //aflu numele testelor si notele respective
                for (int i = 0; i < noteMaterie.Length - 1; i++)
                {
                    materie[i] = noteMaterie[i].Substring(0, noteMaterie[i].IndexOf(':'));
                    note[i] = noteMaterie[i].Substring(noteMaterie[i].IndexOf(':') + 1, noteMaterie[i].Length - noteMaterie[i].IndexOf(':') - 1);
                }

                //verific daca in lista se afla testele la care am note
                for (int i = 0; i < nrTeste - 1; i++)
                {
                    for (int j = 0; j < noteMaterie.Length - 1; j++)
                    {
                        if (testele[i].Text == materie[j])
                        {
                            areNota[i] = true;
                            //creez un label in care scriu nota, si il pozitionez in dreptul testului
                            noteTest[i] = new Label();
                            noteTest[i].AutoSize = true;
                            noteTest[i].Location = new System.Drawing.Point(testele[i].Location.X - 25, testele[i].Location.Y + 5);
                            noteTest[i].Size = new System.Drawing.Size(35, 13);
                            noteTest[i].Text = note[j];
                            panel1ListaLectiiSiTeste.Controls.Add(noteTest[i]);
                            break;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < nrTeste - 1; i++)
            {
                if (sender.Equals(testele[i]))
                {
                    if (tipUtilizator == "Profesor")
                    {
                        NewProfesorTest prof = new NewProfesorTest(testele[i].Text, numeleMateriei);
                        prof.Show();
                    }
                    else
                        if (tipUtilizator == "Elev")
                        {
                            //daca nu are nota, o sa dea testul
                            if (areNota[i] == false)
                            {
                                NewTest test = new NewTest(testele[i].Text, numeleMateriei, userName);
                                test.Show();
                            }
                            else
                                //daca are nota, decat o sa vizualizeze testul
                            {
                                NewVizualizeazaTest test = new NewVizualizeazaTest(testele[i].Text, numeleMateriei, "Elev");
                                test.Show();
                            }
                        }
                        else
                        {
                            NewVizualizeazaTest test = new NewVizualizeazaTest(testele[i].Text, numeleMateriei, "vizitator");
                            test.Show();
                        }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < nrLectii - 1; i++)
            {
                if (sender.Equals(lectiile[i]))
                {
                    NewLectie n = new NewLectie(lectiile[i].Text, tipUtilizator, numeleMateriei, userName);
                    n.Show();
                }
            }
        }

        private void Teste_Click(object sender, EventArgs e)
        {
            if (ExistaTeste == "da")
            {
                label1ListaLectiiSiTeste.Hide();
                mut = "teste";
                //panel1.BringToFront();
                //panel3.SendToBack();
                panel1ListaLectiiSiTeste.BringToFront();
                //aduc panel1 (pe care se afla testele) in fata
                //si pe panel2 (pe care se afla lectiile) il duc in spate

                panel1ListaLectiiSiTeste.Location = new Point(x1 + 10, y1);
                panel2ListaLectiiSiTeste.Location = new Point(x2, y2);
                //pornesc meniul sa se miste
                swypeListaLectiiSiTeste.Start();
            }
            else
            {   
                mut = "nu exista";
                label1ListaLectiiSiTeste.Show();
                label1ListaLectiiSiTeste.Location = new Point(20, y1);
                label1ListaLectiiSiTeste.Text = "Nu exista teste!";
                panel3ListaLectiiSiTeste.BringToFront();
                swypeListaLectiiSiTeste.Start();
            }
        }

        private void Lectii_Click(object sender, EventArgs e)
        {
            if (ExistaLectii == "da")
            {
                label1ListaLectiiSiTeste.Hide();
                mut = "lectii";
                //panel3.SendToBack();
                panel2ListaLectiiSiTeste.BringToFront();
                //panel2.BringToFront();
                //aduc panel2 (pe care se afla lectiile) in fata
                //si pe panel1 (pe care se afla testele) il duc in spate

                panel2ListaLectiiSiTeste.Location = new Point(x1 + 10, y1);
                panel1ListaLectiiSiTeste.Location = new Point(x2, y2);
                swypeListaLectiiSiTeste.Start();
            }
            else
            {
                mut = "nu exista";
                label1ListaLectiiSiTeste.Show();
                label1ListaLectiiSiTeste.Location = new Point(20, y1);
                label1ListaLectiiSiTeste.Text = "Nu exista lectii!";
                panel3ListaLectiiSiTeste.BringToFront();
                swypeListaLectiiSiTeste.Start();
            }
        }

        private void AdaugaTeste_Click(object sender, EventArgs e)
        {
            NewAdaugaTest n = new NewAdaugaTest(numeleMateriei);
            n.Show();
        }

        private void AdaugaLectie_Click(object sender, EventArgs e)
        {
            NewAdaugaLectie n = new NewAdaugaLectie(numeleMateriei);
            n.Show();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            //incarc testele ********************
            //richTextBox1.LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\", RichTextBoxStreamType.PlainText);


            try
            {
                selectNote();
                DirectoryInfo dir1 = new DirectoryInfo(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\");

                string[] teste = Directory.GetDirectories(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\");
                int directoryCount = Directory.GetDirectories(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\").Length;




                //string[] teste = richTextBox1.Text.Split('\n');
                nrTeste = teste.Length + 1;
                //MessageBox.Show((teste.Length - 1).ToString());
                for (int i = 0; i < nrTeste - 1; i++)
                {
                    //vad care este numele testului
                    string numeTest = new DirectoryInfo(teste[i]).Name;

                    testele[i] = new Button();
                    testele[i].Text = numeTest;
                    testele[i].AutoSize = true;
                    testele[i].AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                    testele[i].Size = new System.Drawing.Size(61, 23);

                    //creez un label in care trec detaliile testului
                    detaliiTest[i] = new Label();

                    //daca exista detalii despre test le incarc
                    if (File.Exists(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + numeTest + "\\detalii"))
                    {
                        DetaliileListaLectiiSiTeste.Text = "";
                        DetaliileListaLectiiSiTeste.LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + numeTest + "\\detalii", RichTextBoxStreamType.PlainText);
                        detaliiTest[i].Text = DetaliileListaLectiiSiTeste.Text;
                        if (DetaliileListaLectiiSiTeste.Text == "")
                        {
                            detaliiTest[i].Text = "Nu exista detalii despre acest test!";
                        }
                    }
                    else
                    {
                        detaliiTest[i].Text = "Nu exista detalii despre acest test!";
                    }
                    detaliiTest[i].AutoSize = true;
                    detaliiTest[i].Size = new System.Drawing.Size(35, 13);

                    if (i == 0)
                    {
                        testele[i].Location = new System.Drawing.Point(button1ListaLectiiSiTeste.Location.X + 5,
                                                                        button1ListaLectiiSiTeste.Location.Y);
                    }
                    else
                    {
                        testele[i].Location = new System.Drawing.Point(button1ListaLectiiSiTeste.Location.X + 5,
                                                                        testele[i - 1].Location.Y + 35);
                    }

                    testele[i].TabIndex = 1;
                    testele[i].UseVisualStyleBackColor = true;

                    testele[i].Click += new System.EventHandler(this.button1_Click);
                    panel1ListaLectiiSiTeste.Controls.Add(testele[i]);

                    detaliiTest[i].Location = new Point(testele[i].Location.X + testele[i].Width + 10,
                                                        testele[i].Location.Y + 5);

                    panel1ListaLectiiSiTeste.Controls.Add(detaliiTest[i]);
                }

            }
            catch
            {
                ExistaTeste = "nu";
            }



            //incarc lectiile *********************
            try
            {

                DirectoryInfo dir2 = new DirectoryInfo(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\");

                string[] lectii = Directory.GetDirectories(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\");
                //int directoryCount = Directory.GetDirectories(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\").Length;


                //string[] lectii = richTextBox1.Text.Split('\n');
                nrLectii = lectii.Length + 1;

                for (int i = 0; i < nrLectii - 1; i++)
                {
                    //vad care este numele testului
                    string numeLectie = new DirectoryInfo(lectii[i]).Name;

                    lectiile[i] = new Button();
                    lectiile[i].Text = numeLectie;
                    lectiile[i].AutoSize = true;
                    lectiile[i].AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                    lectiile[i].Size = new System.Drawing.Size(61, 23);

                    //creez un label in care trec detaliile testului
                    detaliiLectie[i] = new Label();

                    //daca exista detalii despre test le incarc
                    if (File.Exists(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + numeLectie + "\\detalii"))
                    {
                        DetaliileListaLectiiSiTeste.Text = "";
                        DetaliileListaLectiiSiTeste.LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + numeLectie + "\\detalii", RichTextBoxStreamType.PlainText);
                        detaliiLectie[i].Text = DetaliileListaLectiiSiTeste.Text;
                        if (DetaliileListaLectiiSiTeste.Text == "")
                        {
                            detaliiLectie[i].Text = "Nu exista detalii despre aceasta lectie!";
                        }
                    }
                    else
                    {
                        detaliiLectie[i].Text = "Nu exista detalii despre aceasta lectie!";
                    }
                    detaliiLectie[i].AutoSize = true;
                    detaliiLectie[i].Size = new System.Drawing.Size(35, 13);

                    if (i == 0)
                    {
                        lectiile[i].Location = new System.Drawing.Point(button1ListaLectiiSiTeste.Location.X + 5,
                                                                        button1ListaLectiiSiTeste.Location.Y);
                    }
                    else
                    {
                        lectiile[i].Location = new System.Drawing.Point(button1ListaLectiiSiTeste.Location.X + 5,
                                                                        testele[i - 1].Location.Y + 35);
                    }

                    lectiile[i].TabIndex = 1;
                    lectiile[i].UseVisualStyleBackColor = true;

                    lectiile[i].Click += new System.EventHandler(this.button2_Click);
                    panel2ListaLectiiSiTeste.Controls.Add(lectiile[i]);

                    detaliiLectie[i].Location = new Point(lectiile[i].Location.X + lectiile[i].Width + 10,
                                                        lectiile[i].Location.Y + 5);

                    panel2ListaLectiiSiTeste.Controls.Add(detaliiLectie[i]);
                }
            }
            catch
            {
                ExistaLectii = "nu";
            }

            panel3ListaLectiiSiTeste.Show();
            label1ListaLectiiSiTeste.Text = "";
            panel3ListaLectiiSiTeste.BringToFront();
        }

        private void swype_Tick(object sender, EventArgs e)
        {
            if (mut == "teste")
            {
                if (panel1ListaLectiiSiTeste.Location.X > x1)
                {
                    panel1ListaLectiiSiTeste.Location = new Point(panel1ListaLectiiSiTeste.Location.X - 1, panel1ListaLectiiSiTeste.Location.Y);
                }
                else
                {
                    mut = "nimic";
                    swypeListaLectiiSiTeste.Stop();
                }
            }
            else
                if (mut == "lectii")
                {
                    if (panel2ListaLectiiSiTeste.Location.X > x1)
                    {
                        panel2ListaLectiiSiTeste.Location = new Point(panel2ListaLectiiSiTeste.Location.X - 1, panel2ListaLectiiSiTeste.Location.Y);
                    }
                    else
                    {
                        mut = "nimic";
                        swypeListaLectiiSiTeste.Stop();
                    }
                }
                else
                    if (mut == "nu exista")
                    {
                        if (label1ListaLectiiSiTeste.Location.X > 10)
                        {
                            label1ListaLectiiSiTeste.Location = new Point(label1ListaLectiiSiTeste.Location.X - 1, label1ListaLectiiSiTeste.Location.Y);
                        }
                        else
                        {
                            mut = "nimic";
                            swypeListaLectiiSiTeste.Stop();
                        }
                    }
        }


    }
}
