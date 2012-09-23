using System;
using ComplexNumbers;

namespace lab2calculatorstate_machine
{
	public interface  IBinOp
	{
		  Complex compute(Complex n1, Complex n2);
		  string ToString();
	}



}

