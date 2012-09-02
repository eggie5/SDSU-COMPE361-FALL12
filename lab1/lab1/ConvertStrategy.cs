using System;

namespace lab1
{
	public abstract class ConvertStrategy
	{
		public abstract double convert(double magnitude, Convert.Units from, Convert.Units to);
	}
}

