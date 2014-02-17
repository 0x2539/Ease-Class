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
    public partial class NewTest : Form
    {
        BazaDate bd = new BazaDate();

        string[] raspunsCompletTestElev = new string[40];//raspunsul corect complet cu tot cu note
        string[,] raspunsuriCorecteTestElev = new string[40, 40];//raspunsuri corecte
        string[] raspunsulMeuTestElev = new string[40];//raspunsul meu complet
        string[,] raspunsuriIntermediareTestElev = new string[40, 40];//raspunsurile mele

        int[,] noteTestElev = new int[40, 40];
        int[] nrNoteTestElev = new int[40];
        int[] nrRaspCorTestElev = new int[40];
        int[] nrRaspMeuTestElev = new int[40];

        int[] inaltimiCasuteTestElev = new int[40];


        int NrTotalTestElev = 3;//nr total de casute cu raspunsuri

        public RichTextBox[] enuntTestElev = new RichTextBox[40];
        public RichTextBox[] raspunsTestElev = new RichTextBox[40];//textBoxurile care apar pe ecran
        public RichTextBox[] raspunsCorectTestElev = new RichTextBox[40];//retine raspunsul corect corespunzator raspunsului
        public Label[] lbTestElev = new Label[40];
        public Label[] NrProblemaTestElev = new Label[40];
        public Button buton10TestElev = new Button();
        public Button buton20TestElev = new Button();
        public Button buton30TestElev = new Button();
        public PictureBox[] imagineTestElev = new PictureBox[140];

        public string locatieTestElev;
        public string numeTestElev;

        public int SecundeTestElev;
        public int MinuteTestElev;
        public int hoursTestElev;
        int nrImaginiTestElev;
        DateTime dt = new DateTime();

        string numeleMateriei = "";
        string userName = "";

        public NewTest(string location, string Materie, string utilizator)
        {
            //setez faptul ca am deschis un test intr-o fereastra secundara
            Deschidere.Default.aDeschisUnTest = true;
            Deschidere.Default.Save();
            
            InitializeComponent();
            locatieTestElev = location;
            numeleMateriei = Materie;
            userName = utilizator;

            this.Text = "Testul " + locatieTestElev + " (" + numeleMateriei + ")";

            nrImaginiTestElev = 0;
            if (Directory.Exists(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestElev + "\\Imagini"))
            {
                nrImaginiTestElev = Directory.GetFiles(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestElev + "\\Imagini\\").Length - 1;
            }

            numarRTTestElev = Directory.GetFiles(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestElev + "\\").Length / 2 - 1;
            
            
            AmTerminatButtonTestElev.Location = new Point(0, 0);
            buton30TestElev.Enabled = false;
            
            richTextBox1TestElev.LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestElev + "\\setari", RichTextBoxStreamType.RichText);
            
            string[] elementeSetari = richTextBox1TestElev.Text.Split('\n');

            string minute = elementeSetari[0];
            
            for (int i = 1; i < numarRTTestElev + 1; i++)
            {
                inaltimiCasuteTestElev[i - 1] = Convert.ToInt32(elementeSetari[i]);
            }

            MinuteTestElev = Convert.ToInt32(minute);
            SecundeTestElev = 0;

            MinuteLabelTestElev.Text = (MinuteTestElev - 1).ToString();
            SecundeLabelTestElev.Text = "60";

            this.buton10TestElev.Click += new System.EventHandler(this.button1_Click);
            this.buton30TestElev.Click += new System.EventHandler(this.button2_Click);
        }
        public int kTestElev = -1;
        public int numarRTTestElev;
        
        private void button1_Click(object sender, EventArgs e)
        {
            buton10TestElev.Enabled = false;
            buton30TestElev.Enabled = true;
            InfoAmTerminatTestElevPicture.Image = global::Proiect.Properties.Resources.bullet_accept;
            LockPrintTestElevPicture.Image = global::Proiect.Properties.Resources.file_unlocked;


            NrTotalTestElev = numarRTTestElev;

            for (int i = 0; i < numarRTTestElev; i++)
            {
                raspunsCompletTestElev[i] = raspunsCorectTestElev[i].Text;
                raspunsulMeuTestElev[i] = raspunsTestElev[i].Text;
            }

            int uyt1 = 0, uyt2 = 0;
            int k11TestElev = 0;//nr total de note
            int k2 = 0;//nr total de raspunsuri corecte
            int k3 = 0;//nr total de raspunsuri ale mele

            string[] copie1 = new string[40];//folosesc copiile ca sa pot sterge spatiile
            string[] copie2 = new string[40];
            for (int i = 0; i < NrTotalTestElev; i++)
            {
                copie1[i] = raspunsCompletTestElev[i];
                copie2[i] = raspunsulMeuTestElev[i];
            }
            //sterg spatiile
            for (int i = 0; i < NrTotalTestElev; i++)
            {
                for (int j = 0; j < copie1[i].Length; j++)
                {
                    if (copie1[i][j] == ' ' || copie1[i][j] == '\n')
                    {
                        raspunsCompletTestElev[i] = raspunsCompletTestElev[i].Remove(j - uyt1, 1);
                        uyt1++;
                    }
                }
                uyt1 = 0;
            }
            //sterg spatiile
            for (int i = 0; i < NrTotalTestElev; i++)
            {
                for (int j = 0; j < copie2[i].Length; j++)
                {
                    if (copie2[i][j] == ' ' || copie2[i][j] == '\n')
                    {
                        raspunsulMeuTestElev[i] = raspunsulMeuTestElev[i].Remove(j - uyt2, 1);
                        uyt2++;
                    }
                }
                uyt2 = 0;
            }

            //aflu notele
            string inter = "";
            int uyt3 = 0;
            for (int i = 0; i < NrTotalTestElev; i++)
            {
                string s = raspunsCompletTestElev[i];
                for (int j = 0; j < raspunsCompletTestElev[i].Length; j++)
                {
                    if (raspunsCompletTestElev[i][j] == '#')
                    {
                        int h = j + 1 - uyt3;
                        //MessageBox.Show("j1    " + j);
                        //verific daca este ultimul #
                        if (h < s.Length)
                        {
                            while (h < s.Length && s[h] != '#')
                            {
                                inter += s[h];
                                h++;
                            }
                        }
                        //retin nota
                        //MessageBox.Show(inter);
                        noteTestElev[i, k11TestElev] = Convert.ToInt32(inter);
                        k11TestElev++;

                        //sterg nota
                        s = s.Remove(j - uyt3, 2 + inter.Length);
                        uyt3 += 2 + inter.Length;

                        //MessageBox.Show("s2    " + s);

                        j += 2 + inter.Length - 1;
                        //MessageBox.Show("j2    "+j);
                        inter = "";
                    }
                }
                raspunsCompletTestElev[i] = s;
                nrNoteTestElev[i] = k11TestElev;
                k11TestElev = 0;
                uyt3 = 0;
            }



            //aflu raspunsurile corecte
            string inter2 = "";
            int uyt4 = 0;
            for (int i = 0; i < NrTotalTestElev; i++)
            {
                string s = raspunsCompletTestElev[i];
                for (int j = 0; j < raspunsCompletTestElev[i].Length; j++)
                {
                    if (raspunsCompletTestElev[i][j] == ';' || j - uyt4 == 0)
                    {
                        int h = j - uyt4;
                        //verific daca este ultimul ;
                        if (h < s.Length)
                        {
                            while (h < s.Length && s[h] != ';')
                            {
                                inter2 += s[h];
                                h++;
                            }
                        }
                        //retin raspunsul
                        raspunsuriCorecteTestElev[i, k2] = inter2;
                        k2++;

                        //sterg raspunsul
                        if (inter2 != s)
                        {
                            s = s.Remove(j - uyt4, 1 + inter2.Length);
                            uyt4 += 1 + inter2.Length;
                        }
                        else
                        {
                            s = s.Remove(j - uyt4, inter2.Length);
                            uyt4 += inter2.Length;
                        }

                        j += inter2.Length;
                        inter2 = "";

                    }
                }
                raspunsCompletTestElev[i] = s;
                nrRaspCorTestElev[i] = k2;
                k2 = 0;
                uyt4 = 0;
            }


            //aflu raspunsurile mele
            string inter3 = "";
            int uyt5 = 0;
            for (int i = 0; i < NrTotalTestElev; i++)
            {
                string s = raspunsulMeuTestElev[i];
                for (int j = 0; j < raspunsulMeuTestElev[i].Length; j++)
                {
                    if (raspunsulMeuTestElev[i][j] == ';' || j - uyt5 == 0)
                    {
                        int h = j - uyt5;
                        //verific daca este ultimul ;
                        if (h < s.Length)
                        {
                            while (h < s.Length && s[h] != ';')
                            {
                                inter3 += s[h];
                                h++;
                            }
                        }
                        //retin raspunsul
                        raspunsuriIntermediareTestElev[i, k3] = inter3;
                        k3++;

                        //sterg raspunsul
                        if (inter3 != s)
                        {
                            s = s.Remove(j - uyt5, 1 + inter3.Length);
                            uyt5 += 1 + inter3.Length;
                        }
                        else
                        {
                            s = s.Remove(j - uyt5, inter3.Length);
                            uyt5 += inter3.Length;
                        }

                        j += inter3.Length;
                        inter3 = "";

                    }
                }
                raspunsulMeuTestElev[i] = s;
                nrRaspMeuTestElev[i] = k3;
                k3 = 0;
                uyt5 = 0;
            }


            int notaT = 0;
            for (int i = 0; i < NrTotalTestElev; i++)
            {
                for (int j = 0; j < nrNoteTestElev[i]; j++)
                {
                    notaT += noteTestElev[i, j];
                }
            }


            int nota = 0;
            for (int i = 0; i < NrTotalTestElev; i++)
            {
                for (int j = 0; j < nrRaspCorTestElev[i]; j++)
                {
                    for (int u = 0; u < nrRaspMeuTestElev[i]; u++)
                    {
                        if (raspunsuriCorecteTestElev[i, j] == raspunsuriIntermediareTestElev[i, u])
                        {
                            nota += noteTestElev[i, j];
                        }
                    }
                }
            }

            MessageBox.Show("Ai obținut: " + nota + " din " + notaT);

            DateTime dt = DateTime.Now;

            PunctajLabelTestElev.Show();
            PunctajLabelTestElev.Text = "Ai obținut: " + nota.ToString() + " din " + notaT.ToString();

            //string g = bd.selectName();
            string q = locatieTestElev + ": " + nota.ToString() + "/" + notaT.ToString() + ';';
            // " la " + dt.ToShortDateString() + ' ' + dt.ToShortTimeString() + ';';
            bd.insereazaNotaMaterie(userName, numeleMateriei, q);
            bd.inserezaDataMaterie(userName, numeleMateriei);

            CronometruTestElev.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            aApasatPeIncepe = true;

            InfoAmTerminatTestElevPicture.Show();
            LockPrintTestElevPicture.Show();

            MinuteLabelTestElev.Show();
            SecundeLabelTestElev.Show();
            dt = DateTime.Now;
            CronometruTestElev.Start();
            IncepeButtonTestElev.Hide();
            int s;
            for (kTestElev = 0; kTestElev < numarRTTestElev; kTestElev++)
            {
                Point pos = new Point(0, 0);
                enuntTestElev[kTestElev] = new RichTextBox();
                raspunsTestElev[kTestElev] = new RichTextBox();
                raspunsCorectTestElev[kTestElev] = new RichTextBox();
                buton10TestElev = new Button();
                buton20TestElev = new Button();

                if (kTestElev == 0)
                {
                    enuntTestElev[kTestElev].BackColor = System.Drawing.Color.White;
                    enuntTestElev[kTestElev].Name = "rt" + kTestElev;
                    enuntTestElev[kTestElev].ReadOnly = true;
                    enuntTestElev[kTestElev].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
                    enuntTestElev[kTestElev].Size = new System.Drawing.Size(704, 10);
                    enuntTestElev[kTestElev].TabIndex = kTestElev + 7;
                    this.enuntTestElev[kTestElev].BorderStyle = System.Windows.Forms.BorderStyle.None;

                    s = kTestElev + 1;

                    enuntTestElev[kTestElev].Text = System.IO.File.ReadAllText(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestElev + "\\problema" + s);
                    raspunsCorectTestElev[kTestElev].Text = System.IO.File.ReadAllText(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestElev + "\\raspuns" + s);
                    enuntTestElev[kTestElev].WordWrap = true;
                    enuntTestElev[kTestElev].Location = new Point(0, 30);

                    raspunsTestElev[kTestElev].BackColor = System.Drawing.Color.White;
                    raspunsTestElev[kTestElev].Name = "tb" + kTestElev;
                    raspunsTestElev[kTestElev].ReadOnly = false;
                    raspunsTestElev[kTestElev].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
                    raspunsTestElev[kTestElev].Size = new System.Drawing.Size(504, 26);
                    raspunsTestElev[kTestElev].TabIndex = kTestElev + 7;
                    raspunsTestElev[kTestElev].Text = "";
                    raspunsTestElev[kTestElev].WordWrap = true;

                    this.Controls.Add(enuntTestElev[kTestElev]);
                }
                else
                    if (kTestElev > 0)
                    {
                        enuntTestElev[kTestElev].BackColor = System.Drawing.Color.White;
                        enuntTestElev[kTestElev].Name = "rt" + kTestElev;
                        enuntTestElev[kTestElev].ReadOnly = true;
                        enuntTestElev[kTestElev].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
                        enuntTestElev[kTestElev].Size = new System.Drawing.Size(704, 10);
                        enuntTestElev[kTestElev].TabIndex = kTestElev + 7;
                        this.enuntTestElev[kTestElev].BorderStyle = System.Windows.Forms.BorderStyle.None;

                        s = kTestElev + 1;

                        enuntTestElev[kTestElev].Text = System.IO.File.ReadAllText(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestElev + "\\problema" + s);
                        raspunsCorectTestElev[kTestElev].Text = System.IO.File.ReadAllText(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestElev + "\\raspuns" + s);
                        enuntTestElev[kTestElev].WordWrap = true;
                        enuntTestElev[kTestElev].Location = new Point(0, lbTestElev[kTestElev - 1].Location.Y + 85);// enunt[k - 1].Location.Y + enunt[k - 1].Height + 15);

                        raspunsTestElev[kTestElev].BackColor = System.Drawing.Color.White;
                        raspunsTestElev[kTestElev].Name = "tb" + kTestElev;
                        raspunsTestElev[kTestElev].ReadOnly = false;
                        raspunsTestElev[kTestElev].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
                        raspunsTestElev[kTestElev].Size = new System.Drawing.Size(504, 26);
                        raspunsTestElev[kTestElev].TabIndex = kTestElev + 7;
                        raspunsTestElev[kTestElev].Text = "";
                        raspunsTestElev[kTestElev].WordWrap = true;

                        this.Controls.Add(enuntTestElev[kTestElev]);

                        if (nrImaginiTestElev != 0)
                        {
                            string qq = "";
                            richTextBox2TestElev.LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestElev + "\\Imagini\\setari");
                            string[] linii = richTextBox2TestElev.Lines;
                            int q = 0, w = 0, ee = 0, r = 0;//q-location.x w-location.y e-width r-height
                            for (int z = 0; z < nrImaginiTestElev; z++)
                            {
                                q = Convert.ToInt32(linii[z].Substring(0, linii[z].LastIndexOf(' ')));
                                w = Convert.ToInt32(linii[z].Substring(linii[z].LastIndexOf(' ') + 1, linii[z].LastIndexOf('.') - linii[z].LastIndexOf(' ') - 1));
                                //richTextBox2.SelectedText += q.ToString() + ' ' + w.ToString() + ' ' + ee.ToString() + ' ' + r.ToString() + "\n";
                                imagineTestElev[z] = new PictureBox();
                                this.imagineTestElev[z].Location = new System.Drawing.Point(q, w);
                                this.imagineTestElev[z].Name = "pictureBo" + z.ToString();
                                Size tempSize = imagineTestElev[z].Size;
                                this.imagineTestElev[z].SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                                this.imagineTestElev[z].TabStop = false;
                                this.imagineTestElev[z].TabIndex = z;
                                this.imagineTestElev[z].Image = System.Drawing.Image.FromFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestElev + "\\Imagini\\" + "imagine" + z.ToString() + ".jpg");//File.Open("D:\\Proiect\\Teste\\Chimie\\" + x + "\\Imagini\\" + z.ToString(), 

                                string sa = z.ToString();
                                Controls.Add(imagineTestElev[z]);
                                imagineTestElev[z].BringToFront();
                            }

                        }

                    }

                //inaltimea richtextboxului
                pos.X = ClientRectangle.Width;
                pos.Y = ClientRectangle.Height;
                int lastIndex = enuntTestElev[kTestElev].GetCharIndexFromPosition(pos);
                int lastLine = enuntTestElev[kTestElev].GetLineFromCharIndex(lastIndex) + 1;
                enuntTestElev[kTestElev].Height = inaltimiCasuteTestElev[kTestElev];

                lbTestElev[kTestElev] = new Label();
                lbTestElev[kTestElev].Text = "Raspuns: ";
                lbTestElev[kTestElev].Name = "label" + kTestElev;
                lbTestElev[kTestElev].BackColor = System.Drawing.Color.Transparent;
                this.lbTestElev[kTestElev].Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                NrProblemaTestElev[kTestElev] = new Label();
                int numar;
                numar = kTestElev + 1;
                NrProblemaTestElev[kTestElev].Text = "Problema " + numar;
                NrProblemaTestElev[kTestElev].AutoSize = true;
                NrProblemaTestElev[kTestElev].Name = "Nrproblema" + kTestElev;
                NrProblemaTestElev[kTestElev].BackColor = System.Drawing.Color.Transparent;
                this.NrProblemaTestElev[kTestElev].Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //pozitia label-ului "Raspuns"
                if (kTestElev == 0)
                {
                    lbTestElev[kTestElev].Location = new Point(0, enuntTestElev[kTestElev].Height + 40);
                    raspunsTestElev[kTestElev].Location = new Point(120, enuntTestElev[kTestElev].Height + 40);
                    NrProblemaTestElev[kTestElev].Location = new Point(245, enuntTestElev[kTestElev].Location.Y - 30);

                    buton10TestElev.Location = new Point(45, enuntTestElev[kTestElev].Height + 70);
                    InfoAmTerminatTestElevPicture.Location = new Point(14, enuntTestElev[kTestElev].Height + 70 - 5);

                    buton30TestElev.Location = new Point(179, enuntTestElev[kTestElev].Height + 70);
                    LockPrintTestElevPicture.Location = new Point(148, enuntTestElev[kTestElev].Height + 70 - 5);
                }
                else
                    if (kTestElev > 0)
                    {
                        lbTestElev[kTestElev].Location = new Point(0, lbTestElev[kTestElev - 1].Location.Y + enuntTestElev[kTestElev].Height + 100);// - 35);
                        raspunsTestElev[kTestElev].Location = new Point(120, lbTestElev[kTestElev - 1].Location.Y + enuntTestElev[kTestElev].Height + 100);
                        NrProblemaTestElev[kTestElev].Location = new Point(245, enuntTestElev[kTestElev].Location.Y - 30);

                        buton10TestElev.Location = new Point(45, lbTestElev[kTestElev - 1].Location.Y + enuntTestElev[kTestElev].Height + 130);
                        InfoAmTerminatTestElevPicture.Location = new Point(14, lbTestElev[kTestElev - 1].Location.Y + enuntTestElev[kTestElev].Height + 130 - 5);

                        buton30TestElev.Location = new Point(179, lbTestElev[kTestElev - 1].Location.Y + enuntTestElev[kTestElev].Height + 130);
                        LockPrintTestElevPicture.Location = new Point(148, lbTestElev[kTestElev - 1].Location.Y + enuntTestElev[kTestElev].Height + 130 - 5);
                    }
                this.Controls.Add(lbTestElev[kTestElev]);
                this.Controls.Add(raspunsTestElev[kTestElev]);
                this.Controls.Add(NrProblemaTestElev[kTestElev]);
                if (kTestElev == numarRTTestElev - 1)
                {
                    buton10TestElev.Text = "Am terminat";
                    buton10TestElev.AutoSize = true;
                    buton30TestElev.Text = "Vezi răspunsuri";
                    buton30TestElev.AutoSize = true;
                    this.buton10TestElev.Click += new System.EventHandler(this.button1_Click);
                    this.Controls.Add(buton10TestElev);
                    this.Controls.Add(buton30TestElev);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewRaspunsTest rasp = new NewRaspunsTest(locatieTestElev, numeleMateriei);
            rasp.Show();
            buton10TestElev.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime top = DateTime.Now;
            TimeSpan timp = top - dt;
            if ((MinuteTestElev == 0) && (SecundeTestElev == 0))
            {
                MinuteLabelTestElev.Hide();
                SecundeLabelTestElev.Text = "gata";
                CronometruTestElev.Stop();
                buton10TestElev.Enabled = false;
                buton30TestElev.Enabled = true;
                button1_Click(sender, e);
            }
            else
            {
                TimeSpanConverter lala = new TimeSpanConverter();

                if (SecundeTestElev < 1)
                {
                    SecundeTestElev = 59;
                    if (MinuteTestElev == 0)
                    {
                        MinuteTestElev = 59;
                    }
                    else
                    {
                        MinuteTestElev--;
                    }
                }
                else
                {
                    SecundeTestElev--;
                }
            }
            MinuteLabelTestElev.Text = MinuteTestElev.ToString();
            SecundeLabelTestElev.Text = SecundeTestElev.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Forma răspunsurilor va fi următoarea: răspuns1; răspuns2;....răspuns n (răspunsurile fiind despărțite prin ;");
        }

        bool aApasatPeIncepe = false;

        private void NewTest_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Deschidere.Default.aDeschisUnTest == true)
            {
                if (buton10TestElev.Enabled == true && aApasatPeIncepe == true)
                {
                    if (MessageBox.Show("Daca iesi, punctajul tau va fi stabilit in urma raspunsurilor date pana acum!" +
                        '\n' + "Esti sigur ca vrei sa renunti?", "ATENTIE!!!",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        buton10TestElev.PerformClick();
                        Deschidere.Default.aDeschisUnTest = false;
                        Deschidere.Default.Save();
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                    if (buton10TestElev.Enabled == false)
                    {
                        buton10TestElev.PerformClick();
                        Deschidere.Default.aDeschisUnTest = false;
                        Deschidere.Default.Save();
                        e.Cancel = false;
                    }
                    else
                        if (aApasatPeIncepe == false)
                        {
                            Deschidere.Default.aDeschisUnTest = false;
                            Deschidere.Default.Save();
                            e.Cancel = false;
                        }
            }
        }
    }
}
