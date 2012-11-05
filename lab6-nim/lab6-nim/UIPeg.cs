
using System;

using Brush = System.Drawing.Brush;
using Brushes = System.Drawing.Brushes;
using Color = System.Drawing.Color;
using Pen = System.Drawing.Pen;
using Rectangle = System.Drawing.Rectangle;
using PaintEventArgs = System.Windows.Forms.PaintEventArgs;

namespace com.thisiscool.csharp.nim.ui
{
	public class UIPeg
	{
	
		
		private Selected brush = Selected.YES;
        private Brush not_selected_color = Brushes.Blue;

        public Brush Not_selected_color
        {
            get { return not_selected_color; }
            set { not_selected_color = value; }
        }
        private Brush selected_color = Brushes.Red;

        public Brush Selected_color
        {
            get { return selected_color; }
            set { selected_color = value; }
        }


		
		public enum Selected {YES, NO};
		
		

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

			Brush brsh = brush == Selected.YES ? not_selected_color : selected_color;

			using (Pen aPen = new Pen(clr, nPenWidth)) {
				// Draw the head
				pe.Graphics.DrawEllipse (aPen, nX, nY, nSide, nSide);
				pe.Graphics.FillEllipse (brsh, nX, nY, nSide, nSide);
			}
		}

	
	
	}
}
