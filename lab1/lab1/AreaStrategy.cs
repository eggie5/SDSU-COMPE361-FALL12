using System;
using NUnit.Framework;
using lab1;

namespace lab1
{
	class AreaStrategy : ConvertStrategy
	{
		//square feet, square miles and acres

		private Convert.Units [] conversions = {Convert.Units.SquareFeet, Convert.Units.SquareMile, Convert.Units.Acre};

		public Convert.Units[] Conversions {
			get {
				return conversions;
			}
		}

		public Convert.Units getUnitFromString (string unit)
		{
			Convert.Units _unit;
			switch (unit) {
			case "sqfeet":
				_unit= Convert.Units.SquareFeet;
				break;
			case "sqmile":
				_unit = Convert.Units.SquareMile;
				break;
			case "acre":
				_unit = Convert.Units.Acre;
				break;
			default:
				throw new Exception("Could not parse: "+unit);
			}

			return _unit;
		}

		public override double convert (double magnitude, Convert.Units from, Convert.Units to)
		{
			if (from == Convert.Units.SquareFeet && to == Convert.Units.SquareMile) {
				return sqfeet_to_sqmiles (magnitude);
			} else if (from == Convert.Units.SquareFeet && to == Convert.Units.Acre) {
				return sqfeet_to_acres (magnitude);
			} else if (from == Convert.Units.SquareMile && to == Convert.Units.SquareFeet) {
				return sqmiles_to_sqfeet (magnitude);
			} else if (from == Convert.Units.SquareMile && to == Convert.Units.Acre) {
				return sqmiles_to_acres (magnitude);
			} else if (from == Convert.Units.Acre && to == Convert.Units.SquareFeet) {
				return acres_to_sqfeet (magnitude);
			} else if (from == Convert.Units.Acre && to == Convert.Units.SquareMile) {
				return acres_to_sqmiles (magnitude);
			} else if (from == to)
			{
				return magnitude;
			}
		

			//no conversion possible
			throw new Exception("cannot find conversion stragety for this area unit");
		}		

		double sqfeet_to_sqmiles (double sqfeet)
		{
			return sqfeet / (double) 27878400;
		}		

		double sqfeet_to_acres (double sqfeet)
		{
			return sqfeet * (double) 0.00002296;
		}		

		double sqmiles_to_sqfeet (double sqmiles)
		{
			return sqmiles * (double) 27878400;
		}		

		double sqmiles_to_acres (double sqmile)
		{
			return sqmile * (double) 640;
		}		

		double acres_to_sqfeet (double acre)
		{
			return acre * (double) 43560;
		}		

		double acres_to_sqmiles (double acres)
		{
			return acres * (double) 0.0015625;
		}







	

	}

}

