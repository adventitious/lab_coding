using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCA
{
    class Player : IComparable<Player>
    {
        #region properties

        public static int HighScore { get; set; }

        private readonly int _playerID;
        public int PlayerID
        {
            get
            {
                return _playerID;
            }
        }
        public string PlayerName { get; private set; }
        public int Score { get; private set; }

        #endregion properties


        public Player(int playerID, string playerName, int score)
        {
            _playerID = playerID;
            PlayerName = playerName;
            Score = score;
        }


        public void IncreaseScore(int addToScore)
        {
            Score = Score + addToScore;
            if (Score > HighScore)
            {
                HighScore = Score;
            }
        }

        public override string ToString()
        {
            return string.Format("{0, -12}{1,-12}{2,-12}", PlayerID, PlayerName, Score);
        }

        public int CompareTo(Player that)
        {
            if (this.Score > that.Score) return -1;
            if (this.Score == that.Score) return 0;
            return 1;
        }
    }
}
