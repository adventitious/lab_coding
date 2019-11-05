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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tblDice.Background = Brushes.Yellow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            updateDice();

        }

        public async void updateDice()
        {
            tblDice.Background = Brushes.Red;
            Random rand = new Random();
            int looping = rand.Next(10, 30);
            for (int i = 0; i < looping; i++)
            {
                int number = rand.Next(1, 7);
                tblDice.Text = number.ToString();

                // pause
                await Task.Delay(rand.Next(30, 150));
            }
            tblDice.Background = Brushes.Green;


        }
    }
}
