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
using com.eggie5.nim.controller;

namespace lab8_nim_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IUserInterface
    {
        private Controller m_Controller;
        private com.eggie5.nim.ui.NimControl nimControl1;

        public MainWindow()
        {
            m_Controller = new Controller(this);
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

        public void MessageBoxShow(string strMessage, string strTitle, MessageDelegate delMsg)
        {
            //hack to show score (fastest way)
            if (strMessage.Contains("I win."))
            {
               // labelComputerScore.Text = (Int32.Parse(labelComputerScore.Text) + 1).ToString();
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
            // Create the interop host control.
            System.Windows.Forms.Integration.WindowsFormsHost host =
                new System.Windows.Forms.Integration.WindowsFormsHost();

            nimControl1 = new com.eggie5.nim.ui.NimControl();

            // Assign the MaskedTextBox control as the host control's child.
            host.Child = nimControl1;

            // Add the interop host control to the Grid 
            // control's collection of child controls. 
            this.Grid1.Children.Add(host);


            nimControl1.IGetNimBoard = m_Controller;
            nimControl1.IUserInterface = this;
            nimControl1.init();
        }

        private void buttonNewGame_Click(object sender, RoutedEventArgs e)
        {
            m_Controller.NewGame(5);
        }

        private void buttonRemovePegs_Click(object sender, RoutedEventArgs e)
        {
            int nRow, nNbPegs;
            nimControl1.GetSelectedPegs(out nRow, out nNbPegs);
            nimControl1.DeselectAll();
            m_Controller.OnMove(nRow, nNbPegs);
        }

    }
}
