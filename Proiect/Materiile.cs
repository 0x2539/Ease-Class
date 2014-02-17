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
    public partial class Materiile : Form
    {

        Button[] materiile = new Button[140];
        string[] initialNames = new string[140];
        int nrMaterii = 0;

        public Materiile()
        {
            InitializeComponent();
            richTextBox1.LoadFile(Application.StartupPath + "\\materii.materie", RichTextBoxStreamType.PlainText);
            
            string[] materii = richTextBox1.Text.Split('\n');
            nrMaterii = materii.Length;

            for (int i = 0; i < materii.Length - 1; i++)
            {
                materiile[i] = new Button();
                materiile[i].AutoSize = true;
                materiile[i].AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                if (i == 0)
                {
                    materiile[i].Location = new System.Drawing.Point(33, 24);
                }
                else
                {
                    materiile[i].Location = new System.Drawing.Point(33, materiile[i-1].Location.Y + 35);
                }
                materiile[i].Size = new System.Drawing.Size(61, 23);
                materiile[i].TabIndex = 1;
                materiile[i].Text = materii[i];

                //retin numele initiale, pentru ca imi trebuiesc cand le schimb in baza de date
                initialNames[i] = materii[i];
                
                materiile[i].UseVisualStyleBackColor = true;
                //MessageBox.Show(materii[i]);
                materiile[i].Click += new System.EventHandler(this.button1_Click);
                Controls.Add(materiile[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < nrMaterii - 1; i++)
            {
                if (materiile[i].Equals(sender))
                {
                    textBox1.Text = materiile[i].Text;
                    textBox1.Location = new Point(materiile[i].Location.X + materiile[i].Width + 10, materiile[i].Location.Y + 2);
                    textBox1.Show();
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            //try
            //{
                for (int i = 0; i < nrMaterii - 1; i++)
                {
                    BazaDate bd = new BazaDate();
                    bd.ChangeColumnNameMaterie(initialNames[i], materiile[i].Text);
                    richTextBox2.Text += materiile[i].Text + '\n';
                }
                richTextBox2.SaveFile(Application.StartupPath + "\\materii.materie", RichTextBoxStreamType.PlainText);
                Close();
            /*}
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }*/
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                for (int i = 0; i < nrMaterii - 1; i++)
                {
                    if (materiile[i].Location.Y == textBox1.Location.Y - 2)
                    {
                        materiile[i].Text = textBox1.Text;
                        textBox1.Location = new Point(materiile[i].Location.X + materiile[i].Width + 10, textBox1.Location.Y);
                    }
                }
            }
        }

    }
}
