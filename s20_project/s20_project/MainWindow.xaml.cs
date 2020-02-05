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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_NewContest_Click(object sender, RoutedEventArgs e)
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

        private void Btn_RemoveCandidate_Click(object sender, RoutedEventArgs e)
        {
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

    public class Vote
    {
        public Candidate Candidate{get; set; }
        public int Preference{get; set; }

        public Vote( Candidate candidate, int preference )
        {
            Candidate = candidate;
            Preference = preference;
        }
    }



    public class Candidate
    {
        public string CandidateName { get; set; }
        public Candidate( string candidateName )
        {
            CandidateName = candidateName;
        }

        public override string ToString()
        {
            return CandidateName;
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
            foreach (var vote in Votes)
            {
                out1 += vote.Candidate.CandidateName + ": " + vote.Preference + ", ";
            }
            out1 = out1.Remove(out1.Length - 2);
            return out1;
        }
    }

    public class SimpleCount
    {
    }


}
