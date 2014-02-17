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
    public partial class ReadMe : Form
    {
        public ReadMe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FAQForm1 fq = new FAQForm1();
            fq.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FAQRegister rg = new FAQRegister();
            rg.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FAQRaspTest rq = new FAQRaspTest();
            rq.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FAQCreareTest aqq = new FAQCreareTest();
            aqq.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FAQCreareLectie fd = new FAQCreareLectie();
            fd.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FAQEvaluator iff = new FAQEvaluator();
            iff.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FAQTest fq = new FAQTest();
            fq.Show();
        }
    }
}


