/*
Copyright (C) 2003 by Mohan Embar
http://www.thisiscool.com/

This program is free software; you can redistribute it and/or modify it under
the terms of the GNU General Public License as published by the Free Software
Foundation; either version 2 of the License, or (at your option) any later version. 

This program is distributed in the hope that it will be useful, but WITHOUT ANY
WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A
PARTICULAR PURPOSE. See the GNU General Public License for more details. 

You should have received a copy of the GNU General Public License along with
this program; if not, write to the Free Software Foundation, Inc., 675 Mass Ave,
Cambridge, MA 02139, USA. 
*/

using System;
using System.Drawing;
using System.Windows.Forms;

using com.thisiscool.csharp.nim.controller;

namespace com.thisiscool.csharp.nim.ui
{
public class MessageForm : Form
{
public MessageForm()
{
	LayoutControls();
}

public String Message
{
	get {return lblMessage.Text;}
	set {lblMessage.Text = value;}
}

public MessageDelegate Delegate
{
	set {m_delMsg = value;}
}

// private //
private MessageDelegate m_delMsg = null;

private Label lblMessage;
private Button bnOK;

private void Dismiss()
{
	Owner.Enabled = true;
	Hide();
	m_delMsg();
}

private void LayoutControls()
{
	lblMessage = new Label();
	bnOK = new Button();
	SuspendLayout();

	lblMessage.Location = new Point(16, 16);
	lblMessage.Name = "lblMessage";
	lblMessage.Size = new Size(272, 23);
	lblMessage.TabIndex = 0;
	lblMessage.TextAlign = ContentAlignment.MiddleCenter;

	bnOK.DialogResult = DialogResult.OK;
	bnOK.Location = new Point(115, 51);
	bnOK.Name = "bnOK";
	bnOK.TabIndex = 1;
	bnOK.Text = "OK";
	bnOK.Click += new System.EventHandler(bnOK_Click);

	AutoScaleBaseSize = new Size(5, 13);
	ClientSize = new Size(304, 77);
	Controls.Add(bnOK);
	Controls.Add(lblMessage);
	Name = "MessageForm";
	StartPosition = FormStartPosition.CenterScreen;
	Text = "Title";
	Closing += new System.ComponentModel.CancelEventHandler(MessageForm_Closing);
	ResumeLayout(false);

}

// Message Handlers
private void bnOK_Click(object sender, System.EventArgs e)
{
	Dismiss();
}

private void MessageForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
{
	e.Cancel = true;
	Dismiss();
}
}
}
