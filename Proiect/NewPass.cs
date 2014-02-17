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
    public partial class NewPass : Form
    {
        string[] nume = new string[40];
        string[] nume2 = new string[40];
        int k = 0;
            
        public NewPass()
        {
            InitializeComponent();
            /*for (int i = 0; i <= bd.selectid(); i++)
            {
                //if (bd.selectElevi(i) != "0" && bd.selectProfElev(i) == 2)
                if (bd.selectIdNewPass(i) != "" && bd.selectIdNewPass(i) != "bmbnmbnm  ")
                {
                    nume[k] = bd.selectIdNewPass(i);
                    k++;
                }
            }*/

            
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < nume[i].Length; j++)
                {
                    if (nume[i][j] != ' ')
                    {
                        nume2[i] += nume[i][j];
                    }
                }
            }
        }

        BazaDate bd = new BazaDate();

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox3.Text != "")
                {
                    if (bd.selectU(textBox1.Text) == 1)
                    {
                        if (bd.selectRaspuns(textBox1.Text, textBox3.Text))
                        {
                            Random r = new Random();
                            string s = "qwertyuiopasdfghjklzxcvbnm1234567890";
                            string pw = "";
                            for (int i = 0; i < 6; i++)
                            {
                                pw += s[r.Next(36)];
                            }
                            textBox4.Text = pw;

                            label4.Show();
                            textBox4.Show();
                            bd.schimbaPass(textBox1.Text, pw);
                            pictureBox1.Image = global::Proiect.Properties.Resources.bullet_accept;
                        }
                        else
                        {
                            MessageBox.Show("Răspunsul la întrebare este incorect!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Id-ul sau răspunsul la întrebare este incorect!");
                    }
                }
                else
                {
                    MessageBox.Show("Nu ai introdus întrebarea!");
                }
            }
            else
            {
                MessageBox.Show("Nu ai introdus id-ul!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = global::Proiect.Properties.Resources.bullet_info;
            //string[] nume = new string[40];
            string s = textBox1.Text;
            for (int i = 0; i < k; i++)
            {
                if (nume2[i] == s)
                {
                    textBox2.Text = bd.selectEmail(s);
                    break;
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = global::Proiect.Properties.Resources.bullet_info;
        }


    }
}
