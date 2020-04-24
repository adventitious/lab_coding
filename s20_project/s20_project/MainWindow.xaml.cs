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


/*

done	 1		WPF/XAML 
done	 2		Classes/Objects 
maybe	 3		Inheritance ( optional )  :: count type descend from abstract count
no		 4		Interfaces ( also optional ) 
to do	 5		Sorting/Filter/Searching 

done	 6		Lists/Observable Collections 
done	 7		Event Handling 
no		 8		Working with Dates 
done	 9		Random
done	10		Github  

to do	11		Hand coded XAML - not drag and drop :: stretching columns
to do	12		LINQ - connecting to a database 
to do	13		Additional Windows/Navigation 
to do	14		JSON 
to do	15		Images 

maybe	16		Styles 
no		17		Data Templates 
to do	18		Exception Handling/Defensive Coding  
to do	19		Testing 

 
 */

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

            int exampleNo = CmbBx_Example.SelectedIndex;

            if (exampleNo == 0)
            {
                ContestCurrent = ContestMaker.ExampleContest1();

                Txb_Seats.Text = ContestCurrent.Seats + "";
            }
            if (exampleNo == 1)
            {
                ContestCurrent = ContestMaker.ExampleContest2();

                Txb_Seats.Text = ContestCurrent.Seats + "";
            }


            Lsb_Candidates.ItemsSource = ContestCurrent.Candidates;
            Lsb_Candidates.Items.Refresh();

            Lsb_Votes.ItemsSource = ContestCurrent.BallotPapers;
            Lsb_Votes.Items.Refresh();

            //ContestCurrent.Seats = Int32.Parse(Txb_Seats.Text);
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
