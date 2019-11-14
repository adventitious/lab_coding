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

namespace LabSheet6c
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TxBlResult.Background = Brushes.Yellow;
            DpOne.SelectedDate = DateTime.Now;// new DateTime(2001, 10, 20)
        }

        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            //DateTime? dp = DpOne.SelectedDate;
            DateTime? selectedDate = DpOne.SelectedDate;
            string formatted = "";

            if (selectedDate.HasValue)
            {
                formatted = selectedDate.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                int y1 = int.Parse( selectedDate.Value.ToString("yyyy", System.Globalization.CultureInfo.InvariantCulture));
                int m1 = int.Parse( selectedDate.Value.ToString("MM", System.Globalization.CultureInfo.InvariantCulture));
                int day1 = int.Parse( selectedDate.Value.ToString("dd", System.Globalization.CultureInfo.InvariantCulture));

                DateTime d1 = new DateTime(y1, m1, day1);


                int dayNumber = int.Parse( TxInDays.Text );
                int monthsNumber = int.Parse( TxInMonths.Text );

                bool b2 = (bool)RdBack.IsChecked;

                if ( b2 )
                {
                    dayNumber *= -1;
                    monthsNumber *= -1;
                }

                DateTime d2 = d1.AddDays(dayNumber);

                d2 = d2.AddMonths(monthsNumber);

                string s1 = string.Format("{0}\n{1}", d2.ToString("dddd"), d2.ToString("dd/MM/yyyy") );


                TxBlResult.Text = s1;
            }

        }
    }
}
