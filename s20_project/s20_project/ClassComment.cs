using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s20_project
{
    class ClassComment
    {
        /*
        List<Candidate> tieWinners = new List<Candidate>();

        int highestC = 0;

        foreach (Candidate c in Candidates)
        {
            if (c.VotesReceived == highestC)
            {
                tieWinners.Add(c);
            }
            if (c.VotesReceived > highestC)
            {
                tieWinners.Clear();
                tieWinners.Add(c);
                highestC = c.VotesReceived;
            }
        }

        foreach (Candidate c in tieWinners )
        {
            out1 += c.CandidateName + " got " + c.VotesReceived + '\n';
        }
        */

    }


    public class Vote : IComparable<Vote>
    {
        public Candidate Candidate { get; set; }
        public int Preference { get; set; }

        public Vote(Candidate candidate, int preference)
        {
            Candidate = candidate;
            Preference = preference;
        }

        public int CompareTo(Vote that)
        {
            return -that.Preference.CompareTo(Preference);
        }
    }



    public class Candidate : IComparable<Candidate>
    {
        public string CandidateName { get; set; }
        //public int VotesReceived { get; set; }
        public double VotesReceived { get; set; }
        public Candidate(string candidateName)
        {
            CandidateName = candidateName;
        }

        public override string ToString()
        {
            return CandidateName;
        }

        public void gotAVote(double voteValue)
        {
            VotesReceived += voteValue;
        }

        public int CompareTo(Candidate that)
        {
            return that.VotesReceived.CompareTo(VotesReceived);
        }
    }

    public class BallotPaper : IComparable<BallotPaper>
    {
        public List<Vote> Votes = new List<Vote>();

        public void AddVote(Vote vote)
        {
            Votes.Add(vote);
        }

        public override string ToString()
        {
            string out1 = "";
            Votes.Sort();
            foreach (var vote in Votes)
            {
                out1 += vote.Candidate.CandidateName + ": " + vote.Preference + ", ";
            }
            out1 = out1.Remove(out1.Length - 2);
            return out1;
        }

        public Candidate getPreferenceOfInt(int preference)
        {
            foreach (Vote vote in Votes)
            {
                if (vote.Preference == preference)
                {
                    return vote.Candidate;
                }
            }
            return null;
        }
        public int CompareTo(BallotPaper that)
        {
            for (int i = 0; i < Votes.Count(); i++)
            {
                if (i < that.Votes.Count())
                {
                    int sortInt = that.Votes[i].Candidate.CandidateName.CompareTo(Votes[i].Candidate.CandidateName);

                    if (sortInt != 0)
                    {
                        return -sortInt;
                    }
                }
            }
            /*
            if( sortInt != 0 )
            {
                return 0;
            }
            */
            return 0;
        }
    }



}
