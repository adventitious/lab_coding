using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
namespace LabSheet7b
{
    public class Member
    {
        public string Name { get; set; }
        string MemberType { get; set; }
        DateTime JoinDate { get; set; }

        public Member(string name, string memberType, DateTime joindate)
        {
            Name = name;
            MemberType = memberType;
            JoinDate = joindate;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", Name, MemberType, JoinDate.ToString("dd/MM/yyyy"));
        }
    }


    public partial class MainWindow : Window
    {
        Random r = new Random();

        List<Member> Members;

        public MainWindow()
        {
            InitializeComponent();
            GetRandomDate();
            Members = new List<Member>();

            CmbxMemberType.Items.Add("Full");
            CmbxMemberType.Items.Add("Off Peak");
            CmbxMemberType.Items.Add("Student");
            CmbxMemberType.Items.Add("Oap");

            CmbxMemberType.SelectedItem = "Student";
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Member member = new Member(TxbName.Text, CmbxMemberType.SelectedItem.ToString(), GetRandomDate() );
            Members.Add(member);

            LbxMain.ItemsSource = null;
            LbxMain.ItemsSource = Members;
        }


        public DateTime GetRandomDate()
        {
            DateTime d1 = new DateTime(2015, 1, 1);
            DateTime d2 = new DateTime(2000, 1, 1);

            int days = (int)(d1 - d2).TotalDays;
            int days2 = r.Next(0, days);

            DateTime d3 = d2.AddDays(days2);
            return d3;
        }


        private void LbxMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Member member = LbxMain.SelectedItem as Member;
            TxbName.Text = member.Name;
        }
    }
}
