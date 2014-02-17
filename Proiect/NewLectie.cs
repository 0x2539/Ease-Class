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
using System.IO;

namespace Proiect
{
    public partial class NewLectie : Form
    {

        AxWMPLib.AxWindowsMediaPlayer[] videosVeziLectie = new AxWMPLib.AxWindowsMediaPlayer[40];
        RichTextBox[] texteVeziLectie = new RichTextBox[40];
        PictureBox[] imagineVeziLectie = new PictureBox[40];
        int nrVideoVeziLectie = 0;
        int nrTexteVeziLectie = 0;
        int nrImaginiVeziLectie = 0;

        private string locatieVeziLectie;
        public string tipUtilizator = "";

        string numeleMateriei = "";
        string userName = "";

        public NewLectie(string location, string utilizator, string Materie, string numeUtilizator)
        {
            InitializeComponent();
            locatieVeziLectie = location;
            userName = numeUtilizator;
            tipUtilizator = utilizator;
            numeleMateriei = Materie;
            this.Text = "Lectia " + locatieVeziLectie + " (" + numeleMateriei + ")";


            //MessageBox.Show(richTextBox1.Text + '\n' + '\n' + '\n' + richTextBox2.Text + '\n' + '\n' + '\n' + richTextBox3.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NewListaLectiiSiTeste mate2 = new NewListaLectiiSiTeste(numeleMateriei, tipUtilizator, userName);
            mate2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + locatieVeziLectie + "\\Video"))
            {
                nrVideoVeziLectie = Directory.GetFiles(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + locatieVeziLectie + "\\Video\\").Length - 1;
                richTextBox1VeziLectie.Text = System.IO.File.ReadAllText(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + locatieVeziLectie + "\\Video\\setari");
                string[] pozitiiV = richTextBox1VeziLectie.Text.Split('\n');

                for (int i = 0; i < nrVideoVeziLectie; i++)
                {
                    string poz1, poz2;

                    poz1 = pozitiiV[i].Substring(0, pozitiiV[i].IndexOf(' '));
                    poz2 = pozitiiV[i].Substring(pozitiiV[i].IndexOf(' ') + 1, pozitiiV[i].Length - pozitiiV[i].IndexOf(' ') - 1);

                    videosVeziLectie[i] = new AxWMPLib.AxWindowsMediaPlayer();
                    videosVeziLectie[i].Enabled = true;

                    videosVeziLectie[i].Location = new Point(0, Convert.ToInt32(poz2));

                    videosVeziLectie[i].Size = new System.Drawing.Size(651, 450);
                    videosVeziLectie[i].Visible = true;


                    //MessageBox.Show("D:\\Proiect\\Lectii\\Chimie\\" + x + "\\Video\\" + i + ".avi");


                    Controls.Add(videosVeziLectie[i]);

                    videosVeziLectie[i].URL = Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + locatieVeziLectie + "\\Video\\" + i + ".avi";
                    videosVeziLectie[i].Ctlcontrols.stop();
                }
            }
        }

        private void VideoChimie_Load(object sender, EventArgs e)
        {
            int totalV = 0, totalT = 0;

            richTextBox4VeziLectie.LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + locatieVeziLectie + "\\setari", RichTextBoxStreamType.PlainText);
            string[] pozi = richTextBox4VeziLectie.Text.Split('\n');
            int nr = 0;

            //vad care e numarul total de randuri
            for (int i = 0; i < richTextBox4VeziLectie.Text.Length; i++)
            {
                if (richTextBox4VeziLectie.Text[i] == '\n')
                {
                    nr++;
                }
            }
            //incarc videourile si textele
            for (int i = 0; i < nr; i++)
            {
                //daca este video
                if (pozi[i][0] != 'T')
                {
                    int numar = Convert.ToInt32(pozi[i]);

                    videosVeziLectie[totalV] = new AxWMPLib.AxWindowsMediaPlayer();
                    videosVeziLectie[totalV].Enabled = true;
                    //daca e primul control din form, merge pe pozitia 0,0
                    if (i == 0)
                    {
                        videosVeziLectie[totalV].Location = new Point(0, 0);
                    }
                    else
                    {
                        //daca a avut inainte tot un film
                        if (pozi[i - 1][0] != 'T')
                        {
                            videosVeziLectie[totalV].Location = new Point(0, videosVeziLectie[totalV - 1].Location.Y + 515);
                        }
                        //daca a avut inainte un text
                        else
                        {
                            Point pos = new Point(0, 0);
                            //inaltimea richtextboxului
                            pos.X = ClientRectangle.Width;
                            pos.Y = ClientRectangle.Height;
                            int lastIndex = texteVeziLectie[totalT - 1].GetCharIndexFromPosition(pos);
                            int lastLine = texteVeziLectie[totalT - 1].GetLineFromCharIndex(lastIndex) + 1;
                            texteVeziLectie[totalT - 1].Height = lastLine * 14;

                            videosVeziLectie[totalV].Location = new Point(0, texteVeziLectie[totalT - 1].Location.Y + texteVeziLectie[totalT - 1].Height + 30);
                        }
                    }

                    videosVeziLectie[totalV].Size = new System.Drawing.Size(651, 484);
                    videosVeziLectie[totalV].Visible = true;
                    Controls.Add(videosVeziLectie[totalV]);

                    videosVeziLectie[totalV].URL = Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + locatieVeziLectie + "\\Video\\" + numar + ".avi";
                    videosVeziLectie[totalV].Ctlcontrols.stop();

                    totalV++;
                }
                else
                {
                    int numar2 = Convert.ToInt32(pozi[i].Substring(1, pozi[i].Length - 1));

                    texteVeziLectie[totalT] = new RichTextBox();

                    if (i == 0)
                    {
                        texteVeziLectie[totalT].Location = new Point(0, 0);
                    }
                    else
                    {
                        //daca a avut inainte tot un film
                        if (pozi[i - 1][0] != 'T')
                        {
                            texteVeziLectie[totalT].Location = new Point(0, videosVeziLectie[totalV - 1].Location.Y + 515);
                        }
                        else
                        {
                            Point pos = new Point(0, 0);
                            //inaltimea richtextboxului
                            pos.X = ClientRectangle.Width;
                            pos.Y = ClientRectangle.Height;
                            int lastIndex = texteVeziLectie[totalT - 1].GetCharIndexFromPosition(pos);
                            int lastLine = texteVeziLectie[totalT - 1].GetLineFromCharIndex(lastIndex) + 1;
                            texteVeziLectie[totalT - 1].Height = lastLine * 14;

                            texteVeziLectie[totalT].Location = new Point(0, texteVeziLectie[totalT - 1].Location.Y + texteVeziLectie[totalT - 1].Height + 30);
                        }
                        //texteVeziLectie[numar].Location = new Point(0, Convert.ToInt32(poz2));
                    }

                    texteVeziLectie[totalT].BackColor = System.Drawing.SystemColors.Control;
                    texteVeziLectie[totalT].ReadOnly = true;
                    texteVeziLectie[totalT].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
                    texteVeziLectie[totalT].Size = new System.Drawing.Size(665, 10);
                    texteVeziLectie[totalT].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    texteVeziLectie[totalT].LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + locatieVeziLectie + "\\Text\\T" + numar2, RichTextBoxStreamType.PlainText);

                    Point pos2 = new Point(0, 0);
                    pos2.X = ClientRectangle.Width;
                    pos2.Y = ClientRectangle.Height;
                    int lastIndex2 = texteVeziLectie[totalT].GetCharIndexFromPosition(pos2);
                    int lastLine2 = texteVeziLectie[totalT].GetLineFromCharIndex(lastIndex2) + 1;
                    texteVeziLectie[totalT].Height = lastLine2 * 14;

                    Controls.Add(texteVeziLectie[totalT]);

                    totalT++;
                }
            }
            if (Directory.Exists(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + locatieVeziLectie + "\\Imagini"))
            {
                nrImaginiVeziLectie = Directory.GetFiles(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + locatieVeziLectie + "\\Imagini").Length - 1;
                if (nrImaginiVeziLectie != 0)
                {
                    string qq = "";
                    richTextBox2VeziLectie.LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + locatieVeziLectie + "\\Imagini\\setari");
                    string[] linii = richTextBox2VeziLectie.Lines;
                    int q = 0, w = 0, ee = 0, r = 0;//q-location.x w-location.y e-width r-height
                    for (int z = 0; z < nrImaginiVeziLectie; z++)
                    {
                        q = Convert.ToInt32(linii[z].Substring(0, linii[z].LastIndexOf(' ')));
                        w = Convert.ToInt32(linii[z].Substring(linii[z].LastIndexOf(' ') + 1, linii[z].LastIndexOf('.') - linii[z].LastIndexOf(' ') - 1));
                        //richTextBox2.SelectedText += q.ToString() + ' ' + w.ToString() + ' ' + ee.ToString() + ' ' + r.ToString() + "\n";
                        imagineVeziLectie[z] = new PictureBox();
                        this.imagineVeziLectie[z].Location = new System.Drawing.Point(q, w);
                        Size tempSize = imagineVeziLectie[z].Size;
                        this.imagineVeziLectie[z].SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                        this.imagineVeziLectie[z].TabStop = false;
                        this.imagineVeziLectie[z].Image = System.Drawing.Image.FromFile(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + locatieVeziLectie + "\\Imagini\\" + "imagine" + z.ToString() + ".jpg");

                        string sa = z.ToString();
                        Controls.Add(imagineVeziLectie[z]);
                        imagineVeziLectie[z].BringToFront();
                    }
                }
            }
            /*
            if (Directory.Exists("D:\\Proiect\\Lectii\\Chimie\\" + locatieVeziLectie + "\\Video"))
            {
                nrVideo = Directory.GetFiles("D:\\Proiect\\Lectii\\Chimie\\" + locatieVeziLectie + "\\Video\\").Length - 1;
                richTextBox1.Text = System.IO.File.ReadAllText("D:\\Proiect\\Lectii\\Chimie\\" + locatieVeziLectie + "\\Video\\setari");
                string[] pozitiiV = richTextBox1.Text.Split('\n');

                for (int i = 0; i < nrVideo; i++)
                {
                    string poz1, poz2;

                    poz1 = pozitiiV[i].Substring(0, pozitiiV[i].IndexOf(' '));
                    poz2 = pozitiiV[i].Substring(pozitiiV[i].IndexOf(' ') + 1, pozitiiV[i].Length - pozitiiV[i].IndexOf(' ') - 1);

                    videosVeziLectie[i] = new AxWMPLib.AxWindowsMediaPlayer();
                    videosVeziLectie[i].Enabled = true;

                    videosVeziLectie[i].Location = new Point(0, Convert.ToInt32(poz2));

                    videosVeziLectie[i].Size = new System.Drawing.Size(651, 484);
                    videosVeziLectie[i].Visible = true;


                    //MessageBox.Show("D:\\Proiect\\Lectii\\Chimie\\" + x + "\\Video\\" + i + ".avi");


                    Controls.Add(videosVeziLectie[i]);

                    videosVeziLectie[i].URL = "D:\\Proiect\\Lectii\\Chimie\\" + locatieVeziLectie + "\\Video\\" + i + ".avi";
                    videosVeziLectie[i].Ctlcontrols.stop();
                }
            }

            if (Directory.Exists("D:\\Proiect\\Lectii\\Chimie\\" + locatieVeziLectie + "\\Text"))
            {
                nrTexte = Directory.GetFiles("D:\\Proiect\\Lectii\\Chimie\\" + locatieVeziLectie + "\\Text\\").Length - 1;
                richTextBox2.Text = System.IO.File.ReadAllText("D:\\Proiect\\Lectii\\Chimie\\" + locatieVeziLectie + "\\Text\\setari");
                string[] pozitiiT = richTextBox2.Text.Split('\n');

                for (int i = 0; i < nrTexte; i++)
                {
                    string poz1, poz2;

                    poz1 = pozitiiT[i].Substring(0, pozitiiT[i].IndexOf(' '));
                    poz2 = pozitiiT[i].Substring(pozitiiT[i].IndexOf(' ') + 1, pozitiiT[i].Length - pozitiiT[i].IndexOf(' ') - 1);

                    texteVeziLectie[i] = new RichTextBox();
                    texteVeziLectie[i].Location = new Point(0, Convert.ToInt32(poz2));
                    texteVeziLectie[i].BackColor = System.Drawing.SystemColors.Control;
                    texteVeziLectie[i].ReadOnly = true;
                    texteVeziLectie[i].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
                    texteVeziLectie[i].Size = new System.Drawing.Size(600, 10);
                    texteVeziLectie[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    texteVeziLectie[i].LoadFile("D:\\Proiect\\Lectii\\Chimie\\" + locatieVeziLectie + "\\Text\\T" + i, RichTextBoxStreamType.PlainText);

                    Point pos = new Point(0, 0);
                    pos.X = ClientRectangle.Width;
                    pos.Y = ClientRectangle.Height;
                    int lastIndex = texteVeziLectie[i].GetCharIndexFromPosition(pos);
                    int lastLine = texteVeziLectie[i].GetLineFromCharIndex(lastIndex) + 1;
                    texteVeziLectie[i].Height = lastLine * 14;

                    Controls.Add(texteVeziLectie[i]);
                }
            }

            if (Directory.Exists("D:\\Proiect\\Lectii\\Chimie\\" + locatieVeziLectie + "\\Imagini"))
            {
                nrImagini = Directory.GetFiles("D:\\Proiect\\Lectii\\Chimie\\" + locatieVeziLectie + "\\Imagini\\").Length - 1;
                richTextBox3.Text = System.IO.File.ReadAllText("D:\\Proiect\\Lectii\\Chimie\\" + locatieVeziLectie + "\\Imagini\\setari");
                string[] pozitiiI = richTextBox3.Text.Split('\n');
            }

            */
        }
    }

}
