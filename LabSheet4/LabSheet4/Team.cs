using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSheet4
{
    enum Result
    {
        Win = 3,
        Draw= 1,
        Lose = 0,
    }

    class Team : IComparable<Team>
    {
        public string TeamName { get; private set; }
        public int Wins { get; private set; }
        public int Losses { get; private set; }
        public int Draws { get; private set; }
        public int Played { get; private set; }
        public List<Player> Players { get; private set; }

        public int Points
        {
            get
            {
                return (Wins * 3) + (Draws * 1);
            }
            private set
            {
                Points = value;
            }
        }

        public Team( string teamName )
        {
            TeamName = teamName;
            Player player1 = new Player("Ed McGinty", "Goalkeeper");
            Player player2 = new Player("John Mahon", "Defender");
            Player player3 = new Player("Ed McGinty", "Forward");

            Players.Add(player1);
            Players.Add(player2);
            Players.Add(player3);
        }

        public int CompareTo(Team that)
        {
            if (this.Points > that.Points) return -1;
            if (this.Points == that.Points) return 0;
            return 1;
        }

        public string DisplayTeamTable()
        {
            return string.Format($"{TeamName,-20}{Points,-12}{Wins,-12}{Draws,-12}{Losses,-12}{Played,-12}");
        }

        public void AddResult( Result result )
        {
            Played++;
            if (result == Result.Win)
            {
                Wins++;
            }
            if (result == Result.Draw)
            {
                Draws++;
            }
            if (result == Result.Lose)
            {
                Losses++;
            }
        }


        static void DisplayPlayers()
        {
            Console.WriteLine("{0,-20}{1,-12}{2,-12}{3,-12}{4,-12}{5,-12}", "Team name", "points", "Wins", "Draws", "Losses", "Played");
            foreach (Team team in teams)
            {
                Console.WriteLine(team.DisplayTeamTable());
            }
        }
    }
}
