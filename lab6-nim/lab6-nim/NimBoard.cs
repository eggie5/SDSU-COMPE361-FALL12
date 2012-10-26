

using System;

namespace com.thisiscool.csharp.nim.dataxfer
{

	public class NimBoard
	{
		public NimBoard(int[] arnRows)
		{
			m_arnRows = arnRows;
		}

		public int NbRows	{get {return m_arnRows.Length;}}
		public int GetPegsInRow(int nRow)
		{
			return m_arnRows[nRow];
		}

		// private //
		private int[] m_arnRows;
	}
}
