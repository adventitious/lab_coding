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
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bands = new List<Band>();
            //          bands.Add(new RockBand(bandName:  "The Beatles", yearFormed: 1960, members: new string[] { "John Lennon", "Paul McCartney", "George Harrison", "Ringo Starr" }));

            Band tempBand = new RockBand("The Beatles", 1960, new string[] { "John Lennon", "Paul McCartney", "George Harrison", "Ringo Starr" });
            tempBand.AddAlbum(new Album("white album 1968"));
            tempBand.AddAlbum(new Album("revolver 1966"));

            bands.Add(tempBand);

            tempBand = new PopBand("The Monkees", 1966, new string[] { "Micky Dolenz", "Michael Nesmith", "Peter Tork", "Davy Jones" });
            tempBand.AddAlbum(new Album("More of The Monkees 67"));
            tempBand.AddAlbum(new Album("Instant Replay(1969)"));

            bands.Add(tempBand);

            tempBand = new RockBand("Queen", 1970, new string[] { "Freddie Mercury", "Brian May", "John Deacon", "Roger Taylor" });
            tempBand.AddAlbum(new Album("Jazz(1978)"));
            tempBand.AddAlbum(new Album("A Kind of Magic (1986)"));

            bands.Add(tempBand);

            tempBand = new RockBand("U2", 1976, new string[] { "Bono", "the Edge", "Adam Clayton", "Larry Mullen Jr" });
            tempBand.AddAlbum(new Album("Boy 1980"));
            tempBand.AddAlbum(new Album("Rattle and Hum 1988"));

            bands.Add(tempBand);

            tempBand = new IndyBand("The Black Keys", 2001, new string[] { "Dan Auerbach", "Patrick Carney" });
            tempBand.AddAlbum(new Album("Thickfreakness 2003"));
            tempBand.AddAlbum(new Album("El Camino 2011"));

            bands.Add(tempBand);

            tempBand = new RockBand("Motörhead", 1975, new string[] { "Lemmy", "Larry Wallis", "Lucas Fox", "Phil Taylor", "Eddie Clarke" });
            tempBand.AddAlbum(new Album("Ace of Spades (1980)"));
            tempBand.AddAlbum(new Album("Iron Fist (1982)"));

            bands.Add(tempBand);

            bands.Sort();

            Lsb_Bands.ItemsSource = bands;
            Lsb_Bands.Items.Refresh();
        }

        private void Lsb_Bands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Lsb_Bands.SelectedItem != null)
            {
                Band band = (Band)Lsb_Bands.SelectedItem;
                Lsb_Albums.ItemsSource = band.Albums;
                Lsb_Albums.Items.Refresh();

                Txbk_YearFormed.Text = band.YearFormed.ToString();
                Txbk_Members.Text = band.MembersString();

                //string msgtext = "That date is not free"+ band.Albums[0].ToString();
                //MessageBoxResult result = MessageBox.Show(msgtext, "Message", MessageBoxButton.OK);

            }
        }
    }

    public class Album
    {
        public string AlbumName { get; set; }
        public int YearRelease { get; set; }
        public int Sales { get; set; }

        public Album( string albumName )
        {
            AlbumName = albumName;
        }

        public override string ToString()
        {
            return string.Format( AlbumName );
        }
    }


    public abstract class Band : IComparable<Band>
    {
        public string BandName { get; set; }
        public int YearFormed { get; set; }
        public string[] Members { get; set; }


        public List<Album> Albums { get; set; }

        public Band(string bandName, int yearFormed, string[] members)
        {
            BandName = bandName;
            YearFormed = yearFormed;
            Members = members;
            Albums = new List<Album>();
        }


        public string MembersString()
        {
            string out1 = "";
            foreach (var member in Members )
            {
                out1 += member + ", ";
            }

            out1 = out1.Remove(out1.Length - 2);

            return out1;
        }

        public void AddAlbum( Album album )
        {
            Albums.Add(album);
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

    public class RockBand : Band
    {
        public RockBand(string bandName, int yearFormed, string[] members) : base(bandName, yearFormed, members)
        {
        }

        public override string ToString()
        {
            return string.Format(this.BandName + " - Rock");
        }
    }

    public class PopBand : Band
    {
        public PopBand(string bandName, int yearFormed, string[] members) : base(bandName, yearFormed, members)
        {
        }

        public override string ToString()
        {
            return string.Format(this.BandName + " - Pop");
        }
    }

    public class IndyBand : Band
    {
        public IndyBand(string bandName, int yearFormed, string[] members) : base(bandName, yearFormed, members)
        {
        }

        public override string ToString()
        {
            return string.Format(this.BandName + " - Indy");
        }
    }
}
