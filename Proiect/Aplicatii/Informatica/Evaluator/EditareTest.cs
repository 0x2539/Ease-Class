using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Proiect.Aplicatii.Informatica.Evaluator
{
    public partial class EditareTest : Form
    {
        private string Path;
        private string FileName;
        private FileInfo myFile;

        public EditareTest(string path, string continut)
        {
            InitializeComponent();
            Path = path;
            FileName = continut;
            Text = "Editare test " + FileName;

            if (File.Exists(path + "\\" + continut))
            {
                FileInfo fisier = new FileInfo(path + "\\" + continut);
                myFile = fisier;
                // deschid fisierul si il inchid
                StreamReader continut2 = fisier.OpenText();
                continutTest.Text = continut2.ReadToEnd();
                continut2.Close();
            }
            
        }

        private void EditareTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            // rescriu fisierul cu modificarile facute
            StreamWriter scriere = myFile.CreateText();
            scriere.Write(continutTest.Text);
            scriere.Close();
        }
    }
}
