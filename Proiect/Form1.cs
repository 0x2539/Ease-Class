using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using Proiect.Aplicatii.Informatica.Evaluator;
using WMPLib;
using System.Security.Cryptography;
using System.IO;

namespace Proiect
{
    public partial class Form1 : Form
    {
        public int a1, a2, in1, in2, i1, i2, r1, r2, c1, c2;
        public int p1, p11, p2, p22, p3, p33, p4, p44, p5, p55;
        
        BazaDate bd = new BazaDate();

        //Here starts Form1 ***********************************************************************************************
        public Form1()
        {
            InitializeComponent();

            if (Deschidere.Default.SqlCon == "")
            {
                Deschidere.Default.SqlCon = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + System.IO.Path.GetFullPath("baza") + @"\Database1.mdf;Integrated Security=True;User Instance=True";
                Deschidere.Default.Save();
                //Deschidere.Default.SqlCon = Application.StartupPath + "\\Baza";
            }

            PanelForm1.Location = new Point(0, 0);
            a1 = AutentificareButton.Location.X;
            a2 = AutentificareButton.Location.Y;

            in1 = InregistrareButton.Location.X;
            in2 = InregistrareButton.Location.Y;

            i1 = DeconectareButton.Location.X;
            i2 = DeconectareButton.Location.Y;

            r1 = RamaiConectatButton.Location.X;
            r2 = RamaiConectatButton.Location.Y;

            c1 = CatalogButton.Location.X;
            c2 = CatalogButton.Location.Y;

            p1 = AutentificarePicture.Location.X;
            p11 = AutentificarePicture.Location.Y;

            p2 = InregistrarePicture.Location.X;
            p22 = InregistrarePicture.Location.Y;

            p3 = IesirePicture.Location.X;
            p33 = IesirePicture.Location.Y;

            p4 = RamaiConectatPicture.Location.X;
            p44 = RamaiConectatPicture.Location.Y;

            p5 = CatalogPicture.Location.X;
            p55 = CatalogPicture.Location.Y;

            if (linkLabel2.Text == "admin")
            {
                UnelteButton.Show();
                AdaugaMaterie.Show();
            }
            else
                if (linkLabel1.Text == "elev")
                {
                    UnelteButton.Show();
                }

            /*try
            {
                incarcaNewPass();
                incarcaMateriile();
                incarcaMateriileCatalog();
                incarcaEleviiCatalog();
            }
            catch
            {
                MessageBox.Show("Press Refresh!");
            }*/
        }

        public void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LogIn frm = new LogIn(this);
            frm.Show();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            //AdaugaTestMatematica adaugaTestMate = new AdaugaTestMatematica();
            //adaugaTestMate.Show();
        }


        public void Form1_Load(object sender, EventArgs e)
        {
            this.AutoScroll = false;
            Deschidere.Default.SqlCon = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + System.IO.Path.GetFullPath("baza") + @"\Database1.mdf;Integrated Security=True;User Instance=True";
            this.Size = new System.Drawing.Size(718, 350);
            Deschidere.Default.Save();

            //this.Hide();

            string x, y;
            x = Deschidere.Default.ElevProf;
            y = Deschidere.Default.Nume;

            if (x != "" && y != "")
            {

                if (x == "Elev")
                {
                    linkLabel1.Text = "Elev";
                    linkLabel2.Text = y;

                    UnelteButton.Show();

                    /*CalculatorPicture.Show();
                    MatriciPicture.Show();
                    EcuatiiPicture.Show();
                    DeterminantiPicture.Show();
                    CautaPeNetPicture.Show();
                    EvaluatorInformaticaPicture.Show();
                    TriunghiuriPicture.Show();

                    */

                    InregistrareButton.Hide();
                    InregistrarePicture.Hide();
                    DeconectareButton.Location = new Point(in1, in2);
                    IesirePicture.Location = new Point(InregistrarePicture.Location.X, InregistrarePicture.Location.Y);
                    //IesirePicture.Location = new Point(in1, in2);
                    DeconectareButton.Show();
                    IesirePicture.Show();



                    AutentificareButton.Text = y;
                    AutentificarePicture.Image = global::Proiect.Properties.Resources.user_info;
                    AutentificareButton.Click -= new System.EventHandler(autentificare2);
                    AutentificareButton.Click -= new System.EventHandler(button5_Click_2);
                    AutentificareButton.Click -= new System.EventHandler(autentificare);
                    AutentificareButton.Click += new System.EventHandler(autentificare);


//                    label2.Show();
                    /*CalculatorButton.Show();
                    TriunghiuriButton.Show();
                    EvaluatorInformaticaButton.Show();
                    EcuatiiButton.Show();
                    MatriciButton.Show();
                    DeterminantiButton.Show();
                    CautaPeNetButton.Show();*/
                }
                else
                    if (x == "Profesor")
                    {
                        linkLabel1.Text = "Profesor";
                        linkLabel2.Text = y;

                        UnelteButton.Show();
                        AdaugaMaterie.Show();

                        /*CalculatorPicture.Show();
                        MatriciPicture.Show();
                        EcuatiiPicture.Show();
                        DeterminantiPicture.Show();
                        CautaPeNetPicture.Show();
                        EvaluatorInformaticaPicture.Show();
                        TriunghiuriPicture.Show();
                        */


                        InregistrareButton.Hide();
                        InregistrarePicture.Hide();

                        DeconectareButton.Location = new Point(i1, i2);
                        IesirePicture.Location = new Point(p3, p33);
                        //IesirePicture.Location = new Point(i1-36, i2-5);
                        
                        CatalogButton.Location = new Point(in1, in2);
                        CatalogPicture.Location = new Point(p2, p22);
                        //CatalogPicture.Location = new Point(in1-36, in2-5);

                        DeconectareButton.Show();
                        IesirePicture.Show();
                        CatalogButton.Show();
                        CatalogPicture.Show();

                        AutentificareButton.Text = y;
                        AutentificarePicture.Image = global::Proiect.Properties.Resources.user_info;
                        AutentificareButton.Click -= new System.EventHandler(autentificare2);
                        AutentificareButton.Click -= new System.EventHandler(button5_Click_2);
                        AutentificareButton.Click -= new System.EventHandler(autentificare);
                        AutentificareButton.Click += new System.EventHandler(autentificare2);




                        //label2.Show();
                        /*CalculatorButton.Show();
                        TriunghiuriButton.Show();
                        EvaluatorInformaticaButton.Show();
                        EcuatiiButton.Show();
                        MatriciButton.Show();
                        DeterminantiButton.Show();
                        CautaPeNetButton.Show();
                        */
                    }

            }

            timer1.Start();


            //this.Show();
        }





        private void ForgotPasswordLogIn_Click(object sender, EventArgs e)
        {
            /*
            NewPasswordButton.BackColor = Color.LightSteelBlue;
            FirstPanel = PanelNewPassword;
            SecondPanel = PanelLogIn;
            xFirstPanel = FirstPanel.Location.X;
            yFirstPanel = FirstPanel.Location.X;
            xSecondPanel = SecondPanel.Location.X;
            ySecondPanel = SecondPanel.Location.X;
            FirstPanel.Location = new Point(100, 0);
            timerPaneluri.Start();
            swypePaneluri();*/
            LogInButton.BackColor = Color.YellowGreen;
            labelLogInStatus.Hide();
            this.Size = new System.Drawing.Size(718, 350);  changePanels(PanelLogIn, PanelNewPassword);
            this.Text = "Am uitat parola";
        }






        public Point pointMouse = new Point();
        public PictureBox controlMoving = new PictureBox();
        public bool bMoving = false;




        public void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        public void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }



        public void button6_Click(object sender, EventArgs e)
        {
            Triunghi tr = new Triunghi();
            tr.Show();
        }

        public void button7_Click(object sender, EventArgs e)
        {
            Ecuatie ec = new Ecuatie();
            ec.Show();
        }

        public void button8_Click(object sender, EventArgs e)
        {
            Calculator calc = new Calculator();
            calc.Show();
        }

        public void DeterminantiButton_Click(object sender, EventArgs e)
        {
            Determinanti det = new Determinanti();
            det.Show();
        }

        public void button10_Click(object sender, EventArgs e)
        {
            Matrici ma = new Matrici();
            ma.Show();
        }

        public void button11_Click(object sender, EventArgs e)
        {
            Evaluator ev = new Evaluator(linkLabel1.Text);
            ev.Show();
        }

        public void button12_Click(object sender, EventArgs e)
        {
            Net net = new Net();
            net.Show();
        }

        public void button13_Click(object sender, EventArgs e)
        {
            ReadMe rd = new ReadMe();
            rd.Show();
        }

        public void button14_Click(object sender, EventArgs e)
        {
            Ecuatia1 ec = new Ecuatia1();
            ec.Show();
        }

        public void button15_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(718, 350);  changePanels(PanelForm1, PanelCatalog);
            this.Text = "Catalog elevi";
            comboBoxEleviCatalog.Focus();
            SalveazaCatalogButton.BackColor = Color.Gold;
            SalveazaCatalogPicture.Image = global::Proiect.Properties.Resources.bullet_error;
            comboBoxEleviCatalog.Items.Clear();
            incarcaEleviiCatalog();
            SalveazaCatalogButton.Enabled = false;
            //Catalog c = new Catalog();
            //c.Show();
        }

        public void autentificare(object sender, EventArgs e)
        {
            /*if (linkLabel1.Text != "Profesor")
            {
                ProfilElev p = new ProfilElev();
                p.Show();
            }*/
            if (linkLabel1.Text != "Profesor")
            {
                incarcaProfilElev();
                incarcaMateriiProfilElev();
                this.Size = new System.Drawing.Size(718, 350);  changePanels(PanelForm1, PanelProfilElev);
            }/*
            else
                if (linkLabel1.Text == "Profesor")
                {
                    this.Size = new System.Drawing.Size(718, 350);  changePanels(PanelForm1, PanelProfilProfesor);

                }*/
        }

        public void autentificare2(object sender, EventArgs e)
        {
            /*if (linkLabel1.Text == "Profesor")
            {
                ProfilProfesor p = new ProfilProfesor();
                p.Show();
            }*/
            if (linkLabel1.Text == "Profesor")
            {
                this.Size = new System.Drawing.Size(718, 350);  changePanels(PanelForm1, PanelProfilProfesor);
                incarcaProfilProfesor();
                PrenumeProfilProfesor.Focus();

                //verific daca e admin, ca sa stiu daca ascund sau nu butonul si campul cu care creez un cod pentru 
                //creearea unui cont de profesor
                if (linkLabel2.Text != "admin")
                {
                    AdaugaProfesorCodeButton.Visible = false;
                    CodAdaugaProfesor.Visible = false;
                }
                else
                {
                    AdaugaProfesorCodeButton.Visible = true;
                    CodAdaugaProfesor.Visible = true;
                }
                //this.Size = new System.Drawing.Size(718, 350);  changePanels(PanelForm1, PanelProfilProfesor);
                //this.Size = new System.Drawing.Size(718, 350);  changePanels(PanelForm1, PanelProfilElev);
            }
        }

        /// <summary>
        /// Click pe autentificare si trimite catre log in panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button5_Click_2(object sender, EventArgs e)
        {
            //LogIn frm = new LogIn(this);
            //frm.Show();

            this.Size = new System.Drawing.Size(718, 350);  changePanels(PanelForm1, PanelLogIn);
            CampLogInId.Focus();
            //int x = PanelLogIn.Location.X, y = PanelLogIn.Location.Y;
            //PanelLogIn.Location = new Point(PanelForm1.Location.X, PanelForm1.Location.Y);
            //PanelForm1.Location = new Point(x, y);
        }

        /// <summary>
        /// click pe register
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button16_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(718, 350);  changePanels(PanelForm1, PanelRegister);
            PrenumeRegister.Focus();
            //Register register = new Register();
            //register.Show();
        }

        public void button17_Click(object sender, EventArgs e)
        {
            UnelteButton.Hide();
                    AdaugaMaterie.Hide();

            /*CalculatorPicture.Hide();
            MatriciPicture.Hide();
            EcuatiiPicture.Hide();
            DeterminantiPicture.Hide();
            CautaPeNetPicture.Hide();
            EvaluatorInformaticaPicture.Hide();
            TriunghiuriPicture.Hide();
            */

            Deschidere.Default.ElevProf = "";
            Deschidere.Default.Nume = "";
            Deschidere.Default.Save();

            InregistrareButton.Show();
            InregistrarePicture.Show();

            DeconectareButton.Hide();
            IesirePicture.Hide();
            CatalogPicture.Hide();
            CatalogButton.Hide();

            DeconectareButton.Location = new Point(i1, i2);
            IesirePicture.Location = new Point(p3, p33);

            RamaiConectatButton.Hide();
            RamaiConectatPicture.Hide();

            AutentificareButton.Click -= new System.EventHandler(button5_Click_2);
            AutentificareButton.Click += new System.EventHandler(button5_Click_2);
            AutentificareButton.Click -= new System.EventHandler(autentificare);

            AutentificareButton.Text = "Autentificare";
            AutentificarePicture.Image = global::Proiect.Properties.Resources.key;


            
            //bd.insereazaConectat("bnmbnmae");

            linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);

            //label2.Hide();

            /*CalculatorButton.Hide();
            DeterminantiButton.Hide();
            MatriciButton.Hide();
            EvaluatorInformaticaButton.Hide();
            CautaPeNetButton.Hide();
            TriunghiuriButton.Hide();
            EcuatiiButton.Hide();
            */
            linkLabel1.Text = "Log in";
            linkLabel2.Text = "Register";
        }

        public void button18_Click(object sender, EventArgs e)
        {
            Deschidere.Default.ElevProf = linkLabel1.Text;
            Deschidere.Default.Nume = linkLabel2.Text;
            Deschidere.Default.Save();

            RamaiConectatButton.Hide();
            RamaiConectatPicture.Hide();

            

            if (linkLabel1.Text == "Elev")
            {
                //bd.insereazaConectat("bnmbnm Dae");
                //bd.insereazaConectatNume(linkLabel2.Text);


                //iesire pe 3
                DeconectareButton.Location = new Point(in1, in2);
                IesirePicture.Location = new Point(p2, p22);
            }
            else
                if (linkLabel1.Text == "Profesor")
                {
                    //bd.insereazaConectat("bnmbnm Dap");
                    //bd.insereazaConectatNume(linkLabel2.Text);

                    CatalogButton.Show();
                    CatalogPicture.Show();
                    //iesire pe 3
                    DeconectareButton.Location = new Point(i1, i2);
                    IesirePicture.Location = new Point(p3, p33);
                    //catalog pe 2
                    CatalogButton.Location = new Point(in1, in2);
                    CatalogPicture.Location = new Point(p2, p22);
                }
        }

        private void button5_Click_3(object sender, EventArgs e)
        {
            Deschidere.Default.SqlCon = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + System.IO.Path.GetFullPath("baza") + @"\Database1.mdf;Integrated Security=True;User Instance=True";
            MessageBox.Show(Deschidere.Default.SqlCon);
            Deschidere.Default.Save();
        }

        private void AdaugaMaterie_Click(object sender, EventArgs e)
        {
            CreateMaterieNoua c = new CreateMaterieNoua();
            c.Show();
        }

        private void EditeazaMateriile_Click(object sender, EventArgs e)
        {
            Materiile m = new Materiile();
            m.Show();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            if (linkLabel1.Text == "Elev")
            {
                AcceseazaMateriile a = new AcceseazaMateriile("elev", linkLabel2.Text);
                a.Show();
            }
            else
                if (linkLabel1.Text == "Profesor")
                {
                    AcceseazaMateriile a = new AcceseazaMateriile("profesor",linkLabel2.Text);
                    a.Show();
                }
                else
                {
                    AcceseazaMateriile a = new AcceseazaMateriile("vizitator",linkLabel2.Text);
                    a.Show();
                }

        }


        //Here starts LogIn form ***********************************************************************************************
        private void LogInButton_Click(object sender, EventArgs e)
        {
            
            if (bd.SelectEncryptedPassword(CampLogInId.Text, CampLogInPass.Text) == 2)
            {
                linkLabel1.Text = "Elev";
                linkLabel2.Text = CampLogInId.Text;

                UnelteButton.Show();

                /*CalculatorPicture.Show();
                MatriciPicture.Show();
                EcuatiiPicture.Show();
                DeterminantiPicture.Show();
                CautaPeNetPicture.Show();
                EvaluatorInformaticaPicture.Show();
                TriunghiuriPicture.Show();
                */




                AutentificareButton.Text = CampLogInId.Text;
                AutentificarePicture.Image = global::Proiect.Properties.Resources.user_info;

                InregistrareButton.Hide();
                InregistrarePicture.Hide();

                DeconectareButton.Show();
                IesirePicture.Show();
                RamaiConectatButton.Show();
                RamaiConectatPicture.Show();

                AutentificareButton.Click -= new System.EventHandler(autentificare);
                AutentificareButton.Click -= new System.EventHandler(autentificare2);
                AutentificareButton.Click -= new System.EventHandler(button5_Click_2);
                AutentificareButton.Click += new System.EventHandler(autentificare);

                RamaiConectatButton.Location = new Point(in1, in2);
                RamaiConectatPicture.Location = new Point(p2, p22);
                DeconectareButton.Location = new Point(i1, i2);
                IesirePicture.Location = new Point(p3, p33);


                //label2.Show();
                /*CalculatorButton.Show();
                DeterminantiButton.Show();
                MatriciButton.Show();
                EvaluatorInformaticaButton.Show();
                CautaPeNetButton.Show();
                TriunghiuriButton.Show();
                EcuatiiButton.Show();
                */
                //bd.insertName(CampLogInId.Text);

                this.Size = new System.Drawing.Size(718, 350);  changePanels(PanelForm1, PanelLogIn);
                CampLogInId.Text = "";
                CampLogInPass.Text = "";
            }
            else
                if (bd.SelectEncryptedPassword(CampLogInId.Text, CampLogInPass.Text) == 1)
                {
                    linkLabel1.Text = "Profesor";
                    linkLabel2.Text = CampLogInId.Text;


                    UnelteButton.Show();

                    if (linkLabel2.Text == "admin")
                    {
                        AdaugaMaterie.Show();
                    }

                    /*CalculatorPicture.Show();
                    MatriciPicture.Show();
                    EcuatiiPicture.Show();
                    DeterminantiPicture.Show();
                    CautaPeNetPicture.Show();
                    EvaluatorInformaticaPicture.Show();
                    TriunghiuriPicture.Show();
                    */





                    AutentificareButton.Text = CampLogInId.Text;
                    AutentificarePicture.Image = global::Proiect.Properties.Resources.user_info;

                    InregistrareButton.Hide();
                    InregistrarePicture.Hide();

                    DeconectareButton.Show();
                    IesirePicture.Show();
                    RamaiConectatButton.Show();
                    RamaiConectatPicture.Show();
                    CatalogButton.Show();
                    CatalogPicture.Show();

                    AutentificareButton.Click -= new System.EventHandler(autentificare2);
                    AutentificareButton.Click -= new System.EventHandler(autentificare);
                    AutentificareButton.Click -= new System.EventHandler(button5_Click_2);
                    AutentificareButton.Click += new System.EventHandler(autentificare2);

                    //iesire pe 4
                    DeconectareButton.Location = new Point(r1, r2);
                    IesirePicture.Location = new Point(p4, p44);
                    //ramane pe 3
                    RamaiConectatButton.Location = new Point(i1, i2);
                    RamaiConectatPicture.Location = new Point(p3, p33);
                    //catalog pe 2
                    CatalogButton.Location = new Point(in1, in2);
                    CatalogPicture.Location = new Point(p2, p22);



                    //label2.Show();
                    /*CalculatorButton.Show();
                    DeterminantiButton.Show();
                    MatriciButton.Show();
                    EvaluatorInformaticaButton.Show();
                    CautaPeNetButton.Show();
                    TriunghiuriButton.Show();
                    EcuatiiButton.Show();
                    */
                    //bd.insertName(CampLogInId.Text);

                    CampLogInId.Text = "";
                    CampLogInPass.Text = "";

                    this.Size = new System.Drawing.Size(718, 350);  changePanels(PanelForm1, PanelLogIn);

                }
                else
                    if (bd.SelectEncryptedPassword(CampLogInId.Text, CampLogInPass.Text) == 0)
                    {
                        //MessageBox.Show("Nume utilizator sau parola gresită");
                        CampLogInId.Clear();
                        CampLogInPass.Clear();
                        LogInButton.BackColor = Color.Tomato;
                        labelLogInStatus.Text = "Autentificarea a esuat! Id sau parola gresita";
                        labelLogInStatus.Show();
                    }
        }

        
        private void CampLogInId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LogInButton.PerformClick();
            }
            //sa pun cod pentru ca atunci cand apasa pe tab sa treaca la campul de parola->conectare->id->parola....
        }

        private void CampLogInPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LogInButton.PerformClick();
            }
        }

        private void BackLogIn_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(718, 350);  changePanels(PanelForm1, PanelLogIn);
            AutentificareButton.Focus();
            CampLogInId.Clear();
            LogInButton.BackColor = Color.YellowGreen;
            labelLogInStatus.Hide();
            CampLogInPass.Clear();
        }

        private void incarcaProfilElev()
        {
            
            //string s = bd.selectName();
            string[] f = bd.selectProfil(linkLabel2.Text);

            this.Text = "Profil (" + linkLabel2.Text + ")";

            CampPrenume.Text = f[0];

            CampNume.Text = f[1];

            CampOras.Text = f[2];

            CampIntrebare.Text = f[3];

            CampRaspuns.Text = f[4];
        }

        private void SaveProfilElevButton_Click(object sender, EventArgs e)
        {
            try
            {
                //string s = bd.selectName();
                bd.insereazaProfil(linkLabel2.Text, CampPrenume.Text, CampNume.Text, CampOras.Text, CampIntrebare.Text, CampRaspuns.Text);
                SaveProfilElevPicture.Image = global::Proiect.Properties.Resources.bullet_accept;
                SaveProfilElevButton.BackColor = Color.YellowGreen;
            }
            catch
            {
                SaveProfilElevPicture.Image = global::Proiect.Properties.Resources.bullet_error;
                SaveProfilElevButton.BackColor = Color.Gold;
                MessageBox.Show("A intervenit o eroare!");
            }
        }



        string[] nume = new string[1000];
        string[] nume2 = new string[1000];
        int k = 0;

        public void incarcaNewPass()
        {   
            nume = bd.selectIdNewPass2();
            nume2 = nume;
            k = bd.nrConturi;
        }

        private void NewPasswordButton_Click(object sender, EventArgs e)
        {
            

            if (CampIdNewPassword.Text != "")
            {
                if (CampAnswerNewPassword.Text != "")
                {
                    if (bd.selectU(CampIdNewPassword.Text) == 1)
                    {
                        if (bd.selectRaspuns(CampIdNewPassword.Text, CampAnswerNewPassword.Text))
                        {
                            Random r = new Random();
                            string s = "qwertyuiopasdfghjklzxcvbnm1234567890";
                            string pw = "";
                            for (int i = 0; i < 6; i++)
                            {
                                pw += s[r.Next(36)];
                            }
                            CampNewPassword.Text = pw;

                            label4.Show();
                            CampNewPassword.Show();
                            bd.insertTheNewEncryptedPassword(CampIdNewPassword.Text, pw);
                            //bd.schimbaPass(CampIdNewPassword.Text, pw);
                            InfoNewPasswordPicture.Image = global::Proiect.Properties.Resources.bullet_accept;
                            NewPasswordButton.BackColor = Color.YellowGreen;
                        }
                        else
                        {
                            MessageBox.Show("Răspunsul la întrebare este incorect!");
                            InfoNewPasswordPicture.Image = global::Proiect.Properties.Resources.bullet_deny;
                            NewPasswordButton.BackColor = Color.Tomato;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Id-ul sau răspunsul la întrebare este incorect!");
                        InfoNewPasswordPicture.Image = global::Proiect.Properties.Resources.bullet_deny;
                        NewPasswordButton.BackColor = Color.Tomato;
                    }
                }
                else
                {
                    MessageBox.Show("Nu ai introdus întrebarea!");
                    InfoNewPasswordPicture.Image = global::Proiect.Properties.Resources.bullet_deny;
                }
            }
            else
            {
                MessageBox.Show("Nu ai introdus id-ul!");
                InfoNewPasswordPicture.Image = global::Proiect.Properties.Resources.bullet_deny;
            }
        }

        private void CampIdNewPassword_TextChanged(object sender, EventArgs e)
        {
            

            InfoNewPasswordPicture.Image = global::Proiect.Properties.Resources.bullet_info;
            string s = CampIdNewPassword.Text;
            for (int i = 0; i < k; i++)
            {
                if (nume2[i] == s)
                {
                    CampQuestionNewPassword.Text = bd.selectEmail(s);
                    break;
                }
                else
                {
                    CampQuestionNewPassword.Clear();
                }
            }
        }

        private void CampAnswerNewPassword_TextChanged(object sender, EventArgs e)
        {
            InfoNewPasswordPicture.Image = global::Proiect.Properties.Resources.bullet_info;
        }

        private void SchimbaParolaButton_Click(object sender, EventArgs e)
        {
            ChangePasswordButton.BackColor = Color.LightSteelBlue;
            this.Size = new System.Drawing.Size(718, 350);  changePanels(PanelProfilElev, PanelChangePassword);
            this.Text = "Schimba parola";
        }

        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            if (CampNewPassword1.Text == CampNewPassword2.Text)
            {
                
                //if (bd.selectPassword(linkLabel2.Text) == CampOldPassword.Text)
                if (bd.SelectEncryptedPasswordForChangePw(linkLabel2.Text, CampOldPassword.Text) == 1 && CampNewPassword1.Text.Length > 5)
                {
                    bd.insertTheNewEncryptedPassword(linkLabel2.Text, CampNewPassword1.Text);
                    //bd.schimbaPass(linkLabel2.Text, CampNewPassword1.Text);

                    InfoChangePasswordPicture.Image = global::Proiect.Properties.Resources.bullet_accept;
                    ChangePasswordButton.BackColor = Color.YellowGreen;
                }
                else
                    if (bd.SelectEncryptedPasswordForChangePw(linkLabel2.Text, CampOldPassword.Text) != 1)
                    {
                        InfoChangePasswordPicture.Image = global::Proiect.Properties.Resources.bullet_deny;
                        ChangePasswordButton.BackColor = Color.Tomato;
                        MessageBox.Show("Parola veche este incorecta!");
                    }
                    else
                        if (CampNewPassword1.Text.Length <= 5)
                        {
                            InfoChangePasswordPicture.Image = global::Proiect.Properties.Resources.bullet_deny;
                            ChangePasswordButton.BackColor = Color.Tomato;
                            MessageBox.Show("Parola noua este prea scurta!" + '\n' + "Trebuiesc cel putin 6 caractere!");
                        }
            }
        }

        private void GoBackChangePasswordButton_Click(object sender, EventArgs e)
        {
            if (linkLabel1.Text == "Profesor")
            {
                this.Size = new System.Drawing.Size(718, 350);  changePanels(PanelChangePassword, PanelProfilProfesor);
                this.Text = "Profil (" + linkLabel2.Text + ")";
                ChangePasswordProfilProfesor.Focus();
            }
            else
            {
                this.Size = new System.Drawing.Size(718, 350); changePanels(PanelChangePassword, PanelProfilElev);
                this.Text = "Profil (" + linkLabel2.Text + ")";
                SchimbaParolaButton.Focus();
            }
            CampOldPassword.Clear();
            CampNewPassword1.Clear();
            CampNewPassword2.Clear();

            InfoChangePasswordPicture.Image = global::Proiect.Properties.Resources.bullet_info;
        }

        private void GoBackProfilElevButton_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(718, 350);  changePanels(PanelProfilElev, PanelForm1);
            ascundeDateleSiNoteleProfil(nrUltimeiMateriiProfil, nrDeNoteProfil[nrUltimeiMateriiProfil]);
            AutentificareButton.Focus();
            this.Text = "Ease Class";
        }

        private void GoBackNewPassword_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(718, 350);  changePanels(PanelLogIn, PanelNewPassword);
            this.Text = "Log in";
            CampIdNewPassword.Clear();
            CampQuestionNewPassword.Clear();
            CampAnswerNewPassword.Clear();
            CampNewPassword.Clear();
            LogInButton.Focus();
        }

        private void GoBackCatalogButton_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(718, 350);  changePanels(PanelCatalog, PanelForm1);
            this.Text = "Ease Class";
            ascundeDateleSiNotele(nrMaterieCurenta, nrNotelorMateriei[nrMaterieCurenta]);
            AutentificareButton.Focus();
        }

        private void comboBoxEleviCatalog_TextChanged(object sender, EventArgs e)
        {
            button5.Enabled = false;
            SalveazaCatalogPicture.Image = global::Proiect.Properties.Resources.bullet_error;

            /*if (sterge1 != 0)
            {
                for (int i = 0; i < sterge1; i++)
                {
                    note1[i].Hide();
                }

                for (int i = 0; i < sterge1; i++)
                {
                    date1[i].Hide();
                }
            }
            labelNota.Text = "Nota";*/
        }



        //Here starts AcceseazaMateriile *****************************************************************************
        Button[] materiile = new Button[140];
        int nrMaterii = 0;

        public void incarcaMateriile()
        {
            MateriiTextBox.LoadFile(Application.StartupPath + "\\materii.materie", RichTextBoxStreamType.PlainText);

            string[] materii = MateriiTextBox.Text.Split('\n');
            nrMaterii = materii.Length;

            for (int i = 0; i < materii.Length - 1; i++)
            {
                materiile[i] = new Button();

                materiile[i].BackColor = System.Drawing.Color.YellowGreen;
                materiile[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                materiile[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                
                materiile[i].AutoSize = true;
                materiile[i].AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                if (i == 0)
                {
                    materiile[i].Location = new System.Drawing.Point(33, 24);
                }
                else
                {
                    materiile[i].Location = new System.Drawing.Point(33, materiile[i - 1].Location.Y + 35);
                }
                materiile[i].Size = new System.Drawing.Size(61, 23);
                materiile[i].Text = materii[i];
                materiile[i].UseVisualStyleBackColor = true;
                materiile[i].Click += new System.EventHandler(this.afiseazaMateria);
                PanelForm1.Controls.Add(materiile[i]);
            }
        }

        private void afiseazaMateria(object sender, EventArgs e)
        {
            //MessageBox.Show(sender.ToString());
            string s = sender.ToString();
            s = s.Substring(s.LastIndexOf("Text: ") + 6, s.Length - s.LastIndexOf("Text: ") - 6);
            //MessageBox.Show(s);
            //verific pe care dintre materii a accesat
            for (int i = 0; i < nrMaterii - 1; i++)
            {
                //MessageBox.Show(sender.Equals(materiile[i]).ToString());
                if (s==materiile[i].Text)
                {
                    incarcaListaLectiiSiTeste(materiile[i].Text);
                    this.Size = new System.Drawing.Size(718, 350);  changePanels(PanelForm1, PanelListaLectiiSiTeste);
                    this.Text = "Lista lectii si teste";
                    RefreshListaLectiiSiTeste.Focus();
                    //NewListaLectiiSiTeste l = new NewListaLectiiSiTeste(materiile[i].Text, linkLabel1.Text, linkLabel2.Text);
                    //l.Show();
                }
            }
        }


        //Here starts Catalog **************************************************************************************************
        
        
        //Here starts AcceseazaMateriile *****************************************************************************
        Button[] materiileCatalog = new Button[140];

        public void incarcaMateriileCatalog()
        {

            string[] materii = MateriiTextBox.Text.Split('\n');

            for (int i = 0; i < materii.Length - 1; i++)
            {
                materiileCatalog[i] = new Button();

                materiileCatalog[i].BackColor = System.Drawing.Color.YellowGreen;
                materiileCatalog[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                materiileCatalog[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                
                materiileCatalog[i].AutoSize = true;
                materiileCatalog[i].AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                if (i == 0)
                {
                    materiileCatalog[i].Location = new System.Drawing.Point(40, 114);
                }
                else
                {
                    materiileCatalog[i].Location = new System.Drawing.Point(40, materiileCatalog[i - 1].Location.Y + 35);
                }
                materiileCatalog[i].Size = new System.Drawing.Size(61, 23);
                materiileCatalog[i].Text = materii[i];
                materiileCatalog[i].UseVisualStyleBackColor = true;
                materiileCatalog[i].Click += new System.EventHandler(this.afiseazaNoteleMaterieiCatalog);
                PanelCatalog.Controls.Add(materiileCatalog[i]);
            }
        }

        string totiElevii = "";

        public void incarcaEleviiCatalog()
        {
            
            string[] elevi = bd.incarcaElevii().Split(';');
            totiElevii = bd.incarcaElevii();
            for (int i = 0; i < elevi.Length - 1; i++)
            {
                comboBoxEleviCatalog.Items.Add(elevi[i]);
            }
        }


        TextBox[,,] noteleMateriei = new TextBox[140, 140, 140];
        TextBox[,,] dataNoteiMateriei = new TextBox[140, 140, 140];
        int[] nrNotelorMateriei = new int[140];
        string AscundeUltimaMaterieCatalog = "";
        
        int nrUltimeiMaterii = 0;
        int indexElevCatalog = -1;
        int nrMaterieCurenta = 0;
        

        private void afiseazaNoteleMaterieiCatalog(object sender, EventArgs e)
        {
            if (comboBoxEleviCatalog.Text.Trim(' ') != "")
            {
                string numeElev = comboBoxEleviCatalog.Text;
                //verific daca elevul scris in combobox se afla in baza de date
                //MessageBox.Show(totiElevii);
                if (totiElevii.IndexOf(numeElev) != -1)
                    if ((totiElevii.IndexOf(numeElev) != 0  && totiElevii[totiElevii.IndexOf(numeElev) - 1] == ';' &&
                        totiElevii[totiElevii.IndexOf(numeElev) + numeElev.Length] == ';') ||
                        totiElevii.IndexOf(numeElev) == 0 &&
                        totiElevii[totiElevii.IndexOf(numeElev) + numeElev.Length] == ';')
                    {
                        //verific pe care dintre materii a apasat
                        for (int i = 0; i < nrMaterii - 1; i++)
                        {
                            string ss = sender.ToString();
                            ss = ss.Substring(ss.LastIndexOf("Text: ") + 6, ss.Length - ss.LastIndexOf("Text: ") - 6);
                            if (ss==materiileCatalog[i].Text)
                            {
                                

                                //in s[0] voi salva notele, iar in s[1] datele notelor
                                string[] s = new string[2];

                                //verific daca materia accesata acum e diferita de ultima
                                if (AscundeUltimaMaterieCatalog != materiileCatalog[i].Text)
                                {
                                    //ascund notele si datele de la ultima materie accesata
                                    if (AscundeUltimaMaterieCatalog != "")
                                    {
                                        ascundeDateleSiNotele(nrUltimeiMaterii, nrNotelorMateriei[nrUltimeiMaterii]);
                                    }
                                    //retin materia pe care am apasat pentru a sti pe care o ascund cand vreau sa afisez alta
                                    AscundeUltimaMaterieCatalog = materiileCatalog[i].Text;
                                    nrUltimeiMaterii = i;

                                    AdaugaNotaCatalogButton.Enabled = true;

                                    //pentru matematica, fizica, chimie si informatica nu am putut sa schimb numele coloanelor
                                    //asa ca in loc de dataMatematica scriu datam
                                    /*if (materiileCatalog[i].Text == "Matematica")
                                    {
                                        s = bd.incarcaNoteleSiDateleMateriei(numeElev.Substring(0, numeElev.IndexOf(' ')),
                                           numeElev.Substring(numeElev.IndexOf(' ') + 1, numeElev.Length - numeElev.IndexOf(' ') - 1),
                                           "m", "").Split('*');
                                    }
                                    else
                                        if (materiileCatalog[i].Text == "Fizica")
                                        {
                                            s = bd.incarcaNoteleSiDateleMateriei(numeElev.Substring(0, numeElev.IndexOf(' ')),
                                               numeElev.Substring(numeElev.IndexOf(' ') + 1, numeElev.Length - numeElev.IndexOf(' ') - 1),
                                               "f", "").Split('*');
                                        }
                                        else
                                            if (materiileCatalog[i].Text == "Chimie")
                                            {
                                                s = bd.incarcaNoteleSiDateleMateriei(numeElev.Substring(0, numeElev.IndexOf(' ')),
                                                   numeElev.Substring(numeElev.IndexOf(' ') + 1, numeElev.Length - numeElev.IndexOf(' ') - 1),
                                                   "c", "").Split('*');
                                            }
                                            else
                                                if (materiileCatalog[i].Text == "Informatica")
                                                {
                                                    s = bd.incarcaNoteleSiDateleMateriei(numeElev.Substring(0, numeElev.IndexOf(' ')),
                                                       numeElev.Substring(numeElev.IndexOf(' ') + 1, numeElev.Length - numeElev.IndexOf(' ') - 1),
                                                       "i", "").Split('*');
                                                }
                                                else
                                                {*/
                                                    s = bd.incarcaNoteleSiDateleMateriei(numeElev.Substring(0, numeElev.IndexOf(' ')),
                                                       numeElev.Substring(numeElev.IndexOf(' ') + 1, numeElev.Length - numeElev.IndexOf(' ') - 1),
                                                       materiileCatalog[i].Text, "");
                                                //}


                                    string[] notele = s[0].Split(';');
                                    string[] datele = s[1].Split(';');

                                    //in cazul in care nu exista nici o nota, sau este decat 1 data
                                    if (notele.Length == 0)
                                    {
                                        noteleMateriei[indexElevCatalog, i, 0] = new TextBox();
                                        noteleMateriei[indexElevCatalog, i, 0].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                                        
                                        noteleMateriei[indexElevCatalog, i, 0].Location = new System.Drawing.Point(CampNotaCatalogText.Location.X,
                                                        CampNotaCatalogText.Location.Y);
                                        
                                        noteleMateriei[indexElevCatalog, i, 0].Size = new System.Drawing.Size(115, 23);
                                        noteleMateriei[indexElevCatalog, i, 0].TabStop = false;
                                        noteleMateriei[indexElevCatalog, i, 0].Text = "";
                                        PanelNoteCatalog.Controls.Add(noteleMateriei[indexElevCatalog, i, 0]);
                                        noteleMateriei[indexElevCatalog, i, 0].TextChanged += new System.EventHandler(this.SchimbaTextulNotei);



                                        dataNoteiMateriei[indexElevCatalog, i, 0] = new TextBox();
                                        dataNoteiMateriei[indexElevCatalog, i, 0].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                                        
                                        dataNoteiMateriei[indexElevCatalog, i, 0].Location = new System.Drawing.Point(CampDataCatalogText.Location.X,
                                                        CampDataCatalogText.Location.Y);
                                        
                                        dataNoteiMateriei[indexElevCatalog, i, 0].Size = new System.Drawing.Size(115, 23);
                                        dataNoteiMateriei[indexElevCatalog, i, 0].TabStop = false;
                                        dataNoteiMateriei[indexElevCatalog, i, 0].Text = datele[0];
                                        PanelNoteCatalog.Controls.Add(dataNoteiMateriei[indexElevCatalog, i, 0]);
                                        dataNoteiMateriei[indexElevCatalog, i, 0].TextChanged += new System.EventHandler(this.SchimbaTextulNotei);


                                        PanelNoteCatalog.Height = 70 + 23 * nrNotelorMateriei[i];
                                    }

                                    //salvez numarul notelor de la materia respectiva
                                    nrNotelorMateriei[i] = datele.Length;

                                    //afisez cele 2 coloane de note si date
                                    for (int j = 0; j < nrNotelorMateriei[i]; j++)
                                    {
                                        //MessageBox.Show(datele[j] + '\n' + notele[j] + '\n' + s[1]);
                                        noteleMateriei[indexElevCatalog, i, j] = new TextBox();
                                        noteleMateriei[indexElevCatalog, i, j].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                                        if (j > 0)
                                        {
                                            noteleMateriei[indexElevCatalog, i, j].Location = new System.Drawing.Point(CampNotaCatalogText.Location.X,
                                                            noteleMateriei[indexElevCatalog, i, j - 1].Location.Y + 23);
                                        }
                                        else
                                        {
                                            noteleMateriei[indexElevCatalog, i, j].Location = new System.Drawing.Point(CampNotaCatalogText.Location.X,
                                                            CampNotaCatalogText.Location.Y);
                                        }
                                        noteleMateriei[indexElevCatalog, i, j].Size = new System.Drawing.Size(115, 23);
                                        noteleMateriei[indexElevCatalog, i, j].TabStop = false;
                                        noteleMateriei[indexElevCatalog, i, j].Text = notele[j];
                                        PanelNoteCatalog.Controls.Add(noteleMateriei[indexElevCatalog, i, j]);
                                        noteleMateriei[indexElevCatalog, i, j].TextChanged += new System.EventHandler(this.SchimbaTextulNotei);



                                        dataNoteiMateriei[indexElevCatalog, i, j] = new TextBox();
                                        dataNoteiMateriei[indexElevCatalog, i, j].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                                        if (j > 0)
                                        {
                                            dataNoteiMateriei[indexElevCatalog, i, j].Location = new System.Drawing.Point(CampDataCatalogText.Location.X,
                                                            dataNoteiMateriei[indexElevCatalog, i, j - 1].Location.Y + 23);
                                        }
                                        else
                                        {
                                            dataNoteiMateriei[indexElevCatalog, i, j].Location = new System.Drawing.Point(CampDataCatalogText.Location.X,
                                                            CampDataCatalogText.Location.Y);
                                        }
                                        dataNoteiMateriei[indexElevCatalog, i, j].Size = new System.Drawing.Size(115, 23);
                                        dataNoteiMateriei[indexElevCatalog, i, j].TabStop = false;
                                        dataNoteiMateriei[indexElevCatalog, i, j].Text = datele[j];
                                        PanelNoteCatalog.Controls.Add(dataNoteiMateriei[indexElevCatalog, i, j]);
                                        dataNoteiMateriei[indexElevCatalog, i, j].TextChanged += new System.EventHandler(this.SchimbaTextulNotei);


                                        PanelNoteCatalog.Height = 70 + 23 * nrNotelorMateriei[i];
                                    }
                                }
                                else
                                {
                                    //sunt deja afisate notele si datele acestei materii
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Elevul selectat nu face parte din baza de date!");
                    }
            }
            else
            {
                MessageBox.Show("Elevul selectat nu face parte din baza de date!");
            }
        }


        private void SchimbaTextulNotei(object sender, EventArgs e)
        {
            button5.Enabled = true;
            SalveazaCatalogPicture.Image = global::Proiect.Properties.Resources.bullet_info;
            SalveazaCatalogButton.Enabled = true;
            SalveazaCatalogButton.BackColor = Color.YellowGreen;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            
            /*bd.DeleteColumn("Imagini", "Informatica");
            bd.DeleteColumn("Imagini", "Chimie");
            bd.DeleteColumn("Imagini", "Fizica");
            bd.DeleteColumn("Imagini", "Matematica");
            bd.DeleteColumn("Imagini", "Romana");*/
            /*bd.InsertNewColumn("Problema1", "nvarchar(MAX)", "Matematica");
            bd.InsertNewColumn("Problema2", "nvarchar(MAX)", "Matematica");*/
            /*bd.InsertNewColumn("Imagini", "image", "Fizica");
            bd.InsertNewColumn("Imagini", "image", "Romana");
            bd.InsertNewColumn("Imagini", "image", "Chimie");
            bd.InsertNewColumn("Imagini", "image", "Matematica");
            bd.InsertNewColumn("Imagini", "image", "Informatica");*/
            //bd.createNewTable("Romana");
            /*bd.createNewTable("Matematica");
            bd.createNewTable("Informatica");
            bd.createNewTable("Fizica");
            bd.createNewTable("Chimie");*/
        }

        private void comboBoxEleviCatalog_SelectedIndexChanged(object sender, EventArgs e)
        {
            AscundeUltimaMaterieCatalog = "";
            ascundeDateleSiNotele(nrUltimeiMaterii, nrNotelorMateriei[nrUltimeiMaterii]);
            AdaugaNotaCatalogButton.Enabled = false;
            indexElevCatalog = comboBoxEleviCatalog.SelectedIndex;
            PanelNoteCatalog.Height = 70;
        }

        private void ascundeDateleSiNotele(int nrMateriei, int nrDeNoteAleMateriei)
        {
            for (int i = 0; i < nrDeNoteAleMateriei; i++)
            {
                noteleMateriei[indexElevCatalog, nrMateriei, i].Hide();
                dataNoteiMateriei[indexElevCatalog, nrMateriei, i].Hide();
            }
            AdaugaNotaCatalogButton.Enabled = false;
        }

        private void SalveazaCatalogButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < nrMaterii - 1; i++)
            {
                string nota = "";
                string data = "";

                bool canInsert = true;

                for (int j = 0; j < nrNotelorMateriei[i]; j++)
                {
                    //verific daca a inserat ;, si daca da atunci ii dau eroare
                    if (noteleMateriei[indexElevCatalog, i, j].Text.IndexOf(';') != -1 ||
                        dataNoteiMateriei[indexElevCatalog, i, j].Text.IndexOf(';') != -1)
                    {
                        canInsert = false;
                        break;
                    }

                    //daca exista nota, sau data in caz ca se doreste doar data
                    if (noteleMateriei[indexElevCatalog, i, j].Text != "Nu exista note!" && 
                        dataNoteiMateriei[indexElevCatalog, i,j].Text != "")
                    {
                        nota += noteleMateriei[indexElevCatalog, i, j].Text + ';';
                        data += dataNoteiMateriei[indexElevCatalog, i, j].Text + ';';
                    }
                }
                string s = materiileCatalog[i].Text;
                /*if (s == "Matematica")
                {
                    s = "m";
                }
                else
                    if (s == "Fizica")
                    {
                        s = "f";
                    }
                    else
                        if (s == "Chimie")
                        {
                            s = "c";
                        }
                        else
                            if (s == "Informatica")
                            {
                                s = "i";
                            }*/
                /*
                MessageBox.Show(s + '\n' + noteleMateriei[indexElevCatalog, i, j].Text + '\n' +
                    dataNoteiMateriei[indexElevCatalog, i, j].Text + '\n' +
                    comboBoxEleviCatalog.Text.Substring(0, comboBoxEleviCatalog.Text.IndexOf(' ')) + '\n' +
                    comboBoxEleviCatalog.Text.Substring(comboBoxEleviCatalog.Text.IndexOf(' ') + 1,
                                comboBoxEleviCatalog.Text.Length - comboBoxEleviCatalog.Text.IndexOf(' ') - 1));*/
                //if (data != "")
                {
                    /*MessageBox.Show(s + '\n' + nota + '\n' + data + '\n' +
                          comboBoxEleviCatalog.Text.Substring(0, comboBoxEleviCatalog.Text.IndexOf(' ')) + '\n' +
                          comboBoxEleviCatalog.Text.Substring(comboBoxEleviCatalog.Text.IndexOf(' ') + 1,
                                      comboBoxEleviCatalog.Text.Length - comboBoxEleviCatalog.Text.IndexOf(' ') - 1));*/
                    if (canInsert == true)
                    {
                        bd.adaugaNoteleSiDateleInBazaDeDate(s, nota, data,
                          comboBoxEleviCatalog.Text.Substring(0, comboBoxEleviCatalog.Text.IndexOf(' ')),
                          comboBoxEleviCatalog.Text.Substring(comboBoxEleviCatalog.Text.IndexOf(' ') + 1,
                                      comboBoxEleviCatalog.Text.Length - comboBoxEleviCatalog.Text.IndexOf(' ') - 1));
                        
                        SalveazaCatalogButton.Enabled = false;
                        SalveazaCatalogPicture.Image = global::Proiect.Properties.Resources.bullet_error;
                        SalveazaCatalogButton.BackColor = Color.Gold;

                    }
                    else
                    {
                        MessageBox.Show("Nu inserati ';' in casuta notei sau a datei!");
                    }
                }
            }
            
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            
            bd.Aleator(comboBoxEleviCatalog.Text.Substring(0, comboBoxEleviCatalog.Text.IndexOf(' ')),
                      comboBoxEleviCatalog.Text.Substring(comboBoxEleviCatalog.Text.IndexOf(' ') + 1,
                                  comboBoxEleviCatalog.Text.Length - comboBoxEleviCatalog.Text.IndexOf(' ') - 1));
        }

        private void AdaugaNotaCatalogButton_Click(object sender, EventArgs e)
        {
            noteleMateriei[indexElevCatalog, nrUltimeiMaterii, nrNotelorMateriei[nrUltimeiMaterii]] = new TextBox();
            noteleMateriei[indexElevCatalog, nrUltimeiMaterii, nrNotelorMateriei[nrUltimeiMaterii]].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            noteleMateriei[indexElevCatalog, nrUltimeiMaterii, nrNotelorMateriei[nrUltimeiMaterii]].Location = new System.Drawing.Point(CampNotaCatalogText.Location.X,
                            noteleMateriei[indexElevCatalog, nrUltimeiMaterii, nrNotelorMateriei[nrUltimeiMaterii] - 1].Location.Y + 23);

            noteleMateriei[indexElevCatalog, nrUltimeiMaterii, nrNotelorMateriei[nrUltimeiMaterii]].Size = new System.Drawing.Size(115, 23);
            noteleMateriei[indexElevCatalog, nrUltimeiMaterii, nrNotelorMateriei[nrUltimeiMaterii]].TabStop = false;
            noteleMateriei[indexElevCatalog, nrUltimeiMaterii, nrNotelorMateriei[nrUltimeiMaterii]].Text = "";
            PanelNoteCatalog.Controls.Add(noteleMateriei[indexElevCatalog, nrUltimeiMaterii, nrNotelorMateriei[nrUltimeiMaterii]]);
            noteleMateriei[indexElevCatalog, nrUltimeiMaterii, nrNotelorMateriei[nrUltimeiMaterii]].TextChanged += new System.EventHandler(this.SchimbaTextulNotei);





            dataNoteiMateriei[indexElevCatalog, nrUltimeiMaterii, nrNotelorMateriei[nrUltimeiMaterii]] = new TextBox();
            dataNoteiMateriei[indexElevCatalog, nrUltimeiMaterii, nrNotelorMateriei[nrUltimeiMaterii]].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            dataNoteiMateriei[indexElevCatalog, nrUltimeiMaterii, nrNotelorMateriei[nrUltimeiMaterii]].Location = new System.Drawing.Point(CampDataCatalogText.Location.X,
                            dataNoteiMateriei[indexElevCatalog, nrUltimeiMaterii, nrNotelorMateriei[nrUltimeiMaterii] - 1].Location.Y + 23);

            dataNoteiMateriei[indexElevCatalog, nrUltimeiMaterii, nrNotelorMateriei[nrUltimeiMaterii]].Size = new System.Drawing.Size(115, 23);
            dataNoteiMateriei[indexElevCatalog, nrUltimeiMaterii, nrNotelorMateriei[nrUltimeiMaterii]].TabStop = false;
            dataNoteiMateriei[indexElevCatalog, nrUltimeiMaterii, nrNotelorMateriei[nrUltimeiMaterii]].Text = "";
            PanelNoteCatalog.Controls.Add(dataNoteiMateriei[indexElevCatalog, nrUltimeiMaterii, nrNotelorMateriei[nrUltimeiMaterii]]);
            dataNoteiMateriei[indexElevCatalog, nrUltimeiMaterii, nrNotelorMateriei[nrUltimeiMaterii]].TextChanged += new System.EventHandler(this.SchimbaTextulNotei);

            PanelNoteCatalog.Height += 23;

            nrNotelorMateriei[nrUltimeiMaterii]++;
        }

        
        
        Button[] materiiProfil = new Button[140];
        TextBox[,] noteProfil = new TextBox[140,140];
        TextBox[,] dateProfil = new TextBox[140,140];
        string ultimaMaterieProfil = "";
        int nrUltimeiMateriiProfil = 0;
        int[] nrDeNoteProfil = new int[140];
        private void incarcaMateriiProfilElev()
        {
            MateriiTextBox.LoadFile(Application.StartupPath + "\\materii.materie", RichTextBoxStreamType.PlainText);

            string[] materii = MateriiTextBox.Text.Split('\n');
            nrMaterii = materii.Length;

            for (int i = 0; i < materii.Length - 1; i++)
            {
                materiiProfil[i] = new Button();

                materiiProfil[i].BackColor = System.Drawing.Color.YellowGreen;
                materiiProfil[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                materiiProfil[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                
                materiiProfil[i].AutoSize = true;
                materiiProfil[i].AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                if (i > 0)
                {
                    materiiProfil[i].Location = new System.Drawing.Point(PrototypeProfil.Location.X, materiiProfil[i - 1].Location.Y + 35);
                }
                else
                {
                    materiiProfil[i].Location = new System.Drawing.Point(PrototypeProfil.Location.X, PrototypeProfil.Location.Y);
                }
                materiiProfil[i].Size = new System.Drawing.Size(61, 23);
                materiiProfil[i].Text = materii[i];
                materiiProfil[i].UseVisualStyleBackColor = true;
                materiiProfil[i].Click += new System.EventHandler(this.afiseazaNoteleMaterieiProfil);
                PanelMateriiProfilElev.Controls.Add(materiiProfil[i]);
                PanelMateriiProfilElev.Height += 35;
            }
        }

        private void afiseazaNoteleMaterieiProfil(object sender, EventArgs e)
        {
            string ss = sender.ToString();
            ss = ss.Substring(ss.LastIndexOf("Text: ") + 6, ss.Length - ss.LastIndexOf("Text: ") - 6);
            for (int i = 0; i < nrMaterii - 1; i++)
            {
                if (ss==materiiProfil[i].Text)
                {
                    if (ultimaMaterieProfil != materiiProfil[i].Text)
                    {
                        if (ultimaMaterieProfil != "")
                        {
                            ascundeDateleSiNoteleProfil(nrUltimeiMateriiProfil, nrDeNoteProfil[nrUltimeiMateriiProfil]);
                        }

                        

                        //in s[0] voi salva notele, iar in s[1] datele notelor
                        string[] s = new string[2];
                            //retin materia pe care am apasat pentru a sti pe care o ascund cand vreau sa afisez alta
                            ultimaMaterieProfil = materiiProfil[i].Text;
                            nrUltimeiMateriiProfil = i;


                            //pentru matematica, fizica, chimie si informatica nu am putut sa schimb numele coloanelor
                            //asa ca in loc de dataMatematica scriu datam
                            /*if (materiiProfil[i].Text == "Matematica")
                            {
                                s = bd.incarcaNoteleSiDateleMateriei("", "", "m", linkLabel2.Text).Split('*');
                            }
                            else
                                if (materiileCatalog[i].Text == "Fizica")
                                {
                                    s = bd.incarcaNoteleSiDateleMateriei("", "", "f", linkLabel2.Text).Split('*');
                                }
                                else
                                    if (materiileCatalog[i].Text == "Chimie")
                                    {
                                        s = bd.incarcaNoteleSiDateleMateriei("", "", "c", linkLabel2.Text).Split('*');
                                    }
                                    else
                                        if (materiileCatalog[i].Text == "Informatica")
                                        {
                                            s = bd.incarcaNoteleSiDateleMateriei("", "", "i", linkLabel2.Text).Split('*');
                                        }
                                        else
                                        {*/
                                            s = bd.incarcaNoteleSiDateleMateriei("", "", materiiProfil[i].Text, linkLabel2.Text);
                                        //}


                            string[] notele = s[0].Split(';');
                            string[] datele = s[1].Split(';');

                            //in cazul in care nu exista nici o nota, sau este decat 1 data
                            if (notele.Length == 0)
                            {
                                noteProfil[i, 0] = new TextBox();
                                noteProfil[i, 0].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

                                noteProfil[i, 0].Location = new System.Drawing.Point(CampNotaProfil.Location.X,
                                                CampNotaProfil.Location.Y);

                                noteProfil[i, 0].Size = new System.Drawing.Size(120, 23);
                                noteProfil[i, 0].ReadOnly = true;
                                noteProfil[i, 0].TabStop = false;
                                noteProfil[i, 0].Text = "";
                                PanelNoteProfil.Controls.Add(noteProfil[i, 0]);
                                


                                dateProfil[i, 0] = new TextBox();
                                dateProfil[i, 0].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

                                dateProfil[i, 0].Location = new System.Drawing.Point(CampDataProfil.Location.X,
                                                CampDataProfil.Location.Y);

                                dateProfil[i, 0].Size = new System.Drawing.Size(130, 23);
                                dateProfil[i, 0].ReadOnly = true;
                                dateProfil[i, 0].TabStop = false;
                                dateProfil[i, 0].Text = datele[0];
                                PanelNoteProfil.Controls.Add(dateProfil[i, 0]);
                                

                                PanelNoteProfil.Height = 70 + 23 * nrNotelorMateriei[i];
                            }

                            //salvez numarul notelor de la materia respectiva
                            nrDeNoteProfil[i] = datele.Length;

                            //afisez cele 2 coloane de note si date
                            for (int j = 0; j < nrDeNoteProfil[i]; j++)
                            {
                                noteProfil[i, j] = new TextBox();
                                noteProfil[i, j].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                                if (j > 0)
                                {
                                    noteProfil[i, j].Location = new System.Drawing.Point(CampNotaCatalogText.Location.X,
                                                    noteProfil[i, j - 1].Location.Y + 23);
                                }
                                else
                                {
                                    noteProfil[i, j].Location = new System.Drawing.Point(CampNotaProfil.Location.X,
                                                    CampNotaProfil.Location.Y);
                                }
                                noteProfil[i, j].Size = new System.Drawing.Size(120, 23);
                                noteProfil[i, j].ReadOnly = true;
                                noteProfil[i, j].TabStop = false;
                                noteProfil[i, j].Text = notele[j];
                                PanelNoteProfil.Controls.Add(noteProfil[i, j]);
                                noteProfil[i, j].TextChanged += new System.EventHandler(this.SchimbaTextulNotei);



                                dateProfil[i, j] = new TextBox();
                                dateProfil[i, j].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                                if (j > 0)
                                {
                                    dateProfil[i, j].Location = new System.Drawing.Point(CampDataProfil.Location.X,
                                                    dateProfil[i, j - 1].Location.Y + 23);
                                }
                                else
                                {
                                    dateProfil[i, j].Location = new System.Drawing.Point(CampDataProfil.Location.X,
                                                    CampDataProfil.Location.Y);
                                }
                                dateProfil[i, j].Size = new System.Drawing.Size(130, 23);
                                dateProfil[i, j].ReadOnly = true;
                                dateProfil[i, j].TabStop = false;
                                dateProfil[i, j].Text = datele[j];
                                PanelNoteProfil.Controls.Add(dateProfil[i, j]);


                                PanelNoteProfil.Height = 70 + 23 * nrDeNoteProfil[i];
                            }
                        
                    }
                    else
                    {
                        //deja a apasat pe materie
                    }
                }
                else
                {
                    //nu a apasat pe butonul asta
                }
            }


        }

        private void ascundeDateleSiNoteleProfil(int nrMateriei, int nrDeNoteAleMateriei)
        {
            for (int i = 0; i < nrDeNoteAleMateriei; i++)
            {
                noteProfil[nrMateriei, i].Hide();
                dateProfil[nrMateriei, i].Hide();
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            
            //int ba = 0;
            //ba = bd.selectid();
            //ba++;
            //Daca a introdus toate datele
            if (UserNameRegister.Text != "" &&
                Parola1Register.Text != "" &&
                Parola2Register.Text != "" &&
                NumeRegister.Text != "" &&
                QuestionRegister.Text != "" &&
                AnswerRegister.Text != "" &&
                PrenumeRegister.Text != "")
            {
                //verific daca id-ul are spatii
                bool existaSpatii = false;
                for (int i = 0; i < UserNameRegister.Text.Length; i++)
                {
                    if (UserNameRegister.Text[i] == ' ')
                    {
                        existaSpatii = true;
                    }
                }

                for (int i = 0; i < Parola1Register.Text.Length; i++)
                {
                    if (Parola1Register.Text[i] == ' ')
                    {
                        existaSpatii = true;
                    }
                }

                if (existaSpatii == false)
                {
                    //daca parola este corecta in ambele cazuri
                    if (Parola1Register.Text == Parola2Register.Text && Parola1Register.Text.Length > 5)
                    {
                        //daca nu exista deja utilizatorul
                        if (bd.selectU(UserNameRegister.Text) == 0)// && bd.selectNumePrenume(PrenumeRegister.Text, NumeRegister.Text) == 0)
                        {
                            //in Table2 se afla niste coduri date de catre admin, cu care profesorii pot crea conturi
                            int nr = 0;
                            /*string h = bd.selectIdProf();
                            string[] iduri = h.Split(';');
                            for (int l = 0; l < h.Length; l++)
                            {
                                if (h[l] == ';')
                                {
                                    nr++;
                                }
                            }*/
                            bool lalala = false;
                            //for (int o = 0; o < nr; o++)
                            //{
                            //if (ProfesorRegister.Text == iduri[o])
                            if (bd.selectEncryptedIdProf(ProfesorRegister.Text) == 1)
                            {
                                bd.insertCryptedPassword(OrasRegister.Text, NumeRegister.Text, PrenumeRegister.Text,
                                    QuestionRegister.Text, AnswerRegister.Text, UserNameRegister.Text, Parola1Register.Text, "Da");
                                //bd.insereazaProf(ba, Nume.Text, Prenume.Text, UserName.Text, Parola1.Text, Oras.Text, Question.Text, Answer.Text);
                                MessageBox.Show("Felicitări! Ai fost adăugat ca profesor!");
                                this.Size = new System.Drawing.Size(718, 350);  changePanels(PanelRegister, PanelForm1);
                                this.Text = "Ease Class";
                                GolitiButton.PerformClick();
                                AutentificareButton.Focus();
                                lalala = true;
                                bd.stergeIdProf(ProfesorRegister.Text);
                                bd.nrConturi++;
                                labelRegisterStatus.Hide();
                                RegisterButton.BackColor = Color.LightSteelBlue;
                                //break;
                            }
                            //}
                            if (lalala == false)
                            {
                                bd.insertCryptedPassword(OrasRegister.Text, NumeRegister.Text, PrenumeRegister.Text,
                                    QuestionRegister.Text, AnswerRegister.Text, UserNameRegister.Text, Parola1Register.Text, "Nu");
                                //bd.insereaza(ba, Nume.Text, Prenume.Text, UserName.Text, Parola1.Text, Oras.Text, Question.Text, Answer.Text);
                                MessageBox.Show("Felicitări! Ai fost adăugat ca elev!");
                                this.Size = new System.Drawing.Size(718, 350);  changePanels(PanelRegister, PanelForm1);
                                this.Text = "Ease Class";
                                GolitiButton.PerformClick();
                                AutentificareButton.Focus();
                                bd.nrConturi++;
                                labelRegisterStatus.Hide();
                                RegisterButton.BackColor = Color.LightSteelBlue;
                            }
                            lalala = false;
                        }
                        else
                            //if (bd.selectU(UserNameRegister.Text) == 0)
                            {
                                //MessageBox.Show("Nume de utilizator deja existent");
                                UserNameRegister.Clear();
                                RegisterButton.BackColor = Color.Tomato;
                                labelRegisterStatus.Show();
                                labelRegisterStatus.Text = "Nume de utilizator deja existent";
                            }
                            /*else
                                if (bd.selectNumePrenume(PrenumeRegister.Text, NumeRegister.Text) == 0)
                                {
                                    MessageBox.Show("Acest elev exista deja!");
                                    NumeRegister.Clear();
                                    PrenumeRegister.Clear();
                                }*/
                    }
                    else
                        if (Parola1Register.Text != Parola2Register.Text)
                        {
                            //MessageBox.Show("Parola greșită" + '\n' + "Reintroduceți parola");
                            Parola1Register.Clear();
                            Parola2Register.Clear();
                            RegisterButton.BackColor = Color.Tomato;
                            labelRegisterStatus.Show();
                            labelRegisterStatus.Text = "Parola greșită! Reintroduceți parola!";
                        }
                        else
                            if (Parola1Register.Text.Length <= 5)
                            {
                                //MessageBox.Show("Parola este prea scurta" + '\n' + "Aceasta trebuie sa contina cel putin 6 caractere");
                                Parola1Register.Clear();
                                Parola2Register.Clear();
                                RegisterButton.BackColor = Color.Tomato;
                                labelRegisterStatus.Show();
                                labelRegisterStatus.Text = "Parola trebuie sa contina minim 6 caractere";
                            }
                }
                else
                {
                    //MessageBox.Show("Id-ul si parola nu trebuie să conțină spații!");
                    labelRegisterStatus.Show();
                    labelRegisterStatus.Text = "Id-ul si parola nu trebuie să conțină spații!";
                    RegisterButton.BackColor = Color.Tomato;
                }
            }
            else
            {
                //MessageBox.Show("Nu ai introdus toate datele necesare!");
                labelRegisterStatus.Show();
                labelRegisterStatus.Text = "Nu ai introdus toate datele necesare!";
                RegisterButton.BackColor = Color.Tomato;
            }
        }

        private void GolitiButton_Click(object sender, EventArgs e)
        {
            labelRegisterStatus.Hide();
            UserNameRegister.Clear();
            Parola1Register.Clear();
            Parola2Register.Clear();
            NumeRegister.Clear();
            PrenumeRegister.Clear();
            OrasRegister.Clear();
            QuestionRegister.Clear();
            ProfesorRegister.Clear();
        }

        private void GoBackRegisterButton_Click(object sender, EventArgs e)
        {
            labelRegisterStatus.Hide();
            RegisterButton.BackColor = Color.LightSteelBlue;

            this.Size = new System.Drawing.Size(718, 350);  changePanels(PanelRegister, PanelForm1);
            this.Text = "Ease Class";
            GolitiButton.PerformClick();
            AutentificareButton.Focus();
        }

        private void GoBackProfilProfesor_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(718, 350); changePanels(PanelProfilProfesor, PanelForm1);
            this.Text = "Ease Class";
            AutentificareButton.Focus();
        }

        private void incarcaProfilProfesor()
        {
            

            //string s = bd.selectName();
            string[] f = bd.selectProfil(linkLabel2.Text);



            this.Text = "Profil" + " (" + linkLabel2.Text + ")";

            PrenumeProfilProfesor.Text = f[0].TrimEnd(' ');

            NumeProfilProfesor.Text = f[1].TrimEnd(' ');

            OrasProfilProfesor.Text = f[2].TrimEnd(' ');

            IntrebareProfilProfesor.Text = f[3].TrimEnd(' ');

            RaspunsProfilProfesor.Text = f[4].TrimEnd(' ');
            
            /*
            PrenumeProfilProfesor.Text = f.Substring(0, f.IndexOf(' '));
            f = f.Remove(0, f.IndexOf(' ') + 1);

            NumeProfilProfesor.Text = f.Substring(0, f.IndexOf(' '));
            f = f.Remove(0, f.IndexOf(' ') + 1);

            OrasProfilProfesor.Text = f.Substring(0, f.IndexOf(' '));
            f = f.Remove(0, f.IndexOf(' ') + 1);

            IntrebareProfilProfesor.Text = f.Substring(0, f.IndexOf(' '));
            f = f.Remove(0, f.IndexOf(' ') + 1);

            RaspunsProfilProfesor.Text = f.Substring(0, f.IndexOf(' '));
            */
        }

        private void NumeProfilProfesor_TextChanged(object sender, EventArgs e)
        {

            InfoProfilProfesorPicture.Image = global::Proiect.Properties.Resources.bullet_info;
        }

        private void SaveChangesProfilProfesor_Click(object sender, EventArgs e)
        {
            try
            {
                //string s = bd.selectName();
                bd.insereazaProfil(linkLabel2.Text, PrenumeProfilProfesor.Text, NumeProfilProfesor.Text, OrasProfilProfesor.Text,
                    IntrebareProfilProfesor.Text, RaspunsProfilProfesor.Text);
                InfoProfilProfesorPicture.Image = global::Proiect.Properties.Resources.bullet_accept;
                SaveChangesProfilProfesor.BackColor = Color.YellowGreen;
            }
            catch
            {
                InfoProfilProfesorPicture.Image = global::Proiect.Properties.Resources.bullet_error;
                SaveChangesProfilProfesor.BackColor = Color.Gold;
                MessageBox.Show("A intervenit o eroare!");
            }
        }

        private void AdaugaProfesorCodeButton_Click(object sender, EventArgs e)
        {
            CodAdaugaProfesor.Text = "";
            string s = "qwertyuiopasdfghjklzxcvbnm1234567890";
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                CodAdaugaProfesor.Text += s[r.Next(35)];
            }
            
            bd.insereazaIdProf(CodAdaugaProfesor.Text);
        }

        private void ChangePasswordProfilProfesor_Click(object sender, EventArgs e)
        {
            ChangePasswordButton.BackColor = Color.LightSteelBlue;
            this.Size = new System.Drawing.Size(718, 350); changePanels(PanelProfilProfesor, PanelChangePassword);
            this.Text = "Schimba parola";
        }




        //Here starts ListaLectiiSiTeste ***************************************************************

        Button[] testeleListaLectiiSiTeste = new Button[140];
        int nrTesteListaLectiiSiTeste = 0;

        Button[] lectiileListaLectiiSiTeste = new Button[140];
        int nrLectiiListaLectiiSiTeste = 0;
        int LastnrLectiiListaLectiiSiTeste = 0;
        int LastnrTesteListaLectiiSiTeste = 0;

        Label[] detaliiTestListaLectiiSiTeste = new Label[140];
        Label[] noteTestListaLectiiSiTeste = new Label[140];
        Label[] detaliiLectieListaLectiiSiTeste = new Label[140];

        bool[] areNota = new bool[140];

        int x1 = 231, y1 = 20;
        int x2 = 721, y2 = 20;

        
        string mut = "nimic";//retine care panel mut cand fac swype

        string ExistaLectii = "da", ExistaTeste = "da";

        string numeleMateriei = "";


        private void GoBackListaLectiiSiTeste_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(718, 350); changePanels(PanelListaLectiiSiTeste, PanelForm1);
            this.Text = "Ease Class";
            AutentificareButton.Focus();
            for (int i = 0; i < nrTesteListaLectiiSiTeste - 1; i++)
            {
                if (areNota[i] == true)
                {
                    noteTestListaLectiiSiTeste[i].Hide();
                    areNota[i] = false;
                }
                testeleListaLectiiSiTeste[i].Hide();
                detaliiTestListaLectiiSiTeste[i].Hide();
            }
            
            for (int i = 0; i < nrLectiiListaLectiiSiTeste - 1; i++)
            {
                lectiileListaLectiiSiTeste[i].Hide();
                detaliiLectieListaLectiiSiTeste[i].Hide();
            }
            nrTesteListaLectiiSiTeste = 0;
            nrLectiiListaLectiiSiTeste = 0;

            richTextBox1ListaLectiiSiTeste.Clear();
            richTextBox2ListaLectiiSiTeste.Clear();
            richTextBox3ListaLectiiSiTeste.Clear();
            richTextBox4ListaLectiiSiTeste.Clear();
            richTextBox5ListaLectiiSiTeste.Clear();
            richTextBox6ListaLectiiSiTeste.Clear();
            label1ListaLectiiSiTeste.Text = "";
        }

        private void incarcaListaLectiiSiTeste(string materie)
        {
            ExistaLectii = "da";
            ExistaTeste = "da";
            numeleMateriei = materie;
            this.Text = "Testele si lectia de la " + materie;
            //ascund butoanele de adaugare de teste si lectii in caz ca utilizatorul nu este profesor
            if (linkLabel1.Text != "Profesor")
            {
                AdaugaLectieListaLectiiSiTesteButton.Hide();
                AdaugaTesteListaLectiiSiTesteButton.Hide();
            }
            else
            {
                AdaugaLectieListaLectiiSiTesteButton.Show();
                AdaugaTesteListaLectiiSiTesteButton.Show();
            }



            //incarc testele ********************

            try
            {

                DirectoryInfo dir1 = new DirectoryInfo(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + materie + "\\");

                string[] teste = Directory.GetDirectories(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + materie + "\\");
                int directoryCount = Directory.GetDirectories(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + materie + "\\").Length;




                //string[] teste = richTextBox1.Text.Split('\n');
                nrTesteListaLectiiSiTeste = teste.Length + 1;

                LastnrTesteListaLectiiSiTeste = nrTesteListaLectiiSiTeste;

                for (int i = 0; i < nrTesteListaLectiiSiTeste - 1; i++)
                {
                    areNota[i] = new bool();
                    areNota[i] = false;
                    //vad care este numele testului
                    string numeTest = new DirectoryInfo(teste[i]).Name;

                    testeleListaLectiiSiTeste[i] = new Button();

                    testeleListaLectiiSiTeste[i].BackColor = System.Drawing.Color.YellowGreen;
                    testeleListaLectiiSiTeste[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    testeleListaLectiiSiTeste[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                
                    testeleListaLectiiSiTeste[i].Text = numeTest;
                    testeleListaLectiiSiTeste[i].AutoSize = true;
                    testeleListaLectiiSiTeste[i].AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                    testeleListaLectiiSiTeste[i].Size = new System.Drawing.Size(61, 23);

                    //creez un label in care trec detaliile testului
                    detaliiTestListaLectiiSiTeste[i] = new Label();


                    //daca exista detalii despre test le incarc
                    if (File.Exists(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + materie + "\\" + numeTest + "\\detalii"))
                    {
                        DetaliileListaLectiiSiTeste.Text = "";
                        DetaliileListaLectiiSiTeste.LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + materie + "\\" + numeTest + "\\detalii", RichTextBoxStreamType.PlainText);
                        detaliiTestListaLectiiSiTeste[i].Text = DetaliileListaLectiiSiTeste.Text;

                        if (DetaliileListaLectiiSiTeste.Text == "")
                        {
                            detaliiTestListaLectiiSiTeste[i].Text = "Nu exista detalii despre acest test!";
                        }
                    }
                    else
                    {
                        detaliiTestListaLectiiSiTeste[i].Text = "Nu exista detalii despre acest test!";
                    }
                    detaliiTestListaLectiiSiTeste[i].AutoSize = true;
                    detaliiTestListaLectiiSiTeste[i].Size = new System.Drawing.Size(35, 13);

                    if (i == 0)
                    {
                        testeleListaLectiiSiTeste[i].Location = new System.Drawing.Point(button1ListaLectiiSiTeste.Location.X + 5,
                                                                        button1ListaLectiiSiTeste.Location.Y);
                    }
                    else
                    {
                        testeleListaLectiiSiTeste[i].Location = new System.Drawing.Point(button1ListaLectiiSiTeste.Location.X + 5,
                                                                        testeleListaLectiiSiTeste[i - 1].Location.Y + 35);
                    }

                    testeleListaLectiiSiTeste[i].TabIndex = 1;
                    testeleListaLectiiSiTeste[i].UseVisualStyleBackColor = true;

                    testeleListaLectiiSiTeste[i].Click += new System.EventHandler(this.button1_ClickListaLectiiSiTeste);
                    panel1ListaLectiiSiTeste.Controls.Add(testeleListaLectiiSiTeste[i]);

                    detaliiTestListaLectiiSiTeste[i].Location = new Point(testeleListaLectiiSiTeste[i].Location.X + testeleListaLectiiSiTeste[i].Width + 10,
                                                        testeleListaLectiiSiTeste[i].Location.Y + 5);

                    panel1ListaLectiiSiTeste.Controls.Add(detaliiTestListaLectiiSiTeste[i]);
                }

                selectNoteListaLectiiSiTeste();
            }
            catch
            {
                ExistaTeste = "nu";
            }


            //incarc lectiile *********************

            try
            {

                DirectoryInfo dir2 = new DirectoryInfo(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + materie + "\\");

                string[] lectii = Directory.GetDirectories(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + materie + "\\");
                //int directoryCount = Directory.GetDirectories(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + materie + "\\").Length;


                //string[] lectii = richTextBox1.Text.Split('\n');
                nrLectiiListaLectiiSiTeste = lectii.Length + 1;

                //il salvez ca sa stiu cate ascund cand dau refresh
                LastnrLectiiListaLectiiSiTeste = nrLectiiListaLectiiSiTeste;
                
                for (int i = 0; i < nrLectiiListaLectiiSiTeste - 1; i++)
                {
                    //vad care este numele testului
                    string numeLectie = new DirectoryInfo(lectii[i]).Name;

                    lectiileListaLectiiSiTeste[i] = new Button();

                    lectiileListaLectiiSiTeste[i].BackColor = System.Drawing.Color.YellowGreen;
                    lectiileListaLectiiSiTeste[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    lectiileListaLectiiSiTeste[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                
                    lectiileListaLectiiSiTeste[i].Text = numeLectie;
                    lectiileListaLectiiSiTeste[i].AutoSize = true;
                    lectiileListaLectiiSiTeste[i].AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                    lectiileListaLectiiSiTeste[i].Size = new System.Drawing.Size(61, 23);

                    //creez un label in care trec detaliile testului
                    detaliiLectieListaLectiiSiTeste[i] = new Label();
    
                    //daca exista detalii despre test le incarc
                    if (File.Exists(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + materie + "\\" + numeLectie + "\\detalii"))
                    {
                        DetaliileListaLectiiSiTeste.Text = "";
                        DetaliileListaLectiiSiTeste.LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + materie + "\\" + numeLectie + "\\detalii", RichTextBoxStreamType.PlainText);
                        detaliiLectieListaLectiiSiTeste[i].Text = DetaliileListaLectiiSiTeste.Text;
                        if (DetaliileListaLectiiSiTeste.Text == "")
                        {
                            detaliiLectieListaLectiiSiTeste[i].Text = "Nu exista detalii despre aceasta lectie!";
                        }
                    }
                    else
                    {
                        detaliiLectieListaLectiiSiTeste[i].Text = "Nu exista detalii despre aceasta lectie!";
                    }
                    detaliiLectieListaLectiiSiTeste[i].AutoSize = true;
                    detaliiLectieListaLectiiSiTeste[i].Size = new System.Drawing.Size(35, 13);

                    if (i == 0)
                    {
                        lectiileListaLectiiSiTeste[i].Location = new System.Drawing.Point(button1ListaLectiiSiTeste.Location.X + 5,
                                                                        button1ListaLectiiSiTeste.Location.Y);
                    }
                    else
                    {
                        lectiileListaLectiiSiTeste[i].Location = new System.Drawing.Point(button1ListaLectiiSiTeste.Location.X + 5,
                                                                        lectiileListaLectiiSiTeste[i - 1].Location.Y + 35);
                    }

                    lectiileListaLectiiSiTeste[i].TabIndex = 1;
                    lectiileListaLectiiSiTeste[i].UseVisualStyleBackColor = true;

                    lectiileListaLectiiSiTeste[i].Click += new System.EventHandler(this.button2_ClickListaLectiiSiTeste);
                    panel2ListaLectiiSiTeste.Controls.Add(lectiileListaLectiiSiTeste[i]);

                    detaliiLectieListaLectiiSiTeste[i].Location = new Point(lectiileListaLectiiSiTeste[i].Location.X + lectiileListaLectiiSiTeste[i].Width + 10,
                                                        lectiileListaLectiiSiTeste[i].Location.Y + 5);

                    panel2ListaLectiiSiTeste.Controls.Add(detaliiLectieListaLectiiSiTeste[i]);
                }

            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                ExistaLectii = "nu";
            }
            panel3ListaLectiiSiTeste.BringToFront();
        }

        public void selectNoteListaLectiiSiTeste()
        {
            if (linkLabel1.Text == "Elev")
            {
                

                //noteMaterie va reprezenta ce se afla in baza de date:  numele testului: nota/punctajul total;
                string[] noteMaterie = bd.selectNoteMaterie(linkLabel2.Text, numeleMateriei).Split(';');
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
                for (int i = 0; i < nrTesteListaLectiiSiTeste - 1; i++)
                {
                    for (int j = 0; j < noteMaterie.Length - 1; j++)
                    {
                        if (testeleListaLectiiSiTeste[i].Text == materie[j])
                        {
                            areNota[i] = true;
                            //creez un label in care scriu nota, si il pozitionez in dreptul testului
                            noteTestListaLectiiSiTeste[i] = new Label();
                            noteTestListaLectiiSiTeste[i].AutoSize = true;
                            noteTestListaLectiiSiTeste[i].BackColor = Color.Transparent;
                            noteTestListaLectiiSiTeste[i].Location = new System.Drawing.Point(testeleListaLectiiSiTeste[i].Location.X - 28,
                                testeleListaLectiiSiTeste[i].Location.Y + 5);
                            noteTestListaLectiiSiTeste[i].Size = new System.Drawing.Size(35, 13);
                            noteTestListaLectiiSiTeste[i].Text = note[j];
                            panel1ListaLectiiSiTeste.Controls.Add(noteTestListaLectiiSiTeste[i]);
                            break;
                        }
                    }
                }
            }
        }

        private void button1_ClickListaLectiiSiTeste(object sender, EventArgs e)
        {
            string ss = sender.ToString();
            ss = ss.Substring(ss.LastIndexOf("Text: ") + 6, ss.Length - ss.LastIndexOf("Text: ") - 6);
            for (int i = 0; i < nrTesteListaLectiiSiTeste - 1; i++)
            {
                if (ss==testeleListaLectiiSiTeste[i].Text)
                {

                    //daca deschide un test in fereastra principala si nu a mai deschis in alta
                    //fereastra, atunci il las sa deschida testul
                    if ((ModifierKeys != Keys.Control && ModifierKeys != Keys.MButton)
                    && Deschidere.Default.aDeschisUnTest == false)
                    {
                        Deschidere.Default.aDeschisUnTest = true;
                        if (linkLabel1.Text == "Profesor")
                        {
                            incarcaTestProfesor(testeleListaLectiiSiTeste[i].Text);
                            this.Size = new System.Drawing.Size(718, 350); changePanels(PanelTestProfesor, PanelListaLectiiSiTeste);
                            this.Text = "Testul " + testeleListaLectiiSiTeste[i].Text + " la " + numeleMateriei;
                            SalveazaTestProfesor.Focus();
                            //NewProfesorTest prof = new NewProfesorTest(testeleListaLectiiSiTeste[i].Text, numeleMateriei);
                            //prof.Show();
                        }
                        else
                            if (linkLabel1.Text == "Elev")
                            {
                                //daca nu are nota, o sa dea testul
                                if (areNota[i] == false)
                                {
                                    incarcaTestulTestElev(testeleListaLectiiSiTeste[i].Text, numeleMateriei);
                                    this.Size = new System.Drawing.Size(718, 350);  changePanels(PanelListaLectiiSiTeste, PanelTestElev);
                                    this.Text = "Testul " + testeleListaLectiiSiTeste[i].Text + " la " + numeleMateriei;
                                    FormaRaspunsuluiTestElevButton.Focus();
                                    //NewTest test = new NewTest(testeleListaLectiiSiTeste[i].Text, numeleMateriei, linkLabel2.Text);
                                    //test.Show();
                                }
                                else
                                //daca are nota, decat o sa vizualizeze testul
                                {
                                    incarcaVizualizeazaTest(testeleListaLectiiSiTeste[i].Text);
                                    PanelVizualizeazaTest.Focus();
                                    this.Size = new System.Drawing.Size(718, 350); changePanels(PanelListaLectiiSiTeste, PanelVizualizeazaTest);
                                    this.Text = "Testul " + testeleListaLectiiSiTeste[i].Text + " la " + numeleMateriei;
                                    //MessageBox.Show("Are nota si trebuie sa ii pun sa afiseze o vizualizare");
                                    //NewVizualizeazaTest test = new NewVizualizeazaTest(testeleListaLectiiSiTeste[i].Text,
                                        //numeleMateriei, "Elev");
                                    //test.Show();
                                }
                            }
                            else
                            {
                                incarcaVizualizeazaTest(testeleListaLectiiSiTeste[i].Text);
                                PanelVizualizeazaTest.Focus();
                                this.Size = new System.Drawing.Size(718, 350); changePanels(PanelListaLectiiSiTeste, PanelVizualizeazaTest);
                                this.Text = "Testul " + testeleListaLectiiSiTeste[i].Text + " la " + numeleMateriei;
                                //NewVizualizeazaTest test = new NewVizualizeazaTest(testeleListaLectiiSiTeste[i].Text,
                                    //numeleMateriei, "vizitator");
                                //test.Show();
                            }
                    }
                    else
                        //daca tine apasat pe control sau apasa pe middle button de la mouse va 
                        //deschide pagina intr-o fereastra noua, si ii dau voie sa deschida un singur test odata
                        if ((ModifierKeys == Keys.Control || ModifierKeys == Keys.MButton)
                                    && Deschidere.Default.aDeschisUnTest == false)
                        {
                            Deschidere.Default.aDeschisUnTest = true;
                            if (linkLabel1.Text == "Profesor")
                            {
                                NewProfesorTest prof = new NewProfesorTest(testeleListaLectiiSiTeste[i].Text, numeleMateriei);
                                prof.Show();
                            }
                            else
                                if (linkLabel1.Text == "Elev")
                                {
                                    //daca nu are nota, o sa dea testul
                                    if (areNota[i] == false)
                                    {
                                        NewTest test = new NewTest(testeleListaLectiiSiTeste[i].Text, numeleMateriei, linkLabel2.Text);
                                        test.Show();
                                    }
                                    else
                                    //daca are nota, decat o sa vizualizeze testul
                                    {
                                        NewVizualizeazaTest test = new NewVizualizeazaTest(testeleListaLectiiSiTeste[i].Text,
                                            numeleMateriei, "Elev");
                                        test.Show();
                                    }
                                }
                                else
                                {
                                    NewVizualizeazaTest test = new NewVizualizeazaTest(testeleListaLectiiSiTeste[i].Text,
                                        numeleMateriei, "vizitator");
                                    test.Show();
                                }
                        }
                        else
                            //nu ii dau voie sa deschida in mai mult de o fereastra un test
                            if ((ModifierKeys == Keys.Control || ModifierKeys == Keys.MButton)
                                    && Deschidere.Default.aDeschisUnTest == true)
                            {
                                MessageBox.Show("Nu poti accesa decat 1 test o data!");
                            }
                            else
                                //nu ii dau voie sa deschida in fereastra principala un test, daca deja e deschis in
                                //fereastra secundara
                                if ((ModifierKeys != Keys.Control && ModifierKeys != Keys.MButton)
                                    && Deschidere.Default.aDeschisUnTest == true)
                                {
                                    MessageBox.Show("Nu poti accesa decat 1 test o data!");
                                }
                }
            }
        }

        private void button2_ClickListaLectiiSiTeste(object sender, EventArgs e)
        {
            string ss = sender.ToString();
            ss = ss.Substring(ss.LastIndexOf("Text: ") + 6, ss.Length - ss.LastIndexOf("Text: ") - 6);
            for (int i = 0; i < nrLectiiListaLectiiSiTeste - 1; i++)
            {
                if (ss==lectiileListaLectiiSiTeste[i].Text)
                {
                    //daca tine apasat pe control sau a apasat pe middle button de la mouse
                    if (ModifierKeys == Keys.Control || ModifierKeys == Keys.MButton)
                    {
                        NewLectie n = new NewLectie(lectiileListaLectiiSiTeste[i].Text, linkLabel1.Text,
                            numeleMateriei, linkLabel2.Text);
                        n.Show();
                    }
                    else
                    {
                        incarcaVeziLectia(lectiileListaLectiiSiTeste[i].Text);
                        changePanels(PanelListaLectiiSiTeste, PanelVeziLectie);
                        this.Text = "Lectia " + lectiileListaLectiiSiTeste[i].Text + " la " + numeleMateriei;
                        GoBackVeziLectie.Focus();
                        this.Width = 680;
                        this.Height = 500;
                        PanelVeziLectie.Width = 670;
                        PanelVeziLectie.Height = 490;
                    }
                }
            }
        }

        private void Teste_ClickListaLectiiSiTeste(object sender, EventArgs e)
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

        private void Lectii_ClickListaLectiiSiTeste(object sender, EventArgs e)
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

        private void AdaugaTeste_ClickListaLectiiSiTeste(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Control || ModifierKeys == Keys.MButton)
            {
                NewAdaugaTest n = new NewAdaugaTest(numeleMateriei);
                n.Show();
            }
            else
                if (ModifierKeys != Keys.Control && ModifierKeys != Keys.MButton)
                {
                    incarcaAdaugaTest();
                    this.Size = new System.Drawing.Size(718, 350); changePanels(PanelListaLectiiSiTeste, PanelAdaugaTest);
                    this.Text = "Adauga un test la " + numeleMateriei;
                    textBox1AdaugaTest.Focus();
                }
        }

        private void AdaugaLectie_ClickListaLectiiSiTeste(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Control || ModifierKeys == Keys.MButton)
            {
                NewAdaugaLectie n = new NewAdaugaLectie(numeleMateriei);
                n.Show();
            }
            else
                if (ModifierKeys != Keys.Control && ModifierKeys != Keys.MButton)
                {
                    incarcaAdaugaLectie();
                    changePanels(PanelListaLectiiSiTeste, PanelAdaugaLectie);
                    this.Text = "Adauga o lectie la " + numeleMateriei;
                    NumeLectieAdaugaLectie.Focus();
                    this.Width = 680;
                    this.Height = 500;
                    PanelAdaugaLectie.Width = 670;
                    PanelAdaugaLectie.Height = 490;
                }
        }

        private void Refresh_ClickListaLectiiSiTeste(object sender, EventArgs e)
        {
            //Deschidere.Default.aDeschisUnTest = false;
            //Deschidere.Default.Save();
            //incarc testele ********************
            //richTextBox1.LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\", RichTextBoxStreamType.PlainText);
            ExistaLectii = "da";
            ExistaTeste = "da";

            try
            {
                for (int i = 0; i < LastnrLectiiListaLectiiSiTeste - 1; i++)
                {
                    lectiileListaLectiiSiTeste[i].Hide();
                    detaliiLectieListaLectiiSiTeste[i].Hide();
                }
                for (int i = 0; i < LastnrTesteListaLectiiSiTeste - 1; i++)
                {
                    if (areNota[i] == true)
                    {
                        noteTestListaLectiiSiTeste[i].Hide();
                        areNota[i] = false;
                    }
                    testeleListaLectiiSiTeste[i].Hide();
                    detaliiTestListaLectiiSiTeste[i].Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            try
            {
                DirectoryInfo dir1 = new DirectoryInfo(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\");

                string[] teste = Directory.GetDirectories(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\");
                int directoryCount = Directory.GetDirectories(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\").Length;




                //string[] teste = richTextBox1.Text.Split('\n');
                nrTesteListaLectiiSiTeste = teste.Length + 1;
                //MessageBox.Show((teste.Length - 1).ToString());
                for (int i = 0; i < nrTesteListaLectiiSiTeste - 1; i++)
                {
                    //vad care este numele testului
                    string numeTest = new DirectoryInfo(teste[i]).Name;

                    testeleListaLectiiSiTeste[i] = new Button();

                    testeleListaLectiiSiTeste[i].BackColor = System.Drawing.Color.YellowGreen;
                    testeleListaLectiiSiTeste[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    testeleListaLectiiSiTeste[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                
                    testeleListaLectiiSiTeste[i].Text = numeTest;
                    testeleListaLectiiSiTeste[i].AutoSize = true;
                    testeleListaLectiiSiTeste[i].AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                    testeleListaLectiiSiTeste[i].Size = new System.Drawing.Size(61, 23);

                    //creez un label in care trec detaliile testului
                    detaliiTestListaLectiiSiTeste[i] = new Label();

                    //daca exista detalii despre test le incarc
                    if (File.Exists(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + numeTest + "\\detalii"))
                    {
                        DetaliileListaLectiiSiTeste.Text = "";
                        DetaliileListaLectiiSiTeste.LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + numeTest + "\\detalii", RichTextBoxStreamType.PlainText);
                        detaliiTestListaLectiiSiTeste[i].Text = DetaliileListaLectiiSiTeste.Text;
                        if (DetaliileListaLectiiSiTeste.Text == "")
                        {
                            detaliiTestListaLectiiSiTeste[i].Text = "Nu exista detalii despre acest test!";
                        }
                    }
                    else
                    {
                        detaliiTestListaLectiiSiTeste[i].Text = "Nu exista detalii despre acest test!";
                    }
                    detaliiTestListaLectiiSiTeste[i].AutoSize = true;
                    detaliiTestListaLectiiSiTeste[i].Size = new System.Drawing.Size(35, 13);

                    if (i == 0)
                    {
                        testeleListaLectiiSiTeste[i].Location = new System.Drawing.Point(button1ListaLectiiSiTeste.Location.X + 5,
                                                                        button1ListaLectiiSiTeste.Location.Y);
                    }
                    else
                    {
                        testeleListaLectiiSiTeste[i].Location = new System.Drawing.Point(button1ListaLectiiSiTeste.Location.X + 5,
                                                                        testeleListaLectiiSiTeste[i - 1].Location.Y + 35);
                    }

                    testeleListaLectiiSiTeste[i].TabIndex = 1;
                    testeleListaLectiiSiTeste[i].UseVisualStyleBackColor = true;

                    testeleListaLectiiSiTeste[i].Click += new System.EventHandler(this.button1_ClickListaLectiiSiTeste);
                    panel1ListaLectiiSiTeste.Controls.Add(testeleListaLectiiSiTeste[i]);

                    detaliiTestListaLectiiSiTeste[i].Location = new Point(testeleListaLectiiSiTeste[i].Location.X +
                        testeleListaLectiiSiTeste[i].Width + 10,
                                                        testeleListaLectiiSiTeste[i].Location.Y + 5);

                    panel1ListaLectiiSiTeste.Controls.Add(detaliiTestListaLectiiSiTeste[i]);
                    selectNoteListaLectiiSiTeste();
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
                nrLectiiListaLectiiSiTeste = lectii.Length + 1;

                
                for (int i = 0; i < nrLectiiListaLectiiSiTeste - 1; i++)
                {
                    //vad care este numele testului
                    string numeLectie = new DirectoryInfo(lectii[i]).Name;

                    lectiileListaLectiiSiTeste[i] = new Button();

                    lectiileListaLectiiSiTeste[i].BackColor = System.Drawing.Color.YellowGreen;
                    lectiileListaLectiiSiTeste[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    lectiileListaLectiiSiTeste[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                
                    lectiileListaLectiiSiTeste[i].Text = numeLectie;
                    lectiileListaLectiiSiTeste[i].AutoSize = true;
                    lectiileListaLectiiSiTeste[i].AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                    lectiileListaLectiiSiTeste[i].Size = new System.Drawing.Size(61, 23);

                    //creez un label in care trec detaliile testului
                    detaliiLectieListaLectiiSiTeste[i] = new Label();

                    //daca exista detalii despre test le incarc
                    if (File.Exists(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + numeLectie + "\\detalii"))
                    {
                        DetaliileListaLectiiSiTeste.Text = "";
                        DetaliileListaLectiiSiTeste.LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + numeLectie + "\\detalii", RichTextBoxStreamType.PlainText);
                        detaliiLectieListaLectiiSiTeste[i].Text = DetaliileListaLectiiSiTeste.Text;
                        if (DetaliileListaLectiiSiTeste.Text == "")
                        {
                            detaliiLectieListaLectiiSiTeste[i].Text = "Nu exista detalii despre aceasta lectie!";
                        }
                    }
                    else
                    {
                        detaliiLectieListaLectiiSiTeste[i].Text = "Nu exista detalii despre aceasta lectie!";
                    }
                    detaliiLectieListaLectiiSiTeste[i].AutoSize = true;
                    detaliiLectieListaLectiiSiTeste[i].Size = new System.Drawing.Size(35, 13);

                    if (i == 0)
                    {
                        lectiileListaLectiiSiTeste[i].Location = new System.Drawing.Point(button1ListaLectiiSiTeste.Location.X + 5,
                                                                        button1ListaLectiiSiTeste.Location.Y);
                    }
                    else
                    {
                        lectiileListaLectiiSiTeste[i].Location = new System.Drawing.Point(button1ListaLectiiSiTeste.Location.X + 5,
                                                                        lectiileListaLectiiSiTeste[i - 1].Location.Y + 35);
                    }

                    lectiileListaLectiiSiTeste[i].TabIndex = 1;
                    lectiileListaLectiiSiTeste[i].UseVisualStyleBackColor = true;

                    lectiileListaLectiiSiTeste[i].Click += new System.EventHandler(this.button2_ClickListaLectiiSiTeste);
                    panel2ListaLectiiSiTeste.Controls.Add(lectiileListaLectiiSiTeste[i]);

                    detaliiLectieListaLectiiSiTeste[i].Location = new Point(lectiileListaLectiiSiTeste[i].Location.X + lectiileListaLectiiSiTeste[i].Width + 10,
                                                        lectiileListaLectiiSiTeste[i].Location.Y + 5);

                    panel2ListaLectiiSiTeste.Controls.Add(detaliiLectieListaLectiiSiTeste[i]);
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

        private void swype_TickListaLectiiSiTeste(object sender, EventArgs e)
        {
            //mut testele
            if (mut == "teste")
            {
                if (panel1ListaLectiiSiTeste.Location.X > x1)
                {
                    panel1ListaLectiiSiTeste.Location = new Point(panel1ListaLectiiSiTeste.Location.X - 1, panel1ListaLectiiSiTeste.Location.Y);
                }
                    //a ajuns in pozitia in de stop
                else
                {
                    mut = "nimic";
                    swypeListaLectiiSiTeste.Stop();
                }
            }
            else
                //mut lectiile
                if (mut == "lectii")
                {
                    if (panel2ListaLectiiSiTeste.Location.X > x1)
                    {
                        panel2ListaLectiiSiTeste.Location = new Point(panel2ListaLectiiSiTeste.Location.X - 1, panel2ListaLectiiSiTeste.Location.Y);
                    }
                    else
                        //a ajuns in pozitia de stop
                    {
                        mut = "nimic";
                        swypeListaLectiiSiTeste.Stop();
                    }
                }
                else
                    //mut labelul pe care scrie ca nu exista teste sau lectii
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



        //Here starts TestElev ******************************************************************

        string[] raspunsCompletTestElev = new string[40];//raspunsul corect complet cu tot cu note
        string[,] raspunsuriCorecteTestElev = new string[40, 40];//raspunsuri corecte
        string[] raspunsulMeuTestElev = new string[40];//raspunsul meu complet
        string[,] raspunsuriIntermediareTestElev = new string[40, 40];//raspunsurile mele

        int[,] noteTestElev = new int[40, 40];
        int[] nrNoteTestElev = new int[40];
        int[] nrRaspCorTestElev = new int[40];
        int[] nrRaspMeuTestElev = new int[40];


        int NrTotalTestElev = 3;//nr total de casute cu raspunsuri

        public RichTextBox[] enuntTestElev = new RichTextBox[40];
        public RichTextBox[] raspunsTestElev = new RichTextBox[40];//textBoxurile care apar pe ecran
        public RichTextBox[] raspunsCorectTestElev = new RichTextBox[40];//retine raspunsul corect corespunzator raspunsului
        public Label[] lbTestElev = new Label[40];
        public Label[] NrProblemaTestElev = new Label[40];
        public PictureBox[] imagineTestElev = new PictureBox[140];

        public string locatieTestElev;
        public string numeTestElev;

        public int SecundeTestElev;
        public int MinuteTestElev;
        public int hoursTestElev;
        int nrImaginiTestElev;
        
        public int kTestElev = -1;
        public int numarRTTestElev;

        int[] inaltimiCasuteTestElev = new int[40];


        private void GoBackTestElevButton_Click(object sender, EventArgs e)
        {
            IncepeButtonTestElev.Show();
            InfoAmTerminatTestElevPicture.Hide();
            LockPrintTestElevPicture.Hide();
            MinuteLabelTestElev.Hide();
            SecundeLabelTestElev.Hide();
            InfoAmTerminatTestElevPicture.Image = global::Proiect.Properties.Resources.bullet_info;
            LockPrintTestElevPicture.Image = global::Proiect.Properties.Resources.file_locked;
            
            if (AmTerminatButtonTestElev.Enabled == true && aApasatPeIncepe == true)
            {
                if (MessageBox.Show("Daca iesi, punctajul tau va fi stabilit in urma raspunsurilor date pana acum!" +
                    '\n' + "Esti sigur ca vrei sa renunti?", "ATENTIE!!!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    AmTerminatButtonTestElev.PerformClick();
                    ascundeTestulTestElev();
                    this.Size = new System.Drawing.Size(718, 350); changePanels(PanelListaLectiiSiTeste, PanelTestElev);
                    this.Text = "Lista lectii si teste";
                    Deschidere.Default.aDeschisUnTest = false;
                    Deschidere.Default.Save();
                }
            }
            else
                if (AmTerminatButtonTestElev.Enabled == false)
                {
                    AmTerminatButtonTestElev.PerformClick();
                    ascundeTestulTestElev();
                    //nu mai trebuie sa folosesc butonul "Am terminat" pentru ca in ascunde... fac timerul 0:0 si
                    //atunci se activeaza singur butonul
                    this.Text = "Lista lectii si teste";
                    this.Size = new System.Drawing.Size(718, 350);  changePanels(PanelListaLectiiSiTeste, PanelTestElev);
                    Deschidere.Default.aDeschisUnTest = false;
                    Deschidere.Default.Save();
                }
                else
                    if (aApasatPeIncepe == false)
                    {
                        this.Size = new System.Drawing.Size(718, 350); changePanels(PanelListaLectiiSiTeste, PanelTestElev);
                        this.Text = "Lista lectii si teste";
                        Deschidere.Default.aDeschisUnTest = false;
                        Deschidere.Default.Save();
                    }
            RefreshListaLectiiSiTeste.PerformClick();
            AmTerminatButtonTestElev.Hide();
            VeziRaspunsuriButtonTestElev.Hide();
        }

        private void ascundeTestulTestElev()
        {
            for (int i = 0; i < numarRTTestElev; i++)
            {
                enuntTestElev[i].Hide();
                lbTestElev[i].Hide();
                NrProblemaTestElev[i].Hide();
                raspunsCorectTestElev[i].Hide();
                raspunsTestElev[i].Hide();
            }

            for (int i = 0; i < nrImaginiTestElev; i++)
            {
                imagineTestElev[i].Hide();
            }
            numarRTTestElev = 0;
            nrImaginiTestElev = 0;
            kTestElev = -1;
            //SecundeTestElev = 0;
            //MinuteTestElev = 0;
            //hoursTestElev = 0;
        }

        private void incarcaTestulTestElev(string location, string Materie)
        {
            aApasatPeIncepe = false;
            MinuteLabelTestElev.Visible = false;
            SecundeLabelTestElev.Visible = false;
            PunctajLabelTestElev.Visible = false;
            IncepeButtonTestElev.Visible = true;

            locatieTestElev = location;
            numeleMateriei = Materie;

            this.Text = "Testul " + locatieTestElev + " (" + numeleMateriei + ")";

            nrImaginiTestElev = 0;
            if (Directory.Exists(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestElev + "\\Imagini"))
            {
                nrImaginiTestElev = Directory.GetFiles(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestElev + "\\Imagini\\").Length - 1;
            }

            numarRTTestElev = Directory.GetFiles(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestElev + "\\").Length / 2 - 1;

            richTextBox1TestElev.LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestElev + "\\setari", RichTextBoxStreamType.PlainText);

            string[] elementeSetari = richTextBox1TestElev.Text.Split('\n');

            string minute = elementeSetari[0];

            for (int i = 1; i < numarRTTestElev + 1; i++)
            {
                inaltimiCasuteTestElev[i - 1] = Convert.ToInt32(elementeSetari[i]);
            }
            
            //AmTerminatButtonTestElev.Location = new Point(0, 0);
            AmTerminatButtonTestElev.Enabled = true;
            VeziRaspunsuriButtonTestElev.Enabled = false;

            MinuteTestElev = Convert.ToInt32(minute);
            SecundeTestElev = 0;

            MinuteLabelTestElev.Text = (MinuteTestElev - 1).ToString();
            SecundeLabelTestElev.Text = "60";

            MinuteLabelTestElev.Location = new Point(500, 14);
            SecundeLabelTestElev.Location = new Point(550, 14);

        }

        private void button1_ClickTestElev(object sender, EventArgs e)
        {
            timerSecunde.Stop();
            timerMinute.Stop();
            CronometruTestElev.Stop();


            SecundeLabelTestElev.Location = new System.Drawing.Point(550, 14);
            MinuteLabelTestElev.Location = new System.Drawing.Point(500, 14); 
                
                
            VeziRaspunsuriButtonTestElev.Enabled = true;
            VeziRaspunsuriButtonTestElev.BackColor = Color.YellowGreen;

            AmTerminatButtonTestElev.Enabled = false;
            AmTerminatButtonTestElev.BackColor = Color.Gold;

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
            for (int i = 0; i < NrTotalTestElev; i++)
            {
                string s = raspunsCompletTestElev[i];
                String[] rasp = s.Split(';');

                for (int w = 0; w < rasp.Length; w++)
                {
                    raspunsuriCorecteTestElev[i, w] = rasp[w];
                }

                nrRaspCorTestElev[i] = rasp.Length;
            }


            //aflu raspunsurile mele
            for (int i = 0; i < NrTotalTestElev; i++)
            {
                string s = raspunsulMeuTestElev[i];
                String[] rasp = s.Split(';');

                for (int w = 0; w < rasp.Length - 1; w++)
                {
                    raspunsuriIntermediareTestElev[i, w] = rasp[w];
                }
                nrRaspMeuTestElev[i] = rasp.Length - 1;
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

            MessageBox.Show("Ai obținut: " + nota + " din " + notaT + " puncte");

            DateTime dt = DateTime.Now;

            PunctajLabelTestElev.Show();
            PunctajLabelTestElev.Text = "Ai obținut: " + nota.ToString() + " din " + notaT.ToString() + " puncte";

            //string g = bd.selectName();
            string q = locatieTestElev + ": " + nota.ToString() + "/" + notaT.ToString() + ';';
            // " la " + dt.ToShortDateString() + ' ' + dt.ToShortTimeString() + ';';
            
            bd.insereazaNotaMaterie(linkLabel2.Text, numeleMateriei, q);
            bd.inserezaDataMaterie(linkLabel2.Text, numeleMateriei);

        }

        DateTime dtTestElev = new DateTime();

        bool aApasatPeIncepe = false;

        private void button3_ClickTestElev(object sender, EventArgs e)
        {
            SecundeLabelTestElev.Location = new Point(MinuteLabelTestElev.Location.X + MinuteLabelTestElev.Width, SecundeLabelTestElev.Location.Y);
            aApasatPeIncepe = true;
            InfoAmTerminatTestElevPicture.Show();
            LockPrintTestElevPicture.Show();

            MinuteLabelTestElev.Show();
            SecundeLabelTestElev.Show();
            SecundeLabelTestElev.BringToFront();
            dtTestElev = DateTime.Now;
            CronometruTestElev.Start();
            IncepeButtonTestElev.Hide();

            AmTerminatButtonTestElev.BackColor = Color.YellowGreen;
            VeziRaspunsuriButtonTestElev.BackColor = Color.Gold;

            AmTerminatButtonTestElev.Show();
            VeziRaspunsuriButtonTestElev.Show();

            int s;

            if (nrImaginiTestElev != 0)
            {
                string qq = "";
                richTextBox2TestElev.Text = "";
                richTextBox2TestElev.LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestElev + "\\Imagini\\setari", RichTextBoxStreamType.PlainText);

                string[] linii = richTextBox2TestElev.Text.Split('\n');
                int[,] noilePozitii = new int[140, 140];

                for (int z = 0; z < linii.Length - 1; z++)
                {
                    string[] intermedirTestElev = linii[z].Split(' ');
                    noilePozitii[z, 0] = Convert.ToInt32(intermedirTestElev[0]);
                    noilePozitii[z, 1] = Convert.ToInt32(intermedirTestElev[1]);
                }

                //int q = 0, w = 0, ee = 0, r = 0;//q-location.x w-location.y e-width r-height
                for (int z = 0; z < nrImaginiTestElev; z++)
                {
                    //q = Convert.ToInt32(linii[z].Substring(0, linii[z].LastIndexOf(' ')));
                    //w = Convert.ToInt32(linii[z].Substring(linii[z].LastIndexOf(' ') + 1, linii[z].LastIndexOf('.') - linii[z].LastIndexOf(' ') - 1));
                    //richTextBox2.SelectedText += q.ToString() + ' ' + w.ToString() + ' ' + ee.ToString() + ' ' + r.ToString() + "\n";
                    imagineTestElev[z] = new PictureBox();
                    this.imagineTestElev[z].Location = new System.Drawing.Point(noilePozitii[z, 0], noilePozitii[z, 1]);
                    this.imagineTestElev[z].Name = "pictureBo" + z.ToString();
                    Size tempSize = imagineTestElev[z].Size;
                    this.imagineTestElev[z].SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                    this.imagineTestElev[z].TabStop = false;
                    this.imagineTestElev[z].TabIndex = z;
                    this.imagineTestElev[z].Image = System.Drawing.Image.FromFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestElev + "\\Imagini\\" + "imagine" + z.ToString() + ".jpg");//File.Open("D:\\Proiect\\Teste\\Chimie\\" + x + "\\Imagini\\" + z.ToString(), 

                    string sa = z.ToString();

                    PanelTestElev.Controls.Add(imagineTestElev[z]);
                    imagineTestElev[z].BringToFront();
                }

            }

            for (kTestElev = 0; kTestElev < numarRTTestElev; kTestElev++)
            {
                Point pos = new Point(0, 0);
                enuntTestElev[kTestElev] = new RichTextBox();
                raspunsTestElev[kTestElev] = new RichTextBox();
                raspunsCorectTestElev[kTestElev] = new RichTextBox();


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

                    this.PanelTestElev.Controls.Add(enuntTestElev[kTestElev]);
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

                        this.PanelTestElev.Controls.Add(enuntTestElev[kTestElev]);



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

                    int yNow = enuntTestElev[kTestElev].Height + 70;

                    AmTerminatButtonTestElev.Location = new Point(AmTerminatButtonTestElev.Location.X, yNow);
                    InfoAmTerminatTestElevPicture.Location = new Point(InfoAmTerminatTestElevPicture.Location.X, yNow);

                    VeziRaspunsuriButtonTestElev.Location = new Point(VeziRaspunsuriButtonTestElev.Location.X, yNow);
                    LockPrintTestElevPicture.Location = new Point(LockPrintTestElevPicture.Location.X, yNow);
                }
                else
                    if (kTestElev > 0)
                    {
                        lbTestElev[kTestElev].Location = new Point(0, lbTestElev[kTestElev - 1].Location.Y + enuntTestElev[kTestElev].Height + 100);// - 35);
                        raspunsTestElev[kTestElev].Location = new Point(120, lbTestElev[kTestElev - 1].Location.Y + enuntTestElev[kTestElev].Height + 100);
                        NrProblemaTestElev[kTestElev].Location = new Point(245, enuntTestElev[kTestElev].Location.Y - 30);

                        int yNow = lbTestElev[kTestElev - 1].Location.Y + enuntTestElev[kTestElev].Height + 130;

                        AmTerminatButtonTestElev.Location = new Point(AmTerminatButtonTestElev.Location.X, yNow);
                        InfoAmTerminatTestElevPicture.Location = new Point(InfoAmTerminatTestElevPicture.Location.X, yNow);

                        VeziRaspunsuriButtonTestElev.Location = new Point(VeziRaspunsuriButtonTestElev.Location.X, yNow);
                        LockPrintTestElevPicture.Location = new Point(LockPrintTestElevPicture.Location.X, yNow);
                    }
                this.PanelTestElev.Controls.Add(lbTestElev[kTestElev]);
                this.PanelTestElev.Controls.Add(raspunsTestElev[kTestElev]);
                this.PanelTestElev.Controls.Add(NrProblemaTestElev[kTestElev]);
                if (kTestElev == numarRTTestElev - 1)
                {
                    AmTerminatButtonTestElev.Text = "Am terminat";

                    VeziRaspunsuriButtonTestElev.Text = "Vezi răspunsuri";

                    this.PanelTestElev.Controls.Add(AmTerminatButtonTestElev);
                    this.PanelTestElev.Controls.Add(VeziRaspunsuriButtonTestElev);
                }
            }
            for (int i = 0; i < nrImaginiTestElev; i++)
            {
                imagineTestElev[i].BringToFront();
            }
            AmTerminatButtonTestElev.Location = new Point(AmTerminatButtonTestElev.Location.X, VeziRaspunsuriButtonTestElev.Location.Y);
        }

        private void button2_ClickTestElev(object sender, EventArgs e)
        {
            NewRaspunsTest rasp = new NewRaspunsTest(locatieTestElev, numeleMateriei);
            rasp.Show();
            AmTerminatButtonTestElev.Enabled = false;
        }

        private void timer1_TickTestElev(object sender, EventArgs e)
        {
            DateTime top = DateTime.Now;
            TimeSpan timp = top - dtTestElev;
            if ((MinuteTestElev == 0) && (SecundeTestElev == 0))
            {
                MinuteLabelTestElev.Hide();
                SecundeLabelTestElev.Hide();
                timerSecunde.Stop();
                timerMinute.Stop();
                CronometruTestElev.Stop();
                AmTerminatButtonTestElev.Enabled = false;
                VeziRaspunsuriButtonTestElev.Enabled = true;
                button1_ClickTestElev(sender, e);
            }
            else
            {
                TimeSpanConverter lala = new TimeSpanConverter();

                if (SecundeTestElev < 1)
                {
                    SecundeTestElev = 59;
                    SecundeLabelTestElev.Location = new Point(SecundeLabelTestElev.Location.X, SecundeLabelTestElev.Location.Y - 8);
                    timerSecunde.Start();
                    if (MinuteTestElev == 0)
                    {
                        MinuteTestElev = 59;
                        MinuteLabelTestElev.Location = new Point(MinuteLabelTestElev.Location.X, MinuteLabelTestElev.Location.Y - 8);
                        timerMinute.Start();
                    }
                    else
                    {
                        MinuteTestElev--;

                        MinuteLabelTestElev.Location = new Point(MinuteLabelTestElev.Location.X, MinuteLabelTestElev.Location.Y - 8);
                        timerMinute.Start();
                    }
                }
                else
                {
                    SecundeTestElev--;
                    SecundeLabelTestElev.Location = new Point(SecundeLabelTestElev.Location.X, SecundeLabelTestElev.Location.Y - 8);
                    timerSecunde.Start();
                }
            }
            MinuteLabelTestElev.Text = MinuteTestElev.ToString();
            SecundeLabelTestElev.Text = SecundeTestElev.ToString();
        }

        private void button6_ClickTestElev(object sender, EventArgs e)
        {
            MessageBox.Show("Forma răspunsurilor va fi următoarea: răspuns1; răspuns2;....răspuns n (răspunsurile fiind despărțite prin ;");
        }



        //Here starts VizualizeazaTest *********************************************************************

        public RichTextBox[] enuntVizualizeazaTest = new RichTextBox[40];
        public Label[] NrProblemaVizualizeazaTest = new Label[40];
        public string locatieVizualizeazaTest;
        int lastNrProblemeVizualizeazaTest = 0;

        private void ascundeVizualizeazaTest()
        {
            for (int i = 0; i < lastNrProblemeVizualizeazaTest; i++)
            {
                enuntVizualizeazaTest[i].Hide();
                NrProblemaVizualizeazaTest[i].Hide();
            }
            lastNrProblemeVizualizeazaTest = 0;
        }

        private void incarcaVizualizeazaTest(string location)
        {
            locatieVizualizeazaTest = location;

            this.Text = "Testul " + locatieVizualizeazaTest + " (" + numeleMateriei + ")";

            numarRTVizualizeazaTest = Directory.GetFiles(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieVizualizeazaTest + "\\").Length / 2 - 1;
            int s;

            SetariTextVizualizeazaTest.LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieVizualizeazaTest + "\\setari", RichTextBoxStreamType.PlainText);

            string[] elementeSetari = SetariTextVizualizeazaTest.Text.Split('\n');
            int[] inaltimiCasutaVizualizeazaTest = new int[40];
            //MessageBox.Show(SetariTextVizualizeazaTest.Text);
            for (int u = 1; u <= numarRTVizualizeazaTest; u++)
            {
                inaltimiCasutaVizualizeazaTest[u - 1] = Convert.ToInt32(elementeSetari[u]);
            }

            lastNrProblemeVizualizeazaTest = numarRTVizualizeazaTest;
            for (k = 0; k < numarRTVizualizeazaTest; k++)
            {
                Point pos = new Point(0, 0);
                enuntVizualizeazaTest[k] = new RichTextBox();


                if (k == 0)
                {
                    enuntVizualizeazaTest[k].BackColor = System.Drawing.Color.White;
                    enuntVizualizeazaTest[k].Name = "rt" + k;
                    enuntVizualizeazaTest[k].ReadOnly = true;
                    enuntVizualizeazaTest[k].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
                    enuntVizualizeazaTest[k].Size = new System.Drawing.Size(704, 10);
                    enuntVizualizeazaTest[k].TabIndex = k + 7;
                    this.enuntVizualizeazaTest[k].BorderStyle = System.Windows.Forms.BorderStyle.None;

                    s = k + 1;

                    enuntVizualizeazaTest[k].Text = System.IO.File.ReadAllText(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieVizualizeazaTest + "\\problema" + s);
                    enuntVizualizeazaTest[k].WordWrap = true;
                    enuntVizualizeazaTest[k].Location = new Point(0, 30);

                    enuntVizualizeazaTest[k].Height = inaltimiCasutaVizualizeazaTest[k];
                    this.PanelVizualizeazaTest.Controls.Add(enuntVizualizeazaTest[k]);
                }
                else
                    if (k > 0)
                    {
                        enuntVizualizeazaTest[k].BackColor = System.Drawing.Color.White;
                        enuntVizualizeazaTest[k].Name = "rt" + k;
                        enuntVizualizeazaTest[k].ReadOnly = true;
                        enuntVizualizeazaTest[k].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
                        enuntVizualizeazaTest[k].Size = new System.Drawing.Size(704, 10);
                        enuntVizualizeazaTest[k].TabIndex = k + 7;
                        this.enuntVizualizeazaTest[k].BorderStyle = System.Windows.Forms.BorderStyle.None;

                        s = k + 1;

                        enuntVizualizeazaTest[k].Text = System.IO.File.ReadAllText(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieVizualizeazaTest + "\\problema" + s);
                        enuntVizualizeazaTest[k].WordWrap = true;
                        enuntVizualizeazaTest[k].Location = new Point(0, enuntVizualizeazaTest[k - 1].Location.Y + enuntVizualizeazaTest[k - 1].Height + 40);// enunt[k - 1].Location.Y + enunt[k - 1].Height + 15);

                        enuntVizualizeazaTest[k].Height = inaltimiCasutaVizualizeazaTest[k];
                        this.PanelVizualizeazaTest.Controls.Add(enuntVizualizeazaTest[k]);
                    }

                //inaltimea richtextboxului
                pos.X = ClientRectangle.Width;
                pos.Y = ClientRectangle.Height;
                int lastIndex = enuntVizualizeazaTest[k].GetCharIndexFromPosition(pos);
                int lastLine = enuntVizualizeazaTest[k].GetLineFromCharIndex(lastIndex) + 1;

                NrProblemaVizualizeazaTest[k] = new Label();
                int numar;
                numar = k + 1;
                NrProblemaVizualizeazaTest[k].Text = "Problema " + numar;
                NrProblemaVizualizeazaTest[k].AutoSize = true;
                NrProblemaVizualizeazaTest[k].Name = "Nrproblema" + k;
                NrProblemaVizualizeazaTest[k].BackColor = System.Drawing.Color.Transparent;
                this.NrProblemaVizualizeazaTest[k].Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //pozitia label-ului "Raspuns"
                if (k == 0)
                {
                    NrProblemaVizualizeazaTest[k].Location = new Point(245, enuntVizualizeazaTest[k].Location.Y - 30);
                }
                else
                    if (k > 0)
                    {
                        NrProblemaVizualizeazaTest[k].Location = new Point(245, enuntVizualizeazaTest[k].Location.Y - 30);
                    }
                this.PanelVizualizeazaTest.Controls.Add(NrProblemaVizualizeazaTest[k]);
            }
            if (linkLabel1.Text == "Elev")
            {
                VeziRaspunsuriVizualizeazaTest.Location = new Point(VeziRaspunsuriVizualizeazaTest.Location.X, 
                    enuntVizualizeazaTest[numarRTVizualizeazaTest - 1].Height +
                    enuntVizualizeazaTest[numarRTVizualizeazaTest - 1].Location.Y + 20);
                InfoVeziRaspunsuriVizualizeazaTest.Location = new Point(InfoVeziRaspunsuriVizualizeazaTest.Location.X,
                    enuntVizualizeazaTest[numarRTVizualizeazaTest - 1].Height +
                    enuntVizualizeazaTest[numarRTVizualizeazaTest - 1].Location.Y + 11);
            }
            else
            {
                VeziRaspunsuriVizualizeazaTest.Hide();
                InfoVeziRaspunsuriVizualizeazaTest.Hide();
            }
        }

        public int kVizualizeazaTest = -1;
        public int numarRTVizualizeazaTest;

        private void VeziRaspunsuri_ClickVizualizeazaTest(object sender, EventArgs e)
        {
            NewRaspunsTest n = new NewRaspunsTest(locatieVizualizeazaTest, numeleMateriei);
            n.Show();
        }

        private void GoBackVizualizeazaTest_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(718, 350); changePanels(PanelVizualizeazaTest, PanelListaLectiiSiTeste);
            this.Text = "Lista lectii si teste";
            ascundeVizualizeazaTest();

            Deschidere.Default.aDeschisUnTest = false;
            Deschidere.Default.Save();
        }




        //Here starts TestProfesor **************************************************************************

        public RichTextBox[] enuntTestProfesor = new RichTextBox[40];
        public RichTextBox[] enuntSalvatTestProfesor = new RichTextBox[40];
        public RichTextBox[] raspunsCorectTestProfesor = new RichTextBox[40];
        public RichTextBox[] raspunsTestProfesor = new RichTextBox[40];
        public PictureBox[] imagineTestProfesor = new PictureBox[140];
        public RichTextBox[] imagineSalvatTestProfesor = new RichTextBox[140];
        public Label[] NrProblemaTestProfesor = new Label[40];
        public Label[] lbTestProfesor = new Label[40];

        string[] TextSalvatTestProfesor = new String[40];

        public string locatieTestProfesor;
        public int kglobalTestProfesor = 0;
        public int kTestProfesor = -1;
        public int numarRTTestProfesor;

        int[] inaltimiCasuteTestProfesor = new int[40];

        public bool clickTestProfesor = false;
        public int nrImaginiTestProfesor = 0;

        private void ascundeTestProfesor(string DeUndeVine)
        {
            Deschidere.Default.aDeschisUnTest = false;
            Deschidere.Default.Save();
            NumarulProblemeiMariteTestProfesor.Text = "";

            for (int i = 0; i < numarRTTestProfesor; i++)
            {
                enuntTestProfesor[i].Hide();
                enuntTestProfesor[i].Clear();
                if (DeUndeVine == "din save")
                {
                    enuntSalvatTestProfesor[i].Hide();
                    enuntSalvatTestProfesor[i].Clear();
                }
                raspunsCorectTestProfesor[i].Hide();
                raspunsCorectTestProfesor[i].Clear();

                raspunsTestProfesor[i].Hide();
                raspunsTestProfesor[i].Clear();

                NrProblemaTestProfesor[i].Hide();
                lbTestProfesor[i].Hide();
            }
            for (int i = 0; i < nrImaginiTestProfesor; i++)
            {
                imagineTestProfesor[i].Hide();
                try
                {
                    imagineSalvatTestProfesor[i].Hide();
                }
                catch
                {
                }
            }
        }

        private void incarcaTestProfesor(string location)
        {

            locatieTestProfesor = "";
            kglobalTestProfesor = 0;
            kTestProfesor = -1;
            numarRTTestProfesor = 0;
            SetariTextTestProfesor.Clear();

            clickTestProfesor = false;
            nrImaginiTestProfesor = 0;



            locatieTestProfesor = location;
            this.Text = "Editare Testul " + locatieTestProfesor + " (" + numeleMateriei + ")";

            //if (location != "ChimieLala")

            numarRTTestProfesor = Directory.GetFiles(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + location + "\\").Length / 2 - 1;
            //buton30TestProfesor.Enabled = true;

            //inserez inaltimile casutelor in rich text box
            SetariTextTestProfesor.LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestProfesor + "\\setari", RichTextBoxStreamType.PlainText);

            string[] elementeSetari = SetariTextTestProfesor.Text.Split('\n');

            //inserez in vector inaltimile casutelor
            for (int i = 1; i <= numarRTTestProfesor; i++)
            {
                inaltimiCasuteTestProfesor[i - 1] = Convert.ToInt32(elementeSetari[i]);
            }
            SetariTextTestProfesor.SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestProfesor + "\\setari", RichTextBoxStreamType.PlainText);

            if (Directory.Exists(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + location + "\\Imagini") == true)
            {
                nrImaginiTestProfesor = Directory.GetFiles(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + location + "\\Imagini\\").Length - 1;
            }

            //this.buton30TestProfesor.Click += new System.EventHandler(this.button2_ClickTestProfesor);

            SalveazaTestProfesor.Show();
            int s;

            for (kTestProfesor = 0; kTestProfesor < numarRTTestProfesor; kTestProfesor++)
            {
                Point pos = new Point(0, 0);
                enuntTestProfesor[kTestProfesor] = new RichTextBox();
                raspunsCorectTestProfesor[kTestProfesor] = new RichTextBox();
                raspunsTestProfesor[kTestProfesor] = new RichTextBox();
                lbTestProfesor[kTestProfesor] = new Label();

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


                    this.PanelTestProfesor.Controls.Add(enuntTestProfesor[kTestProfesor]);
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

                        this.PanelTestProfesor.Controls.Add(enuntTestProfesor[kTestProfesor]);
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
                    //buton30TestProfesor.Location = new Point(0, enuntTestProfesor[kTestProfesor].Height + 70);
                    SalveazaTestProfesor.Location = new Point(SalveazaTestProfesor.Location.X, enuntTestProfesor[kTestProfesor].Height + 70);
                    InfoSalveazaTestProfesorPicture.Location = new Point(InfoSalveazaTestProfesorPicture.Location.X, enuntTestProfesor[kTestProfesor].Height + 70);
                    PlusTestProfesor.Location = new Point(PlusTestProfesor.Location.X, enuntTestProfesor[kTestProfesor].Height + 75);
                    MinusTestProfesor.Location = new Point(MinusTestProfesor.Location.X, enuntTestProfesor[kTestProfesor].Height + 75);
                    NumarulProblemeiMariteTestProfesor.Location = new Point(NumarulProblemeiMariteTestProfesor.Location.X, enuntTestProfesor[kTestProfesor].Height + 76);
                }
                else
                    if (kTestProfesor > 0)
                    {
                        lbTestProfesor[kTestProfesor].Location = new Point(0, lbTestProfesor[kTestProfesor - 1].Location.Y + enuntTestProfesor[kTestProfesor].Height + 100);// - 35);
                        raspunsTestProfesor[kTestProfesor].Location = new Point(120, lbTestProfesor[kTestProfesor - 1].Location.Y + enuntTestProfesor[kTestProfesor].Height + 100);
                        NrProblemaTestProfesor[kTestProfesor].Location = new Point(245, enuntTestProfesor[kTestProfesor].Location.Y - 30);
                        //buton30TestProfesor.Location = new Point(130, lbTestProfesor[kTestProfesor - 1].Location.Y + enuntTestProfesor[kTestProfesor].Height + 130);



                        //NrProblemaTestProfesor[kTestProfesor].Location = new Point(245, enuntTestProfesor[kTestProfesor].Location.Y - 30);
                        //buton30TestProfesor.Location = new Point(0, enuntTestProfesor[kTestProfesor].Location.Y + enuntTestProfesor[kTestProfesor].Height);
                        SalveazaTestProfesor.Location = new Point(SalveazaTestProfesor.Location.X, lbTestProfesor[kTestProfesor - 1].Location.Y + enuntTestProfesor[kTestProfesor].Height + 130);
                        InfoSalveazaTestProfesorPicture.Location = new Point(InfoSalveazaTestProfesorPicture.Location.X, lbTestProfesor[kTestProfesor - 1].Location.Y + enuntTestProfesor[kTestProfesor].Height + 130);
                        PlusTestProfesor.Location = new Point(PlusTestProfesor.Location.X, lbTestProfesor[kTestProfesor - 1].Location.Y + enuntTestProfesor[kTestProfesor].Height + 135);
                        MinusTestProfesor.Location = new Point(MinusTestProfesor.Location.X, lbTestProfesor[kTestProfesor - 1].Location.Y + enuntTestProfesor[kTestProfesor].Height + 135);
                        NumarulProblemeiMariteTestProfesor.Location = new Point(NumarulProblemeiMariteTestProfesor.Location.X, lbTestProfesor[kTestProfesor - 1].Location.Y + enuntTestProfesor[kTestProfesor].Height + 136);
                    }
                this.PanelTestProfesor.Controls.Add(lbTestProfesor[kTestProfesor]);
                this.PanelTestProfesor.Controls.Add(raspunsTestProfesor[kTestProfesor]);
                this.PanelTestProfesor.Controls.Add(NrProblemaTestProfesor[kTestProfesor]);

                /*buton30TestProfesor.Text = "Vezi răspunsuri";
                buton30TestProfesor.AutoSize = true;
                this.buton30TestProfesor.TabIndex = 1;
                this.buton30TestProfesor.UseVisualStyleBackColor = true;
                this.buton30TestProfesor.Name = "buton30TestProfesor";
                this.buton30TestProfesor.Size = new System.Drawing.Size(75, 23);
                //buton30TestProfesor.Visible = true;
                //this.Controls.Add(buton30TestProfesor);
                */
                kglobalTestProfesor++;
                enuntTestProfesor[kTestProfesor].TextChanged += richTextBox1_TextChangedTestProfesor;
            }

            if (nrImaginiTestProfesor != 0)
            {
                string qq = "";
                richTextBox1TestProfesor.Text = "";
                richTextBox1TestProfesor.LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + location + "\\Imagini\\setari", RichTextBoxStreamType.PlainText);

                string[] pozi = richTextBox1TestProfesor.Text.Split('\n');

                int[,] noilePozitii = new int[140, 140];

                for (int i = 0; i < pozi.Length - 1; i++)
                {
                    string[] intr = pozi[i].Split(' ');
                    noilePozitii[i, 0] = Convert.ToInt32(intr[0]);
                    noilePozitii[i, 1] = Convert.ToInt32(intr[1]);
                }

                //int q = 0, w = 0, e = 0, r = 0;//q-location.x w-location.y e-width r-height
                for (kTestProfesor = 0; kTestProfesor < nrImaginiTestProfesor; kTestProfesor++)
                {
                    /*q = Convert.ToInt32(linii[kTestProfesor].Substring(0, linii[kTestProfesor].LastIndexOf(' ')));
                    w = Convert.ToInt32(linii[kTestProfesor].Substring(linii[kTestProfesor].LastIndexOf(' ') + 1, linii[kTestProfesor].LastIndexOf('.') - linii[kTestProfesor].LastIndexOf(' ') - 1));*/
                    //richTextBox2TestProfesor.SelectedText += q.ToString() + ' ' + w.ToString() + ' ' + e.ToString() + ' ' + r.ToString() + "\n";
                    imagineTestProfesor[kTestProfesor] = new PictureBox();
                    this.imagineTestProfesor[kTestProfesor].Location = new System.Drawing.Point(
                        noilePozitii[kTestProfesor, 0], noilePozitii[kTestProfesor, 1]);
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
                    PanelTestProfesor.Controls.Add(imagineTestProfesor[kTestProfesor]);
                    imagineTestProfesor[kTestProfesor].BringToFront();
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
            SetariTextTestProfesor.LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestProfesor + "\\setari", RichTextBoxStreamType.PlainText);

            string[] elementeSetari = SetariTextTestProfesor.Text.Split('\n');

            //asez pe prima linie timpul cronometrului
            SetariTextTestProfesor.Text = elementeSetari[0] + '\n';

            for (int i = 0; i < numarRTTestProfesor; i++)
            {
                SetariTextTestProfesor.Text += enuntTestProfesor[i].Height.ToString() + '\n';
            }
            SetariTextTestProfesor.SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestProfesor + "\\setari", RichTextBoxStreamType.PlainText);



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
                    
                    imagineSalvatTestProfesor[j].Text = imagineTestProfesor[j].Location.X.ToString() + " " + positionsTestProfesor[j].ToString() + '\n';
                    
                    PanelTestProfesor.Controls.Add(imagineSalvatTestProfesor[j]);
                    s = j + 1;
                    lala += imagineSalvatTestProfesor[j].Text;
                }
                imagineSalvatTestProfesor[0].Text = lala;
                imagineSalvatTestProfesor[0].SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestProfesor + "\\Imagini\\setari", RichTextBoxStreamType.PlainText);
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
                PanelTestProfesor.Controls.Add(enuntSalvatTestProfesor[kTestProfesor]);
                s = kTestProfesor + 1;

                enuntSalvatTestProfesor[kTestProfesor].SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestProfesor + "\\" + "problema" + s, RichTextBoxStreamType.PlainText);//"lectia" + kTestProfesor, RichTextBoxStreamType.PlainText);
            }
            for (int i = 0; i < numarRTTestProfesor; i++)
            {
                int f = i + 1;
                raspunsTestProfesor[i].SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatieTestProfesor + "\\raspuns" + f, RichTextBoxStreamType.PlainText);
            }

            ascundeTestProfesor("din save");
            this.Size = new System.Drawing.Size(718, 350); changePanels(PanelTestProfesor, PanelListaLectiiSiTeste);
            this.Text = "Lista lectii si teste";
            RefreshListaLectiiSiTeste.Focus();
        }
        
        private void richTextBox1_TextChangedTestProfesor(object sender, EventArgs e)//, int i)
        {
            int i = 0;
            for (i = 0; i < numarRTTestProfesor; i++)
            {
                TextSalvatTestProfesor[i] = enuntTestProfesor[i].Text;
            }
        }

        private Point pozitiaTestProfesor = new Point();
        private bool miscareTestProfesor = false;

        private void pictureBox1_MouseDownTestProfesor(object sender, MouseEventArgs e, string sad)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            int uw = Convert.ToInt32(sad);
            imagineTestProfesor[uw].BringToFront();
            pozitiaTestProfesor = e.Location;
            miscareTestProfesor = true;
        }

        private int[] positionsTestProfesor = new int[140];

        private void pictureBox1_MouseUpTestProfesor(object sender, MouseEventArgs e, string sad)
        {
            if (e.Button == MouseButtons.Left)
            {
                int uw = Convert.ToInt32(sad);
                imagineTestProfesor[uw].BringToFront();
                positionsTestProfesor[uw] = 0 - PanelTestProfesor.AutoScrollPosition.Y + imagineTestProfesor[uw].Location.Y;
            }
            miscareTestProfesor = false;
        }

        private void pictureBox1_MouseMoveTestProfesor(object sender, MouseEventArgs e, string sad)
        {
            if (!miscareTestProfesor || e.Button != MouseButtons.Left)// || kTestProfesor2 == -1)
            {
                return;
            }
            int kimg = Convert.ToInt32(sad);
            imagineTestProfesor[kimgAdaugaLectie] = (PictureBox)sender;
            imagineTestProfesor[kimgAdaugaLectie].Left += e.X - pozitiaTestProfesor.X;
            imagineTestProfesor[kimgAdaugaLectie].Top += e.Y - pozitiaTestProfesor.Y;
        }

        private void richTextBox3_SizeChangedTestProfesor(object sender, EventArgs e)
        {
            //int x = buton30TestProfesor.Location.Y;
            //buton30TestProfesor.Location = new Point(0, x + 10);
        }

        private void button2_Click_1TestProfesor(object sender, EventArgs e)
        {
            if (NumarulProblemeiMariteTestProfesor.Text != "")
            {
                int x = Convert.ToInt32(NumarulProblemeiMariteTestProfesor.Text);
                if (x > 0 && x <= numarRTTestProfesor)
                {
                    PlusTestProfesor.Location = new Point(PlusTestProfesor.Location.X, SalveazaTestProfesor.Location.Y + 15);
                    MinusTestProfesor.Location = new Point(MinusTestProfesor.Location.X, SalveazaTestProfesor.Location.Y + 15);
                    NumarulProblemeiMariteTestProfesor.Location = new Point(NumarulProblemeiMariteTestProfesor.Location.X, SalveazaTestProfesor.Location.Y + 16);
                    //buton30TestProfesor.Location = new Point(0, SalveazaTestProfesor.Location.Y + 10);
                    InfoSalveazaTestProfesorPicture.Location = new Point(InfoSalveazaTestProfesorPicture.Location.X, SalveazaTestProfesor.Location.Y + 10);
                    SalveazaTestProfesor.Location = new Point(SalveazaTestProfesor.Location.X, SalveazaTestProfesor.Location.Y + 10);
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
                    PlusTestProfesor.Location = new Point(PlusTestProfesor.Location.X, SalveazaTestProfesor.Location.Y - 5);
                    MinusTestProfesor.Location = new Point(MinusTestProfesor.Location.X, SalveazaTestProfesor.Location.Y - 5);
                    NumarulProblemeiMariteTestProfesor.Location = new Point(NumarulProblemeiMariteTestProfesor.Location.X, SalveazaTestProfesor.Location.Y - 4);
                    //buton30TestProfesor.Location = new Point(0, SalveazaTestProfesor.Location.Y - 10);
                    InfoSalveazaTestProfesorPicture.Location = new Point(InfoSalveazaTestProfesorPicture.Location.X, SalveazaTestProfesor.Location.Y - 10);
                    SalveazaTestProfesor.Location = new Point(SalveazaTestProfesor.Location.X, SalveazaTestProfesor.Location.Y - 10);
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

        private void GoBackTestProfesor_Click(object sender, EventArgs e)
        {
            ascundeTestProfesor("din back");
            this.Size = new System.Drawing.Size(718, 350); changePanels(PanelListaLectiiSiTeste, PanelTestProfesor);
            this.Text = "Lista lectii si teste";
            RefreshListaLectiiSiTeste.Focus();
        }





        //Here starts AdaugaTest ************************************************************************
        
        
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

        private void GoBackAdaugaTest_Click(object sender, EventArgs e)
        {
            ascundeAdaugaTest();
            this.Size = new System.Drawing.Size(718, 350); changePanels(PanelAdaugaTest, PanelListaLectiiSiTeste);
            this.Text = "Lista lectii si teste";
            RefreshListaLectiiSiTeste.Focus();
        }

        private void ascundeAdaugaTest()
        {
            PanelAdaugaTest.AutoScroll = false;
            try
            {
                for (int i = 1; i <= kAdaugaTest; i++)
                {
                    enuntAdaugaTest[i].Hide();
                    raspunsAdaugaTest[i].Hide();
                    lbAdaugaTest[i].Hide();
                    NrProblemaAdaugaTest[i].Hide();
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.ToString() +"\n\n\n"+kAdaugaTest);
                //nu a inceput sa aduge teste
            }

            try
            {
                for (int i = 0; i < kimgAdaugaTest; i++)
                {
                    imagineAdaugaTest[i].Hide();
                }
            }
            catch
            {
                //nu a inceput sa adauge teste
            }
        }

        private void incarcaAdaugaTest()
        {
            int pozitionButon1, pozitionButon2, pozitionButon3, pozitionButon4;
            int pozitionImagine1, pozitionImagine2, pozitionImagine3, pozitionImagine4;
            pozitionButon1 = AdaugaEnuntButtonAdaugaTest.Location.X;
            pozitionButon2 = AdaugaImagineButtonAdaugaTest.Location.X;
            pozitionButon3 = AdaugaProblemaButtonAdaugaTest.Location.X;
            pozitionButon4 = SalveazaButtonAdaugaTest.Location.X;
            pozitionImagine1 = AdaugaEnuntPictureAdaugaTest.Location.X;
            pozitionImagine2 = AdaugaImaginePictureAdaugaTest.Location.X;
            pozitionImagine3 = AdaugaProblemaPictureAdaugaTest.Location.X;
            pozitionImagine4 = SalveazaPictureAdaugaTest.Location.X;

            kglobalAdaugaTest = 0;
            pozitiiAdaugaTest = "";

            label1AdaugaTest.Visible = true;
            label2AdaugaTest.Visible = true;
            label3AdaugaTest.Visible = true;
            label4AdaugaTest.Visible = true;
            label5AdaugaTest.Visible = true;

            textBox1AdaugaTest.Clear();
            textBox2AdaugaTest.Clear();
            textBox3AdaugaTest.Clear();
            textBox4AdaugaTest.Clear();

            textBox1AdaugaTest.Visible = true;
            textBox2AdaugaTest.Visible = true;
            textBox3AdaugaTest.Visible = true;
            textBox4AdaugaTest.Visible = true;

            SalveazaButtonAdaugaTest.Enabled = false;
            AdaugaProblemaButtonAdaugaTest.Enabled = false;
            AdaugaImagineButtonAdaugaTest.Enabled = false;
            AdaugaEnuntButtonAdaugaTest.Enabled = false;

            SalveazaButtonAdaugaTest.Location = new Point(pozitionButon4, 115);
            SalveazaPictureAdaugaTest.Location = new Point(pozitionImagine4, 115);

            AdaugaProblemaButtonAdaugaTest.Location = new Point(pozitionButon3, 115);
            AdaugaProblemaPictureAdaugaTest.Location = new Point(pozitionImagine3, 115);

            AdaugaImagineButtonAdaugaTest.Location = new Point(pozitionButon2, 115);
            AdaugaImaginePictureAdaugaTest.Location = new Point(pozitionImagine2, 115);

            AdaugaEnuntButtonAdaugaTest.Location = new Point(pozitionButon1, 115);
            AdaugaEnuntPictureAdaugaTest.Location = new Point(pozitionImagine1, 115);
            
            
            saveAdaugaTest = false;
            apasatAdaugaTest = false;

            AdaugaEnuntButtonAdaugaTest.BackColor = Color.Gold;
            AdaugaImagineButtonAdaugaTest.BackColor = Color.Gold;
            SalveazaButtonAdaugaTest.BackColor = Color.Gold;
            AdaugaProblemaButtonAdaugaTest.BackColor = Color.Gold;

            AdaugaEnuntPictureAdaugaTest.Image = global::Proiect.Properties.Resources.bullet_error;
            AdaugaImaginePictureAdaugaTest.Image = global::Proiect.Properties.Resources.bullet_error;
            SalveazaPictureAdaugaTest.Image = global::Proiect.Properties.Resources.bullet_error;
            AdaugaProblemaPictureAdaugaTest.Image = global::Proiect.Properties.Resources.bullet_error;

            richTextBox1AdaugaTest.Clear();
            richTextBox2AdaugaTest.Clear();
            richTextBox3AdaugaTest.Clear();

            PanelAdaugaTest.AutoScroll = true;

            numarRTAdaugaTest = 0;
            kAdaugaTest = 0;
            nrAdaugaTest = 0;
            kimgAdaugaTest = 0;
            
            this.Text = "Adauga un test la (" + numeleMateriei + ")";
    
            textBox1AdaugaTest.Focus();

            if (Directory.Exists(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei) == false)
            {
                Directory.CreateDirectory(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei);
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

            enuntAdaugaTest[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PanelAdaugaTest.Controls.Add(enuntAdaugaTest[0]);
            this.PanelAdaugaTest.Controls.Add(imagineAdaugaTest[0]);
            //Inaltime RichTextBox1
            if (ofAdaugaTest[0].FileName.Substring(ofAdaugaTest[0].FileName.LastIndexOf('.') + 1, ofAdaugaTest[0].FileName.Length - 1 - ofAdaugaTest[0].FileName.LastIndexOf('.')) == "txt")// ||
                enuntAdaugaTest[0].LoadFile(ofAdaugaTest[0].FileName, RichTextBoxStreamType.PlainText);
            else
                if (ofAdaugaTest[0].FileName.Substring(ofAdaugaTest[0].FileName.LastIndexOf('.') + 1, ofAdaugaTest[0].FileName.Length - 1 - ofAdaugaTest[0].FileName.LastIndexOf('.')) == "rtf")
                    enuntAdaugaTest[0].LoadFile(ofAdaugaTest[0].FileName, RichTextBoxStreamType.PlainText);

            pos.X = 0;
            pos.Y = 0;
            int lastIndex = enuntAdaugaTest[0].GetCharIndexFromPosition(pos);
            int lastLine = enuntAdaugaTest[0].GetLineFromCharIndex(lastIndex) + 1;
            enuntAdaugaTest[0].Height = lastLine * 14;

        }

        public void button1_ClickAdaugaTest(object sender, EventArgs e)
        {

            int pozitionButon1, pozitionButon2, pozitionButon3, pozitionButon4;
            int pozitionImagine1, pozitionImagine2, pozitionImagine3, pozitionImagine4;
            pozitionButon1 = AdaugaEnuntButtonAdaugaTest.Location.X;
            pozitionButon2 = AdaugaImagineButtonAdaugaTest.Location.X;
            pozitionButon3 = AdaugaProblemaButtonAdaugaTest.Location.X;
            pozitionButon4 = SalveazaButtonAdaugaTest.Location.X;
            pozitionImagine1 = AdaugaEnuntPictureAdaugaTest.Location.X;
            pozitionImagine2 = AdaugaImaginePictureAdaugaTest.Location.X;
            pozitionImagine3 = AdaugaProblemaPictureAdaugaTest.Location.X;
            pozitionImagine4 = SalveazaPictureAdaugaTest.Location.X;

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
                                enuntAdaugaTest[kAdaugaTest].Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                this.PanelAdaugaTest.Controls.Add(enuntAdaugaTest[kAdaugaTest]);
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
                                    enuntAdaugaTest[kAdaugaTest].Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                    this.PanelAdaugaTest.Controls.Add(enuntAdaugaTest[kAdaugaTest]);
                                }

                            if (ofAdaugaTest[kAdaugaTest].FileName.Substring(ofAdaugaTest[kAdaugaTest].FileName.LastIndexOf('.') + 1, ofAdaugaTest[kAdaugaTest].FileName.Length - 1 - ofAdaugaTest[kAdaugaTest].FileName.LastIndexOf('.')) == "txt")// ||
                                enuntAdaugaTest[kAdaugaTest].LoadFile(ofAdaugaTest[kAdaugaTest].FileName, RichTextBoxStreamType.PlainText);
                            else
                                if (ofAdaugaTest[kAdaugaTest].FileName.Substring(ofAdaugaTest[kAdaugaTest].FileName.LastIndexOf('.') + 1, ofAdaugaTest[kAdaugaTest].FileName.Length - 1 - ofAdaugaTest[kAdaugaTest].FileName.LastIndexOf('.')) == "rtf")
                                    enuntAdaugaTest[kAdaugaTest].LoadFile(ofAdaugaTest[kAdaugaTest].FileName, RichTextBoxStreamType.PlainText);

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

                            AdaugaEnuntButtonAdaugaTest.BackColor = Color.LightSteelBlue;
                            AdaugaProblemaButtonAdaugaTest.BackColor = Color.Gold;
                            SalveazaButtonAdaugaTest.BackColor = Color.Gold;


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
                            this.PanelAdaugaTest.Controls.Add(NrProblemaAdaugaTest[kAdaugaTest]);
                            this.PanelAdaugaTest.Controls.Add(lbAdaugaTest[kAdaugaTest]);
                            raspunsAdaugaTest[kAdaugaTest].Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                            this.PanelAdaugaTest.Controls.Add(raspunsAdaugaTest[kAdaugaTest]);

                            AdaugaEnuntButtonAdaugaTest.Location = new Point(pozitionButon1, lbAdaugaTest[kAdaugaTest].Location.Y + 45); // button1.Location.Y + enuntAdaugaTest[kAdaugaTest].Height+40);
                            AdaugaEnuntPictureAdaugaTest.Location = new Point(pozitionImagine1, lbAdaugaTest[kAdaugaTest].Location.Y + 45);

                            AdaugaImagineButtonAdaugaTest.Location = new Point(pozitionButon2, AdaugaEnuntButtonAdaugaTest.Location.Y);
                            AdaugaImaginePictureAdaugaTest.Location = new Point(pozitionImagine2, AdaugaEnuntButtonAdaugaTest.Location.Y);

                            AdaugaProblemaButtonAdaugaTest.Location = new Point(pozitionButon3, AdaugaImagineButtonAdaugaTest.Location.Y);
                            AdaugaProblemaPictureAdaugaTest.Location = new Point(pozitionImagine3, AdaugaImagineButtonAdaugaTest.Location.Y);

                            SalveazaButtonAdaugaTest.Location = new Point(pozitionButon4, AdaugaImagineButtonAdaugaTest.Location.Y);
                            SalveazaPictureAdaugaTest.Location = new Point(pozitionImagine4, AdaugaImagineButtonAdaugaTest.Location.Y);

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

                        AdaugaEnuntButtonAdaugaTest.BackColor = Color.Gold;
                        AdaugaProblemaButtonAdaugaTest.BackColor = Color.LightSteelBlue;
                        SalveazaButtonAdaugaTest.BackColor = Color.LightSteelBlue;
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

                    AdaugaEnuntButtonAdaugaTest.BackColor = Color.Gold;
                    AdaugaProblemaButtonAdaugaTest.BackColor = Color.LightSteelBlue;
                    SalveazaButtonAdaugaTest.BackColor = Color.LightSteelBlue;
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

            string ss = sender.ToString();
            ss = ss.Substring(ss.LastIndexOf("Text: ") + 6, ss.Length - ss.LastIndexOf("Text: ") - 6);
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

                                AdaugaEnuntButtonAdaugaTest.BackColor = Color.LightSteelBlue;
                                AdaugaImagineButtonAdaugaTest.BackColor = Color.LightSteelBlue;


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
                    if (ss==textBox1AdaugaTest.Text)
                    {
                        textBox2AdaugaTest.Focus();
                    }
                    else
                        if (ss==textBox2AdaugaTest.Text)
                        {
                            textBox3AdaugaTest.Focus();
                        }
                        else
                            if (ss==textBox3AdaugaTest.Text)
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

                AdaugaEnuntButtonAdaugaTest.BackColor = Color.LightSteelBlue;
                AdaugaProblemaButtonAdaugaTest.BackColor = Color.Gold;
                SalveazaButtonAdaugaTest.BackColor = Color.Gold;
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

                    richTextBox2AdaugaTest.SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + textBox1AdaugaTest.Text + "\\setari", RichTextBoxStreamType.PlainText);

                    int lala = kglobalAdaugaTest;


                    richTextBox3AdaugaTest.Text = textBox4AdaugaTest.Text;
                    richTextBox3AdaugaTest.SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + textBox1AdaugaTest.Text + "\\" + "detalii", RichTextBoxStreamType.PlainText);

                    for (int i = 1; i <= kglobalAdaugaTest; i++)
                    {
                        enuntAdaugaTest[i].SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + textBox1AdaugaTest.Text + "\\" + "problema" + i, RichTextBoxStreamType.PlainText);
                        raspunsAdaugaTest[i].SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + textBox1AdaugaTest.Text + "\\" + "raspuns" + i, RichTextBoxStreamType.PlainText);//"lectia" + k, RichTextBoxStreamType.PlainText);
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
                            pozitiiAdaugaTest += imagineAdaugaTest[i].Location.X + " " + positionsAdaugaTest[i] + '\n';
                            File.Copy(folderimgAdaugaTest[i], Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + textBox1AdaugaTest.Text + "\\Imagini\\" + "imagine" + i + ".jpg", true);
                            richTextBox1AdaugaTest.Text = pozitiiAdaugaTest;

                            /*MessageBox.Show(imagineAdaugaTest[i].Location.X + "  " + imagineAdaugaTest[i].Location.Y + '\n' +
                                imagineAdaugaTest[i].Location.Y + imagineAdaugaTest[i].Parent.Location.Y + '\n' +
                                imagineAdaugaTest[i].Parent.Text+'\n'+positionsAdaugaTest[i]);*/
                        }
                        
                        richTextBox1AdaugaTest.SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + textBox1AdaugaTest.Text + "\\Imagini\\" + "setari", RichTextBoxStreamType.PlainText);
                    }

                    this.Size = new System.Drawing.Size(718, 350); changePanels(PanelAdaugaTest, PanelListaLectiiSiTeste);
                    this.Text = "Lista lectii si teste";
                    RefreshListaLectiiSiTeste.Focus();
                    ascundeAdaugaTest();

                    numarRTAdaugaTest = 0;
                    kAdaugaTest = 0;
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

                this.PanelAdaugaTest.Controls.Add(imagineAdaugaTest[kimgAdaugaTest]);
                imagineAdaugaTest[kimgAdaugaTest].BringToFront();
            }

            kimgAdaugaTest++;
        }

        public Point pozitiaAdaugaTest = new Point();
        public bool miscareAdaugaTest = false;




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
                    pozitiaAdaugaTest = e.Location;
                    miscareAdaugaTest = true;
                    break;
                }
            }
        }

        public void pictureBox1_MouseUpAdaugaTest(object sender, MouseEventArgs e)
        {
            miscareAdaugaTest = false;
            for (int i = 0; i < kimgAdaugaTest; i++)
            {
                if (sender.Equals(imagineAdaugaTest[i]))
                {
                    //MessageBox.Show(e.Location.Y.ToString());
                    //MessageBox.Show(PanelAdaugaTest.AutoScrollPosition.Y.ToString());
                    positionsAdaugaTest[i] = 0 - PanelAdaugaTest.AutoScrollPosition.Y + imagineAdaugaTest[i].Location.Y;
                    break;
                }
            }
        }

        public void pictureBox1_MouseMoveAdaugaTest(object sender, MouseEventArgs e)
        {
            if (miscareAdaugaTest == false || e.Button != MouseButtons.Left)// || k2 == -1)
            {
                return;
            }
            for (int i = 0; i < kimgAdaugaTest; i++)
            {
                if (sender.Equals(imagineAdaugaTest[i]))
                {
                    imagineAdaugaTest[i].Left += e.X - pozitiaAdaugaTest.X;
                    imagineAdaugaTest[i].Top += e.Y - pozitiaAdaugaTest.Y;
                }
            }
        }

        private void button6_ClickAdaugaTest(object sender, EventArgs e)
        {
            MessageBox.Show("Forma răspunsurilor va fi următoarea: răspuns1; răspuns2;....răspuns n #nota1##nota2#...#nota n# (răspunsurile fiind " +
                "despărțite prin ; iar notele fiind cuprinse între #");
        }

        



        //Here starts VeziLectie **********************************************************************

        AxWMPLib.AxWindowsMediaPlayer[] videosVeziLectie = new AxWMPLib.AxWindowsMediaPlayer[40];
        RichTextBox[] texteVeziLectie = new RichTextBox[40];
        PictureBox[] imagineVeziLectie = new PictureBox[40];
        int nrVideoVeziLectie = 0;
        int nrTexteVeziLectie = 0;
        int nrImaginiVeziLectie = 0;

        private string locatieVeziLectie = "";

        private void ascundeVeziLectia()
        {
            for (int i = 0; i < totalV; i++)
            {
                videosVeziLectie[i].Hide();
            }
            for (int i = 0; i < totalT; i++)
            {
                texteVeziLectie[i].Hide();
            }
            for (int i = 0; i < nrImaginiVeziLectie; i++)
            {
                imagineVeziLectie[i].Hide();
            }
        }

        int totalV = 0, totalT = 0;

        private void incarcaVeziLectia(string location)
        {
            nrVideoVeziLectie = 0;
            nrTexteVeziLectie = 0;
            nrImaginiVeziLectie = 0;

            locatieVeziLectie = "";

            locatieVeziLectie = location;
            this.Text = "Lectia " + locatieVeziLectie + " (" + numeleMateriei + ")";

            totalV = 0;
            totalT = 0;

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
                        videosVeziLectie[totalV].Location = new Point(0, 30);
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

                            videosVeziLectie[totalV].Location = new Point(0, 30 + texteVeziLectie[totalT - 1].Location.Y + texteVeziLectie[totalT - 1].Height + 30);
                        }
                    }

                    videosVeziLectie[totalV].Size = new System.Drawing.Size(651, 484);
                    videosVeziLectie[totalV].Visible = true;
                    PanelVeziLectie.Controls.Add(videosVeziLectie[totalV]);

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
                        texteVeziLectie[totalT].Location = new Point(0, 30);
                    }
                    else
                    {
                        //daca a avut inainte tot un film
                        if (pozi[i - 1][0] != 'T')
                        {
                            texteVeziLectie[totalT].Location = new Point(0, 30 + videosVeziLectie[totalV - 1].Location.Y + 515);
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

                    texteVeziLectie[totalT].BackColor = System.Drawing.Color.White;
                    texteVeziLectie[totalT].ReadOnly = true;
                    texteVeziLectie[totalT].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
                    texteVeziLectie[totalT].Size = new System.Drawing.Size(665, 484);
                    texteVeziLectie[totalT].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    texteVeziLectie[totalT].LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + locatieVeziLectie + "\\Text\\T" + numar2, RichTextBoxStreamType.PlainText);

                    Point pos2 = new Point(0, 0);
                    pos2.X = ClientRectangle.Width;
                    pos2.Y = ClientRectangle.Height;
                    int lastIndex2 = texteVeziLectie[totalT].GetCharIndexFromPosition(pos2);
                    int lastLine2 = texteVeziLectie[totalT].GetLineFromCharIndex(lastIndex2) + 1;
                    texteVeziLectie[totalT].Height = lastLine2 * 14;

                    texteVeziLectie[totalT].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    texteVeziLectie[totalT].Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                    PanelVeziLectie.Controls.Add(texteVeziLectie[totalT]);

                    totalT++;
                }
            }
            if (Directory.Exists(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + locatieVeziLectie + "\\Imagini"))
            {
                nrImaginiVeziLectie = Directory.GetFiles(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + locatieVeziLectie + "\\Imagini").Length - 1;
                if (nrImaginiVeziLectie != 0)
                {
                    string qq = "";
                    richTextBox2VeziLectie.Text = "";
                    richTextBox2VeziLectie.LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + locatieVeziLectie + "\\Imagini\\setari", RichTextBoxStreamType.PlainText);

                    string[] pozii = richTextBox2VeziLectie.Text.Split('\n');

                    int[,] noilePozitii = new int[140, 2];

                    for (int i = 0; i < pozii.Length - 1; i++)
                    {
                        //MessageBox.Show(pozii[i]);
                        string[] intr = pozii[i].Split(' ');
                        noilePozitii[i, 0] = Convert.ToInt32(intr[0]);
                        noilePozitii[i, 1] = Convert.ToInt32(intr[1]);
                    }
                    //int q = 0, w = 0, ee = 0, r = 0;//q-location.x w-location.y e-width r-height
                    for (int z = 0; z < nrImaginiVeziLectie; z++)
                    {
                        //q = Convert.ToInt32(linii[z].Substring(0, linii[z].LastIndexOf(' ')));
                        //w = Convert.ToInt32(linii[z].Substring(linii[z].LastIndexOf(' ') + 1, linii[z].LastIndexOf('.') - linii[z].LastIndexOf(' ') - 1));
                        //richTextBox2.SelectedText += q.ToString() + ' ' + w.ToString() + ' ' + ee.ToString() + ' ' + r.ToString() + "\n";
                        imagineVeziLectie[z] = new PictureBox();
                        this.imagineVeziLectie[z].Location = new System.Drawing.Point(noilePozitii[z,0],noilePozitii[z,1]);
                        Size tempSize = imagineVeziLectie[z].Size;
                        this.imagineVeziLectie[z].SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                        this.imagineVeziLectie[z].TabStop = false;
                        this.imagineVeziLectie[z].Image = System.Drawing.Image.FromFile(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + locatieVeziLectie + "\\Imagini\\" + "imagine" + z.ToString() + ".jpg");

                        string sa = z.ToString();
                        PanelVeziLectie.Controls.Add(imagineVeziLectie[z]);
                        imagineVeziLectie[z].BringToFront();
                    }
                }
            }
        }

        private void GoBackVeziLectie_Click(object sender, EventArgs e)
        {
            ascundeVeziLectia();
            changePanels(PanelVeziLectie, PanelListaLectiiSiTeste);
            RefreshListaLectiiSiTeste.Focus();
            this.Text = "Lista lectii si teste";

            this.Width = 718;
            this.Height = 350;
            PanelVeziLectie.Width = 711;
            PanelVeziLectie.Height = 321;
        }



        //Here starts AdaugaLectie ****************************************************************************

        AxWMPLib.AxWindowsMediaPlayer[] videosAdaugaLectie = new AxWMPLib.AxWindowsMediaPlayer[40];
        RichTextBox[] texteAdaugaLectie = new RichTextBox[40];
        PictureBox[] imagineAdaugaLectie = new PictureBox[40];

        int[] positionsAdaugaLectie = new int[40];

        int k1AdaugaLectie = 0;//retine numarul de videos
        int k2AdaugaLectie = 0;//retine numarul de texte
        int kimgAdaugaLectie = 0;//retine numarul de imagini

        int x1AdaugaLectie, y1AdaugaLectie, x2AdaugaLectie, y2AdaugaLectie,
            x3AdaugaLectie, y3AdaugaLectie, x4AdaugaLectie, y4AdaugaLectie;
        string[] folderimgAdaugaLectie = new String[120];
        string[] locatiiAdaugaLectie = new string[40];
        string[] locatiiIMGAdaugaLectie = new string[40];
        string[] numeAdaugaLectie = new string[40];
        string[] caiAdaugaLectie = new string[40];
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));

        private void ascundeAdaugaLectie()
        {
            PanelAdaugaTest.AutoScroll = false;

            for (int i = 0; i < k1AdaugaLectie; i++)
            {
                videosAdaugaLectie[i].Hide();
            }
            for (int i = 0; i < k2AdaugaLectie; i++)
            {
                texteAdaugaLectie[i].Hide();
            }
            for (int i = 0; i < kimgAdaugaLectie; i++)
            {
                imagineAdaugaLectie[i].Hide();
            }
        }

        private void incarcaAdaugaLectie()
        {

            int pozitionButon1, pozitionButon2, pozitionButon3, pozitionButon4;
            int pozitionImagine1, pozitionImagine2, pozitionImagine3, pozitionImagine4;
            pozitionButon1 = AdaugaVideoButtonAdaugaLectie.Location.X;
            pozitionButon2 = AdaugaTextButtonAdaugaLectie.Location.X;
            pozitionButon3 = AdaugaImagineButtonAdaugaLectie.Location.X;
            pozitionButon4 = SalveazaButtonAdaugaLectie.Location.X;
            pozitionImagine1 = AdaugaVideoPictureAdaugaLectie.Location.X;
            pozitionImagine2 = AdaugaTextPictureAdaugaLectie.Location.X;
            pozitionImagine3 = AdaugaImaginePictureAdaugaLectie.Location.X;
            pozitionImagine4 = SalveazaPictureAdaugaLectie.Location.X;

            AdaugaVideoButtonAdaugaLectie.Location = new Point(pozitionButon1, 88);
            AdaugaVideoButtonAdaugaLectie.Enabled = false;
            AdaugaVideoPictureAdaugaLectie.Location = new Point(pozitionImagine1, 88);

            AdaugaTextButtonAdaugaLectie.Location = new Point(pozitionButon2, 88);
            AdaugaTextButtonAdaugaLectie.Enabled = false;
            AdaugaTextPictureAdaugaLectie.Location = new Point(pozitionImagine2, 88);

            AdaugaImagineButtonAdaugaLectie.Location = new Point(pozitionButon3, 88);
            AdaugaImagineButtonAdaugaLectie.Enabled = false;
            AdaugaImaginePictureAdaugaLectie.Location = new Point(pozitionImagine3, 88);

            SalveazaButtonAdaugaLectie.Location = new Point(pozitionButon4, 88);
            SalveazaButtonAdaugaLectie.Enabled = false;
            SalveazaPictureAdaugaLectie.Location = new Point(pozitionImagine4, 88);
            
            label1AdaugaLectie.Location = new Point(14, 27);
            label1AdaugaLectie.Visible = true;
            
            label4AdaugaLectie.Location = new Point(14, 52);
            label4AdaugaLectie.Visible = true;
            
            label5AdaugaLectie.Location = new Point(389, 58);
            label5AdaugaLectie.Visible = true;

            DetaliiAdaugaLectie.Location = new Point(218, 58);
            DetaliiAdaugaLectie.Visible = true;
            DetaliiAdaugaLectie.Clear();

            NumeLectieAdaugaLectie.Location = new Point(218, 30);
            NumeLectieAdaugaLectie.Visible = true;
            NumeLectieAdaugaLectie.Clear();

            PanelAdaugaTest.AutoScroll = true;

            k1AdaugaLectie = 0;//retine numarul de videos
            k2AdaugaLectie = 0;//retine numarul de texte
            kimgAdaugaLectie = 0;//retine numarul de imagini
            this.Text += " (" + numeleMateriei + ")";
            NumeLectieAdaugaLectie.Focus();

            AdaugaVideoButtonAdaugaLectie.BackColor = Color.Gold;
            AdaugaTextButtonAdaugaLectie.BackColor = Color.Gold;
            AdaugaImagineButtonAdaugaLectie.BackColor = Color.Gold;
            SalveazaButtonAdaugaLectie.BackColor = Color.Gold;

            AdaugaVideoPictureAdaugaLectie.Image = global::Proiect.Properties.Resources.bullet_error;
            AdaugaTextPictureAdaugaLectie.Image = global::Proiect.Properties.Resources.bullet_error;
            AdaugaImaginePictureAdaugaLectie.Image = global::Proiect.Properties.Resources.bullet_error;
            SalveazaPictureAdaugaLectie.Image = global::Proiect.Properties.Resources.bullet_error;
        }

        private void AdaugaImagine_ClickAdaugaLectie(object sender, EventArgs e)
        {

            if (Directory.Exists(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text) == false)
            {
                imagineAdaugaLectie[kimgAdaugaLectie] = new PictureBox();
                OpenFileDialog of = new OpenFileDialog();
                if (of.ShowDialog() != System.Windows.Forms.DialogResult.Cancel &&
                               of.FileName.Length > 0)
                {
                    folderimgAdaugaLectie[kimgAdaugaLectie] = of.FileName;

                    imagineAdaugaLectie[kimgAdaugaLectie].Load(of.FileName);
                    imagineAdaugaLectie[kimgAdaugaLectie].SizeMode = PictureBoxSizeMode.AutoSize;
                    imagineAdaugaLectie[kimgAdaugaLectie].Location = new Point(AdaugaImagineButtonAdaugaLectie.Location.X + 50, AdaugaImagineButtonAdaugaLectie.Location.Y);

                    imagineAdaugaLectie[kimgAdaugaLectie].MouseUp += pictureBox1_MouseUpAdaugaLectie;
                    imagineAdaugaLectie[kimgAdaugaLectie].MouseMove += pictureBox1_MouseMoveAdaugaLectie;
                    imagineAdaugaLectie[kimgAdaugaLectie].MouseDown += pictureBox1_MouseDownAdaugaLectie;

                    PanelAdaugaLectie.Controls.Add(imagineAdaugaLectie[kimgAdaugaLectie]);
                    imagineAdaugaLectie[kimgAdaugaLectie].BringToFront();

                    kimgAdaugaLectie++;
                }
            }
            else
            {
                MessageBox.Show("Nume deja existent!" + '\n' + "Introduceți alt nume!");
            }
        }

        public Point pozitiaAdaugaLectie = new Point();
        public bool miscareAdaugaLectie = false;

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
                        richTextBox4AdaugaLectie.Text += k1AdaugaLectie.ToString() + '\n';

                        label1AdaugaLectie.Visible = false;
                        NumeLectieAdaugaLectie.Visible = false;
                        label4AdaugaLectie.Visible = false;
                        label5AdaugaLectie.Visible = false;
                        DetaliiAdaugaLectie.Hide();

                        string calea = of.FileName.Substring(0, of.FileName.LastIndexOf('\\'));

                        caiAdaugaLectie[k1AdaugaLectie] = calea;
                        numeAdaugaLectie[k1AdaugaLectie] = of.SafeFileName;
                        locatiiAdaugaLectie[k1AdaugaLectie] = of.FileName;
                        //MessageBox.Show(locatii[k1AdaugaLectie]);

                        videosAdaugaLectie[k1AdaugaLectie] = new AxWMPLib.AxWindowsMediaPlayer();
                        videosAdaugaLectie[k1AdaugaLectie].Enabled = true;


                        x1AdaugaLectie = AdaugaVideoButtonAdaugaLectie.Location.X;
                        y1AdaugaLectie = AdaugaVideoButtonAdaugaLectie.Location.Y;

                        x2AdaugaLectie = AdaugaTextButtonAdaugaLectie.Location.X;
                        y2AdaugaLectie = AdaugaTextButtonAdaugaLectie.Location.Y;

                        x3AdaugaLectie = AdaugaImagineButtonAdaugaLectie.Location.X;
                        y3AdaugaLectie = AdaugaImagineButtonAdaugaLectie.Location.Y;

                        x4AdaugaLectie = SalveazaButtonAdaugaLectie.Location.X;
                        y4AdaugaLectie = SalveazaButtonAdaugaLectie.Location.Y;

                        if (k2AdaugaLectie == 0 && k1AdaugaLectie == 0)
                        {
                            videosAdaugaLectie[k1AdaugaLectie].Location = new System.Drawing.Point(0, 30);
                            //richTextBox1.Text = "0" + '\n';
                            AdaugaTextPictureAdaugaLectie.Location = new Point(AdaugaTextPictureAdaugaLectie.Location.X, AdaugaTextButtonAdaugaLectie.Location.Y + 450);
                            AdaugaTextButtonAdaugaLectie.Location = new Point(AdaugaTextButtonAdaugaLectie.Location.X, AdaugaTextButtonAdaugaLectie.Location.Y + 450);

                            AdaugaImaginePictureAdaugaLectie.Location = new Point(AdaugaImaginePictureAdaugaLectie.Location.X, AdaugaImagineButtonAdaugaLectie.Location.Y + 450);
                            AdaugaImagineButtonAdaugaLectie.Location = new Point(AdaugaImagineButtonAdaugaLectie.Location.X, AdaugaImagineButtonAdaugaLectie.Location.Y + 450);

                            AdaugaVideoPictureAdaugaLectie.Location = new Point(AdaugaVideoPictureAdaugaLectie.Location.X, AdaugaVideoButtonAdaugaLectie.Location.Y + 450);
                            AdaugaVideoButtonAdaugaLectie.Location = new Point(AdaugaVideoButtonAdaugaLectie.Location.X, AdaugaVideoButtonAdaugaLectie.Location.Y + 450);

                            SalveazaPictureAdaugaLectie.Location = new Point(SalveazaPictureAdaugaLectie.Location.X, SalveazaButtonAdaugaLectie.Location.Y + 450);
                            SalveazaButtonAdaugaLectie.Location = new Point(SalveazaButtonAdaugaLectie.Location.X, SalveazaButtonAdaugaLectie.Location.Y + 450);
                        }
                        else
                            if (k2AdaugaLectie == 0)
                            {
                                videosAdaugaLectie[k1AdaugaLectie].Location = new Point(0, AdaugaVideoButtonAdaugaLectie.Location.Y - 515);
                                //richTextBox1.Text += (AdaugaVideo.Location.Y - 515).ToString() + '\n';

                                AdaugaTextPictureAdaugaLectie.Location = new Point(AdaugaTextPictureAdaugaLectie.Location.X, AdaugaTextButtonAdaugaLectie.Location.Y + 515);
                                AdaugaTextButtonAdaugaLectie.Location = new Point(AdaugaTextButtonAdaugaLectie.Location.X, AdaugaTextButtonAdaugaLectie.Location.Y + 515);

                                AdaugaImaginePictureAdaugaLectie.Location = new Point(AdaugaImaginePictureAdaugaLectie.Location.X, AdaugaImagineButtonAdaugaLectie.Location.Y + 515);
                                AdaugaImagineButtonAdaugaLectie.Location = new Point(AdaugaImagineButtonAdaugaLectie.Location.X, AdaugaImagineButtonAdaugaLectie.Location.Y + 515);

                                AdaugaVideoPictureAdaugaLectie.Location = new Point(AdaugaVideoPictureAdaugaLectie.Location.X, AdaugaVideoButtonAdaugaLectie.Location.Y + 515);
                                AdaugaVideoButtonAdaugaLectie.Location = new Point(AdaugaVideoButtonAdaugaLectie.Location.X, AdaugaVideoButtonAdaugaLectie.Location.Y + 515);

                                SalveazaPictureAdaugaLectie.Location = new Point(SalveazaPictureAdaugaLectie.Location.X, SalveazaButtonAdaugaLectie.Location.Y + 515);
                                SalveazaButtonAdaugaLectie.Location = new Point(SalveazaButtonAdaugaLectie.Location.X, SalveazaButtonAdaugaLectie.Location.Y + 515);
                            }
                            else
                            {
                                //richTextBox1.Text += (AdaugaVideo.Location.Y - 515).ToString() + '\n';

                                AdaugaTextPictureAdaugaLectie.Location = new Point(AdaugaTextPictureAdaugaLectie.Location.X, AdaugaTextButtonAdaugaLectie.Location.Y + 515);
                                AdaugaTextButtonAdaugaLectie.Location = new Point(AdaugaTextButtonAdaugaLectie.Location.X, AdaugaTextButtonAdaugaLectie.Location.Y + 515);

                                AdaugaImaginePictureAdaugaLectie.Location = new Point(AdaugaImaginePictureAdaugaLectie.Location.X, AdaugaImagineButtonAdaugaLectie.Location.Y + 515);
                                AdaugaImagineButtonAdaugaLectie.Location = new Point(AdaugaImagineButtonAdaugaLectie.Location.X, AdaugaImagineButtonAdaugaLectie.Location.Y + 515);

                                AdaugaVideoPictureAdaugaLectie.Location = new Point(AdaugaVideoPictureAdaugaLectie.Location.X, AdaugaVideoButtonAdaugaLectie.Location.Y + 515);
                                AdaugaVideoButtonAdaugaLectie.Location = new Point(AdaugaVideoButtonAdaugaLectie.Location.X, AdaugaVideoButtonAdaugaLectie.Location.Y + 515);

                                SalveazaPictureAdaugaLectie.Location = new Point(SalveazaPictureAdaugaLectie.Location.X, SalveazaButtonAdaugaLectie.Location.Y + 515);
                                SalveazaButtonAdaugaLectie.Location = new Point(SalveazaButtonAdaugaLectie.Location.X, SalveazaButtonAdaugaLectie.Location.Y + 515);

                                videosAdaugaLectie[k1AdaugaLectie].Location = new Point(0, AdaugaVideoButtonAdaugaLectie.Location.Y - 515);
                            }


                        videosAdaugaLectie[k1AdaugaLectie].Size = new System.Drawing.Size(651, 484);
                        videosAdaugaLectie[k1AdaugaLectie].Visible = true;

                        PanelAdaugaLectie.Controls.Add(videosAdaugaLectie[k1AdaugaLectie]);

                        videosAdaugaLectie[k1AdaugaLectie].URL = locatiiAdaugaLectie[k1AdaugaLectie];
                        videosAdaugaLectie[k1AdaugaLectie].Ctlcontrols.stop();
                        k1AdaugaLectie++;

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
            if (k1AdaugaLectie != 0 || k2AdaugaLectie != 0 || kimgAdaugaLectie != 0)
            {
                if (NumeLectieAdaugaLectie.Text != "")
                {
                    richTextBox1AdaugaLectie.Text = "";
                    richTextBox2AdaugaLectie.Text = "";
                    richTextBox3AdaugaLectie.Text = "";

                    //MessageBox.Show(richTextBox4.Text);
                    for (int i = 0; i < k1AdaugaLectie; i++)
                    {
                        string poz = "", hjk = "", pozitii = "";
                        poz = PointToScreen(videosAdaugaLectie[i].Location).ToString();

                        hjk = poz.Substring(poz.IndexOf('=') + 1, poz.IndexOf(',') - poz.IndexOf('=') - 1);
                        hjk += ' ' + poz.Substring(poz.LastIndexOf('=') + 1, poz.Length - poz.LastIndexOf('=') - 2);

                        pozitii = pozitii + hjk + ' ' + '\n';

                        richTextBox1AdaugaLectie.Text += pozitii;
                    }

                    for (int i = 0; i < k2AdaugaLectie; i++)
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


                    for (int i = 0; i < k1AdaugaLectie; i++)
                    {
                        Directory.CreateDirectory(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text + "\\Video");

                        File.Copy(locatiiAdaugaLectie[i], Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text + "\\Video\\" + i + ".avi", true);

                        richTextBox1AdaugaLectie.SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text + "\\Video\\setari", RichTextBoxStreamType.PlainText);
                    }

                    for (int i = 0; i < k2AdaugaLectie; i++)
                    {
                        Directory.CreateDirectory(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text + "\\Text");

                        texteAdaugaLectie[i].SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text + "\\Text\\" + "T" + i, RichTextBoxStreamType.PlainText);

                        richTextBox2AdaugaLectie.SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text + "\\Text\\setari", RichTextBoxStreamType.PlainText);
                    }


                    if (kimgAdaugaLectie != 0)
                    {
                        Directory.CreateDirectory(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text + "\\Imagini\\");
                        for (int i = 0; i < kimgAdaugaLectie; i++)
                        {
                            string poz = "", hjk = "", pozitii = "";
                            poz = PointToScreen(imagineAdaugaLectie[i].Location).ToString();

                            hjk = poz.Substring(poz.IndexOf('=') + 1, poz.IndexOf(',') - poz.IndexOf('=') - 1);
                            hjk += ' ' + poz.Substring(poz.LastIndexOf('=') + 1, poz.Length - poz.LastIndexOf('=') - 2);

                            //pozitii = pozitii + hjk + ' ' + '\n';
                            pozitii += imagineAdaugaLectie[i].Location.X + " " + positionsAdaugaLectie[i] + '\n';
                            richTextBox3AdaugaLectie.Text += pozitii;

                            File.Copy(folderimgAdaugaLectie[i], Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text + "\\Imagini\\" + "imagine" + i + ".jpg", true);
                        }

                        richTextBox3AdaugaLectie.SaveFile(Application.StartupPath + "\\LectiiSiTeste\\Lectii\\" + numeleMateriei + "\\" + NumeLectieAdaugaLectie.Text + "\\Imagini\\" + "setari", RichTextBoxStreamType.PlainText);
                    }

                    changePanels(PanelAdaugaLectie, PanelListaLectiiSiTeste);
                    this.Text = "Lista lectii si teste";
                    RefreshListaLectiiSiTeste.Focus();
                    ascundeAdaugaLectie();
                    this.Width = 718;
                    this.Height = 350;
                    PanelVeziLectie.Width = 711;
                    PanelVeziLectie.Height = 321;

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

                        richTextBox4AdaugaLectie.Text += "T" + k2AdaugaLectie + '\n';

                        label1AdaugaLectie.Visible = false;
                        NumeLectieAdaugaLectie.Visible = false;
                        label5AdaugaLectie.Visible = false;
                        label4AdaugaLectie.Visible = false;
                        DetaliiAdaugaLectie.Hide();


                        texteAdaugaLectie[k2AdaugaLectie] = new RichTextBox();
                        texteAdaugaLectie[k2AdaugaLectie].BackColor = System.Drawing.Color.White;
                        texteAdaugaLectie[k2AdaugaLectie].ReadOnly = false;
                        texteAdaugaLectie[k2AdaugaLectie].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
                        texteAdaugaLectie[k2AdaugaLectie].Size = new System.Drawing.Size(665, 484);//(464, 10);
                        texteAdaugaLectie[k2AdaugaLectie].WordWrap = true;

                        if (of.FileName.Substring(of.FileName.LastIndexOf('.') + 1, of.FileName.Length - 1 - of.FileName.LastIndexOf('.')) == "txt")// ||
                            texteAdaugaLectie[k2AdaugaLectie].LoadFile(of.FileName, RichTextBoxStreamType.PlainText);
                        else
                            if (of.FileName.Substring(of.FileName.LastIndexOf('.') + 1, of.FileName.Length - 1 - of.FileName.LastIndexOf('.')) == "rtf")
                                texteAdaugaLectie[k2AdaugaLectie].LoadFile(of.FileName, RichTextBoxStreamType.PlainText);

                        texteAdaugaLectie[k2AdaugaLectie].BorderStyle = System.Windows.Forms.BorderStyle.None;




                        if (k2AdaugaLectie == 0 && k1AdaugaLectie == 0)
                        {
                            texteAdaugaLectie[k2AdaugaLectie].Location = new Point(0, 30);
                            //richTextBox2.Text = "0" + '\n';
                        }
                        else
                            if (k1AdaugaLectie == 0 && k2AdaugaLectie == 1)
                            {
                                texteAdaugaLectie[k2AdaugaLectie].Location = new Point(0, AdaugaImagineButtonAdaugaLectie.Location.Y - 25);
                            }
                            else
                            {
                                texteAdaugaLectie[k2AdaugaLectie].Location = new Point(0, AdaugaImagineButtonAdaugaLectie.Location.Y + 10);
                            }


                        //inaltimea richtextboxului
                        pos.X = ClientRectangle.Width;
                        pos.Y = ClientRectangle.Height;
                        int lastIndex = texteAdaugaLectie[k2AdaugaLectie].GetCharIndexFromPosition(pos);
                        int lastLine = texteAdaugaLectie[k2AdaugaLectie].GetLineFromCharIndex(lastIndex) + 1;
                        texteAdaugaLectie[k2AdaugaLectie].Height = lastLine * 14;

                        texteAdaugaLectie[k2AdaugaLectie].BorderStyle = System.Windows.Forms.BorderStyle.None;

                        texteAdaugaLectie[k2AdaugaLectie].Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                        PanelAdaugaLectie.Controls.Add(texteAdaugaLectie[k2AdaugaLectie]);


                        AdaugaImaginePictureAdaugaLectie.Location = new Point(AdaugaImaginePictureAdaugaLectie.Location.X, AdaugaImagineButtonAdaugaLectie.Location.Y + texteAdaugaLectie[0].Height + 20);
                        AdaugaImagineButtonAdaugaLectie.Location = new Point(AdaugaImagineButtonAdaugaLectie.Location.X, AdaugaImagineButtonAdaugaLectie.Location.Y + texteAdaugaLectie[0].Height + 20);

                        AdaugaVideoPictureAdaugaLectie.Location = new Point(AdaugaVideoPictureAdaugaLectie.Location.X, AdaugaVideoButtonAdaugaLectie.Location.Y + texteAdaugaLectie[0].Height + 20);
                        AdaugaVideoButtonAdaugaLectie.Location = new Point(AdaugaVideoButtonAdaugaLectie.Location.X, AdaugaVideoButtonAdaugaLectie.Location.Y + texteAdaugaLectie[0].Height + 20);

                        SalveazaPictureAdaugaLectie.Location = new Point(SalveazaPictureAdaugaLectie.Location.X, SalveazaButtonAdaugaLectie.Location.Y + texteAdaugaLectie[0].Height + 20);
                        SalveazaButtonAdaugaLectie.Location = new Point(SalveazaButtonAdaugaLectie.Location.X, SalveazaButtonAdaugaLectie.Location.Y + texteAdaugaLectie[0].Height + 20);

                        AdaugaTextPictureAdaugaLectie.Location = new Point(AdaugaTextPictureAdaugaLectie.Location.X, AdaugaTextButtonAdaugaLectie.Location.Y + texteAdaugaLectie[0].Height + 20);
                        AdaugaTextButtonAdaugaLectie.Location = new Point(AdaugaTextButtonAdaugaLectie.Location.X, AdaugaTextButtonAdaugaLectie.Location.Y + texteAdaugaLectie[0].Height + 20);

                        k2AdaugaLectie++;

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

                        AdaugaVideoButtonAdaugaLectie.BackColor = Color.LightSteelBlue;
                        AdaugaTextButtonAdaugaLectie.BackColor = Color.LightSteelBlue;
                        AdaugaImagineButtonAdaugaLectie.BackColor = Color.LightSteelBlue;
                        SalveazaButtonAdaugaLectie.BackColor = Color.LightSteelBlue;

                    }
                }
                else
                {
                    MessageBox.Show("Nume deja existent!" + '\n' + "Introduceți alt nume!");
                }
            }
        }

        private void pictureBox1_MouseDownAdaugaLectie(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            for (int i = 0; i < kimgAdaugaLectie; i++)
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
            for (int i = 0; i < kimgAdaugaLectie; i++)
            {
                if (sender.Equals(imagineAdaugaLectie[i]))
                {
                    //MessageBox.Show(AutoScrollPosition.Y.ToString());
                    positionsAdaugaLectie[i] = 0 - PanelAdaugaLectie.AutoScrollPosition.Y + imagineAdaugaLectie[i].Location.Y;
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
            for (int i = 0; i < kimgAdaugaLectie; i++)
            {
                if (sender.Equals(imagineAdaugaLectie[i]))
                {
                    imagineAdaugaLectie[i].Left += e.X - pozitiaAdaugaLectie.X;
                    imagineAdaugaLectie[i].Top += e.Y - pozitiaAdaugaLectie.Y;
                }
            }
        }

        private void GoBackAdaugaLectie_Click(object sender, EventArgs e)
        {
            changePanels(PanelListaLectiiSiTeste, PanelAdaugaLectie);
            RefreshListaLectiiSiTeste.Focus();
            this.Text = "Lista lectii si teste";
            ascundeAdaugaLectie();
            
            this.Width = 718;
            this.Height = 350;
            PanelVeziLectie.Width = 711;
            PanelVeziLectie.Height = 321;
        }


        //caz particular pentru care elevul inca are un test de dat
        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Deschidere.Default.aDeschisUnTest == true)
            {
                if (AmTerminatButtonTestElev.Enabled == true && aApasatPeIncepe == true)
                {
                    if (MessageBox.Show("Daca iesi, punctajul tau va fi stabilit in urma raspunsurilor date pana acum!" +
                        '\n' + "Esti sigur ca vrei sa renunti?", "ATENTIE!!!",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        AmTerminatButtonTestElev.PerformClick();
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
                    if (AmTerminatButtonTestElev.Enabled == false)
                    {
                        AmTerminatButtonTestElev.PerformClick();
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




        //Here starts Unelte ***********************************************************************************
        
        //Here starts Calculator *******************************************************************************

        public string ecuatieCalculator, copieCalculator;
        public double rezultatCalculator;
        public bool rezultatCalculatCalculator = false;

        private void incarcaCalculator()
        {
            ecuatieCalculator = ""; copieCalculator = "";
            rezultatCalculator = 0;
            rezultatCalculatCalculator = false;
            RezultatInput.Text = "";
        }

        public void golesteTot_Click(object sender, EventArgs e)
        {
            RezultatInput.Clear();
            rezultatCalculatCalculator = false;
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
                int invalid = copieCalculator.IndexOf('=');
                if (invalid == -1)
                {
                    RezultatInput.Text = copieCalculator + " = " + rezultatCalculator.ToString();
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
            if (rezultatCalculatCalculator)
            {
                RezultatInput.Clear();
                RezultatInput.Text += rezultatCalculator;
                rezultatCalculatCalculator = false;
            }
            RezultatInput.Text += c;
        }

        public void faCalcule()
        {
            ecuatieCalculator = RezultatInput.Text.ToString();
            copieCalculator = ecuatieCalculator;
            try
            {
                ScriereaPoloneza sc = new ScriereaPoloneza();
                rezultatCalculator = Convert.ToDouble(sc.calculeazaToateParantezele(ecuatieCalculator));
                ecuatieCalculator = rezultatCalculator.ToString();
            }
            catch
            {
                ecuatieCalculator = "Eroare!";
            }
            finally
            {
                rezultatCalculatCalculator = true;
                RezultatInput.Text = ecuatieCalculator;
            }
        }

        public void calculeaza1pex_Click(object sender, EventArgs e)
        {
            faCalcule();
            try
            {
                rezultatCalculator = 1 / rezultatCalculator;
                rezultatCalculatCalculator = true;
                RezultatInput.Text = rezultatCalculator.ToString();
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
                rezultatCalculator = rezultatCalculator * rezultatCalculator;
                rezultatCalculatCalculator = true;
                RezultatInput.Text = rezultatCalculator.ToString();
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
                rezultatCalculator = rezultatCalculator * rezultatCalculator * rezultatCalculator;
                rezultatCalculatCalculator = true;
                RezultatInput.Text = rezultatCalculator.ToString();
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
                if (rezultatCalculator > 0)
                {
                    for (int i = 1; i <= rezultatCalculator; i++)
                        rez *= i;
                }
                rezultatCalculator = rez;
                rezultatCalculatCalculator = true;
                RezultatInput.Text = rezultatCalculator.ToString();
            }
            catch { }
        }

        public void calculeazaRadical_Click(object sender, EventArgs e)
        {
            faCalcule();
            try
            {
                double rez = 0;
                if (rezultatCalculator > 0)
                {
                    rez = Math.Sqrt(rezultatCalculator);
                }
                rezultatCalculator = rez;
                rezultatCalculatCalculator = true;
                RezultatInput.Text = rezultatCalculator.ToString();
            }
            catch { }
        }

        public void calculeazaCos_Click(object sender, EventArgs e)
        {
            faCalcule();
            try
            {
                double rez = 0;
                if (rezultatCalculator > 0)
                {
                    rez = Math.Cos(rezultatCalculator);
                }
                rezultatCalculator = rez;
                rezultatCalculatCalculator = true;
                RezultatInput.Text = rezultatCalculator.ToString();
            }
            catch { }
        }

        public void calculeazaSinus_Click(object sender, EventArgs e)
        {
            faCalcule();
            try
            {
                double rez = 0;
                if (rezultatCalculator > 0)
                {
                    rez = Math.Sin(rezultatCalculator);
                }
                rezultatCalculator = rez;
                rezultatCalculatCalculator = true;
                RezultatInput.Text = rezultatCalculator.ToString();
            }
            catch { }
        }

        public void calculeazaCotangenta_Click(object sender, EventArgs e)
        {
            faCalcule();
            try
            {
                double rez = 0;
                if (rezultatCalculator > 0)
                {
                    rez = Math.Cos(rezultatCalculator) / Math.Sin(rezultatCalculator);
                }
                rezultatCalculator = rez;
                rezultatCalculatCalculator = true;
                RezultatInput.Text = rezultatCalculator.ToString();
            }
            catch { }
        }

        public void calculeazaTangenta_Click(object sender, EventArgs e)
        {
            faCalcule();
            try
            {
                double rez = 0;
                if (rezultatCalculator > 0)
                {
                    rez = Math.Tan(rezultatCalculator);
                }
                rezultatCalculator = rez;
                rezultatCalculatCalculator = true;
                RezultatInput.Text = rezultatCalculator.ToString();
            }
            catch { }
        }









        //Here starts ecuatie *******************************************************************************

        string ecuatie = "", ecuatii1 = "", ecuatii2 = "";
        int uyt9 = 0;//sa stiu cat scad din ecuatie

        private void incarcaEcuatie()
        {
            ecuatie = "";
            ecuatii1 = "";
            ecuatii2 = "";
            uyt9 = 0;
            textBox1Ecuatie.Clear();
            textBox4Ecuatie.Clear();
            textBox5Ecuatie.Clear();
            textBox6Ecuatie.Clear();
            textBox7Ecuatie.Clear();
            textBox8Ecuatie.Clear();
            textBox9Ecuatie.Clear();
            textBox10Ecuatie.Clear();
            textBox11Ecuatie.Clear();
            textBox12Ecuatie.Clear();

            LabelX1.Hide();
            LabelX21.Hide();
            LabelX22.Hide();
            LabelX31.Hide();
            LabelX32.Hide();
            LabelX33.Hide();

        }

        private void button1_ClickEcuatie(object sender, EventArgs e)
        {
            bool tr = false;
            string u = "qwertyuiopasfdghjklzcvbnm";
            for (int o = 0; o < textBox1Ecuatie.Text.Length; o++)
            {
                for (int j = 0; j < 25; j++)
                {
                    if (textBox1Ecuatie.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }

            if (tr == true)
            {
                MessageBox.Show("Introduceti numai numere!");
            }

            if (tr == false)
                if (textBox1Ecuatie.Text != "")
                {


                    stergeSpatiiEcuatie();
                    //ecuatie = textBox1.Text;
                    //label3.Text = ecuatie;
                    if (textBox1Ecuatie.Text != "")
                    {
                        bool sePoate = false;
                        string[] ecuatii = textBox1Ecuatie.Text.Split('=');
                        //verifica daca exista egal
                        if (textBox1Ecuatie.Text.IndexOf('=') != -1)
                        {
                            ecuatii1 = ecuatii[0];
                            ecuatie = ecuatii1;
                            ecuatii2 = ecuatii[1];
                            sePoate = true;
                        }
                        else
                        {
                            sePoate = false;
                        }
                        if (sePoate == true)
                        {
                            string eec = ecuatii1;
                            string sss = ecuatii1;
                            int uyt = 0;
                            //verifica daca gaseste paranteza sau pe x, sa ii puna 1* inainte pentru orice eventualitate
                            for (int i = 0; i < eec.Length; i++)
                            {
                                if (eec[i] == '(' || eec[i] == '[' || eec[i] == '{' || eec[i] == 'x')
                                {
                                    sss = sss.Insert(i + uyt, "1*");
                                    uyt++;
                                    uyt++;
                                }
                            }
                            ecuatii1 = sss;

                            eec = ecuatii2;
                            sss = ecuatii2;
                            uyt = 0;
                            for (int i = 0; i < eec.Length; i++)
                            {
                                if (eec[i] == '(' || eec[i] == '[' || eec[i] == '{' || eec[i] == 'x')
                                {
                                    sss = sss.Insert(i + uyt, "1*");
                                    uyt++;
                                    uyt++;
                                }
                            }
                            ecuatii2 = sss;


                            //aduc la acelasi numitor
                            /*string intermediar="";
                            int[] numitori = new int[40];//va retine toti numitorii, pentru a stii care sunt
                                                    //cand voi aduce la acelasi numitor
                            int[] numitorri = new int[40];//va retine numitorii care nu se repeta, pentru
                                                    //a putea calcula numitorul comun
                            int k = 0, g = 0;//k=numarul total de numitori
                                             //g=numarul de numitori care nu se repeta
                        
                            //caut si notez care sunt numitorii
                            for (int i = 0; i < ecuatii1.Length; i++)
                            {
                                if (ecuatii1[i] == '/')
                                {
                                    int j = i + 1;
                                    while (j<ecuatii1.Length && (ecuatii1[j] == '0' || ecuatii1[j] == '1' || 
                                        ecuatii1[j] == '2' || ecuatii1[j] == '3' || ecuatii1[j] == '4' || 
                                        ecuatii1[j] == '5' || ecuatii1[j] == '6' || ecuatii1[j] == '7' || 
                                        ecuatii1[j] == '8' || ecuatii1[j] == '9'))
                                    {
                                        intermediar += ecuatii1[j];
                                        j++;
                                    }
                                
                                    //daca este primul numitor, atunci il retine, pentru ca altfel nu
                                    //va intra in urmatorul for
                                    if (g == 0)
                                    {
                                        numitorri[0] = Convert.ToInt32(intermediar);
                                        g++;
                                    }
                                
                                    bool salal = false;
                                    //salal va retine daca numitorul a mai existat pana acum
                                    for (int h = 0; h < g; h++)
                                    {
                                        if (numitorri[h] == Convert.ToInt32(intermediar))
                                        {
                                            salal = true;
                                        }
                                    }
                                    //daca numitorul nu a mai aparut atunci o sa il notez
                                    if (salal == false)
                                    {
                                        numitorri[g] = Convert.ToInt32(intermediar);
                                        g++;
                                    }
                                    numitori[k] = Convert.ToInt32(intermediar);
                                    k++;
                                    intermediar = "";
                                }
                            }
                        
                            for (int i = 0; i < ecuatii2.Length; i++)
                            {
                                if (ecuatii2[i] == '/')
                                {
                                    int j = i + 1;
                                    while (j < ecuatii2.Length && (ecuatii2[j] == '0' || ecuatii2[j] == '1' ||
                                        ecuatii2[j] == '2' || ecuatii2[j] == '3' || ecuatii2[j] == '4' ||
                                        ecuatii2[j] == '5' || ecuatii2[j] == '6' || ecuatii2[j] == '7' ||
                                        ecuatii2[j] == '8' || ecuatii2[j] == '9'))
                                    {
                                        intermediar += ecuatii2[j];
                                        j++;
                                    }
                                
                                    //daca este primul numitor, atunci il retine, pentru ca altfel nu
                                    //va intra in urmatorul for
                                    if (g == 0)
                                    {
                                        numitorri[0] = Convert.ToInt32(intermediar);
                                        g++;
                                    }
                                
                                    bool salal = false;
                                    //salal va retine daca numitorul a mai existat pana acum
                                    for (int h = 0; h < g; h++)
                                    {
                                        if (numitorri[h] == Convert.ToInt32(intermediar))
                                        {
                                            salal = true;
                                        }
                                        else
                                            if (numitorri[h] % Convert.ToInt32(intermediar) == 0)
                                            {
                                                salal = true;
                                            }
                                            else
                                                if (Convert.ToInt32(intermediar) % numitorri[h] == 0)
                                                {
                                                    salal = true;
                                                    numitorri[h] = Convert.ToInt32(intermediar);
                                                }
                                    }
                                    //daca numitorul nu a mai aparut atunci o sa il notez
                                    if (salal == false)
                                    {
                                        numitorri[g] = Convert.ToInt32(intermediar);
                                        g++;
                                    }
                                    numitori[k] = Convert.ToInt32(intermediar);
                                    k++;
                                    intermediar = "";
                                }
                            }
                            //calculez numitorul comun
                            int numitor = 1;
                            for (int i = 0; i < g; i++)
                            {
                                numitor *= numitorri[i];
                            }

                            string sd = ecuatii1;
                            int uy = 0, sterse = 0, f = 0;
                            //f va retine numarul numitorului corespunzator fiecarui "/"
                            for (int i = 0; i < ecuatii1.Length; i++)
                            {
                                if (ecuatii1[i] == '/')
                                {
                                    int j = i + 1;
                                    while (j < ecuatii1.Length)
                                    {
                                        if (sd[j - uy] == '0' || sd[j - uy] == '1' ||
                                            sd[j - uy] == '2' || sd[j - uy] == '3' || sd[j - uy] == '4' ||
                                            sd[j - uy] == '5' || sd[j - uy] == '6' || sd[j - uy] == '7' ||
                                            sd[j - uy] == '8' || sd[j - uy] == '9')
                                        {
                                            sterse++;
                                            j++;
                                        }
                                        else
                                            break;
                                    }
                                    int nr1 = numitori[f], nr2;
                                    nr2 = numitor/numitori[f];
                                    sd = sd.Remove(i - uy, numitori[f].ToString().Length + 1);
                                    sd = sd.Insert(i - uy, "*" + nr2.ToString());
                                    uy += sterse;
                                    uy -= nr2.ToString().Length;
                                    sterse = 0;
                                    f++;
                                }
                            }
                            ecuatii1 = sd;


                            sd = ecuatii2;
                            uy = 0;
                            sterse = 0;
                            f = 0;
                            //f va retine numarul numitorului corespunzator fiecarui "/"
                            for (int i = 0; i < ecuatii2.Length; i++)
                            {
                                if (ecuatii2[i] == '/')
                                {
                                    int j = i + 1;
                                    while (j < ecuatii2.Length)
                                    {
                                        if (sd[j - uy] == '0' || sd[j - uy] == '1' ||
                                            sd[j - uy] == '2' || sd[j - uy] == '3' || sd[j - uy] == '4' ||
                                            sd[j - uy] == '5' || sd[j - uy] == '6' || sd[j - uy] == '7' ||
                                            sd[j - uy] == '8' || sd[j - uy] == '9')
                                        {
                                            sterse++;
                                            j++;
                                        }
                                        else
                                            break;
                                    }
                                    int nr1 = numitori[f], nr2;
                                    nr2 = numitor / numitori[f];
                                    sd = sd.Remove(i - uy, numitori[f].ToString().Length + 1);
                                    sd = sd.Insert(i - uy, "*" + nr2.ToString());
                                    uy += sterse;
                                    uy -= nr2.ToString().Length;
                                    sterse = 0;
                                    f++;
                                }
                            }
                            ecuatii2 = sd;
                        
                        


                            //MessageBox.Show("ecuatia este ecuatii    " + ecuatii1+'\n'+ecuatii2);
                            */

                            //ecuatie ia valoarea membrului stang
                            //se calculeaza membrul stang
                            ecuatie = ecuatii1;
                            calculeazaMembreEcuatie(ecuatii1);
                            //label2.Text = ecuatie;
                            string membruStang = ecuatie;

                            //se calculeaza membrul drept
                            ecuatie = ecuatii2;
                            calculeazaMembreEcuatie(ecuatii2);
                            //label3.Text = ecuatie;
                            string membruDrept = ecuatie;


                            string membru = "";
                            //pun + inainte pentru ca sa fac calcule corect mai tarziu
                            if (membruDrept[0] != '-')
                            {
                                membruDrept = membruDrept.Insert(0, "+");
                            }

                            //fiind in membrul drept voi schimba semnele pentru a le trece in membrul stang
                            membruDrept = ReverseSemnEcuatie(membruDrept);

                            string cop;
                            string s = membruStang + membruDrept; uyt9 = 0; ecuatie = s;
                            cop = s;
                            //calculeaza dupa ce a trecut membrul drept in partea stanga
                            calculeazaMembreEcuatie(s);
                            //label1.Text = ecuatie;

                            string cope = ecuatie, s5 = "", s6 = "";
                            for (int i = cope.Length - 1; i >= 0; i--)
                            {
                                if (ecuatie[i] == 'x')
                                {
                                    int j = i - 2;
                                    while (j >= 0 && ecuatie[j] != '+' && ecuatie[j] != '-' &&
                                        ecuatie[j] != '(' && ecuatie[j] != '[' && ecuatie[j] != '{')
                                    {
                                        s5 += ecuatie[j];
                                        j--;
                                    }
                                    s5 += ecuatie[j];
                                    i = j;
                                }
                                else
                                {
                                    s6 += ecuatie[i];
                                }
                            }
                            s5 = ReverseStringEcuatie(s5);
                            s6 = ReverseStringEcuatie(s6);
                            double raspuns = 0;
                            //MessageBox.Show(s5 + "     " + s6);
                            try
                            {

                                raspuns = (Convert.ToDouble(s6) * (-1)) / Convert.ToDouble(s5);
                            }
                            catch (Exception ex)
                            {
                                //MessageBox.Show(ex.ToString());
                            }
                            LabelX1.Show();
                            LabelX1.Text = raspuns.ToString();
                            uyt9 = 0;
                            //label4.Text = raspuns.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Introduceti ecuatia!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Introduceti ecuatia!");
                    }
                }
                else
                {
                    MessageBox.Show("Introduceti ecuatia!");
                }
        }

        public void inmultesteTermeniIEcuatie(int poz11, int ii)
        {
            //desfac parantezele care pot, 
            string s = ecuatie;
            if (inmultiriParantezeEcuatie(poz11, ii) != "")
            {
                //falala va contine operatiile din jurul parantezelor : 3*2(1+2x)/4*5 ( 3*2/4*5)
                string falala = inmultiriParantezeEcuatie(poz11, ii);
                //fala1=pozitia cea mai la stanga a termenului cu care se inmuleteste : 3*2*(1+2x) (pozitia lui 3)
                string fala1 = falala.Substring(falala.LastIndexOf(' '), falala.Length - falala.LastIndexOf(' '));
                falala = falala.Remove(falala.LastIndexOf(' '), falala.Length - falala.LastIndexOf(' '));
                //fala2=pozitia cea mai la dreapta a termenului cu care se inmulteste : (1+2x)*3*2 (pozitia lui 2)
                string fala2 = falala.Substring(falala.LastIndexOf(' '), falala.Length - falala.LastIndexOf(' '));

                falala = falala.Remove(falala.LastIndexOf(' '), falala.Length - falala.LastIndexOf(' '));

                int uy = 0, sterse = 1;
                string sd = falala, dupa = "";


                if (sd == "")
                {
                    sd = "1";
                }
                if (sd[0] == '/')
                {
                    sd = sd.Insert(0, "1");
                }
                string calculll = "";
                //calculele termenilor de langa paranteze + semnul de dinaintea parantezei + paranteza
                calculll = faCalculeEcuatie(sd) + '*' + s.Substring(poz11, ii - poz11 + 1);// +dupa;


                int po1 = Convert.ToInt32(fala1), po2 = Convert.ToInt32(fala2);
                string asd = s.Substring(poz11, ii - poz11 + 1);

                ecuatie = ecuatie.Remove(po1, po2 - po1 + 1);
                uyt9 += po2 - po1 + 1;
                ecuatie = ecuatie.Insert(po1, calculll);
                uyt9 -= calculll.Length;
            }
        }

        public void calculeazaParantezeIEcuatie(int poz11, int ii)
        {
            string s = ecuatie.Substring(poz11, ii - poz11 + 1);
            bool skip = false;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == 'x')
                {
                    skip = true;
                    break;
                }
            }
            //daca nu a gasit pe x atunci poate face calculele in paranteza
            if (skip == false)
            {
                s = faCalculeEcuatie(s);
                ecuatie = ecuatie.Remove(poz11, ii - poz11 + 1);
                uyt9 += ii - poz11 + 1;
                ecuatie = ecuatie.Insert(poz11, s);
                uyt9 -= s.Length;
            }
        }

        public void calculeazaMembreEcuatie(string falala)
        {
            uyt9 = 0;

            int poz1 = -1, poz2 = -1, poz3 = -1;//poz1=( poz2=[ poz3={
            string s = falala;
            //salvez pozitiile unde gaseste inceputul de paranteze si dupa aceea fac calculele de unde gaseste sfarsitul
            //parantezei face calculele pana la pozitia memorata
            for (int i = 0; i < falala.Length; i++)
            {

                if (s[i] == '(')
                {
                    poz1 = i - uyt9;
                }

                if (s[i] == '[')
                {
                    poz2 = i - uyt9;
                }

                if (s[i] == '{')
                {
                    poz3 = i - uyt9;
                }


                if (s[i] == '}')
                {
                    calculeazaParantezeIEcuatie(poz3, i - uyt9);
                }

                if (s[i] == ']')
                {
                    calculeazaParantezeIEcuatie(poz2, i - uyt9);
                }

                if (s[i] == ')')
                {
                    calculeazaParantezeIEcuatie(poz1, i - uyt9);
                }
            }

            falala = ecuatie;
            uyt9 = 0;
            s = falala;

            for (int i = 0; i < falala.Length; i++)
            {
                if (s[i] == 'x')
                {
                    inmultesteTermeniIEcuatie(i - uyt9, i - uyt9);
                }

                if (s[i] == '(')
                {
                    poz1 = i - uyt9;
                }

                if (s[i] == '[')
                {
                    poz2 = i - uyt9;
                }

                if (s[i] == '{')
                {
                    poz3 = i - uyt9;
                }


                if (s[i] == '}')
                {
                    inmultesteTermeniIEcuatie(poz3, i - uyt9);
                }

                if (s[i] == ']')
                {
                    inmultesteTermeniIEcuatie(poz2, i - uyt9);
                }

                if (s[i] == ')')
                {
                    inmultesteTermeniIEcuatie(poz1, i - uyt9);
                }
            }

            falala = ecuatie;
            uyt9 = 0;
            s = falala;

            for (int i = 0; i < falala.Length; i++)
            {

                if (s[i] == '(')
                {
                    poz1 = i - uyt9;
                }

                if (s[i] == '[')
                {
                    poz2 = i - uyt9;
                }

                if (s[i] == '{')
                {
                    poz3 = i - uyt9;
                }


                if (s[i] == '}')
                {
                    calculeazaParantezeEcuatie(poz3, i - uyt9);
                }

                if (s[i] == ']')
                {
                    calculeazaParantezeEcuatie(poz2, i - uyt9);
                }

                if (s[i] == ')')
                {
                    calculeazaParantezeEcuatie(poz1, i - uyt9);
                }
            }


            falala = ecuatie;
            uyt9 = 0;
            s = falala;

            for (int i = 0; i < falala.Length; i++)
            {

                if (s[i] == '(')
                {
                    poz1 = i - uyt9;
                }

                if (s[i] == '[')
                {
                    poz2 = i - uyt9;
                }

                if (s[i] == '{')
                {
                    poz3 = i - uyt9;
                }


                if (s[i] == '}')
                {
                    desfaceParantezeEcuatie(poz3, i - uyt9);
                }

                if (s[i] == ']')
                {
                    desfaceParantezeEcuatie(poz2, i - uyt9);
                }

                if (s[i] == ')')
                {
                    desfaceParantezeEcuatie(poz1, i - uyt9);
                }
            }

            /*
                 int j = i;
                    while (s[j] != '{')
                    {
                        j--;
                    }
                    poz3 = j - uyt9;
                    
                    inmultesteTermeni(poz3, i - uyt9);

                    j = i;
                    while (s[j] != '{')
                    {
                        j--;
                    }
                    poz3 = j - uyt9; 
                    
                    calculeazaParanteze(poz3, i - uyt9);

                    j = i;
                    while (s[j] != '{')
                    {
                        j--;
                    }
                    poz3 = j - uyt9;

                    desfaceParanteze(poz3, i - uyt9);
                */


            ////MessageBox.Show(ecuatie + "             " + 1);

            if (ecuatie[0] == '+')
            {
                ecuatie = ecuatie.Remove(0, 1);
                uyt9++;
            }
            calculeFinaleEcuatie();
            string membruStang = ecuatie;
            //MessageBox.Show("ecuatie in calculeaza membre    " + ecuatie);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lala">membrul drept</param>
        public string ReverseSemnEcuatie(string lala)
        {
            string s = lala;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '+')
                {
                    s = s.Remove(i, 1);
                    s = s.Insert(i, "-");
                }
                else
                    if (s[i] == '-')
                    {
                        s = s.Remove(i, 1);
                        s = s.Insert(i, "+");
                    }
            }
            return s;
        }

        public void calculeFinaleEcuatie()
        {
            string s = ecuatie;
            string s1 = "";
            int i = ecuatie.Length - 1;

            while (i >= 0)
            {
                if (s[i] == 'x')
                {
                    /*if (i - 1 > 0)
                    {
                        if (s[i - 1] != '*')
                        {
                            s = s.Insert(i, "1*");
                        }
                    }
                    else
                    {*/
                    s = s.Insert(i, "1*");
                    //}
                }
                i--;
            }
            ecuatie = s;
            //MessageBox.Show("ecuatie:          " + ecuatie);
            i = s.Length - 1;
            //retin care sunt termenii care contin pe x si cei care nu il contin, dupa care fac calcule intre ei
            while (i >= 0)
            {
                if (s[i] == 'x')
                {
                    int j = i - 2;
                    while (j >= 0 && s[j] != '+' && s[j] != '-' && s[j] != '(' && s[j] != '['
                            && s[j] != '{')
                    {
                        s1 += s[j];
                        j--;
                    }
                    if (j >= 0)
                    {
                        if (s[j] == '+' || s[j] == '-')
                        {
                            s1 += s[j];
                        }
                    }
                }
                i--;
            }
            s1 = ReverseStringEcuatie(s1);
            if (s1 != "")
            {
                if (s1[0] == '+')
                {
                    s1 = s1.Remove(0, 1);
                }
            }
            if (s1 != "")
            {
                s1 = faCalculeEcuatie(s1) + "*x";
            }
            else
            {
                s1 = "0*x";
            }

            if (s1[0] != '-')
            {
                s1 = s1.Insert(0, "+");
            }
            string s2 = "";
            i = s.Length - 1;
            while (i >= 0)
            {
                if (s[i] == 'x')
                {
                    int j = i - 1;
                    while (j >= 0 && s[j] != '+' && s[j] != '-' && s[j] != '(' && s[j] != '['
                                && s[j] != '{')
                    {
                        j--;
                    }
                    i = j;
                }
                else
                {
                    s2 += s[i];
                }
                i--;
            }
            s2 = ReverseStringEcuatie(s2);
            s2 = faCalculeEcuatie(s2);
            string s3 = s2 + s1;
            ecuatie = s3;
        }

        /// <summary>
        /// desface parantezele
        /// </summary>
        /// <param name="poz11"></param>
        /// <param name="ii"></param>
        public void desfaceParantezeEcuatie(int poz11, int ii)
        {
            //MessageBox.Show("ecuatie la inceputul desface paranteze    " + ecuatie);
            int uyt = 0, poz22 = poz11;
            string ecuatie2 = ecuatie;
            string s = ecuatie;
            string s1 = s.Substring(poz11, ii - poz11 + 1), s2 = "", s3 = "", s4 = "";
            //s2 pentru termeni liberi si s3 pentru termenii care contin pe x
            int j = poz11 - 1;
            while (j >= 0 && s[j] != '+' && s[j] != '-' && s[j] != '(' && s[j] != ')' && s[j] != '['
                        && s[j] != ']' && s[j] != '{' && s[j] != '}')
            {
                //terbuie sa fie diferit de primul semn de langa paranteza pentru ca poate fi * sau /
                if (j != poz11 - 1)
                {
                    s2 += s[j];
                }
                j--;
            }
            //poz22=pozitia de unde o sa sterg paranteza, pentru ca inainte de paranteza pot fi niste
            //termeni ai unei inmultiri
            if (j >= 0)
            {
                if (j != poz11 - 1)
                {
                    poz22 = j;
                }
                else
                {
                    //daca se afla imediat langa paranteza si este + sau - trebuie sa incep inlocuirea de 
                    //la acea pozitie
                    if (s[j] == '+' || s[j] == '-')
                    {
                        poz22 = j;
                    }
                }
            }
            else
            {
                poz22 = 0;
            }

            ////MessageBox.Show("poz22    " + poz22+"       poz11    "+ poz11);
            //daca inainte de paranteza este doar un + sau -
            if (s2 == "")
            {
                s2 = "1";
            }
            if (j >= 0)
            {
                if (s[j] == '-')
                {
                    s2 += '-';
                }
            }

            s2 = ReverseStringEcuatie(s2);
            j = 1;
            char semn;
            //vad care este semnul primului numar pentru a vedea cum sa fac inmultirea cu 
            //termenul liber din afara parantezei
            if (s1[j] == '-')
            {
                semn = '-';
                //il fac pe j++ pentru ca altfel nu o sa intre in urmatorul while
                j++;
            }
            else
                if (s1[j] == '+')
                {
                    semn = '+';
                    j++;
                }
                else
                {
                    semn = '+';
                }

            while (j < s1.Length && s1[j] != '+' && s1[j] != '-' && s1[j] != ')' && s1[j] != ']' && s1[j] != 'x' &&
                         s1[j] != '[' && s1[j] != '(' && s1[j] != '{' && s1[j] != '}')
            {
                s3 += s1[j];
                //verific daca urmatorul caracter este x sau este un + sau -
                if (j + 1 < s1.Length)
                {
                    if (s1[j + 1] == 'x')
                    {
                        //sterg ultimul caracter
                        s3 = s3.Remove(s3.Length - 1, 1);
                        s4 = s4 + semn + faCalculeEcuatie(s2 + "*" + s3) + "*x";
                        //vad care este semnul urmatorului numar
                        if (j + 2 < s1.Length)
                        {
                            if (s[j + 2] == '+')
                            {
                                semn = '+';
                            }
                            else
                                if (s[j + 2] == '-')
                                {
                                    semn = '-';
                                }
                            j += 2;
                        }
                        //reinitializez numarul
                        s3 = "";
                    }
                    else
                        if (s1[j + 1] == '+')
                        {
                            s4 = s4 + semn + faCalculeEcuatie(s2 + "*" + s3);
                            semn = '+';
                            s3 = "";
                            j++;
                        }
                        else
                            if (s1[j + 1] == '-')
                            {
                                s4 = s4 + semn + faCalculeEcuatie(s2 + "*" + s3);
                                semn = '-';
                                j++;
                                s3 = "";
                            }
                }
                j++;
            }

            s3 = "";
            j++;
            //fac un for in care daca gaseste +- sa il inlocuiasca cu -, sau daca gaseste -- sa il inlocuiasca cu +
            string ss4 = s4;
            int uyt4 = 0;
            for (int i = 0; i < s4.Length; i++)
            {
                if (s4[i] == '+' && i + 1 < s4.Length)
                {
                    if (s4[i + 1] == '+')
                    {
                        ss4 = ss4.Remove(i - uyt4, 2);
                        ss4 = ss4.Insert(i - uyt4, "+");
                        uyt4++;
                        //MessageBox.Show("primul if");
                    }

                    if (s4[i + 1] == '-')
                    {
                        ss4 = ss4.Remove(i - uyt4, 2);
                        ss4 = ss4.Insert(i - uyt4, "-");
                        uyt4++;
                        //MessageBox.Show("al treilea if");
                    }
                }
                else
                    if (s4[i] == '-' && i + 1 < s4.Length)
                    {
                        if (s4[i + 1] == '+')
                        {
                            ss4 = ss4.Remove(i - uyt4, 2);
                            ss4 = ss4.Insert(i - uyt4, "-");
                            uyt4++;
                            //MessageBox.Show("al doilea if");
                        }

                        if (s4[i + 1] == '-')
                        {
                            ss4 = ss4.Remove(i - uyt4, 2);
                            ss4 = ss4.Insert(i - uyt4, "+");
                            uyt4++;
                            //MessageBox.Show("al patrulea if");
                        }
                    }
            }
            s4 = ss4;
            //MessageBox.Show("acesta numar este s4    " + s4 + "        ecuatia   " + ecuatie);
            ecuatie = ecuatie.Remove(poz22, ii - poz22 + 1);
            ecuatie = ecuatie.Insert(poz22, s4);
            uyt9 += ii - poz22 + 1;
            uyt9 -= s4.Length;
            //MessageBox.Show("ecuatie in desface paranteze    " + ecuatie);
        }

        /// <summary>
        /// calculeaza termenii liberi din jurul parantezelor : 2/(1+2x)*3 = 6/(1+2x)
        /// </summary>
        /// <param name="poz11">pozitia de unde incepe paranteza</param>
        /// <param name="ii">pozitia de unde se termina paranteza</param>
        public void inmultesteTermeniEcuatie(int poz11, int ii)
        {
            //MessageBox.Show(poz11 + "    " + ii + "    " + ecuatie + "     " + uyt9);
            string s = ecuatie;
            if (inmultiriParantezeEcuatie(poz11, ii) != "")
            {
                //falala va contine operatiile din jurul parantezelor : 3*2(1+2x)/4*5 ( 3*2/4*5)
                string falala = inmultiriParantezeEcuatie(poz11, ii);
                //fala1=pozitia cea mai la stanga a termenului cu care se inmuleteste : 3*2*(1+2x) (pozitia lui 3)
                string fala1 = falala.Substring(falala.LastIndexOf(' '), falala.Length - falala.LastIndexOf(' '));
                falala = falala.Remove(falala.LastIndexOf(' '), falala.Length - falala.LastIndexOf(' '));
                //fala2=pozitia cea mai la dreapta a termenului cu care se inmulteste : (1+2x)*3*2 (pozitia lui 2)
                string fala2 = falala.Substring(falala.LastIndexOf(' '), falala.Length - falala.LastIndexOf(' '));

                falala = falala.Remove(falala.LastIndexOf(' '), falala.Length - falala.LastIndexOf(' '));
                int uy = 0;

                for (int o = 0; o < falala.Length; o++)
                {
                    if (falala[o] == ' ')
                    {
                        uy++;
                    }
                }

                int j = poz11 - 1, m1 = 0, k1 = 0, m2 = 0, k2 = 0;
                string semn1 = "", semn2 = "";
                while (j >= 0 && s[j] != '+' && s[j] != '-' && s[j] != ')' && s[j] != ']' &&
                    s[j] != '}' && s[j] != '(' && s[j] != '[' && s[j] != '{')
                {
                    if (s[j] == ' ')
                    {
                        m1++;
                    }
                    else
                        if (semn1 == "")
                        {
                            if (s[j] == '*' || s[j] == '/')
                            {
                                semn1 = s[j].ToString();
                            }
                        }
                    j--;
                    k1++;
                }
                j = ii + 1;
                while (j < s.Length && s[j] != '+' && s[j] != '-' && s[j] != ')' && s[j] != ']' && s[j] != '}'
           && s[j] != '(' && s[j] != '[' && s[j] != '{')
                {
                    if (s[j] == ' ')
                    {
                        m2++;
                    }
                    else
                        if (semn2 == "")
                        {
                            if (s[j] == '*' || s[j] == '/')
                            {
                                semn2 = s[j].ToString();
                            }
                        }
                    j--;
                    k2++;
                }
                //daca are termeni si in stanga si in dreapta
                if (uy != falala.Length)
                {
                    //daca la stanga se afla termeni
                    if (m1 != k1)
                    {
                        string calculll;
                        //calculele termenilor de langa paranteze + semnul de dinaintea parantezei + paranteza
                        calculll = faCalculeEcuatie(falala) + semn1 + s.Substring(poz11, ii - poz11 + 1);

                        //daca paranteza NU este pe prima pozitie
                        if (Convert.ToDouble(fala1) > 0)//(Convert.ToDouble(fala2) - uyt9 <= ecuatie.Length)
                        {
                            ecuatie = ecuatie.Remove(Convert.ToInt32(fala1), Convert.ToInt32(fala2) - Convert.ToInt32(fala1) + 1);
                            ecuatie = ecuatie.Insert(Convert.ToInt32(fala1), calculll);
                            uyt9 += Convert.ToInt32(fala2) - Convert.ToInt32(fala1) + 1;
                            uyt9 -= calculll.Length;
                        }
                        else
                        {
                            ecuatie = ecuatie.Remove(Convert.ToInt32(fala1), Convert.ToInt32(fala2) - Convert.ToInt32(fala1) + 1);
                            ecuatie = ecuatie.Insert(Convert.ToInt32(fala1), calculll);
                            uyt9 += Convert.ToInt32(fala2) - Convert.ToInt32(fala1) + 1;
                            uyt9 -= calculll.Length;
                        }

                    }
                    //daca la stanga nu se afla termeni
                    else
                        if (m1 == k1 && m2 != k2)
                        {
                            string calculll = s.Substring(poz11, ii - poz11 + 1);
                            if (semn2 == "*")
                            {
                                calculll = faCalculeEcuatie(falala) + semn2 + s.Substring(poz11, ii - poz11 + 1);
                            }
                            else
                                if (semn2 == "/")
                                {
                                    falala = falala.Insert(0, "1/");
                                    calculll = faCalculeEcuatie(falala) + "*" + s.Substring(poz11, ii - poz11 + 1);
                                }
                            if (Convert.ToDouble(fala1) >= 0)
                            {
                                ecuatie = ecuatie.Remove(Convert.ToInt32(fala1), Convert.ToInt32(fala2) - Convert.ToInt32(fala1) + 1);
                                ecuatie = ecuatie.Insert(Convert.ToInt32(fala1), calculll);
                                uyt9 += Convert.ToInt32(fala2) - Convert.ToInt32(fala1) + 1;
                                uyt9 -= calculll.Length;
                            }
                        }
                }
                else
                {
                    ////MessageBox.Show("Nu are termeni");
                }
            }
            //MessageBox.Show("ecuatie in inmulteste termeni   " + ecuatie);
        }

        /// <summary>
        /// schimba pe textbox1 cu textbox1 fara spatii
        /// </summary>
        public void stergeSpatiiEcuatie()
        {
            string s = textBox1Ecuatie.Text;
            string s1 = s;
            int uyt1 = 0;
            bool apare = false;

            for (int i = 0; i < textBox1Ecuatie.Text.Length; i++)
            {
                if (s[i] == ' ')
                {
                    s1 = s1.Remove(i - uyt1, 1);
                    uyt1++;
                }
                if (s[i] == 'x')
                {
                    if (i != 0)
                    {
                        for (int j = 0; j <= 9; j++)
                        {
                            if (s[i - 1] == j)
                            {
                                apare = true;
                            }
                        }
                    }
                    if (apare == true)
                    {
                        apare = false;
                        s1 = s1.Insert(i, "*");
                        uyt1--;
                    }
                }
            }
            ecuatie = s1;
            //textBox1.Text = s1;
        }

        /// <summary>
        /// Calculeaza termenii dinauntrul parantezelor care
        /// nu contin pe x, nu returneaza nimic, si schimba
        /// variabila "ecuatie" cu rezultatul obtinut
        /// </summary>
        /// <param name="e">substring din ecuatie de la ( )</param>
        /// <param name="qwe"></param>
        /// <param name="ert"></param>
        public void calculeazaParantezeEcuatie(int poz11, int ii)
        {//(1+2*x)+2+2+3*(1+2+2*2*x)
            //MessageBox.Show("aici se afla ec in calcParanteze    " + ecuatie);
            int uyt = 0;
            string ecuatie2 = ecuatie;
            string s = ecuatie.Substring(poz11, ii - poz11 + 1);
            string s1 = s, s2 = "", s3 = "", s4 = "";//s2 pentru termeni liberi si s3 pentru termenii care contin pe x
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ')' && i != s.Length - 1)
                {
                    int j = i;
                    while (j >= 0 && s[j] != '(')
                    {
                        s3 += s[j];
                        j--;
                    }
                    if (s3 != "" && j >= 0)
                    {
                        s3 += s[j];
                    }
                    i = j + 1;
                }
                else
                    if (s[i] == '(' && i >= 1)
                    {
                        int j = i - 1;
                        while (j >= 0 && s[j] != '+' && s[j] != '-' && s[j] != '(' && s[j] != ')' &&
                                    s[j] != '[' && s[j] != ']' && s[j] != '{' && s[j] != '}')
                        {
                            s3 += s[j];
                            j--;
                        }
                        if (s3 != "" && j >= 0)
                        {
                            s3 += s[j];
                        }
                        i = j;
                    }
                    else
                        if (s[i] == ']' && i != s.Length - 1)
                        {
                            int j = i - 1;
                            while (j >= 0 && s[j] != '[')
                            {
                                j--;
                            }
                            i = j + 1;
                        }
                        else
                            if (s[i] == '[' && i >= 1)
                            {
                                int j = i - 1;
                                while (j >= 0 && s[j] != '+' && s[j] != '-' && s[j] != '(' && s[j] != ')' &&
                                            s[j] != '[' && s[j] != ']' && s[j] != '{' && s[j] != '}')
                                {
                                    j--;
                                }
                                i = j;
                            }
                            else
                                if (s[i] == 'x')
                                {
                                    int j = i;
                                    //s2 = "";
                                    while (j > 0 && s[j] != '+' && s[j] != '-' && s[j] != '(' && s[j] != ')' &&
                                                s[j] != '[' && s[j] != ']' && s[j] != '{' && s[j] != '}')
                                    {
                                        s3 += s[j];
                                        j--;
                                    }
                                    if (s3 != "" && j > 0)
                                    {
                                        if (s[j] == '+' || s[j] == '-')
                                        {
                                            s3 += s[j];
                                        }
                                    }
                                    //daca termenul care il are pe x se afla la sfarsitul parantezei
                                    //atunci fac un j+1 pentru a salva si paranteza 
                                    if (s[j] == '(' || s[j] == '[' || s[j] == '{')
                                    {
                                        s2 += s[j];
                                        i = j;
                                    }
                                    else
                                        if (s[j] != '(' && s[j] != '[' && s[j] != '{')
                                        {
                                            i = j;
                                        }
                                        else
                                            if (j == 0)
                                                break;
                                }
                                else
                                {
                                    ////MessageBox.Show("s[i]            " + s[i]);
                                    s2 += s[i];
                                }
            }
            s2 = ReverseString2Ecuatie(s2);
            s3 = ReverseString2Ecuatie(s3);
            char paranteza1, paranteza2;
            //MessageBox.Show("ecuatie[poz11]    " + ecuatie[poz11] + "    poz11    " + poz11 +
            //'\n' + "ecuatie[ii]    " + ecuatie[ii] + "    ii    " + ii +
            //'\n' + s2 + "         " + s3 + "        " + ecuatie +
            //'\n' + uyt9);
            paranteza1 = ecuatie[poz11];
            paranteza2 = ecuatie[ii];
            if (s2.Length > 2)
            {
                s2 = s2.Remove(s2.Length - 1, 1);
                s2 = s2.Remove(0, 1);
                s2 = faCalculeEcuatie(s2);
            }
            else
            //if (s2.Length == 0)
            {
                s2 = "";
            }
            ecuatie = ecuatie.Remove(poz11, ii - poz11 + 1);
            if (s3 != "")
            {
                if (s3[0] != '-' && s3[0] != '+')
                {
                    s3 = s3.Insert(0, "+");
                }
            }
            s4 = s2 + s3;
            //MessageBox.Show("noile s3 si s4    " + s3 + "     " + s4);
            int plus = 0;
            //verific daca in s4 sunt numai termeni care contin pe x sau mai sunt si termeni liberi
            //si daca NU sunt numai termeni cu x atunci o sa afisam si parantezele
            for (int j = 0; j < s4.Length; j++)
            {
                if (s4[j] == '+' || s4[j] == '-')
                {
                    plus = 1;
                }
            }
            if (plus == 1)
            {
                ecuatie = ecuatie.Insert(poz11, paranteza1 + s2 + s3 + paranteza2);
                uyt9 -= (s2 + s3).Length + 2;
            }
            else
            {
                ecuatie = ecuatie.Insert(poz11, s2 + s3);
                uyt9 -= (s2 + s3).Length;
            }
            uyt9 += ii - poz11 + 1;
            if (s3 != "")
            {
                s4 = s2 + s3;
            }
            //MessageBox.Show("ecuatie in calculeaza paranteze      " + ecuatie);
        }

        /// <summary>
        /// Returneaza un string format din termenii liberi de
        /// pe langa paranteza cu x + pozitia parantezelor
        /// </summary>
        /// <param name="qwe"></param>
        /// <param name="ert"></param>
        /// <returns></returns>
        public string inmultiriParantezeEcuatie(int poz11, int ii)
        {
            string ret = "";
            string s = ecuatie, intermediar = "", intermediar1 = "", intermediar2 = "";
            int j = poz11 - 1;
            int uy = 0;
            while (j >= 0 && s[j] != '+' && s[j] != '-' && s[j] != ')' && s[j] != ']' && s[j] != '}'
                    && s[j] != '(' && s[j] != '[' && s[j] != '{')
            {
                if (s[j] == ' ')
                {
                    uy++;
                }
                if (j != poz11 - 1)
                {
                    intermediar1 += s[j];
                }
                if (s[j] == 'x')
                {
                    ret = "nu";
                }
                j--;
            }
            int f = j + 1;
            intermediar1 = ReverseStringEcuatie(intermediar1);
            int l = poz11 - 1 - j;
            if (uy != poz11 - 1 - j)
            {
                j = ii + 1;

            }
            else
            {
                j = ii + 2;
            }
            while (j < s.Length && s[j] != '+' && s[j] != '-' && s[j] != ')' && s[j] != ']' && s[j] != '}'
                        && s[j] != '(' && s[j] != '[' && s[j] != '{')
            {
                if (s[j] == 'x')
                {
                    ret = "nu";
                }
                intermediar2 += s[j];
                j++;
            }
            int f2 = j - 1;
            //MessageBox.Show(intermediar1 + '\n' + intermediar2);
            if (ret != "nu")
            {
                intermediar = intermediar1 + intermediar2 + ' ' + f2.ToString() + ' ' + f.ToString();
            }
            else
            {
                intermediar = "";
            }
            return intermediar;
        }

        /// <summary>
        /// Returneaza un string
        /// </summary>
        /// <param name="ecuatie2"></param>
        /// <returns></returns>
        public string faCalculeEcuatie(string ecuatie2)
        {
            string hg = "";
            try
            {
                string lala = ecuatie2;
                ScriereaPoloneza sc = new ScriereaPoloneza();
                hg = sc.calculeazaToateParantezele(lala);
                return hg;
            }
            catch
            {
                hg = "Eroare!";
                return hg;
            }
        }

        /// <summary>
        /// Returneaza un string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ReverseStringEcuatie(string s)
        {
            char[] a = s.ToCharArray();
            Array.Reverse(a);
            string f = new string(a);
            for (int i = 0; i < f.Length; i++)
            {
                if (f[i] == '(')
                {
                    f = f.Remove(i, 1);
                    f = f.Insert(i, ")");
                }
                else
                    if (f[i] == ')')
                    {
                        f = f.Remove(i, 1);
                        f = f.Insert(i, "(");
                    }
                    else
                        if (f[i] == '[')
                        {
                            f = f.Remove(i, 1);
                            f = f.Insert(i, "]");
                        }
                        else
                            if (f[i] == ']')
                            {
                                f = f.Remove(i, 1);
                                f = f.Insert(i, "[");
                            }
                            else
                                if (f[i] == '{')
                                {
                                    f = f.Remove(i, 1);
                                    f = f.Insert(i, "}");
                                }
                                else
                                    if (f[i] == '}')
                                    {
                                        f = f.Remove(i, 1);
                                        f = f.Insert(i, "{");
                                    }
            }
            return f;
        }

        public string ReverseString2Ecuatie(string s)
        {
            char[] a = s.ToCharArray();
            Array.Reverse(a);
            string f = new string(a);
            return f;
        }

        private void button2_ClickEcuatie(object sender, EventArgs e)
        {
            if (textBox4Ecuatie.Text != "" && textBox5Ecuatie.Text != "" && textBox6Ecuatie.Text != "" && textBox7Ecuatie.Text != "")
            {
                double x = Convert.ToDouble(textBox4Ecuatie.Text);
                double y = Convert.ToDouble(textBox5Ecuatie.Text);
                double z = Convert.ToDouble(textBox6Ecuatie.Text);
                double w = Convert.ToDouble(textBox7Ecuatie.Text);
                double rasp = 0;
                z = z - w;
                double delta = y * y - 4 * x * z;
                if (delta > 0)
                {
                    LabelXX22.Show();
                    LabelXX21.Text = "x1= ";
                    LabelXX22.Text = "x2= ";

                    delta = Math.Sqrt(delta * delta - 4 * x * z);
                    rasp = (-y + delta) / (-2 * x);

                    LabelX21.Show();
                    LabelX21.Text = rasp.ToString();

                    rasp = (-y - delta) / (-2 * x);

                    LabelX22.Show();
                    LabelX22.Text = rasp.ToString();
                }
                else
                    if (delta == 0)
                    {
                        LabelXX22.Hide();
                        LabelX22.Hide();

                        rasp = -y / (-2 * x);

                        LabelXX21.Text = "x1= ";
                        LabelX21.Show();
                        LabelX21.Text = rasp.ToString();
                    }
                    else
                    {
                        LabelXX21.Text = "ecuatia nu are radacini reale";

                        LabelX21.Hide();
                        LabelXX22.Hide();
                        LabelX22.Hide();
                    }
            }
            else
            {
                MessageBox.Show("Introduceti toate datele!");
            }
        }

        private void button3_ClickEcuatie(object sender, EventArgs e)
        {
            if (textBox8Ecuatie.Text != "" && textBox9Ecuatie.Text != "" && textBox10Ecuatie.Text != "" && textBox11Ecuatie.Text != "" && textBox12Ecuatie.Text != "")
            {
                double x = Convert.ToDouble(textBox8Ecuatie.Text);
                double y = Convert.ToDouble(textBox9Ecuatie.Text);
                double z = Convert.ToDouble(textBox10Ecuatie.Text);
                double q = Convert.ToDouble(textBox11Ecuatie.Text);
                double w = Convert.ToDouble(textBox12Ecuatie.Text);
                double rasp = 0;
                q = q - w;

                double inter1 = 0, inter2 = 0;
                int j = 0;
                while (rasp == 0)
                {
                    j++;
                    if (x * j * j * j + y * j * j + z * j + q == 0)
                    {
                        rasp = j;
                        LabelX31.Text = rasp.ToString();
                    }
                }
                if (rasp == 0)
                {
                    LabelXX33.Hide();
                    LabelXX32.Hide();
                    LabelX32.Hide();
                    LabelX33.Hide();
                    LabelX31.Hide();
                    LabelXX31.Text = "ecuatia nu are radacini reale";
                }
                //else
                //{
                //    string s1=
                //}



            }
            else
            {
                MessageBox.Show("Introduceti toate datele!");
            }
        }

        private void textBox1_KeyPressEcuatie(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                CalculeazaButton1Ecuatie.PerformClick();
            }
        }

        private void textBox1_TextChangedEcuatie(object sender, EventArgs e)
        {

        }



        //Here starts Triunghi **********************************************************************************

        System.ComponentModel.ComponentResourceManager resourcesTriunghi = new System.ComponentModel.ComponentResourceManager(typeof(Form1));

        private void incarcaTriunghi()
        {
            textBox1TriunghiAB.Clear();
            textBox2TriunghiBC.Clear();
            textBox3TriunghiCA.Clear();
            textBox4TriunghiX1.Text = "(x)";
            textBox6TriunghiX2.Text = "(x)";
            textBox8TriunghiX3.Text = "(x)";
            textBox5TriunghiY1.Text = "(y)";
            textBox7TriunghiY2.Text = "(y)";
            textBox9TriunghiY3.Text = "(y)";
            
            label4Triunghi.Text = "";
            label5Triunghi.Text = "";
            label6Triunghi.Text = "";

            label10Triunghi.Text = "";
            label11Triunghi.Text = "";
            label12Triunghi.Text = "";

            label49Triunghi.Text = "";
            label50Triunghi.Text = "";
            label51Triunghi.Text = "";

            label32Triunghi.Text = "";
            label35Triunghi.Text = "";
            label36Triunghi.Text = "";

            a1Triunghi.Text = "";
            a2Triunghi.Text = "";
            a3Triunghi.Text = "";


            b1Triunghi.Text = "";
            b2Triunghi.Text = "";
            b3Triunghi.Text = "";

            c1Triunghi.Text = "";
            c2Triunghi.Text = "";
            c3Triunghi.Text = "";
        }

        private void button1_ClickTriunghi(object sender, EventArgs e)
        {
            bool tr = false;
            string u = "qwertyuiopasfdghjklzxcvbnm";
            for (int o = 0; o < textBox1TriunghiAB.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox1TriunghiAB.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            for (int o = 0; o < textBox2TriunghiBC.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox2TriunghiBC.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            for (int o = 0; o < textBox3TriunghiCA.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox3TriunghiCA.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            if (tr == true)
            {
                MessageBox.Show("Introduceti numai numere!");
            }
            
            if (tr == false)
            {
                if (textBox1TriunghiAB.Text != "" && textBox2TriunghiBC.Text != "" && textBox3TriunghiCA.Text != "")
                {
                    label4Triunghi.Text = (Convert.ToDouble(textBox1TriunghiAB.Text) + Convert.ToDouble(textBox2TriunghiBC.Text) + Convert.ToDouble(textBox3TriunghiCA.Text)).ToString();
                    label5Triunghi.Text = (Convert.ToDouble(label4Triunghi.Text) / 2).ToString();
                    label6Triunghi.Text = HeronTriunghi(Convert.ToDouble(textBox1TriunghiAB.Text), Convert.ToDouble(textBox2TriunghiBC.Text), Convert.ToDouble(textBox3TriunghiCA.Text)).ToString();

                    label10Triunghi.Text = textBox1TriunghiAB.Text;
                    label11Triunghi.Text = textBox2TriunghiBC.Text;
                    label12Triunghi.Text = textBox3TriunghiCA.Text;

                    label4Triunghi.Show();
                    label5Triunghi.Show();
                    label6Triunghi.Show();
                    label10Triunghi.Show();
                    label11Triunghi.Show();
                    label12Triunghi.Show();
                }
                else
                    if ((textBox1TriunghiAB.Text == "" && textBox2TriunghiBC.Text == "" && textBox3TriunghiCA.Text == "") ||
                            (textBox1TriunghiAB.Text == "0" && textBox2TriunghiBC.Text == "0" && textBox3TriunghiCA.Text == "0"))
                    {
                        MessageBox.Show("Introduceți toate datele!");
                    }
            }
        }

        public static double arieTriunghi(double x1, double y1, double x2, double y2, double x3, double y3)//(Point A, Point B, Point C)
        {
            return Convert.ToDouble(Math.Abs((x1 * y2) + (x2 * y3) + (x3 * y1) - (y2 * x3) - (y3 * x1) - (y1 * x2))) / 2.0;
        }

        public static double HeronTriunghi(double A, double B, double C)
        {
            double p, a, b, c;
            p = (A + B + C) / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public static double distantaTriunghi(double x1, double y1, double x2, double y2)//(Point A, Point B)
        {
            return Math.Round(Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)), 2);
        }

        int pozTriunghi = -1;

        private void button3_ClickTriunghi(object sender, EventArgs e)
        {
            bool tr = false;
            string u = "qwertyuiopasfdghjklzxcvbnm";
            for (int o = 0; o < textBox4TriunghiX1.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox4TriunghiX1.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }

            for (int o = 0; o < textBox5TriunghiY1.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox5TriunghiY1.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            for (int o = 0; o < textBox6TriunghiX2.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox6TriunghiX2.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            for (int o = 0; o < textBox7TriunghiY2.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox7TriunghiY2.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            for (int o = 0; o < textBox8TriunghiX3.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox8TriunghiX3.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            for (int o = 0; o < textBox9TriunghiY3.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox9TriunghiY3.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }

            if (tr == true)
            {
                MessageBox.Show("Itroduceti numai numere!");
            }
            if (tr == false)
            {
                if ((textBox4TriunghiX1.Text == "0" && textBox5TriunghiY1.Text == "0" && textBox6TriunghiX2.Text == "0" &&
                       textBox7TriunghiY2.Text == "0" && textBox8TriunghiX3.Text == "0" && textBox9TriunghiY3.Text == "0") ||
                   (textBox4TriunghiX1.Text == "(x)" || textBox5TriunghiY1.Text == "(y)" || textBox6TriunghiX2.Text == "(x)" ||
                           textBox7TriunghiY2.Text == "(y)" || textBox8TriunghiX3.Text == "(x)" || textBox9TriunghiY3.Text == "(y)"))
                {
                    MessageBox.Show("Introduceți toate datele!");
                }
                else
                    if (textBox4TriunghiX1.Text != "" && textBox5TriunghiY1.Text != "" && textBox6TriunghiX2.Text != "" &&
                            textBox7TriunghiY2.Text != "" && textBox8TriunghiX3.Text != "" && textBox9TriunghiY3.Text != "" &&
                        textBox4TriunghiX1.Text != "(x)" && textBox5TriunghiY1.Text != "(y)" && textBox6TriunghiX2.Text != "(x)" &&
                            textBox7TriunghiY2.Text != "(y)" && textBox8TriunghiX3.Text != "(x)" && textBox9TriunghiY3.Text != "(y)")
                    {
                        label36Triunghi.Show();
                        label35Triunghi.Show();
                        label32Triunghi.Show();


                        double xa1 = Convert.ToDouble(textBox5TriunghiY1.Text) - Convert.ToDouble(textBox7TriunghiY2.Text);
                        a1Triunghi.Text = xa1.ToString() + 'x';
                        double xb1 = Convert.ToDouble(textBox6TriunghiX2.Text) - Convert.ToDouble(textBox4TriunghiX1.Text);
                        b1Triunghi.Text = xb1.ToString();
                        double xc1 = Convert.ToDouble(textBox4TriunghiX1.Text) * Convert.ToDouble(textBox7TriunghiY2.Text) - Convert.ToDouble(textBox5TriunghiY1.Text) * Convert.ToDouble(textBox6TriunghiX2.Text);
                        c1Triunghi.Text = xc1.ToString();
                        a1Triunghi.Show();

                        if (b1Triunghi.Text[0] == '-')
                        {
                            a1Triunghi.Text += " - " + b1Triunghi.Text + 'y';

                            if (c1Triunghi.Text[0] == '-')
                            {
                                a1Triunghi.Text += " - " + c1Triunghi.Text + " = 0";
                            }
                            else
                            {
                                a1Triunghi.Text += " + " + c1Triunghi.Text + " = 0";
                            }
                        }
                        else
                        {
                            a1Triunghi.Text += " + " + b1Triunghi.Text + 'y';

                            if (c1Triunghi.Text[0] == '-')
                            {
                                a1Triunghi.Text += " - " + c1Triunghi.Text + " = 0";
                            }
                            else
                            {
                                a1Triunghi.Text += " + " + c1Triunghi.Text + " = 0";
                            }
                        }

                        double xa2 = Convert.ToDouble(textBox7TriunghiY2.Text) - Convert.ToDouble(textBox9TriunghiY3.Text);
                        a2Triunghi.Text = xa2.ToString() + 'x';
                        double xb2 = Convert.ToDouble(textBox8TriunghiX3.Text) - Convert.ToDouble(textBox6TriunghiX2.Text);
                        b2Triunghi.Text = xb2.ToString();
                        double xc2 = Convert.ToDouble(textBox6TriunghiX2.Text) * Convert.ToDouble(textBox9TriunghiY3.Text) - Convert.ToDouble(textBox7TriunghiY2.Text) * Convert.ToDouble(textBox8TriunghiX3.Text);
                        c2Triunghi.Text = xc2.ToString();
                        a2Triunghi.Show();


                        if (b2Triunghi.Text[0] == '-')
                        {
                            a2Triunghi.Text += " - " + b2Triunghi.Text + 'y';

                            if (c2Triunghi.Text[0] == '-')
                            {
                                a2Triunghi.Text += " - " + c2Triunghi.Text + " = 0";
                            }
                            else
                            {
                                a2Triunghi.Text += " + " + c2Triunghi.Text + " = 0";
                            }
                        }
                        else
                        {
                            a2Triunghi.Text += " + " + b2Triunghi.Text + 'y';

                            if (c2Triunghi.Text[0] == '-')
                            {
                                a2Triunghi.Text += " - " + c2Triunghi.Text + " = 0";
                            }
                            else
                            {
                                a2Triunghi.Text += " + " + c2Triunghi.Text + " = 0";
                            }
                        }


                        double xa3 = Convert.ToDouble(textBox5TriunghiY1.Text) - Convert.ToDouble(textBox9TriunghiY3.Text);
                        a3Triunghi.Text = xa3.ToString() + 'x';
                        double xb3 = Convert.ToDouble(textBox8TriunghiX3.Text) - Convert.ToDouble(textBox4TriunghiX1.Text);
                        b3Triunghi.Text = xb3.ToString();
                        double xc3 = Convert.ToDouble(textBox4TriunghiX1.Text) * Convert.ToDouble(textBox9TriunghiY3.Text) - Convert.ToDouble(textBox5TriunghiY1.Text) * Convert.ToDouble(textBox8TriunghiX3.Text);
                        c3Triunghi.Text = xc3.ToString();
                        a3Triunghi.Show();


                        if (b3Triunghi.Text[0] == '-')
                        {
                            a3Triunghi.Text += " - " + b3Triunghi.Text + 'y';

                            if (c3Triunghi.Text[0] == '-')
                            {
                                a3Triunghi.Text += " - " + c3Triunghi.Text + " = 0";
                            }
                            else
                            {
                                a3Triunghi.Text += " + " + c3Triunghi.Text + " = 0";
                            }
                        }
                        else
                        {
                            a3Triunghi.Text += " + " + b3Triunghi.Text + 'y';

                            if (c3Triunghi.Text[0] == '-')
                            {
                                a3Triunghi.Text += " - " + c3Triunghi.Text + " = 0";
                            }
                            else
                            {
                                a3Triunghi.Text += " + " + c3Triunghi.Text + " = 0";
                            }
                        }


                        label32Triunghi.Text = Convert.ToDouble(xa1 * Convert.ToDouble(textBox4TriunghiX1.Text) + xb1 * Convert.ToDouble(textBox5TriunghiY1.Text)).ToString();
                        label35Triunghi.Text = Convert.ToDouble(xa2 * Convert.ToDouble(textBox6TriunghiX2.Text) + xb2 * Convert.ToDouble(textBox7TriunghiY2.Text)).ToString();
                        label36Triunghi.Text = Convert.ToDouble(xa3 * Convert.ToDouble(textBox8TriunghiX3.Text) + xb3 * Convert.ToDouble(textBox9TriunghiY3.Text)).ToString();

                        label49Triunghi.Text = ((-1) * (xa1 / xb1)).ToString();
                        label50Triunghi.Text = ((-1) * (xa2 / xb2)).ToString();
                        label51Triunghi.Text = ((-1) * (xa3 / xb3)).ToString();
                        label49Triunghi.Show();
                        label50Triunghi.Show();
                        label51Triunghi.Show();


                        //textBox10.Location = new Point(Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));
                        //textBox11.Location = new Point(Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text));
                        //textBox12.Location = new Point(Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox9.Text));
                        label4Triunghi.Text = (distantaTriunghi(Convert.ToDouble(textBox4TriunghiX1.Text), Convert.ToDouble(textBox5TriunghiY1.Text), Convert.ToDouble(textBox6TriunghiX2.Text), Convert.ToDouble(textBox7TriunghiY2.Text)) +
                                        distantaTriunghi(Convert.ToDouble(textBox4TriunghiX1.Text), Convert.ToDouble(textBox5TriunghiY1.Text), Convert.ToDouble(textBox8TriunghiX3.Text), Convert.ToDouble(textBox9TriunghiY3.Text)) +
                                        distantaTriunghi(Convert.ToDouble(textBox6TriunghiX2.Text), Convert.ToDouble(textBox7TriunghiY2.Text), Convert.ToDouble(textBox8TriunghiX3.Text), Convert.ToDouble(textBox9TriunghiY3.Text))).ToString();
                        label6Triunghi.Text = (arieTriunghi(Convert.ToDouble(textBox4TriunghiX1.Text), Convert.ToDouble(textBox5TriunghiY1.Text), Convert.ToDouble(textBox6TriunghiX2.Text), Convert.ToDouble(textBox7TriunghiY2.Text), Convert.ToDouble(textBox8TriunghiX3.Text), Convert.ToDouble(textBox9TriunghiY3.Text))).ToString();
                        double x;
                        x = (double)(1.0 / 3);
                        label5Triunghi.Text = (Convert.ToDouble(label4Triunghi.Text) / 2).ToString();

                        label10Triunghi.Text = distantaTriunghi(Convert.ToDouble(textBox4TriunghiX1.Text), Convert.ToDouble(textBox5TriunghiY1.Text), Convert.ToDouble(textBox6TriunghiX2.Text), Convert.ToDouble(textBox7TriunghiY2.Text)).ToString();
                        label11Triunghi.Text = distantaTriunghi(Convert.ToDouble(textBox4TriunghiX1.Text), Convert.ToDouble(textBox5TriunghiY1.Text), Convert.ToDouble(textBox8TriunghiX3.Text), Convert.ToDouble(textBox9TriunghiY3.Text)).ToString();
                        label12Triunghi.Text = distantaTriunghi(Convert.ToDouble(textBox6TriunghiX2.Text), Convert.ToDouble(textBox7TriunghiY2.Text), Convert.ToDouble(textBox8TriunghiX3.Text), Convert.ToDouble(textBox9TriunghiY3.Text)).ToString();

                        label4Triunghi.Show();
                        label5Triunghi.Show();
                        label6Triunghi.Show();
                        label10Triunghi.Show();
                        label11Triunghi.Show();
                        label12Triunghi.Show();
                    }

            }
        }

        private void button4_ClickTriunghi(object sender, EventArgs e)
        {
            bool tr = false;
            string u = "qwertyuiopasfdghjklzxcvbnm";
            for (int o = 0; o < textBox4TriunghiX1.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox4TriunghiX1.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }

            for (int o = 0; o < textBox5TriunghiY1.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox5TriunghiY1.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            for (int o = 0; o < textBox6TriunghiX2.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox6TriunghiX2.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            for (int o = 0; o < textBox7TriunghiY2.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox7TriunghiY2.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            for (int o = 0; o < textBox8TriunghiX3.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox8TriunghiX3.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            for (int o = 0; o < textBox9TriunghiY3.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox9TriunghiY3.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }

            if (tr == true)
            {
                MessageBox.Show("Itroduceti numai numere!");
            }
            if (tr == false)
            {
                if ((textBox4TriunghiX1.Text == "(x)" || textBox5TriunghiY1.Text == "(y)" || textBox6TriunghiX2.Text == "(x)" ||
                           textBox7TriunghiY2.Text == "(y)" || textBox8TriunghiX3.Text == "(x)" || textBox9TriunghiY3.Text == "(y)") ||
                  (textBox4TriunghiX1.Text == "0" && textBox5TriunghiY1.Text == "0" && textBox6TriunghiX2.Text == "0" &&
                           textBox7TriunghiY2.Text == "0" && textBox8TriunghiX3.Text == "0" && textBox9TriunghiY3.Text == "0"))
                {
                    MessageBox.Show("Introduceți coordonatele tuturor punctelor!");
                }
                else
                {
                    Desen1 de = new Desen1(textBox4TriunghiX1.Text, textBox6TriunghiX2.Text, textBox8TriunghiX3.Text, textBox5TriunghiY1.Text, textBox7TriunghiY2.Text, textBox9TriunghiY3.Text);
                    de.Show();
                }
            }
        }

        private void button2_ClickTriunghi(object sender, EventArgs e)
        {
            textBox1TriunghiAB.Clear();
            textBox2TriunghiBC.Clear();
            textBox3TriunghiCA.Clear();
        }

        private void button5_ClickTriunghi(object sender, EventArgs e)
        {
            textBox4TriunghiX1.Text = "(x)";
            textBox5TriunghiY1.Text = "(y)";
            textBox6TriunghiX2.Text = "(x)";

            textBox7TriunghiY2.Text = "(y)";
            textBox8TriunghiX3.Text = "(x)";
            textBox9TriunghiY3.Text = "(y)";
        }

        private void textBox4_ClickTriunghi(object sender, EventArgs e)
        {
            if (textBox4TriunghiX1.Text == "(x)")
            {
                textBox4TriunghiX1.Text = "";
            }
            else
                if (textBox4TriunghiX1.Text != "(x)")
                {
                    textBox4TriunghiX1.Select(0, textBox4TriunghiX1.Text.Length);
                }
        }

        private void textBox6_ClickTriunghi(object sender, EventArgs e)
        {
            if (textBox6TriunghiX2.Text == "(x)")
            {
                textBox6TriunghiX2.Text = "";
            }
            else
                if (textBox6TriunghiX2.Text != "(x)")
                {
                    textBox6TriunghiX2.Select(0, textBox6TriunghiX2.Text.Length);
                }
        }

        private void textBox9_ClickTriunghi(object sender, EventArgs e)
        {
            if (textBox9TriunghiY3.Text == "(y)")
            {
                textBox9TriunghiY3.Text = "";
            }
            else
                if (textBox9TriunghiY3.Text != "")
                    if (textBox9TriunghiY3.Text != "(y)")
                    {
                        textBox9TriunghiY3.Select(0, textBox9TriunghiY3.Text.Length);
                    }
        }

        private void textBox7_ClickTriunghi(object sender, EventArgs e)
        {
            if (textBox7TriunghiY2.Text == "(y)")
            {
                textBox7TriunghiY2.Text = "";
            }
            else
                if (textBox7TriunghiY2.Text != "(y)")
                {
                    textBox7TriunghiY2.Select(0, textBox7TriunghiY2.Text.Length);
                }

        }

        private void textBox5_ClickTriunghi(object sender, EventArgs e)
        {
            if (textBox5TriunghiY1.Text == "(y)")
            {
                textBox5TriunghiY1.Text = "";
            }
            else
                if (textBox5TriunghiY1.Text != "(y)")
                {
                    textBox5TriunghiY1.Select(0, textBox5TriunghiY1.Text.Length);
                }
        }

        private void textBox8_ClickTriunghi(object sender, EventArgs e)
        {
            if (textBox8TriunghiX3.Text == "(x)")
            {
                textBox8TriunghiX3.Text = "";
            }
            else
                if (textBox8TriunghiX3.Text != "(x)")
                {
                    textBox8TriunghiX3.Select(0, textBox8TriunghiX3.Text.Length);
                }
        }

        private void textBox8_LeaveTriunghi(object sender, EventArgs e)
        {
            if (textBox8TriunghiX3.Text == "")
            {
                textBox8TriunghiX3.Text = "(x)";
            }
        }

        private void textBox6_LeaveTriunghi(object sender, EventArgs e)
        {
            if (textBox6TriunghiX2.Text == "")
            {
                textBox6TriunghiX2.Text = "(x)";
            }
        }

        private void textBox4_LeaveTriunghi(object sender, EventArgs e)
        {
            if (textBox4TriunghiX1.Text == "")
            {
                textBox4TriunghiX1.Text = "(x)";
            }
        }

        private void textBox5_LeaveTriunghi(object sender, EventArgs e)
        {
            if (textBox5TriunghiY1.Text == "")
            {
                textBox5TriunghiY1.Text = "(y)";
            }
        }

        private void textBox7_LeaveTriunghi(object sender, EventArgs e)
        {
            if (textBox7TriunghiY2.Text == "")
            {
                textBox7TriunghiY2.Text = "(y)";
            }
        }

        private void textBox9_LeaveTriunghi(object sender, EventArgs e)
        {
            if (textBox9TriunghiY3.Text == "")
            {
                textBox9TriunghiY3.Text = "(y)";
            }
        }



        //Here starts determinanti ***************************************************************************
        Graphics g;
        Pen pen = new Pen(Color.Black);

        public void incarcaDeterminanti()
        {
            textBox1Determinanti.Clear();
            textBox2Determinanti.Clear();
            textBox3Determinanti.Clear();
            textBox4Determinanti.Clear();
            textBox5Determinanti.Clear();
            textBox6Determinanti.Clear();
            textBox7Determinanti.Clear();
            textBox8Determinanti.Clear();
            textBox9Determinanti.Clear();

            timer1Determinanti.Start();
            label3Determinanti.Text = "";
            button2.PerformClick();
        }

        private void button1_ClickDeterminanti(object sender, EventArgs e)
        {
            try
            {
                double x1 = Convert.ToDouble(textBox1Determinanti.Text);
                double y1 = Convert.ToDouble(textBox2Determinanti.Text);
                double z1 = Convert.ToDouble(textBox3Determinanti.Text);
                double x2 = Convert.ToDouble(textBox4Determinanti.Text);
                double y2 = Convert.ToDouble(textBox5Determinanti.Text);
                double z2 = Convert.ToDouble(textBox6Determinanti.Text);
                double x3 = Convert.ToDouble(textBox7Determinanti.Text);
                double y3 = Convert.ToDouble(textBox8Determinanti.Text);
                double z3 = Convert.ToDouble(textBox9Determinanti.Text);
                double rasp = 0;

                bool tr = false;
                string u = "qwertyuiopasfdghjklzxcvbnm";
                for (int o = 0; o < textBox1Determinanti.Text.Length; o++)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        if (textBox1Determinanti.Text[o] == u[j])
                        {
                            tr = true;
                        }
                    }
                }

                for (int o = 0; o < textBox2Determinanti.Text.Length; o++)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        if (textBox2Determinanti.Text[o] == u[j])
                        {
                            tr = true;
                        }
                    }
                }

                for (int o = 0; o < textBox3Determinanti.Text.Length; o++)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        if (textBox3Determinanti.Text[o] == u[j])
                        {
                            tr = true;
                        }
                    }
                }

                for (int o = 0; o < textBox4Determinanti.Text.Length; o++)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        if (textBox4Determinanti.Text[o] == u[j])
                        {
                            tr = true;
                        }
                    }
                }

                for (int o = 0; o < textBox5Determinanti.Text.Length; o++)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        if (textBox5Determinanti.Text[o] == u[j])
                        {
                            tr = true;
                        }
                    }
                }

                for (int o = 0; o < textBox6Determinanti.Text.Length; o++)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        if (textBox6Determinanti.Text[o] == u[j])
                        {
                            tr = true;
                        }
                    }
                }

                for (int o = 0; o < textBox7Determinanti.Text.Length; o++)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        if (textBox7Determinanti.Text[o] == u[j])
                        {
                            tr = true;
                        }
                    }
                }

                for (int o = 0; o < textBox8Determinanti.Text.Length; o++)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        if (textBox8Determinanti.Text[o] == u[j])
                        {
                            tr = true;
                        }
                    }
                }

                for (int o = 0; o < textBox9Determinanti.Text.Length; o++)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        if (textBox9Determinanti.Text[o] == u[j])
                        {
                            tr = true;
                        }
                    }
                }

                if (tr == false)
                {
                    rasp = x1 * y2 * z3 + x2 * y3 * z1 + x3 * y1 * z2 - z1 * x3 * y2 - z2 * y3 * x1 - z3 * x2 * y1;
                    label3Determinanti.Text = rasp.ToString();
                }
                else
                {
                    label3Determinanti.Text = "Introduceti numai numere!";
                }
            }
            catch
            {
                MessageBox.Show("Introduceti corect numerele");
            }
        }
        
        private void button2_ClickDeterminanti(object sender, EventArgs e)
        {

        }

        private void timer1_TickDeterminanti(object sender, EventArgs e)
        {
            button2.PerformClick();
            timer1Determinanti.Stop();
        }



        //Here starts Matrici *************************************************************************************
                int[] aMatrici = new int[200];
        int[] solMatrici = new int[200];
        int[] a2Matrici = new int[200];
        int[] sol2Matrici = new int[200];
        int[] rezMatrici = new int[200];
        int[] rez2Matrici = new int[200];
        Label[] lb1Matrici = new Label[10000];
        Label[] lb2Matrici = new Label[10000];
        int n1Matrici, m1Matrici, pozxMatrici = 0, pozyMatrici = 0,
            last1Matrici = 0, last2Matrici = 0, last3Matrici = 0, last4Matrici = 0;
        int n2Matrici, m2Matrici;

        public void incarcaMatrici()
        {
            button4Matrici.PerformClick();
            button5Matrici.PerformClick();

            nr1Matrici = 0;
            nr2Matrici = 0;

            n1Matrici = 0;
            m1Matrici = 0;
            pozxMatrici = 0;
            pozyMatrici = 0;
            last1Matrici = 0;
            last2Matrici = 0;
            last3Matrici = 0;
            last4Matrici = 0;
            n2Matrici = 0;
            m2Matrici = 0;

            textBox1Matrici.Text = "(k)";
            textBox2Matrici.Text = "(n)";
            textBox3Matrici.Text = "(k)";
            textBox4Matrici.Text = "(n)";
        }

        private void button2_ClickMatrici(object sender, EventArgs e)
        {
            bool tr = false;
            string u = "qwertyuiopasfdghjklzxcvbnm";
            for (int o = 0; o < textBox1Matrici.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox1Matrici.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            if (tr == true)
            {
                MessageBox.Show("Introduceti numai numere!");
            }
            if(tr==false)
            if (textBox3Matrici.Text != "" && textBox4Matrici.Text != "" &&
                textBox3Matrici.Text != "(k)" && textBox4Matrici.Text != "(n)")
            {
                if (last2Matrici != 0)
                {
                    button5Matrici.PerformClick();
                    /*
                    for (int i = 0; i <= last2; i++)
                    {
                        lb2Matrici[i] = new Label();
                        lb2Matrici[i].Hide();
                    }*/
                }
                n2Matrici = Convert.ToInt32(textBox4Matrici.Text);
                m2Matrici = Convert.ToInt32(textBox3Matrici.Text);
                if (n2Matrici >= m2Matrici)
                {
                    /*if (last2 != 0)
                    {
                        for (int i = 0; i < last2; i++)
                        {
                            lb2Matrici[i] = new Label();
                            lb2Matrici[i].Hide();
                        }
                    }*/

                    lb2Matrici[0] = new Label();
                    this.lb2Matrici[0].AutoSize = true;
                    this.lb2Matrici[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lb2Matrici[0].Location = new System.Drawing.Point(label1Matrici.Location.X, label1Matrici.Location.Y);
                    this.lb2Matrici[0].Name = "label1";
                    this.lb2Matrici[0].Size = new System.Drawing.Size(35, 13);
                    this.lb2Matrici[0].TabIndex = 0;
                    this.lb2Matrici[0].Text = "1";
                    lb2Matrici[0].BackColor = System.Drawing.Color.Transparent;
                    UnealtaMatrici.Controls.Add(lb2Matrici[0]);
                    
                    nr2Matrici++;
                    
                    lb2Matrici[0].Show();
                    pozxMatrici = lb2Matrici[0].Location.X;
                    pozyMatrici = lb2Matrici[0].Location.Y;

                    for (int i = 1; i <= n2Matrici; i++)
                    {
                        a2Matrici[i] = new int();
                        a2Matrici[i] = i;
                    }
                    last2Matrici = 0;
                    back2Matrici(1);

                }
                else
                {
                    MessageBox.Show("n trebuie să fie mai mare decât k!");
                }
            }
            else
            {
                MessageBox.Show("Introduceți pe n si pe k!");
            }
        }
        public int valid2Matrici(int k)
        {
            int i;
            for (i = 1; i <= k - 1; i++)
                if (sol2Matrici[i] == sol2Matrici[k])
                    return 0;
            return 1;
        }
        int numaraMatrici = 0;
        int nr1Matrici, nr2Matrici;
        public void back2Matrici(int k)
        {
            int i;
            if (k == m2Matrici + 1)
            {
                int uy = lb2Matrici[0].Location.X;

                for (i = 1; i <= m2Matrici; i++)
                {
                    lb2Matrici[numaraMatrici * m2Matrici + i] = new Label();
                    this.lb2Matrici[numaraMatrici * m2Matrici + i].AutoSize = true;
                    this.lb2Matrici[numaraMatrici * m2Matrici + i].Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lb2Matrici[numaraMatrici * m2Matrici + i].BackColor = System.Drawing.Color.Transparent;
                    if (i != 1)
                    {
                        this.lb2Matrici[numaraMatrici * m2Matrici + i].Location = new System.Drawing.Point(this.lb2Matrici[numaraMatrici * m2Matrici + i - 1].Location.X + 30, pozyMatrici);
                    }
                    else
                    {
                        lb2Matrici[numaraMatrici * m2Matrici + i].Location = new Point(pozxMatrici, pozyMatrici);
                    }
                    rez2Matrici[numaraMatrici * m2Matrici + i] = new int();
                    this.lb2Matrici[numaraMatrici * m2Matrici + i].Name = "label1";
                    this.lb2Matrici[numaraMatrici * m2Matrici + i].Size = new System.Drawing.Size(35, 13);
                    this.lb2Matrici[numaraMatrici * m2Matrici + i].TabIndex = 0;
                    this.lb2Matrici[numaraMatrici * m2Matrici + i].Text = a2Matrici[sol2Matrici[i]].ToString();
                    UnealtaMatrici.Controls.Add(lb2Matrici[numaraMatrici * m2Matrici + i]);

                    nr2Matrici++;

                    last2Matrici = numaraMatrici * m2Matrici + i;
                    lb2Matrici[last2Matrici].Show();
                }
                pozxMatrici = lb2Matrici[0].Location.X;
                pozyMatrici += 30;
                richTextBox1Matrici.Text += '\n';

                numaraMatrici++;
            }
            else
                for (i = 1; i <= n2Matrici; i++)
                {
                    sol2Matrici[k] = new int();
                    sol2Matrici[k] = i;
                    if (valid2Matrici(k) != 0)
                        back2Matrici(k + 1);
                }
        }

        int valid1Matrici(int k)
        {
            int i;

            if (solMatrici[k - 1] >= solMatrici[k] && k > 1) return 0;
            return 1;
        }
        void back1Matrici(int k)
        {
            int i;
            if (k == m1Matrici + 1)
            {

                for (i = 1; i <= m1Matrici; i++)
                {
                    lb1Matrici[numaraMatrici * m1Matrici + i] = new Label();
                    this.lb1Matrici[numaraMatrici * m1Matrici + i].AutoSize = true;
                    lb1Matrici[numaraMatrici * m1Matrici + i].BackColor = System.Drawing.Color.Transparent;
                    this.lb1Matrici[numaraMatrici * m1Matrici + i].Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    if (i != 1)
                    {
                        this.lb1Matrici[numaraMatrici * m1Matrici + i].Location = new System.Drawing.Point(this.lb1Matrici[numaraMatrici * m1Matrici + i - 1].Location.X + 30, pozyMatrici);
                    }
                    else
                    {
                        lb1Matrici[numaraMatrici * m1Matrici + i].Location = new Point(pozxMatrici, pozyMatrici);
                    }
                    rez2Matrici[numaraMatrici * m2Matrici + i] = new int();
                    this.lb1Matrici[numaraMatrici * m1Matrici + i].Name = "label1";
                    this.lb1Matrici[numaraMatrici * m1Matrici + i].Size = new System.Drawing.Size(35, 13);
                    this.lb1Matrici[numaraMatrici * m1Matrici + i].TabIndex = 0;
                    this.lb1Matrici[numaraMatrici * m1Matrici + i].Text = aMatrici[solMatrici[i]].ToString();
                    UnealtaMatrici.Controls.Add(lb1Matrici[numaraMatrici * m1Matrici + i]);

                    nr1Matrici++;
                    
                    richTextBox1Matrici.Text += aMatrici[solMatrici[i]].ToString() + ' ';
                    last1Matrici = numaraMatrici * m1Matrici + i;
                    lb1Matrici[last1Matrici].Show();
                }
                pozxMatrici = lb1Matrici[0].Location.X;
                pozyMatrici += 30;
                richTextBox1Matrici.Text += '\n';

                numaraMatrici++;
            }
            else for (i = 1; i <= n1Matrici; i++)
                {
                    solMatrici[k] = i;
                    if (valid1Matrici(k) != 0) back1Matrici(k + 1);
                }
        }

        private void button1_ClickMatrici(object sender, EventArgs e)
        {
            bool tr = false;
            string u = "qwertyuiopasfdghjklzxcvbnm";
            for (int o = 0; o < textBox1Matrici.Text.Length; o++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (textBox1Matrici.Text[o] == u[j])
                    {
                        tr = true;
                    }
                }
            }
            if (tr == true)
            {
                MessageBox.Show("Introduceti numai numere!");
            }
            if(tr==false)
            if (textBox1Matrici.Text != "" && textBox2Matrici.Text != "" &&
                textBox1Matrici.Text != "(k)" && textBox2Matrici.Text != "(n)")
            {
                if (last1Matrici != 0)
                {
                    button4Matrici.PerformClick();/*
                    for (int i = 0; i <= last1; i++)
                    {
                        lb1Matrici[i] = new Label();
                        lb1Matrici[i].Hide();
                    }*/
                }
                n1Matrici = Convert.ToInt32(textBox2Matrici.Text);
                m1Matrici = Convert.ToInt32(textBox1Matrici.Text);
                if (n1Matrici >= m1Matrici)
                {
                    /*if (last1 != 0)
                    {
                        for (int i = 0; i < last1; i++)
                        {
                            lb1Matrici[i] = new Label();
                            lb1Matrici[i].Hide();
                        /
                    }*/

                    lb1Matrici[0] = new Label();
                    this.lb1Matrici[0].AutoSize = true;
                    this.lb1Matrici[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lb1Matrici[0].Location = new System.Drawing.Point(label8Matrici.Location.X, label8Matrici.Location.Y);
                    this.lb1Matrici[0].Name = "label1";
                    this.lb1Matrici[0].Size = new System.Drawing.Size(35, 13);
                    this.lb1Matrici[0].TabIndex = 0;
                    this.lb1Matrici[0].Text = "1";
                    lb1Matrici[0].BackColor = System.Drawing.Color.Transparent;
                    UnealtaMatrici.Controls.Add(lb1Matrici[0]);

                    nr1Matrici++;
                    
                    pozxMatrici = lb1Matrici[0].Location.X;
                    pozyMatrici = lb1Matrici[0].Location.Y;
                    lb1Matrici[0].Show();
                    for (int i = 1; i <= n1Matrici; i++)
                    {
                        aMatrici[i] = new int();
                        aMatrici[i] = i;
                    }
                    last1Matrici = 0;
                    back1Matrici(1);
                }
                else
                {
                    MessageBox.Show("n trebuie să fie mai mare decât k!");
                }
            }
            else
            {
                MessageBox.Show("Introduceți pe n si pe k!");
            }
        }
        private void button3_ClickMatrici(object sender, EventArgs e)
        {

        }

        private void textBox1_ClickMatrici(object sender, EventArgs e)
        {
            if (textBox1Matrici.Text == "(k)")
            {
                textBox1Matrici.Text = "";
            }
            else
                if (textBox1Matrici.Text != "(k)")
                {
                    textBox1Matrici.Select(0, textBox1Matrici.Text.Length);
                }
        }

        private void textBox2_ClickMatrici(object sender, EventArgs e)
        {
            if (textBox2Matrici.Text == "(n)")
            {
                textBox2Matrici.Text = "";
            }
            else
                if (textBox2Matrici.Text != "(n)")
                {
                    textBox2Matrici.Select(0, textBox2Matrici.Text.Length);
                }
        }

        private void textBox5_ClickMatrici(object sender, EventArgs e)
        {
            if (textBox5Matrici.Text == "(n)")
            {
                textBox5Matrici.Text = "";
            }
            else
                if (textBox5Matrici.Text != "(n)")
                {
                    textBox5Matrici.Select(0, textBox5Matrici.Text.Length);
                }
        }

        private void textBox5_LeaveMatrici(object sender, EventArgs e)
        {
            if (textBox5Matrici.Text == "")
            {
                textBox5Matrici.Text = "(n)";
            }
        }

        private void textBox3_LeaveMatrici(object sender, EventArgs e)
        {
            if (textBox3Matrici.Text == "")
            {
                textBox3Matrici.Text = "(k)";
            }
        }

        private void textBox4_LeaveMatrici(object sender, EventArgs e)
        {
            if (textBox4Matrici.Text == "")
            {
                textBox4Matrici.Text = "(n)";
            }
        }

        private void textBox2_LeaveMatrici(object sender, EventArgs e)
        {
            if (textBox2Matrici.Text == "")
            {
                textBox2Matrici.Text = "(n)";
            }
        }

        private void textBox1_LeaveMatrici(object sender, EventArgs e)
        {
            if (textBox1Matrici.Text == "")
            {
                textBox1Matrici.Text = "(k)";
            }
        }

        private void button4_ClickMatrici(object sender, EventArgs e)
        {
            try
            {
                if (nr1Matrici != 0)
                {
                    for (int i = 0; i <= nr1Matrici; i++)
                    {
                        lb1Matrici[i].Hide();
                    }
                    nr1Matrici = 0;
                }
            }
            catch
            {
            }
        }

        private void button5_ClickMatrici(object sender, EventArgs e)
        {
            try
            {
                if (nr2Matrici != 0)
                {
                    for (int i = 0; i <= nr2Matrici; i++)
                    {
                        lb2Matrici[i].Hide();
                    }
                    nr2Matrici = 0;
                }
            }
            catch
            {
            }
        }

        private void textBox3_ClickMatrici(object sender, EventArgs e)
        {
            if (textBox3Matrici.Text == "(k)")
            {
                textBox3Matrici.Text = "";
            }
            else
                if (textBox3Matrici.Text != "(k)")
                {
                    textBox3Matrici.Select(0, textBox3Matrici.Text.Length);
                }
        }

        private void textBox4_ClickMatrici(object sender, EventArgs e)
        {
            if (textBox4Matrici.Text == "(n)")
            {
                textBox4Matrici.Text = "";
            }
            else
                if (textBox4Matrici.Text != "(n)")
                {
                    textBox4Matrici.Select(0, textBox4Matrici.Text.Length);
                }
        }

        private void UnelteButton_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(718, 350); changePanels(PanelForm1, PanelUnelte);
            this.Text = "Unelte";
            CalculatorButton2.Focus();
        }



        //int xPanelUnelte, yPanelUnelte;
        //string stopPanelUnelte = "nimic";
        Panel TheFirstPanel;

        private void swypeUnelte()
        {
            if (TheFirstPanel.Location.X > 289)
            {
                TheFirstPanel.Location = new Point(TheFirstPanel.Location.X - 8, TheFirstPanel.Location.Y);
            }
            else
                if (TheFirstPanel.Location.X > 269)
                {
                    TheFirstPanel.Location = new Point(TheFirstPanel.Location.X - 1, TheFirstPanel.Location.Y);
                }
                else
                {
                    SwypeUnelteTimer.Stop();
                }
        }

        private void SwypeUnelteTimer_Tick(object sender, EventArgs e)
        {
            //if (stopPanelUnelte != "nimic")
            {
                swypeUnelte();
            }
        }


        private void CalculatorButton2_Click(object sender, EventArgs e)
        {
            //pun sa fie diferit de 3, pentru ca sa nu se intample nimic cand apasa de mai multe ori pe el
            if (UnealtaCalculator.Location.Y != 3)
            {
                incarcaCalculator();
                //schimb coordonatele tuturor celorlalte unelte
                UnealtaEcuatie.Hide();
                UnealtaEcuatie.Location = new Point(330, 4);
                UnealtaMatrici.Hide();
                UnealtaMatrici.Location = new Point(330, 4);
                UnealtaTriunghi.Hide();
                UnealtaTriunghi.Location = new Point(330, 4);
                UnealtaDeterminanti.Hide();
                UnealtaDeterminanti.Location = new Point(330, 4);

                TheFirstPanel = UnealtaCalculator;
                UnealtaCalculator.Show();
                UnealtaCalculator.BringToFront();
                TheFirstPanel.Location = new Point(330, 3);
                SwypeUnelteTimer.Start();
            }
        }

        private void EcuatiiButton2_Click(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Control || ModifierKeys == Keys.MButton)
            {
                Ecuatie ec = new Ecuatie();
                ec.Show();
            }
            else
            {
                //pun sa fie diferit de 3, pentru ca sa nu se intample nimic cand apasa de mai multe ori pe el
                if (UnealtaEcuatie.Location.Y != 3)
                {
                    incarcaEcuatie();
                    //schimb coordonatele tuturor celorlalte unelte
                    UnealtaCalculator.Hide();
                    UnealtaCalculator.Location = new Point(330, 4);
                    UnealtaMatrici.Hide();
                    UnealtaMatrici.Location = new Point(330, 4);
                    UnealtaTriunghi.Hide();
                    UnealtaTriunghi.Location = new Point(330, 4);
                    UnealtaDeterminanti.Hide();
                    UnealtaDeterminanti.Location = new Point(330, 4);

                    TheFirstPanel = UnealtaEcuatie;
                    UnealtaEcuatie.Show();
                    UnealtaEcuatie.BringToFront();
                    TheFirstPanel.Location = new Point(330, 3);
                    SwypeUnelteTimer.Start();
                }
            }
        }

        private void DeterminantiButton2_Click(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Control || ModifierKeys == Keys.MButton)
            {
                Determinanti ec = new Determinanti();
                ec.Show();
            }
            else
            {
                //pun sa fie diferit de 3, pentru ca sa nu se intample nimic cand apasa de mai multe ori pe el
                if (UnealtaDeterminanti.Location.Y != 3)
                {
                    incarcaDeterminanti();
                    //schimb coordonatele tuturor celorlalte unelte
                    UnealtaCalculator.Hide();
                    UnealtaCalculator.Location = new Point(330, 4);
                    UnealtaMatrici.Hide();
                    UnealtaMatrici.Location = new Point(330, 4);
                    UnealtaTriunghi.Hide();
                    UnealtaTriunghi.Location = new Point(330, 4);
                    UnealtaEcuatie.Hide();
                    UnealtaEcuatie.Location = new Point(330, 4);

                    TheFirstPanel = UnealtaDeterminanti;
                    UnealtaDeterminanti.Show();
                    UnealtaDeterminanti.BringToFront();
                    TheFirstPanel.Location = new Point(330, 3);
                    SwypeUnelteTimer.Start();
                }
            }
        }

        private void MatriciButton2_Click(object sender, EventArgs e)
        {

            if (ModifierKeys == Keys.Control || ModifierKeys == Keys.MButton)
            {
                Matrici ec = new Matrici();
                ec.Show();
            }
            else
            {
                //pun sa fie diferit de 3, pentru ca sa nu se intample nimic cand apasa de mai multe ori pe el
                if (UnealtaMatrici.Location.Y != 3)
                {
                    incarcaMatrici();
                    //schimb coordonatele tuturor celorlalte unelte
                    UnealtaCalculator.Hide();
                    UnealtaCalculator.Location = new Point(330, 4);
                    UnealtaDeterminanti.Hide();
                    UnealtaDeterminanti.Location = new Point(330, 4);
                    UnealtaTriunghi.Hide();
                    UnealtaTriunghi.Location = new Point(330, 4);
                    UnealtaEcuatie.Hide();
                    UnealtaEcuatie.Location = new Point(330, 4);

                    TheFirstPanel = UnealtaMatrici;
                    UnealtaMatrici.Show();
                    UnealtaMatrici.BringToFront();
                    TheFirstPanel.Location = new Point(330, 3);
                    SwypeUnelteTimer.Start();
                }
            }
        }

        private void TriunghiuriButton2_Click(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Control || ModifierKeys == Keys.MButton)
            {
                Triunghi ec = new Triunghi();
                ec.Show();
            }
            else
            {
                //pun sa fie diferit de 3, pentru ca sa nu se intample nimic cand apasa de mai multe ori pe el
                if (UnealtaTriunghi.Location.Y != 3)
                {
                    incarcaTriunghi();
                    //schimb coordonatele tuturor celorlalte unelte
                    UnealtaCalculator.Hide();
                    UnealtaCalculator.Location = new Point(330, 4);
                    UnealtaDeterminanti.Hide();
                    UnealtaDeterminanti.Location = new Point(330, 4);
                    UnealtaMatrici.Hide();
                    UnealtaMatrici.Location = new Point(330, 4);
                    UnealtaEcuatie.Hide();
                    UnealtaEcuatie.Location = new Point(330, 4);

                    TheFirstPanel = UnealtaTriunghi;
                    UnealtaTriunghi.Show();
                    UnealtaTriunghi.BringToFront();
                    TheFirstPanel.Location = new Point(330, 3);
                    SwypeUnelteTimer.Start();
                }
            }
        }

        private void EvaluatorButton2_Click(object sender, EventArgs e)
        {
            Evaluator ev = new Evaluator(linkLabel1.Text);
            ev.Show();
        }

        private void CautaPeNetButton2_Click(object sender, EventArgs e)
        {
            Net net = new Net();
            net.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                incarcaNewPass();
                incarcaMateriile();
                incarcaMateriiProfilElev();
                incarcaMateriileCatalog();
                incarcaEleviiCatalog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        public void changePanels(Panel panel1, Panel panel2)
        {
            if (panel1.Location.X == 0 && panel1.Location.Y == 0)
            {
                oldX = panel2.Location.X;
                oldY = panel2.Location.Y;
                theWantedPanel = panel2;
                if (way.Next() % 2 == 0)
                {
                    theWantedPanel.Location = new Point(30, 0);
                }
                else
                {
                    theWantedPanel.Location = new Point(0, 30);
                }
                theNotWantedPanel = panel1;
                theNotWantedPanel.Location = new Point(oldX, oldY);
            }
            else
                if (panel2.Location.X == 0 && panel2.Location.Y == 0)
                {
                    oldX = panel1.Location.X;
                    oldY = panel1.Location.Y;
                    theWantedPanel = panel1;
                    if (way.Next() % 2 == 0)
                    {
                        theWantedPanel.Location = new Point(30, 0);
                    }
                    else
                    {
                        theWantedPanel.Location = new Point(0, 30);
                    }
                    theNotWantedPanel = panel2;
                    theNotWantedPanel.Location = new Point(oldX, oldY);
                }
            theWantedPanel.BringToFront();
            timerPaneluri.Start();
            //int x = panel1.Location.X, y = panel1.Location.Y;
            //panel1.Location = new Point(panel2.Location.X, panel2.Location.Y);
            //panel2.Location = new Point(x, y);
        }

        Random way = new Random();
        //Panel FirstPanel, SecondPanel;
        //int xFirstPanel, yFirstPanel, xSecondPanel, ySecondPanel;
        Panel theWantedPanel, theNotWantedPanel;
        int newX, newY, oldX, oldY;
        /// <summary>
        /// first panel is the one that slides
        /// </summary>
        private void swypePaneluri()
        {
            //misca pe orizontala
            if (theWantedPanel.Location.Y == 0)
            {
                if (theWantedPanel.Location.X > 15)
                {
                    theWantedPanel.Location = new Point(theWantedPanel.Location.X - 8, theWantedPanel.Location.Y);
                }
                else
                    if (theWantedPanel.Location.X > 0)
                    {
                        theWantedPanel.Location = new Point(theWantedPanel.Location.X - 2, theWantedPanel.Location.Y);
                    }
                    else
                    {
                        timerPaneluri.Stop();
                        theWantedPanel.Location = new Point(0, 0);
                        theNotWantedPanel.Location = new Point(oldX, oldY);
                    }
            }
            else//misca pe verticala
                if (theWantedPanel.Location.X == 0)
                {
                    if (theWantedPanel.Location.Y > 15)
                    {
                        theWantedPanel.Location = new Point(theWantedPanel.Location.X, theWantedPanel.Location.Y - 8);
                    }
                    else
                        if (theWantedPanel.Location.Y > 0)
                        {
                            theWantedPanel.Location = new Point(theWantedPanel.Location.X, theWantedPanel.Location.Y - 2);
                        }
                        else
                        {
                            timerPaneluri.Stop();
                            theWantedPanel.Location = new Point(0, 0);
                            theNotWantedPanel.Location = new Point(oldX, oldY);
                        }
                }
        }

        private void SwypePaneluriTimer_Tick(object sender, EventArgs e)
        {
            //if (stopPanelUnelte != "nimic")
            {
                swypePaneluri();
            }
        }

        private void GoBackUnelte_Click(object sender, EventArgs e)
        {
            UnealtaCalculator.Location = new Point(330, 4);
            UnealtaCalculator.Hide();
            UnealtaEcuatie.Location = new Point(330, 4);
            UnealtaMatrici.Hide();
            UnealtaMatrici.Location = new Point(330, 4);
            UnealtaTriunghi.Hide();
            UnealtaTriunghi.Location = new Point(330, 4);
            UnealtaDeterminanti.Hide();
            UnealtaDeterminanti.Location = new Point(330, 4);
            this.Size = new System.Drawing.Size(718, 350); changePanels(PanelUnelte, PanelForm1);
            this.Text = "Ease Class";
        }

        int waitForStart = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.Hide();

            try
            {
                if (waitForStart == 1)
                {
                    incarcaMateriile();
                }
                if (waitForStart == 2)
                {
                    incarcaMateriiProfilElev();
                }
                if (waitForStart == 3)
                {
                    incarcaMateriileCatalog();
                }
                if (waitForStart == 4)
                {
                    //incarcaNewPass();
                    panel1.Hide();
                    timerLoad.Stop();
                    timer1.Stop();
                }
            }
            catch (Exception ex)
            {
                if (MessageBox.Show("Programul a intampinat o eroare!" + '\n' + "Va rugam pornitil din nou!", "Si dus a fost...",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    //Application.Restart();
                    Close();
                }
            }
            
            waitForStart++;
            //if (progressBar1.Value < 5)
            //{
                progressBar1.Value++;
            //}
            if (progressBar1.Value == 8)
            {
                timerLoad.Stop();
                timerPuncteIncet.Stop();
                timer1.Stop();
            }
        }
        





        bool downTest = false;
        Button GoBackButtonTest;
        int hGoBackTest, wGoBackTest;
        float procentOfFontSize = 0;

        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (downTest == false)
                {
                    downTest = true;

                    GoBackButtonTest = (Button)sender;
                    GoBackButtonTest.TextAlign = ContentAlignment.TopCenter;
                    
                    hGoBackTest = GoBackButtonTest.Height;
                    wGoBackTest = GoBackButtonTest.Width;

                    Font fontvechi = GoBackButtonTest.Font;
                    procentOfFontSize = (GoBackButtonTest.Width / fontvechi.Size) / 25;

                    timerDown.Start();
                    timerDown.Enabled = true;
                    timerUp.Stop();
                    timerUp.Enabled = false;
                }
            }
        }

        private void button_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (downTest == true)
                {
                    GoBackButtonTest.TextAlign = ContentAlignment.MiddleCenter;
                    downTest = false;
                    timerUp.Start();
                    timerUp.Enabled = true;
                    timerDown.Stop();
                    timerDown.Enabled = false;
                }
            }
        }

        private void timerDown_TickDown(object sender, EventArgs e)
        {
            if (GoBackButtonTest.Width > wGoBackTest - 6)
            {
                timerUp.Stop();
                timerUp.Enabled = false;

                Font fontvechi = GoBackButtonTest.Font;
                //float sizeFont = fontvechi.Size - 0.5F;
                float sizeFont = fontvechi.Size - procentOfFontSize;// (GoBackButtonTest.Width / fontvechi.Size) / 25;
                GoBackButtonTest.Font = new System.Drawing.Font("Microsoft Sans Serif", sizeFont, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    
                GoBackButtonTest.Width--;
                GoBackButtonTest.Width--;
                GoBackButtonTest.Height--;
                GoBackButtonTest.Height--;
                
                int x = GoBackButtonTest.Location.X + 1, y = GoBackButtonTest.Location.Y + 1;
                GoBackButtonTest.Location = new Point(x, y);
            }
            else
            {
                timerDown.Stop();
                timerDown.Enabled = false;
            }
        }

        private void timerUp_TickUp(object sender, EventArgs e)
        {
            if (GoBackButtonTest.Width < wGoBackTest)
            {
                timerDown.Stop();
                timerDown.Enabled = false;

                Font fontvechi = GoBackButtonTest.Font;
                //float sizeFont = fontvechi.Size + 0.5F;
                float sizeFont = fontvechi.Size + procentOfFontSize;// (GoBackButtonTest.Width / fontvechi.Size) / 25;
                GoBackButtonTest.Font = new System.Drawing.Font("Microsoft Sans Serif", sizeFont, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    
                GoBackButtonTest.Width++;
                GoBackButtonTest.Width++;
                GoBackButtonTest.Height++;
                GoBackButtonTest.Height++;
                int x = GoBackButtonTest.Location.X - 1, y = GoBackButtonTest.Location.Y - 1;
                GoBackButtonTest.Location = new Point(x, y);
            }
            else
            {
                timerUp.Stop();
                timerUp.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Programul a intimpinat o eroare!" + '\n' + "Va rugam pornitil din nou!", "Si dus a fost...",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                Close();
            }
        }

        /// <summary>
        /// cand da log in si introduce o parola sau id gresit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CampLogInId_TextChanged(object sender, EventArgs e)
        {
            LogInButton.BackColor = Color.YellowGreen;
            labelLogInStatus.Hide();
        }

        /// <summary>
        /// cand schimba textul la inregistrare sa schimbe culoarea butonului
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumeRegister_TextChanged(object sender, EventArgs e)
        {
            labelRegisterStatus.Hide();
            RegisterButton.BackColor = Color.LightSteelBlue;
        }

        private void timerSecunde_Tick(object sender, EventArgs e)
        {
            if (SecundeLabelTestElev.Location.Y < 14)
            {
                SecundeLabelTestElev.Location = new Point(SecundeLabelTestElev.Location.X, SecundeLabelTestElev.Location.Y + 1);
            }
            else
            {
                timerSecunde.Stop();
            }
        }

        private void timerMinute_Tick(object sender, EventArgs e)
        {
            if (MinuteLabelTestElev.Location.Y < 14)
            {
                MinuteLabelTestElev.Location = new Point(MinuteLabelTestElev.Location.X, MinuteLabelTestElev.Location.Y + 1);
            }
            else
            {
                timerMinute.Stop();
            }
        }

        int kRapid = 6, klent = 1, pozInitial = -73;
        private void timerLoad_Tick(object sender, EventArgs e)
        {
            if (punct1.Location.X <= 0)
            {
                punct1.Location = new Point(punct1.Location.X + klent, punct1.Location.Y);
            }
            if (punct2.Location.X <= 0)
            {
                punct2.Location = new Point(punct2.Location.X + klent, punct2.Location.Y);
            }
            if (punct3.Location.X <= 0)
            {
                punct3.Location = new Point(punct3.Location.X + klent, punct3.Location.Y);
            }
            if (punct4.Location.X <= 0)
            {
                punct4.Location = new Point(punct4.Location.X + klent, punct4.Location.Y);
            }
            if (punct5.Location.X <= 0)
            {
                punct5.Location = new Point(punct5.Location.X + klent, punct5.Location.Y);
            }

            if ((punct1.Location.X <= panelPuncte.Width / 2 - 25 || punct1.Location.X >= panelPuncte.Width / 2 + 25)&&
                punct1.Location.X <= panelPuncte.Width && punct1.Location.X >= 0)
            {
                punct1.Location = new Point(punct1.Location.X + kRapid, punct1.Location.Y);
            }
            else
                    if (punct1.Location.X >= panelPuncte.Width)
                    {
                        punct1.Location = new Point(pozInitial, punct1.Location.Y);
                    }

            if ((punct2.Location.X <= panelPuncte.Width / 2 - 25 || punct2.Location.X >= panelPuncte.Width / 2 + 25) &&
                punct2.Location.X <= panelPuncte.Width && punct2.Location.X >= 0)
            {
                punct2.Location = new Point(punct2.Location.X + kRapid, punct2.Location.Y);
            }
            else
                if (punct2.Location.X >= panelPuncte.Width)
                {
                    punct2.Location = new Point(pozInitial, punct2.Location.Y);
                }

            if ((punct3.Location.X <= panelPuncte.Width / 2 - 25 || punct3.Location.X >= panelPuncte.Width / 2 + 25) &&
                punct3.Location.X <= panelPuncte.Width && punct3.Location.X >= 0)
            {
                punct3.Location = new Point(punct3.Location.X + kRapid, punct3.Location.Y);
            }
            else
                if (punct3.Location.X >= panelPuncte.Width)
                {
                    punct3.Location = new Point(pozInitial, punct3.Location.Y);
                }

            if ((punct4.Location.X <= panelPuncte.Width / 2 - 25 || punct4.Location.X >= panelPuncte.Width / 2 + 25) &&
                punct4.Location.X <= panelPuncte.Width && punct4.Location.X >= 0)
            {
                punct4.Location = new Point(punct4.Location.X + kRapid, punct4.Location.Y);
            }
            else
                if (punct4.Location.X >= panelPuncte.Width)
                {
                    punct4.Location = new Point(pozInitial, punct4.Location.Y);
                }

            if ((punct5.Location.X <= panelPuncte.Width / 2 - 25 || punct5.Location.X >= panelPuncte.Width / 2 + 25) &&
                punct5.Location.X <= panelPuncte.Width && punct5.Location.X >= 0)
            {
                punct5.Location = new Point(punct5.Location.X + kRapid, punct5.Location.Y);
            }
            else
                if (punct5.Location.X >= panelPuncte.Width)
                {
                    punct5.Location = new Point(pozInitial, punct5.Location.Y);
                }
        }

        private void timerPuncteIncet_Tick(object sender, EventArgs e)
        {
            if (punct1.Location.X >= panelPuncte.Width / 2 - 25 && punct1.Location.X <= panelPuncte.Width / 2 + 25)
            {
                punct1.Location = new Point(punct1.Location.X + klent, punct1.Location.Y);
            }

            if (punct2.Location.X >= panelPuncte.Width / 2 - 25 && punct2.Location.X <= panelPuncte.Width / 2 + 25)
            {
                punct2.Location = new Point(punct2.Location.X + klent, punct2.Location.Y);
            }

            if (punct3.Location.X >= panelPuncte.Width / 2 - 25 && punct3.Location.X <= panelPuncte.Width / 2 + 25)
            {
                punct3.Location = new Point(punct3.Location.X + klent, punct3.Location.Y);
            }

            if (punct4.Location.X >= panelPuncte.Width / 2 - 25 && punct4.Location.X <= panelPuncte.Width / 2 + 25)
            {
                punct4.Location = new Point(punct4.Location.X + klent, punct4.Location.Y);
            }
            if (punct5.Location.X >= panelPuncte.Width / 2 - 25 && punct5.Location.X <= panelPuncte.Width / 2 + 25)
            {
                punct5.Location = new Point(punct5.Location.X + klent, punct5.Location.Y);
            }
        }

    


    }
}
