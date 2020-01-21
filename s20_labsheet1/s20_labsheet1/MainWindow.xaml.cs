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
        public MainWindow()
        {
            InitializeComponent();
            Band[] bands = new Band[6];

            bands[0] = new Band("The Beatles", 1960, new string[] { "John Lennon", "Paul McCartney", "George Harrison", "Ringo Starr" } );
            bands[1] = new Band("The Monkees", 1966, new string[] { "Micky Dolenz", "Michael Nesmith", "Peter Tork", "Davy Jones" } );
            bands[2] = new Band("Queen", 1970, new string[] { "Freddie Mercury", "Brian May", "John Deacon", "Roger Taylor" } );

            bands[3] = new Band("U2", 1976, new string[] { "Bono", "the Edge", "Adam Clayton", "Larry Mullen Jr" } );
            bands[4] = new Band("The Black Keys", 2001, new string[] { "Dan Auerbach", "Patrick Carney" } );
            bands[5] = new Band("Motörhead", 1975, new string[] { "Lemmy", "Larry Wallis", "Lucas Fox", "Phil Taylor", "Eddie Clarke" } );

        }
    }

    class Band
    {
        string bandName;
        int yearFormed;
        string[] Members;

        public Band( string BandName, int YearFormed, string[] Members )
        {

        }
    }
}
