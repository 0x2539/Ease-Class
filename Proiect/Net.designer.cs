namespace Proiect
{
    partial class Net
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Net));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cautaPeGoogleButton = new System.Windows.Forms.ToolStripTextBox();
            this.cautaPeWikiButton = new System.Windows.Forms.ToolStripTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(994, 572);
            this.webBrowser1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cautaPeGoogleButton,
            this.cautaPeWikiButton});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(994, 25);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cautaPeGoogleButton
            // 
            this.cautaPeGoogleButton.BackColor = System.Drawing.Color.Beige;
            this.cautaPeGoogleButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cautaPeGoogleButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cautaPeGoogleButton.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.cautaPeGoogleButton.Name = "cautaPeGoogleButton";
            this.cautaPeGoogleButton.ShortcutsEnabled = false;
            this.cautaPeGoogleButton.Size = new System.Drawing.Size(200, 21);
            this.cautaPeGoogleButton.Text = "Caută pe Google...";
            this.cautaPeGoogleButton.ToolTipText = "Cauta informatii pe Wikipedia";
            this.cautaPeGoogleButton.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBox1_KeyPress);
            this.cautaPeGoogleButton.Click += new System.EventHandler(this.toolStripTextBox1_Click_1);
            // 
            // cautaPeWikiButton
            // 
            this.cautaPeWikiButton.BackColor = System.Drawing.Color.Beige;
            this.cautaPeWikiButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cautaPeWikiButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cautaPeWikiButton.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.cautaPeWikiButton.Name = "cautaPeWikiButton";
            this.cautaPeWikiButton.ShortcutsEnabled = false;
            this.cautaPeWikiButton.Size = new System.Drawing.Size(200, 21);
            this.cautaPeWikiButton.Text = "Caută pe Wikipedia...";
            this.cautaPeWikiButton.ToolTipText = "Cauta informatii pe Wikipedia";
            this.cautaPeWikiButton.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cautaPeWikiButton_KeyPress);
            this.cautaPeWikiButton.Click += new System.EventHandler(this.cautaPeWikiButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(411, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "(apăsați ENTER pentru a căuta pe internet)";
            // 
            // Net
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(994, 572);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.webBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Net";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Căutare Web";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripTextBox cautaPeWikiButton;
        private System.Windows.Forms.ToolStripTextBox cautaPeGoogleButton;
        private System.Windows.Forms.Label label1;



    }
}