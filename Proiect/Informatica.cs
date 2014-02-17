using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SoftEducationalCIA;
using System.Reflection;

namespace SoftEducationalCIA.Informatica
{
    public partial class Informatica : Form
    {
        private TreeFileGrab grabInfo;

        public Informatica()
        {
            InitializeComponent();
            grabInfo = new TreeFileGrab("informatica", treeFile);
        }

        private void Informatica_Load(object sender, EventArgs e)
        {
            Uri url = new Uri(Directory.GetCurrentDirectory() + "\\Teorie\\informatica\\C C++\\Lectii\\Introducere in C++.htm");
            webBrowser1.Url = url;
        }

        private void treeFile_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // preiau lista de fisiere cu extensie cu tot: nume_fisier -> nume_fisier.ext
            Dictionary<string, string> ListaFisiere = grabInfo.getListaFisiereExt();
            
            // elementul selectat
            TreeNode SelectedNode = treeFile.SelectedNode;

            // daca exista in lista nodul ala
            if (ListaFisiere.ContainsKey(SelectedNode.Text))
            {
                try
                {
                    // toata calea fisierului pe disk
                    string fullFilePath = Directory.GetCurrentDirectory() + "\\" + ListaFisiere[SelectedNode.Text];
                    // il incarcin browser
                    Uri url = new Uri(fullFilePath);
                    //webBrowser1.Url = url;
                    webBrowser1.Navigate(fullFilePath);

                }
                catch {
                    MessageBox.Show("A aparut o problema.", "Eroare");
                }
            }
        }

        private void evaluatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Aplicatii.Informatica.Evaluator.Evaluator evaluator = new Aplicatii.Informatica.Evaluator.Evaluator();
            evaluator.Show();
        }

    }
}
