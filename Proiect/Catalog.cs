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
    public partial class Catalog : Form
    {
        string[] nume = new string[40];
        string[] iduri = new string[40];

        int sterge1 = 0, sterge2 = 0, sterge3 = 0, sterge4 = 0;
        int apasat = 0;

        public Label[] elevi = new Label[40];
        public TextBox[] note1 = new TextBox[40];
        public TextBox[] date1 = new TextBox[40];
        public Label[] note2 = new Label[40];
        public Label[] note3 = new Label[40];
        public Label[] note4 = new Label[40];


        public TextBox[] tb = new TextBox[40];
        
        int k = 0;
        BazaDate bd = new BazaDate();
            
        public Catalog()
        {
            InitializeComponent();

            /*for (int i = 0; i <= bd.selectid(); i++)
            {
                if (bd.selectElevi(i) != "0" && bd.selectProfElev(i) == 2)
                {
                    nume[k] = bd.selectElevi(i);
                    iduri[k] = bd.selectConturi(i);
                    k++;
                }
            }*/

            for (int i = 0; i < k; i++)
            {
                comboBox1.Items.Add(nume[i]);
            }
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            button6.Enabled = true;
            labelNota.Text = "Note" + '\n' + "matematica";
            
            if (sterge1 != 0)
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
            int nr1 = 0, nr2 = 0, nr3 = 0, nr4 = 0;//nr vor reprezenta numarul de note pentru fiecare materie

            for (int i = 0; i < k; i++)
            {
                if (comboBox1.Text == nume[i])
                {
                    //verific daca are note
                    if (bd.selectNoteMatematica(iduri[i]) != "")
                    {
                        //vad care este numarul de note
                        for (int j = 0; j < bd.selectNoteMatematica(iduri[i]).Length; j++)
                        {
                            if (bd.selectNoteMatematica(iduri[i])[j] == ';')
                            {
                                nr1++;
                            }
                        }
                        //nr1++;
                        sterge1 = nr1;
                        //vad care sunt notele
                        string[] not1 = bd.selectNoteMatematica(iduri[i]).Split(';');
                        string[] dat1 = bd.selectDataMatematica(iduri[i]).Split(';');
                        note1[0] = new TextBox();
                        note1[0].BackColor = System.Drawing.SystemColors.Control;
                        note1[0].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        note1[0].Location = new System.Drawing.Point(textBox1.Location.X, textBox1.Location.Y);
                        note1[0].Size = new System.Drawing.Size(115, 23);
                        note1[0].Text = not1[0];
                        Controls.Add(note1[0]);
                        note1[0].TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            

                        date1[0] = new TextBox();
                        date1[0].BackColor = System.Drawing.SystemColors.Control;
                        date1[0].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        date1[0].Location = new System.Drawing.Point(textBox2.Location.X, textBox2.Location.Y);
                        date1[0].Size = new System.Drawing.Size(115, 23);
                        date1[0].Text = dat1[0];
                        Controls.Add(date1[0]);
                        date1[0].TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            
                        if (nr1 > 1)
                        {
                            for (int j = 1; j < nr1; j++)
                            {
                                note1[j] = new TextBox();
                                note1[j].Location = new System.Drawing.Point(note1[j - 1].Location.X, note1[j - 1].Location.Y + 23);
                                note1[j].BackColor = System.Drawing.SystemColors.Control;
                                note1[j].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                                note1[j].Size = new System.Drawing.Size(115, 23);
                                note1[j].Text = not1[j];
                                Controls.Add(note1[j]);
                                note1[j].TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            

                                date1[j] = new TextBox();
                                date1[j].Location = new System.Drawing.Point(date1[j - 1].Location.X, date1[j - 1].Location.Y + 23);
                                date1[j].BackColor = System.Drawing.SystemColors.Control;
                                date1[j].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                                date1[j].Size = new System.Drawing.Size(115, 23);
                                date1[j].Text = dat1[j];
                                Controls.Add(date1[j]);
                                date1[j].TextChanged += new System.EventHandler(this.textBox1_TextChanged);
                            }
                        }
                        apasat = 1;
                    }
                    else
                    {
                        note1[0] = new TextBox();
                        note1[0].Location = new System.Drawing.Point(textBox1.Location.X, textBox1.Location.Y);
                        note1[0].BackColor = System.Drawing.SystemColors.Control;
                        note1[0].Size = new System.Drawing.Size(115, 23);
                        note1[0].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        note1[0].Text = "Nu există nici o notă!";
                        Controls.Add(note1[0]);
                        sterge1 = 1;
                        apasat = -1;
                        note1[0].TextChanged += new System.EventHandler(this.textBox1_TextChanged);
                
                        date1[0] = new TextBox();
                        date1[0].Location = new System.Drawing.Point(textBox2.Location.X, textBox2.Location.Y);
                        date1[0].BackColor = System.Drawing.SystemColors.Control;
                        date1[0].Size = new System.Drawing.Size(115, 23);
                        date1[0].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        date1[0].Text = "Nu există nici o notă!";
                        Controls.Add(date1[0]);
                        date1[0].TextChanged += new System.EventHandler(this.textBox1_TextChanged);
                        sterge1 = 1;
                    }
                    break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button6.Enabled = true;
            labelNota.Text = "Note" + '\n' + "fizica";

            if (sterge1 != 0)
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
            int nr1 = 0, nr2 = 0, nr3 = 0, nr4 = 0;//nr vor reprezenta numarul de note pentru fiecare materie

            for (int i = 0; i < k; i++)
            {
                if (comboBox1.Text == nume[i])
                {
                    //verific daca are note
                    if (bd.selectNoteFizica(iduri[i]) != "")
                    {
                        //vad care este numarul de note
                        for (int j = 0; j < bd.selectNoteFizica(iduri[i]).Length; j++)
                        {
                            if (bd.selectNoteFizica(iduri[i])[j] == ';')
                            {
                                nr1++;
                            }
                        }
                        //nr1++;
                        sterge1 = nr1;
                        //vad care sunt notele
                        string[] not1 = bd.selectNoteFizica(iduri[i]).Split(';');
                        string[] dat1 = bd.selectDataFizica(iduri[i]).Split(';');
                        note1[0] = new TextBox();
                        note1[0].BackColor = System.Drawing.SystemColors.Control;
                        note1[0].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        note1[0].Location = new System.Drawing.Point(textBox1.Location.X, textBox1.Location.Y);
                        note1[0].Size = new System.Drawing.Size(115, 23);
                        note1[0].Text = not1[0];
                        Controls.Add(note1[0]);
                        note1[0].TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            
                        date1[0] = new TextBox();
                        date1[0].BackColor = System.Drawing.SystemColors.Control;
                        date1[0].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        date1[0].Location = new System.Drawing.Point(textBox2.Location.X, textBox2.Location.Y);
                        date1[0].Size = new System.Drawing.Size(115, 23);
                        date1[0].Text = dat1[0];
                        Controls.Add(date1[0]);
                        date1[0].TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            
                        if (nr1 > 1)
                        {
                            for (int j = 1; j < nr1; j++)
                            {
                                note1[j] = new TextBox();
                                note1[j].Location = new System.Drawing.Point(note1[j - 1].Location.X, note1[j - 1].Location.Y + 23);
                                note1[j].BackColor = System.Drawing.SystemColors.Control;
                                note1[j].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                                note1[j].Size = new System.Drawing.Size(115, 23);
                                note1[j].Text = not1[j];
                                Controls.Add(note1[j]);
                                note1[j].TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            

                                date1[j] = new TextBox();
                                date1[j].Location = new System.Drawing.Point(date1[j - 1].Location.X, date1[j - 1].Location.Y + 23);
                                date1[j].BackColor = System.Drawing.SystemColors.Control;
                                date1[j].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                                date1[j].Size = new System.Drawing.Size(115, 23);
                                date1[j].Text = dat1[j];
                                Controls.Add(date1[j]);
                                date1[j].TextChanged += new System.EventHandler(this.textBox1_TextChanged);
                            }
                        }
                        apasat = 2;
                    }
                    else
                    {
                        note1[0] = new TextBox();
                        note1[0].Location = new System.Drawing.Point(textBox1.Location.X, textBox1.Location.Y);
                        note1[0].BackColor = System.Drawing.SystemColors.Control;
                        note1[0].Size = new System.Drawing.Size(115, 23);
                        note1[0].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        note1[0].Text = "Nu există nici o notă!";
                        Controls.Add(note1[0]);
                        sterge1 = 1;
                        apasat = -2;
                        note1[0].TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            
                        date1[0] = new TextBox();
                        date1[0].Location = new System.Drawing.Point(textBox2.Location.X, textBox2.Location.Y);
                        date1[0].BackColor = System.Drawing.SystemColors.Control;
                        date1[0].Size = new System.Drawing.Size(115, 23);
                        date1[0].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        date1[0].Text = "Nu există nici o notă!";
                        Controls.Add(date1[0]);
                        sterge1 = 1;
                        date1[0].TextChanged += new System.EventHandler(this.textBox1_TextChanged);
                    }
                    break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button6.Enabled = true;
            labelNota.Text = "Note" + '\n' + "chimie";

            if (sterge1 != 0)
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
            int nr1 = 0, nr2 = 0, nr3 = 0, nr4 = 0;//nr vor reprezenta numarul de note pentru fiecare materie

            for (int i = 0; i < k; i++)
            {
                if (comboBox1.Text == nume[i])
                {
                    //verific daca are note
                    if (bd.selectNoteChimie(iduri[i]) != "")
                    {
                        //vad care este numarul de note
                        for (int j = 0; j < bd.selectNoteChimie(iduri[i]).Length; j++)
                        {
                            if (bd.selectNoteChimie(iduri[i])[j] == ';')
                            {
                                nr1++;
                            }
                        }
                        //nr1++;
                        sterge1 = nr1;
                        //vad care sunt notele
                        string[] not1 = bd.selectNoteChimie(iduri[i]).Split(';');
                        string[] dat1 = bd.selectDataChimie(iduri[i]).Split(';');
                        note1[0] = new TextBox();
                        note1[0].BackColor = System.Drawing.SystemColors.Control;
                        note1[0].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        note1[0].Location = new System.Drawing.Point(textBox1.Location.X, textBox1.Location.Y);
                        note1[0].Size = new System.Drawing.Size(115, 23);
                        note1[0].Text = not1[0];
                        Controls.Add(note1[0]);
                        note1[0].TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            
                        date1[0] = new TextBox();
                        date1[0].BackColor = System.Drawing.SystemColors.Control;
                        date1[0].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        date1[0].Location = new System.Drawing.Point(textBox2.Location.X, textBox2.Location.Y);
                        date1[0].Size = new System.Drawing.Size(115, 23);
                        date1[0].Text = dat1[0];
                        Controls.Add(date1[0]);
                        date1[0].TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            
                        if (nr1 > 1)
                        {
                            for (int j = 1; j < nr1; j++)
                            {
                                note1[j] = new TextBox();
                                note1[j].Location = new System.Drawing.Point(note1[j - 1].Location.X, note1[j - 1].Location.Y + 23);
                                note1[j].BackColor = System.Drawing.SystemColors.Control;
                                note1[j].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                                note1[j].Size = new System.Drawing.Size(115, 23);
                                note1[j].Text = not1[j];
                                Controls.Add(note1[j]);
                                note1[j].TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            

                                date1[j] = new TextBox();
                                date1[j].Location = new System.Drawing.Point(date1[j - 1].Location.X, date1[j - 1].Location.Y + 23);
                                date1[j].BackColor = System.Drawing.SystemColors.Control;
                                date1[j].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                                date1[j].Size = new System.Drawing.Size(115, 23);
                                date1[j].Text = dat1[j];
                                Controls.Add(date1[j]);
                                date1[j].TextChanged += new System.EventHandler(this.textBox1_TextChanged);
                            }
                        }
                        apasat = 3;
                    }
                    else
                    {
                        note1[0] = new TextBox();
                        note1[0].Location = new System.Drawing.Point(textBox1.Location.X, textBox1.Location.Y);
                        note1[0].BackColor = System.Drawing.SystemColors.Control;
                        note1[0].Size = new System.Drawing.Size(115, 23);
                        note1[0].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        note1[0].Text = "Nu există nici o notă!";
                        Controls.Add(note1[0]);
                        sterge1 = 1;
                        apasat = -3;
                        note1[0].TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            
                        date1[0] = new TextBox();
                        date1[0].Location = new System.Drawing.Point(textBox2.Location.X, textBox2.Location.Y);
                        date1[0].BackColor = System.Drawing.SystemColors.Control;
                        date1[0].Size = new System.Drawing.Size(115, 23);
                        date1[0].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        date1[0].Text = "Nu există nici o notă!";
                        Controls.Add(date1[0]);
                        sterge1 = 1;
                        date1[0].TextChanged += new System.EventHandler(this.textBox1_TextChanged);
                    }
                    break;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button6.Enabled = true;
            labelNota.Text = "Note" + '\n' + "informatica";

            if (sterge1 != 0)
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
            int nr1 = 0, nr2 = 0, nr3 = 0, nr4 = 0;//nr vor reprezenta numarul de note pentru fiecare materie

            for (int i = 0; i < k; i++)
            {
                if (comboBox1.Text == nume[i])
                {
                    //verific daca are note
                    if (bd.selectNoteInformatica(iduri[i]) != "")
                    {
                        //vad care este numarul de note
                        for (int j = 0; j < bd.selectNoteInformatica(iduri[i]).Length; j++)
                        {
                            if (bd.selectNoteInformatica(iduri[i])[j] == ';')
                            {
                                nr1++;
                            }
                        }
                        //nr1++;
                        sterge1 = nr1;
                        //vad care sunt notele
                        string[] not1 = bd.selectNoteInformatica(iduri[i]).Split(';');
                        string[] dat1 = bd.selectDataInformatica(iduri[i]).Split(';');
                        note1[0] = new TextBox();
                        note1[0].BackColor = System.Drawing.SystemColors.Control;
                        note1[0].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        note1[0].Location = new System.Drawing.Point(textBox1.Location.X, textBox1.Location.Y);
                        note1[0].Size = new System.Drawing.Size(115, 23);
                        note1[0].Text = not1[0];
                        Controls.Add(note1[0]);
                        note1[0].TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            
                        date1[0] = new TextBox();
                        date1[0].BackColor = System.Drawing.SystemColors.Control;
                        date1[0].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        date1[0].Location = new System.Drawing.Point(textBox2.Location.X, textBox2.Location.Y);
                        date1[0].Size = new System.Drawing.Size(115, 23);
                        date1[0].Text = dat1[0];
                        Controls.Add(date1[0]);
                        date1[0].TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            
                        if (nr1 > 1)
                        {
                            for (int j = 1; j < nr1; j++)
                            {
                                note1[j] = new TextBox();
                                note1[j].Location = new System.Drawing.Point(note1[j - 1].Location.X, note1[j - 1].Location.Y + 23);
                                note1[j].BackColor = System.Drawing.SystemColors.Control;
                                note1[j].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                                note1[j].Size = new System.Drawing.Size(115, 23);
                                note1[j].Text = not1[j];
                                Controls.Add(note1[j]);
                                note1[j].TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            

                                date1[j] = new TextBox();
                                date1[j].Location = new System.Drawing.Point(date1[j - 1].Location.X, date1[j - 1].Location.Y + 23);
                                date1[j].BackColor = System.Drawing.SystemColors.Control;
                                date1[j].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                                date1[j].Size = new System.Drawing.Size(115, 23);
                                date1[j].Text = dat1[j];
                                Controls.Add(date1[j]);
                                date1[j].TextChanged += new System.EventHandler(this.textBox1_TextChanged);
                            }
                        }
                        apasat = 4;
                    }
                    else
                    {
                        note1[0] = new TextBox();
                        note1[0].Location = new System.Drawing.Point(textBox1.Location.X, textBox1.Location.Y);
                        note1[0].BackColor = System.Drawing.SystemColors.Control;
                        note1[0].Size = new System.Drawing.Size(115, 23);
                        note1[0].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        note1[0].Text = "Nu există nici o notă!";
                        Controls.Add(note1[0]);
                        sterge1 = 1;
                        apasat = -4;
                        note1[0].TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            
                        date1[0] = new TextBox();
                        date1[0].Location = new System.Drawing.Point(textBox2.Location.X, textBox2.Location.Y);
                        date1[0].BackColor = System.Drawing.SystemColors.Control;
                        date1[0].Size = new System.Drawing.Size(115, 23);
                        date1[0].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        date1[0].Text = "Nu există nici o notă!";
                        Controls.Add(date1[0]);
                        sterge1 = 1;
                        date1[0].TextChanged += new System.EventHandler(this.textBox1_TextChanged);
                    }
                    break;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //trigonometrie: 1/3;qew: 2/6;
            //7/25/2012, 6:37PM;7/25/2012, 6:38 PM;
            string s1 = "", s2 = "";
            for (int i = 0; i < sterge1; i++)
            {
                //if (note1[i].Text != "" && date1[i].Text != "" &&
                if (date1[i].Text != "" && date1[i].Text != "Nu există nici o notă!")
                {
                    if (note1[i].Text != "" && note1[i].Text != "Nu există nici o notă!")
                    {
                        s1 += note1[i].Text + ';';
                        s2 += date1[i].Text + ';';
                    }
                    else
                    {
                        if (apasat == -1)
                        {
                            apasat = 1;
                        }
                        else
                            if (apasat == -2)
                            {
                                apasat = 2;
                            }
                            else
                                if (apasat == -3)
                                {
                                    apasat = 3;
                                }
                                else
                                    if (apasat == -4)
                                    {
                                        apasat = 4;
                                    }
                        s1 += " ;";
                        s2 += date1[i].Text + ';';
                    }
                }
            }
            if (apasat == 1)
            {
                for (int i = 0; i < k; i++)
                {
                    if (nume[i] == comboBox1.Text)
                    {
                        bd.NotaCatalogM(iduri[i], s1);
                        bd.DataCatalogM(iduri[i], s2);
                    }
                }
                pictureBox4.Image = global::Proiect.Properties.Resources.bullet_accept;
                button5.Enabled = false;
            }

            if (apasat == 2)
            {
                for (int i = 0; i < k; i++)
                {
                    if (nume[i] == comboBox1.Text)
                    {
                        bd.NotaCatalogF(iduri[i], s1);
                        bd.DataCatalogF(iduri[i], s2);
                    }
                }
                pictureBox4.Image = global::Proiect.Properties.Resources.bullet_accept;
                button5.Enabled = false;
            }

            if (apasat == 3)
            {
                for (int i = 0; i < k; i++)
                {
                    if (nume[i] == comboBox1.Text)
                    {
                        bd.NotaCatalogC(iduri[i], s1);
                        bd.DataCatalogC(iduri[i], s2);
                    }
                }
                pictureBox4.Image = global::Proiect.Properties.Resources.bullet_accept;
                button5.Enabled = false;
            }

            if (apasat == 4)
            {
                MessageBox.Show("asdsadasdasda");
                for (int i = 0; i < k; i++)
                {
                    if (nume[i] == comboBox1.Text)
                    {
                        bd.NotaCatalogI(iduri[i], s1);
                        bd.DataCatalogI(iduri[i], s2);
                    }
                }
                pictureBox4.Image = global::Proiect.Properties.Resources.bullet_accept;
                button5.Enabled = false;
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            button5.Enabled = false;
            pictureBox4.Image = global::Proiect.Properties.Resources.bullet_error;
                        
            if (sterge1 != 0)
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
            labelNota.Text = "Nota";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button5.Enabled = true;
            pictureBox4.Image = global::Proiect.Properties.Resources.bullet_info;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (apasat == -1)
            {
                apasat = 1;
            }
            else
                if (apasat == -2)
                {
                    apasat = 2;
                }
                else

                    if (apasat == -3)
                    {
                        apasat = 3;
                    }
                    else
                        if (apasat == -4)
                        {
                            apasat = 4;
                        }
            //string s = bd.selectName();
            
            int nr1=sterge1;
            sterge1++;
            
            note1[nr1] = new TextBox();
            note1[nr1].Location = new System.Drawing.Point(note1[nr1 - 1].Location.X, note1[nr1 - 1].Location.Y + 23);
            note1[nr1].BackColor = System.Drawing.SystemColors.Control;
            note1[nr1].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            note1[nr1].Size = new System.Drawing.Size(115, 23);
            Controls.Add(note1[nr1]);
            note1[nr1].TextChanged += new System.EventHandler(this.textBox1_TextChanged);


            date1[nr1] = new TextBox();
            date1[nr1].Location = new System.Drawing.Point(date1[nr1 - 1].Location.X, date1[nr1 - 1].Location.Y + 23);
            date1[nr1].BackColor = System.Drawing.SystemColors.Control;
            date1[nr1].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            date1[nr1].Size = new System.Drawing.Size(115, 23);
            Controls.Add(date1[nr1]);
            date1[nr1].TextChanged += new System.EventHandler(this.textBox1_TextChanged);

            nr1++;
        }
    }
}
