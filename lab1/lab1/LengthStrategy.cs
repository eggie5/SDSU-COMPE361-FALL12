using System;

namespace lab1
{
	public class LengthStrategy : ConvertStrategy
	{
//		public enum Units {feet, meters, miles};

		public LengthStrategy ()
		{
		}

		//implement interface
		public override double convert (double magnitude, Convert.Units from, Convert.Units to)
		{
			if (from == Convert.Units.Feet && to == Convert.Units.Meter) {
				return feet_to_meters (magnitude);
			} else if (from == Convert.Units.Feet && to == Convert.Units.Mile) {
				return feet_to_miles (magnitude);
			} else if (from == Convert.Units.Meter && to == Convert.Units.Feet) {
				return meters_to_feet (magnitude);
			} else if (from == Convert.Units.Meter && to == Convert.Units.Mile) {
				return meters_to_miles(magnitude);
			} else if (from == Convert.Units.Mile && to == Convert.Units.Feet) {
				return miles_to_feet(magnitude);
			} else if (from == Convert.Units.Mile && to == Convert.Units.Meter) {
				return miles_to_meters(magnitude);
			}

			//no conversion possible
			throw new Exception("cannot find conversion stragety for this length unit");
		}

		private double feet_to_meters (double feet)
		{
			return feet / (double) 3.28084;

		}		

		double feet_to_miles (double feet)
		{
			return feet / (double) 5280;
		}		

		double meters_to_feet (double meters)
		{
			return meters * (double) 3.28084;
		}		

		double meters_to_miles (double meters)
		{
			return meters / (double) 1609.34;
		}		

		double miles_to_feet (double miles)
		{
			return miles * (double) 5280;
		}		

		double miles_to_meters (double miles)
		{
			return miles * (double) 1609.34;
		}






	}
}

