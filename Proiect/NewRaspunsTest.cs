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
    public partial class NewRaspunsTest : Form
    {
        public RichTextBox[] raspuns = new RichTextBox[40];
        public Label[] lb = new Label[40];
        public Label[] NrProblema = new Label[40];
        public Button buton10 = new Button();
        public Button buton20 = new Button();
        public string locatie;
        public int k = -1;
        public int numarRT;

        string numeleMateriei = "";

        public NewRaspunsTest(string location, string Materie)
        {
            InitializeComponent();
            numeleMateriei = Materie;
            //numarRT = 0;
            locatie = location;
            numarRT = (Directory.GetFiles(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + location + "\\").Length - 2) / 2;
            button1.Location = new Point(0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RaspunsTest_Load(object sender, EventArgs e)
        {
            for (k = 0; k < numarRT; k++)
            {
                Point pos = new Point(0, 0);
                raspuns[k] = new RichTextBox();
                buton10 = new Button();

                if (k == 0)
                {
                    raspuns[k].BackColor = System.Drawing.Color.White;
                    raspuns[k].Name = "tb" + k;
                    raspuns[k].ReadOnly = false;
                    raspuns[k].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
                    raspuns[k].Size = new System.Drawing.Size(400, 26);
                    raspuns[k].TabIndex = k + 7;
                    raspuns[k].Text = "";
                    raspuns[k].BorderStyle = BorderStyle.FixedSingle;
                    raspuns[k].WordWrap = true;
                    raspuns[k].ReadOnly = true;

                }
                else
                    if (k > 0)
                    {
                        raspuns[k].BackColor = System.Drawing.Color.White;
                        raspuns[k].Name = "tb" + k;
                        raspuns[k].ReadOnly = false;
                        raspuns[k].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
                        raspuns[k].Size = new System.Drawing.Size(400, 26);
                        raspuns[k].TabIndex = k + 7;
                        raspuns[k].Text = "";
                        raspuns[k].BorderStyle = BorderStyle.FixedSingle;
                        raspuns[k].WordWrap = true;
                        raspuns[k].ReadOnly = true;
                    }
                int suma = k + 1;
                lb[k] = new Label();
                lb[k].Text = "Răspuns " + suma;
                lb[k].Name = "label" + suma;
                lb[k].AutoSize = true;
                this.lb[k].Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                //pozitia label-ului "Raspuns"
                if (k == 0)
                {
                    lb[k].Location = new Point(0, 10);
                    raspuns[k].Location = new Point(120, 10);
                    buton10.Location = new Point(0, raspuns[k].Height + 50);
                }
                else
                    if (k > 0)
                    {
                        lb[k].Location = new Point(0, lb[k - 1].Location.Y + 40);// - 35);
                        raspuns[k].Location = new Point(120, lb[k - 1].Location.Y + 40);
                        buton10.Location = new Point(0, lb[k].Location.Y + 40);
                    }
                raspuns[k].Text = System.IO.File.ReadAllText(Application.StartupPath + 
                    "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatie + "\\raspuns" + suma);

                raspuns[k].BorderStyle = BorderStyle.FixedSingle;

                this.Controls.Add(lb[k]);
                this.Controls.Add(raspuns[k]);
                if (k == numarRT - 1)
                {
                    buton10.Text = "Close";
                    buton10.AutoSize = true;
                    this.buton10.Click += new System.EventHandler(this.button1_Click);
                    this.Controls.Add(buton10);
                }
            }
        }
    }
}