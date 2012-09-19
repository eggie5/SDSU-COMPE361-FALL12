using System;
using System.Numerics;

namespace lab2calculatorstate_machine
{
	public class Opperations
	{
		public class AddOp : IBinOp
		{
			public AddOp ()
			{
			}
			
			#region IBinOp implementation
			
			public Complex compute (Complex n1, Complex n2)
			{
				return n1 + n2;
			}
			
#endregion
		}

		public class SubOp : IBinOp
		{
			public SubOp ()
			{
			}
			
			#region IBinOp implementation
			
			public Complex compute (Complex n1, Complex n2)
			{
				return n1 - n2;
			}
			
#endregion
		}

		public class MultiplyOp : IBinOp
		{
			public MultiplyOp ()
			{
			}
			
			#region IBinOp implementation
			
			public Complex compute (Complex n1, Complex n2)
			{
				return n1 * n2;
			}
			
#endregion
		}

		public class DivideOp : IBinOp
		{
			public DivideOp ()
			{
			}
			
			#region IBinOp implementation
			
			public Complex compute (Complex n1, Complex n2)
			{
				return n1 / n2;
			}
			
#endregion
		}
	}
}

