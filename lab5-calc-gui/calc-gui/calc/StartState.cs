using System;
namespace calc_gui
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

			//calc.Total=new Complex(0,0);
			calc.setDisplay(c.ToString());
			calc.CurrentState = OpperandEnteredState.Singleton;

		}

		public override void addOpperator (Calc calc, IBinOp op)
		{
	

			calc.CurrentState = ErrorState.Singleton;
			//throw new Exception ("cannot add opperator when an opperand has not been entered yet!");
		
		}

		public override void Calculate (Calc calc)
		{

			calc.CurrentState = (ErrorState.Singleton);
			throw new Exception ("cannot do calculation when no expressions have been entered --- in the start state");

		}


        public override void enterDigit(Calc calc, char c)
        {
            Console.WriteLine("Start State: enter character " + c);
            calc.setDisplay("" + c);
            if ('0' != c)
            {
                calc.CurrentState = AccumState.Singleton;
            }
        }
		#endregion
	}
}

