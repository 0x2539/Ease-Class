using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proiect.Aplicatii.Informatica.Evaluator
{
    public partial class Punctaje : Form
    {
        private Dictionary<string, Dictionary<int, Dictionary<string, long>>> RezultateEvaluare = new Dictionary<string, Dictionary<int, Dictionary<string, long>>>();
        private Problema ProblemaCurenta;
        int[] puncte = new int[40];
        String Path, numere = "0123456789", numeTest = "";
        int x1 = -1, x2 = -1;

        public Punctaje(int index, string nume, string path)
        {
            InitializeComponent();

            Path = path + "\\" + nume + "\\";

            ProblemaCurenta = new Problema(index, nume, path);
            
            listaPunctaje.Items.Clear();
            int i = 0;
            try
            {
                foreach (string test in ProblemaCurenta.TesteIntrare)
                {
                    puncte[i] = 10;
                    i++;
                    listaPunctaje.Items.Add(test);
                }

                richTextBox1.LoadFile(Path + "\\puncte", RichTextBoxStreamType.PlainText);

                string[] pct = richTextBox1.Text.Split('\n');
                for (int q = 0; q < pct.Length - 1; q++)
                {
                    puncte[q] = Convert.ToInt32(pct[q]);
                }

                //daca nu exista teste ascund textboxul si butonul
                if (listaPunctaje.Items.Count == 1)
                {
                    if (listaPunctaje.Items[0].ToString() == "Fara teste")
                    {
                        textBox1.Hide();
                        salveaza.Hide();
                    }
                }
                else
                //selectez primul test
                if (listaPunctaje.Items.Count != 0)
                {
                    textBox1.Text = puncte[0].ToString();
                    listaPunctaje.SetSelected(0, true);
                }
            }
            catch
            {
                MesajeAvertizare.mesajEroareString("Lista cu puncte nu a putut fi preluată.");
                Close();
            }
        }

        private void salveaza_Click(object sender, EventArgs e)
        {
            listaPunctaje_SelectedIndexChanged(sender, e);

            if (ok == true)
            {
                int r = 10;
                richTextBox1.Text = "";
                try
                {
                    r = Convert.ToInt32(textBox1.Text);
                    for (int i = 0; i < listaPunctaje.Items.Count; i++)
                    {
                        richTextBox1.Text += puncte[i].ToString() + '\n';
                    }
                    richTextBox1.SaveFile(Path + "\\puncte", RichTextBoxStreamType.PlainText);
                    Close();
                }
                catch
                {
                    MessageBox.Show("Introduceți un număr rezonabil de puncte pentru testul " + listaPunctaje.SelectedItem.ToString());

                    textBox1.Text = "10";
                }
            }
            else
            {
                MessageBox.Show("Introduceți un punctaj pentru test!");
            }
        }

        //ok va fi folosit sa vad daca numarul introdus e prea mare sau prea mic
        bool ok = true;
        private void listaPunctaje_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ok == true)
            {
                //salvez pozitia testului curent pentru a trece mai departe dupa ce termin introducerea punctajelor
                x2 = listaPunctaje.SelectedIndex;
                
                //daca nu a fost selectat niciun test
                if (x1 == -1)
                {
                    x1 = listaPunctaje.SelectedIndex;
                    numeTest = listaPunctaje.SelectedItem.ToString();
                }
                if (textBox1.Text != "")
                {
                    //numar va retine daca in textBox exista numai numere, false: nu contine, true: contine
                    bool numar = false, plusminus = false;
                    for (int i = 0; i < textBox1.Text.Length; i++)
                    {
                        if (numar == true)
                        {
                            puncte[x1] = 10;
                            if (plusminus == true)
                            {
                                MessageBox.Show("Introduceți numai numere!");
                            }
                            else
                            {
                                MessageBox.Show("Introduceți numai numere pozitive!");
                            }
                            textBox1.Text = "10";
                            break;
                        }
                        //il setez true ca apoi sa il schimb in false daca gaseste numar

                        numar = true;
                        plusminus = true;

                        for (int j = 0; j <= 9; j++)
                        {
                            if (textBox1.Text[i] == '-')
                            {
                                plusminus = false;
                            }
                            if (textBox1.Text[i] == numere[j])
                            {
                                numar = false;
                                break;
                            }
                        }

                    }

                    if (numar == false)
                    {
                        int r = 10;//default 10 puncte
                        try
                        {
                            r = Convert.ToInt32(textBox1.Text);
                            puncte[x1] = r;
                            numeTest = listaPunctaje.SelectedItem.ToString();
                            x1 = x2;
                        }
                        catch
                        {
                            ok = false;
                            listaPunctaje.SetSelected(x2, false);
                            listaPunctaje.SetSelected(x1, true);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Introduceți un punctaj pentru test!");
                }


                if (puncte[listaPunctaje.SelectedIndex] == 0)
                {
                    MessageBox.Show("Punctajul pentru testul " + numeTest + " a fost 0, așa că a fost schimbat în 10!");
                    puncte[listaPunctaje.SelectedIndex] = 10;
                    textBox1.Text = "10";
                }
                else
                {
                    textBox1.Text = puncte[listaPunctaje.SelectedIndex].ToString();
                }
            }
            else
            {
                MessageBox.Show("Introduceți un număr rezonabil de puncte pentru testul " + numeTest);

                textBox1.Text = "10";
                puncte[x1] = 10;
                ok = true;
            }

        }

    }
}
