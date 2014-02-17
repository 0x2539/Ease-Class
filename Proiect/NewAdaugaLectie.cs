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
    public partial class NewAdaugaLectie : Form
    {

        //richtextbox1 va retine datele despre pozitia videourilor
        //richtextbox2 va retine datele despre pozitia texturilor
        //richtextbox3 va retine datele despre pozitia imaginilor
        AxWMPLib.AxWindowsMediaPlayer[] videosAdaugaLectie = new AxWMPLib.AxWindowsMediaPlayer[40];
        RichTextBox[] texteAdaugaLectie = new RichTextBox[40];
        PictureBox[] imagineAdaugaLectie = new PictureBox[40];

        int[] positionsAdaugaLectie = new int[40];

        int k1 = 0;//retine numarul de videos
        int k2 = 0;//retine numarul de texte
        int kimg = 0;//retine numarul de imagini
        int x1AdaugaLectie, y1AdaugaLectie, x2AdaugaLectie, y2AdaugaLectie,
            x3AdaugaLectie, y3AdaugaLectie, x4AdaugaLectie, y4AdaugaLectie;
        string[] folderimgAdaugaLectie = new String[120];
        string[] locatiiAdaugaLectie = new string[40];
        string[] locatiiIMGAdaugaLectie = new string[40];
        string[] numeAdaugaLectie = new string[40];
        string[] caiAdaugaLectie = new string[40];
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewAdaugaLectie));

        string numeleMateriei = "";

        public NewAdaugaLectie(string Materie)
        {
            InitializeComponent();
            this.Text += " (" + Materie + ")";
            NumeLectieAdaugaLectie.Focus();
            numeleMateriei = Materie;
        }

        private void button1_Click_1AdaugaLectie(object sender, EventArgs e)
        {

            if (NumeLectieAdaugaLectie.Text != "")
            {

                if (Directory.Exists(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text) == false)
                {

                    OpenFileDialog of = new OpenFileDialog();
                    if (of.ShowDialog() != System.Windows.Forms.DialogResult.Cancel &&
                                   of.FileName.Length > 0)// && of[k].ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                    {
                        richTextBox4AdaugaLectie.Text += k1.ToString() + '\n';

                        label1AdaugaLectie.Visible = false;
                        NumeLectieAdaugaLectie.Visible = false;
                        label4AdaugaLectie.Visible = false;
                        label5AdaugaLectie.Visible = false;
                        DetaliiAdaugaLectie.Hide();

                        string calea = of.FileName.Substring(0, of.FileName.LastIndexOf('\\'));

                        caiAdaugaLectie[k1] = calea;
                        numeAdaugaLectie[k1] = of.SafeFileName;
                        locatiiAdaugaLectie[k1] = of.FileName;
                        //MessageBox.Show(locatii[k1]);

                        videosAdaugaLectie[k1] = new AxWMPLib.AxWindowsMediaPlayer();
                        videosAdaugaLectie[k1].Enabled = true;


                        x1AdaugaLectie = AdaugaVideoButtonAdaugaLectie.Location.X;
                        y1AdaugaLectie = AdaugaVideoButtonAdaugaLectie.Location.Y;

                        x2AdaugaLectie = AdaugaTextButtonAdaugaLectie.Location.X;
                        y2AdaugaLectie = AdaugaTextButtonAdaugaLectie.Location.Y;

                        x3AdaugaLectie = AdaugaImagineButtonAdaugaLectie.Location.X;
                        y3AdaugaLectie = AdaugaImagineButtonAdaugaLectie.Location.Y;

                        x4AdaugaLectie = SalveazaButtonAdaugaLectie.Location.X;
                        y4AdaugaLectie = SalveazaButtonAdaugaLectie.Location.Y;

                        if (k2 == 0 && k1 == 0)
                        {
                            videosAdaugaLectie[k1].Location = new System.Drawing.Point(0, 0);
                            //richTextBox1.Text = "0" + '\n';
                            AdaugaTextPictureAdaugaLectie.Location = new Point(AdaugaTextPictureAdaugaLectie.Location.X, AdaugaTextButtonAdaugaLectie.Location.Y + 450 - 6);
                            AdaugaTextButtonAdaugaLectie.Location = new Point(AdaugaTextButtonAdaugaLectie.Location.X, AdaugaTextButtonAdaugaLectie.Location.Y + 450);

                            AdaugaImaginePictureAdaugaLectie.Location = new Point(AdaugaImaginePictureAdaugaLectie.Location.X, AdaugaImagineButtonAdaugaLectie.Location.Y + 450 - 6);
                            AdaugaImagineButtonAdaugaLectie.Location = new Point(AdaugaImagineButtonAdaugaLectie.Location.X, AdaugaImagineButtonAdaugaLectie.Location.Y + 450);

                            AdaugaVideoPictureAdaugaLectie.Location = new Point(AdaugaVideoPictureAdaugaLectie.Location.X, AdaugaVideoButtonAdaugaLectie.Location.Y + 450 - 6);
                            AdaugaVideoButtonAdaugaLectie.Location = new Point(AdaugaVideoButtonAdaugaLectie.Location.X, AdaugaVideoButtonAdaugaLectie.Location.Y + 450);

                            SalveazaPictureAdaugaLectie.Location = new Point(SalveazaPictureAdaugaLectie.Location.X, SalveazaButtonAdaugaLectie.Location.Y + 450 - 6);
                            SalveazaButtonAdaugaLectie.Location = new Point(SalveazaButtonAdaugaLectie.Location.X, SalveazaButtonAdaugaLectie.Location.Y + 450);
                        }
                        else
                            if (k2 == 0)
                            {
                                videosAdaugaLectie[k1].Location = new Point(0, AdaugaVideoButtonAdaugaLectie.Location.Y - 515);
                                //richTextBox1.Text += (AdaugaVideo.Location.Y - 515).ToString() + '\n';

                                AdaugaTextPictureAdaugaLectie.Location = new Point(AdaugaTextPictureAdaugaLectie.Location.X, AdaugaTextButtonAdaugaLectie.Location.Y + 515 - 6);
                                AdaugaTextButtonAdaugaLectie.Location = new Point(AdaugaTextButtonAdaugaLectie.Location.X, AdaugaTextButtonAdaugaLectie.Location.Y + 515);

                                AdaugaImaginePictureAdaugaLectie.Location = new Point(AdaugaImaginePictureAdaugaLectie.Location.X, AdaugaImagineButtonAdaugaLectie.Location.Y + 515 - 6);
                                AdaugaImagineButtonAdaugaLectie.Location = new Point(AdaugaImagineButtonAdaugaLectie.Location.X, AdaugaImagineButtonAdaugaLectie.Location.Y + 515);

                                AdaugaVideoPictureAdaugaLectie.Location = new Point(AdaugaVideoPictureAdaugaLectie.Location.X, AdaugaVideoButtonAdaugaLectie.Location.Y + 515 - 6);
                                AdaugaVideoButtonAdaugaLectie.Location = new Point(AdaugaVideoButtonAdaugaLectie.Location.X, AdaugaVideoButtonAdaugaLectie.Location.Y + 515);

                                SalveazaPictureAdaugaLectie.Location = new Point(SalveazaPictureAdaugaLectie.Location.X, SalveazaButtonAdaugaLectie.Location.Y + 515 - 6);
                                SalveazaButtonAdaugaLectie.Location = new Point(SalveazaButtonAdaugaLectie.Location.X, SalveazaButtonAdaugaLectie.Location.Y + 515);
                            }
                            else
                            {
                                //richTextBox1.Text += (AdaugaVideo.Location.Y - 515).ToString() + '\n';

                                AdaugaTextPictureAdaugaLectie.Location = new Point(AdaugaTextPictureAdaugaLectie.Location.X, AdaugaTextButtonAdaugaLectie.Location.Y + 515 - 6);
                                AdaugaTextButtonAdaugaLectie.Location = new Point(AdaugaTextButtonAdaugaLectie.Location.X, AdaugaTextButtonAdaugaLectie.Location.Y + 515);

                                AdaugaImaginePictureAdaugaLectie.Location = new Point(AdaugaImaginePictureAdaugaLectie.Location.X, AdaugaImagineButtonAdaugaLectie.Location.Y + 515 - 6);
                                AdaugaImagineButtonAdaugaLectie.Location = new Point(AdaugaImagineButtonAdaugaLectie.Location.X, AdaugaImagineButtonAdaugaLectie.Location.Y + 515);

                                AdaugaVideoPictureAdaugaLectie.Location = new Point(AdaugaVideoPictureAdaugaLectie.Location.X, AdaugaVideoButtonAdaugaLectie.Location.Y + 515 - 6);
                                AdaugaVideoButtonAdaugaLectie.Location = new Point(AdaugaVideoButtonAdaugaLectie.Location.X, AdaugaVideoButtonAdaugaLectie.Location.Y + 515);

                                SalveazaPictureAdaugaLectie.Location = new Point(SalveazaPictureAdaugaLectie.Location.X, SalveazaButtonAdaugaLectie.Location.Y + 515 - 6);
                                SalveazaButtonAdaugaLectie.Location = new Point(SalveazaButtonAdaugaLectie.Location.X, SalveazaButtonAdaugaLectie.Location.Y + 515);

                                videosAdaugaLectie[k1].Location = new Point(0, AdaugaVideoButtonAdaugaLectie.Location.Y - 515);
                            }


                        videosAdaugaLectie[k1].Size = new System.Drawing.Size(651, 484);
                        videosAdaugaLectie[k1].Visible = true;

                        Controls.Add(videosAdaugaLectie[k1]);

                        videosAdaugaLectie[k1].URL = locatiiAdaugaLectie[k1];
                        videosAdaugaLectie[k1].Ctlcontrols.stop();
                        k1++;

                    }
                }
                else
                {
                    MessageBox.Show("Nume deja existent!" + '\n' + "Introduceți alt nume!");
                }
            }
        }


        private void button3_ClickAdaugaLectie(object sender, EventArgs e)
        {
            if (k1 != 0 || k2 != 0 || kimg != 0)
            {
                if (NumeLectieAdaugaLectie.Text != "")
                {
                    richTextBox1AdaugaLectie.Text = "";
                    richTextBox2AdaugaLectie.Text = "";
                    richTextBox3AdaugaLectie.Text = "";

                    //MessageBox.Show(richTextBox4.Text);
                    for (int i = 0; i < k1; i++)
                    {
                        string poz = "", hjk = "", pozitii = "";
                        poz = PointToScreen(videosAdaugaLectie[i].Location).ToString();

                        hjk = poz.Substring(poz.IndexOf('=') + 1, poz.IndexOf(',') - poz.IndexOf('=') - 1);
                        hjk += ' ' + poz.Substring(poz.LastIndexOf('=') + 1, poz.Length - poz.LastIndexOf('=') - 2);

                        pozitii = pozitii + hjk + ' ' + '\n';

                        richTextBox1AdaugaLectie.Text += pozitii;
                    }

                    for (int i = 0; i < k2; i++)
                    {
                        string poz = "", hjk = "", pozitii = "";
                        poz = PointToScreen(texteAdaugaLectie[i].Location).ToString();

                        hjk = poz.Substring(poz.IndexOf('=') + 1, poz.IndexOf(',') - poz.IndexOf('=') - 1);
                        hjk += ' ' + poz.Substring(poz.LastIndexOf('=') + 1, poz.Length - poz.LastIndexOf('=') - 2);

                        pozitii = pozitii + hjk + ' ' + '\n';
                        richTextBox2AdaugaLectie.Text += pozitii;



                        //richTextBox2.Text += texteAdaugaLectie[i].Location.Y + '\n';
                    }

                    Directory.CreateDirectory(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text);
                    richTextBox4AdaugaLectie.SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text + "\\setari", RichTextBoxStreamType.PlainText);


                    richTextBox5AdaugaLectie.Text = DetaliiAdaugaLectie.Text;
                    richTextBox5AdaugaLectie.SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text + "\\" + "detalii", RichTextBoxStreamType.PlainText);


                    for (int i = 0; i < k1; i++)
                    {
                        Directory.CreateDirectory(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text + "\\Video");

                        File.Copy(locatiiAdaugaLectie[i], Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text + "\\Video\\" + i + ".avi", true);

                        richTextBox1AdaugaLectie.SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text + "\\Video\\setari", RichTextBoxStreamType.PlainText);
                    }

                    for (int i = 0; i < k2; i++)
                    {
                        Directory.CreateDirectory(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text + "\\Text");

                        texteAdaugaLectie[i].SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text + "\\Text\\" + "T" + i, RichTextBoxStreamType.PlainText);

                        richTextBox2AdaugaLectie.SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text + "\\Text\\setari", RichTextBoxStreamType.PlainText);
                    }


                    if (kimg != 0)
                    {
                        Directory.CreateDirectory(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text + "\\Imagini\\");
                        for (int i = 0; i < kimg; i++)
                        {
                            string poz = "", hjk = "", pozitii = "";
                            poz = PointToScreen(imagineAdaugaLectie[i].Location).ToString();

                            hjk = poz.Substring(poz.IndexOf('=') + 1, poz.IndexOf(',') - poz.IndexOf('=') - 1);
                            hjk += ' ' + poz.Substring(poz.LastIndexOf('=') + 1, poz.Length - poz.LastIndexOf('=') - 2);

                            //pozitii = pozitii + hjk + ' ' + '\n';
                            pozitii += imagineAdaugaLectie[i].Location.X + " " + positionsAdaugaLectie[i] + "." + '\n';
                            richTextBox3AdaugaLectie.Text += pozitii;

                            File.Copy(folderimgAdaugaLectie[i], Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text + "\\Imagini\\" + "imagine" + i + ".jpg", true);
                        }

                        richTextBox3AdaugaLectie.SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text + "\\Imagini\\" + "setari", RichTextBoxStreamType.RichText);
                    }

                    Close();

                }
            }
        }

        private void AdaugaText_ClickAdaugaLectie(object sender, EventArgs e)
        {
            if (NumeLectieAdaugaLectie.Text != "")
            {

                if (Directory.Exists(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text) == false)
                {

                    Point pos = new Point(0, 0);
                    OpenFileDialog of = new OpenFileDialog();
                    if (of.ShowDialog() != System.Windows.Forms.DialogResult.Cancel &&
                                   of.FileName.Length > 0)// && of[k].ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                    {

                        richTextBox4AdaugaLectie.Text += "T" + k2 + '\n';

                        label1AdaugaLectie.Visible = false;
                        NumeLectieAdaugaLectie.Visible = false;
                        label5AdaugaLectie.Visible = false;
                        label4AdaugaLectie.Visible = false;
                        DetaliiAdaugaLectie.Hide();


                        texteAdaugaLectie[k2] = new RichTextBox();
                        texteAdaugaLectie[k2].BackColor = System.Drawing.Color.White;
                        texteAdaugaLectie[k2].ReadOnly = false;
                        texteAdaugaLectie[k2].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
                        texteAdaugaLectie[k2].Size = new System.Drawing.Size(665, 484);//(464, 10);
                        texteAdaugaLectie[k2].WordWrap = true;

                        if (of.FileName.Substring(of.FileName.LastIndexOf('.') + 1, of.FileName.Length - 1 - of.FileName.LastIndexOf('.')) == "txt")// ||
                            texteAdaugaLectie[k2].LoadFile(of.FileName, RichTextBoxStreamType.PlainText);
                        else
                            if (of.FileName.Substring(of.FileName.LastIndexOf('.') + 1, of.FileName.Length - 1 - of.FileName.LastIndexOf('.')) == "rtf")
                                texteAdaugaLectie[k2].LoadFile(of.FileName, RichTextBoxStreamType.RichText);

                        texteAdaugaLectie[k2].BorderStyle = System.Windows.Forms.BorderStyle.None;




                        if (k2 == 0 && k1 == 0)
                        {
                            texteAdaugaLectie[k2].Location = new Point(0, 0);
                            //richTextBox2.Text = "0" + '\n';
                        }
                        else
                            if (k1 == 0 && k2 == 1)
                            {
                                texteAdaugaLectie[k2].Location = new Point(0, AdaugaImagineButtonAdaugaLectie.Location.Y - 25);
                            }
                            else
                            {
                                texteAdaugaLectie[k2].Location = new Point(0, AdaugaImagineButtonAdaugaLectie.Location.Y + 10);
                            }


                        //inaltimea richtextboxului
                        pos.X = ClientRectangle.Width;
                        pos.Y = ClientRectangle.Height;
                        int lastIndex = texteAdaugaLectie[k2].GetCharIndexFromPosition(pos);
                        int lastLine = texteAdaugaLectie[k2].GetLineFromCharIndex(lastIndex) + 1;
                        texteAdaugaLectie[k2].Height = lastLine * 14;

                        Controls.Add(texteAdaugaLectie[k2]);


                        AdaugaImaginePictureAdaugaLectie.Location = new Point(AdaugaImaginePictureAdaugaLectie.Location.X, AdaugaImagineButtonAdaugaLectie.Location.Y + texteAdaugaLectie[0].Height + 20 - 6);
                        AdaugaImagineButtonAdaugaLectie.Location = new Point(AdaugaImagineButtonAdaugaLectie.Location.X, AdaugaImagineButtonAdaugaLectie.Location.Y + texteAdaugaLectie[0].Height + 20);

                        AdaugaVideoPictureAdaugaLectie.Location = new Point(AdaugaVideoPictureAdaugaLectie.Location.X, AdaugaVideoButtonAdaugaLectie.Location.Y + texteAdaugaLectie[0].Height + 20 - 6);
                        AdaugaVideoButtonAdaugaLectie.Location = new Point(AdaugaVideoButtonAdaugaLectie.Location.X, AdaugaVideoButtonAdaugaLectie.Location.Y + texteAdaugaLectie[0].Height + 20);

                        SalveazaPictureAdaugaLectie.Location = new Point(SalveazaPictureAdaugaLectie.Location.X, SalveazaButtonAdaugaLectie.Location.Y + texteAdaugaLectie[0].Height + 20 - 6);
                        SalveazaButtonAdaugaLectie.Location = new Point(SalveazaButtonAdaugaLectie.Location.X, SalveazaButtonAdaugaLectie.Location.Y + texteAdaugaLectie[0].Height + 20);

                        AdaugaTextPictureAdaugaLectie.Location = new Point(AdaugaTextPictureAdaugaLectie.Location.X, AdaugaTextButtonAdaugaLectie.Location.Y + texteAdaugaLectie[0].Height + 20 - 6);
                        AdaugaTextButtonAdaugaLectie.Location = new Point(AdaugaTextButtonAdaugaLectie.Location.X, AdaugaTextButtonAdaugaLectie.Location.Y + texteAdaugaLectie[0].Height + 20);

                        k2++;

                    }
                }
                else
                {
                    MessageBox.Show("Nume deja existent!" + '\n' + "Introduceți alt nume!");
                }
            }
        }

        private void textBox1_KeyPressAdaugaLectie(object sender, KeyPressEventArgs e)
        {
            if (NumeLectieAdaugaLectie.Text != "")
            {

                if (Directory.Exists(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text) == false)
                {
                    if (e.KeyChar == 13)
                    {
                        AdaugaVideoButtonAdaugaLectie.Enabled = true;
                        AdaugaTextButtonAdaugaLectie.Enabled = true;
                        AdaugaImagineButtonAdaugaLectie.Enabled = true;
                        SalveazaButtonAdaugaLectie.Enabled = true;
                        AdaugaVideoPictureAdaugaLectie.Image = global::Proiect.Properties.Resources.basket_add;
                        AdaugaTextPictureAdaugaLectie.Image = global::Proiect.Properties.Resources.file_edit;
                        AdaugaImaginePictureAdaugaLectie.Image = global::Proiect.Properties.Resources.photo_add;
                        SalveazaPictureAdaugaLectie.Image = global::Proiect.Properties.Resources.bullet_info;
                    }
                }
                else
                {
                    MessageBox.Show("Nume deja existent!" + '\n' + "Introduceți alt nume!");
                }
            }
        }

        private void AdaugaLectieChimie_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Hide();
        }

        private void AdaugaImagine_ClickAdaugaLectie(object sender, EventArgs e)
        {

            if (Directory.Exists(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text) == false)
            {
                imagineAdaugaLectie[kimg] = new PictureBox();
                OpenFileDialog of = new OpenFileDialog();
                if (of.ShowDialog() != System.Windows.Forms.DialogResult.Cancel &&
                               of.FileName.Length > 0)
                {
                    folderimgAdaugaLectie[kimg] = of.FileName;

                    imagineAdaugaLectie[kimg].Load(of.FileName);
                    imagineAdaugaLectie[kimg].SizeMode = PictureBoxSizeMode.AutoSize;
                    imagineAdaugaLectie[kimg].Location = new Point(AdaugaImagineButtonAdaugaLectie.Location.X + 50, AdaugaImagineButtonAdaugaLectie.Location.Y);

                    imagineAdaugaLectie[kimg].MouseUp += pictureBox1_MouseUpAdaugaLectie;
                    imagineAdaugaLectie[kimg].MouseMove += pictureBox1_MouseMoveAdaugaLectie;
                    imagineAdaugaLectie[kimg].MouseDown += pictureBox1_MouseDownAdaugaLectie;

                    Controls.Add(imagineAdaugaLectie[kimg]);
                    imagineAdaugaLectie[kimg].BringToFront();

                    kimg++;
                }
            }
            else
            {
                MessageBox.Show("Nume deja existent!" + '\n' + "Introduceți alt nume!");
            }
        }


        public Point pozitiaAdaugaLectie = new Point();
        public bool miscareAdaugaLectie = false;



        private void pictureBox1_MouseDownAdaugaLectie(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            for (int i = 0; i < kimg; i++)
            {
                if (sender.Equals(imagineAdaugaLectie[i]))
                {
                    imagineAdaugaLectie[i].BringToFront();
                    pozitiaAdaugaLectie = e.Location;
                    miscareAdaugaLectie = true;
                    break;
                }
            }
        }

        private void pictureBox1_MouseUpAdaugaLectie(object sender, MouseEventArgs e)
        {
            miscareAdaugaLectie = false;
            for (int i = 0; i < kimg; i++)
            {
                if (sender.Equals(imagineAdaugaLectie[i]))
                {
                    //MessageBox.Show(AutoScrollPosition.Y.ToString());
                    positionsAdaugaLectie[i] = 0 - AutoScrollPosition.Y + imagineAdaugaLectie[i].Location.Y;
                    break;
                }
            }
        }

        private void pictureBox1_MouseMoveAdaugaLectie(object sender, MouseEventArgs e)
        {
            if (miscareAdaugaLectie == false || e.Button != MouseButtons.Left)// || k2 == -1)
            {
                return;
            }
            for (int i = 0; i < kimg; i++)
            {
                if (sender.Equals(imagineAdaugaLectie[i]))
                {
                    imagineAdaugaLectie[i].Left += e.X - pozitiaAdaugaLectie.X;
                    imagineAdaugaLectie[i].Top += e.Y - pozitiaAdaugaLectie.Y;
                }
            }
        }

        private void AdaugaLectieChimie_Load(object sender, EventArgs e)
        {
            AdaugaVideoPictureAdaugaLectie.Image = global::Proiect.Properties.Resources.bullet_error;
            AdaugaTextPictureAdaugaLectie.Image = global::Proiect.Properties.Resources.bullet_error;
            AdaugaImaginePictureAdaugaLectie.Image = global::Proiect.Properties.Resources.bullet_error;
            SalveazaPictureAdaugaLectie.Image = global::Proiect.Properties.Resources.bullet_error;
        }

    }
}
