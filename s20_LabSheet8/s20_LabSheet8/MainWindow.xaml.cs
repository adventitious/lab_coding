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

namespace s20_LabSheet8
{

    public partial class MainWindow : Window
    {
        TeamData db = new TeamData();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from t in db.Teams
                        select t.TeamName;

            var teams = query.ToList();

            lbxTeams.ItemsSource = teams;
            
            lbxTeams.SelectedItem = 0;
            string teamName = teams.ElementAt(0);

            ChangePlayers(teamName);
        }

        private void lbxTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string teamName = (string)lbxTeams.SelectedValue;
            ChangePlayers(teamName);
        }

        private void ChangePlayers( string teamName)
        {
            var players = from p in db.Players
                          where p.Team.TeamName == teamName
                          select p.Name;

            lbxPlayers.ItemsSource = players.ToList();
        }
    }
}
