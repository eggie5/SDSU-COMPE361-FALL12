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
        private Color [] game_sequence;
        private Dictionary<Color, Button> lookup;
        private int elapsed=0;
        private System.Timers.Timer aTimer;
        private List<Color> user_sequence;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            user_sequence = new List<Color>();
            aTimer=new System.Timers.Timer();
            aTimer.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick) ;
            aTimer.Interval = 1;
            
            gameEngine = new SimonSays();
            lookup = new Dictionary<Color, Button>();
            lookup.Add(gameEngine.Colors[0], this.button1);
            lookup.Add(gameEngine.Colors[1], this.button2);
            lookup.Add(gameEngine.Colors[2], this.button3);
            lookup.Add(gameEngine.Colors[3], this.button4);

            buttons = new Button[] { this.button1, this.button2, this.button3, this.button4 };
          

            for(int i=0; i<buttons.Length;i++)
            {
                buttons[i].BackColor = gameEngine.Colors[i];
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            reset();
            Color [] colors = gameEngine.newSequence(Int32.Parse(this.textBox1.Text));
            this.game_sequence = colors;
            playSequence();
        }

        private void reset()
        {
            user_sequence = new List<Color>();
        }

        public static Color Lighten(Color inColor, double inAmount)
        {
            return Color.FromArgb(
              inColor.A,
              (int)Math.Min(255, inColor.R + 255 * inAmount),
              (int)Math.Min(255, inColor.G + 255 * inAmount),
              (int)Math.Min(255, inColor.B + 255 * inAmount));
        }

        private void playSequence()
        {
            Console.WriteLine("staring playsequence {0}", this.game_sequence);
            foreach (Color color in game_sequence)
            {
                Button b;
                Boolean status = lookup.TryGetValue(color, out b);
                playButtonSound(b);
                Color old = b.BackColor;
                Console.WriteLine("color= {0}", old);

                b.BackColor = Lighten(old, 0.8);
                this.Refresh();
                
                aTimer.Start();
                while (elapsed < 10)
                {
                    //Console.WriteLine("elapsed={0}", elapsed);
                }
                aTimer.Stop();
                elapsed = 0;
                b.BackColor = old;
                this.Refresh();

                
            }
            Console.WriteLine("done playing sequence");
        }

        private void timer1_Tick(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("TICK, elepsed={0}", elapsed);
            elapsed++;
        }

        private void playButtonSound(Button b)
        {
            switch (b.BackColor.Name)
            {
                case "Red":
                    playSound(lab4SimonSays.Properties.Resources.Tone1);
                    break;
                case "Green":
                    playSound(lab4SimonSays.Properties.Resources.Tone2);
                    break;
                case "Blue":
                    playSound(lab4SimonSays.Properties.Resources.Tone3);
                    break;
                case "Yellow":
                    playSound(lab4SimonSays.Properties.Resources.Tone4);
                    break;

            }
        }

        private void playSound(System.IO.UnmanagedMemoryStream stream)
        {
            (new SoundPlayer(stream)).PlaySync();
        }

        private void button_click(object sender, EventArgs e)
        {
            //get which button this is:
            Button b = (Button)sender;

            playButtonSound(b);
            
            //update user's moves
            this.user_sequence.Add(b.BackColor);

            int result=gameEngine.Compare(this.user_sequence.ToArray());
            switch (result)
            {
                case 1:
                    Console.WriteLine("winner!");
                    playSound(lab4SimonSays.Properties.Resources.tada);
                    MessageBox.Show("you won!");
                    
                    reset();
                    break;
                case 0:
                    Console.WriteLine("good job, keep going...");
                    break;
                case -1:
                    Console.WriteLine("You lost!");
                    playSound(lab4SimonSays.Properties.Resources.ups);
                    MessageBox.Show("You lost!!!");

                    reset();
                    break;
            }

        }
    }
}
