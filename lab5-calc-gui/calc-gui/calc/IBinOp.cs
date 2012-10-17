using System;

namespace calc_gui
{
	public interface  IBinOp
	{
		  Complex compute(Complex n1, Complex n2);
		  string ToString();
	}



}

