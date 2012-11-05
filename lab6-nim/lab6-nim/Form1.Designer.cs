namespace nim_test
{
    partial class Form1
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
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.buttonRemovePegs = new System.Windows.Forms.Button();
            this.textBoxMaxRows = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelUserScore = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelComputerScore = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nimControl1 = new com.eggie5.nim.ui.NimControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonNewGame.Location = new System.Drawing.Point(12, 318);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(90, 34);
            this.buttonNewGame.TabIndex = 0;
            this.buttonNewGame.Text = "&New Game";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // buttonRemovePegs
            // 
            this.buttonRemovePegs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemovePegs.Enabled = false;
            this.buttonRemovePegs.Location = new System.Drawing.Point(471, 318);
            this.buttonRemovePegs.Name = "buttonRemovePegs";
            this.buttonRemovePegs.Size = new System.Drawing.Size(75, 52);
            this.buttonRemovePegs.TabIndex = 2;
            this.buttonRemovePegs.Text = "Remove";
            this.buttonRemovePegs.UseVisualStyleBackColor = true;
            this.buttonRemovePegs.Click += new System.EventHandler(this.buttonRemovePegs_Click);
            // 
            // textBoxMaxRows
            // 
            this.textBoxMaxRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxMaxRows.Location = new System.Drawing.Point(74, 357);
            this.textBoxMaxRows.Name = "textBoxMaxRows";
            this.textBoxMaxRows.Size = new System.Drawing.Size(28, 20);
            this.textBoxMaxRows.TabIndex = 3;
            this.textBoxMaxRows.Text = "5";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 360);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Rows Max:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 329);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "User:";
            // 
            // labelUserScore
            // 
            this.labelUserScore.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelUserScore.AutoSize = true;
            this.labelUserScore.Location = new System.Drawing.Point(190, 342);
            this.labelUserScore.Name = "labelUserScore";
            this.labelUserScore.Size = new System.Drawing.Size(13, 13);
            this.labelUserScore.TabIndex = 6;
            this.labelUserScore.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(303, 329);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Computer";
            // 
            // labelComputerScore
            // 
            this.labelComputerScore.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelComputerScore.AutoSize = true;
            this.labelComputerScore.Location = new System.Drawing.Point(308, 346);
            this.labelComputerScore.Name = "labelComputerScore";
            this.labelComputerScore.Size = new System.Drawing.Size(13, 13);
            this.labelComputerScore.TabIndex = 8;
            this.labelComputerScore.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(558, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem1.Text = "Help";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // nimControl1
            // 
            this.nimControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nimControl1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nimControl1.IGetNimBoard = null;
            this.nimControl1.IUserInterface = null;
            this.nimControl1.Location = new System.Drawing.Point(0, 27);
            this.nimControl1.Name = "nimControl1";
            this.nimControl1.Size = new System.Drawing.Size(557, 285);
            this.nimControl1.TabIndex = 1;
            this.nimControl1.Text = "nimControl1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 382);
            this.Controls.Add(this.labelComputerScore);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelUserScore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMaxRows);
            this.Controls.Add(this.buttonRemovePegs);
            this.Controls.Add(this.nimControl1);
            this.Controls.Add(this.buttonNewGame);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNewGame;
        private com.eggie5.nim.ui.NimControl nimControl1;
        private System.Windows.Forms.Button buttonRemovePegs;
        private System.Windows.Forms.TextBox textBoxMaxRows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelUserScore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelComputerScore;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}