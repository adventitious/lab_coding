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

namespace s20_labsheet1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Band> bands;

        public MainWindow()
        {
            InitializeComponent();
            /*
            Band[] bands = new Band[6];

            bands[0] = new Band("The Beatles", 1960, new string[] { "John Lennon", "Paul McCartney", "George Harrison", "Ringo Starr" } );
            bands[1] = new Band("The Monkees", 1966, new string[] { "Micky Dolenz", "Michael Nesmith", "Peter Tork", "Davy Jones" } );
            bands[2] = new Band("Queen", 1970, new string[] { "Freddie Mercury", "Brian May", "John Deacon", "Roger Taylor" } );

            bands[3] = new Band("U2", 1976, new string[] { "Bono", "the Edge", "Adam Clayton", "Larry Mullen Jr" } );
            bands[4] = new Band("The Black Keys", 2001, new string[] { "Dan Auerbach", "Patrick Carney" } );
            bands[5] = new Band("Motörhead", 1975, new string[] { "Lemmy", "Larry Wallis", "Lucas Fox", "Phil Taylor", "Eddie Clarke" } );
            */
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bands = new List<Band>();
            /*
            bands.Add(new RockBand("The Beatles", 1960, new string[] { "John Lennon", "Paul McCartney", "George Harrison", "Ringo Starr" }));
            bands.Add(new RockBand("The Monkees", 1966, new string[] { "Micky Dolenz", "Michael Nesmith", "Peter Tork", "Davy Jones" }));
            bands.Add(new RockBand("Queen", 1970, new string[] { "Freddie Mercury", "Brian May", "John Deacon", "Roger Taylor" }));
            bands.Add(new RockBand("U2", 1976, new string[] { "Bono", "the Edge", "Adam Clayton", "Larry Mullen Jr" }));  
            bands.Add(new RockBand("The Black Keys", 2001, new string[] { "Dan Auerbach", "Patrick Carney" }));
            bands.Add(new RockBand("Motörhead", 1975, new string[] { "Lemmy", "Larry Wallis", "Lucas Fox", "Phil Taylor", "Eddie Clarke" }));
            */
            Lsb_Bands.ItemsSource = bands;
            bands.Sort();
            Lsb_Bands.Items.Refresh();

        }

    }

    abstract class Band : IComparable<Band>
    {
        public string BandName { get; set; }
        public int YearFormed { get; set; }
        public string[] Members { get; set; }

        public Band(string bandName, int yearFormed, string[] members)
        {
            BandName = bandName;
            YearFormed = yearFormed;
            Members = members;
        }


        public override string ToString()
        {
            return string.Format("{0}", BandName);
        }

        public int CompareTo(Band that)
        {
            return -that.BandName.CompareTo(BandName);
        }
    }

    class RockBand : Band, IComparable<Band>
    {
        public string BandName { get; set; }
        public int YearFormed { get; set; }
        public string[] Members { get; set; }

        public RockBand( string bandName )
        {

        }

    }
}
