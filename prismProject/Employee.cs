using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prismProject
{
    internal class Employee
    {
        public short userID;
        public string username;
        public string password;
        public string department;
        public string firstName;
        public string lastName;

        public Employee()
        {
            userID = 0;
            username = "";
            password = "";
            department = "";
            firstName = "";
            lastName = "";
        }
        public Employee(short usid, string usnam, string pw, string dep, string fn, string ln)
        {
            userID = usid;
            username = usnam;
            password = pw;
            department = dep;
            firstName = fn;
            lastName = ln;
        }
    }
}
