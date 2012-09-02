using System;
using NUnit.Framework;
using lab1;

namespace lab1
{
	[TestFixture()]
	public class TestCalc
	{
		Convert converter;

		[SetUp()]
		public void Setup ()
		{
			converter=new Convert();
		}

		[Test()]
		public void TestLength () 
		{
			converter.SetConvertStrategy(new LengthStrategy());

			//1 foot to meters
			double meters = converter.convert(1, Convert.Units.Feet, Convert.Units.Meter);
			Assert.AreEqual("0.304", meters.ToString().Substring(0,5));

			//5280 feet in miles
			double miles = converter.convert(5280, Convert.Units.Feet, Convert.Units.Mile);
			Assert.AreEqual("1", miles.ToString());

			//meters to feet
			double feet =  converter.convert(1, Convert.Units.Meter, Convert.Units.Feet);
			Assert.AreEqual("3.280", feet.ToString().Substring(0,5));

			//1609.34 meters to miles
			double miles2 = converter.convert(1609.34, Convert.Units.Meter, Convert.Units.Mile);
			Assert.AreEqual("1", miles2.ToString());

			//2 miles to feet
			double feet2= converter.convert(2, Convert.Units.Mile, Convert.Units.Feet);
			Assert.AreEqual("10560", feet2.ToString());

			//1 mile to meters
			double meters2= converter.convert(1, Convert.Units.Mile, Convert.Units.Meter);
			Assert.AreEqual("1609.34", meters2.ToString().Substring(0,7));

			 

//			converter.SetConvertStrategy(new VolumeStrategy());
//			double liters = converter.convert(16, Convert.Units.Ounce, Convert.Units.Liter);
//			Assert.AreEqual("1.233", liters.ToString().Substring(0,5));
//
//			converter.SetConvertStrategy(new AreaStrategy());
//			double miles = converter.convert(1241241234, Convert.Units.Feet, Convert.Units.Mile);
//			Assert.AreEqual("3.433", miles.ToString().Substring(0,5));



		}
	}
}

