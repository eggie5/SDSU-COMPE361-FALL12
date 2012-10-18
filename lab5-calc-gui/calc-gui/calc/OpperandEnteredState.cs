using System;
 

namespace calc_gui
{
	public class OpperandEnteredState : CalcState
	{
		public static OpperandEnteredState Singleton = new OpperandEnteredState();

		public OpperandEnteredState ()
		{

		}

		#region implemented abstract members of CalcState

        public override void enterDigit(Calc calc, char c)
        {
            throw new NotImplementedException();
        }

		public override void addOpperand (Calc calc, Complex c)
		{
			calc.CurrentState=ErrorState.Singleton;
			throw new Exception("Cannot add opperand in opperand entered state");

		}

		public override void addOpperator (Calc calc, IBinOp op)
		{
			calc.pending_op=op;
			calc.CurrentState=OpperatorEntredState.Singleton;

		}

		public override void Calculate (Calc calc)
		{
			if (calc.pending_op != null) {

				Complex total = calc.pending_op.compute(calc.Total, Complex.Parse(calc.getDisplay()));
				//calc.Opperand1=total;
				calc.Total = total;


				calc.CurrentState = CompState.Singleton;
			} else {
				calc.CurrentState=ErrorState.Singleton;
//				throw new Exception("cannot do calculation w/o pending opperator");
			}
		}




		#endregion
	}
}

