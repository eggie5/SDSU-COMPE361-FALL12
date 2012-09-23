using System;

namespace lab2calculatorstate_machine
{
	public class CompState :CalcState
	{
		public static CompState Singleton = new CompState();

		public CompState ()
		{

		}

		#region implemented abstract members of CalcState

		public override void addOpperand (Calc calc, System.Numerics.Complex c)
		{
			calc.Opperand1=calc.Total;
			calc.Opperand2=c;
			calc.CurrentState=OpperandEnteredState.Singleton;
			
		}

		public override void addOpperator (Calc calc, IBinOp op)
		{
			calc.Opperand1=calc.Total;
			calc.pending_op=op;
			calc.CurrentState=OpperatorEntredState.Singleton;
		}

		public override void Calculate (Calc calc)
		{
			//calc.CurrentState=ErrorState.Singleton;
			//throw new Exception("called calculate in compute state????");
			//just redo the calc just finished
			calc.Total=calc.pending_op.compute(calc.Opperand1, calc.Opperand2);
			calc.CurrentState=CompState.Singleton;
		}

		#endregion
	}
}

