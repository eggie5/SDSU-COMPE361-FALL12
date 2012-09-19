using System;
using System.Numerics;

namespace lab2calculatorstate_machine
{
	public class Calc
	{
		private CalcState currentState; 

		private IBinOp _pendingOp; 
		private Complex total;
		private Complex opperand1;
		private Complex opperand2;


		public Calc ()
		{
			Clear();
		}


		public Complex Opperand1 {
			get{ return opperand1;}
			set{ opperand1 = value;}

		}
		public Complex Opperand2 {
			get{ return opperand2;}
			set{ opperand2 = value;}
			
		}
		public Complex Total {
			get{ return total;}
			set{ total = value;}
			
		}
		public CalcState CurrentState {
			get {
				return currentState;
			}
			set {
				currentState = value;
			}
		}



		public IBinOp pending_op {
			get {
				return _pendingOp;
			}
			set {
				_pendingOp = value;
			}
		}

		public void Clear() {
		
			total=0;
			currentState = StartState.Singleton;
			//_pendingOp = _noOp;
		
			//        System.out.println("Clear All!");


		
		}

		public void compute ()
		{
			currentState.Calculate(this);
			//Console.WriteLine("({0}) + {1}) = {3}", opperand1.ToString (), opperand2.ToString(), total.ToString());
		}

		public void EnterOperand (String input)
		{
			String [] parts = input.Trim().Split ();
			if (parts.Length != 2) {
				currentState = ErrorState.Singleton;
				//throw new Exception("Could not parse this input");
			} else {
				Complex c = new Complex (Double.Parse (parts [0]), Double.Parse (parts [1]));
				currentState.addOpperand (this, c);
			}
		}


		public void enterOp(IBinOp op) {
			currentState.addOpperator(this, op);
		}

		public void enterEqual() {
			currentState.Calculate(this);

		}
	}
}

