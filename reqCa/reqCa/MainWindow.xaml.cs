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

namespace reqCa
{
    public class Goal
    {
        public string Name { get; set; }
        public Action[] Actions { get; set; }
        public int Progress { get; set; }
        public int GoalComplete { get; set; }
        static int GoalCount;
        public List<Event> Events { get; set; }

        public Goal( string name, Action[] actions, int goalComplete )
        {
            GoalCount++;
            Name = string.Format("Goal {0}: {1}", GoalCount, name);
            Actions = actions;
            GoalComplete = goalComplete;
            Events = new List<Event>();
        }

        public void AddEvent( Event argEvent )
        {
            if( Progress < GoalComplete )
            {
                Events.Add(argEvent);
                Progress += argEvent.EventAction.Progress;
                string s0 = "Event added: {0} \n{1}\nProgress: {2} out of {3}";
                string s1 = string.Format(s0, argEvent.EventAction.Name, Name, Progress, GoalComplete);
                if (Progress >= GoalComplete)
                {
                    s1 += "\nGoal complete";
                    Events.Add(new Event(new Action("goal completed", Progress), argEvent.EventDateTime));
                }
                MessageBox.Show(s1, "Message", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Goal completed", "Message", MessageBoxButton.OK);
            }
            
        }

        public string ListEvents()
        {
            string s1 = "";
            foreach( Event ev in Events )
            {
                s1 += ev.EventDateTime.ToString();
                s1 += "\t" + ev.EventAction.Progress;
                s1 += "\t" + ev.EventAction.Name;
                s1 += "\n";
            }
            return s1;
        }

        public override string ToString()
        {
            return Name;
        }
    }


    public class Action
    {
        public string Name { get; set; }
        public int Progress { get; set; }

        public Action( string name, int progress )
        {
            Name = name;
            Progress = progress;
        }
        public override string ToString()
        {
            return Name;
        }
    }

    public class Event
    {
        public Action EventAction{ get; set; }
        public DateTime EventDateTime { get; set; }

        public Event( Action action, DateTime dateTime )
        {
            EventAction = action;
            EventDateTime = dateTime;
        }
    }


    public partial class MainWindow : Window
    {
        List<Goal> GoalList;
        Action[] actionsStudy;
        Action[] actionsEat;
        Action[] actionsExercise;
        public MainWindow()
        {
            InitializeComponent();

            Rdo_Study.IsChecked = (true);

            GoalList = new List<Goal>();

            Lsb_Goals.ItemsSource = GoalList;

            actionsStudy = new Action[3];
            actionsStudy[0] = new Action("read a book", 2);
            actionsStudy[1] = new Action("finished homework", 1);
            actionsStudy[2] = new Action("attended class", 1);

            actionsEat = new Action[3];
            actionsEat[0] = new Action("ate takeaway", -1);
            actionsEat[1] = new Action("made salad", 2);
            actionsEat[2] = new Action("ate vegetables", 1);

            actionsExercise = new Action[3];
            actionsExercise[0] = new Action("went running", 2);
            actionsExercise[1] = new Action("went walking", 1);
            actionsExercise[2] = new Action("did nothing", -1);
        }

        private void Btn_AddGoal_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)Rdo_Study.IsChecked)
            {
                AddGoal(Rdo_Study.Content.ToString(), actionsStudy, 5);
            }
            if ((bool)Rdo_Eat.IsChecked)
            {
                AddGoal(Rdo_Eat.Content.ToString(), actionsEat, 7);
            }
            if ((bool)Rdo_Exercise.IsChecked)
            {
                AddGoal(Rdo_Exercise.Content.ToString(), actionsExercise, 20);
            }
        }


        public void AddGoal(string goalName, Action[] action, int progress)
        {
            GoalList.Add(new Goal(goalName, action, progress));
            Lsb_Goals.Items.Refresh();
            Lsb_Goals.SelectedIndex = Lsb_Goals.Items.Count - 1;
        }


        private void Lsb_Goals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Goal goal = (Goal)Lsb_Goals.SelectedItem;
            Lsb_Actions.ItemsSource = goal.Actions;
            Lsb_Actions.SelectedIndex = 0;

            Txb_Events.Text = goal.ListEvents();
        }

        private void Btn_AddEvent_Click(object sender, RoutedEventArgs e)
        {
            Action action = (Action)Lsb_Actions.SelectedItem;
            Event my_event = new Event( action, DateTime.Now );
            Goal goal = (Goal)Lsb_Goals.SelectedItem;
            goal.AddEvent(my_event);
            Txb_Events.Text = goal.ListEvents();
        }
    }
}
