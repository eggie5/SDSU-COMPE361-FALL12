using System;


namespace lab7_calc
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

			public override string ToString ()
			{
				return "+";
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

			public override string ToString ()
			{
				return "-";
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

			public override string ToString ()
			{
				return "*";
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

			public override string ToString ()
			{
				return "/";
			}
			
#endregion
		}
	}
}

