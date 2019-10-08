using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSheet4
{
    class Program
    {
        static void Main(string[] args)
        {
            Team SligoRovers = new Team("Sligo  Rovers");
            Team FinnHarps = new Team("Finn  Harps");
            Team GalwayUnited = new Team("Galway  United");
            Team DerryCity = new Team("Derry  City");
            Team Dundalk = new Team("Dundalk");

            List<Team> teams = new List<Team>();

            teams.Add(SligoRovers);
            teams.Add(FinnHarps);
            teams.Add(GalwayUnited);
            teams.Add(DerryCity);
            teams.Add(Dundalk);

            DisplayTeams(teams);
            Console.WriteLine();

            SligoRovers.AddResult(Result.Win);
            FinnHarps.AddResult(Result.Lose);
            FinnHarps.AddResult(Result.Draw);
            GalwayUnited.AddResult(Result.Win);
            Dundalk.AddResult(Result.Lose);

            DisplayTeams(teams);
            Console.WriteLine();

            teams.Sort();
            DisplayTeams(teams);
        }

        static void DisplayTeams(List<Team> teams)
        {
            Console.WriteLine( "{0,-20}{1,-12}{2,-12}{3,-12}{4,-12}{5,-12}","Team name", "points", "Wins","Draws", "Losses", "Played");
            foreach ( Team team in teams)
            {
                Console.WriteLine(team.DisplayTeamTable() );
            }
        }
    }
}
