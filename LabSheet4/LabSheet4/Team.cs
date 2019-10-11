using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSheet4
{
    class Team : IComparable<Team>
    {
        #region properties

        public string TeamName { get; private set; }
        public int Wins { get; private set; }
        public int Losses { get; private set; }
        public int Draws { get; private set; }
        public int Played { get; private set; }
        public List<Player> Players { get; set; }
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

        #endregion properties


        public Team( string teamName )
        {
            TeamName = teamName;
            Players = new List<Player>();
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
                return;
            }
            if (result == Result.Draw)
            {
                Draws++;
                return;
            }
            if (result == Result.Lose)
            {
                Losses++;
                return;
            }
        }

        public void DisplayPlayers()
        {
            Console.WriteLine( TeamName + " Players");
            Console.WriteLine("{0,-20}{1,-20}", "Player name", "Position");

            foreach (Player player in Players)
            {
                Console.WriteLine(player.DisplayPlayerTable());
            }
        }
    }
}
