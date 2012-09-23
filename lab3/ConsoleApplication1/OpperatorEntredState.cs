using System;
using ComplexNumbers;

namespace lab2calculatorstate_machine
{
	public class OpperatorEntredState: CalcState
	{
		public static OpperatorEntredState Singleton = new OpperatorEntredState();


		public OpperatorEntredState ()
		{
		}

		#region implemented abstract members of CalcState

		public override void addOpperand (Calc calc, Complex c)
		{
			calc.Opperand1=calc.Total;
			calc.Opperand2=c;

//			Complex result = calc.pending_op.compute(calc.Total, calc.Opperand2);
//			calc.Total=result;
//			calc.Opperand1=result;

			//why did I do this???
			//calc.pending_op=null;

			calc.CurrentState=OpperandEnteredState.Singleton;
			//calc.CurrentState=CompState.Singleton;
		}

		public override void addOpperator (Calc calc, IBinOp op)
		{
			calc.CurrentState=ErrorState.Singleton;
			throw new Exception("cant add opperator in opperator entered state");
		}

		public override void Calculate (Calc calc)
		{
			Complex total = calc.pending_op.compute(calc.Opperand1, calc.Opperand2);
			calc.Opperand1=total;
			calc.Total = total;
			calc.CurrentState = CompState.Singleton;
			//calc.CurrentState=ErrorState.Singleton;
			//throw new Exception("you cant do a calculation right after you add an opperator, need another opperand");
		}

	

		#endregion
	}
}

