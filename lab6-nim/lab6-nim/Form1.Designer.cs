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
            this.nimControl1 = new com.thisiscool.csharp.nim.ui.NimControl();
            this.SuspendLayout();
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonNewGame.Location = new System.Drawing.Point(45, 333);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(75, 23);
            this.buttonNewGame.TabIndex = 0;
            this.buttonNewGame.Text = "New Game";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // buttonRemovePegs
            // 
            this.buttonRemovePegs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemovePegs.Enabled = false;
            this.buttonRemovePegs.Location = new System.Drawing.Point(404, 333);
            this.buttonRemovePegs.Name = "buttonRemovePegs";
            this.buttonRemovePegs.Size = new System.Drawing.Size(75, 23);
            this.buttonRemovePegs.TabIndex = 2;
            this.buttonRemovePegs.Text = "Remove";
            this.buttonRemovePegs.UseVisualStyleBackColor = true;
            this.buttonRemovePegs.Click += new System.EventHandler(this.buttonRemovePegs_Click);
            // 
            // nimControl1
            // 
            this.nimControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nimControl1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nimControl1.IGetNimBoard = null;
            this.nimControl1.IUserInterface = null;
            this.nimControl1.Location = new System.Drawing.Point(0, 0);
            this.nimControl1.Name = "nimControl1";
            this.nimControl1.Size = new System.Drawing.Size(557, 312);
            this.nimControl1.TabIndex = 1;
            this.nimControl1.Text = "nimControl1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 382);
            this.Controls.Add(this.buttonRemovePegs);
            this.Controls.Add(this.nimControl1);
            this.Controls.Add(this.buttonNewGame);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonNewGame;
        private com.thisiscool.csharp.nim.ui.NimControl nimControl1;
        private System.Windows.Forms.Button buttonRemovePegs;
    }
}