﻿using System;
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
        Air
    }


    class Activity : IComparable<Activity>
    {
        string Name { get; set; }
        public string Description{ get; set; }
        public  DateTime Date{ get; set; }
        public decimal Price { get; set; }
        public ActivityType ActivityType { get; set; }

        public Activity(string name, string description, DateTime date, ActivityType activityType, decimal price)
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
            if(other.Date.CompareTo(Date) == 0)
            {
                return -other.Name.CompareTo(Name);
            }
            return -other.Date.CompareTo(Date);
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
        List<Activity> ActivityAll;
        List<Activity> ActivitySelected;
        List<Activity> ActivityOut;

        public MainWindow()
        {
            InitializeComponent();
            // observable collection
            // string builder
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
                "Treking",
                 "Instructor led group trek through local mountains.",
                new DateTime(2019, 06, 01),
                ActivityType.Land,
                20m
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

                ActivityAll.Sort();
                ActivitySelected.Sort();

                LsBx_All.Items.Refresh();
                LsBx_Selected.Items.Refresh();

            }
            else
            {
                TxBl_NoSelect.Text = "nothing selected";
            }
        }

        private void Btn_Del_Click(object sender, RoutedEventArgs e)
        {
            if(LsBx_Selected.SelectedIndex != -1 )
            {
                Activity activity = (Activity)LsBx_Selected.SelectedItem;
                ActivityAll.Add(activity);
                ActivitySelected.RemoveAt(LsBx_Selected.SelectedIndex);

                ActivityAll.Sort();
                ActivitySelected.Sort();

                LsBx_All.Items.Refresh();
                LsBx_Selected.Items.Refresh();
            }
            else
            {
                TxBl_NoSelect.Text = "nothing selected";
            }
        }



        private void Rdo_Water_Checked(object sender, RoutedEventArgs e)
        {
            for( int i = 0; i < ActivityAll.Count; i++ )
            {
                Activity a = ActivityAll.ElementAt(i);
                if ( a.ActivityType != ActivityType.Water )
                {
                    ActivityOut.Add( a );
                    ActivityAll.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < ActivityOut.Count; i++)
            {
                Activity a = ActivityOut.ElementAt(i);
                if (a.ActivityType == ActivityType.Water)
                {
                    ActivityAll.Add(a);
                    ActivityOut.RemoveAt(i);
                    i--;
                }
            }
            LsBx_All.Items.Refresh();
        }

        private void Rdo_Air_Checked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ActivityAll.Count; i++)
            {
                Activity a = ActivityAll.ElementAt(i);
                if (a.ActivityType != ActivityType.Air)
                {
                    ActivityOut.Add(a);
                    ActivityAll.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < ActivityOut.Count; i++)
            {
                Activity a = ActivityOut.ElementAt(i);
                if (a.ActivityType == ActivityType.Air)
                {
                    ActivityAll.Add(a);
                    ActivityOut.RemoveAt(i);
                    i--;
                }
            }
            LsBx_All.Items.Refresh();
        }

        private void Rdo_Land_Checked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ActivityAll.Count; i++)
            {
                Activity a = ActivityAll.ElementAt(i);
                if (a.ActivityType != ActivityType.Land)
                {
                    ActivityOut.Add(a);
                    ActivityAll.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < ActivityOut.Count; i++)
            {
                Activity a = ActivityOut.ElementAt(i);
                if (a.ActivityType == ActivityType.Land)
                {
                    ActivityAll.Add(a);
                    ActivityOut.RemoveAt(i);
                    i--;
                }
            }
            LsBx_All.Items.Refresh();
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
            LsBx_All.Items.Refresh();
        }
    }
}
