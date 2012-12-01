

using System;

namespace com.eggie5.nim.dataxfer
{

	public class NimBoard
	{
		public int getMaxPegCount ()
		{
			int max=0;
			for (int i=0; i<rows.Length; i++) {
				if(rows[i]>max)
					max=rows[i];
			}
			return max;
		}

		public int[] GetArray ()
		{
			return this.rows;
		}

		private int[] rows;

		public NimBoard(int[] rows)
		{
			this.rows = rows;
		}

		public int RowCount	
		{get {return rows.Length;}}

		public int GetPegsInRow(int nRow)
		{
			return rows[nRow];
		}

	
	}
}
