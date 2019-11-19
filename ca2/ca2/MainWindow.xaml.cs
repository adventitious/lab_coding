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
using System.Collections.ObjectModel;

namespace ca2
{
    /*
    static class Extensions
    {
        public static void Sort<T>(this ObservableCollection<T> collection) where T : IComparable
        {
            List<T> sorted = collection.OrderBy(x => x).ToList();
            for (int i = 0; i < sorted.Count(); i++)
                collection.Move(collection.IndexOf(sorted[i]), i);
        }
    }
    */




    enum ActivityType
    {
        Land,
        Sea,
        Air
    }


   /* public static class Extensions
    {
        public static void Sort<T>(this ObservableCollection<T> collection) where T : IComparable
        {
            List<T> sorted = collection.OrderBy(x => x).ToList();
            for (int i = 0; i < sorted.Count(); i++)
                collection.Move(collection.IndexOf(sorted[i]), i);
        }
    }*/

    class Activity : IComparable<Activity>
    {
        string Name { get; set; }
        public string Description{ get; set; }
        public  DateTime Date{ get; set; }
        public double Price { get; set; }
        ActivityType ActivityType { get; set; }

        public Activity(string name, string description, DateTime date, double price, ActivityType activityType)
        {
            // name, description, date, price
            Name = name;
            Description = description;
            Date = date;
            Price = price;
            ActivityType = activityType;
        }

        public int CompareTo(Activity other)
        {
            return other.Date.CompareTo(Date);
            //return DateTime.Compare(this.Date, that.Date);
            //return DateTime.Compare(this.Date, that.Date);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}",Name, Date.ToString("dd/MM/yyyy") );
        }
           
       
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Activity> ActivityAll;
        ObservableCollection<Activity> ActivitySelected;
        //List<Activity> ActivityAll;
        //List<Activity> ActivitySelected;
        public MainWindow()
        {
            InitializeComponent();
            // observable collection
            // string builder
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ActivityAll = new ObservableCollection<Activity>();
            //ActivityAll = new List<Activity>();
            ActivitySelected = new ObservableCollection<Activity>();

            

            ActivityAll.Add(new Activity("Helicopter Tour", "flying", new DateTime(2016,9,13 ), 22.99, ActivityType.Air));
            ActivityAll.Add(new Activity("Kayaking", "small boating", new DateTime(2016,2,13 ), 19.99, ActivityType.Sea));
            ActivityAll.Add(new Activity("Parachuting", "jumping", new DateTime(2016,6,13 ), 19.99, ActivityType.Air));
            ActivityAll.Add(new Activity("Mountain Biking", "cycling", new DateTime(2016,7,13 ), 19.99, ActivityType.Land));
            ActivityAll.Add(new Activity("Hang Gliding", "more flying", new DateTime(2016,3,09 ), 9.99, ActivityType.Air));
            ActivityAll.Add(new Activity("Abseiling", "mountaining", new DateTime(2016,03,13 ), 19.99, ActivityType.Land));
            ActivityAll.Add(new Activity("Sailing", "more boating", new DateTime(2016,4,13 ), 19.99, ActivityType.Sea));
            ActivityAll.Add(new Activity("Trekking", "walking", new DateTime(2016,1,13 ), 19.99, ActivityType.Land));
            ActivityAll.Add(new Activity("Surfing", "splashing", new DateTime(2016,12,13 ), 19.99, ActivityType.Sea ));

            //LsBx_All.Sort
            //LsBx_All.Items.SortDescriptions.
            //List<Activity> Ls = new List<Activity>();
            //Ls.Sort();
            //List<Activity>  = ActivityAll.OrderBy<Activity>();
            //ActivityAll.Sort();

            ActivityAll = new ObservableCollection<Activity>( ActivityAll.OrderBy( i => i ) );

            LsBx_All.ItemsSource = ActivityAll;
            LsBx_Selected.ItemsSource = ActivitySelected;

            //ActivityAll.Sort();

            //LsBx_All.ItemsSource = null;
            //LsBx_All.ItemsSource = ActivityAll;

        }




        private void LsBx_All_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Activity activity = (Activity)LsBx_All.SelectedItem;
            if( activity != null )
            {
                TxBl_Description.Text = "ok";
                TxBl_Description.Text = string.Format("{0}, Cost - {1:c}", activity.Description, activity.Price);
            }
        }

        private void LsBx_Selected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Activity activity = (Activity)LsBx_Selected.SelectedItem;
            if (activity != null)
            {
                TxBl_Description.Text = "ok";
                TxBl_Description.Text = string.Format("{0}, Cost - {1:c}", activity.Description, activity.Price);
            }
        }


        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            if (LsBx_All.SelectedIndex != -1)
            {
                Activity activity = (Activity)LsBx_All.SelectedItem;
                ActivitySelected.Add(activity);
                ActivityAll.RemoveAt(LsBx_All.SelectedIndex);
            }
            else
            {
                TxBl_NoSelect.Text = "nothing selected";
            }
        }

        private void Btn_Del_Click(object sender, RoutedEventArgs e)
        {
            // TxBl_Description.Text = LsBx_Selected.SelectedIndex + "";
            if(LsBx_Selected.SelectedIndex != -1 )
            {
                Activity activity = (Activity)LsBx_Selected.SelectedItem;
                ActivityAll.Add(activity);
                ActivitySelected.RemoveAt(LsBx_Selected.SelectedIndex);
            }
            else
            {
                TxBl_NoSelect.Text = "nothing selected";
            }
        }
    }
}
