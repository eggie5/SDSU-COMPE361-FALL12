using System;
using ComplexNumbers;

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
			Clear ();
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

		public void Clear ()
		{
		
			total = new Complex (0, 0);
			opperand1 = new Complex (0, 0);
			opperand2 = new Complex (0, 0);
			currentState = StartState.Singleton;
			//_pendingOp = _noOp;
		
			//        System.out.println("Clear All!");


		
		}

		public void compute ()
		{
			currentState.Calculate (this);
		}

		public Complex enterRectOperand (String input)
		{
			String [] parts = input.Trim ().Split ();
			if (parts.Length != 2) {
				currentState = ErrorState.Singleton;
				return null;
			} else {
				Complex c = new Complex (Double.Parse (parts [0]), Double.Parse (parts [1]));
				currentState.addOpperand (this, c);
				return c;
			}
		}

		public Complex enterPolarOperand (string input)
		{
			String [] parts = input.Trim ().Split ();
			if (parts.Length != 2) {
				currentState = ErrorState.Singleton;
				return null;
			} else {
				//need to convert these to rectangle or add a new constrctor
				//that takes polar as input
				Complex c = new Complex (0, Double.Parse (parts [0]), Double.Parse (parts [1]));
				currentState.addOpperand (this, c);
				return c;
			}
		}

		public void enterOp (String input_string)
		{

			IBinOp opp;
			switch (input_string) {
			case "+":
				opp = new Opperations.AddOp ();
				break;
			case "-":
				opp = new Opperations.SubOp ();
				break;
			case "*":
				opp = new Opperations.MultiplyOp ();
				break;
			case "/":
				opp = new Opperations.DivideOp ();
				break;
			default:
				//throw new Exception ("Don't know how to handle that arithmatic with: " + opperator);
				this.CurrentState = ErrorState.Singleton;
				opp = null;
				break;
				
			}

			if (opp == null) {

			} else {
				currentState.addOpperator (this, opp);
			}
		}

		public void enterEqual ()
		{
			currentState.Calculate (this);

		}
	}
}

