using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proiect
{

    public partial class Register : Form
    {
        BazaDate bd = new BazaDate();
        //int ba = 0;
        //int idNR;
        public Register()
        {
            InitializeComponent();
            //ba = bd.selectid();
            //ba++;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Parola1.PasswordChar = '*';
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Parola2.PasswordChar = '*';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserName.Clear();
            Parola1.Clear();
            Parola2.Clear();
            Nume.Clear();
            Prenume.Clear();
            Oras.Clear();
            Question.Clear();
            Profesor.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Daca a introdus toate datele
            if (UserName.Text != "" &&
                Parola1.Text != "" &&
                Parola2.Text != "" &&
                Nume.Text != "" &&
                Question.Text != "" &&
                Answer.Text != "")
            {
                //verific daca id-ul are spatii
                bool lala = false;
                for (int i = 0; i < UserName.Text.Length; i++)
                {
                    if (UserName.Text[i] == ' ')
                    {
                        lala = true;
                    }
                }

                for (int i = 0; i < Parola1.Text.Length; i++)
                {
                    if (Parola1.Text[i] == ' ')
                    {
                        lala = true;
                    }
                }

                if (lala == false)
                {
                    //daca parola este corecta in ambele cazuri
                    if (Parola1.Text == Parola2.Text)
                    {
                        //daca nu exista deja utilizatorul
                        if (bd.selectU(UserName.Text) == 0)
                        {
                            //in Table2 se afla niste coduri date de catre admin, cu care profesorii pot crea conturi
                            int nr=0;
                            string h = bd.selectIdProf();
                            string[] iduri = h.Split(';');
                            for (int l = 0; l < h.Length; l++)
                            {
                                if (h[l] == ';')
                                {
                                    nr++;
                                }
                            }
                            bool lalala = false;
                            for (int o = 0; o < nr; o++)
                            {
                                if (Profesor.Text == iduri[o])
                                {
                                    bd.insertCryptedPassword(Oras.Text, Nume.Text, Prenume.Text, Question.Text, Answer.Text, UserName.Text, Parola1.Text, "Da");
                                    //bd.insereazaProf(ba, Nume.Text, Prenume.Text, UserName.Text, Parola1.Text, Oras.Text, Question.Text, Answer.Text);
                                    MessageBox.Show("Felicitări! Ai fost adăugat ca profesor!");
                                    Close();
                                    lalala = true;
                                    bd.stergeIdProf(iduri[o]);
                                    break;
                                }
                            }
                            if (lalala == false)
                            {
                                bd.insertCryptedPassword(Oras.Text, Nume.Text, Prenume.Text, Question.Text, Answer.Text, UserName.Text, Parola1.Text, "Nu");
                                //bd.insereaza(ba, Nume.Text, Prenume.Text, UserName.Text, Parola1.Text, Oras.Text, Question.Text, Answer.Text);
                                MessageBox.Show("Felicitări! Ai fost adăugat ca elev!");
                                Close();
                            }
                            lalala = false;
                        }
                        else
                        {
                            MessageBox.Show("Nume utilizator deja existent");
                            UserName.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Parola greșită" + '\n' + "Reintroduceți parola");
                        Parola1.Clear();
                        Parola2.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Id-ul si parola nu trebuie să conțină spații!");
                }
            }
        }

    }
}
