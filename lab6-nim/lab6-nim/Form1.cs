﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.thisiscool.csharp.nim.controller;

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
            m_Controller.NewGame();
        }



        public void InitBoard()
        {
            nimControl1.InitBoard();
        }

        public void OnBoardChanged()
        {
            throw new NotImplementedException();
        }

        public void UpdateUI()
        {
            throw new NotImplementedException();
        }

        public void Ask(string strQuestion, string strTitle, AskDelegate delAsk)
        {
            var result=MessageBox.Show(strQuestion, strTitle, MessageBoxButtons.YesNo);
            

        }

        public void Message(string strMessage, string strTitle, MessageDelegate delMsg)
        {
            throw new NotImplementedException();
        }

        public void Error(string strMessage, string strTitle, MessageDelegate delMsg)
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nimControl1.IGetNimBoard = m_Controller;
            nimControl1.IUserInterface = this;
        }
    }
}