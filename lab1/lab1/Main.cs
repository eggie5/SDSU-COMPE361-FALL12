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
				String category = Console.ReadLine ().ToLower ().Trim ();

				Console.WriteLine ("Input measure");
				String mag_input = Console.ReadLine ();
				double magnitude = Double.Parse (mag_input);

				Console.WriteLine ("Input unit");
				String from_unit_string = Console.ReadLine ();
				Convert.Units from = converter.ParseUnitsString (from_unit_string);


				switch (category) {
				case Units.LENGTH:
					converter.SetConvertStrategy (new LengthStrategy ());
					print_conversions (converter, LengthStrategy.Conversions, magnitude, from);
					break;
				case Units.VOLUME:
					converter.SetConvertStrategy (new VolumeStrategy ());
					print_conversions (converter, VolumeStrategy.Conversions, magnitude, from);
					break;
				case Units.AREA:
					converter.SetConvertStrategy (new AreaStrategy ());
					print_conversions (converter, AreaStrategy.Conversions, magnitude, from);
					break;
				default:
					break;
				}


			}//end while
		}

		public static void print_conversions (Convert converter, Convert.Units[] units, double magnitude, Convert.Units from)
		{
			foreach (Convert.Units to in units) {
				double conversion = converter.convert (magnitude, from, to); 
				Console.WriteLine (magnitude + " " + from + "(s)" + " = " + " " + conversion.ToString () + " " + to + "(s)");
			}
		}


	}
}
