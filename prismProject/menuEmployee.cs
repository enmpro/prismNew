using prismProject;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace prismProject
{
    public partial class menuEmployee : BaseForm
    {

        public menuEmployee()
        {
            InitializeComponent();
            
        }

        private void menuEmployee_Load(object sender, EventArgs e)
        {
            FormHelper.newLocation(this);
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=prismDatabase.accdb");
            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            cmd.Connection = con;
            // use to fetch rows from demo table
            cmd.CommandText = "Select * from Ticket Where UserID = ?";
            cmd.Parameters.AddWithValue("?", EmployeeData.listIndex);

            // to execute the sql statement
            cmd.ExecuteNonQuery();
            // use to read each row in table
            OleDbDataReader datareader = cmd.ExecuteReader();

            int ticket_index = 0;
            string tickid, credate, ticket_name, stat, desc, emplid;
            short empl_id, ticket_id = 0;
            DateTime create_date = DateTime.Now;

            listTicket.View = View.Details;
            listTicket.FullRowSelect = true;
            listTicket.MultiSelect = true;
            listTicket.Columns.Add("Ticket #");
            listTicket.Columns.Add("Ticket Name", 150);
            listTicket.Columns.Add("Date", 150);
            listTicket.Columns.Add("Status", 150);
            listTicket.Columns.Add("Description", 250);
            listTicket.Columns.Add("Software", 150);
            listTicket.Columns.Add("SoftwareType", 150);
            while (datareader.Read())
            {
                tickid = datareader["TicketID"].ToString();
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
                listTicket.Items.Add(new ListViewItem(new string[] { tickid, ticket_name, credate, stat, desc }));
                listTicket.GridLines = true;

                ticket_index++;
            }
            con.Close();
        }

        // options employee can use
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            FormHelper.saveLocation(this);
            ticketReq t = new ticketReq();
            if (newTick.Checked)
            {
                t.Show();
                this.Hide();
            }
            if (editTick.Checked)
            {
                if (listTicket.SelectedItems.Count == 1)
                {
                    int ticketID = int.Parse(listTicket.SelectedItems[0].Text);
                    ticketEdit editForm = new ticketEdit(ticketID);
                    editForm.Show();
                    this.Hide();
                }
                else if (listTicket.SelectedItems.Count > 1)
                {
                    MessageBox.Show("Please select only one ticket to edit.");
                }
                else
                {
                    MessageBox.Show("Please select a ticket to edit.");
                }
            }
            if (deleteTick.Checked)
            {
                recordsToClose();
            }
        }

        private void closeRecord(List<int> ids)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=prismDatabase.accdb");
            con.Open();
            foreach (int id in ids)
            { // update the database
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Ticket SET [Status] = \"Closed\" WHERE TicketID = @ID";
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
        private void recordsToClose()
        {
            if (listTicket.SelectedItems.Count > 0)
            { // change the status from open to closed in one or more rec
                List<int> ids = new List<int>();
                foreach (ListViewItem selectedItem in listTicket.SelectedItems)
                {
                    ids.Add(int.Parse(selectedItem.Text));
                }

                // delete
                closeRecord(ids);

                //foreach (ListViewItem selectedItem in listTicket.SelectedItems)
                //{
                //    listTicket.Items.Remove(selectedItem);
                //}

                MessageBox.Show("Selected records deleted successfully!");
            }
            else
            {
                MessageBox.Show("Please select one or more records to delete.");
            }
        }

    }
}
