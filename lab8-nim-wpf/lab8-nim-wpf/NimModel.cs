
using System;

namespace com.eggie5.nim.model
{
	public class NimModel
	{
		private int[] rows;

		public NimModel (int num_of_rows)
		{
			if (num_of_rows < 0 || num_of_rows >= 10) {
				throw new TooManyRowsException (num_of_rows);
			}

			rows = new int[num_of_rows];

			//pegs/row should be random per spec.
			Random rand = new Random (DateTime.Now.Millisecond);

			for (int n=num_of_rows-1; n>=0; --n) {
				rows [n] = rand.Next (1, 7);
			}
		}

		// Accessors
		public int RowCount               
		{ get { return rows.Length; } }

		public int GetPegsInRow (int n)
		{
			return rows [n];
		}

		public bool IsGameOver {
			get {
				int total_pegs = 0;
				for (int nRow=0; nRow<RowCount; ++nRow)
					total_pegs += GetPegsInRow (nRow);

				return total_pegs == 0;
			}
		}

		// Operations
		public bool MakeMove (int nRow, int nNbPegs)
		{
			if (nRow >= RowCount || nNbPegs == 0 || GetPegsInRow (nRow) < nNbPegs)
				return false;

			rows [nRow] -= nNbPegs;

			return true;
		}

		public void CalcBestMove (out int rnRow, out int rnNbPegs)
		{
			bool bSolutionFound = false;

			rnRow = rnNbPegs = 0;

			//n^2 algorithm 
			for (int nRow=0; nRow<RowCount && !bSolutionFound; ++nRow) {
				int nXorStart = 0;
				for (int i=0; i<RowCount; ++i) {
					if (i != nRow)
						nXorStart ^= GetPegsInRow (i);
				}
				for ( int nNbPegs=1; nNbPegs<=GetPegsInRow(nRow) && !bSolutionFound; ++nNbPegs ) {
					int nXor = nXorStart ^ (GetPegsInRow (nRow) - nNbPegs);
					if (nXor == 0) {
						bSolutionFound = true;
						rnRow = nRow;
						rnNbPegs = nNbPegs;
					}
				}
			}//end for

			if (!bSolutionFound) {
				int nRowWithMostPegs = 0;
				int nMaxPegs = 0;
				for (int i=0; i<RowCount; ++i) {
					if (GetPegsInRow (i) > nMaxPegs) {
						nMaxPegs = GetPegsInRow (i);
						nRowWithMostPegs = i;
					}
				}
				rnRow = nRowWithMostPegs;
				rnNbPegs = 1;
			}
		}


	}

	public class TooManyRowsException : Exception
	{
		public TooManyRowsException (int nNbRows) :
			base("Too many rows: "+nNbRows)
		{
			row_count = nNbRows;
		}
		
		public int RowsCount { get { return row_count; } }
		
		private int row_count;
	}
}