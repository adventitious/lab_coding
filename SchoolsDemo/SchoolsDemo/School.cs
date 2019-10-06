using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolsDemo
{
    class School : IComparable<School>
    {
        private string Name { get; set; }
        private int Pupils { get; set; }

        public School( string argName, int argPupils )
        {
            Name = argName;
            Pupils = argPupils;
        }


        public int CompareTo(School that)
        {
            if (this.Pupils > that.Pupils) return -1;
            if (this.Pupils == that.Pupils) return 0;
            return 1;
        }

        public string ToString()
        {
            string s1 = "School, Name: {0}, Enrollment: {1}";
            string output = String.Format(s1, Name, Pupils);
            return output;
        }
    }
}
