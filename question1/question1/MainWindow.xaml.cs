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

namespace question1
{
    public enum Position
    {
        Goalkeeper,
        Defender,
        Midfielder,
        Forward
    }

    public class Player : IComparable<Player>
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public Position PreferredPosition { get; set; }
        public DateTime DateOfBirth { get; set; }

        private int age;

        public int Age
        {
            get
            {
                age = DateTime.Now.Year - DateOfBirth.Year;
                if (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear)
                    age--;
                return age;
            }
        }


        static Random rnd = new Random();

        public Player( Position preferredPosition )
        {
            SetRandomName();
            PreferredPosition = preferredPosition;
            DateOfBirth = RandomDay();
        }

        void SetRandomName( )
        {
            string[] firstNames = {
                "Adam", "Amelia", "Ava", "Chloe", "Conor", "Daniel", "Emily",
                "Emma", "Grace", "Hannah", "Harry", "Jack", "James",
                "Lucy", "Luke", "Mia", "Michael", "Noah", "Sean", "Sophie"};

            string[] lastNames = {
                "Brennan", "Byrne", "Daly", "Doyle", "Dunne", "Fitzgerald", "Kavanagh",
                "Kelly", "Lynch", "McCarthy", "McDonagh", "Murphy", "Nolan", "O'Brien",
                "O'Connor", "O'Neill", "O'Reilly", "O'Sullivan", "Ryan", "Walsh"
            };
            FirstName = firstNames[rnd.Next(0, firstNames.Length)];
            Surname = lastNames[rnd.Next(0, firstNames.Length)];
        }

        DateTime RandomDay()
        {
            // var myDate = DateTime.Today;
            //var newDate = DateTime.Today.AddYears(-10);

            DateTime start = DateTime.Today.AddYears(-10);
            int range = (DateTime.Today - start).Days;

            DateTime oneToTen = start.AddDays(rnd.Next(range));
            DateTime twentyToThirty = oneToTen.AddYears(-20);

            return twentyToThirty;
        }


        public int CompareTo(Player that)
        {
            return -that.PreferredPosition.CompareTo(PreferredPosition);
            /*
            if (that.ActivityDate.CompareTo(Player) == 0)
            {
                return -other.Name.CompareTo(Name);
            }
            return -other.ActivityDate.CompareTo(ActivityDate);
            */
        }


        public override string ToString()
        {
            return string.Format("{0} {1} ({2}) {3}", FirstName,Surname,Age,PreferredPosition );
        }

    }


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Player> PlayersAll;
        List<Player> PlayersSelected;
        int Spaces
        {
            get
            {
                return 11 - PlayersSelected.Count;
            }
        }
        int[,] Formations = new int[,] { { 4, 4, 2 }, { 4, 3, 3 }, { 4, 5, 1 }, { 0,0,0 } };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreatePlayers();
            PlayersSelected = new List<Player>();

            Lsb_All.ItemsSource = PlayersAll;
            Lsb_Selected.ItemsSource = PlayersSelected;

            Lsb_Selected.Items.Refresh();
            Lsb_All.Items.Refresh();

            Txb_Spaces.Text = Spaces.ToString();


            AddComboBoxItems();
            Cmb_Formation.SelectedValue= 2;
        }

        private void AddComboBoxItems()
        {
            int formationRows = (Formations.GetUpperBound(0) - Formations.GetLowerBound(0) + 1);
            for (int i = 0; i < formationRows; i++)
            {
                Cmb_Formation.Items.Add( string.Format("{0}-{1}-{2}", Formations[i, 0], Formations[i, 1], Formations[i, 2]) );
            }

            MessageBoxResult result = MessageBox.Show("qqq" + 33, "Message", MessageBoxButton.OK);
        }

        private void CreatePlayers()
        {
            PlayersAll = new List<Player>();

            PlayersAll.Add(new Player(Position.Goalkeeper));
            PlayersAll.Add(new Player(Position.Goalkeeper));

            for (int i = 0; i < 6; i++)
            {
                PlayersAll.Add(new Player(Position.Defender));
            }
            for (int i = 0; i < 6; i++)
            {
                PlayersAll.Add(new Player(Position.Midfielder));
            }
            for (int i = 0; i < 4; i++)
            {
                PlayersAll.Add(new Player(Position.Forward));
            }

            Lsb_All.ItemsSource = PlayersAll;
            Lsb_All.Items.Refresh();
        }


        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            if (Lsb_All.SelectedIndex != -1)
            {
                Player player = (Player)Lsb_All.SelectedItem;
                PlayersSelected.Add(player);
                PlayersAll.RemoveAt(Lsb_All.SelectedIndex);
            }

            PlayersAll.Sort();
            PlayersSelected.Sort();

            Lsb_Selected.Items.Refresh();
            Lsb_All.Items.Refresh();
            Txb_Spaces.Text = Spaces.ToString();
        }
        
        private void Btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            if (Lsb_Selected.SelectedIndex != -1)
            {
                Player player = (Player)Lsb_Selected.SelectedItem;
                PlayersAll.Add(player);
                PlayersSelected.RemoveAt(Lsb_Selected.SelectedIndex);
            }

            PlayersAll.Sort();
            PlayersSelected.Sort();

            Lsb_Selected.Items.Refresh();
            Lsb_All.Items.Refresh();
            Txb_Spaces.Text = Spaces.ToString();
        }

        private void Cmb_Formation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string ss = (string)Cmb_Formation.SelectedItem;
            int ss = Cmb_Formation.SelectedIndex;
            MessageBoxResult result = MessageBox.Show("qqq" + ss, "Message", MessageBoxButton.OK);

        }
    }
}
