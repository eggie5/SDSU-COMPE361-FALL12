using System;
using NUnit.Framework;
using lab1;

namespace lab1
{
	class VolumeStrategy : ConvertStrategy
	{
		private Convert.Units [] conversions = {Convert.Units.Ounce, Convert.Units.Liter, Convert.Units.Quart};

		public Convert.Units[] Conversions {
			get {
				return conversions;
			}
		}

		public Convert.Units getUnitFromString (string unit)
		{
			Convert.Units _unit;
			switch (unit) {
			case "ounce":
				_unit= Convert.Units.Ounce;
				break;
			case "liter":
				_unit = Convert.Units.Liter;
				break;
			case "quart":
				_unit = Convert.Units.Quart;
				break;
			default:
				throw new Exception("Could not parse: "+unit);
			}

			return _unit;
		}

		//ounces, quarts and liters
		public override double convert (double magnitude, Convert.Units from, Convert.Units to)
		{
			if (from == Convert.Units.Ounce && to == Convert.Units.Liter) {
				return ounces_to_liters (magnitude);
			} else if (from == Convert.Units.Ounce && to == Convert.Units.Quart) {
				return ounces_to_quarts (magnitude);
			} else if (from == Convert.Units.Quart && to == Convert.Units.Ounce) {
				return quarts_to_ounces (magnitude);
			} else if (from == Convert.Units.Quart && to == Convert.Units.Liter) {
				return quarts_to_liters (magnitude);
			} else if (from == Convert.Units.Liter && to == Convert.Units.Ounce) {
				return liters_to_ounces (magnitude);
			} else if (from == Convert.Units.Liter && to == Convert.Units.Quart) {
				return liters_to_quarts (magnitude);
			} else if (from == to)
			{
				return magnitude;
			}

			//no conversion possible
			throw new Exception("cannot find conversion stragety for this volume unit");
		}

		double ounces_to_liters (double ounces)
		{
			return ounces / (double) 33.814;
		}		

		double ounces_to_quarts (double ounces)
		{
			return ounces / (double) 32;
		}		

		double quarts_to_ounces (double quarts)
		{
			return quarts * (double) 32;
		}		

		double quarts_to_liters (double quarts)
		{
			return quarts / (double) 1.05669;
		}		

		double liters_to_ounces (double liters)
		{
			return liters * (double) 33.814;
		}		

		double liters_to_quarts (double liters)
		{
			return liters * (double) 1.05669;
		}






	}

}

