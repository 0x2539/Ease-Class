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
    public partial class NoteElevi : Form
    {
        public Label[] elevi = new Label[400];
        public TextBox[] tb = new TextBox[400];

        BazaDate bd = new BazaDate();
        public NoteElevi()
        {
            InitializeComponent();
            int i;
            elevi[0] = new Label();

            for (i = 0; i < bd.selectid(); i++)
            {
                elevi[i] = new Label();
                this.elevi[i].AutoSize = true;
                this.elevi[i].Name = "la" + i;
                this.elevi[i].TabIndex = i + 3;
                
                if (bd.selectElevi(i) != "0" && bd.selectProfElev(i) == 2)
                {
                    
                    elevi[i].Text = bd.selectElevi(i);

                    if (i == 0)
                    {
                        elevi[i].Location = new Point(0, 0);
                        tb[i] = new TextBox();
                        this.tb[i].Location = new System.Drawing.Point(0, 16);
                        this.tb[i].Name = "textBox1";
                        this.tb[i].Size = new System.Drawing.Size(366, 20);
                        this.tb[i].TabIndex = 1;
                        tb[i].Text = bd.selectNote(i);
                        this.tb[i].Visible = true;
                        Controls.Add(tb[i]);
                    }
                    else
                    {
                        elevi[i].Location = new Point(0, elevi[i - 1].Location.Y + 50);
                        tb[i] = new TextBox();
                        this.tb[i].Location = new System.Drawing.Point(0, elevi[i - 1].Location.Y + 66);
                        this.tb[i].Name = "textBox1";
                        this.tb[i].Size = new System.Drawing.Size(366, 20);
                        this.tb[i].TabIndex = 1;
                        this.tb[i].Visible = true;
                        tb[i].Text = bd.selectNote(i);
                        Controls.Add(tb[i]);
                    }
                    Controls.Add(elevi[i]);
                }
            }
        }
    }
}
