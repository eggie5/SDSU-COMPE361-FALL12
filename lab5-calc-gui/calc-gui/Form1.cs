using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calc_gui
{
    public partial class Form1 : Form
    {
        private Calc calc;

        public Form1()
        {
            InitializeComponent();
            calc = new Calc();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void onDigitButtonClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            String tag = (String)b.Tag;

            this.display.Text = calc.enterDigit(tag[0]) ;

            //Complex c=calc.enterRectOperand(String.Format("{0} 0", b.Text));
            //this.display.Text = c.ToString();
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {

            this.display.Text = calc.enterEqual();
        }

        private void onOpButtonClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            String tag = (string)b.Tag;
            calc.enterOp(tag);
            this.display.Text = tag;
        }

        private void onButtonMemoryClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (b.Name.Equals(buttonMS.Name))
            {
                listBoxMemory.Items.Add(this.calc.getDisplay());
                Console.WriteLine("Saved {0} to mem", this.calc.getDisplay());
            }
            else if (b.Name.Equals(buttonMR.Name))
            {
                String mem=(String)listBoxMemory.SelectedItem;
                if (mem != null)
                {

                    Complex parsed_complex = Complex.Parse(mem);
                    Console.WriteLine("Loaded {0} from memory", parsed_complex.ToString());
                    Complex c = calc.enterRectOperand(parsed_complex);
                    this.display.Text = c.ToString();
                }
            }
            else if (b.Name.Equals(buttonMC.Name))
            {
                listBoxMemory.Items.Clear();
            }

            

        }

        private void buttonComplexInsert_Click(object sender, EventArgs e)
        {

            Complex c = Complex.Parse(String.Format("{0} {1}", textBoxComplexReal.Text, textBoxComplexImag.Text));
            Console.WriteLine("Parsed {0} from complex input", c.ToString());

            if(calc.getMode()==MODE.Rectangular)
                this.display.Text = calc.enterRectOperand(c).ToString();
            else if(calc.getMode()==MODE.Polar)
                this.display.Text = calc.enterPolarOperand(c).ToString();

        }

        private void buttonToggleModeClick(object sender, EventArgs e)
        {
            RadioButton b = (RadioButton)sender;
            if (b.Name.Equals(radioButtonRect.Name))
            {
                calc.setRect();
                this.display.Text = Complex.Parse(this.display.Text).ToString();
            }
            else if (b.Name.Equals(radioButtonPolar.Name))
            {
                calc.setPolar();
                this.display.Text = Complex.Parse(this.display.Text).ToString();
            }
        }

        private void clearButtonClick(object sender, EventArgs e)
        {
            calc.Clear();
            this.display.Text = "0";
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 b = new AboutBox1();
            b.Show();
        }



  
    }
}
