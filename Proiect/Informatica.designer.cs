namespace SoftEducationalCIA.Informatica
{
    partial class Informatica
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Aplicatii", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Introducere in C++");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Variabile");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Functii");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Clase");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Quicksort");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Algoritmica", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Teorie", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode8});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Informatica));
            this.treeFile = new System.Windows.Forms.TreeView();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.evaluatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeFile
            // 
            this.treeFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeFile.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeFile.Location = new System.Drawing.Point(0, 24);
            this.treeFile.Name = "treeFile";
            treeNode1.Name = "Node2";
            treeNode1.Text = "Node2";
            treeNode2.Name = "Node0";
            treeNode2.Text = "Aplicatii";
            treeNode3.Name = "Node3";
            treeNode3.Text = "Introducere in C++";
            treeNode4.Name = "Node4";
            treeNode4.Text = "Variabile";
            treeNode5.Name = "Node5";
            treeNode5.Text = "Functii";
            treeNode6.Name = "Node6";
            treeNode6.Text = "Clase";
            treeNode7.Name = "Node8";
            treeNode7.Text = "Quicksort";
            treeNode8.Name = "Node7";
            treeNode8.Text = "Algoritmica";
            treeNode9.Name = "Node1";
            treeNode9.Text = "Teorie";
            this.treeFile.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode9});
            this.treeFile.Size = new System.Drawing.Size(202, 548);
            this.treeFile.TabIndex = 0;
            this.treeFile.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFile_AfterSelect);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(202, 24);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(779, 548);
            this.webBrowser1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.evaluatorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(981, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // evaluatorToolStripMenuItem
            // 
            this.evaluatorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("evaluatorToolStripMenuItem.Image")));
            this.evaluatorToolStripMenuItem.Name = "evaluatorToolStripMenuItem";
            this.evaluatorToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.evaluatorToolStripMenuItem.Text = "Evaluator";
            this.evaluatorToolStripMenuItem.Click += new System.EventHandler(this.evaluatorToolStripMenuItem_Click);
            // 
            // Informatica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(981, 572);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.treeFile);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Informatica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informatica";
            this.Load += new System.EventHandler(this.Informatica_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeFile;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem evaluatorToolStripMenuItem;



    }
}