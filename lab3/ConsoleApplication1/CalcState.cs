using System;
using ComplexNumbers;

namespace lab2calculatorstate_machine
{
	public abstract class CalcState
	{
		public CalcState ()
		{
		}

		public abstract void addOpperand(Calc calc, Complex c);
	
		public abstract void addOpperator(Calc calc, IBinOp op);

		public abstract void Calculate(Calc calc);
	
	}
}

