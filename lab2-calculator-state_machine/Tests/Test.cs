using System;
using NUnit.Framework;
using lab2calculatorstate_machine;
using System.Numerics;

namespace Tests
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void TestCase ()
		{
			Calc c=new Calc();
			Assert.True(c.CurrentState is StartState);
			c.enterOperand("3 4");
			Assert.True(c.CurrentState is OpperandEnteredState);
			Assert.AreEqual(c.Total, new Complex(0,0));
			Assert.AreEqual(new Complex(3,4), c.Opperand2);

			//should fail b/c there's no operator to use!
			c.compute();
			Assert.IsTrue(c.CurrentState is ErrorState);

			//add operator
			c.enterOp("+");
			c.compute();
			Complex answer=new Complex(3,4);
			Assert.IsTrue(c.CurrentState is CompState);
			Assert.AreEqual(answer, c.Total);
			Assert.AreEqual(answer, c.Opperand1);

			//now let's subtract and check if we get 0+0i
			c.enterOperand("3 4");
			c.enterOp("-");
			c.compute();
			answer=new Complex(0,0);
			Assert.IsTrue(c.CurrentState is CompState);
			Assert.AreEqual(answer, c.Total);
			Assert.AreEqual(answer, c.Opperand1);

			//now lets add 5-6i
			Complex old_lhs=c.Opperand1;
			c.enterOp("+");
			Assert.IsTrue(c.CurrentState is OpperatorEntredState);
			c.enterOperand("5 -6");
			Assert.AreEqual(new Complex(5,-6), c.Opperand2);
			c.compute();
			answer=new Complex(5,-6);
			Assert.IsTrue(c.CurrentState is CompState);
			Assert.AreEqual(answer.ToString(), c.Total.ToString());
			Assert.AreEqual(old_lhs.ToString(), c.Opperand1.ToString());

			//test multplication (5-6i) * (2+3i) = (28+3i)
			c.enterOp("*");
			Assert.AreEqual(c.Total.ToString(), c.Opperand1.ToString());
			c.enterOperand("2 3");
			c.compute();
			answer=new Complex(28,3);
			Assert.IsTrue(c.CurrentState is CompState);
			Assert.AreEqual(answer.ToString(), c.Total.ToString());

			//test division (28+3i) / (3-2i)=(6+5i)
			c.enterOp("/");
			c.enterOperand("3 -2");
			c.compute();
			answer=new Complex(6,5);
			Assert.IsTrue(c.CurrentState is CompState);
			Assert.AreEqual(answer.ToString(), c.Total.ToString());

			//test error handling
			Complex opp1=c.Opperand1;
			Complex opp2=c.Opperand2;
			c.enterOperand("3");
			Assert.IsTrue(c.CurrentState is ErrorState);
			//ensure no opperands are changed
			Assert.AreEqual(opp1, c.Opperand1);
			Assert.AreEqual(opp2, c.Opperand2);
			Assert.AreEqual(answer.ToString(), c.Total.ToString()); //ensure previous sum remains

			//enter bad input again!
			c.enterOperand("3 3 3 3 3");
			Assert.IsTrue(c.CurrentState is ErrorState);
			//ensure no opperands are changed
			Assert.AreEqual(opp1, c.Opperand1);
			Assert.AreEqual(opp2, c.Opperand2);
			Assert.AreEqual(answer.ToString(), c.Total.ToString()); //ensure previous sum remains

			//test bad operatOR inputs
			IBinOp old_op=c.pending_op;
			c.enterOp("a");
			Assert.IsTrue(c.CurrentState is ErrorState);
			//ensure no opperands are changed
			Assert.AreEqual(opp1, c.Opperand1);
			Assert.AreEqual(opp2, c.Opperand2);
			Assert.AreEqual(old_op, c.pending_op);
			Assert.AreEqual(answer.ToString(), c.Total.ToString()); //ensure previous sum remains

			//check that op1 and op2 and opp are same from before errors started
			Assert.AreEqual(opp1, c.Opperand1);
			Assert.AreEqual(opp2, c.Opperand2);
			Assert.AreEqual(old_op, c.pending_op);

			c.enterOp("+");
			c.enterOperand("6 6");
			c.compute();
			answer=new Complex(12,11);
			Assert.IsTrue(c.CurrentState is CompState);
			Assert.AreEqual(answer.ToString(), c.Total.ToString());


			//reset calc
			c.Clear();
			Assert.IsTrue(c.CurrentState is StartState);
			Assert.AreEqual(new Complex(0,0), c.Opperand1);
			Assert.AreEqual(new Complex(0,0), c.Opperand2);

			//initialize for console calc
			c.enterOperand("3 4");
			c.enterOp("+");
			c.compute();
			//now it's ready for the while loop

			c.enterOperand("1 2");
			c.compute();
			Assert.IsTrue(c.CurrentState is CompState);
			Assert.AreEqual(new Complex(4,6), c.Total);





			

		}
	}
}

