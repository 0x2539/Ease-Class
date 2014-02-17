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
    public partial class CreateMaterieNoua : Form
    {
        public CreateMaterieNoua()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, EventArgs e)
        {

            try
            {
                BazaDate bd = new BazaDate();
                //inserez materia
                bd.InsertNewColumn(textBox1.Text, "nvarchar(MAX)", "Table1");
                //inserez coloana pentru data
                bd.InsertNewColumn("data" + textBox1.Text, "nvarchar(MAX)", "Table1");

                //application.startuppath = locatia aplicatiei
                //textBox1.Text = Application.StartupPath;
                richTextBox1.LoadFile(Application.StartupPath + "\\materii.materie", RichTextBoxStreamType.PlainText);
                richTextBox1.Text += textBox1.Text + '\n';
                richTextBox1.SaveFile(Application.StartupPath + "\\materii.materie", RichTextBoxStreamType.PlainText);
                MessageBox.Show("Materia a fost adaugata cu succes!");
            }
            catch
            {
                MessageBox.Show("Materia deja exista!");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            richTextBox1.LoadFile(Application.StartupPath + "\\materii.materie", RichTextBoxStreamType.PlainText);
            try
            {
                BazaDate bd = new BazaDate();
                //sterg coloana cu materia
                bd.DeleteColumn(textBox1.Text, "Table1");
                //daca exista materia
                if (richTextBox1.Text.IndexOf(textBox1.Text) != -1)
                {
                    //daca in stanga si dreapta ei se afla '\n'
                    if ((richTextBox1.Text[richTextBox1.Text.IndexOf(textBox1.Text) - 1] == '\n' || 
                        richTextBox1.Text.IndexOf(textBox1.Text) == 0) &&
                        richTextBox1.Text[richTextBox1.Text.IndexOf(textBox1.Text) + textBox1.Text.Length] == '\n')
                    {
                        richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.Text.IndexOf(textBox1.Text), textBox1.Text.Length);
                        richTextBox1.SaveFile(Application.StartupPath + "\\materii.materie", RichTextBoxStreamType.PlainText);
                    }
                }
                
                //sterg coloana cu data de la materie
                /*if (textBox1.Text == "Matematica")
                {
                    bd.DeleteColumnNameMaterie("datam");
                }
                else
                    if (textBox1.Text == "Fizica")
                    {
                        bd.DeleteColumnNameMaterie("dataf");
                    }
                    else
                        if (textBox1.Text == "Chimie")
                        {
                            bd.DeleteColumnNameMaterie("datac");
                        }
                        else
                            if (textBox1.Text == "Informatica")
                            {
                                bd.DeleteColumnNameMaterie("datai");
                            }
                            else
                            {*/
                                bd.DeleteColumn("data" + textBox1.Text, "Table1");
                            //}

            }
            catch
            {
                MessageBox.Show("Eroare!");
            }
        }


    }
}
