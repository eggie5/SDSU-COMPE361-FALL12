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

namespace com.thisiscool.csharp.nim.model
{
	public class TooManyRowsException : Exception
	{
		public TooManyRowsException(int nNbRows) :
			base("Too many rows: "+nNbRows)
		{
			m_nNbRows = nNbRows;
		}

		public int NbRows {get {return m_nNbRows;}}

		// private //
		private int m_nNbRows;
	}
	
	public class NimModel
	{
		public NimModel(int nNbRows)
		{
			if (nNbRows<0 || nNbRows>=10)
			{
				throw new TooManyRowsException(nNbRows);
			}

			m_nNbRows = nNbRows;
			int nNbPegs = nNbRows;
			for (int nRow=nNbRows-1; nRow>=0; --nRow)
			{
				m_arnPegs[nRow] = nNbPegs;
				nNbPegs += 2;
			}
		}

		// Accessors
		public int NbRows               {get {return m_nNbRows;}}
		public int GetPegsInRow(int nRow)
		{
			return m_arnPegs[nRow];
		}
		public bool IsGameOver
		{
			get 
			{
				int nNbPegsTotal = 0;
				for (int nRow=0; nRow<NbRows; ++nRow)
					nNbPegsTotal += GetPegsInRow(nRow);

				return nNbPegsTotal == 0;
			}
		}

		// Operations
		public bool MakeMove(int nRow, int nNbPegs)
		{
			if (nRow>=NbRows || nNbPegs==0 || GetPegsInRow(nRow)<nNbPegs)
				return false;

			m_arnPegs[nRow] -= nNbPegs;

			return true;
		}

		public void CalcBestMove(out int rnRow, out int rnNbPegs)
		{
			bool bSolutionFound = false;

			// The compiler isn't smart enough to see that
			// all control paths return values.
			rnRow = rnNbPegs = 0;

			for (int nRow=0; nRow<NbRows && !bSolutionFound; ++nRow)
			{
				int nXorStart = 0;
				for (int i=0; i<NbRows; ++i)
				{
					if (i!=nRow)
						nXorStart ^= GetPegsInRow(i);
				}
				for
				(
					int nNbPegs=1;
					nNbPegs<=GetPegsInRow(nRow) && !bSolutionFound;
					++nNbPegs
				)
				{
					int nXor = nXorStart ^ (GetPegsInRow(nRow)-nNbPegs);
					if (nXor == 0)
					{
						bSolutionFound = true;
						rnRow = nRow;
						rnNbPegs = nNbPegs;
					}
				}
			}

			if (!bSolutionFound)
			{
				int nRowWithMostPegs = 0;
				int nMaxPegs = 0;
				for (int i=0; i<NbRows; ++i)
				{
					if (GetPegsInRow(i)>nMaxPegs)
					{
						nMaxPegs = GetPegsInRow(i);
						nRowWithMostPegs = i;
					}
				}
				rnRow = nRowWithMostPegs;
				rnNbPegs = 1;
			}
		}

		// private //
		private int m_nNbRows;
		private int[] m_arnPegs = new int[10];
	}
}