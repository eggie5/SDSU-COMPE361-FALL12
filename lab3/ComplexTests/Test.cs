using System;
using NUnit.Framework;
using ComplexNumbers;

namespace ComplexTests
{
	[TestFixture()]
	public class Test
	{

		[Test()]
		public void TestMagnitude ()
		{
			Complex c1 = new Complex(3,4);

			double expected= 5.0;
			
			Assert.AreEqual(expected, c1.Magnitude);

			c1.Magnitude=10;
			Assert.AreEqual(6, c1.Real);
			Assert.AreEqual(8, c1.Imag);



		}

		[Test()]
		public void TestAngle ()
		{
			//get angle
			Complex c1 = new Complex(3,4);
			double expected= 53.13;
			Assert.AreEqual(expected.ToString().Substring(0,4), c1.Angle.ToString().Substring(0,4));

			//set angle
			Complex c2 = new Complex(5,4);
			Assert.AreEqual(38.65.ToString().Substring(0,4), c2.Angle.ToString().Substring(0,4));
			Assert.AreEqual(6.4031.ToString().Substring(0,4), c2.Magnitude.ToString().Substring(0,4));
			double mag_before = c2.Magnitude;


			c2.Angle=45;
			//should give us real = 2.7 and img = 2.7

			Assert.AreEqual(4.5254.ToString().Substring(0,4), c2.Real.ToString().Substring(0,4));
			Assert.AreEqual(4.5254.ToString().Substring(0,4), c2.Imag.ToString().Substring(0,4));
			Assert.AreEqual(mag_before, c2.Magnitude);

			c2.Angle=10;
			Assert.AreEqual(1.1113.ToString().Substring(0,4), c2.Imag.ToString().Substring(0,4));
			Assert.AreEqual(6.30277.ToString().Substring(0,4), c2.Real.ToString().Substring(0,4));
			Assert.AreEqual(mag_before, c2.Magnitude, 0.00001, "Magnitude must not change");
			

		}


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

