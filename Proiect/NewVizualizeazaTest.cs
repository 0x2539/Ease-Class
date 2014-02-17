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
    public partial class NewVizualizeazaTest : Form
    {
        public RichTextBox[] enunt = new RichTextBox[40];
        public Label[] NrProblema = new Label[40];
        public string locatie;

        string numeleMateriei = "";

        public NewVizualizeazaTest(string location, string Materie, string utilizator)
        {
            Deschidere.Default.aDeschisUnTest = true;
            Deschidere.Default.Save();
            InitializeComponent();
            locatie = location;
            numeleMateriei = Materie;

            this.Text = "Testul " + locatie + " (" + numeleMateriei + ")";

            numarRT = Directory.GetFiles(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatie + "\\").Length / 2 - 1;
            int s;
            
            SetariTextVizualizeazaTest.LoadFile(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatie + "\\setari", RichTextBoxStreamType.RichText);

            string[] elementeSetari = SetariTextVizualizeazaTest.Text.Split('\n');
            int[] inaltimiCasutaVizualizeazaTest = new int[40];
            //MessageBox.Show(SetariTextVizualizeazaTest.Text);
            for (int u = 1; u <= numarRT; u++)
            {
                inaltimiCasutaVizualizeazaTest[u - 1] = Convert.ToInt32(elementeSetari[u]);
            }

            
            for (k = 0; k < numarRT; k++)
            {
                Point pos = new Point(0, 0);
                enunt[k] = new RichTextBox();


                if (k == 0)
                {
                    enunt[k].BackColor = System.Drawing.Color.White;
                    enunt[k].Name = "rt" + k;
                    enunt[k].ReadOnly = true;
                    enunt[k].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
                    enunt[k].Size = new System.Drawing.Size(704, 10);
                    enunt[k].TabIndex = k + 7;
                    this.enunt[k].BorderStyle = System.Windows.Forms.BorderStyle.None;

                    s = k + 1;

                    enunt[k].Text = System.IO.File.ReadAllText(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatie + "\\problema" + s);
                    enunt[k].WordWrap = true;
                    enunt[k].Location = new Point(0, 30);
                    enunt[k].Height = inaltimiCasutaVizualizeazaTest[k];

                    this.Controls.Add(enunt[k]);
                }
                else
                    if (k > 0)
                    {
                        enunt[k].BackColor = System.Drawing.Color.White;
                        enunt[k].Name = "rt" + k;
                        enunt[k].ReadOnly = true;
                        enunt[k].ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
                        enunt[k].Size = new System.Drawing.Size(704, 10);
                        enunt[k].TabIndex = k + 7;
                        this.enunt[k].BorderStyle = System.Windows.Forms.BorderStyle.None;

                        s = k + 1;

                        enunt[k].Text = System.IO.File.ReadAllText(Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + locatie + "\\problema" + s);
                        enunt[k].WordWrap = true;
                        enunt[k].Location = new Point(0, enunt[k - 1].Location.Y + enunt[k - 1].Height + 40);

                        enunt[k].Height = inaltimiCasutaVizualizeazaTest[k];
                        this.Controls.Add(enunt[k]);
                    }

                //inaltimea richtextboxului
                pos.X = ClientRectangle.Width;
                pos.Y = ClientRectangle.Height;
                int lastIndex = enunt[k].GetCharIndexFromPosition(pos);
                int lastLine = enunt[k].GetLineFromCharIndex(lastIndex) + 1;
                MessageBox.Show(enunt[k].Location.Y.ToString());

                NrProblema[k] = new Label();
                int numar;
                numar = k + 1;
                NrProblema[k].Text = "Problema " + numar;
                NrProblema[k].AutoSize = true;
                NrProblema[k].Name = "Nrproblema" + k;
                NrProblema[k].BackColor = System.Drawing.Color.Transparent;
                this.NrProblema[k].Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //pozitia label-ului "Raspuns"
                if (k == 0)
                {
                    NrProblema[k].Location = new Point(245, enunt[k].Location.Y - 30);
                }
                else
                    if (k > 0)
                    {
                        NrProblema[k].Location = new Point(245, enunt[k].Location.Y - 30);
                    }
                this.Controls.Add(NrProblema[k]);
            }
            if (utilizator == "Elev")
            {
                VeziRaspunsuri.Location = new Point(VeziRaspunsuri.Location.X, enunt[numarRT - 1].Height + enunt[numarRT - 1].Location.Y + 20);
                pictureBox2.Location = new Point(pictureBox2.Location.X, enunt[numarRT - 1].Height + enunt[numarRT - 1].Location.Y + 11);
            }
            else
            {
                VeziRaspunsuri.Hide();
                pictureBox2.Hide();
            }
        }

        public int k = -1;
        public int numarRT;

        private void VeziRaspunsuri_Click(object sender, EventArgs e)
        {
            NewRaspunsTest n = new NewRaspunsTest(locatie, numeleMateriei);
            n.Show();
        }

        private void NewVizualizeazaTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            Deschidere.Default.aDeschisUnTest = false;
            Deschidere.Default.Save();
        }
        
    }
}
