using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Player
    {

        #region properties

        private readonly  int _playerID;
        protected int PlayerID
        {
            get
            {
                return _playerID;
            }
        }
        protected string PlayerName { get; set; }
        public int Score {  get; private set; }

        #endregion properties


        public Player( int playerID, string playerName, int score )
        {

        }


        public void IncreaseScore( int addToScore )
        {
            Score = Score + addToScore;
        }


    }
}
