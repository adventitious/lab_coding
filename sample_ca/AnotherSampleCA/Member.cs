using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherSampleCA
{
    class Member : IComparable<Member>
    {
        //e First Name, Last Name, Age, MemberID and MembershipStatus





        #region properties
        private readonly double _price;
        public double Price
        {
            get
            {
                return _price;
            }
        }

        public static int MemberCount { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age{ get; set; }
        public string MemberID{ get; set; }
        public string MembershipStatus{ get; set; }

        #endregion properties

        public Member(string firstName, string lastName, int age, string memberID )
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            MemberID = memberID;
            MembershipStatus = "expired";
            if( Age < 18 )
            {
                _price = 50;
            }
            else
            {
                _price = 150;
            }

            MemberCount++;
        }

        public void ChangeStatus()
        {
            if( MembershipStatus == "expired")
            {
                MembershipStatus = "current";
            }
            else
            {
                MembershipStatus = "expired";
            }
        }

        public override string ToString()
        {
            string s0 = "first name: {0}, last name: {1}, age: {2}, ID: {3}, status: {4}, price: {5}";
            string s1 = string.Format(s0, FirstName, LastName, Age, MemberID, MembershipStatus, Price );
            return s1;
        }

        public int CompareTo(Member that)
        {
            bool b1 = string.Compare(this.LastName, that.LastName) < 0;
            if( b1 )
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}
