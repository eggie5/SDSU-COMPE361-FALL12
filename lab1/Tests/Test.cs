using System;
using NUnit.Framework;
using lab1;

namespace lab1
{
	[TestFixture()]
	public class Test
	{
		Convert converter;

		[SetUp()]
		public void Setup ()
		{
			converter=new Convert();
		}

		[Test()]
		public void testArea()
		{
			converter.SetConvertStrategy(new AreaStrategy());

			//160,000,000 square feet to sq miles
			double miles = converter.convert(160000000, Convert.Units.SquareFeet, Convert.Units.SquareMile);
			Assert.AreEqual("5.739", miles.ToString().Substring(0,5));

			//160,000,000 square feet to acres
			double acres = converter.convert(160000000, Convert.Units.SquareFeet, Convert.Units.Acre);
			Assert.AreEqual("3673.6", acres.ToString());

			//34 square miles to sq feet
			double sqfeet = converter.convert(34, Convert.Units.SquareMile, Convert.Units.SquareFeet);
			Assert.AreEqual("947865600", sqfeet.ToString());

			//34 square miels to acres
			double acres2 = converter.convert(34, Convert.Units.SquareMile, Convert.Units.Acre);
			Assert.AreEqual("21760", acres2.ToString());

			//1 acre to sq feet
			double sqfeet2= converter.convert(1, Convert.Units.Acre, Convert.Units.SquareFeet);
			Assert.AreEqual("43560", sqfeet2.ToString());

			//1 acre to sq miles
			double sqmiles2=converter.convert(1, Convert.Units.Acre, Convert.Units.SquareMile);
			Assert.AreEqual("0.001", sqmiles2.ToString().Substring(0,5));
		}

		[Test()]
		public void testVolume()
		{
			converter.SetConvertStrategy(new VolumeStrategy());

			//16 ounces to liters
			double liters = converter.convert(16, Convert.Units.Ounce, Convert.Units.Liter);
			Assert.AreEqual("0.473", liters.ToString().Substring(0,5));

			//14 ounces to quarts
			double quarts = converter.convert(14, Convert.Units.Ounce, Convert.Units.Quart);
			Assert.AreEqual("0.437", quarts.ToString().Substring(0,5));

			//1 quart to ounces
			double ounces = converter.convert(1, Convert.Units.Quart, Convert.Units.Ounce);
			Assert.AreEqual("32", ounces.ToString());

			//2 quarts to liters
			double literes2=converter.convert(2, Convert.Units.Quart, Convert.Units.Liter);
			Assert.AreEqual("1.892", literes2.ToString().Substring(0,5));

			//1 liter to ounces
			double ounces2 = converter.convert(1, Convert.Units.Liter, Convert.Units.Ounce);
			Assert.AreEqual("33.81", ounces2.ToString().Substring(0,5));

			//1 liter to quarts
			double quarts2 = converter.convert(1, Convert.Units.Liter, Convert.Units.Quart);
			Assert.AreEqual("1.056", quarts2.ToString().Substring(0,5));
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

			//test string parser
			Assert.AreEqual(Convert.Units.Meter, converter.ParseUnitsString("meter"));
			Assert.AreEqual(Convert.Units.Feet, converter.ParseUnitsString("feet"));
			Assert.AreEqual(Convert.Units.Mile, converter.ParseUnitsString("mile"));


		}
	}
}

