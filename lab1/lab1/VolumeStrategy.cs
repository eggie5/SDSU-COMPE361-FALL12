using System;
using NUnit.Framework;
using lab1;

namespace lab1
{
	class VolumeStrategy : ConvertStrategy
	{
		public override double convert (double magnitude, Convert.Units from, Convert.Units to)
		{
			throw new NotImplementedException ();
		}
	}

}

