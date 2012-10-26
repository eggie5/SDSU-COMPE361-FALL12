

using System;

using com.thisiscool.csharp.nim.dataxfer;
using com.thisiscool.csharp.nim.model;

namespace com.thisiscool.csharp.nim.controller
{

	public class Controller : IGetNimBoard
	{
		public Controller(IUserInterface iUserInterface)
		{
			m_Model = null;
			m_iUserInterface = iUserInterface;
		}

		// Operations
		public void NewGame()
		{
			if (m_Model!=null && !m_Model.IsGameOver)
			{
				m_iUserInterface.Ask
				(
					"Cancel the game in progress?",
					"Really Quit?",
					new AskDelegate(StartNewGame)
				);
			}
			else
			{
				StartNewGame(true);
			}
		}

		public void OnMove(int nRow, int nNbPegs)
		{
			if (m_Model.MakeMove(nRow, nNbPegs))
			{
				m_iUserInterface.OnBoardChanged();
				if (m_Model.IsGameOver)
				{
					m_iUserInterface.Message
						(
						"Keep contributing to DotGNU!",
						"Nice job!",
						new MessageDelegate(GameOver)
						);
				}
				else
				{
					MakeComputerMove();
					UpdateUI();
				}
			}
			else
			{
				m_iUserInterface.Error
				(
					"Illegal move. Try again.",
					"Illegal Move",
					new MessageDelegate(UpdateUI)
				);
			}
		}

		// IGetNimBoard overrides
		public NimBoard Board
		{
			get
			{
				if (m_Model == null)
					return null;

				int[] arnRows = new int[m_Model.NbRows];
				for (int i=0; i<m_Model.NbRows; ++i)
					arnRows[i] = m_Model.GetPegsInRow(i);

				return new NimBoard(arnRows);
			}
		}

		// private //
		private NimModel m_Model = null;
		private IUserInterface m_iUserInterface;

		private void MakeComputerMove()
		{
			if (m_Model.IsGameOver)
				return;

			int nRow, nNbPegs;
			m_Model.CalcBestMove(out nRow, out nNbPegs);

			string strPegs = nNbPegs==1 ? "peg" : "pegs";

			m_iUserInterface.Message
			(
				"I remove "+nNbPegs+" "+strPegs+" from row "+(nRow+1)+".",
				"My Move",
				new MessageDelegate(DoComputerMove)
			);
		}

		private void StartNewGame(bool bStart)
		{
			if (!bStart) return;

			m_Model = new NimModel(3);
			m_iUserInterface.InitBoard();

			m_iUserInterface.Ask
			(
				"Shall I move first?",
				"First Move",
				new AskDelegate(FirstMove)
			);
		}

		private void FirstMove(bool bComputerMovesFirst)
		{
			if (bComputerMovesFirst)
				MakeComputerMove();

			UpdateUI();
		}

		private void GameOver()
		{
			m_Model = null;
			UpdateUI();
		}

		private void UpdateUI()
		{
			m_iUserInterface.UpdateUI();
		}

		private void DoComputerMove()
		{
			int nRow, nNbPegs;
			m_Model.CalcBestMove(out nRow, out nNbPegs);
				// Here, we cheat and recalculate the best
				// move again since we are being forced to
				// do things asynchronously.

			m_Model.MakeMove(nRow, nNbPegs);
			m_iUserInterface.OnBoardChanged();

			if (m_Model.IsGameOver)
			{
				m_iUserInterface.Message
				(
					"I win. Maybe you should stick to coding.",
					"I win!",
					new MessageDelegate(GameOver)
				);
			}
		}
	}
}
