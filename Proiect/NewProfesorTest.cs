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
    public partial class NewProfesorTest : Form
    {
        public RichTextBox[] enuntTestProfesor = new RichTextBox[40];
        public RichTextBox[] enuntSalvatTestProfesor = new RichTextBox[40];
        public RichTextBox[] raspunsCorectTestProfesor = new RichTextBox[40];
        public RichTextBox[] raspunsTestProfesor = new RichTextBox[40];
        public PictureBox[] imagineTestProfesor = new PictureBox[140];
        public RichTextBox[] imagineSalvatTestProfesor = new RichTextBox[140];
        public Label[] NrProblemaTestProfesor = new Label[40];
        public Label[] lbTestProfesor = new Label[40];
        public Button buton20TestProfesor = new Button();
        public Button buton30TestProfesor = new Button();

        string[] TextSalvatTestProfesor = new String[40];

        public string locatieTestProfesor;
        public int kglobalTestProfesor = 0;
        public int kTestProfesor = -1;
        public int numarRTTestProfesor;

        int[] inaltimiCasuteTestProfesor = new int[40];

        public bool clickTestProfesor = false;
        public int nrImaginiTestProfesor = 0;

        string numeleMateriei = "";

        public NewProfesorTest(string location, string Materie)
        {
            Deschidere.Default.aDeschisUnTest = false;
            Deschidere.Default.Save();

            InitializeComponent();
            numeleMateriei = Materie;


            locatieTestProfesor = location;
            this.Text = "Editare Testul " + locatieTestProfesor + " (" + numeleMateriei + ")";

            //if (location != "ChimieLala")
            {
                numarRTTestProfesor = Directory.GetFiles(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + location + "\\").Length / 2 - 1;
                buton30TestProfesor.Enabled = true;

                //inserez inaltimile casutelor in rich text box
                SetariTextTestProfesor.LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestProfesor + "\\setari", RichTextBoxStreamType.RichText);

                string[] elementeSetari = SetariTextTestProfesor.Text.Split('\n');

                //inserez in vector inaltimile casutelor
                for (int i = 1; i <= numarRTTestProfesor; i++)
                {
                    inaltimiCasuteTestProfesor[i - 1] += Convert.ToInt32(elementeSetari[i]);
                }
                SetariTextTestProfesor.SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestProfesor + "\\setari", RichTextBoxStreamType.RichText);
            
                if (Directory.Exists(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + location + "\\Imagini") == true)
                {
                    nrImaginiTestProfesor = Directory.GetFiles(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + location + "\\Imagini\\").Length - 1;
                }

                this.buton30TestProfesor.Click += new System.EventHandler(this.button2_ClickTestProfesor);

                SalveazaTestProfesor.Show();
                int s;

                for (kTestProfesor = 0; kTestProfesor < numarRTTestProfesor; kTestProfesor++)
                {
                    Point pos = new Point(0, 0);
                    enuntTestProfesor[kTestProfesor] = new RichTextBox();
                    raspunsCorectTestProfesor[kTestProfesor] = new RichTextBox();
                    raspunsTestProfesor[kTestProfesor] = new RichTextBox();
                    lbTestProfesor[kTestProfesor] = new Label();

                    buton20TestProfesor = new Button();

                    if (kTestProfesor == 0)
                    {
                        enuntTestProfesor[kTestProfesor].BackColor = System.Drawing.Color.White;
                        enuntTestProfesor[kTestProfesor].Name = "rt" + kTestProfesor;
                        enuntTestProfesor[kTestProfesor].ReadOnly = false;
                        enuntTestProfesor[kTestProfesor].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
                        enuntTestProfesor[kTestProfesor].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
                        enuntTestProfesor[kTestProfesor].Size = new System.Drawing.Size(704, 10);
                        enuntTestProfesor[kTestProfesor].TabIndex = kTestProfesor + 7;
                        this.enuntTestProfesor[kTestProfesor].BorderStyle = System.Windows.Forms.BorderStyle.None;

                        s = kTestProfesor + 1;

                        enuntTestProfesor[kTestProfesor].Text = System.IO.File.ReadAllText(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestProfesor + "\\problema" + s);
                        raspunsCorectTestProfesor[kTestProfesor].Text = System.IO.File.ReadAllText(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestProfesor + "\\raspuns" + s);
                        enuntTestProfesor[kTestProfesor].WordWrap = true;
                        enuntTestProfesor[kTestProfesor].Location = new Point(0, 30);

                        raspunsTestProfesor[kTestProfesor].BackColor = System.Drawing.Color.White;
                        raspunsTestProfesor[kTestProfesor].Name = "tb" + kTestProfesor;
                        raspunsTestProfesor[kTestProfesor].ReadOnly = false;
                        raspunsTestProfesor[kTestProfesor].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
                        raspunsTestProfesor[kTestProfesor].Size = new System.Drawing.Size(400, 26);
                        raspunsTestProfesor[kTestProfesor].TabIndex = kTestProfesor + 7;
                        raspunsTestProfesor[kTestProfesor].Text = System.IO.File.ReadAllText(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestProfesor + "\\raspuns" + s);
                        raspunsTestProfesor[kTestProfesor].WordWrap = true;


                        this.Controls.Add(enuntTestProfesor[kTestProfesor]);
                    }
                    else
                        if (kTestProfesor > 0)
                        {
                            enuntTestProfesor[kTestProfesor].BackColor = System.Drawing.Color.White;
                            enuntTestProfesor[kTestProfesor].SizeChanged += richTextBox3_SizeChangedTestProfesor;
                            enuntTestProfesor[kTestProfesor].ReadOnly = false;
                            enuntTestProfesor[kTestProfesor].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
                            enuntTestProfesor[kTestProfesor].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
                            enuntTestProfesor[kTestProfesor].Size = new System.Drawing.Size(704, 10);
                            enuntTestProfesor[kTestProfesor].BorderStyle = System.Windows.Forms.BorderStyle.None;

                            s = kTestProfesor + 1;

                            enuntTestProfesor[kTestProfesor].Text = System.IO.File.ReadAllText(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestProfesor + "\\problema" + s);
                            raspunsCorectTestProfesor[kTestProfesor].Text = System.IO.File.ReadAllText(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestProfesor + "\\raspuns" + s);
                            enuntTestProfesor[kTestProfesor].WordWrap = true;
                            enuntTestProfesor[kTestProfesor].Location = new Point(0, lbTestProfesor[kTestProfesor - 1].Location.Y + 85);// enuntTestProfesor[kTestProfesor - 1].Location.Y + enuntTestProfesor[kTestProfesor - 1].Height + 15);

                            raspunsTestProfesor[kTestProfesor].BackColor = System.Drawing.Color.White;
                            raspunsTestProfesor[kTestProfesor].ReadOnly = false;
                            raspunsTestProfesor[kTestProfesor].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
                            raspunsTestProfesor[kTestProfesor].Size = new System.Drawing.Size(400, 26);
                            raspunsTestProfesor[kTestProfesor].Text = System.IO.File.ReadAllText(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestProfesor + "\\raspuns" + s);
                            raspunsTestProfesor[kTestProfesor].WordWrap = true;

                            this.Controls.Add(enuntTestProfesor[kTestProfesor]);
                        }

                    //inaltimea richtextboxului
                    pos.X = ClientRectangle.Width;
                    pos.Y = ClientRectangle.Height;
                    int lastIndex = enuntTestProfesor[kTestProfesor].GetCharIndexFromPosition(pos);
                    int lastLine = enuntTestProfesor[kTestProfesor].GetLineFromCharIndex(lastIndex) + 1;
                    enuntTestProfesor[kTestProfesor].Height = inaltimiCasuteTestProfesor[kTestProfesor];

                    lbTestProfesor[kTestProfesor] = new Label();
                    lbTestProfesor[kTestProfesor].Text = "Răspuns: ";
                    lbTestProfesor[kTestProfesor].Name = "label" + kTestProfesor;
                    lbTestProfesor[kTestProfesor].BackColor = System.Drawing.Color.Transparent;
                    this.lbTestProfesor[kTestProfesor].Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    NrProblemaTestProfesor[kTestProfesor] = new Label();
                    int numar;
                    numar = kTestProfesor + 1;
                    NrProblemaTestProfesor[kTestProfesor].Text = "Problema " + numar;
                    NrProblemaTestProfesor[kTestProfesor].AutoSize = true;
                    NrProblemaTestProfesor[kTestProfesor].Name = "Nrproblema" + kTestProfesor;
                    NrProblemaTestProfesor[kTestProfesor].BackColor = System.Drawing.Color.Transparent;
                    this.NrProblemaTestProfesor[kTestProfesor].Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //pozitia label-ului "Raspuns"
                    if (kTestProfesor == 0)
                    {
                        lbTestProfesor[kTestProfesor].Location = new Point(0, enuntTestProfesor[kTestProfesor].Height + 40);
                        raspunsTestProfesor[kTestProfesor].Location = new Point(120, enuntTestProfesor[kTestProfesor].Height + 40);
                        //NrProblemaTestProfesor[kTestProfesor].Location = new Point(245, enuntTestProfesor[kTestProfesor].Location.Y - 30);


                        NrProblemaTestProfesor[kTestProfesor].Location = new Point(245, enuntTestProfesor[kTestProfesor].Location.Y - 30);
                        buton30TestProfesor.Location = new Point(0, enuntTestProfesor[kTestProfesor].Height + 70);
                        SalveazaTestProfesor.Location = new Point(95, enuntTestProfesor[kTestProfesor].Height + 70);
                        InfoSalveazaTestProfesorPicture.Location = new Point(64, enuntTestProfesor[kTestProfesor].Height + 70 - 5);
                        PlusTestProfesor.Location = new Point(242, enuntTestProfesor[kTestProfesor].Height + 70);
                        MinusTestProfesor.Location = new Point(277, enuntTestProfesor[kTestProfesor].Height + 70);
                        NumarulProblemeiMariteTestProfesor.Location = new Point(187, enuntTestProfesor[kTestProfesor].Height + 70);
                    }
                    else
                        if (kTestProfesor > 0)
                        {
                            lbTestProfesor[kTestProfesor].Location = new Point(0, lbTestProfesor[kTestProfesor - 1].Location.Y + enuntTestProfesor[kTestProfesor].Height + 100);// - 35);
                            raspunsTestProfesor[kTestProfesor].Location = new Point(120, lbTestProfesor[kTestProfesor - 1].Location.Y + enuntTestProfesor[kTestProfesor].Height + 100);
                            NrProblemaTestProfesor[kTestProfesor].Location = new Point(245, enuntTestProfesor[kTestProfesor].Location.Y - 30);
                            buton30TestProfesor.Location = new Point(130, lbTestProfesor[kTestProfesor - 1].Location.Y + enuntTestProfesor[kTestProfesor].Height + 130);



                            //NrProblemaTestProfesor[kTestProfesor].Location = new Point(245, enuntTestProfesor[kTestProfesor].Location.Y - 30);
                            //buton30TestProfesor.Location = new Point(0, enuntTestProfesor[kTestProfesor].Location.Y + enuntTestProfesor[kTestProfesor].Height);
                            SalveazaTestProfesor.Location = new Point(95, lbTestProfesor[kTestProfesor - 1].Location.Y + enuntTestProfesor[kTestProfesor].Height + 130);
                            InfoSalveazaTestProfesorPicture.Location = new Point(64, lbTestProfesor[kTestProfesor - 1].Location.Y + enuntTestProfesor[kTestProfesor].Height + 130 - 5);
                            PlusTestProfesor.Location = new Point(242, lbTestProfesor[kTestProfesor - 1].Location.Y + enuntTestProfesor[kTestProfesor].Height + 130);
                            MinusTestProfesor.Location = new Point(277, lbTestProfesor[kTestProfesor - 1].Location.Y + enuntTestProfesor[kTestProfesor].Height + 130);
                            NumarulProblemeiMariteTestProfesor.Location = new Point(187, lbTestProfesor[kTestProfesor - 1].Location.Y + enuntTestProfesor[kTestProfesor].Height + 130);
                        }
                    this.Controls.Add(lbTestProfesor[kTestProfesor]);
                    this.Controls.Add(raspunsTestProfesor[kTestProfesor]);
                    this.Controls.Add(NrProblemaTestProfesor[kTestProfesor]);

                    buton30TestProfesor.Text = "Vezi răspunsuri";
                    buton30TestProfesor.AutoSize = true;
                    this.buton30TestProfesor.TabIndex = 1;
                    this.buton30TestProfesor.UseVisualStyleBackColor = true;
                    this.buton30TestProfesor.Name = "buton30TestProfesor";
                    this.buton30TestProfesor.Size = new System.Drawing.Size(75, 23);
                    //buton30TestProfesor.Visible = true;
                    //this.Controls.Add(buton30TestProfesor);

                    kglobalTestProfesor++;
                    enuntTestProfesor[kTestProfesor].TextChanged += richTextBox1_TextChangedTestProfesor;
                }

                if (nrImaginiTestProfesor != 0)
                {
                    string qq = "";
                    richTextBox1TestProfesor.LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + location + "\\Imagini\\setari");
                    string[] linii = richTextBox1TestProfesor.Lines;
                    int q = 0, w = 0, e = 0, r = 0;//q-location.x w-location.y e-width r-height
                    for (kTestProfesor = 0; kTestProfesor < nrImaginiTestProfesor; kTestProfesor++)
                    {
                        q = Convert.ToInt32(linii[kTestProfesor].Substring(0, linii[kTestProfesor].LastIndexOf(' ')));
                        w = Convert.ToInt32(linii[kTestProfesor].Substring(linii[kTestProfesor].LastIndexOf(' ') + 1, linii[kTestProfesor].LastIndexOf('.') - linii[kTestProfesor].LastIndexOf(' ') - 1));
                        richTextBox2TestProfesor.SelectedText += q.ToString() + ' ' + w.ToString() + ' ' + e.ToString() + ' ' + r.ToString() + "\n";
                        imagineTestProfesor[kTestProfesor] = new PictureBox();
                        this.imagineTestProfesor[kTestProfesor].Location = new System.Drawing.Point(q, w);
                        this.imagineTestProfesor[kTestProfesor].Name = "pictureBo" + kTestProfesor.ToString();
                        Size tempSize = imagineTestProfesor[kTestProfesor].Size;
                        this.imagineTestProfesor[kTestProfesor].SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                        this.imagineTestProfesor[kTestProfesor].TabStop = false;
                        this.imagineTestProfesor[kTestProfesor].TabIndex = kTestProfesor;
                        this.imagineTestProfesor[kTestProfesor].Image = System.Drawing.Image.FromFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + location + "\\Imagini\\" + "imagine" + kTestProfesor.ToString() + ".jpg");//File.Open("D:\\Proiect\\Teste\\Chimie\\" + x + "\\Imagini\\" + kTestProfesor.ToString(), 


                        string sa = kTestProfesor.ToString();


                        this.imagineTestProfesor[kTestProfesor].MouseDown += delegate(object sender, MouseEventArgs t)
                        {
                            pictureBox1_MouseDownTestProfesor(sender, t, sa);
                        };
                        this.imagineTestProfesor[kTestProfesor].MouseUp += delegate(object sender, MouseEventArgs t)
                        {
                            pictureBox1_MouseUpTestProfesor(sender, t, sa);
                        };
                        this.imagineTestProfesor[kTestProfesor].MouseMove += delegate(object sender, MouseEventArgs t)
                        {
                            pictureBox1_MouseMoveTestProfesor(sender, t, sa);
                        };
                        Controls.Add(imagineTestProfesor[kTestProfesor]);
                        imagineTestProfesor[kTestProfesor].BringToFront();
                    }

                }

            }
        }


        private void button2_ClickTestProfesor(object sender, EventArgs e)
        {
            //ProfesorraspunsTestProfesorTestChimie rasp = new ProfesorraspunsTestProfesorTestChimie(locatieTestProfesor);
            //rasp.Show();
        }


        private void button1_ClickTestProfesor(object sender, EventArgs e)
        {
            SetariTextTestProfesor.LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestProfesor + "\\setari", RichTextBoxStreamType.RichText);

            string[] elementeSetari = SetariTextTestProfesor.Text.Split('\n');
            
            //asez pe prima linie timpul cronometrului
            SetariTextTestProfesor.Text = elementeSetari[0] + '\n';
            
            for (int i = 0; i < numarRTTestProfesor; i++)
            {
                SetariTextTestProfesor.Text += enuntTestProfesor[i].Height.ToString() + '\n';
            }
            SetariTextTestProfesor.SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestProfesor + "\\setari", RichTextBoxStreamType.RichText);
            


            clickTestProfesor = true;
            int s;
            if (nrImaginiTestProfesor != 0)
            {
                string lala = "";
                for (int j = 0; j < nrImaginiTestProfesor; j++)
                {
                    imagineSalvatTestProfesor[j] = new RichTextBox();
                    imagineSalvatTestProfesor[j].BackColor = System.Drawing.Color.White;
                    imagineSalvatTestProfesor[j].Name = "rtt" + j;
                    imagineSalvatTestProfesor[j].SizeChanged += richTextBox3_SizeChangedTestProfesor;
                    imagineSalvatTestProfesor[j].ReadOnly = false;
                    imagineSalvatTestProfesor[j].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
                    imagineSalvatTestProfesor[j].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
                    imagineSalvatTestProfesor[j].Size = new System.Drawing.Size(704, 10);
                    imagineSalvatTestProfesor[j].TabIndex = j + 7;
                    this.imagineSalvatTestProfesor[j].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    imagineSalvatTestProfesor[j].Text = imagineTestProfesor[j].Location.X.ToString() + ' ' + imagineTestProfesor[j].Location.Y.ToString() + '.' + '\n';
                    Controls.Add(imagineSalvatTestProfesor[j]);
                    s = j + 1;
                    lala += imagineSalvatTestProfesor[j].Text;
                }
                imagineSalvatTestProfesor[0].Text = lala;
                imagineSalvatTestProfesor[0].SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestProfesor + "\\Imagini\\setari", RichTextBoxStreamType.RichText);
            }
            for (kTestProfesor = 0; kTestProfesor < numarRTTestProfesor; kTestProfesor++)
            {
                enuntSalvatTestProfesor[kTestProfesor] = new RichTextBox();
                enuntSalvatTestProfesor[kTestProfesor].BackColor = System.Drawing.Color.White;
                enuntSalvatTestProfesor[kTestProfesor].Name = "rt" + kTestProfesor;
                enuntSalvatTestProfesor[kTestProfesor].SizeChanged += richTextBox3_SizeChangedTestProfesor;
                enuntSalvatTestProfesor[kTestProfesor].ReadOnly = false;
                enuntSalvatTestProfesor[kTestProfesor].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
                enuntSalvatTestProfesor[kTestProfesor].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
                enuntSalvatTestProfesor[kTestProfesor].Size = new System.Drawing.Size(704, 10);
                enuntSalvatTestProfesor[kTestProfesor].TabIndex = kTestProfesor + 7;
                this.enuntSalvatTestProfesor[kTestProfesor].BorderStyle = System.Windows.Forms.BorderStyle.None;
                enuntSalvatTestProfesor[kTestProfesor].Text = enuntTestProfesor[kTestProfesor].Text;
                Controls.Add(enuntSalvatTestProfesor[kTestProfesor]);
                s = kTestProfesor + 1;

                enuntSalvatTestProfesor[kTestProfesor].SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestProfesor + "\\" + "problema" + s, RichTextBoxStreamType.PlainText);//"lectia" + kTestProfesor, RichTextBoxStreamType.RichText);
            }
            for (int i = 0; i < numarRTTestProfesor; i++)
            {
                int f = i + 1;
                raspunsTestProfesor[i].SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestProfesor + "\\raspuns" + f, RichTextBoxStreamType.PlainText);
            }
            Close();
        }
        private void richTextBox1_TextChangedTestProfesor(object sender, EventArgs e)//, int i)
        {
            int i = 0;
            for (i = 0; i < numarRTTestProfesor; i++)
            {
                TextSalvatTestProfesor[i] = enuntTestProfesor[i].Text;
            }
        }
        

        private Point pozitia = new Point();
        private bool miscare = false;




        private void pictureBox1_MouseDownTestProfesor(object sender, MouseEventArgs e, string sad)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            int uw = Convert.ToInt32(sad);
            imagineTestProfesor[uw].BringToFront();
            pozitia = e.Location;
            miscare = true;
        }

        private void pictureBox1_MouseUpTestProfesor(object sender, MouseEventArgs e, string sad)
        {
            int uw = Convert.ToInt32(sad);
            imagineTestProfesor[uw].BringToFront();
            miscare = false;
        }

        private void pictureBox1_MouseMoveTestProfesor(object sender, MouseEventArgs e, string sad)
        {
            if (!miscare || e.Button != MouseButtons.Left)// || kTestProfesor2 == -1)
            {
                return;
            }
            int kimg = Convert.ToInt32(sad);
            imagineTestProfesor[kimg] = (PictureBox)sender;
            imagineTestProfesor[kimg].Left += e.X - pozitia.X;
            imagineTestProfesor[kimg].Top += e.Y - pozitia.Y;
        }

        private void richTextBox3_SizeChangedTestProfesor(object sender, EventArgs e)
        {
            int x = buton30TestProfesor.Location.Y;
            buton30TestProfesor.Location = new Point(0, x + 10);
        }

        private void button2_Click_1TestProfesor(object sender, EventArgs e)
        {
            if (NumarulProblemeiMariteTestProfesor.Text != "")
            {
                int x = Convert.ToInt32(NumarulProblemeiMariteTestProfesor.Text);
                if (x > 0 && x <= numarRTTestProfesor)
                {
                    PlusTestProfesor.Location = new Point(242, SalveazaTestProfesor.Location.Y + 10);
                    MinusTestProfesor.Location = new Point(277, SalveazaTestProfesor.Location.Y + 10);
                    NumarulProblemeiMariteTestProfesor.Location = new Point(187, SalveazaTestProfesor.Location.Y + 10);
                    buton30TestProfesor.Location = new Point(0, SalveazaTestProfesor.Location.Y + 10);
                    SalveazaTestProfesor.Location = new Point(95, SalveazaTestProfesor.Location.Y + 10);
                    InfoSalveazaTestProfesorPicture.Location = new Point(64, SalveazaTestProfesor.Location.Y - 3);
                    enuntTestProfesor[x - 1].Height += 10;

                    lbTestProfesor[x - 1].Location = new Point(0, lbTestProfesor[x - 1].Location.Y + 10);
                    raspunsTestProfesor[x - 1].Location = new Point(120, raspunsTestProfesor[x - 1].Location.Y + 10);
                    //label1.Location = new Point(label1.Location.X, label1.Location.Y + 10);

                    if (x - 1 < numarRTTestProfesor)
                    {
                        for (int j = x; j < numarRTTestProfesor; j++)
                        {
                            lbTestProfesor[j].Location = new Point(0, lbTestProfesor[j].Location.Y + 10);
                            raspunsTestProfesor[j].Location = new Point(120, raspunsTestProfesor[j].Location.Y + 10);

                            NrProblemaTestProfesor[j].Location = new Point(245, NrProblemaTestProfesor[j].Location.Y + 10);
                            enuntTestProfesor[j].Location = new Point(0, enuntTestProfesor[j].Location.Y + 10);
                        }
                    }
                }
            }
            else
                MessageBox.Show("Introduceti numarul problemei!");
        }

        private void button4_ClickTestProfesor(object sender, EventArgs e)
        {
            if (NumarulProblemeiMariteTestProfesor.Text != "")
            {

                int x = Convert.ToInt32(NumarulProblemeiMariteTestProfesor.Text);
                if (x > 0 && x <= numarRTTestProfesor)
                {
                    PlusTestProfesor.Location = new Point(242, SalveazaTestProfesor.Location.Y - 10);
                    MinusTestProfesor.Location = new Point(277, SalveazaTestProfesor.Location.Y - 10);
                    NumarulProblemeiMariteTestProfesor.Location = new Point(187, SalveazaTestProfesor.Location.Y - 10);
                    buton30TestProfesor.Location = new Point(0, SalveazaTestProfesor.Location.Y - 10);
                    SalveazaTestProfesor.Location = new Point(95, SalveazaTestProfesor.Location.Y - 10);
                    InfoSalveazaTestProfesorPicture.Location = new Point(64, SalveazaTestProfesor.Location.Y - 10 + 5);
                    enuntTestProfesor[x - 1].Height -= 10;

                    lbTestProfesor[x - 1].Location = new Point(0, lbTestProfesor[x - 1].Location.Y - 10);
                    raspunsTestProfesor[x - 1].Location = new Point(120, raspunsTestProfesor[x - 1].Location.Y - 10);
                    //label1.Location = new Point(label1.Location.X, label1.Location.Y - 10);

                    if (x - 1 < numarRTTestProfesor)
                    {
                        for (int j = x; j < numarRTTestProfesor; j++)
                        {
                            lbTestProfesor[j].Location = new Point(0, lbTestProfesor[j].Location.Y - 10);
                            raspunsTestProfesor[j].Location = new Point(120, raspunsTestProfesor[j].Location.Y - 10);

                            NrProblemaTestProfesor[j].Location = new Point(245, NrProblemaTestProfesor[j].Location.Y - 10);
                            enuntTestProfesor[j].Location = new Point(0, enuntTestProfesor[j].Location.Y - 10);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Introduceti numarul problemei!");
            }
        }

        private void NewProfesorTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            Deschidere.Default.aDeschisUnTest = false;
            Deschidere.Default.Save();
        }


    }
}
