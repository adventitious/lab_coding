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
    class Activity
    {
        string Name { get; set; }
        string Description{ get; set; }
        DateTime Date{ get; set; }
        double Price { get; set; }

        public Activity(string name, string description, DateTime date, double price )
        {
            // name, description, date, price
            Name = name;
            Description = description;
            Date = date;
            Price = price;
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
        private ObservableCollection<Activity> ActivityAll;
        public MainWindow()
        {
            InitializeComponent();
            // observable collection
            // string builder
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ActivityAll = new ObservableCollection<Activity>();
            LsBx_All.ItemsSource = ActivityAll;

            ActivityAll.Add(new Activity("Helicopter Tour", "flying", new DateTime(2016,5,13 ), 22.99));
            ActivityAll.Add(new Activity("Kayaking", "", new DateTime(2016,5,13 ), 19.99));
            ActivityAll.Add(new Activity("Parachuting", "", new DateTime(2016,5,13 ), 19.99));
            ActivityAll.Add(new Activity("Mountain Biking", "", new DateTime(2016,5,13 ), 19.99));
            ActivityAll.Add(new Activity("Hang Gliding", "", new DateTime(2016,5,13 ), 19.99));
            ActivityAll.Add(new Activity("Abseiling", "", new DateTime(2016,5,13 ), 19.99));
            ActivityAll.Add(new Activity("Sailing", "", new DateTime(2016,5,13 ), 19.99));
            ActivityAll.Add(new Activity("Trekking", "", new DateTime(2016,5,13 ), 19.99));
            ActivityAll.Add(new Activity("Surfing", "", new DateTime(2016,5,13 ), 19.99));


        }
    }
}
