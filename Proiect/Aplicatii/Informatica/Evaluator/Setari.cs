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
    public partial class Setari : Form
    {
        public Setari()
        {
            InitializeComponent();
            CaleCompilatorCPP.Text = SetariCompilator.Default.CaleCPP;
            CaleCompilatorC.Text = SetariCompilator.Default.CaleC;
            CaleCompilatorPAS.Text = SetariCompilator.Default.CalePas;
        }

        private void Setari_FormClosed(object sender, FormClosedEventArgs e)
        {
            SetariCompilator.Default.CaleCPP = CaleCompilatorCPP.Text;
            SetariCompilator.Default.CaleC = CaleCompilatorC.Text;
            SetariCompilator.Default.CalePas = CaleCompilatorPAS.Text;
            SetariCompilator.Default.Save();
        }

        private void AlegeCPP_Click(object sender, EventArgs e)
        {
            alegeCompilatorCPP.ShowDialog();
            CaleCompilatorCPP.Text = alegeCompilatorCPP.FileName;
        }

        private void AlegeC_Click(object sender, EventArgs e)
        {
            alegeCompilatorC.ShowDialog();
            CaleCompilatorC.Text = alegeCompilatorC.FileName;
        }

        private void AlegePas_Click(object sender, EventArgs e)
        {
            alegeCompilatorPas.ShowDialog();
            CaleCompilatorPAS.Text = alegeCompilatorPas.FileName;
        }


    }

}
