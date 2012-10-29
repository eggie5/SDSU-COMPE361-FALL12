
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
		// private //
		
		private Selected brush = Selected.YES;


		public enum EEyesState {STRAIGHT, LEFT, RIGHT, CLOSED};
		public enum Selected {YES, NO};
		
		internal UIPeg()
		{}

		internal Selected MouthState
		{
			get {return brush;}
			set {brush = value;}
		}



		internal void Draw (PaintEventArgs pe, int nX, int nY, int nSide)
		{
			nX += 8;
			nY += 8;
		
			int nPenWidth = Math.Max (nSide / 15, 1);
		

			Color clr =Color.Blue;

			Brush brsh = brush == Selected.YES ? Brushes.Blue : Brushes.Red;

			using (Pen aPen = new Pen(clr, nPenWidth)) {
				// Draw the head
				pe.Graphics.DrawEllipse (aPen, nX, nY, nSide, nSide);
				pe.Graphics.FillEllipse (brsh, nX, nY, nSide, nSide);
			}
		}

	
	
	}
}
