

using System;

using com.eggie5.nim.dataxfer;
using com.eggie5.nim.model;

namespace com.eggie5.nim.controller
{

	public class Controller : IGetNimBoard
	{
		public Controller(IUserInterface iUserInterface)
		{
			m_Model = null;
			m_iUserInterface = iUserInterface;
		}

        private int max_rows = 5;

		// Operations
		public void NewGame(int rows)
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
                max_rows = rows;
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
					m_iUserInterface.MessageBoxShow
						(
						"Good Job!",
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

				int[] arnRows = new int[m_Model.RowCount];
				for (int i=0; i<m_Model.RowCount; ++i)
					arnRows[i] = m_Model.GetPegsInRow(i);

				return new NimBoard(arnRows);
			}
		}

		private NimModel m_Model = null;
		private IUserInterface m_iUserInterface;

		private void MakeComputerMove()
		{
			if (m_Model.IsGameOver)
				return;

			int nRow, nNbPegs;
			m_Model.CalcBestMove(out nRow, out nNbPegs);

			string strPegs = nNbPegs==1 ? "peg" : "pegs";

			m_iUserInterface.MessageBoxShow
			(
				"I remove "+nNbPegs+" "+strPegs+" from row "+(nRow+1)+".",
				"My Move",
				new MessageDelegate(DoComputerMove)
			);
		}

		private void StartNewGame(bool bStart)
		{
			if (!bStart) return;

            Random r = new Random(DateTime.Now.Millisecond);
            int rows = r.Next(3, max_rows+1); // spec is between 3 and max
			m_Model = new NimModel(rows); //num of rows. If I change to 4 the paint code in control breaks :(
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
			

			m_Model.MakeMove(nRow, nNbPegs);
			m_iUserInterface.OnBoardChanged();

			if (m_Model.IsGameOver)
			{
				m_iUserInterface.MessageBoxShow
				(
					"I win. You loose, now give me an A+",
					"I win!",
					new MessageDelegate(GameOver)
				);
			}
		}
	}
}
