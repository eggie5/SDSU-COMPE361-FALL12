using System;

namespace calc_gui
{
	public class CompState :CalcState
	{
		public static CompState Singleton = new CompState();

		public CompState ()
		{

		}

		#region implemented abstract members of CalcState

		public override void addOpperand (Calc calc,Complex c)
		{
			//calc.Opperand1=calc.Total;
			//calc.Opperand2=c;
			calc.Total=c;
			calc.CurrentState=OpperandEnteredState.Singleton;
			
		}

		public override void addOpperator (Calc calc, IBinOp op)
		{
			//calc.Opperand1=calc.Total;
			calc.pending_op=op;
			calc.CurrentState=OpperatorEntredState.Singleton;
		}

		public override void Calculate (Calc calc)
		{
			//calc.CurrentState=ErrorState.Singleton;
			//throw new Exception("called calculate in compute state????");
			//just redo the calc just finished
//			calc.Total=calc.pending_op.compute(calc.Opperand1, calc.Opperand2);
//            calc.setDisplay(calc.Total.ToString());
//			calc.CurrentState=CompState.Singleton;
			calc.setDisplay("Syntax Error!");
			calc.CurrentState=ErrorState.Singleton;
		}

        public override void enterDigit(Calc calc, char c)
        {
			//Complex c=Complex.Parse(calc.getDisplay());
			throw new NotImplementedException();
        }

		#endregion
	}
}
