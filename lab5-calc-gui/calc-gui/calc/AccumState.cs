﻿using System;


namespace calc_gui
{
    public class AccumState : CalcState
    {
        public static AccumState Singleton = new AccumState();

        public AccumState()
        {

        }

        #region implemented abstract members of CalcState

        public override void enterDigit(Calc calc, char c)
        {
            Console.WriteLine("Accumulate State: enter character " + c);
            calc.setDisplay(calc.getDisplay() + c);
            calc.CurrentState = AccumState.Singleton;
        }

        public override void addOpperand(Calc calc, Complex c)
        {
            //calc.CurrentState = ErrorState.Singleton;
            //throw new Exception("Cannot add opperand in opperand entered state");
            calc.setDisplay(c.ToString());
            calc.CurrentState = OpperandEnteredState.Singleton;

        }

        public override void addOpperator(Calc calc, IBinOp op)
        {
			calc.Total=Complex.Parse(calc.getDisplay());
            calc.pending_op = op;
            calc.setDisplay("");
            calc.CurrentState = OpperatorEntredState.Singleton;

            

        }

        public override void Calculate(Calc calc)
        {
            if (calc.pending_op != null)
            {
				Complex opperand=Complex.Parse(calc.getDisplay());

                Complex total = calc.pending_op.compute(calc.Total, opperand);
                //calc.Opperand1=total;
                calc.Total = total;
                calc.setDisplay(total.ToString());

                calc.CurrentState = CompState.Singleton;
            }
            else
            {
                calc.CurrentState = ErrorState.Singleton;
                //				throw new Exception("cannot do calculation w/o pending opperator");
            }
        }




        #endregion
    }
}

