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

    public partial class NewAdaugaTest : Form
    {
        public int kglobalAdaugaTest;
        public string pozitiiAdaugaTest;
        public RichTextBox[] enuntAdaugaTest = new RichTextBox[40];
        public OpenFileDialog[] ofAdaugaTest = new OpenFileDialog[40];
        public RichTextBox[] raspunsAdaugaTest = new RichTextBox[40];
        public PictureBox[] imagineAdaugaTest = new PictureBox[40];
        public string[] folderimgAdaugaTest = new String[120];
        public Label[] lbAdaugaTest = new Label[40];
        public Label[] NrProblemaAdaugaTest = new Label[40];
        public int numarRTAdaugaTest = 0, kAdaugaTest = 0, nrAdaugaTest = 0, kimgAdaugaTest = 0;
        
        int[] positionsAdaugaTest = new int[40];

        string numeleMateriei = "";

        public NewAdaugaTest(string Materie)
        {
            InitializeComponent();

            this.Text += " (" + Materie + ")";
            
            numeleMateriei = Materie;

            textBox1AdaugaTest.Focus();

            if (Directory.Exists(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + Materie) == false)
            {
                Directory.CreateDirectory(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + Materie);
            }

            Point pos = new Point(0, 0);
            // creez RichTextBox1
            ofAdaugaTest[0] = new OpenFileDialog();
            ofAdaugaTest[0].FileName = "of" + 0;
            ofAdaugaTest[0].DefaultExt = "*.txt";
            ofAdaugaTest[0].Filter = "Text Files|*.txt|RTF Files|*.rtf";

            raspunsAdaugaTest[0] = new RichTextBox();
            raspunsAdaugaTest[0].Text = "asdasd";
            raspunsAdaugaTest[0].ReadOnly = false;

            enuntAdaugaTest[0] = new RichTextBox();
            enuntAdaugaTest[0].BackColor = System.Drawing.Color.White;
            enuntAdaugaTest[0].Location = new System.Drawing.Point(0, -30);// -110);
            enuntAdaugaTest[0].Name = "rt" + 0;
            enuntAdaugaTest[0].ReadOnly = false;
            enuntAdaugaTest[0].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            enuntAdaugaTest[0].Size = new System.Drawing.Size(500, 10);//(464, 10);
            enuntAdaugaTest[0].TabIndex = 7;
            enuntAdaugaTest[0].Text = "";
            enuntAdaugaTest[0].WordWrap = true;
            this.Controls.Add(enuntAdaugaTest[0]);
            this.Controls.Add(imagineAdaugaTest[0]);
            //Inaltime RichTextBox1
            if (ofAdaugaTest[0].FileName.Substring(ofAdaugaTest[0].FileName.LastIndexOf('.') + 1, ofAdaugaTest[0].FileName.Length - 1 - ofAdaugaTest[0].FileName.LastIndexOf('.')) == "txt")// ||
                enuntAdaugaTest[0].LoadFile(ofAdaugaTest[0].FileName, RichTextBoxStreamType.PlainText);
            else
                if (ofAdaugaTest[0].FileName.Substring(ofAdaugaTest[0].FileName.LastIndexOf('.') + 1, ofAdaugaTest[0].FileName.Length - 1 - ofAdaugaTest[0].FileName.LastIndexOf('.')) == "rtf")
                    enuntAdaugaTest[0].LoadFile(ofAdaugaTest[0].FileName, RichTextBoxStreamType.RichText);

            pos.X = 0;
            pos.Y = 0;
            int lastIndex = enuntAdaugaTest[0].GetCharIndexFromPosition(pos);
            int lastLine = enuntAdaugaTest[0].GetLineFromCharIndex(lastIndex) + 1;
            enuntAdaugaTest[0].Height = lastLine * 14;

            //button3.Location = new Point(220, button3.Location.Y + enuntAdaugaTest[0].Height);
            //button5.Location = new Point(120, button1.Location.Y + enuntAdaugaTest[0].Height);
            //button1.Location = new Point(0, button1.Location.Y + enuntAdaugaTest[0].Height);
            //button2.Location = new Point(button5.Location.X + 220, button5.Location.Y);
            //button3.Location = new Point(button5.Location.X + 110, button5.Location.Y);


        }

        public void button1_ClickAdaugaTest(object sender, EventArgs e)
        {
            try
            {

                if (kAdaugaTest < numarRTAdaugaTest)
                {
                    kAdaugaTest++;
                    if (raspunsAdaugaTest[kAdaugaTest - 1].Text != "")
                    {
                        Point pos = new Point(0, 0);
                        raspunsAdaugaTest[kAdaugaTest] = new RichTextBox();//casuta in care scriu raspunsul
                        enuntAdaugaTest[kAdaugaTest] = new RichTextBox();//casuta in care scriu enuntul
                        enuntAdaugaTest[39] = new RichTextBox();
                        ofAdaugaTest[kAdaugaTest] = new OpenFileDialog();

                        ofAdaugaTest[kAdaugaTest].DefaultExt = "*.txt";
                        ofAdaugaTest[kAdaugaTest].Filter = "Text Files|*.txt|RTF Files|*.rtf";

                        raspunsAdaugaTest[kAdaugaTest].BackColor = System.Drawing.Color.White;
                        raspunsAdaugaTest[kAdaugaTest].Name = "tb" + kAdaugaTest;
                        raspunsAdaugaTest[kAdaugaTest].ReadOnly = false;
                        raspunsAdaugaTest[kAdaugaTest].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
                        raspunsAdaugaTest[kAdaugaTest].Size = new System.Drawing.Size(504, 26);//(232, 26);
                        raspunsAdaugaTest[kAdaugaTest].TabIndex = kAdaugaTest + 7;
                        raspunsAdaugaTest[kAdaugaTest].Text = "";
                        raspunsAdaugaTest[kAdaugaTest].WordWrap = true;
                        if (ofAdaugaTest[kAdaugaTest].ShowDialog() != System.Windows.Forms.DialogResult.Cancel &&
                           ofAdaugaTest[kAdaugaTest].FileName.Length > 0)// && ofAdaugaTest[kAdaugaTest].ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                        {
                            //if-ul este pentru pozitia richtextbox-ului
                            if (kAdaugaTest == 1)
                            {
                                enuntAdaugaTest[kAdaugaTest].BackColor = System.Drawing.Color.White;
                                enuntAdaugaTest[kAdaugaTest].Name = "rt" + kAdaugaTest;
                                enuntAdaugaTest[kAdaugaTest].ReadOnly = false;
                                enuntAdaugaTest[kAdaugaTest].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
                                enuntAdaugaTest[kAdaugaTest].Size = new System.Drawing.Size(704, 10);//(464, 10);
                                enuntAdaugaTest[kAdaugaTest].TabIndex = kAdaugaTest + 7;
                                enuntAdaugaTest[kAdaugaTest].Text = "";
                                enuntAdaugaTest[kAdaugaTest].WordWrap = true;
                                this.enuntAdaugaTest[kAdaugaTest].BorderStyle = System.Windows.Forms.BorderStyle.None;

                                enuntAdaugaTest[kAdaugaTest].Location = new Point(0, enuntAdaugaTest[kAdaugaTest - 1].Location.Y + enuntAdaugaTest[kAdaugaTest - 1].Height + 45);
                                this.Controls.Add(enuntAdaugaTest[kAdaugaTest]);
                            }
                            else
                                if (kAdaugaTest > 1)
                                {
                                    enuntAdaugaTest[kAdaugaTest].BackColor = System.Drawing.Color.White;
                                    enuntAdaugaTest[kAdaugaTest].Name = "rt" + kAdaugaTest;
                                    enuntAdaugaTest[kAdaugaTest].ReadOnly = false;
                                    enuntAdaugaTest[kAdaugaTest].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
                                    enuntAdaugaTest[kAdaugaTest].Size = new System.Drawing.Size(704, 10);//(464, 10);
                                    enuntAdaugaTest[kAdaugaTest].TabIndex = kAdaugaTest + 7;
                                    enuntAdaugaTest[kAdaugaTest].Text = "";
                                    enuntAdaugaTest[kAdaugaTest].WordWrap = true;
                                    this.enuntAdaugaTest[kAdaugaTest].BorderStyle = System.Windows.Forms.BorderStyle.None;
                                    enuntAdaugaTest[kAdaugaTest].Location = new Point(0, lbAdaugaTest[kAdaugaTest - 1].Location.Y + 75);// rt[k - 1].Location.Y + rt[k - 1].Height + 15);
                                    this.Controls.Add(enuntAdaugaTest[kAdaugaTest]);
                                }

                            if (ofAdaugaTest[kAdaugaTest].FileName.Substring(ofAdaugaTest[kAdaugaTest].FileName.LastIndexOf('.') + 1, ofAdaugaTest[kAdaugaTest].FileName.Length - 1 - ofAdaugaTest[kAdaugaTest].FileName.LastIndexOf('.')) == "txt")// ||
                                enuntAdaugaTest[kAdaugaTest].LoadFile(ofAdaugaTest[kAdaugaTest].FileName, RichTextBoxStreamType.PlainText);
                            else
                                if (ofAdaugaTest[kAdaugaTest].FileName.Substring(ofAdaugaTest[kAdaugaTest].FileName.LastIndexOf('.') + 1, ofAdaugaTest[kAdaugaTest].FileName.Length - 1 - ofAdaugaTest[kAdaugaTest].FileName.LastIndexOf('.')) == "rtf")
                                    enuntAdaugaTest[kAdaugaTest].LoadFile(ofAdaugaTest[kAdaugaTest].FileName, RichTextBoxStreamType.RichText);

                            //inaltimea richtextboxului
                            pos.X = ClientRectangle.Width;
                            pos.Y = ClientRectangle.Height;
                            int lastIndex = enuntAdaugaTest[kAdaugaTest].GetCharIndexFromPosition(pos);
                            int lastLine = enuntAdaugaTest[kAdaugaTest].GetLineFromCharIndex(lastIndex) + 1;
                            enuntAdaugaTest[kAdaugaTest].Height = lastLine * 14;

                            //AddProblema.Hide();
                            AdaugaProblemaButtonAdaugaTest.Enabled = false;
                            SalveazaButtonAdaugaTest.Enabled = false;
                            //pictureBox4.Hide();
                            //button3.Hide();
                            AdaugaEnuntPictureAdaugaTest.Image = global::Proiect.Properties.Resources.file_edit;
                            AdaugaProblemaPictureAdaugaTest.Image = global::Proiect.Properties.Resources.bullet_error;
                            SalveazaPictureAdaugaTest.Image = global::Proiect.Properties.Resources.bullet_error;


                            lbAdaugaTest[kAdaugaTest] = new Label();
                            lbAdaugaTest[kAdaugaTest].Text = "Raspuns: ";
                            lbAdaugaTest[kAdaugaTest].Name = "label" + kAdaugaTest;
                            lbAdaugaTest[kAdaugaTest].BackColor = System.Drawing.Color.Transparent;
                            this.lbAdaugaTest[kAdaugaTest].Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                            NrProblemaAdaugaTest[kAdaugaTest] = new Label();
                            NrProblemaAdaugaTest[kAdaugaTest].AutoSize = true;
                            NrProblemaAdaugaTest[kAdaugaTest].Text = "Problema " + kAdaugaTest;
                            NrProblemaAdaugaTest[kAdaugaTest].Name = "Nrproblema" + kAdaugaTest;
                            NrProblemaAdaugaTest[kAdaugaTest].BackColor = System.Drawing.Color.Transparent;
                            this.NrProblemaAdaugaTest[kAdaugaTest].Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                            //pozitia label-ului "Raspuns"
                            if (kAdaugaTest == 1)
                            {
                                lbAdaugaTest[kAdaugaTest].Location = new Point(0, enuntAdaugaTest[kAdaugaTest].Height + 40);
                                NrProblemaAdaugaTest[kAdaugaTest].Location = new Point(245, enuntAdaugaTest[kAdaugaTest].Location.Y - 30); //+ enuntAdaugaTest[k - 1].Height + 15);//la mijlocul randului
                                raspunsAdaugaTest[kAdaugaTest].Location = new Point(120, enuntAdaugaTest[kAdaugaTest].Height + 40);
                            }
                            else
                                if (kAdaugaTest > 1)
                                {
                                    lbAdaugaTest[kAdaugaTest].Location = new Point(0, AdaugaEnuntButtonAdaugaTest.Location.Y + enuntAdaugaTest[kAdaugaTest].Height + 50);// - 35);
                                    NrProblemaAdaugaTest[kAdaugaTest].Location = new Point(245, lbAdaugaTest[kAdaugaTest - 1].Location.Y + 45);// - 35);
                                    raspunsAdaugaTest[kAdaugaTest].Location = new Point(120, lbAdaugaTest[kAdaugaTest].Location.Y - 2);
                                }
                            this.Controls.Add(NrProblemaAdaugaTest[kAdaugaTest]);
                            this.Controls.Add(lbAdaugaTest[kAdaugaTest]);
                            this.Controls.Add(raspunsAdaugaTest[kAdaugaTest]);

                            AdaugaEnuntButtonAdaugaTest.Location = new Point(45, lbAdaugaTest[kAdaugaTest].Location.Y + 45); // button1.Location.Y + enuntAdaugaTest[kAdaugaTest].Height+40);
                            AdaugaEnuntPictureAdaugaTest.Location = new Point(14, lbAdaugaTest[kAdaugaTest].Location.Y + 40);

                            AdaugaImagineButtonAdaugaTest.Location = new Point(201, AdaugaEnuntButtonAdaugaTest.Location.Y);
                            AdaugaImaginePictureAdaugaTest.Location = new Point(170, AdaugaEnuntButtonAdaugaTest.Location.Y - 5);

                            AdaugaProblemaButtonAdaugaTest.Location = new Point(350, AdaugaImagineButtonAdaugaTest.Location.Y);
                            AdaugaProblemaPictureAdaugaTest.Location = new Point(319, AdaugaImagineButtonAdaugaTest.Location.Y - 5);

                            SalveazaButtonAdaugaTest.Location = new Point(500, AdaugaImagineButtonAdaugaTest.Location.Y);
                            SalveazaPictureAdaugaTest.Location = new Point(469, AdaugaImagineButtonAdaugaTest.Location.Y - 5);

                            textBox2AdaugaTest.Hide();
                            label1AdaugaTest.Hide();
                            textBox1AdaugaTest.Hide();
                            label2AdaugaTest.Hide();
                            textBox3AdaugaTest.Hide();
                            label3AdaugaTest.Hide();
                            textBox4AdaugaTest.Hide();
                            label4AdaugaTest.Hide();
                            label5AdaugaTest.Hide();


                            int lala = kAdaugaTest - 1;
                            kglobalAdaugaTest = kAdaugaTest;
                        }
                        else
                        {
                            kAdaugaTest--;
                        }
                    }
                    else
                    {
                        kAdaugaTest--;
                        MessageBox.Show("Introduceți un raspuns");
                        raspunsAdaugaTest[kAdaugaTest].Focus();
                    }

                    if (kAdaugaTest == numarRTAdaugaTest && raspunsAdaugaTest[kAdaugaTest - 1].Text != "")
                    {
                        AdaugaEnuntButtonAdaugaTest.Enabled = false;

                        SalveazaButtonAdaugaTest.Enabled = true;
                        AdaugaProblemaButtonAdaugaTest.Enabled = true;

                        AdaugaEnuntPictureAdaugaTest.Image = global::Proiect.Properties.Resources.bullet_error;
                        AdaugaProblemaPictureAdaugaTest.Image = global::Proiect.Properties.Resources.file_download;
                        SalveazaPictureAdaugaTest.Image = global::Proiect.Properties.Resources.bullet_info;
                    }
                    else
                        if (kAdaugaTest == numarRTAdaugaTest && raspunsAdaugaTest[kAdaugaTest - 1].Text == "")
                        {
                            MessageBox.Show("Introduceți un raspuns");
                            raspunsAdaugaTest[kAdaugaTest].Focus();
                        }

                }
                else
                {
                    SalveazaButtonAdaugaTest.Enabled = true;
                    AdaugaImagineButtonAdaugaTest.Enabled = true;
                    SalveazaButtonAdaugaTest.Show();
                    AdaugaProblemaButtonAdaugaTest.Show();
                    AdaugaProblemaButtonAdaugaTest.Enabled = true;
                    SalveazaButtonAdaugaTest.Enabled = true;
                    AdaugaProblemaPictureAdaugaTest.Show();
                    AdaugaEnuntPictureAdaugaTest.Image = global::Proiect.Properties.Resources.bullet_error;
                    AdaugaProblemaPictureAdaugaTest.Image = global::Proiect.Properties.Resources.file_download;
                    SalveazaPictureAdaugaTest.Image = global::Proiect.Properties.Resources.bullet_info;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        bool apasatAdaugaTest = false;
        public void textBox1_KeyPressAdaugaTest(object sender, KeyPressEventArgs e)
        {

            nrAdaugaTest++;
            if (e.KeyChar == 13)
            {
                if (textBox1AdaugaTest.Text != "" && textBox2AdaugaTest.Text != "" && textBox3AdaugaTest.Text != "")
                {
                    if (apasatAdaugaTest == false)
                    {
                        bool tr = false;
                        string u = "qwertyuiopasfdghjklzxcvbnm";
                        for (int o = 0; o < textBox2AdaugaTest.Text.Length; o++)
                        {
                            for (int j = 0; j < 26; j++)
                            {
                                if (textBox2AdaugaTest.Text[o] == u[j])
                                {
                                    tr = true;
                                }
                            }
                        }

                        for (int o = 0; o < textBox3AdaugaTest.Text.Length; o++)
                        {
                            for (int j = 0; j < 26; j++)
                            {
                                if (textBox3AdaugaTest.Text[o] == u[j])
                                {
                                    tr = true;
                                }
                            }
                        }

                        if (tr == false)
                        {
                            bool lala = Directory.Exists(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + textBox1AdaugaTest.Text);
                            if (lala == false)
                            {
                                numarRTAdaugaTest = Convert.ToInt32(textBox2AdaugaTest.Text);
                                AdaugaEnuntButtonAdaugaTest.Enabled = true;
                                AdaugaImagineButtonAdaugaTest.Enabled = true;

                                AdaugaEnuntPictureAdaugaTest.Image = global::Proiect.Properties.Resources.file_edit;
                                AdaugaImaginePictureAdaugaTest.Image = global::Proiect.Properties.Resources.photo_add;


                                textBox1_TextChangedAdaugaTest(sender, e);
                                apasatAdaugaTest = true;
                            }
                            else
                            {
                                MessageBox.Show("Fișierul deja există! \nAlegeți alt nume pentru test.",
                                    "Fișier deja existent!");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Numărul de probleme si timpul necesar elevului trebuie scris numai cu numere!");
                        }
                    }
                    else
                    {
                        textBox1AdaugaTest.Focus();
                    }
                }
                else
                {
                    if (sender.Equals(textBox1AdaugaTest))
                    {
                        textBox2AdaugaTest.Focus();
                    }
                    else
                        if (sender.Equals(textBox2AdaugaTest))
                        {
                            textBox3AdaugaTest.Focus();
                        }
                        else
                            if (sender.Equals(textBox3AdaugaTest))
                            {
                                textBox1AdaugaTest.Focus();
                            }
                }
            }
        }

        public void button3_ClickAdaugaTest(object sender, EventArgs e)
        {
            if (raspunsAdaugaTest[kAdaugaTest].Text != "")
            {
                numarRTAdaugaTest++;
                AdaugaEnuntButtonAdaugaTest.Enabled = true;
                AdaugaImagineButtonAdaugaTest.Enabled = true;
                //button3.Hide();
                //AddProblema.Hide();
                AdaugaProblemaButtonAdaugaTest.Enabled = false;
                SalveazaButtonAdaugaTest.Enabled = false;
                //pictureBox4.Hide();
                AdaugaEnuntPictureAdaugaTest.Image = global::Proiect.Properties.Resources.file_edit;
                AdaugaProblemaPictureAdaugaTest.Image = global::Proiect.Properties.Resources.bullet_error;
                SalveazaPictureAdaugaTest.Image = global::Proiect.Properties.Resources.bullet_error;
            }
            else
            {
                MessageBox.Show("Introduceți un raspuns");
            }
        }

        public void textBox1_TextChangedAdaugaTest(object sender, EventArgs e)
        {
            AdaugaEnuntButtonAdaugaTest.Enabled = true;
            AdaugaImagineButtonAdaugaTest.Enabled = true;
            numarRTAdaugaTest = Convert.ToInt32(textBox2AdaugaTest.Text);
        }
        bool saveAdaugaTest = false;
        public void button2_ClickAdaugaTest(object sender, EventArgs e)
        {
            try
            {
                saveAdaugaTest = true;
                if (raspunsAdaugaTest[kAdaugaTest].Text != "")
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + textBox1AdaugaTest.Text);
                    
                    richTextBox2AdaugaTest.Text = textBox3AdaugaTest.Text + '\n';


                    for (int u = 1; u <= numarRTAdaugaTest; u++)
                    {
                        richTextBox2AdaugaTest.Text += enuntAdaugaTest[u].Height.ToString() + '\n';
                    }

                    richTextBox2AdaugaTest.SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + textBox1AdaugaTest.Text + "\\setari", RichTextBoxStreamType.RichText);

                    numarRTAdaugaTest = 0;
                    kAdaugaTest = 0;
                    int lala = kglobalAdaugaTest;
                    
                    
                    richTextBox3AdaugaTest.Text = textBox4AdaugaTest.Text;
                    richTextBox3AdaugaTest.SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + textBox1AdaugaTest.Text + "\\" + "detalii", RichTextBoxStreamType.PlainText);
                    
                    for (int i = 1; i <= kglobalAdaugaTest; i++)
                    {
                        enuntAdaugaTest[i].SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + textBox1AdaugaTest.Text + "\\" + "problema" + i, RichTextBoxStreamType.PlainText);
                        raspunsAdaugaTest[i].SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + textBox1AdaugaTest.Text + "\\" + "raspuns" + i, RichTextBoxStreamType.PlainText);//"lectia" + k, RichTextBoxStreamType.RichText);
                    }


                    if (kimgAdaugaTest != 0)
                    {
                        string hjk = "", poz = "";
                        Directory.CreateDirectory(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + textBox1AdaugaTest.Text + "\\Imagini\\");
                        pozitiiAdaugaTest = "";//kimgAdaugaTest.ToString() + "\n";
                        for (int i = 0; i < kimgAdaugaTest; i++)
                        {
                            poz = PointToClient(imagineAdaugaTest[i].Location).ToString();// +' ' + PointToScreen(new Point(richTextBox1.Location.Y)).ToString();
                            hjk = poz.Substring(poz.IndexOf('=') + 1, poz.IndexOf(',') - poz.IndexOf('=') - 1);
                            hjk += ' ' + poz.Substring(poz.LastIndexOf('=') + 1, poz.Length - poz.LastIndexOf('=') - 2);

                            //pozitiiAdaugaTest = pozitiiAdaugaTest + hjk + '.' + "\n";
                            pozitiiAdaugaTest += imagineAdaugaTest[i].Location.X + " " + positionsAdaugaTest[i] + "." + "\n";
                            File.Copy(folderimgAdaugaTest[i], Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + textBox1AdaugaTest.Text + "\\Imagini\\" + "imagine" + i + ".jpg", true);
                            richTextBox1AdaugaTest.Text = pozitiiAdaugaTest;
                        }

                        richTextBox1AdaugaTest.SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + textBox1AdaugaTest.Text + "\\Imagini\\" + "setari", RichTextBoxStreamType.RichText);
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show("Introduceți un raspuns");
                    raspunsAdaugaTest[kAdaugaTest].Focus();
                }
                //Salvez imaginile si pozitiiAdaugaTestle imaginilor in folderul imagini
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        public void ScrieLectie_Load(object sender, EventArgs e)
        {
            textBox1AdaugaTest.Focus();
            AdaugaEnuntPictureAdaugaTest.Image = global::Proiect.Properties.Resources.bullet_error;
            AdaugaImaginePictureAdaugaTest.Image = global::Proiect.Properties.Resources.bullet_error;
            SalveazaPictureAdaugaTest.Image = global::Proiect.Properties.Resources.bullet_error;
            AdaugaProblemaPictureAdaugaTest.Image = global::Proiect.Properties.Resources.bullet_error;
        }

        public void ScrieLectie_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        public void button4_ClickAdaugaTest(object sender, EventArgs e)
        {
            if (raspunsAdaugaTest[kAdaugaTest].Text != "")
            {
                PrintDialog print = new PrintDialog();
                print.AllowPrintToFile = true;
                print.ShowDialog();
            }
            else
            {
                MessageBox.Show("Introduceți un raspuns");
                raspunsAdaugaTest[kAdaugaTest].Focus();
            }
        }

        public void button5_ClickAdaugaTest(object sender, EventArgs e)
        {
            imagineAdaugaTest[kimgAdaugaTest] = new PictureBox();
            OpenFileDialog of = new OpenFileDialog();
            if (of.ShowDialog() != System.Windows.Forms.DialogResult.Cancel &&
                           of.FileName.Length > 0)
            {
                folderimgAdaugaTest[kimgAdaugaTest] = of.FileName;

                imagineAdaugaTest[kimgAdaugaTest].Load(of.FileName);
                imagineAdaugaTest[kimgAdaugaTest].SizeMode = PictureBoxSizeMode.AutoSize;
                imagineAdaugaTest[kimgAdaugaTest].Name = "imagine" + kimgAdaugaTest;
                imagineAdaugaTest[kimgAdaugaTest].Location = new Point(AdaugaImagineButtonAdaugaTest.Location.X + 50, AdaugaImagineButtonAdaugaTest.Location.Y);

                imagineAdaugaTest[kimgAdaugaTest].MouseUp += pictureBox1_MouseUpAdaugaTest;
                imagineAdaugaTest[kimgAdaugaTest].MouseMove += pictureBox1_MouseMoveAdaugaTest;
                imagineAdaugaTest[kimgAdaugaTest].MouseDown += pictureBox1_MouseDownAdaugaTest;

                this.Controls.Add(imagineAdaugaTest[kimgAdaugaTest]);
                imagineAdaugaTest[kimgAdaugaTest].BringToFront();
            }

            kimgAdaugaTest++;
        }

        public Point pozitia = new Point();
        public bool miscare = false;




        public void pictureBox1_MouseDownAdaugaTest(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            for (int i = 0; i < kimgAdaugaTest; i++)
            {
                if (sender.Equals(imagineAdaugaTest[i]))
                {
                    imagineAdaugaTest[i].BringToFront();
                    pozitia = e.Location;
                    miscare = true;
                    break;
                }
            }
        }

        public void pictureBox1_MouseUpAdaugaTest(object sender, MouseEventArgs e)
        {
            miscare = false;
            for (int i = 0; i < kimgAdaugaTest; i++)
            {
                if (sender.Equals(imagineAdaugaTest[i]))
                {
                    //MessageBox.Show(AutoScrollPosition.Y.ToString());
                    positionsAdaugaTest[i] = 0 - AutoScrollPosition.Y + imagineAdaugaTest[i].Location.Y;
                    break;
                }
            }
        }

        public void pictureBox1_MouseMoveAdaugaTest(object sender, MouseEventArgs e)
        {
            if (miscare == false || e.Button != MouseButtons.Left)// || k2 == -1)
            {
                return;
            }
            for (int i = 0; i < kimgAdaugaTest; i++)
            {
                if (sender.Equals(imagineAdaugaTest[i]))
                {
                    imagineAdaugaTest[i].Left += e.X - pozitia.X;
                    imagineAdaugaTest[i].Top += e.Y - pozitia.Y;
                }
            }
        }

        public void AdaugaTestChimie_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button6_ClickAdaugaTest(object sender, EventArgs e)
        {
            MessageBox.Show("Forma răspunsurilor va fi următoarea: răspuns1; răspuns2;....răspuns n #nota1##nota2#...#nota n# (răspunsurile fiind " +
                "despărțite prin ; iar notele fiind cuprinse între #");
        }

        private void textBox2_TextChangedAdaugaTest(object sender, EventArgs e)
        {

        }


    }

}
