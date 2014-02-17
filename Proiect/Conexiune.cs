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
    public partial class Conexiune : Form
    {
        public Conexiune()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string f = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + textBox1.Text + @"\Database1.mdf;Integrated Security=True;User Instance=True";
            
            Deschidere.Default.SqlCon = f;
            Deschidere.Default.SqlCon = @"Data Source=.\SQLEXPRESS;AttachDbFilename="+System.IO.Path.GetFullPath("baza")+@"\Database1.mdf;Integrated Security=True;User Instance=True";
            
            Deschidere.Default.Save();
            Close();
        }
    }
}
