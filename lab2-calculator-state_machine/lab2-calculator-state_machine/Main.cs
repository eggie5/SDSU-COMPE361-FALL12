using System;
using System.Numerics;

namespace lab2calculatorstate_machine
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Calc calc = new Calc ();

			//initial conditions
			Console.WriteLine("state = "+calc.CurrentState);
			QueryUserForInput (calc);


			while (true) {

				Console.WriteLine ("Enter operator (+ - * /): ");
				Console.ReadLine ();
				calc.enterOp (new Opperations.AddOp ());

				//get op2
				QueryUserForInput (calc);
		
				calc.compute();
				if (calc.CurrentState.GetType () == CompState.Singleton.GetType ()) {
					Console.WriteLine ("({0}) + ({1}) = {2}", calc.Opperand1.ToString (), calc.Opperand2.ToString (), calc.Total.ToString ());
				}
			}//end while



		}

		static void QueryUserForInput (Calc calc)
		{
			while (calc.CurrentState.GetType () != OpperandEnteredState.Singleton.GetType ()) {
				Console.WriteLine ("Enter Operand: ");
				calc.EnterOperand (Console.ReadLine ());
				if (calc.CurrentState.GetType ().Equals (ErrorState.Singleton.GetType ())) {
					Console.WriteLine ("There was an input error");
				}
			}
		}
	}
}
