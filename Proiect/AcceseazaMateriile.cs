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
    public partial class AcceseazaMateriile : Form
    {
        Button[] materiile = new Button[140];
        int nrMaterii = 0;
        string tipUtilizator = "";
        string userName = "";

        public AcceseazaMateriile(string utilizator, string numeUtilizator)
        {
            InitializeComponent();
            tipUtilizator = utilizator;
            userName = numeUtilizator;

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
                    materiile[i].Location = new System.Drawing.Point(33, materiile[i - 1].Location.Y + 35);
                }
                materiile[i].Size = new System.Drawing.Size(61, 23);
                materiile[i].TabIndex = 1;
                materiile[i].Text = materii[i];
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
                if (sender.Equals(materiile[i]))
                {
                    NewListaLectiiSiTeste l = new NewListaLectiiSiTeste(materiile[i].Text, tipUtilizator, userName);
                    l.Show();
                }
            }
        }
    }
}
