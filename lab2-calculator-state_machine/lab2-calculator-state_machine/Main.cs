using System;
using System.Numerics;

namespace lab2calculatorstate_machine
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Calc calc = new Calc ();
	
			PrintMenu ();
			bootstrap (calc);

			while (true) {
				try {
					ConsoleReadOperator (calc);
					ConsoleReadOperand (calc);
					Compute (calc);
				} catch (ClearException) {
					calc.Clear();
					bootstrap(calc);
				}
			}//end while



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

		static void HandleMenuInterupt (string input)
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
				//set polar here
				break;

			}
		}

		static void ConsoleReadOperator (Calc calc)
		{
			while (!(calc.CurrentState is OpperatorEntredState)) {
				Console.Write ("Enter operator (+ - * /): ");
				String opperator = Console.ReadLine ();
				HandleMenuInterupt (opperator);
				calc.enterOp (opperator);
			}
		
		}

		static void ConsoleReadOperand (Calc calc)
		{
			while (!(calc.CurrentState is OpperandEnteredState)) {
				Console.Write ("Enter Operand: ");
				String input = Console.ReadLine ();
				HandleMenuInterupt (input);
				calc.enterOperand (input);
				if (calc.CurrentState is ErrorState) {
					Console.WriteLine ("There was an input error");
				}
			}
		}
	}
}
