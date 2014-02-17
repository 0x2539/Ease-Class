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
    public partial class LectiiMate : Form
    {
        public LectiiMate()
        {
            InitializeComponent();
            //Load textBox1 = Test.txt;
            //ll[0] = new LinkLabel();
            /*this.ll[0].AutoSize = true;
            this.ll[0].Location = new System.Drawing.Point(0, 76);
            this.ll[0].Name = "ll" + 0;
            this.ll[0].Size = new System.Drawing.Size(55, 13);
            this.ll[0].TabIndex = 0;
            this.ll[0].TabStop = true;
            this.ll[0].Text = "ll" + 0;
            this.ll[0].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_LinkClicked);
            this.Controls.Add(ll[0]);
        */}
        public LinkLabel[] ll = new LinkLabel[1000];
        public int nr = 0;
        /*public void label(int n, string mesaj)
        {
        }*/

        private void ll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string X1 = linkLabel1.Text;
            //VideoMate mate2 = new VideoMate(linkLabel1.Text);
            //mate2.Show();
            //Properties.Settings.Default.Save();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string X1 = linkLabel1.Text;
            //VideoMate mate2 = new VideoMate(linkLabel1.Text);
            //mate2.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //VideoMate mate2 = new VideoMate(linkLabel2.Text);
            //mate2.Show();
 
        }

    }
}
