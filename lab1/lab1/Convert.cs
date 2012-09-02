using System;

namespace lab1
{
	public class Convert
	{
		public enum Units {Feet, Yards, Mile, Kilometer, Meter, Ounce, Liter};
		private ConvertStrategy convert_strategy;
 
	    public void SetConvertStrategy(ConvertStrategy convert_strategy)
	    {
			this.convert_strategy=convert_strategy;
	    }

		public Convert ()
		{

		}

		//needs generics??? just assuming double for now
		public double convert (double magnitude, Units from, Units to)
		{
			return this.convert_strategy.convert(magnitude, from, to);
		}

	}
}

