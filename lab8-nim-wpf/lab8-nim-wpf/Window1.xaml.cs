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
using System.Windows.Shapes;

namespace lab8_nim_wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        MainWindow main_ref;
        public Window1(MainWindow main_ref)
        {
            this.main_ref = main_ref;
            InitializeComponent();
        }

        public System.Drawing.Font font;
        public System.Drawing.Color back_color;
        public System.Drawing.Color token_color;

        private void fontButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FontDialog fd = new System.Windows.Forms.FontDialog();
         
           if (fd.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
           {
               font = fd.Font;
               lableFontname.Content = font.Name;
           }

            
        }

        private void buttonChangeBack_click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog cd = new System.Windows.Forms.ColorDialog();
            if (cd.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                back_color = cd.Color;
                lableFontname_Copy.Content = back_color.Name;
            }
        }

        private void buttonChangeForeClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog cd = new System.Windows.Forms.ColorDialog();
            if (cd.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                token_color = cd.Color;
                lableFontname_Copy1.Content = token_color.Name;
                
            }
        }

        private void buttonSaveForm_Click(object sender, RoutedEventArgs e)
        {

            main_ref.nimControl1.BackColor = back_color;
            //nimControl1.ForeColor = w1.token_color;
            main_ref.nimControl1.updatePegColor(token_color);
            main_ref.FontFamily = new FontFamily(font.Name);
            this.Visibility=Visibility.Hidden;

        }

       
    }
}
