using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.eggie5.nim.controller;

namespace nim_test
{
    public partial class Form1 : Form, IUserInterface
    {
        private Controller m_Controller;

        public Form1()
        {
            m_Controller = new Controller(this);
            

            InitializeComponent();
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            m_Controller.NewGame(Int32.Parse(this.textBoxMaxRows.Text));
        }



        public void InitBoard()
        {
            nimControl1.InitBoard();
        }

        public void OnBoardChanged()
        {
			nimControl1.Invalidate();
        }

        public void UpdateUI()
        {
			int nRow, nNbPegs;
			nimControl1.GetSelectedPegs(out nRow, out nNbPegs);
			buttonRemovePegs.Enabled = nNbPegs > 0;
        }

        public void Ask(string strQuestion, string strTitle, AskDelegate delAsk)
        {
            var result=MessageBox.Show(strQuestion, strTitle, MessageBoxButtons.YesNo);
			if(result==DialogResult.Yes)
				delAsk(true);
			else
				delAsk(false);
            

        }

        public void MessageBoxShow(string strMessage, string strTitle, MessageDelegate delMsg)
        {
            //hack to show score (fastest way)
            if(strMessage.Contains("I win."))
            {
                labelComputerScore.Text = (Int32.Parse(labelComputerScore.Text) + 1).ToString();
            }

			MessageBox.Show(strMessage, strTitle);
			delMsg();
        }

        public void Error(string strMessage, string strTitle, MessageDelegate delMsg)
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nimControl1.IGetNimBoard = m_Controller;
            nimControl1.IUserInterface = this;
            nimControl1.init();
        }

        private void buttonRemovePegs_Click(object sender, EventArgs e)
        {
			int nRow, nNbPegs;
			nimControl1.GetSelectedPegs(out nRow, out nNbPegs);
			nimControl1.DeselectAll();
			m_Controller.OnMove(nRow,nNbPegs);

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new AboutBox1().Show();
        }


    }
}
