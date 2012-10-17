using System;
 


namespace calc_gui
{
	public abstract class CalcState
	{
		public CalcState ()
		{
		}

		public abstract void addOpperand(Calc calc, Complex c);
	
		public abstract void addOpperator(Calc calc, IBinOp op);

		public abstract void Calculate(Calc calc);

        public abstract void enterDigit(Calc calc, char c);
	
	}
}

