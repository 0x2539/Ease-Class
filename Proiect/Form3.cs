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
using Proiect.Aplicatii.Informatica.Evaluator;

namespace Proiect.Nivele_utilizatori
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button4.Click += new System.EventHandler(this.button4_Click);

            //AdaugaTestChimie
            textBox2.Focus();

            Point pos = new Point(0, 0);
            // creez RichTextBox1
            of[0] = new OpenFileDialog();
            of[0].FileName = "of" + 0;
            of[0].DefaultExt = "*.txt";
            of[0].Filter = "Text Files|*.txt|RTF Files|*.rtf";

            raspuns[0] = new RichTextBox();
            raspuns[0].Text = "asdasd";
            raspuns[0].ReadOnly = false;

            /*imagine[0] = new PictureBox();
            imagine[0].Name = "imagine0";
            imagine[0].Size = new System.Drawing.Size(100, 50);
            */
            enunt[0] = new RichTextBox();
            enunt[0].BackColor = System.Drawing.SystemColors.Control;
            enunt[0].Location = new System.Drawing.Point(0, -30);// -110);
            enunt[0].Name = "rt" + 0;
            enunt[0].ReadOnly = false;
            enunt[0].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            enunt[0].Size = new System.Drawing.Size(500, 10);//(464, 10);
            enunt[0].TabIndex = 7;
            enunt[0].Text = "";
            enunt[0].WordWrap = true;
            this.Controls.Add(enunt[0]);
            this.Controls.Add(imagine[0]);
            //Inaltime RichTextBox1
            if (of[0].FileName.Substring(of[0].FileName.LastIndexOf('.') + 1, of[0].FileName.Length - 1 - of[0].FileName.LastIndexOf('.')) == "txt")// ||
                //of[0].FileName.Substring(of[0].FileName.LastIndexOf('.') + 1, of[0].FileName.Length - 1 - of[0].FileName.LastIndexOf('.')) == "docx") 
                enunt[0].LoadFile(of[0].FileName, RichTextBoxStreamType.PlainText);
            else
                if (of[0].FileName.Substring(of[0].FileName.LastIndexOf('.') + 1, of[0].FileName.Length - 1 - of[0].FileName.LastIndexOf('.')) == "rtf")
                    enunt[0].LoadFile(of[0].FileName, RichTextBoxStreamType.RichText);

            pos.X = 0;// ClientRectangle.Width;
            pos.Y = 0;// ClientRectangle.Height;
            int lastIndex = enunt[0].GetCharIndexFromPosition(pos);
            int lastLine = enunt[0].GetLineFromCharIndex(lastIndex) + 1;
            enunt[0].Height = lastLine * 14;

            //button5.Location = new Point(110, button1.Location.Y + enunt[0].Height);
            //button1.Location = new Point(0, button1.Location.Y + enunt[0].Height);



            //VeziTesteChimie




        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (bd.selectConectatElev() == 1)
            {
                Form2 form2 = new Form2("Elev", textBox1.Text);

                button1.Show();
                button2.Show();
                button3.Show();
                button4.Show();
                linkLabel1.Show();
                linkLabel2.Show();
                linkLabel3.Show();
                textBox1.Hide();
                textBox3.Hide();

                //this.button1.Click -= new System.EventHandler(this.button1_Click_Login);
                this.button1.Click += new System.EventHandler(this.button1_Click);
                button1.Location = form2.button1.Location;
                button1.Image = form2.button1.Image;
                button1.BackgroundImage = form2.button1.BackgroundImage;
                button1.Size = form2.button1.Size;
                button1.Text = form2.button1.Text;

                //this.button2.Click -= new System.EventHandler(this.button2_Click_Login);
                this.button2.Click += new System.EventHandler(this.button2_Click);
                button2.Location = form2.button2.Location;
                button2.Image = form2.button2.Image;
                button2.BackgroundImage = form2.button2.BackgroundImage;
                button2.Size = form2.button2.Size;
                button2.Text = form2.button2.Text;

                button3.Location = form2.button3.Location;
                button3.Image = form2.button3.Image;
                button3.BackgroundImage = form2.button3.BackgroundImage;
                button3.Size = form2.button3.Size;
                button3.Text = form2.button3.Text;

                button4.Location = form2.button4.Location;
                button4.Image = form2.button4.Image;
                button4.BackgroundImage = form2.button4.BackgroundImage;
                button4.Size = form2.button4.Size;
                button4.Text = form2.button4.Text;

                linkLabel1.LinkClicked += linkLabel1_LinkClicked;
                //linkLabel1.Location = form2.linkLabel1.Location;
                linkLabel1.Image = form2.linkLabel1.Image;
                linkLabel1.BackgroundImage = form2.linkLabel1.BackgroundImage;
                linkLabel1.Size = form2.linkLabel1.Size;
                linkLabel1.Text = "Elev";

                linkLabel2.LinkClicked += linkLabel2_LinkClicked;
                //linkLabel2.Location = form2.linkLabel2.Location;
                linkLabel2.Image = form2.linkLabel2.Image;
                linkLabel2.BackgroundImage = form2.linkLabel2.BackgroundImage;
                linkLabel2.Size = form2.linkLabel2.Size;
                linkLabel2.Text = bd.selectConectatNume().Substring(0, bd.selectConectatNume().Length - 7);

                linkLabel3.LinkClicked += linkLabel3_LinkClicked;
                //linkLabel3.Location = form2.linkLabel3.Location;
                linkLabel3.Image = form2.linkLabel3.Image;
                linkLabel3.BackgroundImage = form2.linkLabel3.BackgroundImage;
                linkLabel3.Size = form2.linkLabel3.Size;
                linkLabel3.Text = "Log out";

                logat = 2;
            }
            else
                if (bd.selectConectatProf() == 1)
                {
                    Form2 form2 = new Form2("Profesor", textBox1.Text);

                    button1.Show();
                    button2.Show();
                    button3.Show();
                    button4.Show();
                    linkLabel1.Show();
                    linkLabel2.Show();
                    linkLabel3.Show();
                    textBox1.Hide();
                    textBox3.Hide();

                    //this.button1.Click -= new System.EventHandler(this.button1_Click_Login);
                    this.button1.Click += new System.EventHandler(this.button1_Click);
                    button1.Location = form2.button1.Location;
                    button1.Image = form2.button1.Image;
                    button1.BackgroundImage = form2.button1.BackgroundImage;
                    button1.Size = form2.button1.Size;
                    button1.Text = form2.button1.Text;

                    //this.button2.Click -= new System.EventHandler(this.button2_Click_Login);
                    this.button2.Click += new System.EventHandler(this.button2_Click);
                    button2.Location = form2.button2.Location;
                    button2.Image = form2.button2.Image;
                    button2.BackgroundImage = form2.button2.BackgroundImage;
                    button2.Size = form2.button2.Size;
                    button2.Text = form2.button2.Text;

                    button3.Location = form2.button3.Location;
                    button3.Image = form2.button3.Image;
                    button3.BackgroundImage = form2.button3.BackgroundImage;
                    button3.Size = form2.button3.Size;
                    button3.Text = form2.button3.Text;

                    button4.Location = form2.button4.Location;
                    button4.Image = form2.button4.Image;
                    button4.BackgroundImage = form2.button4.BackgroundImage;
                    button4.Size = form2.button4.Size;
                    button4.Text = form2.button4.Text;

                    linkLabel1.LinkClicked += linkLabel1_LinkClicked;
                    //linkLabel1.Location = form2.linkLabel1.Location;
                    linkLabel1.Image = form2.linkLabel1.Image;
                    linkLabel1.BackgroundImage = form2.linkLabel1.BackgroundImage;
                    linkLabel1.Size = form2.linkLabel1.Size;
                    linkLabel1.Text = "Profesor";

                    linkLabel2.LinkClicked += linkLabel2_LinkClicked;
                    //linkLabel2.Location = form2.linkLabel2.Location;
                    linkLabel2.Image = form2.linkLabel2.Image;
                    linkLabel2.BackgroundImage = form2.linkLabel2.BackgroundImage;
                    linkLabel2.Size = form2.linkLabel2.Size;
                    linkLabel2.Text = bd.selectConectatNume().Substring(0, bd.selectConectatNume().Length - 7);
                    
                    linkLabel3.LinkClicked += linkLabel3_LinkClicked;
                    //linkLabel3.Location = form2.linkLabel3.Location;
                    linkLabel3.Image = form2.linkLabel3.Image;
                    linkLabel3.BackgroundImage = form2.linkLabel3.BackgroundImage;
                    linkLabel3.Size = form2.linkLabel3.Size;
                    linkLabel3.Text = "Log out";

                    logat = 2;
                }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LogIn logIn = new LogIn(this);
            button3.Hide();
            button4.Hide();
            label1.Hide();
            linkLabel2.Hide();
            textBox1.Show();
            textBox3.Show();

            textBox1.Focus();

            this.button1.Click -= new System.EventHandler(this.button1_Click);
            this.button1.Click += new System.EventHandler(this.button1_Click_Login);
            button1.Location = logIn.button1.Location;
            button1.Image = logIn.button1.Image;
            button1.BackgroundImage = logIn.button1.BackgroundImage;
            button1.Size = logIn.button1.Size;
            button1.Text = logIn.button1.Text;

            this.button2.Click -= new System.EventHandler(this.button2_Click);
            this.button2.Click += new System.EventHandler(this.button2_Click_Login);
            button2.Location = logIn.button2.Location;
            button2.Image = logIn.button2.Image;
            button2.BackgroundImage = logIn.button2.BackgroundImage;
            button2.Size = logIn.button2.Size;
            button2.Text = logIn.button2.Text;

            linkLabel1.Location = logIn.linkLabel1.Location;
            linkLabel1.Image = logIn.linkLabel1.Image;
            linkLabel1.BackgroundImage = logIn.linkLabel1.BackgroundImage;
            linkLabel1.Size = logIn.linkLabel1.Size;
            linkLabel1.Text = logIn.linkLabel1.Text;

            textBox1.Location = logIn.textBox1.Location;
            textBox1.BackgroundImage = logIn.textBox1.BackgroundImage;
            textBox1.Size = logIn.textBox1.Size;
            textBox1.Text = logIn.textBox1.Text;

            textBox3.Location = logIn.textBox2.Location;
            textBox3.BackgroundImage = logIn.textBox2.BackgroundImage;
            textBox3.Size = logIn.textBox2.Size;
            textBox3.Text = logIn.textBox2.Text;
            textBox3.PasswordChar = '*';
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (linkLabel1.Text == "Elev")
            {
                ElevMatematica elev = new ElevMatematica(linkLabel2.Text);
                //elev.Show();
            }
            else
                if (linkLabel1.Text == "Profesor")
                {
                    ProfesorMatematica prof = new ProfesorMatematica();
                    //prof.Show();
                }
                else
                {
                    VizitatorMatematica mate = new VizitatorMatematica();
                    mate.Show();
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (linkLabel1.Text == "Elev")
            {
                ElevFizica elev = new ElevFizica(linkLabel2.Text);
                elev.Show();
            }
            else
                if (linkLabel1.Text == "Profesor")
                {
                    ProfesorFizica prof = new ProfesorFizica();
                    prof.Show();
                }
                else
                {
                    VizitatorFizica Fizica = new VizitatorFizica();
                    Fizica.Show();
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (linkLabel1.Text == "Elev")
            {
                ElevChimie elev = new ElevChimie(linkLabel2.Text);
                elev.Show();
            }
            else
                if (linkLabel1.Text == "Profesor")
                {
                    ProfesorChimie prof = new ProfesorChimie();
                    //prof.Show();

                    linkLabel2.Hide();
                    linkLabel3.Hide();

                    this.button1.Click -= new System.EventHandler(this.button1_Click);
                    this.button1.Click += new System.EventHandler(this.button1_Click_ProfesorChimie);
                    button1.Location = prof.button1.Location;
                    button1.Image = prof.button1.Image;
                    button1.BackgroundImage = prof.button1.BackgroundImage;
                    button1.Size = prof.button1.Size;
                    button1.Text = prof.button1.Text;

                    this.button2.Click -= new System.EventHandler(this.button2_Click);
                    this.button2.Click += new System.EventHandler(this.button2_Click_ProfesorChimie);
                    button2.Location = prof.button2.Location;
                    button2.Image = prof.button2.Image;
                    button2.BackgroundImage = prof.button2.BackgroundImage;
                    button2.Size = prof.button2.Size;
                    button2.Text = prof.button2.Text;

                    this.button3.Click -= new System.EventHandler(this.button3_Click);
                    this.button3.Click += new System.EventHandler(this.button3_Click_ProfesorChimie);
                    button3.Location = prof.button3.Location;
                    button3.Image = prof.button3.Image;
                    button3.BackgroundImage = prof.button3.BackgroundImage;
                    button3.Size = prof.button3.Size;
                    button3.Text = prof.button3.Text;

                    this.button4.Click -= new System.EventHandler(this.button4_Click);
                    this.button4.Click += new System.EventHandler(this.button4_Click_ProfesorChimie);
                    button4.Location = prof.button4.Location;
                    button4.Image = prof.button4.Image;
                    button4.BackgroundImage = prof.button4.BackgroundImage;
                    button4.Size = prof.button4.Size;
                    button4.Text = prof.button4.Text;
                }
                else
                {
                    VizitatorChimie Chimie = new VizitatorChimie();
                    Chimie.Show();
                }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (linkLabel1.Text == "Elev")
            {
                ElevInformatica elev = new ElevInformatica(linkLabel2.Text);
                elev.Show();
            }
            else
                if (linkLabel1.Text == "Profesor")
                {
                    ProfesorInformatica prof = new ProfesorInformatica();
                    prof.Show();
                }
                else
                {
                    VizitatorInformatica Informatica = new VizitatorInformatica();
                    Informatica.Show();
                }
        }

        private Point pointMouse = new Point();
        private PictureBox ctrlMoved = new PictureBox();
        private bool bMoving = false;

        private void pictureBox1_Resize(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.Text = "Log in";
            linkLabel2.Text = "Register";
            bd.insereazaConectat("Nu");
            linkLabel3.Hide();
            linkLabel4.Hide();
        }
        



        //Formul Login

        
        public int logat = 0;
        BazaDate bd = new BazaDate();
        private Form1 mainForm = null;
        /*
        public LogIn(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }*/
        
        public int sw = -1;

        public void button1_Click_Login(object sender, EventArgs e)
        {
            if (bd.select(textBox1.Text, textBox3.Text) == 2)
            {
                Form2 form2 = new Form2("Elev", textBox1.Text);

                button1.Show();
                button2.Show();
                button3.Show();
                button4.Show();
                linkLabel1.Show();
                linkLabel2.Show();
                linkLabel3.Show();
                linkLabel4.Show();
                textBox1.Hide();
                textBox3.Hide();

                this.button1.Click -= new System.EventHandler(this.button1_Click_Login);
                this.button1.Click += new System.EventHandler(this.button1_Click);
                button1.Location = form2.button1.Location;
                button1.Image = form2.button1.Image;
                button1.BackgroundImage = form2.button1.BackgroundImage;
                button1.Size = form2.button1.Size;
                button1.Text = form2.button1.Text;

                this.button2.Click -= new System.EventHandler(this.button2_Click_Login);
                this.button2.Click += new System.EventHandler(this.button2_Click);
                button2.Location = form2.button2.Location;
                button2.Image = form2.button2.Image;
                button2.BackgroundImage = form2.button2.BackgroundImage;
                button2.Size = form2.button2.Size;
                button2.Text = form2.button2.Text;

                button3.Location = form2.button3.Location;
                button3.Image = form2.button3.Image;
                button3.BackgroundImage = form2.button3.BackgroundImage;
                button3.Size = form2.button3.Size;
                button3.Text = form2.button3.Text;

                button4.Location = form2.button4.Location;
                button4.Image = form2.button4.Image;
                button4.BackgroundImage = form2.button4.BackgroundImage;
                button4.Size = form2.button4.Size;
                button4.Text = form2.button4.Text;

                linkLabel1.LinkClicked += linkLabel1_LinkClicked;
                linkLabel1.Location = new Point(454, 9);//form2.linkLabel1.Location;
                linkLabel1.Image = form2.linkLabel1.Image;
                linkLabel1.BackgroundImage = form2.linkLabel1.BackgroundImage;
                linkLabel1.Size = form2.linkLabel1.Size;
                linkLabel1.Text = "Elev";

                linkLabel2.LinkClicked += linkLabel2_LinkClicked;
                linkLabel2.Location = new Point(496, 9);//form2.linkLabel2.Location;
                linkLabel2.Image = form2.linkLabel2.Image;
                linkLabel2.BackgroundImage = form2.linkLabel2.BackgroundImage;
                linkLabel2.Size = form2.linkLabel2.Size;
                linkLabel2.Text = textBox1.Text; ;

                linkLabel3.LinkClicked += linkLabel3_LinkClicked;
                linkLabel3.Location = new Point(405, 9); //form2.linkLabel3.Location;
                linkLabel3.Image = form2.linkLabel3.Image;
                linkLabel3.BackgroundImage = form2.linkLabel3.BackgroundImage;
                linkLabel3.Size = form2.linkLabel3.Size;
                linkLabel3.Text = "Log out";

                logat = 2;
            }
            else
                if (bd.select(textBox1.Text, textBox3.Text) == 1)
                {
                    Form2 form2 = new Form2("Profesor", textBox1.Text);

                    button1.Show();
                    button2.Show();
                    button3.Show();
                    button4.Show();
                    linkLabel1.Show();
                    linkLabel2.Show();
                    linkLabel3.Show();
                    linkLabel4.Show();
                    textBox1.Hide();
                    textBox3.Hide();

                    this.button1.Click -= new System.EventHandler(this.button1_Click_Login);
                    this.button1.Click += new System.EventHandler(this.button1_Click); 
                    button1.Location = form2.button1.Location;
                    button1.Image = form2.button1.Image;
                    button1.BackgroundImage = form2.button1.BackgroundImage;
                    button1.Size = form2.button1.Size;
                    button1.Text = form2.button1.Text;

                    this.button2.Click -= new System.EventHandler(this.button2_Click_Login);
                    this.button2.Click += new System.EventHandler(this.button2_Click);
                    button2.Location = form2.button2.Location;
                    button2.Image = form2.button2.Image;
                    button2.BackgroundImage = form2.button2.BackgroundImage;
                    button2.Size = form2.button2.Size;
                    button2.Text = form2.button2.Text;

                    button3.Location = form2.button3.Location;
                    button3.Image = form2.button3.Image;
                    button3.BackgroundImage = form2.button3.BackgroundImage;
                    button3.Size = form2.button3.Size;
                    button3.Text = form2.button3.Text;

                    button4.Location = form2.button4.Location;
                    button4.Image = form2.button4.Image;
                    button4.BackgroundImage = form2.button4.BackgroundImage;
                    button4.Size = form2.button4.Size;
                    button4.Text = form2.button4.Text;

                    linkLabel1.LinkClicked += linkLabel1_LinkClicked;
                    linkLabel1.Location = new Point(454, 9); //form2.linkLabel1.Location;
                    linkLabel1.Image = form2.linkLabel1.Image;
                    linkLabel1.BackgroundImage = form2.linkLabel1.BackgroundImage;
                    linkLabel1.Size = form2.linkLabel1.Size;
                    linkLabel1.Text = "Profesor";

                    linkLabel2.LinkClicked += linkLabel2_LinkClicked;
                    linkLabel2.Location = new Point(496, 9); //form2.linkLabel2.Location;
                    linkLabel2.Image = form2.linkLabel2.Image;
                    linkLabel2.BackgroundImage = form2.linkLabel2.BackgroundImage;
                    linkLabel2.Size = form2.linkLabel2.Size;
                    linkLabel2.Text = textBox1.Text; ;

                    linkLabel3.LinkClicked += linkLabel3_LinkClicked;
                    linkLabel3.Location = new Point(405, 9);// form2.linkLabel3.Location;
                    linkLabel3.Image = form2.linkLabel3.Image;
                    linkLabel3.BackgroundImage = form2.linkLabel3.BackgroundImage;
                    linkLabel3.Size = form2.linkLabel3.Size;
                    linkLabel3.Text = "Log out";

                    logat = 2;
                }
                else
                    if (bd.select(textBox1.Text, textBox3.Text) == 0)
                    {
                        MessageBox.Show("Nume utilizator sau parola gresita");
                        textBox1.Clear();
                        textBox3.Clear();
                    }
        }

        public void button2_Click_Login(object sender, EventArgs e)
        {
            textBox1.Hide();
            textBox3.Hide();

            Form2 form2 = new Form2("llls", "lkalla");

            button1.Show();
            button2.Show();
            button3.Show();
            button4.Show();
            linkLabel1.Show();
            linkLabel2.Show();
            textBox1.Hide();
            textBox3.Hide();

            button1.Click += button1_Click;
            button1.Location = form2.button1.Location;
            button1.Image = form2.button1.Image;
            button1.BackgroundImage = form2.button1.BackgroundImage;
            button1.Size = form2.button1.Size;
            button1.Text = form2.button1.Text;

            button2.Click += button2_Click;
            button2.Location = form2.button2.Location;
            button2.Image = form2.button2.Image;
            button2.BackgroundImage = form2.button2.BackgroundImage;
            button2.Size = form2.button2.Size;
            button2.Text = form2.button2.Text;

            button3.Click += button3_Click;
            button3.Location = form2.button3.Location;
            button3.Image = form2.button3.Image;
            button3.BackgroundImage = form2.button3.BackgroundImage;
            button3.Size = form2.button3.Size;
            button3.Text = form2.button3.Text;

            button4.Click += button4_Click;
            button4.Location = form2.button4.Location;
            button4.Image = form2.button4.Image;
            button4.BackgroundImage = form2.button4.BackgroundImage;
            button4.Size = form2.button4.Size;
            button4.Text = form2.button4.Text;

            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            linkLabel1.Location = form2.linkLabel1.Location;
            linkLabel1.Image = form2.linkLabel1.Image;
            linkLabel1.BackgroundImage = form2.linkLabel1.BackgroundImage;
            linkLabel1.Size = form2.linkLabel1.Size;
            linkLabel1.Text = "Log in";

            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            linkLabel2.Location = form2.linkLabel2.Location;
            linkLabel2.Image = form2.linkLabel2.Image;
            linkLabel2.BackgroundImage = form2.linkLabel2.BackgroundImage;
            linkLabel2.Size = form2.linkLabel2.Size;
            linkLabel2.Text = "Register";
        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
        
        public void LogIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            //formla1.Show();
        }




        //Formul ProfesorChimie



        /*public ProfesorChimie()
        {
            InitializeComponent();
        }*/

        private void button4_Click_ProfesorChimie(object sender, EventArgs e)
        {
            AdaugaLectieChimie chimie = new AdaugaLectieChimie();
            chimie.Show();
        }

        private void button3_Click_ProfesorChimie(object sender, EventArgs e)
        {
            AdaugaTestChimie chimie = new AdaugaTestChimie();
            //chimie.Show();
            button1.Show();
            button2.Show();
            button3.Show();
            button4.Show();
            button5.Show();
            label1.Show();
            label2.Show();
            label3.Show();
            textBox1.Show();
            textBox2.Show();
            textBox4.Show();
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();

            label1.Location = chimie.label1.Location;
            label1.Text = chimie.label1.Text;
            label1.Size = chimie.label1.Size;
            label1.Font = chimie.label1.Font;

            label2.Location = chimie.label2.Location;
            label2.Text = chimie.label2.Text;
            label2.Size = chimie.label2.Size;
            label2.Font = chimie.label2.Font;

            label3.Location = chimie.label3.Location;
            label3.Text = chimie.label3.Text;
            label3.Size = chimie.label3.Size;
            label3.Font = chimie.label3.Font;
            
            textBox1.Location = chimie.textBox1.Location;
            textBox1.Size = chimie.textBox1.Size;
            textBox1.KeyPress += chimie.textBox1_KeyPress;

            textBox2.Location = chimie.textBox2.Location;
            textBox2.Size = chimie.textBox2.Size;
            textBox2.KeyPress += chimie.textBox1_KeyPress;

            textBox4.Location = chimie.textBox3.Location;
            textBox4.Size = chimie.textBox3.Size;
            textBox4.KeyPress += chimie.textBox1_KeyPress;
            
            this.button1.Click -= new System.EventHandler(this.button1_Click_ProfesorChimie);
            this.button1.Click += new System.EventHandler(this.button1_Click_adaugaTest);
            //button1.Visible = chimie.button1.Visible;
            button1.Location = chimie.button1.Location;
            button1.Image = chimie.button1.Image;
            button1.BackgroundImage = chimie.button1.BackgroundImage;
            button1.Size = chimie.button1.Size;
            button1.Text = chimie.button1.Text;
            button1.Enabled = false;

            this.button2.Click -= new System.EventHandler(this.button2_Click_ProfesorChimie);
            this.button2.Click += new System.EventHandler(this.button2_Click_adaugaTest);
            button2.Visible = chimie.button2.Visible;
            button2.Location = chimie.button2.Location;
            button2.Image = chimie.button2.Image;
            button2.BackgroundImage = chimie.button2.BackgroundImage;
            button2.Size = chimie.button2.Size;
            button2.Text = chimie.button2.Text;
            button2.Enabled = chimie.button2.Enabled;

            this.button3.Click -= new System.EventHandler(this.button3_Click_ProfesorChimie);
            this.button3.Click += new System.EventHandler(this.button3_Click_adaugaTest);
            button3.Visible = chimie.button3.Visible;
            button3.Location = chimie.button3.Location;
            button3.Image = chimie.button3.Image;
            button3.BackgroundImage = chimie.button3.BackgroundImage;
            button3.Size = chimie.button3.Size;
            button3.Text = chimie.button3.Text;
            button3.Enabled = chimie.button3.Enabled;

            this.button4.Click -= new System.EventHandler(this.button4_Click_ProfesorChimie);
            this.button4.Click += new System.EventHandler(this.button4_Click_adaugaTest);
            button4.Visible = chimie.button4.Visible;
            button4.Location = chimie.button4.Location;
            button4.Image = chimie.button4.Image;
            button4.BackgroundImage = chimie.button4.BackgroundImage;
            button4.Size = chimie.button4.Size;
            button4.Text = chimie.button4.Text;
            button4.Enabled = chimie.button4.Enabled;

            this.button5.Click += new System.EventHandler(this.button5_Click_adaugaTest);
            //button5.Visible = chimie.button5.Visible;
            button5.Location = chimie.button5.Location;
            button5.Image = chimie.button5.Image;
            button5.BackgroundImage = chimie.button5.BackgroundImage;
            button5.Size = chimie.button5.Size;
            button5.Text = chimie.button5.Text;
            button5.Enabled = false;
        }

        private void button2_Click_ProfesorChimie(object sender, EventArgs e)
        {
            VeziLectiiChimie chimie2 = new VeziLectiiChimie("prof");
            chimie2.Show();
        }

        private void button1_Click_ProfesorChimie(object sender, EventArgs e)
        {
            VeziTesteChimie chimie3 = new VeziTesteChimie("prof","lalala");
            chimie3.Show();
            /*


            if (Directory.Exists("D:\\Proiect\\Teste\\Chimie") == true)
            {
                int directoryCount = Directory.GetDirectories("D:\\Proiect\\Teste\\Chimie\\").Length;

                if (directoryCount != 0)
                {

                    DirectoryInfo dir1 = new DirectoryInfo("D:\\Proiect\\Teste\\Chimie\\");
                    InitializeComponent();

                    string[] dirs = Directory.GetDirectories("D:\\Proiect\\Teste\\Chimie\\");

                    //uu = u;
                    //vv = v;

                    while (nr < directoryCount)
                    {
                        if (nr >= 1)
                        {
                            string dirs2 = new DirectoryInfo(dirs[nr]).Name;
                            ll[nr] = new LinkLabel();
                            ll[nr].Text = dirs2;
                            ll[nr].AutoSize = true;
                            ll[nr].Location = new System.Drawing.Point(17, ll[nr - 1].Location.Y + 15);
                            ll[nr].Name = "linkLabel" + nr;
                            ll[nr].TabIndex = nr;
                            ll[nr].TabStop = true;
                            this.ll[nr].Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            this.Controls.Add(ll[nr]);
                            //if (ll[nr].LinkVisited == true)//new System.Windows.Forms.LinkLabelLinkClickedEventHandler(ll_LinkClicked(nr))
                            //{
                            //this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Mymethod);
                            //this.ll[nr].LinkClicked += new System.EventHandler(this.Mymethod);
                            //}

                            for (int i = 1; i < 100; i++)
                            {
                                string numefct = "this.linkLabel10" + i + "_LinkClicked";
                            }

                            if (nr == 1)
                            {
                                this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel101_LinkClicked);
                            }
                            else
                                if (nr == 2)
                                {
                                    this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel102_LinkClicked);
                                }
                                else
                                    if (nr == 3)
                                    {
                                        this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel103_LinkClicked);
                                    }
                                    else
                                        if (nr == 4)
                                        {
                                            this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel104_LinkClicked);
                                        }
                                        else
                                            if (nr == 5)
                                            {
                                                this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel105_LinkClicked);
                                            }
                                            else
                                                if (nr == 6)
                                                {
                                                    this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel106_LinkClicked);
                                                }
                                                else
                                                    if (nr == 7)
                                                    {
                                                        this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel107_LinkClicked);
                                                    }
                                                    else
                                                        if (nr == 8)
                                                        {
                                                            this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel108_LinkClicked);
                                                        }
                                                        else
                                                            if (nr == 9)
                                                            {
                                                                this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel109_LinkClicked);
                                                            }
                                                            else
                                                                if (nr == 10)
                                                                {
                                                                    this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel110_LinkClicked);
                                                                }
                                                                else
                                                                    if (nr == 11)
                                                                    {
                                                                        this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel111_LinkClicked);
                                                                    }
                                                                    else
                                                                        if (nr == 12)
                                                                        {
                                                                            this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel112_LinkClicked);
                                                                        }
                                                                        else
                                                                            if (nr == 13)
                                                                            {
                                                                                this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel113_LinkClicked);
                                                                            }
                                                                            else
                                                                                if (nr == 14)
                                                                                {
                                                                                    this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel114_LinkClicked);
                                                                                }
                                                                                else
                                                                                    if (nr == 15)
                                                                                    {
                                                                                        this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel115_LinkClicked);
                                                                                    }
                                                                                    else
                                                                                        if (nr == 16)
                                                                                        {
                                                                                            this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel116_LinkClicked);
                                                                                        }
                                                                                        else
                                                                                            if (nr == 17)
                                                                                            {
                                                                                                this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel117_LinkClicked);
                                                                                            }
                                                                                            else
                                                                                                if (nr == 18)
                                                                                                {
                                                                                                    this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel118_LinkClicked);
                                                                                                }
                                                                                                else
                                                                                                    if (nr == 19)
                                                                                                    {
                                                                                                        this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel119_LinkClicked);
                                                                                                    }
                                                                                                    else
                                                                                                        if (nr == 20)
                                                                                                        {
                                                                                                            this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel120_LinkClicked);
                                                                                                        }
                                                                                                        else
                                                                                                            if (nr == 21)
                                                                                                            {
                                                                                                                this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel121_LinkClicked);
                                                                                                            }
                                                                                                            else
                                                                                                                if (nr == 22)
                                                                                                                {
                                                                                                                    this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel122_LinkClicked);
                                                                                                                }
                                                                                                                else
                                                                                                                    if (nr == 23)
                                                                                                                    {
                                                                                                                        this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel123_LinkClicked);
                                                                                                                    }
                                                                                                                    else
                                                                                                                        if (nr == 24)
                                                                                                                        {
                                                                                                                            this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel124_LinkClicked);
                                                                                                                        }
                                                                                                                        else
                                                                                                                            if (nr == 25)
                                                                                                                            {
                                                                                                                                this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel125_LinkClicked);
                                                                                                                            }
                                                                                                                            else
                                                                                                                                if (nr == 26)
                                                                                                                                {
                                                                                                                                    this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel126_LinkClicked);
                                                                                                                                }
                                                                                                                                else
                                                                                                                                    if (nr == 27)
                                                                                                                                    {
                                                                                                                                        this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel127_LinkClicked);
                                                                                                                                    }
                                                                                                                                    else
                                                                                                                                        if (nr == 28)
                                                                                                                                        {
                                                                                                                                            this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel128_LinkClicked);
                                                                                                                                        }
                                                                                                                                        else
                                                                                                                                            if (nr == 29)
                                                                                                                                            {
                                                                                                                                                this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel129_LinkClicked);
                                                                                                                                            }
                                                                                                                                            else
                                                                                                                                                if (nr == 30)
                                                                                                                                                {
                                                                                                                                                    this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel130_LinkClicked);
                                                                                                                                                }

                            nr++;
                        }
                        else
                            if (nr == 0)
                            {
                                string dirs2 = new DirectoryInfo(dirs[nr]).Name;
                                ll[nr] = new LinkLabel();
                                ll[nr].Text = dirs2;
                                ll[nr].AutoSize = true;
                                ll[nr].Location = new System.Drawing.Point(17, 10);
                                ll[nr].Name = "linkLabel" + nr;
                                ll[nr].TabIndex = nr;
                                ll[nr].TabStop = true;
                                this.ll[nr].Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                this.Controls.Add(ll[nr]);
                                //if (ll[nr].LinkVisited == true)//new System.Windows.Forms.LinkLabelLinkClickedEventHandler(ll_LinkClicked(nr))
                                //{
                                // this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.functie);
                                //this.ll[nr].LinkClicked += new System.EventHandler(this.Mymethod);
                                //}

                                if (nr == 0)
                                {
                                    this.ll[nr].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel100_LinkClicked);
                                }
                                nr++;
                            }

                    }
                }
            }*/

        }






        //Formul VeziTesteChimie



        public LinkLabel[] ll = new LinkLabel[1000];
        public int nr = 0;
        public string uu;
        public string vv;
        public void VeziTesteChimie(string u, string v)
        {
            

        }

        void Mymethod(int nr2, object sender, EventArgs e)
        {
            //if (sender == btn1)
            MessageBox.Show(nr.ToString());
        }

        private void linkLabel100_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[0].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[0].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[0].Text);
                    test.Show();
                }
        }

        private void linkLabel101_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[1].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[1].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[1].Text);
                    test.Show();
                }
        }

        private void linkLabel102_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[2].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[2].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[2].Text);
                    test.Show();
                }
        }

        private void linkLabel103_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[3].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[3].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[3].Text);
                    test.Show();
                }
        }

        private void linkLabel104_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[4].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[4].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[4].Text);
                    test.Show();
                }
        }

        private void linkLabel105_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[5].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[5].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[5].Text);
                    test.Show();
                }
        }

        private void linkLabel106_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[6].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[6].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[6].Text);
                    test.Show();
                }
        }

        private void linkLabel107_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[7].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[7].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[7].Text);
                    test.Show();
                }
        }

        private void linkLabel108_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[8].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[8].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[8].Text);
                    test.Show();
                }
        }

        private void linkLabel109_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[9].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[9].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[9].Text);
                    test.Show();
                }
        }

        private void linkLabel110_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[10].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[10].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[10].Text);
                    test.Show();
                }
        }

        private void linkLabel111_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[11].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[11].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[11].Text);
                    test.Show();
                }
        }

        private void linkLabel112_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[12].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[12].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[12].Text);
                    test.Show();
                }
        }

        private void linkLabel113_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[13].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[13].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[13].Text);
                    test.Show();
                }
        }

        private void linkLabel114_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[14].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[14].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[14].Text);
                    test.Show();
                }
        }

        private void linkLabel115_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[15].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[15].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[15].Text);
                    test.Show();
                }
        }

        private void linkLabel116_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[16].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[16].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[16].Text);
                    test.Show();
                }
        }

        private void linkLabel117_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[17].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[17].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[17].Text);
                    test.Show();
                }
        }

        private void linkLabel118_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[18].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[18].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[18].Text);
                    test.Show();
                }
        }

        private void linkLabel119_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[19].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[19].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[19].Text);
                    test.Show();
                }
        }

        private void linkLabel120_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[20].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[20].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[20].Text);
                    test.Show();
                }
        }

        private void linkLabel121_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[21].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[21].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[21].Text);
                    test.Show();
                }
        }

        private void linkLabel122_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[22].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[22].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[22].Text);
                    test.Show();
                }
        }

        private void linkLabel123_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[23].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[23].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[23].Text);
                    test.Show();
                }
        }

        private void linkLabel124_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[24].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[24].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[24].Text);
                    test.Show();
                }
        }

        private void linkLabel125_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[25].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[25].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[25].Text);
                    test.Show();
                }
        }

        private void linkLabel126_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[26].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[26].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[26].Text);
                    test.Show();
                }
        }

        private void linkLabel127_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[27].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[27].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[27].Text);
                    test.Show();
                }
        }

        private void linkLabel128_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[28].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[28].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[28].Text);
                    test.Show();
                }
        }

        private void linkLabel129_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[29].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[29].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[29].Text);
                    test.Show();
                }
        }

        private void linkLabel130_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uu == "prof")
            {
                ProfesorTestChimie prof = new ProfesorTestChimie(ll[30].Text);
                prof.Show();
            }
            else
                if (uu == "da")
                {
                    TestChimie test = new TestChimie(ll[30].Text, vv);
                    test.Show();
                }
                else
                {
                    VizualizeazaTestChimie test = new VizualizeazaTestChimie(ll[30].Text);
                    test.Show();
                }
        }



        //Formul AdaugaTestChimie




        public int kglobal;
        public string pozitii;
        public RichTextBox[] enunt = new RichTextBox[40];
        public OpenFileDialog[] of = new OpenFileDialog[40];
        public RichTextBox[] raspuns = new RichTextBox[40];
        public PictureBox[] imagine = new PictureBox[40];
        public string[] folderimg = new String[120];
        public Label[] lb = new Label[40];
        public Label[] NrProblema = new Label[40];
        public int numarRT = 0, k = 0, kimg = 0;

        /*public void AdaugaTestChimie()
        {
            InitializeComponent();
            
        }*/

        private void button1_Click_adaugaTest(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    if (k < numarRT)
                    {
                        k++;
                        if (raspuns[k - 1].Text != "")
                        {
                            Point pos = new Point(0, 0);
                            raspuns[k] = new RichTextBox();//casuta in care scriu raspunsul
                            enunt[k] = new RichTextBox();//casuta in care scriu enuntul
                            enunt[39] = new RichTextBox();
                            of[k] = new OpenFileDialog();

                            of[k].DefaultExt = "*.txt";
                            of[k].Filter = "Text Files|*.txt|RTF Files|*.rtf";

                            raspuns[k].BackColor = System.Drawing.Color.White;
                            //enunt[k].Location = new System.Drawing.Point(0,0);// rt[k - 1].Location.Y);// + 10);
                            raspuns[k].Name = "tb" + k;
                            raspuns[k].ReadOnly = false;
                            raspuns[k].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
                            raspuns[k].Size = new System.Drawing.Size(400, 26);//(232, 26);
                            raspuns[k].TabIndex = k + 7;
                            raspuns[k].Text = "";
                            raspuns[k].WordWrap = true;

                            // Determine whether the user selected a file from the OpenFileDialog.
                            if (of[k].ShowDialog() != System.Windows.Forms.DialogResult.Cancel &&
                               of[k].FileName.Length > 0)// && of[k].ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                            {
                                //if-ul este pentru pozitia richtextbox-ului
                                if (k == 1)
                                {
                                    enunt[k].BackColor = System.Drawing.SystemColors.Control;
                                    //enunt[k].Location = new System.Drawing.Point(0,0);// rt[k - 1].Location.Y);// + 10);
                                    enunt[k].Name = "rt" + k;
                                    enunt[k].ReadOnly = false;
                                    enunt[k].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
                                    enunt[k].Size = new System.Drawing.Size(600, 10);//(464, 10);
                                    enunt[k].TabIndex = k + 7;
                                    enunt[k].Text = "";
                                    enunt[k].WordWrap = true;
                                    this.enunt[k].BorderStyle = System.Windows.Forms.BorderStyle.None;

                                    // Load the contents of the file into the RichTextBox.
                                    enunt[k].Location = new Point(0, enunt[k - 1].Location.Y + enunt[k - 1].Height + 45);
                                    //enunt[k].Location = new Point(0, NrProblema[k].Location.Y + 20);
                                    this.Controls.Add(enunt[k]);
                                }
                                else
                                    if (k > 1)
                                    {
                                        enunt[k].BackColor = System.Drawing.SystemColors.Control;
                                        //enunt[k].Location = new System.Drawing.Point(0,0);// rt[k - 1].Location.Y);// + 10);
                                        enunt[k].Name = "rt" + k;
                                        enunt[k].ReadOnly = false;
                                        enunt[k].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
                                        enunt[k].Size = new System.Drawing.Size(600, 10);//(464, 10);
                                        enunt[k].TabIndex = k + 7;
                                        enunt[k].Text = "";
                                        enunt[k].WordWrap = true;
                                        this.enunt[k].BorderStyle = System.Windows.Forms.BorderStyle.None;
                                        // Load the contents of the file into the RichTextBox.
                                        enunt[k].Location = new Point(0, lb[k - 1].Location.Y + 75);// rt[k - 1].Location.Y + rt[k - 1].Height + 15);
                                        //enunt[k].Location = new Point(0, NrProblema[k].Location.Y + 20);
                                        this.Controls.Add(enunt[k]);
                                    }

                                if (of[k].FileName.Substring(of[k].FileName.LastIndexOf('.') + 1, of[k].FileName.Length - 1 - of[k].FileName.LastIndexOf('.')) == "txt")// ||
                                    enunt[k].LoadFile(of[k].FileName, RichTextBoxStreamType.PlainText);
                                else
                                    if (of[k].FileName.Substring(of[k].FileName.LastIndexOf('.') + 1, of[k].FileName.Length - 1 - of[k].FileName.LastIndexOf('.')) == "rtf")
                                        enunt[k].LoadFile(of[k].FileName, RichTextBoxStreamType.RichText);

                                //inaltimea richtextboxului
                                pos.X = ClientRectangle.Width;
                                pos.Y = ClientRectangle.Height;
                                int lastIndex = enunt[k].GetCharIndexFromPosition(pos);
                                int lastLine = enunt[k].GetLineFromCharIndex(lastIndex) + 1;
                                enunt[k].Height = lastLine * 14;

                                button2.Hide();
                                button3.Hide();
                                button4.Hide();

                                //raspuns[k].Size += raspuns[k].Size;

                                lb[k] = new Label();
                                lb[k].Text = "Raspuns: ";
                                lb[k].Name = "label" + k;
                                this.lb[k].Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                                NrProblema[k] = new Label();
                                NrProblema[k].AutoSize = true;
                                NrProblema[k].Text = "Problema " + k;
                                NrProblema[k].Name = "Nrproblema" + k;
                                this.NrProblema[k].Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                                //pozitia label-ului "Raspuns"
                                if (k == 1)
                                {
                                    lb[k].Location = new Point(0, button1.Location.Y + enunt[k].Height - 35);
                                    NrProblema[k].Location = new Point(245, enunt[k].Location.Y - 30); //+ enunt[k - 1].Height + 15);//la mijlocul randului
                                    raspuns[k].Location = new Point(140, lb[k].Location.Y - 2);
                                    //enunt[k].Location = new Point(0, lb[k - 1].Location.Y + 35);// rt[k - 1].Location.Y + rt[k - 1].Height + 15);
                                }
                                else
                                    if (k > 1)
                                    {
                                        lb[k].Location = new Point(0, button1.Location.Y + enunt[k].Height + 50);// - 35);
                                        NrProblema[k].Location = new Point(245, lb[k - 1].Location.Y + 45);// - 35);
                                        raspuns[k].Location = new Point(140, lb[k].Location.Y - 2);
                                    }
                                this.Controls.Add(NrProblema[k]);
                                this.Controls.Add(lb[k]);
                                this.Controls.Add(raspuns[k]);

                                button1.Location = new Point(0, lb[k].Location.Y + 45); // button1.Location.Y + enunt[k].Height+40);
                                button5.Location = new Point(120, button1.Location.Y);

                                textBox1.Hide();
                                label1.Hide();
                                textBox2.Hide();
                                label3.Hide();

                                button2.Location = new Point(button5.Location.X + 110, button5.Location.Y);
                                button3.Location = new Point(button5.Location.X + 220, button5.Location.Y);
                                button4.Location = new Point(button5.Location.X + 300, button5.Location.Y);
                                /*
                                rt[39].SelectedText = enunt[k].Location.X.ToString() + ' ' + enunt[k].Location.Y.ToString() + ' ' + 
                                    lb[k].Location.X.ToString() + ' ' + lb[k].Location.Y.ToString() + '\n';
                                */
                                //raspuns[k].Text = raspuns[k].Text;
                                enunt[k].SaveFile("D:\\Proiect\\Teste\\Chimie\\" + textBox1.Text + "\\" + "problema" + k, RichTextBoxStreamType.PlainText);//"lectia" + k, RichTextBoxStreamType.RichText);
                                int lala = k - 1;
                                if (lala != 0)
                                    raspuns[k - 1].SaveFile("D:\\Proiect\\Teste\\Chimie\\" + textBox1.Text + "\\" + "raspuns" + lala, RichTextBoxStreamType.PlainText);//"lectia" + k, RichTextBoxStreamType.RichText);
                                //MessageBox.Show(raspuns[k-1].Text);
                                //SetAutoScrollMargin(617, 343);
                                kglobal = k;
                            }
                            else
                            {
                                k--;
                            }
                        }
                        else
                        {
                            k--;
                            MessageBox.Show("Introdu un raspuns");
                            raspuns[k].Focus();
                        }

                        if (k == numarRT && raspuns[k - 1].Text != "")
                        {
                            button1.Enabled = false;
                            button3.Show();
                            button2.Show();
                            //button4.Show();
                        }
                        else
                            if (k == numarRT && raspuns[k - 1].Text == "")
                            {
                                MessageBox.Show("Introdu un raspuns");
                                raspuns[k].Focus();
                            }

                    }
                    else
                    {
                        button3.Show();
                        button2.Show();
                        //button4.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click_adaugaTest(object sender, EventArgs e)
        {
            try
            {
                save = true;
                if (raspuns[k].Text != "")
                {
                    MessageBox.Show(numarRT.ToString());
                    numarRT = 0;
                    k = 0;
                    int lala = kglobal;
                    raspuns[kglobal].SaveFile("D:\\Proiect\\Teste\\Chimie\\" + textBox2.Text + "\\" + "raspuns" + lala, RichTextBoxStreamType.PlainText);//"lectia" + k, RichTextBoxStreamType.RichText);

                    if (kimg != 0)
                    {
                        Directory.CreateDirectory("D:\\Proiect\\Teste\\Chimie\\" + textBox2.Text + "\\Imagini\\");
                        pozitii = kimg.ToString() + "\n";
                        for (int i = 0; i < kimg; i++)
                        {
                            pozitii = pozitii + imagine[i].Location.X.ToString() + " " + imagine[i].Location.Y.ToString() + "\n";
                            //int s = i + 1;
                            File.Copy(folderimg[i], "D:\\Proiect\\Teste\\Chimie\\" + textBox2.Text + "\\Imagini\\" + "imagine" + i + ".jpg", true);
                            richTextBox1.Text = pozitii;
                            //richTextBox1.SaveFile(
                        }

                        richTextBox1.SaveFile("D:\\Proiect\\Teste\\Chimie\\" + textBox2.Text + "\\Imagini\\" + "setari", RichTextBoxStreamType.RichText);
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show("Introdu un raspuns");
                    raspuns[k].Focus();
                }
                //Salvez imaginile si pozitiile imaginilor in folderul imagini
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click_adaugaTest(object sender, EventArgs e)
        {
            if (raspuns[k].Text != "")
            {
                numarRT++;
                button1.Enabled = true;
                button5.Enabled = true;
                button3.Hide();
                button2.Hide();
                button4.Hide();
            }
            else
            {
                MessageBox.Show("Introdu un raspuns");
            }
        }

        private void button4_Click_adaugaTest(object sender, EventArgs e)
        {
            if (raspuns[k].Text != "")
            {
                PrintDialog print = new PrintDialog();
                print.AllowPrintToFile = true;
                print.ShowDialog();
            }
            else
            {
                MessageBox.Show("Introdu un raspuns");
                raspuns[k].Focus();
            }
        }

        private void button5_Click_adaugaTest(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                MessageBox.Show(numarRT.ToString());
                imagine[kimg] = new PictureBox();
                OpenFileDialog of = new OpenFileDialog();
                if (of.ShowDialog() != System.Windows.Forms.DialogResult.Cancel &&
                               of.FileName.Length > 0)
                {
                    folderimg[kimg] = of.FileName;

                    imagine[kimg].Load(of.FileName);
                    //imagine[kimg].Resize
                    imagine[kimg].SizeMode = PictureBoxSizeMode.AutoSize;
                    imagine[kimg].Name = "imagine" + kimg;
                    imagine[kimg].Location = new Point(button5.Location.X + 50, button5.Location.Y);

                    imagine[kimg].MouseUp += pictureBox1_MouseUp;
                    imagine[kimg].MouseMove += pictureBox1_MouseMove;
                    imagine[kimg].MouseDown += pictureBox1_MouseDown;

                    this.Controls.Add(imagine[kimg]);
                }

                //of.Dispose();
                kimg++;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            nr++;
            if (e.KeyChar == 13)
            {
                if (textBox2.Text != "" && textBox1.Text != "")
                {
                    bool lala = Directory.Exists("D:\\Proiect\\Teste\\Chimie\\" + textBox1.Text);
                    if (lala == false)
                    {
                        Directory.CreateDirectory("D:\\Proiect\\Teste\\Chimie\\" + textBox1.Text);
                        //Directory.CreateDirectory("D:\\Proiect\\Teste\\Chimie\\" + textBox2.Text + "\\Imagini\\");
                        numarRT = Convert.ToInt32(textBox2.Text);
                        button1.Enabled = true;
                        button5.Enabled = true;
                        //button1_Click(sender, e);
                        textBox1_TextChanged(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Fisierul deja exista! \nAlegeti alt nume pentru test.",
                            "Fisier deja existent!", System.Windows.Forms.MessageBoxButtons.OKCancel);
                    }
                }
                else
                {
                    textBox2.Focus();
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && textBox2.Text != "" && textBox1.Text == "")
            {
                textBox1.Focus();
            }
            else
                if (e.KeyChar == 13 && textBox2.Text != "" && textBox1.Text != "")
                {
                    bool lala = Directory.Exists("D:\\Proiect\\Teste\\Chimie\\" + textBox1.Text);
                    if (lala == false)
                    {
                        Directory.CreateDirectory("D:\\Proiect\\Teste\\Chimie\\" + textBox1.Text);
                        numarRT = Convert.ToInt32(textBox2.Text);
                        button1.Enabled = true;
                        button5.Enabled = true;
                        //button1_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Fisierul deja exista! \nAlegeti alt nume pentru test.",
                            "Fisier deja existent!", System.Windows.Forms.MessageBoxButtons.OKCancel);//"Fisier deja existent",
                        //System.Windows.Forms.MessageBoxButtons.OKCancel);
                    }
                }
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button5.Enabled = true;
            numarRT = Convert.ToInt32(textBox2.Text);
        }
        
        bool save = false;
        
        private void ScrieLectie_Load(object sender, EventArgs e)
        {
            textBox2.Focus();
        }

        private void ScrieLectie_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                numarRT = 0;
                k = 0;
                save = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        /*private Point pointMouse = new Point();
        private PictureBox ctrlMoved = new PictureBox();
        private bool bMoving = false;
        */



        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //if not left mouse button, exit
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            // save cursor location
            pointMouse = e.Location;
            //remember that we're moving
            bMoving = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            bMoving = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //int k2 = -1;
            //for (int i = 0; i < kimg; i++)
            //{
            //    if (imagine[i].Focused == true)
            //    {
            //        k2 = i;
            //    }
            //}
            //if not being moved or left mouse button not used, exit
            if (!bMoving || e.Button != MouseButtons.Left)// || k2 == -1)
            {
                return;
            }
            //get control reference
            imagine[kimg] = (PictureBox)sender;
            //set control's position based upon mouse's position change
            imagine[kimg].Left += e.X - pointMouse.X;
            imagine[kimg].Top += e.Y - pointMouse.Y;

        }

        private void AdaugaTestChimie_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (save == false)
                {
                    //Directory.Delete("D:\\Proiect\\Teste\\Chimie\\" + textBox2.Text);
                    Directory.Delete("D:\\Proiect\\Teste\\Chimie\\" + textBox2.Text, true);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabel1.Text == "Elev")
            {
                MessageBox.Show("dae");
                bd.insereazaConectat("bnmbnm Dae");
                bd.insereazaConectatNume(linkLabel2.Text);
                linkLabel4.Hide();
            }
            else
                if (linkLabel1.Text == "Profesor")
                {
                    MessageBox.Show("dap");
                    bd.insereazaConectat("bnmbnm Dap");
                    bd.insereazaConectatNume(linkLabel2.Text);
                    linkLabel4.Hide();
                }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Evaluator ev = new Evaluator();
            ev.Show();
        }

        





    }
}
