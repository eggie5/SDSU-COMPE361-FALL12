using System;
using System.Numerics;

namespace lab2calculator
{
	class MainClass
	{
		class InvalidInputException : Exception
		{
			private String message;

			public String Message {
				get {
					return message;
				}
			}

			public InvalidInputException (string number_string)
			{
				this.message = number_string;
			}
		}

		class ClearException : Exception
		{
		}

		class ShowMenuException : Exception
		{
		}

		class QuitException : Exception
		{
		}

		static void PrintMenu ()
		{
			Console.WriteLine ("Complex Number Calculator");
			Console.WriteLine ("\t(c)\tClear\n\t(+)\tAdd\n\t(-)\tSubtract\n\t(*)\tMultiply" + "\n\t(/)\tDivide\n\t(m)\tMenu\n\t(q)\tQuit");
			Console.WriteLine ("Operation entry: c, +, -, *, /, m. or q");
			Console.WriteLine ("Operand entry: REAL IMAGINARY\n");
		}

		static void CatchMenuRequest (string number_string)
		{
			switch (number_string) {
			case "q":
				throw new QuitException ();
			case "m":
				throw new ShowMenuException ();
			case "c":
				throw new ClearException ();
			}
		}

		static Complex ConsoleReadComplexInput ()
		{

			String number_string = Console.ReadLine ();

			CatchMenuRequest (number_string);
		

			String[] ops1 = number_string.Split (' ');

			if (ops1.Length != 2) {
				//there is invalid input
				Console.WriteLine ("INVALID OPERAND ENTRY\nENTER AS FOLLOWS: REAL IMAGINARY");
				Console.Write ("Enter operand: ");

				throw new InvalidInputException (number_string);
			} else {
				return new Complex (Double.Parse (ops1 [0]), Double.Parse (ops1 [1]));
			}
		}

		static String ConsoleReadOperatorInput ()
		{
			String op_str = Console.ReadLine ().Trim ();
			CatchMenuRequest (op_str);

			if (op_str.Equals ("+") || op_str.Equals ("-") || op_str.Equals ("*") || op_str.Equals ("/")) {
				return op_str;
			} else {
				Console.WriteLine ("INVALID OPERATION ENTRY.\nENTER +, -, *, /, m or q");
				throw new ClearException (); //restart whole flow
			}
		}

		public static void Main (string[] args)
		{
			PrintMenu ();

			
			//get opperand1
			Console.Write ("Enter operand1: ");
			Complex opperand1;
			try {
				opperand1 = ConsoleReadComplexInput ();
			} catch (InvalidInputException) {
				opperand1 = ConsoleReadComplexInput ();
			}
			Complex result;

			while (true) {
				try {

					Console.WriteLine (String.Format ("opperand1: ({0}, {1})", opperand1.Real, opperand1.Imaginary));

					//get opperator
					Console.Write ("Enter operation: ");
					String opperator = ConsoleReadOperatorInput ();

					//get opperand2
					Console.Write ("Enter operand2: ");
					Complex opperand2;
					try {
						opperand2 = ConsoleReadComplexInput ();
					} catch (InvalidInputException) {
						opperand2 = ConsoleReadComplexInput (); //retry
					}
					Console.WriteLine (String.Format ("opperand2: ({0}, {1})", opperand2.Real, opperand2.Imaginary));

					//now do math
					
					switch (opperator) {
					case "+":
						result = opperand1 + opperand2;
						break;
					case "-":
						result = opperand1 - opperand2;
						break;
					case "*":
						result = opperand1 * opperand2;
						break;
					case "/":
						result = opperand1 / opperand2;
						break;
					default:
						throw new Exception ("Don't know how to handle that arithmatic with: " + opperator);
				
					}

					Console.WriteLine (String.Format ("({0}, {1}) {6} ({2}, {3}) = ({4}, {5})", 
				                                  opperand1.Real, opperand1.Imaginary,
				                                opperand2.Real, opperand2.Imaginary,
				                                result.Real, result.Imaginary, opperator));

					//setup next loop iteration
					opperand1 = result;

				}//end try

				catch (ClearException) {
					Console.Write ("Enter operand1: ");
					try {
						opperand1 = ConsoleReadComplexInput ();
					} catch (InvalidInputException) {
						opperand1 = ConsoleReadComplexInput ();
					}
				} catch (ShowMenuException) {
					PrintMenu ();
				} catch (QuitException) {
					Environment.Exit (0);
				}
				
			}//end while

		}
	}
}
