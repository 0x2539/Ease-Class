namespace Proiect.Aplicatii.Informatica.Evaluator
{
    partial class Punctaje
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listaPunctaje = new System.Windows.Forms.ListBox();
            this.salveaza = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.richTextBox1);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.listaPunctaje);
            this.groupBox3.Controls.Add(this.salveaza);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(256, 320);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Punctaje";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(24, -102);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(100, 96);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, 294);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "10";
            // 
            // listaPunctaje
            // 
            this.listaPunctaje.BackColor = System.Drawing.Color.White;
            this.listaPunctaje.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listaPunctaje.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaPunctaje.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.listaPunctaje.FormattingEnabled = true;
            this.listaPunctaje.ItemHeight = 18;
            this.listaPunctaje.Location = new System.Drawing.Point(6, 16);
            this.listaPunctaje.Name = "listaPunctaje";
            this.listaPunctaje.Size = new System.Drawing.Size(256, 270);
            this.listaPunctaje.TabIndex = 11;
            this.listaPunctaje.SelectedIndexChanged += new System.EventHandler(this.listaPunctaje_SelectedIndexChanged);
            // 
            // salveaza
            // 
            this.salveaza.BackColor = System.Drawing.Color.White;
            this.salveaza.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.salveaza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salveaza.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salveaza.ForeColor = System.Drawing.Color.DimGray;
            this.salveaza.Location = new System.Drawing.Point(105, 296);
            this.salveaza.Name = "salveaza";
            this.salveaza.Size = new System.Drawing.Size(150, 24);
            this.salveaza.TabIndex = 10;
            this.salveaza.Text = "salvează";
            this.salveaza.UseVisualStyleBackColor = false;
            this.salveaza.Click += new System.EventHandler(this.salveaza_Click);
            // 
            // Punctaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 320);
            this.Controls.Add(this.groupBox3);
            this.Name = "Punctaje";
            this.Text = "Punctaje";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button salveaza;
        private System.Windows.Forms.ListBox listaPunctaje;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;


    }
}