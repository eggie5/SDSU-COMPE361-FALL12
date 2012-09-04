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

				Console.WriteLine("Input measure");
				String mag_input =Console.ReadLine();
				double magnitude=Double.Parse(mag_input);

				Console.WriteLine("Input unit");
				String unit = Console.ReadLine();


				double conversion;

				switch (category) {
				case Units.LENGTH:
					LengthStrategy length=new LengthStrategy();
					Convert.Units this_from = length.getUnitFromString(unit);
					converter.SetConvertStrategy (length);

					foreach(Convert.Units to_conversion in length.Conversions)
					{
						conversion = converter.convert(magnitude, this_from, to_conversion); 
						Console.WriteLine(magnitude + " "+this_from + "(s)" + " = " +" "+conversion.ToString()+" "+to_conversion+ "(s)" );
					}

					break;
				case Units.VOLUME:
					VolumeStrategy volume = new VolumeStrategy();
					Convert.Units v_from = volume.getUnitFromString(unit);
					converter.SetConvertStrategy (new VolumeStrategy ());

					foreach(Convert.Units to_conversion in volume.Conversions)
					{
						conversion = converter.convert(magnitude, v_from, to_conversion); 
						Console.WriteLine(magnitude + " "+v_from + "(s)" + " = "+" "+conversion.ToString()+" " +to_conversion+ "(s)"  );
					}
					break;
				case Units.AREA:
					AreaStrategy area = new AreaStrategy();
					Convert.Units a_from = area.getUnitFromString(unit);
					converter.SetConvertStrategy (new AreaStrategy ());

					foreach(Convert.Units to_conversion in area.Conversions)
					{
						conversion = converter.convert(magnitude, a_from, to_conversion); 
						Console.WriteLine(magnitude + " "+a_from + "(s)" + " = " +" "+conversion.ToString()+" "+to_conversion+ "(s)" );
					}
					break;
				default:
					break;
				}


			}//end while
		}


	}
}
