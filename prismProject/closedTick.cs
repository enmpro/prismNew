using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prismProject
{
    public partial class closedTick : Form
    {
        public closedTick()
        {
            InitializeComponent();
        }

        private void closedTick_Load(object sender, EventArgs e)
        {
            string tickid, tickType, credate, closedDate, ticket_name, stat, desc, emplid;
            short empl_id, ticket_id = 0;
            DateTime create_date = DateTime.Now;

            closeTickView.View = View.Details;
            closeTickView.FullRowSelect = true;
            closeTickView.Columns.Add("Ticket #");
            closeTickView.Columns.Add("Close Date");
            closeTickView.Columns.Add("Ticket Name", 150);
            closeTickView.Columns.Add("Type", 100);
            closeTickView.Columns.Add("Date", 150);
            closeTickView.Columns.Add("Status", 150);
            closeTickView.Columns.Add("Description", 250);
            closeTickView.Columns.Add("Software", 150);
            closeTickView.Columns.Add("SoftwareType", 150);


            // database
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=prismDatabase.accdb");
            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            cmd.Connection = con;
            // use to fetch rows from demo table
            cmd.CommandText = "Select * from Ticket WHERE [Status] = \"Closed\"";
            cmd.Parameters.AddWithValue("?", EmployeeData.listIndex);

            // to execute the sql statement
            cmd.ExecuteNonQuery();
            // use to read each row in table
            OleDbDataReader datareader = cmd.ExecuteReader();

            while (datareader.Read())
            {
                tickid = datareader["TicketID"].ToString();
                closedDate = datareader["CloseDateTime"].ToString();
                tickType = datareader["Type"].ToString();
                credate = datareader["CreationDate"].ToString();
                ticket_name = datareader["TicketName"].ToString();
                stat = datareader["Status"].ToString();
                desc = datareader["Description"].ToString();
                emplid = datareader["UserID"].ToString();

                ticket_id = Int16.Parse(tickid);
                empl_id = Int16.Parse(emplid);
                create_date = DateTime.Parse(credate);
                //Ticket ticketRec = new Ticket(ticket_id, create_date, fn, ln, stat, desc, empl_id);
                //ticketList.Add(ticketRec);
                closeTickView.Items.Add(new ListViewItem(new string[] { tickid, closedDate, ticket_name, tickType, credate, stat, desc }));
                closeTickView.GridLines = true;


            }
            con.Close();
        }
    }
}
