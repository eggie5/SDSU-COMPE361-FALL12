using System;
using System.Numerics;

namespace lab2calculator
{
	class MainClass
	{
		static void PrintMenu ()
		{
			Console.WriteLine ("Complex Number Calculator");
			Console.WriteLine ("\t(c)\tClear\n\t(+)\tAdd\n\t(-)\tSubtract\n\t(*)\tMultiply" + "\n\t(/)\tDivide\n\t(m)\tMenu\n\t(q)\tQuit");
		}

		static Complex ParseComplexInput (string number_string)
		{
			String[] ops1 = number_string.Split (new char[] {
				' '
			});

			return new Complex (Double.Parse (ops1 [0]), Double.Parse (ops1 [1]));
		}
		public static void Main (string[] args)
		{
			PrintMenu ();
			while (true) {
				Console.WriteLine ("Operation entry: c, +, -, *, /, m. or q");
				Console.WriteLine ("Operand entry: REAL IMAGINARY\n");

				//get opperand1
				Console.Write ("Enter operand1: ");
				String cmplx_input_string = Console.ReadLine ();
				Complex opperand1 = ParseComplexInput (cmplx_input_string);
				Console.WriteLine (String.Format ("opperand1: ({0}, {1})", opperand1.Real, opperand1.Imaginary));

				//get opperator
				Console.Write ("Enter operation: ");
				String op_str = Console.ReadLine ();

				//get opperand2
				Console.Write ("Enter operand2: ");
				cmplx_input_string = Console.ReadLine ();
				Complex opperand2 = ParseComplexInput(cmplx_input_string);
				Console.WriteLine (String.Format ("opperand2: ({0}, {1})", opperand2.Real, opperand2.Imaginary));

				//now do math
				Complex result;
				switch (op_str) {
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
					throw new Exception("Don't know how to handle that arithmatic with: "+op_str);
				
				}

				Console.WriteLine (String.Format ("({0}, {1}) + ({2}, {3}) = ({4}, {5})", opperand1.Real, opperand1.Imaginary,
				                                opperand2.Real, opperand2.Imaginary,
				                                result.Real, result.Imaginary)
				);


			}

		}
	}
}
