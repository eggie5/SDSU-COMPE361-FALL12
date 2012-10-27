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

namespace com.thisiscool.csharp.nim.dataxfer
{
	/// <summary>
	/// Summary description for NimBoard.
	/// </summary>
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