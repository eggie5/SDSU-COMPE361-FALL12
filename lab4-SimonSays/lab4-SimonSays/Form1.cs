using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.Timers;
using System.Media;

namespace lab4SimonSays
{
	public partial class Form1 : Form
	{
		private SimonSays gameEngine;
		private Button[] buttons;
		private Color[] game_sequence;
		private Dictionary<Color, Button> lookup;
		private List<Color> user_sequence;
		private SoundPlayer redSound;
		private SoundPlayer greenSound;
		private SoundPlayer blueSound;
		private SoundPlayer yellowSound;
		private SoundPlayer winSound = new SoundPlayer (lab4SimonSays.Properties.Resources.tada);
		private SoundPlayer looseSound = new SoundPlayer (lab4SimonSays.Properties.Resources.ups);
		private System.Threading.Timer mTimer = null;
		private int ANIMATION_RATE = 1;
		private int MILLASECONDS = 0;
		private int timer_index = 0;
		private int timer_elapsed;
		private Color old_color;
        private int interval;

		public Form1 ()
		{
			InitializeComponent ();
			redSound = new SoundPlayer (lab4SimonSays.Properties.Resources.Tone1);
			greenSound = new SoundPlayer (lab4SimonSays.Properties.Resources.Tone2);
			blueSound = new SoundPlayer (lab4SimonSays.Properties.Resources.Tone3);
			yellowSound = new SoundPlayer (lab4SimonSays.Properties.Resources.Tone4);

            comboBoxIntervals.SelectedIndex = 3;

			//Set up the function to call when the timer fires
			TimerCallback timercb = new TimerCallback (TimerCB);

			//Set up the timer to fire at the set animation rate
			mTimer = new System.Threading.Timer (timercb, null, ANIMATION_RATE, ANIMATION_RATE);
            
		}

		protected void TimerCB (object o)
		{
			MILLASECONDS++;

			//turn off timer if nothing to iterate
			if (this.game_sequence != null && this.timer_index < this.game_sequence.Length) {
				this.timer_elapsed++;
				Color color = this.game_sequence [this.timer_index];
				Button b;
				lookup.TryGetValue (color, out b);

				//need to highlist button
				if (this.timer_elapsed == 0) {
					Console.WriteLine ("setting...");
					//play sound
					playButtonSound (b);
					//lighten background
					this.old_color = b.BackColor;
					b.BackColor = Lighten (this.old_color, 0.5);
				}
                //unhighlighting it and move index to next button
                    
                else if (this.timer_elapsed > (50/this.interval)) {
					Console.WriteLine ("reseting...");
					b.BackColor = this.old_color;

					this.timer_index++;
					this.timer_elapsed = -1;

				} else
					//waiting...
                
              
				//Redraw the form
				Invalidate ();
			}
		}

		private void Form1_Load (object sender, EventArgs e)
		{
			user_sequence = new List<Color> ();
            
			gameEngine = new SimonSays ();
			lookup = new Dictionary<Color, Button> ();
			lookup.Add (gameEngine.Colors [0], this.button1);
			lookup.Add (gameEngine.Colors [1], this.button2);
			lookup.Add (gameEngine.Colors [2], this.button3);
			lookup.Add (gameEngine.Colors [3], this.button4);

			buttons = new Button[] {
				this.button1,
				this.button2,
				this.button3,
				this.button4
			};
			for (int i=0; i<buttons.Length; i++) {
				buttons [i].BackColor = gameEngine.Colors [i];
			}
		}

		private void buttonStart_Click (object sender, EventArgs e)
		{
			reset ();
			Color [] colors = gameEngine.newSequence (Int32.Parse (this.textBox1.Text));
			this.game_sequence = colors;
			this.timer_index = 0;
			this.timer_elapsed = -1;
            this.interval = Int32.Parse(comboBoxIntervals.Text);
           
			//playSequence();
		}

		private void reset ()
		{
			user_sequence = new List<Color> ();
		}

		public static Color Lighten (Color inColor, double inAmount)
		{
			return Color.FromArgb (
              inColor.A,
              (int)Math.Min (255, inColor.R + 255 * inAmount),
              (int)Math.Min (255, inColor.G + 255 * inAmount),
              (int)Math.Min (255, inColor.B + 255 * inAmount));
		}

		//private void playSequence()
		//{
		//    int delay = 5;
		//    Console.WriteLine("staring playsequence");
		//    foreach (Color color in game_sequence)
		//    {
		//        int start = MILLASECONDS;
		//        Button b;    lookup.TryGetValue(color, out b);
		//        Console.WriteLine("color: {0}", color.Name);
		//        playButtonSound(b);
		//        Color old = b.BackColor;

		//        b.BackColor = Lighten(old, 0.8);

   
		//        b.BackColor = old;
               

		//    }
		//    Console.WriteLine("done playing sequence");
		//}


		private void playButtonSound (Button b)
		{
			switch (b.BackColor.Name) {
			case "Red":
				redSound.Play ();
				break;
			case "Green":
				greenSound.Play ();
				break;
			case "Blue":
				blueSound.Play ();
				break;
			case "Yellow":
				yellowSound.Play ();
				break;

			}
		}

//        private void playSound(System.IO.UnmanagedMemoryStream stream)
//        {
//            (new SoundPlayer(stream)).PlaySync();
//        }


		private void button_click (object sender, EventArgs e)
		{
			//get which button this is:
			Button b = (Button)sender;

			playButtonSound (b);
            
			//update user's moves
			this.user_sequence.Add (b.BackColor);

			try {

				int result = gameEngine.Compare (this.user_sequence.ToArray ());
				switch (result) {
				case 1:
					Console.WriteLine ("winner!");
					winSound.Play ();
					//MessageBox.Show ("you won!");
					var res = MessageBox.Show(" You Won!\nWould you like to try again?","You Won!", 
					                                      MessageBoxButtons.YesNo,
					                                      MessageBoxIcon.Question);

					if (res == DialogResult.Yes)
					{
						reset();
						this.timer_index = 0;
						this.timer_elapsed = -1;

					}

					reset ();
					break;
				case 0:
					Console.WriteLine ("good job, keep going...");
					break;
				case -1:
					Console.WriteLine ("You lost!");
					looseSound.Play ();
					MessageBox.Show ("You lost!!!");

					reset ();
					break;
				}
			} catch (InvalidStateException message) {
				Console.WriteLine ("Start a new game first...");
			}

        }



	}
}
