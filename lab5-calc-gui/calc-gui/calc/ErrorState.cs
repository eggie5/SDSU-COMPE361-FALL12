using System;

namespace calc_gui
{
	public class ErrorState : CalcState
	{
		public static ErrorState Singleton = new ErrorState();

		public ErrorState ()
		{

		}

		#region implemented abstract members of CalcState

		public override void addOpperand (Calc calc, Complex c)
		{
			calc.Opperand1=c;
			calc.CurrentState=OpperandEnteredState.Singleton;
		}

		public override void addOpperator (Calc calc, IBinOp op)
		{
			calc.pending_op=op;
			calc.CurrentState=OpperatorEntredState.Singleton;
		}

		public override void Calculate (Calc calc)
		{
			throw new NotImplementedException ();
		}


        public override void enterDigit(Calc calc, char c)
        {
            throw new NotImplementedException();
        }

		#endregion
	}
}

