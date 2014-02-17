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
    public partial class Mesaj : Form
    {
        public Mesaj()
        {
            InitializeComponent();
        }
        public int numar;
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();
            saveFile1.DefaultExt = "*.txt";
            saveFile1.Filter = "Text Files|*.txt|RTF Files|*.rtf";

            LectiiMate n2 = new LectiiMate();
            string message = textBox1.Text;
            //numar = n2.nr;
            //numar++;
            n2.nr++;
            n2.ll[n2.nr] = new LinkLabel();
            n2.ll[n2.nr].Text = message;
            richTextBox1.Text = message;
           
            //textBox1
            
            
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                richTextBox1.SaveFile(saveFile1.FileName, RichTextBoxStreamType.RichText);
            }
            //n2.ll[n2.nr].Text = n2.nr.ToString();
            n2.Show();
            //Close();
        }

    }
}
