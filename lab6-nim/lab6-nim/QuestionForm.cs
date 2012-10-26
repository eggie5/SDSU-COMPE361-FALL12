
using System;
using System.Drawing;
using System.Windows.Forms;

using com.thisiscool.csharp.nim.controller;

namespace com.thisiscool.csharp.nim.ui
{
public class QuestionForm : Form
{
public QuestionForm()
{
	LayoutControls();
}

public String Question
{
	get {return lblQuestion.Text;}
	set {lblQuestion.Text = value;}
}

public AskDelegate Delegate
{
	set {m_delAsk = value;}
}

// private //
private void LayoutControls()
{
	lblQuestion = new Label();
	bnYes = new Button();
	bnNo = new Button();
	SuspendLayout();

	lblQuestion.Location = new Point(16, 16);
	lblQuestion.Name = "lblQuestion";
	lblQuestion.Size = new Size(272, 23);
	lblQuestion.TabIndex = 0;
	lblQuestion.TextAlign = ContentAlignment.MiddleCenter;

	bnYes.DialogResult = DialogResult.OK;
	bnYes.Location = new Point(67, 51);
	bnYes.Name = "bnYes";
	bnYes.TabIndex = 1;
	bnYes.Text = "Yes";
	bnYes.Click += new System.EventHandler(bnYes_Click);

	bnNo.DialogResult = DialogResult.OK;
	bnNo.Location = new Point(163, 51);
	bnNo.Name = "bnNo";
	bnNo.TabIndex = 2;
	bnNo.Text = "No";
	bnNo.Click += new System.EventHandler(bnNo_Click);

	AutoScaleBaseSize = new Size(5, 13);
	ClientSize = new Size(304, 77);
	Controls.Add(bnNo);
	Controls.Add(bnYes);
	Controls.Add(lblQuestion);
	Name = "QuestionForm";
	StartPosition = FormStartPosition.CenterScreen;
	Text = "Title";
	Closing += new System.ComponentModel.CancelEventHandler(QuestionForm_Closing);
	ResumeLayout(false);

}

private AskDelegate m_delAsk = null;

private Label lblQuestion;
private Button bnYes;
private Button bnNo;

private void DoAnswer(bool bAnswer)
{
	Owner.Enabled = true;
	Hide();
	m_delAsk(bAnswer);
}


// Message Handlers
private void bnYes_Click(object sender, System.EventArgs e)
{
	DoAnswer(true);
}

private void QuestionForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
{
	e.Cancel = true;
	DoAnswer(false);
}

private void bnNo_Click(object sender, System.EventArgs e)
{
	DoAnswer(false);
}
}
}
