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

namespace LabSheet6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random r;
        public MainWindow()
        {
            InitializeComponent();
            r = new Random();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            int r1 = r.Next(1, 21);
            TxbInitial.Text = r1 + "";
        }

        private void BtnGuess_Click(object sender, RoutedEventArgs e)
        {
            int r1 = int.Parse(TxbInitial.Text);
            int r2 = r.Next(1, 21);
            TxbSecond.Text = r2 + "";

            if (RdBig.IsChecked == true && (r2 > r1))
            {
                TxbWin.Text = "you win";
            }
            else if (RdSmall.IsChecked == true && (r2 < r1))
            {
                TxbWin.Text = "you win";
            }
            else
            {
                TxbWin.Text = "you lose";
            }
        }
    }
}
