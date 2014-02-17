using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Proiect.Aplicatii;

namespace Proiect.Aplicatii.Informatica.Evaluator
{
    public partial class Evaluator : Form
    {
        private Problema ProblemaCurenta;                       // indexul problemei curente
        public static string DirectorProbleme = "Probleme";           // direcotorul cu probleme
        public static string TemplateProblema = "template_problema";  // directorul template pt probleme noi
        private bool SurseSelectateToate = false;
        private bool ExeSelectateToate = false;
        private Dictionary<string, Dictionary<int, Dictionary<string, long>>> RezultateEvaluare = new Dictionary<string, Dictionary<int, Dictionary<string, long>>>();


        public Evaluator(string tipUtilizator)
        {
            InitializeComponent();
            incarcaListaProbleme();
            Form1 f = new Form1();
            if (tipUtilizator == "Profesor")
            {
                punctajeToolStripMenuItem.Visible = true;
            }
            else
            {
                punctajeToolStripMenuItem.Visible = false;
            }
        }

        private void incarcaListaProbleme()
        {
            // scanez directorul cu probleme si le afisez
            if (!Directory.Exists(DirectorProbleme))
            {
                MesajeAvertizare.mesajDirectorInexistent(DirectorProbleme);
            }
            else
            {
                // golesc lista
                listaProbleme.Items.Clear();
                string[] subDirectoare = Directory.GetDirectories(DirectorProbleme);
                foreach (string problema in subDirectoare)
                {
                    string nume = problema.Substring(problema.LastIndexOf('\\') + 1);
                    if (nume != TemplateProblema)
                        listaProbleme.Items.Add(nume);
                }
                // selectez prima problema
                if (listaProbleme.Items.Count > 0)
                    listaProbleme.SetSelected(0, true);
                else
                    MesajeAvertizare.mesajAtentie("Nu există nici o problemă.");
            }
        }

        private void listaProbleme_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             * cand se selecteaza o problema schimb informatiile despre ea
             */
            ProblemaCurenta = new Problema(listaProbleme.SelectedIndex, listaProbleme.SelectedItem.ToString(), DirectorProbleme);
            populeazaInformatiiProblema();



            // preiau testele, sursele, punctele si executabilele
            preiaTeste();
            preiaSurse();
            preiaPuncte();
            preiaExe();

        }

        private void populeazaInformatiiProblema()
        {
            if (ProblemaCurenta.OK)
            {
                // ProblemaCurenta
                limitaTimp.Text = convertToBigger(ProblemaCurenta.LimitaTimp, "ms").ToString() + "s";
                memorieTotala.Text = convertToBigger(ProblemaCurenta.MemorieTotala, "KB").ToString() + "MB";
                memorieStiva.Text = convertToBigger(ProblemaCurenta.MemorieStiva, "KB").ToString() + "MB";
                nrTeste.Text = ProblemaCurenta.NrTeste.ToString();
                dimensiuneSursa.Text = ProblemaCurenta.DimensiuneSursa.ToString() + "KB"; ;
                alteInformatii.Text = ProblemaCurenta.AlteInformatii;

                testeIntrare.Text = ProblemaCurenta.NumeProblema + ".in";
                testeIesire.Text = ProblemaCurenta.NumeProblema + ".out";
            }
        }

        private double convertToBigger(int value, string type)
        {
            float val = value;
            switch (type)
            {
                case "ms":
                    return TimeSpan.FromMilliseconds(value).TotalSeconds;

                case "KB":
                    return ConvertKilobytesToMegabytes(value);
            }
            return 0;
        }

        private double ConvertKilobytesToMegabytes(int kilobytes)
        {
            return kilobytes / 1024f;
        }

        private void preiaTeste()
        {
            // mai intai golesc listele
            listaTesteIntrare.Items.Clear();
            listaTesteIesire.Items.Clear();

            try
            {
                foreach (string test in ProblemaCurenta.TesteIntrare)
                {
                    listaTesteIntrare.Items.Add(test);
                }

                foreach (string test in ProblemaCurenta.TesteIesire)
                {
                    listaTesteIesire.Items.Add(test);
                }

            }
            catch
            {
                MesajeAvertizare.mesajEroareString("Lista cu teste nu a putut fi preluată.");
            }
        }

        private void preiaSurse()
        {
            listaCheckSurse.Items.Clear();

            List<string> surse = ProblemaCurenta.citesteSurse();
            foreach (string sursa in surse)
            {
                listaCheckSurse.Items.Add(sursa);
            }
        }

        private void preiaPuncte()
        {
            try
            {
                PuncteTextBox.Text = "";
                PuncteTextBox.LoadFile(ProblemaCurenta.Path + "\\puncte", RichTextBoxStreamType.PlainText);
            }
            catch
            {
                MesajeAvertizare.mesajEroareString("Lista cu puncte nu a putut fi preluată.");
            }
        }

        private void preiaExe()
        {
            listaCheckExe.Items.Clear();

            List<string> exes = ProblemaCurenta.citesteExecutabile();
            foreach (string exe in exes)
            {
                listaCheckExe.Items.Add(exe);
            }
        }

        private void editeazaTestIntrare_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaTesteIntrare.SelectedItem.ToString() != "Fara teste")
                {
                    EditareTest editor = new EditareTest(ProblemaCurenta.directorTeste(), listaTesteIntrare.SelectedItem.ToString());
                    editor.Show();
                }
                else MesajeAvertizare.mesajAtentie("Problema " + ProblemaCurenta.NumeProblema + " nu are teste de intrare.");
            }
            catch { }
        }

        private void editeazaTestIesire_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaTesteIesire.SelectedItem.ToString() != "Fara teste")
                {
                    EditareTest editor = new EditareTest(ProblemaCurenta.directorTeste(), listaTesteIesire.SelectedItem.ToString());
                    editor.Show();
                }
                else MesajeAvertizare.mesajAtentie("Problema " + ProblemaCurenta.NumeProblema + " nu are teste de iesire.");
            }
            catch { }
        }

        private void compileazaSursele_Click(object sender, EventArgs e)
        {
            compileazaSursele.Text = "se compilează...";

            for (int i = 0; i < listaCheckSurse.Items.Count; i++)
            {
                if (listaCheckSurse.GetItemChecked(i))
                {
                    string numeSursa = listaCheckSurse.Items[i].ToString();
                    string asd = DirectorProbleme + "\\" + listaProbleme.SelectedItem.ToString() + "\\executabile\\";

                    if (File.Exists(asd + numeSursa.Substring(0, numeSursa.LastIndexOf('.')) + ".exe"))
                    {
                        File.Delete(asd + numeSursa.Substring(0, numeSursa.LastIndexOf('.')) + ".exe");
                    }

                    ProblemaCurenta.compileazaSursa(listaCheckSurse.Items[i].ToString());
                }
            }

            compileazaSursele.Text = "compilează";
            preiaExe();
        }

        private void evalueazaExe_Click(object sender, EventArgs e)
        {
            evalueazaExe.Text = "se evaluează...";
            RezultateEvaluare.Clear();

            preiaPuncte();

            for (int i = 0; i < listaCheckExe.Items.Count; i++)
            {
                if (listaCheckExe.GetItemChecked(i))
                {
                    RezultateEvaluare.Add(listaCheckExe.Items[i].ToString(), ProblemaCurenta.evalueazaExe(listaCheckExe.Items[i].ToString(), PuncteTextBox.Text));
                }
            }
            evalueazaExe.Text = "evaluează";
            MesajeAvertizare.mesajSuccess("Evaluarea a luat sfârșit. \nPentru a vedea rezultatele accesați meniul 'Rezultate'.");

        }

        private void compileazaSurseleSelectateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            compileazaSursele.PerformClick();
        }

        private void stergeSurseleSelectateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listaCheckSurse.Items.Count; i++)
            {
                if (listaCheckSurse.GetItemChecked(i))
                    ProblemaCurenta.stergeSursa(listaCheckSurse.Items[i].ToString());
            }
            // am sters de pe hdd, reincarc lista
            preiaSurse();
        }

        private void stergeExecutabileleSelectateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listaCheckExe.Items.Count; i++)
            {
                if (listaCheckExe.GetItemChecked(i))
                    ProblemaCurenta.stergeExecutabil(listaCheckExe.Items[i].ToString());
            }
            // am sters de pe hdd, reincarc lista
            preiaExe();
        }

        private void adaugaSurseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogIncarcaSurse.ShowDialog();

            foreach (string sursa in dialogIncarcaSurse.FileNames)
            {
                ProblemaCurenta.adaugaSursa(sursa);
            }

            // reincarc lista cu surse
            preiaSurse();
        }

        private void selecteazadeselecteazaToateSurseleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listaCheckSurse.Items.Count; i++)
            {
                listaCheckSurse.SetItemChecked(i, !SurseSelectateToate);
            }
            SurseSelectateToate = !SurseSelectateToate;
        }

        private void deSelecteazaToateExecutabileleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listaCheckExe.Items.Count; i++)
            {
                listaCheckExe.SetItemChecked(i, !ExeSelectateToate);
            }
            ExeSelectateToate = !ExeSelectateToate;
        }

        private void stergeProblemaSelectataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProblemaCurenta.stergeProblema();
            // reincarc lista cu probleme
            incarcaListaProbleme();
        }

        private void problemaNouaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdaugaProblema pbnoua = new AdaugaProblema();
            pbnoua.Show();
            pbnoua.FormClosed += new FormClosedEventHandler(reincarcaListaProbleme);
        }

        private void reincarcaListaProbleme(object sender, EventArgs e)
        {
            incarcaListaProbleme();
        }

        private void modificaProblemaSelectataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdaugaProblema pbnoua = new AdaugaProblema(ProblemaCurenta);
            pbnoua.Show();
            pbnoua.FormClosed += new FormClosedEventHandler(reincarcaListaProbleme);
        }

        private void setariToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Setari setari = new Setari();
            setari.Show();
        }

        private void rezultateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rezultate rez = new Rezultate(RezultateEvaluare);
            rez.Show();
        }

        private void compileazaExecutabileleSelectateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            evalueazaExe.PerformClick();
        }

        private void compileazaExecutabileleSelectateToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            evalueazaExe.PerformClick();
        }

        private void problemaNoua_Click(object sender, EventArgs e)
        {
            AdaugaProblema pbnoua = new AdaugaProblema();
            pbnoua.Show();
            pbnoua.FormClosed += new FormClosedEventHandler(reincarcaListaProbleme);
        }

        private void punctajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Punctaje p = new Punctaje(listaProbleme.SelectedIndex, listaProbleme.SelectedItem.ToString(), DirectorProbleme);
            p.Show();
        }

    }
}
