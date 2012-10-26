
using System;

using Brush = System.Drawing.Brush;
using Brushes = System.Drawing.Brushes;
using Color = System.Drawing.Color;
using Pen = System.Drawing.Pen;
using Rectangle = System.Drawing.Rectangle;
using PaintEventArgs = System.Windows.Forms.PaintEventArgs;

namespace com.thisiscool.csharp.nim.ui
{
	internal class UIPeg
	{
		public enum EEyesState {STRAIGHT, LEFT, RIGHT, CLOSED};
		public enum EMouthState {HAPPY, SAD};
		
		internal UIPeg()
		{}

		// Properties
		internal EEyesState EyesState
		{
			get {return m_eEyeState;}
			set {m_eEyeState = value;}
		}

		internal EMouthState MouthState
		{
			get {return m_eMouthState;}
			set {m_eMouthState = value;}
		}

		// Operations
		internal bool ChangeState()
		{
			if (EyesState == EEyesState.CLOSED)
			{
				EyesState = EEyesState.STRAIGHT;
				return true;
			}

			if (m_rnd.Next(20) != 4)
				return false;

			// Change my eye state
			EEyesState eNewState = EyesState;
			while (eNewState == EyesState)
			{
				eNewState =
					(EEyesState) m_rnd.Next((int)(EEyesState.CLOSED)+1);
			}

			EyesState = eNewState;
			return true;
		}

		internal void Draw(PaintEventArgs pe, int nX, int nY, int nSide)
		{
			nX+=8; nY+=8;
			int nIncrement = nSide / 10;
			int nPenWidth = Math.Max(nSide / 15, 1);
			int nIncrementX2 = nSide / 5;
			int nIncrementX3 = (int) (nSide / 3.6);
			int nIncrementX35 = (int) (nSide / 3.0);
			int nIncrementX4 = (int) (nSide / 2.5);

			Color clr =
				m_eMouthState==EMouthState.HAPPY ? Color.Blue : Color.Red;

			Brush brsh =
				m_eMouthState==EMouthState.HAPPY ? Brushes.Blue : Brushes.Red;

			using (Pen aPen = new Pen(clr, nPenWidth))
			{
				// Draw the head
				pe.Graphics.DrawEllipse(aPen, nX, nY, nSide, nSide);
				pe.Graphics.DrawEllipse
					(
						aPen,
						nX+nIncrement, nY+nIncrement,
						nSide-nIncrementX2, nSide-nIncrementX2
					);

				if (m_eEyeState == EEyesState.CLOSED)
				{
					pe.Graphics.FillEllipse
						(
						brsh,
						nX+nIncrementX3, nY+nIncrementX3,
						nIncrementX2, nIncrementX2
						);
					pe.Graphics.FillEllipse
						(
						brsh,
						nX+nIncrementX3+nIncrementX3, nY+nIncrementX3,
						nIncrementX2, nIncrementX2
						);
				}
				else
				{
					pe.Graphics.DrawEllipse
						(
						aPen,
						nX+nIncrementX3, nY+nIncrementX3,
						nIncrementX2, nIncrementX2
						);
					pe.Graphics.DrawEllipse
						(
						aPen,
						nX+nIncrementX3+nIncrementX3, nY+nIncrementX3,
						nIncrementX2, nIncrementX2
						);
				}

				int nEyeOffset = 0;
				
				switch (m_eEyeState)
				{
					case EEyesState.LEFT:
						nEyeOffset -= (nSide / 25);
						break;
					case EEyesState.RIGHT:
						nEyeOffset += (nSide / 25);
						break;
				}

				pe.Graphics.FillEllipse
				(
					brsh,
					nX+nIncrementX35+nEyeOffset, nY+nIncrementX35,
					nIncrement, nIncrement
				);
				pe.Graphics.FillEllipse
				(
					brsh,
					nX+nIncrementX3+nIncrementX35+nEyeOffset, nY+nIncrementX35,
					nIncrement, nIncrement
				);

				/*
				// TODO: Replace current implementation with this
				// once DrawArc is implemented.
				switch (m_eMouthState)
				{
					case EMouthState.HAPPY:
						pe.Graphics.DrawArc
							(
								aPen,
								nX+nIncrementX2, nY+nIncrementX2,
								nSide-nIncrementX4, nSide-nIncrementX4,
								0, 180
							);
						break;
					case EMouthState.SAD:
						pe.Graphics.DrawArc
							(
								aPen,
								nX+nIncrementX2, nY+nIncrementX4+nIncrementX2,
								nSide-nIncrementX4, nSide-nIncrementX4,
								-30, -120
							);
						break;
				}
				*/

				switch (m_eMouthState)
				{
					case EMouthState.HAPPY:
						pe.Graphics.DrawLine
							(
							aPen,
							nX+nIncrementX2, nY+nIncrementX4+nIncrementX2,
							nX+nIncrementX4, nY+nIncrementX4+nIncrementX35
							);
						pe.Graphics.DrawLine
							(
							aPen,
							nX+nIncrementX4+nIncrementX4, nY+nIncrementX4+nIncrementX2,
							nX+nIncrementX4+nIncrementX2, nY+nIncrementX4+nIncrementX35
							);
						pe.Graphics.DrawLine
							(
							aPen,
							nX+nIncrementX35, nY+nIncrementX4+nIncrementX35,
							nX+nIncrementX4+nIncrementX3, nY+nIncrementX4+nIncrementX35
							);
						break;
					case EMouthState.SAD:
						pe.Graphics.DrawLine
							(
							aPen,
							nX+nIncrementX4, nY+nIncrementX4+nIncrementX2,
							nX+nIncrementX2, nY+nIncrementX4+nIncrementX3
							);
						pe.Graphics.DrawLine
							(
							aPen,
							nX+nIncrementX4+nIncrementX2, nY+nIncrementX4+nIncrementX2,
							nX+nIncrementX4+nIncrementX4, nY+nIncrementX4+nIncrementX3
							);
						pe.Graphics.DrawLine
							(
							aPen,
							nX+nIncrementX4+nIncrementX3, nY+nIncrementX4+nIncrementX2,
							nX+nIncrementX35, nY+nIncrementX4+nIncrementX2
							);
						break;
				}
			}
		}

		// private //
		private EEyesState m_eEyeState = EEyesState.STRAIGHT;
		private EMouthState m_eMouthState = EMouthState.HAPPY;

		private static Random m_rnd = new Random();
	}
}
