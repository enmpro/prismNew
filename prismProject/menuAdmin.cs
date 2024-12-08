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
    public partial class menuAdmin : BaseForm
    {
        public menuAdmin()
        {
            InitializeComponent();
        }

        private void menuAdmin_Load(object sender, EventArgs e)
        {
            FormHelper.newLocation(this);
            
            string tickid, tickType, credate, ticket_name, stat, desc, emplid;
            short empl_id, ticket_id = 0;
            DateTime create_date = DateTime.Now;

            listTicket.View = View.Details;
            listTicket.FullRowSelect = true;
            listTicket.MultiSelect = true;
            listTicket.Columns.Add("Ticket #");
            listTicket.Columns.Add("Ticket Name", 150);
            listTicket.Columns.Add("Type", 100);
            listTicket.Columns.Add("Date", 150);
            listTicket.Columns.Add("Status", 150);
            listTicket.Columns.Add("Description", 250);
            listTicket.Columns.Add("Software", 150);
            listTicket.Columns.Add("SoftwareType", 150);

            // database
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=prismDatabase.accdb");
            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            cmd.Connection = con;
            // use to fetch rows from demo table
            cmd.CommandText = "Select * from Ticket WHERE [Status] = \"Open\"";
            cmd.Parameters.AddWithValue("?", EmployeeData.listIndex);

            // to execute the sql statement
            cmd.ExecuteNonQuery();
            // use to read each row in table
            OleDbDataReader datareader = cmd.ExecuteReader();

            while (datareader.Read())
            {
                tickid = datareader["TicketID"].ToString();
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
                listTicket.Items.Add(new ListViewItem(new string[] { tickid, ticket_name, tickType, credate, stat, desc }));
                listTicket.GridLines = true;


            }
            con.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (repairOpt.Checked)
            {

            }

            if (installOpt.Checked)
            {

            }

            if (uninstallOpt.Checked)
            {

            }

            if (closedOpt.Checked)
            {

            }
        }
    }
}
