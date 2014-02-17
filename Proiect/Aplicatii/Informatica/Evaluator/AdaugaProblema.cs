using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Proiect.Aplicatii.Informatica.Evaluator
{
    public partial class AdaugaProblema : Form
    {
        private bool SeModifica = false;
        private string numePrb = "";

        public AdaugaProblema()
        {
            InitializeComponent();
        }

        public AdaugaProblema(Problema editareProblema)
        {
            InitializeComponent();
            
            // setez valorile implicite primite ca parametru
            NumeProblema.Text = editareProblema.NumeProblema;
            LimitaTimp.Text = editareProblema.LimitaTimp.ToString();
            MemorieTotala.Text = editareProblema.MemorieTotala.ToString();
            MemorieStiva.Text = editareProblema.MemorieStiva.ToString();
            NrTeste.Text = editareProblema.NrTeste.ToString();
            DimensiuneSursa.Text = editareProblema.DimensiuneSursa.ToString();
            AlteInformatii.Text = editareProblema.AlteInformatii;

            numePrb = NumeProblema.Text;
            SeModifica = true;
            // nu modifica numele problemei
            NumeProblema.Enabled = false;
        }

        private void butonIesire_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void salveazaProblema_Click(object sender, EventArgs e)
        {
            salveazaDetalii();
            if (caleaTesteIntrare != "")
            {
                //MessageBox.Show(Evaluator.DirectorProbleme + "\\" + numePrb + "\\teste");
                //MessageBox.Show(numePrb);
                Directory.Delete(Evaluator.DirectorProbleme + "\\" + numePrb + "\\teste", true);
                copyDirectory(caleaTesteIntrare, Evaluator.DirectorProbleme + "\\" + numePrb+"\\teste");// + "\\teste\\");
            }
            if (caleaSurse != "")
            {
                Directory.Delete(Evaluator.DirectorProbleme + "\\" + numePrb + "\\surse", true);
                copyDirectory(caleaSurse, Evaluator.DirectorProbleme + "\\" + numePrb+"\\surse");// + "\\surse\\");
            }

            //string[] caileTesteIntrare = Directory.GetFiles(caleaTesteIntrare);
            //string[] caileSurse = Directory.GetFiles(caleaSurse);
            /*for (int i = 0; i < caleaTesteIntrare.Length; i++)
            {
                File.Copy(
            }*/
            //File.Copy(folderimgAdaugaTest[i], Application.StartupPath + "\\LectiiSiTeste\\Teste\\" + numeleMateriei + "\\" + textBox1AdaugaTest.Text + "\\Imagini\\" + "imagine" + i + ".jpg", true);
        }

        public void copyDirectory(string Src, string Dst)
        {
            /**
             * Copiaza recurisv un folder cu tot cu continut
             */
            String[] Files;

            if(Dst[Dst.Length-1]!=Path.DirectorySeparatorChar) 
                Dst+=Path.DirectorySeparatorChar;
            if (!Directory.Exists(Dst))
                Directory.CreateDirectory(Dst);
            //MessageBox.Show(Src);
            Files=Directory.GetFileSystemEntries(Src);
            foreach(string Element in Files)
            {
                // subdirectoare
                if(Directory.Exists(Element)) 
                    copyDirectory(Element,Dst+Path.GetFileName(Element));
                // fisierele din folder
                else 
                    File.Copy(Element,Dst+Path.GetFileName(Element),true);                
            }
        }

        private void salveazaDetalii() 
        {
            try
            {
                if (LimitaTimp.Text != "" && MemorieTotala.Text != "" && MemorieStiva.Text != "" &&
                            NrTeste.Text != "" && DimensiuneSursa.Text != "" && AlteInformatii.Text != "")
                {
                    // daca se modifica nu mai creez alta structura
                    if (!SeModifica)
                    {
                        // copiez directorul template al problemei
                        copyDirectory(Evaluator.DirectorProbleme + "\\" + Evaluator.TemplateProblema,
                                     Evaluator.DirectorProbleme + "\\" + NumeProblema.Text);
                    }

                    XmlDocument writerConfig = new XmlDocument();
                    string fisierConfig = Evaluator.DirectorProbleme + "\\" + NumeProblema.Text + "\\" + Problema.NumeConfig;
                    writerConfig.Load(fisierConfig);

                    XmlNode node = writerConfig.SelectSingleNode("//problema");

                    node["limitaTimp"].InnerText = LimitaTimp.Text;
                    node["memorieTotala"].InnerText = MemorieTotala.Text;
                    node["memorieStiva"].InnerText = MemorieStiva.Text;
                    node["nrTeste"].InnerText = NrTeste.Text;
                    node["dimensiuneSursa"].InnerText = DimensiuneSursa.Text;
                    node["alteInformatii"].InnerText = AlteInformatii.Text;

                    writerConfig.Save(fisierConfig);

                    MesajeAvertizare.mesajSuccess("Problema a fost salvata.");
                    this.Close();

                }
                else
                    MesajeAvertizare.mesajAtentie("Toate campurile sunt obligatorii!");
            }
            catch
            { 
                MesajeAvertizare.mesajEroareString("Problema nu a putut fi salvata.");             
            }
           
        }

        string caleaTesteIntrare = "", caleaSurse = "";

        private void TesteIntrareButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog of = new FolderBrowserDialog();
            
            if (of.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (of.SelectedPath.Substring(of.SelectedPath.Length - 5, 5) == "teste")
                {
                    caleaTesteIntrare = of.SelectedPath;
                }
                else
                {
                    MessageBox.Show("Numele folderului trebuie sa fie 'teste'!");
                }
            }
        }

        private void SurseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog of = new FolderBrowserDialog();

            if (of.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (of.SelectedPath.Substring(of.SelectedPath.Length - 5, 5) == "surse")
                {
                    caleaSurse = of.SelectedPath;
                }
                else
                {
                    MessageBox.Show("Numele folderului trebuie sa fie 'surse'!");
                }
            }
        }

        private void NumeProblema_TextChanged(object sender, EventArgs e)
        {
            numePrb = NumeProblema.Text;
        }

    }
}
