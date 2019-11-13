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

namespace LabSheet6b
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnOddEven_Click(object sender, RoutedEventArgs e)
        {
            string s1 = TxBxNumber.Text;
            int number = 0;
            bool isInt = int.TryParse(s1, out number);

            if( isInt )
            {
                if( number % 2 == 0 )
                {
                    TxBlResult.Text = "is even";
                    TxBlResult.Foreground = Brushes.Red;
                    TxBlResult.Background = Brushes.GreenYellow;
                }
                else
                {
                    TxBlResult.Text = "is odd";
                    TxBlResult.Foreground = Brushes.GreenYellow;
                    TxBlResult.Background = Brushes.Black;
                }
            }
            else
            {
                TxBlResult.Text = "is not int";
                TxBlResult.Foreground = Brushes.White;
                TxBlResult.Background = Brushes.Red;
            }
        }
    }
}