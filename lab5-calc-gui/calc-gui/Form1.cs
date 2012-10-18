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

            this.display.Text=(calc.enterDigit(b.Text[0]));

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
            calc.enterOp(b.Text);
            this.display.Text = b.Text;
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
                Console.WriteLine("Loaded {0} from memory", mem);
                Complex c=calc.enterRectOperand(mem);
                this.display.Text=c.ToString();
            }

            

        }
    }
}
