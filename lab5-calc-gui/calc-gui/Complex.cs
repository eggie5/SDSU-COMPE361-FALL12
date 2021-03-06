using System;
using System.Text;

namespace calc_gui
{
    public enum MODE { Rectangular, Polar }
    public class Complex
	{
		private double real;
		private double imag;
        public static MODE mode = MODE.Rectangular;

		public Complex(double re, double im)
		{
			real = re;
			imag = im;
		}

        //from polar
		public Complex (int fake, double magnitude, double angle)
		{
			real = Math.Cos(angle * Math.PI / 180)*magnitude;
			imag= Math.Sin(angle * Math.PI / 180)*magnitude;
		}

		public Complex()
		{
			real = 0;
			imag = 0;
		}

		public static Complex Parse (string input)
		{
            Console.WriteLine("attempting to parse {0}", input);
			String [] parts = input.Trim ().Split ();
			if (parts.Length == 0) {
				throw new Exception("cannot parse");
			} else if (parts.Length == 1) { //only real part i.e. non-complex
				Complex c = new Complex(Double.Parse(parts[0]), 0);
				return c;
			}
            else if (parts.Length == 4)
            {
                Complex c = new Complex(Double.Parse(parts[0]), Double.Parse(parts[3]));
                return c;
            }
            else if (parts[1].Equals("@"))//polar
            {
                Console.WriteLine("Detected polar, parsing...");
                Complex c = new Complex(-1, Double.Parse(parts[0]), Double.Parse(parts[2]));
                return c;
            }
            else
            {
                if (Complex.mode == MODE.Rectangular)
                {
                    Complex c = new Complex(Double.Parse(parts[0]), Double.Parse(parts[1]));
                    return c;
                }
                else if (Complex.mode == MODE.Polar)
                {

                    Complex c = new Complex(-1, Double.Parse(parts[0]), Double.Parse(parts[1]));
                    return c;

                }
                else
                    throw new Exception("could not parse ");
            }
		}

		public double new_real
		{
			get { return real; }
			set { real = value; }
		}

		public double Imag
		{
			get { return imag; }
			set { imag = value; }
		}

		public double Magnitude
		{
			get { return Math.Sqrt(imag * imag + real * real); }
			set
			{
                if (value < 0)
                    throw new Exception("Error. attempt to set negative magnitude");
                else
				{
					double angle = Angle;
					real = value * Math.Cos(angle * Math.PI / 180);
                    imag = value * Math.Sin(angle * Math.PI / 180);
				}
			}
		}

		public double Angle
		{
			get	//returns angle in degrees, between -180 and +180
			{
				double angle = Math.Atan2(imag, real); // Notice the order of the arguments

				// Angle in radians, between -pi and +pi
				// Convert to degrees
				return angle * 180 / Math.PI;
			}
			set	// assumes value is in degrees
			{
				double angle = value;
				double mag = this.Magnitude;

				real = Math.Cos(angle * Math.PI / 180)*mag;
				imag= Math.Sin(angle * Math.PI / 180)*mag;

			}
		}




		public override string ToString()
		{
            if (mode == MODE.Rectangular)
            {
                if (imag == 0)
                    return String.Format("{0:F2}", real);
                else if (imag < 0)
                    return String.Format("{0:F2} - j {1:F2}", real, -imag);
                else
                    return String.Format("{0:F2} + j {1:F2}", real, imag);
            }
            else
            {
                if (Angle == 0)
                    return String.Format("{0:F2}", Magnitude);
                else
                    return String.Format("{0:F2} @ {1:F2}", Magnitude, Angle);
            }
		}

		public static Complex operator +(Complex x, Complex y)
		{
			return new Complex(x.real + y.real, x.imag + y.imag);
		}

		public static Complex operator -(Complex x, Complex y)
		{
			return new Complex(x.real - y.real, x.imag - y.imag);
		}

		public static Complex operator *(Complex x, Complex y)
		{
			return new Complex((x.real*y.real - x.imag*y.imag), (x.real*y.imag + x.imag*y.real));
		}

		public static Complex operator /(Complex x, Complex y)
		{
			//((ac + bd) / (c 2 + d 2 )) + ((bc - ad) / (c 2 + d 2 )i

			Complex quotent = new Complex((x.real*y.real + x.imag*y.imag) 
			                              / (Math.Pow(y.real, 2) + Math.Pow(y.imag,2)),((x.imag*y.real - x.real*y.imag)
			                                              /(Math.Pow(y.real,2)+Math.Pow(y.imag,2))));

			return quotent;
		}

	}   // end class Complex

    public class ExceptionMagnitude : Exception
    {
        public override string Message
        {
            get
            {
                return string.Format("Error.  Magnitude must be non-negative. ");
            }
        }
    }

}   // end namespace ComplexClass

