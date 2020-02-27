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

namespace s20_project
{
    public partial class MainWindow : Window
    {
        public Contest ContestCurrent;

        Random r = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //MakeNewContest();
        }

        private void Btn_NewContest_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            ContestCurrent = ContestMaker.ExampleContest2( r );

            Lsb_Candidates.ItemsSource = ContestCurrent.Candidates;
            Lsb_Candidates.Items.Refresh();

            Lsb_Votes.ItemsSource = ContestCurrent.BallotPapers;
            Lsb_Votes.Items.Refresh();

            doSimpleCount();

            //MessageBox.Show("You said: " + " qqq: " );
        }




        private void Btn_RemoveCandidate_Click(object sender, RoutedEventArgs e)
        {
            int rint = r.Next(0, 3);
            MessageBox.Show("You said: " + " qqq: " + rint);
        }

        private void Btn_Count_Click(object sender, RoutedEventArgs e)
        {
            doSimpleCount();
        }

        private void doSimpleCount()
        {
            try
            {
                SimpleCount1 sc = new SimpleCount1( ContestCurrent );

                // string s = sc.getResults();
                
                Txb_Results.Text = sc.getResults();  //s;
            }
            catch ( Exception exc)
            {
                MessageBox.Show("You said: " + " wwww:333 " + exc.Message);
            }
        }

        private void Btn_AddCandidate_Click(object sender, RoutedEventArgs e)
        {
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }
    }

}
