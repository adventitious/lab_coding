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
        List<Band> filteredBands;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Cmbx_Genre.Items.Add("All");
            Cmbx_Genre.Items.Add("Rock");
            Cmbx_Genre.Items.Add("Pop");
            Cmbx_Genre.Items.Add("Indy");

            Random rnd = new Random();
            // int month = rnd.Next(1, 13);  // creates a number between 1 and 12

            bands = new List<Band>();
            filteredBands = new List<Band>();
            //          bands.Add(new RockBand(bandName:  "The Beatles", yearFormed: 1960, members: new string[] { "John Lennon", "Paul McCartney", "George Harrison", "Ringo Starr" }));

            rnd.Next(1, 10000000);

            Band tempBand = new RockBand("The Beatles", 1960, new string[] { "John Lennon", "Paul McCartney", "George Harrison", "Ringo Starr" });
            tempBand.AddAlbum(new Album("white album", rnd.Next(1965, 2020), rnd.Next(1, 10000000) ));
            tempBand.AddAlbum(new Album("revolver", rnd.Next(1965, 2020), rnd.Next(1, 10000000)));

            bands.Add(tempBand);

            tempBand = new PopBand("The Monkees", 1966, new string[] { "Micky Dolenz", "Michael Nesmith", "Peter Tork", "Davy Jones" });
            tempBand.AddAlbum(new Album("More of The Monkees", rnd.Next(1965, 2020), rnd.Next(1, 10000000)));
            tempBand.AddAlbum(new Album("Instant Replay", rnd.Next(1965, 2020), rnd.Next(1, 10000000)));

            bands.Add(tempBand);

            tempBand = new RockBand("Queen", 1970, new string[] { "Freddie Mercury", "Brian May", "John Deacon", "Roger Taylor" });
            tempBand.AddAlbum(new Album("Jazz", rnd.Next(1965, 2020), rnd.Next(1, 10000000)));
            tempBand.AddAlbum(new Album("A Kind of Magic", rnd.Next(1965, 2020), rnd.Next(1, 10000000)));

            bands.Add(tempBand);

            tempBand = new RockBand("U2", 1976, new string[] { "Bono", "the Edge", "Adam Clayton", "Larry Mullen Jr" });
            tempBand.AddAlbum(new Album("Boy", rnd.Next(1965, 2020), rnd.Next(1, 10000000)));
            tempBand.AddAlbum(new Album("Rattle and Hum", rnd.Next(1965, 2020), rnd.Next(1, 10000000)));

            bands.Add(tempBand);

            tempBand = new IndyBand("The Black Keys", 2001, new string[] { "Dan Auerbach", "Patrick Carney" });
            tempBand.AddAlbum(new Album("Thickfreakness", rnd.Next(1965, 2020), rnd.Next(1, 10000000)));
            tempBand.AddAlbum(new Album("El Camino", rnd.Next(1965, 2020), rnd.Next(1, 10000000)));

            bands.Add(tempBand);

            tempBand = new RockBand("Motörhead", 1975, new string[] { "Lemmy", "Larry Wallis", "Lucas Fox", "Phil Taylor", "Eddie Clarke" });
            tempBand.AddAlbum(new Album("Ace of Spades", rnd.Next(1965, 2020), rnd.Next(1, 10000000)));
            tempBand.AddAlbum(new Album("Iron Fist", rnd.Next(1965, 2020), rnd.Next(1, 10000000)));

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
                Txbk_Members.Text = band.MembersString;
            }
        }

        private void Cmbx_Genre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string genre = (string)Cmbx_Genre.SelectedItem;

            for (int i = 0; i < bands.Count; i++)
            {
                if ( genre  != bands[i].GenreAsaString() && genre != "All" )
                {
                    filteredBands.Add(bands[i]);
                    bands.Remove(bands[i]);
                    i--;
                }
            }

            for (int i = 0; i < filteredBands.Count; i++)
            {
                if (filteredBands[i].GenreAsaString() == genre || genre == "All")
                {
                    bands.Add(filteredBands[i]);
                    filteredBands.Remove(filteredBands[i]);
                    i--;
                }
            }

            bands.Sort();
            Lsb_Bands.Items.Refresh();
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if(Lsb_Bands.SelectedItem == null )
            {
                MessageBox.Show("no band selected", "Message", MessageBoxButton.OK);
            }
            else
            {
                Band band = (Band)Lsb_Bands.SelectedItem;

                string[] lines = { "Band Name \t\t" + band.BandName,
                    "Year Formed \t" + band.YearFormed + "",
                    "Members \t\t" + band.MembersString,
                    "Albums \t\t\t" + band.AlbumsString + ""
                };

                // \Source\Repos\lab_coding\s20_labsheet1\s20_labsheet1\bin\Debug
                string saveDest = @"myfile.txt";
                try
                {
                    System.IO.File.WriteAllLines(saveDest, lines);
                }
                catch (Exception eee)
                {
                    MessageBox.Show(eee.Message, "Message", MessageBoxButton.OK);
                }

            }
            
        }
    }

    public class Album
    {
        public string AlbumName { get; set; }
        public DateTime YearRelease { get; set; }
        public int Sales { get; set; }

        public Album(string albumName, int yearRelease, int sales)
        {
            AlbumName = albumName;
            YearRelease = new DateTime(yearRelease, 1, 1 );
            Sales = sales;
        }

         

        public override string ToString()
        {
            // https://stackoverflow.com/questions/4127363/date-difference-in-years-using-c-sharp
            DateTime zeroTime = new DateTime(1, 1, 1);
            DateTime now = DateTime.Now;
            TimeSpan span = now - YearRelease;

            int years = (zeroTime + span).Year - 1;

            return string.Format( AlbumName  + " (" + YearRelease.Year + "), " + years + " years");
        }
    }


    public abstract class Band : IComparable<Band>
    {
        public string BandName { get; set; }
        public int YearFormed { get; set; }
        public string[] Members { get; set; }
        public string MembersString
        {
            get
            {
                string out1 = "";
                foreach (var member in Members)
                {
                    out1 += member + ", ";
                }
                out1 = out1.Remove(out1.Length - 2);
                return out1;
            }
        }
        public string AlbumsString
        {
            get
            {
                string out1 = "";
                foreach( Album album in Albums )
                {
                    out1 += album.AlbumName + ", ";
                }
                out1 = out1.Remove(out1.Length - 2);
                return out1;
            }
        }

        public List<Album> Albums { get; set; }

        public Band(string bandName, int yearFormed, string[] members)
        {
            BandName = bandName;
            YearFormed = yearFormed;
            Members = members;
            Albums = new List<Album>();
        }

        public abstract string GenreAsaString();

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

        public override string GenreAsaString()
        {
            return "Rock";
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

        public override string GenreAsaString()
        {
            return "Pop";
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

        public override string GenreAsaString()
        {
            return "Indy";
        }

        public override string ToString()
        {
            return string.Format(this.BandName + " - Indy");
        }
    }
}