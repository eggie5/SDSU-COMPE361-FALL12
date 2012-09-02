using System;

namespace lab1
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Convert converter = new Convert ();

			while (true) {

				Console.WriteLine ("Input category: length, volume or area");
				String unit = Console.ReadLine ().ToLower ().Trim ();

				Console.WriteLine("Input measure");
				String mag_input =Console.ReadLine();
				double magnitude=Double.Parse(mag_input);
				double conversion;

				switch (unit) {
				case Units.LENGTH:
					converter.SetConvertStrategy (new LengthStrategy ());
					conversion = converter.convert(magnitude, Convert.Units.Feet, Convert.Units.Meter); 
					break;
				case Units.VOLUME:
					converter.SetConvertStrategy (new VolumeStrategy ());
					break;
				case Units.AREA:
					converter.SetConvertStrategy (new AreaStrategy ());
					break;
				default:
					break;
				}

				Console.WriteLine("output= "+conversion.ToString());
			}//end while
		}
	}
}
