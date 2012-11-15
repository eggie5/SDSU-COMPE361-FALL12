using System;

namespace lab7_calc
{
	public interface  IBinOp
	{
		  Complex compute(Complex n1, Complex n2);
		  string ToString();
	}



}

