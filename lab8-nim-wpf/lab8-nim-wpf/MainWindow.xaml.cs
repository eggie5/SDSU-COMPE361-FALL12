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
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms.Integration;
using com.eggie5.nim.controller;

namespace lab8_nim_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IUserInterface
    {
        private Controller m_Controller;
        public com.eggie5.nim.ui.NimControl nimControl1;
        Window1 w1;
       

        public MainWindow()
        {
            m_Controller = new Controller(this);
             w1=new Window1(this);
            InitializeComponent();
        }

        public void InitBoard()
        {
            nimControl1.InitBoard();
        }

        public void Ask(string strQuestion, string strTitle, AskDelegate delAsk)
        {
            var result = System.Windows.MessageBox.Show(strQuestion, strTitle, MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
                delAsk(true);
            else
                delAsk(false);


        }

        private void InitalizeComponent()
        {

            WindowsFormsHost h = new WindowsFormsHost();
            h.Child = nimControl1;
            this.Grid1.Children.Add(h);

        }

        public void MessageBoxShow(string strMessage, string strTitle, MessageDelegate delMsg)
        {
            if (strMessage.Contains("I win."))
            {
                labelComputerScore.Content = (Int32.Parse(labelComputerScore.Content.ToString()) + 1).ToString();
            }

            System.Windows.MessageBox.Show(strMessage, strTitle);
            delMsg();
        }

        public void OnBoardChanged()
        {
            nimControl1.Invalidate();
        }

        public void UpdateUI()
        {
            int nRow, nNbPegs;
            nimControl1.GetSelectedPegs(out nRow, out nNbPegs);
            buttonRemovePegs.IsEnabled = nNbPegs > 0;
        }

        public void Error(string strMessage, string strTitle, MessageDelegate delMsg)
        {
            throw new NotImplementedException();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            nimControl1 = new com.eggie5.nim.ui.NimControl();
            nimControl1.IGetNimBoard = m_Controller;
            nimControl1.IUserInterface = this;
            nimControl1.init();
            InitalizeComponent();

         
            
        }

       

        private void buttonNewGame_Click(object sender, RoutedEventArgs e)
        {
            m_Controller.NewGame(Int32.Parse(textBoxRows.Text));
        }

        private void buttonRemovePegs_Click(object sender, RoutedEventArgs e)
        {
            int nRow, nNbPegs;
            nimControl1.GetSelectedPegs(out nRow, out nNbPegs);
            nimControl1.DeselectAll();
            m_Controller.OnMove(nRow, nNbPegs);
        }

        private void buttonSettings_Click(object sender, RoutedEventArgs e)
        {

           w1.Show();
         
               
               
           
        }

    }
}
