

using System;
using System.Drawing;
using System.Windows.Forms;

using com.thisiscool.csharp.nim.controller;
using com.thisiscool.csharp.nim.dataxfer;

namespace com.thisiscool.csharp.nim.ui
{
internal class NimControl : Control
{
// protected //
protected override void OnPaint(PaintEventArgs pe)
{
	base.OnPaint(pe);
	
	using (Brush b = new SolidBrush(BackColor))
		pe.Graphics.FillRectangle(b, pe.ClipRectangle);

	NimBoard aBoard = m_iGetNimBoard.Board;
	if (aBoard == null) return;

	// Calculate the size of each peg
	Size sz = SafeSize;

	int nHeight = (sz.Height - 20) / aBoard.NbRows;
	int nWidth = (sz.Width - 20) / ((aBoard.NbRows << 1) + 1);

	int nSide = Math.Min(nWidth, nHeight);
	nSide -= 10;

	int nCurY = 10;
	for (int i=0; i<aBoard.NbRows; ++i)
	{
		int nNbPegs = aBoard.GetPegsInRow(i);
		int nCurX = (sz.Width - nNbPegs*nWidth) >> 1;
		for (int j=0; j<nNbPegs; ++j)
		{
			m_arPeg[j,i].Draw(pe, nCurX, nCurY, nSide);
			nCurX += nWidth;
		}
		nCurY += nHeight;
	}
}

// internal //
internal NimControl
	(
	IGetNimBoard iGetNimBoard,
	IUserInterface iUserInterface
	)
{
	m_iGetNimBoard = iGetNimBoard;
	m_iUserInterface = iUserInterface;

	MouseDown +=
		new System.Windows.Forms.MouseEventHandler(OnMouseDown);

	m_Timer = new Timer();
	m_Timer.Tick += new EventHandler(TimerTick);
	m_Timer.Interval = 400;
	m_Timer.Start();

	SetStyle(ControlStyles.ResizeRedraw, true);
}

internal void GetSelectedPegs(out int nRow, out int nNbPegs)
{
	nRow = nNbPegs = -1;

	NimBoard aBoard = m_iGetNimBoard.Board;
	if (aBoard == null)
		return;

	nNbPegs = 0;
	for (int i=0; i<aBoard.NbRows; ++i)
	{
		int nNbPegsInThisRow = aBoard.GetPegsInRow(i);
		for (int j=0; j<nNbPegsInThisRow; ++j)
		{
			if (m_arPeg[j,i].MouthState == UIPeg.EMouthState.SAD)
			{
				nRow = i;
				++nNbPegs;
			}
		}
	}
}

internal void InitBoard()
{
	// Initialize our peg array. For simplicity's sake, we
	// allocate a rectangular array even though not all elements
	// will be used.
	int nNbRows = m_iGetNimBoard.Board.NbRows;
	int nNbCols = (nNbRows << 1) + 1;
	m_arPeg = new UIPeg[nNbCols, nNbRows];
	for (int i=0; i<nNbCols; ++i)
	{
		for (int j=0; j<nNbRows; ++j)
		{
			m_arPeg[i,j] = new UIPeg();
		}
	}
	Invalidate();
}

internal void DeselectAll()
{
	NimBoard aBoard = m_iGetNimBoard.Board;
	if (aBoard == null)
		return;

	for (int i=0; i<aBoard.NbRows; ++i)
	{
		int nNbPegsInThisRow = aBoard.GetPegsInRow(i);
		for (int j=0; j<nNbPegsInThisRow; ++j)
		{
			m_arPeg[j,i].MouthState = UIPeg.EMouthState.HAPPY;
		}
	}
}

// private //
private IGetNimBoard m_iGetNimBoard = null;
private IUserInterface m_iUserInterface = null;
private UIPeg[,] m_arPeg;
private Timer m_Timer;

private void OnMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
{
	Point pt = new Point(e.X, e.Y);

	NimBoard aBoard = m_iGetNimBoard.Board;
	if (aBoard == null) return;

	// Calculate the size of each peg
	Size sz = SafeSize;

	int nHeight = (sz.Height - 20) / aBoard.NbRows;
	int nWidth = (sz.Width - 20) / ((aBoard.NbRows << 1) + 1);

	int nSide = Math.Min(nWidth, nHeight);
	nSide -= 10;

	// First select the peg
	int nRow=-1, nCol=-1;
	int nCurY = 10;

	for (int i=0; i<aBoard.NbRows; ++i)
	{
		int nNbPegs = aBoard.GetPegsInRow(i);
		int nCurX = (sz.Width - nNbPegs*nWidth) >> 1;
		for (int j=0; j<nNbPegs; ++j)
		{
			Rectangle rct = new Rectangle(nCurX, nCurY, nWidth, nHeight);
			if (rct.Contains(pt))
			{
				nRow = i;
				nCol = j;
				Invalidate(rct);
				break;
			}
			nCurX += nWidth;
		}
		nCurY += nHeight;
	}

	if (nRow==-1 || nCol==-1)
		return;

	m_arPeg[nCol,nRow].MouthState = UIPeg.EMouthState.SAD;

	// Now deselect pegs from all other rows
	nCurY = 10;
	for (int i=0; i<aBoard.NbRows; ++i)
	{
		int nNbPegs = aBoard.GetPegsInRow(i);
		int nCurX = (sz.Width - nNbPegs*nWidth) >> 1;
		for (int j=0; j<nNbPegs; ++j)
		{
			if
				(
				i!=nRow
				&&
				m_arPeg[j,i].MouthState==UIPeg.EMouthState.SAD
				)
			{
				m_arPeg[j,i].MouthState = UIPeg.EMouthState.HAPPY;
				Rectangle rct =
					new Rectangle(nCurX, nCurY, nWidth, nHeight);
				Invalidate(rct);
			}
			nCurX += nWidth;
		}
		nCurY += nHeight;
	}

	m_iUserInterface.UpdateUI();
}

private void TimerTick(object sender, EventArgs e)
{
	NimBoard aBoard = m_iGetNimBoard.Board;
	if (aBoard == null) return;

	// Calculate the size of each peg
	Size sz = SafeSize;

	int nHeight = (sz.Height - 20) / aBoard.NbRows;
	int nWidth = (sz.Width - 20) / ((aBoard.NbRows << 1) + 1);

	int nSide = Math.Min(nWidth, nHeight);
	nSide -= 10;
	int nIncrementX3 = (int) (nSide / 3.6);
	int nIncrementX2 = (int) nSide / 5;

	// If there are any eyes closed, open them.
	int nCurY = 10;

	for (int i=0; i<aBoard.NbRows; ++i)
	{
		int nNbPegs = aBoard.GetPegsInRow(i);
		int nCurX = (sz.Width - nNbPegs*nWidth) >> 1;
		for (int j=0; j<nNbPegs; ++j)
		{
			if (m_arPeg[j,i].ChangeState())
			{
				// Invalidate the eyes only.
				Rectangle rct =
					new Rectangle
					(
					nCurX+nIncrementX3, nCurY+nIncrementX2+8,
					8 + (nIncrementX3 << 1), nIncrementX3+nIncrementX2
					);
				Invalidate(rct);
			}
			nCurX += nWidth;
		}
		nCurY += nHeight;
	}
}

// Hack to compensate for MinimumSize not being enforced.
private Size SafeSize
{
	get
	{
		Size sz = Size;
		if (sz.Width < 384 || sz.Height<165)
			sz = new Size(384,165);
		return sz;
	}
}
}
}
