
using System;
using System.Drawing;
using System.Windows.Forms;

using com.thisiscool.csharp.nim.controller;

namespace com.thisiscool.csharp.nim.ui
{
public class NimForm : Form, IUserInterface
{
public NimForm()
{
	SetStyle(ControlStyles.ResizeRedraw, true);

	m_frmMessage.Owner = this;
	m_frmQuestion.Owner = this;

	m_Controller = new Controller(this);

	LayoutControls();

	UpdateUI();
}

// private //
private MessageForm m_frmMessage = new MessageForm();
private QuestionForm m_frmQuestion = new QuestionForm();

private Panel panel1;
private Label label1;
private Panel panel2;
private Panel panel3;
private Panel panel4;
private Button bnRemovePegs;
private Button bnExit;
private Panel panel5;
private Button bnNewGame;

private Controller m_Controller;
private Label label2;
private Panel panel6;
private Label label3;
private Label label4;
private NimControl m_NimControl;

private void LayoutControls()
{
	panel1 = new Panel();
	panel2 = new Panel();
	panel3 = new Panel();
	panel4 = new Panel();
	bnNewGame = new Button();
	bnExit = new Button();
	bnRemovePegs = new Button();
	panel6 = new Panel();
	label2 = new Label();
	label1 = new Label();
	panel5 = new Panel();
	label3 = new Label();
	label4 = new Label();
	panel1.SuspendLayout();
	panel2.SuspendLayout();
	panel3.SuspendLayout();
	panel4.SuspendLayout();
	panel6.SuspendLayout();
	SuspendLayout();

	panel1.Controls.Add(panel2);
	panel1.Controls.Add(label1);
	panel1.Dock = DockStyle.Bottom;
	panel1.Location = new Point(0, 181);
	panel1.Name = "panel1";
	panel1.Size = new Size(384, 128);
	panel1.TabIndex = 0;

	panel2.Controls.Add(panel3);
	panel2.Controls.Add(label2);
	panel2.Dock = DockStyle.Fill;
	panel2.Location = new Point(0, 23);
	panel2.Name = "panel2";
	panel2.Size = new Size(384, 105);
	panel2.TabIndex = 1;

	panel3.Controls.Add(panel4);
	panel3.Controls.Add(panel6);
	panel3.Dock = DockStyle.Fill;
	panel3.Location = new Point(0, 23);
	panel3.Name = "panel3";
	panel3.Size = new Size(384, 82);
	panel3.TabIndex = 1;

	panel4.Controls.Add(bnNewGame);
	panel4.Controls.Add(bnExit);
	panel4.Controls.Add(bnRemovePegs);
	panel4.Dock = DockStyle.Fill;
	panel4.Location = new Point(0, 32);
	panel4.Name = "panel4";
	panel4.Size = new Size(384, 50);
	panel4.TabIndex = 1;

	bnNewGame.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) 
		| AnchorStyles.Left)));
	bnNewGame.Location = new Point(14, 9);
	bnNewGame.Name = "bnNewGame";
	bnNewGame.Size = new Size(104, 32);
	bnNewGame.TabIndex = 0;
	bnNewGame.Text = "New Game";
	bnNewGame.Click += new System.EventHandler(bnNewGame_Click);

	bnExit.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) 
		| AnchorStyles.Right)));
	bnExit.Location = new Point(266, 9);
	bnExit.Name = "bnExit";
	bnExit.Size = new Size(104, 32);
	bnExit.TabIndex = 2;
	bnExit.Text = "Exit";
	bnExit.Click += new System.EventHandler(bnExit_Click);

	bnRemovePegs.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) 
		| AnchorStyles.Left)));
	bnRemovePegs.Location = new Point(140, 9);
	bnRemovePegs.Name = "bnRemovePegs";
	bnRemovePegs.Size = new Size(104, 32);
	bnRemovePegs.TabIndex = 1;
	bnRemovePegs.Text = "Remove Pegs";
	bnRemovePegs.Click += new System.EventHandler(bnRemovePegs_Click);

	panel6.Controls.Add(label4);
	panel6.Controls.Add(label3);
	panel6.Dock = DockStyle.Top;
	panel6.Location = new Point(0, 0);
	panel6.Name = "panel6";
	panel6.Size = new Size(384, 32);
	panel6.TabIndex = 3;



	panel5.Dock = DockStyle.Fill;
	panel5.Location = new Point(0, 0);
	panel5.Name = "panel5";
	panel5.Size = new Size(384, 181);
	panel5.TabIndex = 1;

	label3.Dock = DockStyle.Top;
	label3.Location = new Point(0, 0);
	label3.Name = "label3";
	label3.Size = new Size(384, 12);
	label3.TabIndex = 0;
	label3.Text = "Remove as many pegs as you want from a given row.";
	label3.TextAlign = ContentAlignment.MiddleCenter;

	label4.Dock = DockStyle.Fill;
	label4.Location = new Point(0, 12);
	label4.Name = "label4";
	label4.Size = new Size(384, 20);
	label4.TabIndex = 1;
	label4.Text = "To win, you must remove the last peg.";
	label4.TextAlign = ContentAlignment.MiddleCenter;

	AutoScaleBaseSize = new Size(5, 13);
	ClientSize = new Size(384, 309);
	Controls.Add(panel5);
	Controls.Add(panel1);
	MinimumSize = new Size(392, 320);
	Name = "NimForm";
	Text = "Alex Nimm";
	panel1.ResumeLayout(false);
	panel2.ResumeLayout(false);
	panel3.ResumeLayout(false);
	panel4.ResumeLayout(false);
	panel6.ResumeLayout(false);
	ResumeLayout(false);

	m_NimControl = new NimControl(m_Controller, this);
	m_NimControl.Dock = DockStyle.Fill;
	m_NimControl.Location = new Point(0, 0);
	panel5.Controls.Add(m_NimControl);
	
	this.ClientSize = new Size(384, 293);
}

static void Main() 
{
	Application.Run(new NimForm());
}

private void bnExit_Click(object sender, System.EventArgs e)
{
	Close();
}

// IUserInterface overrides
public void InitBoard()
{
	m_NimControl.InitBoard();
}

public void OnBoardChanged()
{
	m_NimControl.Invalidate();
}

public void UpdateUI()
{
	UpdateCtrls();
}

/*
// TODO: Replace current implementation with this
// once MessageBox support is complete.
public void Ask
(
	String strQuestion,
	String strTitle,
	AskDelegate delAsk
)
{
	DialogResult aResult =
		MessageBox.Show
		(
			this,
			strQuestion,
			strTitle,
			MessageBoxButtons.YesNo,
			MessageBoxIcon.Question
		);

	delAsk(aResult == DialogResult.Yes);
}

public void Message
(
	String strMessage,
	String strTitle,
	MessageDelegate delMsg
)
{
	MessageBox.Show
	(
		this,
		strMessage,
		strTitle,
		MessageBoxButtons.OK,
		MessageBoxIcon.Information
	);
	delMsg();
}

public void Error
(
	String strMessage,
	String strTitle,
	MessageDelegate delMsg
)
{
	MessageBox.Show
	(
		this,
		strMessage,
		strTitle,
		MessageBoxButtons.OK,
		MessageBoxIcon.Error
	);
	delMsg();
}
*/

public void Ask
(
	String strQuestion,
	String strTitle,
	AskDelegate delAsk
)
{
	m_frmQuestion.Text = strTitle;
	m_frmQuestion.Question = strQuestion;
	m_frmQuestion.Delegate = delAsk;
	this.Enabled = false;
	m_frmQuestion.Invalidate();
	m_frmQuestion.Show();
}

public void Message
(
	String strMessage,
	String strTitle,
	MessageDelegate delMsg
)
{
	m_frmMessage.Text = strTitle;
	m_frmMessage.Message = strMessage;
	m_frmMessage.Delegate = delMsg;
	this.Enabled = false;
	m_frmMessage.Invalidate();
	m_frmMessage.Show();
}

public void Error
(
	String strMessage,
	String strTitle,
	MessageDelegate delMsg
)
{
	Message(strMessage, strTitle, delMsg);
}

private void UpdateCtrls()
{
	int nRow, nNbPegs;
	m_NimControl.GetSelectedPegs(out nRow, out nNbPegs);
	bnRemovePegs.Enabled = nNbPegs > 0;
}

private void bnNewGame_Click(object sender, System.EventArgs e)
{
	m_Controller.NewGame();
}

private void bnRemovePegs_Click(object sender, System.EventArgs e)
{
	int nRow, nNbPegs;
	m_NimControl.GetSelectedPegs(out nRow, out nNbPegs);
	m_NimControl.DeselectAll();
	m_Controller.OnMove(nRow,nNbPegs);
}
}
}
