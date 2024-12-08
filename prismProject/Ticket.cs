using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prismProject
{
    internal class Ticket
    {
        public short ticketID;
        public DateTime createDate;
        public string firstName;
        public string lastName;
        public string status;
        public string desc;
        public short employid;

        public Ticket()
        {
            ticketID = 0;
            createDate = DateTime.MinValue;
            firstName = null;
            lastName = null;
            status = null;
            desc = null;
            employid = 0;
        }
        public Ticket(short tickid, DateTime credate, string fn, string ln, string stat, string des, short emplid)
        {
            ticketID = tickid;
            createDate = credate;
            firstName = fn;
            lastName = ln;
            status = stat;
            desc = des;
            employid = emplid;
        }
    }
}
