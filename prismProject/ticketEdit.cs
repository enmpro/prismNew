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
using System.Windows.Forms.VisualStyles;

namespace prismProject
{
    public partial class ticketEdit : BaseForm
    {
        private int ticketID;
        private LinkedList programList;
        public ticketEdit(int ticketID)
        {
            InitializeComponent();
            this.ticketID = ticketID;

            // linked list for the programs and their types
            programList = new LinkedList();

            // database connections
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=prismDatabase.accdb";
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                con.Open();
                string query = "SELECT [Type], [SoftwareName] FROM Software";

                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    using (OleDbDataReader datareader = cmd.ExecuteReader())
                    {
                        while (datareader.Read())
                        {
                            string typeAdd = datareader.GetString(0);
                            string progAdd = datareader.GetString(1);
                            programList.Add(typeAdd, progAdd);
                        }
                    }
                }
                con.Close();
            }

            // ticket type request
            helpType.Items.AddRange(new string[] { "General", "Networking", "Program" });
            helpType.SelectedIndexChanged += new EventHandler(helpTypeSelectedItem);

            lblProgName.Visible = false;
            lblProgType.Visible = false;
            prgType.Visible = false;
            prgType.Enabled = false;
            prgName.Visible = false;
            prgName.Enabled = false;

            // program type list added
            addProgramType();
            prgType.SelectedIndexChanged += new EventHandler(prgTypeSelectedItem);
        }

        private void addProgramType()
        {
            prgType.Items.Clear();
            foreach (string programType in programList.GetProgramTypes())
            {
                prgType.Items.Add(programType);
            }
        }

        private void prgTypeSelectedItem(object sender, EventArgs e)
        {
            string selectedProgramType = prgType.SelectedItem.ToString();
            addProgram(selectedProgramType);
        }

        private void addProgram(string programType)
        {
            prgName.Items.Clear();
            foreach (string program in programList.GetProgramsByType(programType))
            {
                prgName.Items.Add(program);
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            FormHelper.saveLocation(this);
            menuEmployee display = new menuEmployee();
            display.lblLIS.Text = "Welcome to PRISM, " + EmployeeData.employees[EmployeeData.listIndex - 1].username;
            display.Show();
            this.Hide();
        }


        //hides the text box whether the type is relevant
        private void helpTypeSelectedItem(object sender, EventArgs e)
        {
            if (helpType.SelectedItem.ToString() == "General")
            {
                lblProgName.Visible = false;
                lblProgType.Visible = false;
                prgType.Visible = false;
                prgType.Enabled = false;
                prgName.Visible = false;
                prgName.Enabled = false;
            }
            if (helpType.SelectedItem.ToString() == "Networking")
            {
                lblProgName.Visible = false;
                lblProgType.Visible = false;
                prgType.Visible = false;
                prgType.Enabled = false;
                prgName.Visible = false;
                prgName.Enabled = false;
            }

            if (helpType.SelectedItem.ToString() == "Program")
            {
                lblProgName.Visible = true;
                lblProgType.Visible = true;
                prgType.Visible = true;
                prgType.Enabled = true;
                prgName.Visible = true;
                prgName.Enabled = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // check if stuff is empty
            if (helpType.SelectedItem == null)
            {
                MessageBox.Show("No empty values!");
                return;
            }
            if (string.IsNullOrEmpty(ticketName.Text))
            {
                MessageBox.Show("No empty values!");
                return;
            }
            if (string.IsNullOrEmpty(ticketDesc.Text))
            {
                MessageBox.Show("No empty values!");
                return;
            }
            if (prgType.SelectedItem == null && (prgType.Enabled == true))
            {
                MessageBox.Show("No empty values!");
                return;
            }
            if (prgName.SelectedItem == null && (prgName.Enabled == true))
            {
                MessageBox.Show("No empty values!");
                return;
            }
            using (OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=prismDatabase.accdb"))
            {
                con.Open();
                using (OleDbCommand cmd = con.CreateCommand())
                { // update ticket name and desc
                    cmd.CommandText = "UPDATE Ticket SET TicketName = @TicketName, Description = @Description, [Type] = @Type WHERE TicketID = @TicketID";
                    cmd.Parameters.AddWithValue("@TicketName", ticketName.Text);
                    cmd.Parameters.AddWithValue("@Description", ticketDesc.Text);
                    cmd.Parameters.AddWithValue("@Type", helpType.SelectedItem.ToString());

                    

                    cmd.Parameters.AddWithValue("@TicketID", ticketID);
                    cmd.ExecuteNonQuery();
                }

                if (helpType.SelectedItem.ToString() == "Program")
                {
                    int softwareID = GetSoftwareID(prgName.SelectedItem.ToString(), prgType.SelectedItem.ToString());
                    using (OleDbCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE Ticket " +
                            "SET SoftwareID = @id";
                        cmd.Parameters.AddWithValue("@id", softwareID);
                        cmd.ExecuteNonQuery();
                    }
                }

                con.Close();
            }
            
            MessageBox.Show("Ticket updated successfully!");
        }

        // get the software id
        private int GetSoftwareID(string softwareName, string softwareType)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=prismDatabase.accdb";
            string query = "SELECT SoftwareID FROM Software WHERE SoftwareName = @name AND [Type] = @type";
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                con.Open();
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", softwareName);
                    cmd.Parameters.AddWithValue("@type", softwareType);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        // load the ticket in
        private void ticketEdit_Load(object sender, EventArgs e)
        {
            FormHelper.newLocation(this);
            using (OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=prismDatabase.accdb"))
            {
                con.Open();
                using (OleDbCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Ticket WHERE TicketID = @TicketID";
                    cmd.Parameters.AddWithValue("@TicketID", ticketID);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ticketName.Text = reader["TicketName"].ToString();
                            ticketDesc.Text = reader["Description"].ToString();
                            helpType.SelectedItem = reader["Type"].ToString();
                            
                        }
                    }
                    if (helpType.Text == "Program")
                    {
                        cmd.CommandText = "SELECT Software.SoftwareName, Software.Type " +
                        "FROM Software " +
                        "INNER JOIN Ticket ON Ticket.SoftwareID = Software.SoftwareID " +
                        "WHERE Ticket.TicketID = @TicketID";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@TicketID", ticketID);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                prgType.SelectedItem = reader["Type"].ToString();
                                prgName.SelectedItem = reader["SoftwareName"].ToString();
                            }
                        }
                    }
                    


                }
                con.Close();
            }
        }

        
    }
}
