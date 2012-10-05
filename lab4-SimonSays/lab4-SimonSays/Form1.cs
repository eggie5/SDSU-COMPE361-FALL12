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

namespace lab4SimonSays
{
    public partial class Form1 : Form
    {
        private SimonSays gameEngine;
        private Button[] buttons;
        private Color [] sequence;
        private Dictionary<Color, Button> lookup;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
            Color [] colors = gameEngine.newSequence(Int32.Parse(this.textBox1.Text));
            this.sequence = colors;
            playSequence();
        }



        private void playSequence()
        {
            foreach (Color color in sequence)
            {
                Button b;
                Boolean status = lookup.TryGetValue(color, out b);
                Color old = b.BackColor;
                timer1.Start();
                b.BackColor = Color.White;
                timer1.Stop();
                b.BackColor = old;

                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            highlightButton();
        }
    }
}
