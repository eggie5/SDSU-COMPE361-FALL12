using System;
 

namespace calc_gui
{
	public class Calc
	{
		private CalcState currentState;
		private IBinOp _pendingOp;
		private Complex total;

        //current display string
        private String _display;

		public Calc ()
		{
			Clear ();
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

			currentState = StartState.Singleton;
			//_pendingOp = _noOp;
		
			//        System.out.println("Clear All!");


		
		}

        public void setDisplay(String d)
        {
            _display = d;
        }

		public void compute ()
		{
			currentState.Calculate (this);
		}

        public String enterDigit(char c)
        {
            Console.WriteLine("Calc enter digit " + c + " : pre display " + _display);
            this.currentState.enterDigit(this, c);
            Console.WriteLine("Infix Calc enter digit: post display " + _display);
            return _display;
        }

		public Complex enterRectOperand (String input)
		{
			String [] parts = input.Trim ().Split ();
			if (parts.Length ==0 || parts.Length>2) {
				currentState = ErrorState.Singleton;
				return null;
			}
            else if (parts.Length == 1)
            {
                Complex c = new Complex(Double.Parse(parts[0]), 0);
                currentState.addOpperand(this, c);
                return c;
            }
            else
            {
                Complex c = new Complex(Double.Parse(parts[0]), Double.Parse(parts[1]));
                currentState.addOpperand(this, c);
                return c;
            }
		}


        public Complex enterRectOperand(Complex input)
        {
         
                
                currentState.addOpperand(this, input);
                return input;
            
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

        public Complex enterPolarOperand(Complex c)
        {
                currentState.addOpperand(this, c);
                return c;
            
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

        public String enterEqual()
        {
            currentState.Calculate(this);
            Console.WriteLine("Calc enter equal: post display " + _display);
            return _display;

        }

        public String getDisplay()
        {
            return _display;
        }
    }
}

