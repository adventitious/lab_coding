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
    enum ActivityType
    {
        Land,
        Water,
        Air,
        All
    }

    class Activity : IComparable<Activity>
    {
        public string Name { get; set; }
        public string Description{ get; set; }
        public  DateTime ActivityDate { get; set; }
        public decimal Cost { get; set; }
        public ActivityType TypeOfActivity { get; set; }

        public Activity(string name, string description, DateTime activityDate, ActivityType typeOfActivity, decimal cost)
        {
            Name = name;
            Description = description;
            ActivityDate = activityDate;
            Cost = cost;
            TypeOfActivity = typeOfActivity;
        }

        public int CompareTo(Activity other)
        {
            if(other.ActivityDate.CompareTo(ActivityDate) == 0)
            {
                return -other.Name.CompareTo(Name);
            }
            return -other.ActivityDate.CompareTo(ActivityDate);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}",Name, ActivityDate.ToString("dd/MM/yyyy") );
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        List<Activity> ActivityAll;
        List<Activity> ActivitySelected;
        List<Activity> ActivityOut;
        ActivityType CurrentFilter = ActivityType.All;
        decimal TotalPrice = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ActivityAll = new List<Activity>();
            ActivitySelected = new List<Activity>();
            ActivityOut = new List<Activity>();

            ActivityAll.Add(new Activity(
                "Mountain Biking",
                "Instructor led half day mountain biking.  All equipment provided.",
                new DateTime(2019, 06, 02),
                ActivityType.Land,
                30
            ));

            ActivityAll.Add(new Activity(
                name: "Treking",
                description: "Instructor led group trek through local mountains.",
                activityDate: new DateTime(2019, 06, 01),
                typeOfActivity: ActivityType.Land,
                cost: 20m
            ));

            ActivityAll.Add(new Activity(
                "Abseiling",
                "Experience the rush of adrenaline as you descend cliff faces from 10-500m.",
                new DateTime(2019, 06, 03),
                ActivityType.Land,
                40
            ));
            
            ActivityAll.Add(new Activity(
                "Kayaking",
                "Half day lakeland kayak with island picnic.",
                new DateTime(2019, 06, 01),
                ActivityType.Water,
                40
            ));
            
            ActivityAll.Add(new Activity(
                "Surfing",
                "2 hour surf lesson on the wild atlantic way",
                new DateTime(2019, 06, 02),
                ActivityType.Water,
                25
            ));
            
            ActivityAll.Add(new Activity(
                "Sailing",
                "Full day lakeland kayak with island picnic.",
                new DateTime(2019, 06, 03),
                ActivityType.Water,
                50
            ));
            
            ActivityAll.Add(new Activity(
                "Parachuting",
                "Experience the thrill of free fall while you tandem jump from an airplane.",
                new DateTime(2019, 06, 01),
                ActivityType.Air,
                100
            ));
            
            ActivityAll.Add(new Activity(
                "Hang Gliding",
                "Soar on hot air currents and enjoy spectacular views of the coastal region.",
                new DateTime(2019, 06, 02),
                ActivityType.Air,
                80
            ));
            
            ActivityAll.Add(new Activity(
                "Helicopter Tour",
                "Experience the ultimate in aerial sight-seeing as you tour the area in our modern helicopters",
                new DateTime(2019, 06, 03),
                ActivityType.Air,
                200
            ));

            LsBx_All.ItemsSource = ActivityAll;
            LsBx_Selected.ItemsSource = ActivitySelected;

            LsBx_All.Items.Refresh();
            LsBx_Selected.Items.Refresh();

            ActivityAll.Sort();
            ActivitySelected.Sort();

            TxBl_Cost.Text = string.Format("{0:c}", TotalPrice);
        }

        private void LsBx_All_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Activity activity = (Activity)LsBx_All.SelectedItem;
            if( activity != null )
            {
                TxBl_Description.Text = "ok";
                TxBl_Description.Text = string.Format("{0}, Cost - {1:c}", activity.Description, activity.Cost);
            }
        }

        private void LsBx_Selected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Activity activity = (Activity)LsBx_Selected.SelectedItem;
            if (activity != null)
            {
                TxBl_Description.Text = "ok";
                TxBl_Description.Text = string.Format("{0}, Cost - {1:c}", activity.Description, activity.Cost);
            }
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            if (LsBx_All.SelectedIndex != -1)
            {
                Activity activity = (Activity)LsBx_All.SelectedItem;
                if( IsDateFree( activity.ActivityDate ) )
                {
                    ActivitySelected.Add(activity);
                    ActivityAll.RemoveAt(LsBx_All.SelectedIndex);

                    // TotalPrice += activity.Price;
                    TxBl_Cost.Text = string.Format("{0:c}", TotalPrice += activity.Cost );

                    ActivityAll.Sort();
                    ActivitySelected.Sort();

                    LsBx_All.Items.Refresh();
                    LsBx_Selected.Items.Refresh();
                }
                else
                {
                    string msgtext = "That date is not free";
                    MessageBoxResult result = MessageBox.Show(msgtext, "Message", MessageBoxButton.OK);
                }
            }
            else
            {
                string msgtext = "Nothing selected";
                MessageBoxResult result = MessageBox.Show(msgtext, "Message", MessageBoxButton.OK);
            }
        }

        public bool IsDateFree( DateTime dateTime )
        {
            foreach( Activity activity in ActivitySelected )
            {
                if( activity.ActivityDate == dateTime )
                {
                    return false;
                }
            }
            return true;
        }

        private void Btn_Del_Click(object sender, RoutedEventArgs e)
        {
            if(LsBx_Selected.SelectedIndex != -1 )
            {
                Activity activity = (Activity)LsBx_Selected.SelectedItem;
                if( (activity.TypeOfActivity == CurrentFilter) || (CurrentFilter == ActivityType.All ) )
                {
                    ActivityAll.Add(activity);
                }
                else
                {
                    ActivityOut.Add(activity);
                }

                ActivitySelected.RemoveAt(LsBx_Selected.SelectedIndex);

                //TotalPrice -= activity.Price;
                TxBl_Cost.Text = string.Format("{0:c}", (TotalPrice -= activity.Cost ) );

                ActivityAll.Sort();
                ActivitySelected.Sort();

                LsBx_All.Items.Refresh();
                LsBx_Selected.Items.Refresh();
            }
            else
            {
                string msgtext = "Nothing selected";
                MessageBoxResult result = MessageBox.Show(msgtext, "Message", MessageBoxButton.OK);
            }
        }

        private void Rdo_Function(ActivityType activityType )
        {
            for (int i = 0; i < ActivityAll.Count; i++)
            {
                Activity a = ActivityAll.ElementAt(i);
                if (a.TypeOfActivity != activityType)
                {
                    ActivityOut.Add(a);
                    ActivityAll.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < ActivityOut.Count; i++)
            {
                Activity a = ActivityOut.ElementAt(i);
                if (a.TypeOfActivity == activityType)
                {
                    ActivityAll.Add(a);
                    ActivityOut.RemoveAt(i);
                    i--;
                }
            }
            CurrentFilter = activityType;
            LsBx_All.Items.Refresh();
        }

        private void Rdo_Water_Checked(object sender, RoutedEventArgs e)
        {
            Rdo_Function(ActivityType.Water );
        }

        private void Rdo_Air_Checked(object sender, RoutedEventArgs e)
        {
            Rdo_Function(ActivityType.Air);
        }

        private void Rdo_Land_Checked(object sender, RoutedEventArgs e)
        {
            Rdo_Function(ActivityType.Land);
        }

        private void Rdo_All_Checked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ActivityOut.Count; i++)
            {
                Activity a = ActivityOut.ElementAt(i);
                ActivityAll.Add(a);
                ActivityOut.RemoveAt(i);
                i--;
            }
            ActivityAll.Sort();
            LsBx_All.Items.Refresh();
            CurrentFilter = ActivityType.All;
        }
    }
}
