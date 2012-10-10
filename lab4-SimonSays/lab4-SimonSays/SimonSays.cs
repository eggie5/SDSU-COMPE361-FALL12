using System;
using System.Drawing;

namespace lab4SimonSays
{
	public class SimonSays
	{
		private Color[] sequence;
		private Color [] colors =  new Color[]{Color.Red, Color.Green, Color.Blue, Color.Yellow};


		public SimonSays ()
		{
		}

		public Color [] newSequence (int length)
		{
			Color [] array = new Color[length];
            Random rand = new Random(DateTime.Now.Millisecond);// don't inline w/ colors[] - wont be random

			for (int i=0; i<length; i++) {
                array[i] = colors[rand.Next(0,4)];
			}
			this.sequence=array;
			return array;
		}

		public void newSequence (Color [] sequence)
		{
			this.sequence=sequence;
		}

		public int Compare (Color[] user_colors)
		{
            if(this.sequence ==null)
                throw new InvalidStateException("The game engine has not generated  sequence yet");
			for (int i=0; i<user_colors.Length; i++) {
				if (user_colors [i] == this.sequence [i]) {
					//single match
				} else {
					//no match
					return -1;
				}
			}

			//all matched
			if (user_colors.Length == this.sequence.Length) {
				return 1;
			} else { //partial match
				return 0;
			}
		}

		public Color[] Colors {
			get {
				return colors;
			}
		}
	}
}

