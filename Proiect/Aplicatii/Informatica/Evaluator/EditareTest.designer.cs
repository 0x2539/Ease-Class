namespace Proiect.Aplicatii.Informatica.Evaluator
{
    partial class EditareTest
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
            this.continutTest = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // continutTest
            // 
            this.continutTest.BackColor = System.Drawing.Color.White;
            this.continutTest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.continutTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.continutTest.Location = new System.Drawing.Point(0, 0);
            this.continutTest.Name = "continutTest";
            this.continutTest.Size = new System.Drawing.Size(284, 262);
            this.continutTest.TabIndex = 0;
            this.continutTest.Text = "";
            // 
            // EditareTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.continutTest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "EditareTest";
            this.Text = "Editare Test";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditareTest_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox continutTest;
    }
}