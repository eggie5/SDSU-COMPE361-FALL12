using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab7_calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Calc calc;

        public MainWindow()
        {
            InitializeComponent();
            calc = new Calc();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            String tag = (String)b.Tag;

            this.display.Text = calc.enterDigit(tag[0]);
        }

        private void buttonComplexInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Complex c = Complex.Parse(String.Format("{0} {1}", textBoxComplexReal.Text, textBoxComplexImag.Text));
                Console.WriteLine("Parsed {0} from complex input", c.ToString());

                if (calc.getMode() == MODE.Rectangular)
                    this.display.Text = calc.enterRectOperand(c).ToString();
                else if (calc.getMode() == MODE.Polar)
                    this.display.Text = calc.enterPolarOperand(c).ToString();
            }
            catch (Exception)
            {
                calc.CurrentState = ErrorState.Singleton;
                this.display.Text = "Argument Error";
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            calc.Clear();
            this.display.Text = "0";
        }

        private void onOpButtonClick(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            String tag = (string)b.Tag;
            calc.enterOp(tag);
            this.display.Text = tag;
        }

        private void buttonEquals_Click(object sender, RoutedEventArgs e)
        {
            this.display.Text = calc.enterEqual();
        }

        private void buttonToggleModeClick(object sender, RoutedEventArgs e)
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

        private void onButtonMemoryClick(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            if (b.Name.Equals(buttonMS.Name))
            {
                listBoxMemory.Items.Add(this.calc.getDisplay());
                Console.WriteLine("Saved {0} to mem", this.calc.getDisplay());
            }
            else if (b.Name.Equals(buttonMR.Name))
            {
                String mem = (String)listBoxMemory.SelectedItem;
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
    }
}
