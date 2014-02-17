using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Proiect
{
    public partial class Net : Form
    {
        private string wikipedia = "http://ro.wikipedia.org/w/index.php?search=";
        private string google = "http://www.google.com/search?hl=en&q=";
        public Net()
        {
            InitializeComponent();
        }


        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            cautaPeWikiButton.Text = "";
        }

        private void cautaPeWikiButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {  // apasat enter 
                goToUrl(this.wikipedia + cautaPeWikiButton.Text.ToString());
            }
        }

        private void goToUrl(string Url)
        {
            Uri url = new Uri(Url);
            webBrowser1.Url = url;
        }

        private void cautaPeWikiButton_Leave(object sender, EventArgs e)
        {
            cautaPeWikiButton.Text = "Cauta pe Wikipedia...";
        }


        private void cautaPeWikiButton_Click(object sender, EventArgs e)
        {
            cautaPeWikiButton.Text = "";
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {  // apasat enter 
                goToUrl(this.google + cautaPeGoogleButton.Text.ToString());
            }
        }

        private void toolStripTextBox1_Click_1(object sender, EventArgs e)
        {
            cautaPeGoogleButton.Text = "";
        }


    }
}
