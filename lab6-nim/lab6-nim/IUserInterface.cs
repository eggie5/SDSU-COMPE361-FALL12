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
