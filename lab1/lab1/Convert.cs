using System;

namespace lab1
{
	public class Convert
	{
		public enum Units
		{
			Feet,
			Mile,
			Meter,
			Ounce,
			Liter,
			Quart,
			SquareMile,
			SquareFeet,
			Acre}
		;
		private ConvertStrategy convert_strategy;

		public Units ParseUnitsString (String string_unit)
		{
			Convert.Units unit;
			switch (string_unit) {
			case "meter":
				unit = Convert.Units.Meter;
				break;
			case "feet":
				unit = Convert.Units.Feet;
				break;
			case "mile":
				unit = Convert.Units.Mile;
				break;
			case "ounce":
				unit = Convert.Units.Ounce;
				break;
			case "liter":
				unit = Convert.Units.Liter;
				break;
			case "quart":
				unit = Convert.Units.Quart;
				break;
			case "sqfeet":
				unit = Convert.Units.SquareFeet;
				break;
			case "sqmile":
				unit = Convert.Units.SquareMile;
				break;
			case "acre":
				unit = Convert.Units.Acre;
				break;
			default:
				throw new Exception ("Could not parse: " + string_unit);
			}

			return unit;
		}
 
		public void SetConvertStrategy (ConvertStrategy convert_strategy)
		{
			this.convert_strategy = convert_strategy;
		}

		public Convert ()
		{

		}

		//needs generics??? just assuming double for now
		public double convert (double magnitude, Units from, Units to)
		{
			return this.convert_strategy.convert (magnitude, from, to);
		}

	}
}

