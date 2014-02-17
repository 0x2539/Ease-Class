namespace Proiect
{
    partial class NewVizualizeazaTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.VeziRaspunsuri = new System.Windows.Forms.Button();
            this.SetariTextVizualizeazaTest = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Proiect.Properties.Resources.file_edit;
            this.pictureBox2.Location = new System.Drawing.Point(9, 261);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 32;
            this.pictureBox2.TabStop = false;
            // 
            // VeziRaspunsuri
            // 
            this.VeziRaspunsuri.AutoSize = true;
            this.VeziRaspunsuri.Location = new System.Drawing.Point(40, 270);
            this.VeziRaspunsuri.Name = "VeziRaspunsuri";
            this.VeziRaspunsuri.Size = new System.Drawing.Size(88, 23);
            this.VeziRaspunsuri.TabIndex = 31;
            this.VeziRaspunsuri.Text = "Vezi raspunsuri";
            this.VeziRaspunsuri.UseVisualStyleBackColor = true;
            this.VeziRaspunsuri.Click += new System.EventHandler(this.VeziRaspunsuri_Click);
            // 
            // SetariTextVizualizeazaTest
            // 
            this.SetariTextVizualizeazaTest.Location = new System.Drawing.Point(13, -110);
            this.SetariTextVizualizeazaTest.Name = "SetariTextVizualizeazaTest";
            this.SetariTextVizualizeazaTest.Size = new System.Drawing.Size(100, 96);
            this.SetariTextVizualizeazaTest.TabIndex = 33;
            this.SetariTextVizualizeazaTest.Text = "";
            // 
            // NewVizualizeazaTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(705, 305);
            this.Controls.Add(this.SetariTextVizualizeazaTest);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.VeziRaspunsuri);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NewVizualizeazaTest";
            this.Text = "Vizualizeaza Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewVizualizeazaTest_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button VeziRaspunsuri;
        private System.Windows.Forms.RichTextBox SetariTextVizualizeazaTest;




    }
}