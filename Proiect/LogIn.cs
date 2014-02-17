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
    public partial class LogIn : Form
    {
        public int logat = 0;
        BazaDate bd = new BazaDate();
        public Form1 principal = null;
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            
        public LogIn(Form inlocuie)
        {
            principal = inlocuie as Form1;
            InitializeComponent();
        }
        
        public int sw = -1;
        public void button1_Click(object sender, EventArgs e)
        {
            if (bd.select(textBox1.Text, textBox2.Text) == 2)
            {
                principal.linkLabel1.Text = "Elev";
                principal.linkLabel2.Text = textBox1.Text;


                /*
                principal.CalculatorPicture.Show();
                principal.MatriciPicture.Show();
                principal.EcuatiiPicture.Show();
                principal.DeterminantiPicture.Show();
                principal.CautaPeNetPicture.Show();
                principal.EvaluatorInformaticaPicture.Show();
                principal.TriunghiuriPicture.Show();

                */



                principal.AutentificareButton.Text = textBox1.Text;
                principal.AutentificarePicture.Image = global::Proiect.Properties.Resources.user_info;
                
                principal.InregistrareButton.Hide();
                principal.InregistrarePicture.Hide();
                
                principal.DeconectareButton.Show();
                principal.IesirePicture.Show();
                principal.RamaiConectatButton.Show();
                principal.RamaiConectatPicture.Show();

                principal.AutentificareButton.Click -= new System.EventHandler(principal.autentificare);
                principal.AutentificareButton.Click -= new System.EventHandler(principal.autentificare2);
                principal.AutentificareButton.Click -= new System.EventHandler(principal.button5_Click_2);
                principal.AutentificareButton.Click += new System.EventHandler(principal.autentificare);

                principal.RamaiConectatButton.Location = new Point(principal.in1, principal.in2);
                principal.RamaiConectatPicture.Location = new Point(principal.p2, principal.p22);
                principal.DeconectareButton.Location = new Point(principal.i1, principal.i2);
                principal.IesirePicture.Location = new Point(principal.p3, principal.p33);





 //               principal.label2.Show();
                //principal.label3.Show();
/*                principal.CalculatorButton.Show();
                principal.DeterminantiButton.Show();
                principal.MatriciButton.Show();
                principal.EvaluatorInformaticaButton.Show();
                principal.CautaPeNetButton.Show();
                principal.TriunghiuriButton.Show();
                principal.EcuatiiButton.Show();
                //principal.linkLabel5.Show();
  */              
                //bd.insertName(textBox1.Text);

                Close();
                logat = 2;
                
            }
            else
                if (bd.select(textBox1.Text, textBox2.Text) == 1)
                {
                    principal.linkLabel1.Text = "Profesor";
                    //principal.linkLabel4.Show();
                    principal.linkLabel2.Text = textBox1.Text;
                    //principal.linkLabel3.Show();
                    //principal.linkLabel5.Show();



                    /*
                    principal.CalculatorPicture.Show();
                    principal.MatriciPicture.Show();
                    principal.EcuatiiPicture.Show();
                    principal.DeterminantiPicture.Show();
                    principal.CautaPeNetPicture.Show();
                    principal.EvaluatorInformaticaPicture.Show();
                    principal.TriunghiuriPicture.Show();
                    */





                    principal.AutentificareButton.Text = textBox1.Text;
                    principal.AutentificarePicture.Image = global::Proiect.Properties.Resources.user_info;
                    
                    principal.InregistrareButton.Hide();
                    principal.InregistrarePicture.Hide();
                    
                    principal.DeconectareButton.Show();
                    principal.IesirePicture.Show();
                    principal.RamaiConectatButton.Show();
                    principal.RamaiConectatPicture.Show();
                    principal.CatalogButton.Show();
                    principal.CatalogPicture.Show();

                    principal.AutentificareButton.Click -= new System.EventHandler(principal.autentificare2);
                    principal.AutentificareButton.Click -= new System.EventHandler(principal.autentificare);
                    principal.AutentificareButton.Click -= new System.EventHandler(principal.button5_Click_2);
                    principal.AutentificareButton.Click += new System.EventHandler(principal.autentificare2);

                    //iesire pe 4
                    principal.DeconectareButton.Location = new Point(principal.r1, principal.r2);
                    principal.IesirePicture.Location = new Point(principal.p4, principal.p44);
                    //ramane pe 3
                    principal.RamaiConectatButton.Location = new Point(principal.i1, principal.i2);
                    principal.RamaiConectatPicture.Location = new Point(principal.p3, principal.p33);
                    //catalog pe 2
                    principal.CatalogButton.Location = new Point(principal.in1, principal.in2);
                    principal.CatalogPicture.Location = new Point(principal.p2, principal.p22);



//                    principal.label2.Show();
                    //principal.label3.Show();
                    /*principal.CalculatorButton.Show();
                    principal.DeterminantiButton.Show();
                    principal.MatriciButton.Show();
                    principal.EvaluatorInformaticaButton.Show();
                    principal.CautaPeNetButton.Show();
                    principal.TriunghiuriButton.Show();
                    principal.EcuatiiButton.Show();
                    */
                    //bd.insertName(textBox1.Text);
    
                    Close();
                }
                else
                    if (bd.select(textBox1.Text, textBox2.Text) == 0)
                    {
                        MessageBox.Show("Nume utilizator sau parola gresită");
                        textBox1.Clear();
                        textBox2.Clear();
                    }
        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        public void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void LogIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            //formla1.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NewPass n = new NewPass();
            n.Show();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1.PerformClick();
            }
        }
    }
}
