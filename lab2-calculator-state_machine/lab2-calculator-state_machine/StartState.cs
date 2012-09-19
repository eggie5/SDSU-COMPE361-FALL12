using System;
using System.Numerics;

namespace lab2calculatorstate_machine
{
	public class StartState : CalcState
	{
		public StartState ()
		{
		
		}

		public static StartState Singleton = new StartState();

		#region implemented abstract members of CalcState

		public override void addOpperand (Calc calc, Complex c)
		{

			calc.Total=c;
			calc.Opperand1 = c;
			calc.CurrentState = OpperandEnteredState.Singleton;

		}

		public override void addOpperator (Calc calc, IBinOp op)
		{
	

			calc.CurrentState = ErrorState.Singleton;
			throw new Exception ("cannot add opperator when an opperand has not been entered yet!");
		
		}

		public override void Calculate (Calc calc)
		{

			calc.CurrentState = (ErrorState.Singleton);
			throw new Exception ("cannot do calculation when no expressions have been entered --- in the start state");

		}



		#endregion
	}
}

