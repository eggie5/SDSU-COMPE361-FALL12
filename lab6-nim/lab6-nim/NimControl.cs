using System;
using System.Drawing;
using System.Windows.Forms;
using com.thisiscool.csharp.nim.controller;
using com.thisiscool.csharp.nim.dataxfer;

namespace com.thisiscool.csharp.nim.ui
{
public class NimControl : Control
{
    // private //
    private IGetNimBoard m_iGetNimBoard = null;

    public IGetNimBoard IGetNimBoard
    {
        get { return m_iGetNimBoard; }
        set { m_iGetNimBoard = value; }
    }
    private IUserInterface m_iUserInterface = null;

    public IUserInterface IUserInterface
    {
        get { return m_iUserInterface; }
        set { m_iUserInterface = value; }
    }
    private UIPeg[,] pegs;
    private Timer m_Timer;

    public NimControl()
    {
        //InitializeComponent();
    }

    public NimControl ( IGetNimBoard iGetNimBoard, IUserInterface iUserInterface)
    {
        m_iGetNimBoard = iGetNimBoard;
        m_iUserInterface = iUserInterface;

        MouseDown +=
            new System.Windows.Forms.MouseEventHandler(OnMouseDown);

//        m_Timer = new Timer();
//        m_Timer.Tick += new EventHandler(TimerTick);
//        m_Timer.Interval = 400;
//        m_Timer.Start();

        SetStyle(ControlStyles.ResizeRedraw, true);
    }

    public void init()
    {
        MouseDown +=
            new System.Windows.Forms.MouseEventHandler(OnMouseDown);

        m_Timer = new Timer();
//        m_Timer.Tick += new EventHandler(TimerTick);
//        m_Timer.Interval = 400;
//        m_Timer.Start();

        SetStyle(ControlStyles.ResizeRedraw, true);
    }

 
// protected //
protected override void OnPaint(PaintEventArgs pe)
{
    if (DesignMode) return; // so it doesn't crash the designer

	base.OnPaint(pe);
	
	using (Brush b = new SolidBrush(BackColor))
		pe.Graphics.FillRectangle(b, pe.ClipRectangle);

    if (m_iGetNimBoard == null) return;
    if (m_iGetNimBoard.Board == null) return;
	NimBoard aBoard = m_iGetNimBoard.Board;
	if (aBoard == null) return;

	// Calculate the size of each peg
	Size sz = SafeSize;

	int nHeight = (sz.Height - 20) / aBoard.RowCount;
	int nWidth = (sz.Width - 20) / ((aBoard.RowCount << 1) + 1);

	int nSide = Math.Min(nWidth, nHeight);
	nSide -= 10;

	int nCurY = 10;
	for (int i=0; i<aBoard.RowCount; i++)
	{
		int nNbPegs = aBoard.GetPegsInRow(i);
		int nCurX = (sz.Width - nNbPegs*nWidth) >> 1;
		for (int j=0; j<nNbPegs; j++)
		{
			Console.WriteLine("i={0}, j={1}", i,j);
			pegs[j,i].Draw(pe, nCurX, nCurY, nSide);
			nCurX += nWidth;
		}
		nCurY += nHeight;
	}
}

// internal //


internal void GetSelectedPegs(out int nRow, out int nNbPegs)
{
	nRow = nNbPegs = -1;

	NimBoard aBoard = m_iGetNimBoard.Board;
	if (aBoard == null)
		return;

	nNbPegs = 0;
	for (int i=0; i<aBoard.RowCount; i++)
	{
		int nNbPegsInThisRow = aBoard.GetPegsInRow(i);
		for (int j=0; j<nNbPegsInThisRow; j++)
		{
			if (pegs[j,i].MouthState == UIPeg.EMouthState.SAD)
			{
				nRow = i;
				nNbPegs++;
			}
		}
	}
}

internal void InitBoard()
{
	// Initialize our peg array. For simplicity's sake, we
	// allocate a rectangular array even though not all elements
	// will be used.
	//int [] rows=m_iGetNimBoard.Board.GetArray();
	int nNbRows = m_iGetNimBoard.Board.RowCount;
	int nNbCols = m_iGetNimBoard.Board.getMaxPegCount();
	pegs = new UIPeg[nNbCols, nNbRows];
	for (int i=0; i<nNbCols; i++)
	{
		for (int j=0; j<nNbRows; j++)
		{
			pegs[i,j] = new UIPeg();
		}
	}
	Invalidate();
}

internal void DeselectAll()
{
	NimBoard aBoard = m_iGetNimBoard.Board;
	if (aBoard == null)
		return;

	for (int i=0; i<aBoard.RowCount; ++i)
	{
		int nNbPegsInThisRow = aBoard.GetPegsInRow(i);
		for (int j=0; j<nNbPegsInThisRow; ++j)
		{
			pegs[j,i].MouthState = UIPeg.EMouthState.HAPPY;
		}
	}
}



private void OnMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
{
	Point pt = new Point(e.X, e.Y);

	NimBoard aBoard = m_iGetNimBoard.Board;
	if (aBoard == null) return;

	// Calculate the size of each peg
	Size sz = SafeSize;

	int nHeight = (sz.Height - 20) / aBoard.RowCount;
	int nWidth = (sz.Width - 20) / ((aBoard.RowCount << 1) + 1);

	int nSide = Math.Min(nWidth, nHeight);
	nSide -= 10;

	// First select the peg
	int nRow=-1, nCol=-1;
	int nCurY = 10;

	for (int i=0; i<aBoard.RowCount; ++i)
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

	pegs[nCol,nRow].MouthState = UIPeg.EMouthState.SAD;

	// Now deselect pegs from all other rows
	nCurY = 10;
	for (int i=0; i<aBoard.RowCount; ++i)
	{
		int nNbPegs = aBoard.GetPegsInRow(i);
		int nCurX = (sz.Width - nNbPegs*nWidth) >> 1;
		for (int j=0; j<nNbPegs; ++j)
		{
			if
				(
				i!=nRow
				&&
				pegs[j,i].MouthState==UIPeg.EMouthState.SAD
				)
			{
				pegs[j,i].MouthState = UIPeg.EMouthState.HAPPY;
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

	int nHeight = (sz.Height - 20) / aBoard.RowCount;
	int nWidth = (sz.Width - 20) / ((aBoard.RowCount << 1) + 1);

	int nSide = Math.Min(nWidth, nHeight);
	nSide -= 10;
	int nIncrementX3 = (int) (nSide / 3.6);
	int nIncrementX2 = (int) nSide / 5;

	// If there are any eyes closed, open them.
	int nCurY = 10;

	for (int i=0; i<aBoard.RowCount; ++i)
	{
		int nNbPegs = aBoard.GetPegsInRow(i);
		int nCurX = (sz.Width - nNbPegs*nWidth) >> 1;
		for (int j=0; j<nNbPegs; ++j)
		{
			if (pegs[j,i].ChangeState())
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
