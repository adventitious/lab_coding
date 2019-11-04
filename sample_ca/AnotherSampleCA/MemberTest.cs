using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherSampleCA
{
    class MemberTest
    {
        public MemberTest()
        {
            Console.WriteLine("===== Club Member Details =====" );

            Member[] members = new Member[5];
            
            members[0] = new Member("Pat", "Kelly", 23, "1022");
            members[1] = new Member("Jim", "Jones", 17, "2167");
            members[2] = new Member("Pa", "Kiernan", 33, "1234");
            members[3] = new Member("Lucy", "Lipton", 44, "2032");
            members[4] = new Member("Mary", "Kennedy", 13, "2022");

            Console.WriteLine("=== Member Details ===");
            MemberDetails( members );

            members[0].ChangeStatus();
            members[2].ChangeStatus();
            

            Console.WriteLine();
            Console.WriteLine("=== Club Member Details Status Changed ==="); 
            MemberDetails(members);


            List<Member> list1 = new List<Member>();

            // list1.Sort();
            Array.Sort( members );
            Array.Reverse( members );
            Console.WriteLine();
            Console.WriteLine("=== Club Member Details Sort Reverse ===");
            MemberDetails(members);

            Console.WriteLine("\nmember count: {0}\n", Member.MemberCount );
        }

        private void MemberDetails( Member[] members )
        {
            foreach( Member m in members )
            {
                Console.WriteLine( m.ToString() );
            }
        }

    }
}
