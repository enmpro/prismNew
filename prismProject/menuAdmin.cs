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
    public partial class menuAdmin : BaseForm
    {
        public menuAdmin()
        {
            InitializeComponent();
        }



        private void menuAdmin_Load(object sender, EventArgs e)
        {
            FormHelper.newLocation(this);

            string tickid, fn, ln, tickType, credate, ticket_name, stat, desc, emplid, softName, softType;
            short empl_id, ticket_id = 0;
            DateTime create_date = DateTime.Now;

            listTicket.View = View.Details;
            listTicket.FullRowSelect = true;
            listTicket.Columns.Add("Ticket #");
            listTicket.Columns.Add("Ticket Name", 150);
            listTicket.Columns.Add("First Name", 100);
            listTicket.Columns.Add("Last Name", 100);
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
                fn = datareader["FirstName"].ToString();
                ln = datareader["LastName"].ToString();
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
                listTicket.Items.Add(new ListViewItem(new string[] { tickid, ticket_name, fn, ln, tickType, credate, stat, desc }));
                listTicket.GridLines = true;


            }

            foreach (ListViewItem item in listTicket.Items)
            {
                int ticketID = int.Parse(item.SubItems[0].Text);

                if (item.SubItems[4].Text == "Program")
                {

                    using (OleDbCommand cmd2 = con.CreateCommand())
                    {

                        cmd2.CommandText = "SELECT Software.SoftwareName, Software.[Type] " +
                                          "FROM Software " +
                                          "INNER JOIN Ticket ON Ticket.SoftwareID = Software.SoftwareID " +
                                          "WHERE Ticket.TicketID = ?";

                        cmd2.Parameters.Clear();
                        cmd2.Parameters.AddWithValue("?", ticketID);

                        using (OleDbDataReader datareader2 = cmd2.ExecuteReader())
                        {
                            if (datareader2.Read())
                            {

                                item.SubItems.Add(datareader2["SoftwareName"].ToString());
                                item.SubItems.Add(datareader2["Type"].ToString());
                            }

                        }
                    }
                }
                
            }
            con.Close();
        }

        // resolve the issues, simulation
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (listTicket.SelectedItems.Count > 0)
            {
                int ticketID = int.Parse(listTicket.SelectedItems[0].Text);
                if (repairOpt.Checked)
                {
                    clientHelpSimulation popup = new clientHelpSimulation("Repair");
                    popup.ShowDialog();
                    // database connections
                    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=prismDatabase.accdb";
                    using (OleDbConnection con = new OleDbConnection(connectionString))
                    {
                        con.Open();
                        string query = $"UPDATE Ticket SET Status = \"Closed\", CloseDateTime = #{DateTime.Now}# WHERE TicketID = @tickid";

                        using (OleDbCommand cmd = new OleDbCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@tickid", ticketID);
                            cmd.ExecuteNonQuery();

                        }
                        con.Close();
                    }
                }

                if (installOpt.Checked && (listTicket.SelectedItems[0].SubItems[4].Text == "Program"))
                {
                    clientHelpSimulation popup = new clientHelpSimulation("Install");
                    popup.ShowDialog();
                    // database connections
                    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=prismDatabase.accdb";
                    using (OleDbConnection con = new OleDbConnection(connectionString))
                    {
                        con.Open();
                        string query = $"UPDATE Ticket SET Status = \"Closed\", CloseDateTime = #{DateTime.Now}# WHERE TicketID = @tickid";

                        using (OleDbCommand cmd = new OleDbCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@tickid", ticketID);
                            cmd.ExecuteNonQuery();

                        }
                        con.Close();
                    }
                }

                if (uninstallOpt.Checked && (listTicket.SelectedItems[0].SubItems[4].Text == "Program"))
                {
                    clientHelpSimulation popup = new clientHelpSimulation("Uninstall");
                    popup.ShowDialog();
                    // database connections
                    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=prismDatabase.accdb";
                    using (OleDbConnection con = new OleDbConnection(connectionString))
                    {
                        con.Open();
                        string query = $"UPDATE Ticket SET Status = \"Closed\", CloseDateTime = #{DateTime.Now}# WHERE TicketID = @tickid";

                        using (OleDbCommand cmd = new OleDbCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@tickid", ticketID);
                            cmd.ExecuteNonQuery();

                        }
                        con.Close();
                    }
                }
            } else
            {
                MessageBox.Show("Please choose a ticket.");
                return;
            }
           

            if (closedOpt.Checked)
            {
                closedTick closedTick = new closedTick();
                closedTick.Show();
            }
        }
    }
}
