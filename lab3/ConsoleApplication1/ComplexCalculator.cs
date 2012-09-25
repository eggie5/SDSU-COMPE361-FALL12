using System;
using lab2calculatorstate_machine;

namespace ComplexNumbers
{
	public class ComplexCalculator
	{
		public ComplexCalculator ()
		{
		}

		private static Calc calc;

		public static void runCalculator ()
		{
			calc = new Calc ();
			
			
			PrintMenu ();
			bootstrap (calc);
			
			while (true) {
				try {
					ConsoleReadOperator (calc);
					ConsoleReadOperand (calc);
					Compute (calc);
				} catch (ClearException) {
					calc.Clear ();
					bootstrap (calc);
				}
			}//end while
			
			

		}

		static void ShowEditMagnitude ()
		{
			Console.Write ("{0}: ", calc.Total.Magnitude);
			String input = Console.ReadLine ();
			double new_mag = Double.Parse (input);
			calc.Total.Magnitude = new_mag;

		}

		static void ShowEditAngle ()
		{
			Console.Write ("{0}: ", calc.Total.Angle);
			String input = Console.ReadLine ();
			double new_angle = Double.Parse (input);
			calc.Total.Angle = new_angle;
			
		}

		static void ShowEditReal ()
		{
			Console.Write ("{0}: ", calc.Total.new_real);
			String input = Console.ReadLine ();
			double new_angle = Double.Parse (input);
			calc.Total.new_real = new_angle;
			
		}

		static void ShowEditImag ()
		{
			Console.Write ("{0}: ", calc.Total.Imag);
			String input = Console.ReadLine ();
			double new_imag = Double.Parse (input);
			calc.Total.Imag = new_imag;
			
		}

		static void PrintMenu ()
		{
			Console.WriteLine ("Complex Number Calculator");
			Console.WriteLine ("\t(c)\tClear\n\t(+)\tAdd\n\t(-)\tSubtract\n\t(*)\tMultiply" + 
				"\n\t(/)\tDivide\n\t(p)\tPolar\n\t(r)\tRectanular\n\t(m)\tMenu\n" +
				"\t(q)\tQuit\n\t(M)\tMagnitude\n\t(A)\tAngle\n\t(R)\tReal\n\t(I)\tImaginary\n");
			Console.WriteLine ("Operation entry: c, +, -, *, /, m. or q");
			Console.WriteLine ("Operand entry: REAL IMAGINARY\n");
		}
		
		static void bootstrap (Calc calc)
		{
			ConsoleReadOperand (calc); //initial
			calc.enterOp ("+");
			calc.compute ();
		}
		
		static void Compute (Calc calc)
		{
			calc.compute ();
			if (calc.CurrentState is CompState) {
				Console.WriteLine ("({0}) {1} ({2}) = {3}", calc.Opperand1.ToString (), calc.pending_op.ToString (), calc.Opperand2.ToString (), calc.Total.ToString ());
			}
		}
		
		static Boolean HandleMenuInterupt (string input)
		{
			switch (input) {
			case "q":
				//throw new QuitException ();
				Environment.Exit (1);
				break;
			case "m":
				//throw new ShowMenuException ();
				PrintMenu ();
				break;
			case "c":
				throw new ClearException ();
			case "p":
				Complex.mode = ComplexNumbers.MODE.Polar;
				Console.WriteLine ("Calc set to polar mode");
				break;
			case "r":
				Complex.mode = ComplexNumbers.MODE.Rectangular;
				Console.WriteLine ("Calc set to rectagular mode");
				break;
			case "M":
				ShowEditMagnitude ();
				break;
			case "A":
				ShowEditAngle ();
				break;
			case "R":
				ShowEditReal ();
				break;
			case "I":
				ShowEditImag ();
				break;
			default:
				return false;

				
			}
			return true;
		}
		
		static void ConsoleReadOperator (Calc calc)
		{
			while (!(calc.CurrentState is OpperatorEntredState)) {
				Console.Write ("Operation: ");
				String opperator = Console.ReadLine ();
				if (HandleMenuInterupt (opperator)) {
					continue; //restart while?
				}
				calc.enterOp (opperator);
				if (calc.CurrentState is ErrorState) {
					Console.WriteLine ("ERROR! Enter an operation.");
					Console.WriteLine ("Options are: c, +, -, *, /, p, r, m, q, M, A, R, I");
				}
			}
			
		}
		
		static void ConsoleReadOperand (Calc calc)
		{
			Complex new_opp=null;
			//get rid of duplicate code!!!!
			switch (Complex.mode) {
			case ComplexNumbers.MODE.Polar:
				while (!(calc.CurrentState is OpperandEnteredState)) {
					Console.WriteLine ("Enter operand: ");
					Console.Write("\tmagnitude: ");
					String magnitude = Console.ReadLine ().Trim();
					
					Console.Write("\tangle: ");
					String angle=Console.ReadLine().Trim();
					
					String opp_str=String.Format("{0} {1}", magnitude, angle);
					new_opp=calc.enterPolarOperand (opp_str);
					
					if (calc.CurrentState is ErrorState) {
						Console.WriteLine ("There was an input error");
					}
				}
				break;
			case ComplexNumbers.MODE.Rectangular:
				while (!(calc.CurrentState is OpperandEnteredState)) {
					Console.WriteLine ("Enter operand: ");
					Console.Write("\treal part: ");
					String real = Console.ReadLine ().Trim();
					
					Console.Write("\timaginary part: ");
					String imag=Console.ReadLine().Trim();
					
					String opp_str=String.Format("{0} {1}", real, imag);
					new_opp=calc.enterRectOperand (opp_str);
					
					if (calc.CurrentState is ErrorState) {
						Console.WriteLine ("There was an input error");
					}
				}
				break;
			}



			//			if(new_opp!=null)
			//				Console.WriteLine("operand: {0}", new_opp);
		}
	}
}

