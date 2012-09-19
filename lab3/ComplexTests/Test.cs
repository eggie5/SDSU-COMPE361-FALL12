using System;
using NUnit.Framework;
using ComplexNumbers;

namespace ComplexTests
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void TestAdd ()
		{
			Complex c1 = new Complex(3,4);
			Complex c2 = new Complex(1,2);

			Complex actual= c1+c2;

			Assert.AreEqual(new Complex(4,6).ToString(), actual.ToString());

		
		}

		[Test()]
		public void TestSub ()
		{
			Complex c1 = new Complex(3,4);
			Complex c2 = new Complex(1,2);
			
			Complex actual= c1-c2;
			
			Assert.AreEqual(new Complex(2,2).ToString(), actual.ToString());
			
			
		}

		[Test()]
		public void TestMultiplicaion ()
		{

			Complex c1 = new Complex(2,1);
			Complex c2 = new Complex(1,3);
			
			Complex actual= c1*c2;
			
			Assert.AreEqual(new Complex(-1,7).ToString(), actual.ToString());


			c1 = new Complex(3,4);
			c2 = new Complex(1,2);
			
			actual= c1*c2;
			
			Assert.AreEqual(new Complex(-5,10).ToString(), actual.ToString());

			c1 = new Complex(-3,4);
			c2 = new Complex(1,2);
			
			actual= c1*c2;
			
			Assert.AreEqual(new Complex(-11,-2).ToString(), actual.ToString());
		}

		[Test()]
		public void TestDivision ()
		{
			
			Complex c1 = new Complex(-3,4);
			Complex c2 = new Complex(1,2);
			
			Complex actual= c1/c2;
			
			Assert.AreEqual(new Complex(1,2).ToString(), actual.ToString());
			
			
			c1 = new Complex(8,4);
			c2 = new Complex(2,2);
			
			actual= c1/c2;
			
			Assert.AreEqual(new Complex(3,-1).ToString(), actual.ToString());
			
			c1 = new Complex(32,4);
			c2 = new Complex(2,2);
			
			actual= c1/c2;
			
			Assert.AreEqual(new Complex(9,-7).ToString(), actual.ToString());
		}
	}
}

