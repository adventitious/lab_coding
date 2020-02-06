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

namespace s20_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Contest ContestCurrent;

        Random r = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //MakeNewContest();
        }

        private void Btn_NewContest_Click(object sender, RoutedEventArgs e)
        {
            MakeNewContest4();

            doSimpleCount();


            //MessageBox.Show("You said: " + " qqq: " );
        }


        private void MakeNewContest1()   // simple pr
        {
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

                ContestCurrent.AddBallotPaper(b);
            }

            Lsb_Votes.ItemsSource = ContestCurrent.BallotPapers;
            Lsb_Votes.Items.Refresh();
        }




        private void Btn_RemoveCandidate_Click(object sender, RoutedEventArgs e)
        {
            int rint = r.Next(0, 3);
            MessageBox.Show("You said: " + " qqq: " + rint);
        }



        private void Btn_Count_Click(object sender, RoutedEventArgs e)
        {
            doSimpleCount();
        }


        private void doSimpleCount()
        {
            try
            {
                SimpleCount sc = new SimpleCount(ContestCurrent.Candidates, ContestCurrent.BallotPapers);

                //MessageBox.Show("You said: " + " 246: " + ContestCurrent.BallotPapers.Count());

                string s = sc.getResults();
                
                Txb_Results.Text = s;
            }
            catch ( Exception exc)
            {
                MessageBox.Show("You said: " + " wwww: " + exc.Message);
            }
        }
    }

    public class Contest
    {
        public List<Candidate> Candidates = new List<Candidate>();
        public List<BallotPaper> BallotPapers = new List<BallotPaper>();

        public void AddCandidate(Candidate candidate)
        {
            Candidates.Add(candidate);
        }
        public void AddBallotPaper( BallotPaper ballotPaper)
        {
            BallotPapers.Add(ballotPaper);
        }
    }

    public class Vote : IComparable<Vote>
    {
        public Candidate Candidate{get; set; }
        public int Preference{get; set; }

        public Vote( Candidate candidate, int preference )
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
        public Candidate( string candidateName )
        {
            CandidateName = candidateName;
        }

        public override string ToString()
        {
            return CandidateName;
        }

        public void gotAVote( double voteValue )
        {
            VotesReceived += voteValue;
        }

        public int CompareTo(Candidate that)
        {
            return that.VotesReceived.CompareTo(VotesReceived);
        }
    }

    public class BallotPaper
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

        public Candidate getPreferenceOfInt( int preference )
        {
            foreach (Vote vote in Votes)
            {
                if( vote.Preference == preference )
                {
                    return vote.Candidate;
                }
            }
            return null;
        }
    }

    public class SimpleCount
    {
        public List<Candidate> Candidates;
        public List<BallotPaper> BallotPapers;

        public SimpleCount( List<Candidate> candidates, List<BallotPaper> ballotPapers )
        {

            Candidates = candidates;
            BallotPapers = ballotPapers;

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

        public string getResults()
        {
            string out1 = "";
            int[] counts = new int[Candidates.Count()];
            foreach( BallotPaper bp in BallotPapers )
            {
                Candidate gotVote = bp.getPreferenceOfInt(1);
                gotVote.gotAVote( 1.0 );
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

            double quota= BallotPapers.Count()  / (seats + 1);
            quota = Math.Round(quota, 2); // round up some

            out1 += "quota: " + quota.ToString();
            out1 += '\n' + ListCanVotes();

            // candidate with a vote of that exceeds the quota is deemed elected.
            List<Candidate> elected = new List<Candidate>();
            foreach (Candidate c in Candidates)
            {
                if (c.VotesReceived > quota )
                {
                    out1 += '\n' + c.CandidateName + " is elected with a surplus of "+ (c.VotesReceived - quota);
                    elected.Add(c);
                    //Candidates.Remove(c);
                    
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
            // if theur no2 is elected not txable


            

            // public void DistributeCandidatesSurplus( Candidate c, List<BallotPaper> ballotPapers, double quota )

            foreach ( Candidate c in elected )
            {
                out1 += DistributeCandidatesSurplus(c, BallotPapers, quota, elected, out1);
            }
            
            out1 += "\nafter step 2\n" + ListCanVotes();


            return out1;
        }

        public string DistributeCandidatesSurplus( Candidate c, List<BallotPaper> ballotPapers, double quota, List<Candidate> elected, string s2  )
        {
            string out2 = "\nElected:" + c.CandidateName + " : " + c.VotesReceived;

            double surplus = c.VotesReceived - quota;
            double transferValue = surplus / c.VotesReceived;

            foreach ( BallotPaper b in ballotPapers )
            {
                out2 += "\n" + b.ToString(); // Votes[0].Candidate.CandidateName + "==" + c.CandidateName;
                if ( b.Votes[0].Candidate.CandidateName.Equals( c.CandidateName) )
                {
                    out2 += "\n" + "me:" + c.CandidateName;


                    Candidate c2 = b.Votes[1].Candidate;
                    out2 += "\n" + "my no 2:" + c2.CandidateName;
                    out2 += "\n" + "give " + c2.CandidateName + " " + transferValue;


                    if (elected.Contains(c2))
                    {
                        out2 += "\nno don't";
                    }
                    else
                    {
                        out2 += "\nya do";
                        c2.gotAVote(transferValue);
                        //MessageBox.Show("You said: " + " 469: " + c.CandidateName + c.VotesReceived + "ww" + b.Votes[1].Candidate.CandidateName + b.Votes[1].Candidate.VotesReceived + "tv " + transferValue);
                    }


                    out2 += "\n";
                    /*
                    Candidate c2 = b.Votes[1].Candidate;
                    s2 += "\n" + c2.CandidateName + " : " + c2.VotesReceived;
*/
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
                out1 += String.Format("{0} got {1} votes\n", c.CandidateName, c.VotesReceived );
            }
            return out1;
        }
    }
}
