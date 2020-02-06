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

                MessageBox.Show("You said: " + " 246: " + ContestCurrent.BallotPapers.Count());

                MessageBox.Show("You said: " + " 248: " + sc.BallotPapers.Count());
                string s = sc.getResults();
                MessageBox.Show("You said: " + " 249: " + sc.BallotPapers.Count());

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
        public int VotesReceived { get; set; }
        public Candidate( string candidateName )
        {
            CandidateName = candidateName;
        }

        public override string ToString()
        {
            return CandidateName;
        }

        public void gotAVote()
        {
            VotesReceived++;
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

        }

        public string getResults()
        {
            /*
            MessageBox.Show("You said: " + " 371: " + BallotPapers.Count());


            double quota = BallotPapers.Count() + 5;// / (seats + 1);

            MessageBox.Show("You said: " + " 376: " + quota);
            */
            string out1 = "";
            int[] counts = new int[Candidates.Count()];
            foreach( BallotPaper bp in BallotPapers )
            {
                Candidate gotVote = bp.getPreferenceOfInt(1);
                gotVote.gotAVote();
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

            // seats : 2
            // total valid vote : 10

            // step 1 
            // quota
            // "The Quota is determined by dividing the total valid vote 
            // by one more than the number of places to be filled,
            // continuing the calculation to two decimal places, and rounding up."

            // 10 / 3 = 10.33 --> 10.34

            double seats = 2;

            double quota= BallotPapers.Count()  / (seats + 1);

            MessageBox.Show("You said: " + " 422: " + quota);

            quota = Math.Round(quota, 2);
            quota = Math.Round(quota, 2);

            //inputValue = Math.Round(inputValue, 2);

            //string q = "" + quota;

            out1 += "qqq" + quota.ToString() + "!";
            out1 += '\n' + ListCanVotes();


            return out1;//+ '\n' + ListCanVotes()
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
