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

namespace com.thisiscool.csharp.nim.controller
{
	public delegate void MessageDelegate();
	public delegate void AskDelegate(bool bAnswer);

	public interface IUserInterface
	{
		void InitBoard();
		void OnBoardChanged();
		void UpdateUI();

		void Ask(String strQuestion, String strTitle, AskDelegate delAsk);
		void Message
		(
			String strMessage,
			String strTitle,
			MessageDelegate delMsg
		);
		void Error
		(
			String strMessage,
			String strTitle,
			MessageDelegate delMsg
		);
	}
}
