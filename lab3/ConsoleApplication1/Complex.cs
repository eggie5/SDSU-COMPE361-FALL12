using System;
using System.Text;

namespace ComplexNumbers
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

		public Complex()
		{
			real = 0;
			imag = 0;
		}

		public double Real
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
			}
		}


		public override string ToString()
		{
            if (mode == MODE.Rectangular)
            {
                if (imag < 0)
                    return String.Format("{0:F2} - j {1:F2}", real, -imag);
                else
                    return String.Format("{0:F2} + j {1:F2}", real, imag);
            }
            else
            {
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

