using System;
using System.Numerics;

namespace lab2calculatorstate_machine
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Calc calc = new Calc ();
			System.Threading.Thread.Sleep(1000);

			while (true) {
				Console.WriteLine("loop start -----------");
				Console.WriteLine("state = "+calc.CurrentState);
				QueryUserForInput (calc);
				Console.WriteLine("state = "+calc.CurrentState);

				Console.WriteLine ("Enter operator (+ - * /): ");
				Console.ReadLine ();
				calc.enterOp (new Opperations.AddOp ());
				Console.WriteLine("state = "+calc.CurrentState);

				//get op2
				QueryUserForInput (calc);
				Console.WriteLine("state = "+calc.CurrentState);



				calc.compute();
				if (calc.CurrentState.GetType () == CompState.Singleton.GetType ()) {
					Console.WriteLine ("({0}) + ({1}) = {2}", calc.Opperand1.ToString (), calc.Opperand2.ToString (), calc.Total.ToString ());
				}
				Console.WriteLine("state = "+calc.CurrentState);

			}



		}

		static void QueryUserForInput (Calc calc)
		{
			while (calc.CurrentState.GetType () != OpperandEnteredState.Singleton.GetType ()) {
				Console.WriteLine ("Enter Operand1: ");
				calc.EnterOperand (Console.ReadLine ());
				if (calc.CurrentState.GetType ().Equals (ErrorState.Singleton.GetType ())) {
					Console.WriteLine ("There was an input error");
				}
			}
		}
	}
}
