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
        



        
    public class SimpleCount
    {
        public List<Candidate> Candidates;
        public List<BallotPaper> BallotPapers;

        public SimpleCount( List<Candidate> candidates, List<BallotPaper> ballotPapers )
        {
            Candidates = candidates;
            BallotPapers = ballotPapers;
        }

        public string getResults()
        {
            string out1 = "";

            // seats : 2
            double seats = 2;


            // Count the number of invalid papers, 
            // and subtract this from the total vote 
            // to get the total valid vote.

            // total valid vote : 10
            // BallotPapers.Count()

            // step 1 
            // quota
            // "The Quota is determined by dividing the total valid vote 
            // by one more than the number of places to be filled,
            // continuing the calculation to two decimal places, and rounding up."

            // 10 / 3 = 3.33 --> 3.34





            // Calculate the quota by dividing the total valid vote 
            // by one more than the number of places to be filled. 
            // Take the division to two decimal places. 
            // If the result is exact that is the quota. 
            // Otherwise ignore the remainder, and add 0.01.

            double quota = BallotPapers.Count() / (seats + 1);

            quota = Math.Round(quota, 2);    // ...don't round, truncate remainder
            quota += 0.01;                   // ...this is okay, but above should not be rounded

            out1 += "quota: " + quota.ToString() + "\n\n";             // display the quota



            foreach (BallotPaper bp in BallotPapers)
            {
                Candidate gotVote = bp.getPreferenceOfInt(1);
                gotVote.gotAVote(1.0);
            }
            out1 += ListCanVotes();                            // display the candidates and their votes 
            out1 += "\n";


            // deem elected any candidate whose vote equals or exceeds  the quota

            // if a candidate has more than (or equals) the quota, that candidate is elected




            // else, the candidate with least votes is removed

            // candidate with a vote of that exceeds the quota is deemed elected.
            List<Candidate> elected = new List<Candidate>();
            foreach (Candidate c in Candidates)
            {
                if (c.VotesReceived > quota)
                {
                    out1 += c.CandidateName + " is elected with a surplus of " + (c.VotesReceived - quota);
                    out1 += "\n";
                    elected.Add(c);
                }
            }




            // Step 2
            // if surplus is greater than the difference between the votes of the last two candidates,
            // the surplus must be transferred.
            // if it is less it won't make any difference, so do anyway...

            // elected got 5 votes, all fully filled in 
            // surplus: 1.67
            // 1.67 / 5 = .33
            // transfervalue = 0.33

            // how many of the electeds votes are transferrable, 
            // if their 2nd preference is elected,    not transferrable
            // if their 2nd preference is eliminated, not transferrable
            // if their 2nd preference is empty,      not transferrable




            foreach (Candidate c in elected)
            {
                out1 += DistributeCandidatesSurplus(c, BallotPapers, quota, elected, out1);
                out1 += "\n";
            }

            out1 += "\n\nafter step 2\n" + ListCanVotes();

            return out1;
        }




        public string getResults1()
        {
            string out1 = "";
            int[] counts = new int[Candidates.Count()];
            foreach (BallotPaper bp in BallotPapers)
            {
                Candidate gotVote = bp.getPreferenceOfInt(1);
                gotVote.gotAVote(1.0);
            }

            // seats : 2
            // total valid vote : 10

            // step 1 
            // quota
            // "The Quota is determined by dividing the total valid vote 
            // by one more than the number of places to be filled,
            // continuing the calculation to two decimal places, and rounding up."

            // 10 / 3 = 3.33 --> 3.34

            double seats = 2;

            double quota = BallotPapers.Count() / (seats + 1);
            quota = Math.Round(quota, 2); // round up some

            out1 += ListCanVotes();
            out1 += "\nquota: " + quota.ToString();
            out1 += "\n";

            // candidate with a vote of that exceeds the quota is deemed elected.
            List<Candidate> elected = new List<Candidate>();
            foreach (Candidate c in Candidates)
            {
                if (c.VotesReceived > quota)
                {
                    out1 += '\n' + c.CandidateName + " is elected with a surplus of " + (c.VotesReceived - quota);
                    elected.Add(c);
                }
            }




            // Step 2
            // if surplus is greater than the difference between the votes of the last two candidates,
            // the surplus must be transferred.
            // if it is less it won't make any difference, so do anyway...

            // elected got 5 votes, all fully filled in 
            // surplus: 1.67
            // 1.67 / 5 = .33
            // transfervalue = 0.33

            // how many of the electeds votes are transferrable, 
            // if their 2nd preference is elected,    not transferrable
            // if their 2nd preference is eliminated, not transferrable
            // if their 2nd preference is empty,      not transferrable




            foreach (Candidate c in elected)
            {
                out1 += "\n";
                out1 += DistributeCandidatesSurplus(c, BallotPapers, quota, elected, out1);
            }

            out1 += "\n\nafter step 2\n" + ListCanVotes();

            return out1;
        }

        public string DistributeCandidatesSurplus( Candidate c, List<BallotPaper> ballotPapers, double quota, List<Candidate> elected, string s2  )
        {
            double surplus = c.VotesReceived - quota;
            double transferValue = surplus / c.VotesReceived;

            string out2 = "\nElected: " + c.CandidateName + " with " + c.VotesReceived + " votes,  tv: "+ transferValue;

            foreach ( BallotPaper b in ballotPapers )
            {
                out2 += "\n\tballot:\n\t" + b.ToString(); // Votes[0].Candidate.CandidateName + "==" + c.CandidateName;
                if ( b.Votes[0].Candidate.CandidateName.Equals( c.CandidateName) )
                {
                    Candidate c2 = b.Votes[1].Candidate;

                    if (!elected.Contains(c2))
                    {
                        out2 += "\n\t\t" + c.CandidateName + " gives " + c2.CandidateName + " " + transferValue;

                        c2.gotAVote(transferValue);
                        //MessageBox.Show("You said: " + " 469: " + c.CandidateName + c.VotesReceived + "ww" + b.Votes[1].Candidate.CandidateName + b.Votes[1].Candidate.VotesReceived + "tv " + transferValue);
                    }

                }
            }
            c.VotesReceived = c.VotesReceived - surplus;
            return out2;
        }

        public string ListCanVotes()
        {
            string out1 = "";
            Candidates.Sort();
            foreach( Candidate c in Candidates )
            {
                out1 += String.Format("{0} got {1} votes\n", c.CandidateName, Math.Round(c.VotesReceived, 2) );
            }
            return out1;
        }
    }







        
        public void ShuffleList( List<int> list)
        {
            // https://stackoverflow.com/questions/273313/randomize-a-listt
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = r.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }


        private void MakeNewContest4()   // simple pr
        {
            ContestCurrent = new Contest();

            ContestCurrent.AddCandidate(new Candidate("John"));
            ContestCurrent.AddCandidate(new Candidate("Mary"));
            ContestCurrent.AddCandidate(new Candidate("Dan "));

            Lsb_Candidates.ItemsSource = ContestCurrent.Candidates;
            Lsb_Candidates.Items.Refresh();


            for (int i = 0; i < 10; i++)
            {
                List<int> prefs = new List<int>();

                BallotPaper b;
                b = new BallotPaper();

                prefs.Add(1);
                prefs.Add(2);
                prefs.Add(3);

                ShuffleList(prefs);

                for (int j = 0; j < ContestCurrent.Candidates.Count(); j++)
                {
                    b.AddVote(new Vote(ContestCurrent.Candidates[j], prefs[j]));
                }

                b.Votes.Sort();
                ContestCurrent.AddBallotPaper(b);
            }

            ContestCurrent.BallotPapers.Sort();
            Lsb_Votes.ItemsSource = ContestCurrent.BallotPapers;
            Lsb_Votes.Items.Refresh();
        }



        
        private void MakeNewContest1()   // simple pr
        {
            Contest  cm = ContestMaker.ExampleContest(); 



            ContestCurrent = new Contest();

            ContestCurrent.AddCandidate(new Candidate("John"));
            ContestCurrent.AddCandidate(new Candidate("Mary"));
            ContestCurrent.AddCandidate(new Candidate("Dan "));

            Lsb_Candidates.ItemsSource = ContestCurrent.Candidates;
            Lsb_Candidates.Items.Refresh();

            BallotPaper b;
            b = new BallotPaper();
            b.AddVote(new Vote(ContestCurrent.Candidates[0], 1));
            b.AddVote(new Vote(ContestCurrent.Candidates[2], 2));
            b.AddVote(new Vote(ContestCurrent.Candidates[1], 3));

            ContestCurrent.AddBallotPaper(b);

            b = new BallotPaper();
            b.AddVote(new Vote(ContestCurrent.Candidates[0], 1));
            b.AddVote(new Vote(ContestCurrent.Candidates[1], 2));
            b.AddVote(new Vote(ContestCurrent.Candidates[2], 3));

            ContestCurrent.AddBallotPaper(b);

            b = new BallotPaper();
            b.AddVote(new Vote(ContestCurrent.Candidates[2], 1));
            b.AddVote(new Vote(ContestCurrent.Candidates[0], 2));
            b.AddVote(new Vote(ContestCurrent.Candidates[1], 1));

            ContestCurrent.AddBallotPaper(b);

            b = new BallotPaper();
            b.AddVote(new Vote(ContestCurrent.Candidates[2], 1));
            b.AddVote(new Vote(ContestCurrent.Candidates[0], 2));
            b.AddVote(new Vote(ContestCurrent.Candidates[1], 3));

            ContestCurrent.AddBallotPaper(b);

            b = new BallotPaper();
            b.AddVote(new Vote(ContestCurrent.Candidates[1], 1));
            b.AddVote(new Vote(ContestCurrent.Candidates[0], 2));
            b.AddVote(new Vote(ContestCurrent.Candidates[2], 3));

            ContestCurrent.AddBallotPaper(b);

            Lsb_Votes.ItemsSource = ContestCurrent.BallotPapers;
            Lsb_Votes.Items.Refresh();
        }



        private void MakeNewContest2()   // simple fpp
        {
            ContestCurrent = new Contest();

            ContestCurrent.AddCandidate(new Candidate("John"));
            ContestCurrent.AddCandidate(new Candidate("Mary"));
            ContestCurrent.AddCandidate(new Candidate("Dan"));

            Lsb_Candidates.ItemsSource = ContestCurrent.Candidates;
            Lsb_Candidates.Items.Refresh();


            BallotPaper b;
            b = new BallotPaper();
            b.AddVote(new Vote(ContestCurrent.Candidates[0], 1));

            ContestCurrent.AddBallotPaper(b);

            b = new BallotPaper();
            b.AddVote(new Vote(ContestCurrent.Candidates[0], 1));

            ContestCurrent.AddBallotPaper(b);

            b = new BallotPaper();
            b.AddVote(new Vote(ContestCurrent.Candidates[2], 1));

            ContestCurrent.AddBallotPaper(b);

            b = new BallotPaper();
            b.AddVote(new Vote(ContestCurrent.Candidates[2], 1));

            ContestCurrent.AddBallotPaper(b);

            b = new BallotPaper();
            b.AddVote(new Vote(ContestCurrent.Candidates[1], 1));
            ContestCurrent.AddBallotPaper(b);

            Lsb_Votes.ItemsSource = ContestCurrent.BallotPapers;
            Lsb_Votes.Items.Refresh();
        }


        private void MakeNewContest3()   // simple fpp
        {
            ContestCurrent = new Contest();

            ContestCurrent.AddCandidate(new Candidate("John"));
            ContestCurrent.AddCandidate(new Candidate("Mary"));
            ContestCurrent.AddCandidate(new Candidate("Dan "));

            Lsb_Candidates.ItemsSource = ContestCurrent.Candidates;
            Lsb_Candidates.Items.Refresh();


            for (int i = 0; i < 10; i++)
            {
                BallotPaper b;
                b = new BallotPaper();
                int rint = r.Next(0, 3 );
                //b.AddVote(new Vote(ContestCurrent.Candidates[r.Next(0, rint )], 1));
                b.AddVote(new Vote(ContestCurrent.Candidates[ rint ], 1));

                ContestCurrent.AddBallotPaper(b);
            }


            Lsb_Votes.ItemsSource = ContestCurrent.BallotPapers;
            Lsb_Votes.Items.Refresh();
        }




        
        
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


    public class Contest
    {
        public List<Candidate> Candidates = new List<Candidate>();
        public List<BallotPaper> BallotPapers = new List<BallotPaper>();

        public void AddCandidate(Candidate candidate)
        {
            Candidates.Add(candidate);
        }
        public void AddBallotPaper(BallotPaper ballotPaper)
        {
            BallotPapers.Add(ballotPaper);
        }
    }



    public class ContestMaker
    {
        static Random r = new Random();
        public static Contest ExampleContest1()
        {
            Contest ContestEx = new Contest();

            ContestEx.AddCandidate(new Candidate("John"));
            ContestEx.AddCandidate(new Candidate("Mary"));
            ContestEx.AddCandidate(new Candidate("Dan "));

            for (int i = 0; i < 10; i++)
            {
                List<int> prefs = new List<int>();

                BallotPaper b;
                b = new BallotPaper();

                prefs.Add(1);
                prefs.Add(2);
                prefs.Add(3);

                //ShuffleList(prefs);

                for (int j = 0; j < ContestEx.Candidates.Count(); j++)
                {
                    b.AddVote(new Vote(ContestEx.Candidates[j], prefs[j]));
                }

                b.Votes.Sort();
                ContestEx.AddBallotPaper(b);
            }

            ContestEx.BallotPapers.Sort();

            return ContestEx;
        }
        public static Contest ExampleContest2( Random r2 )
        {
            Contest ContestEx = new Contest();

            ContestEx.AddCandidate(new Candidate("John"));
            ContestEx.AddCandidate(new Candidate("Mary"));
            ContestEx.AddCandidate(new Candidate("Dan "));

            for (int i = 0; i < 5; i++)
            {
                AddSomeVotes(ContestEx, 3, r2);
            }

            for (int i = 0; i < 5; i++)
            {
                AddSomeVotes(ContestEx, 2, r2);
            }

            for (int i = 0; i < 5; i++)
            {
                AddSomeVotes(ContestEx, 1, r2);
            }

            ContestEx.BallotPapers.Sort();

            return ContestEx;
        }

        public static void AddSomeVotes( Contest ContestEx , int prefsToAdd, Random r2)
        {
            List<int> prefs = new List<int>();

            BallotPaper b;
            b = new BallotPaper();

            for (int j = 0; j < ContestEx.Candidates.Count(); j++)
            {
                prefs.Add(j);
            }

            // prefs = [ 0, 1, 2 ]

            ShuffleList(prefs, r2);

            // prefs = [ 2, 0, 1 ]
            for (int j = 0; j < prefsToAdd; j++)
            {
                // j = 0 , 1, 2
                b.AddVote(new Vote(ContestEx.Candidates[ prefs[ j ] ], j+1 ) ) ;
            }

            b.Votes.Sort();
            ContestEx.AddBallotPaper(b);
        }


        public static void ShuffleList(List<int> list, Random r2 )
        {
            // https://stackoverflow.com/questions/273313/randomize-a-listt
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = r.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
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

        public List<BallotPaper> Transfers { get; set; } 

        public Candidate(string candidateName)
        {
            CandidateName = candidateName;
            Transfers = new List<BallotPaper>();
        }

        public override string ToString()
        {
            return CandidateName;
        }

        public void gotAVote(double voteValue)
        {
            VotesReceived += voteValue;
        }

        public void gotATransfer(BallotPaper transfer)
        {
            Transfers.Add(transfer);
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
/*
 * 
 
seats: 2
total votes: 15
quota: 5

Mary got 6 votes
Dan  got 5 votes
John got 4 votes

Mary is elected with a surplus of 1
Dan  is elected with a surplus of 0

total surplus: 1
diff of 2 lowest : 1
total surplus does not exceed the diference

Mary has the highest surplus

Mary gave no transfer Dan  is elected
Mary gave John a transfer
Mary gave John a transfer
Mary gave John a transfer
Mary gave no transfer 
Mary gave no transfer 

transferrable papers: 3
transfer value: 0.33

John receives 0.33
John receives 0.33
John receives 0.33

Mary got 5.01 votes
Dan  got 5 votes
John got 4.99 votes



     
     
     
     */
