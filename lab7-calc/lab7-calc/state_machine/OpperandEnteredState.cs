using System;


namespace lab7_calc
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
			//just replace current w/ this
            calc.setDisplay(c.ToString());


            calc.CurrentState = OpperandEnteredState.Singleton;

		}

		public override void addOpperator (Calc calc, IBinOp op)
		{
            calc.Total = Complex.Parse(calc.getDisplay());
			calc.pending_op=op;
			calc.CurrentState=OpperatorEntredState.Singleton;

		}

		public override void Calculate (Calc calc)
		{
			if (calc.pending_op != null) {
                Complex opperand = Complex.Parse(calc.getDisplay());

				Complex total = calc.pending_op.compute(calc.Total, opperand);
				//calc.Opperand1=total;
				calc.Total = total;
                calc.setDisplay(total.ToString());


				calc.CurrentState = CompState.Singleton;
			} else {
				calc.CurrentState=ErrorState.Singleton;
//				throw new Exception("cannot do calculation w/o pending opperator");
			}

		}




		#endregion
	}
}

