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
    public partial class ticketReq : BaseForm
    {
        private LinkedList programList;
        public ticketReq()
        {
            InitializeComponent();

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
        //create ticket button code
        private void btnCreate_Click(object sender, EventArgs e)
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
            requestTicket();
            resetComboBoxes();
        }
        //back to main menu
        private void btnGoBack_Click(object sender, EventArgs e)
        {
            FormHelper.saveLocation(this);
            menuEmployee display = new menuEmployee();
            display.lblLIS.Text = "Welcome to PRISM, " + EmployeeData.employees[EmployeeData.listIndex - 1].username;
            display.Show();
            this.Hide();
        }
        // request the ticket
        private void requestTicket()
        {
            string query = "INSERT INTO Ticket (TicketName, CreationDate, FirstName, LastName, Status, Type, Description, UserID) " +
                           "VALUES (@tick, @creadate, @fn, @ln, @stat, @type, @desc, @userid)";

            // Connect to the database
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=prismDatabase.accdb";
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    string createDate = DateTime.Now.ToString("MM/dd/yyyy");

                    // Add parameters and display their values
                    cmd.Parameters.AddWithValue("@tick", ticketName.Text);
                    cmd.Parameters.AddWithValue("@creadate", createDate);
                    cmd.Parameters.AddWithValue("@fn", EmployeeData.employees[10].firstName);
                    cmd.Parameters.AddWithValue("@ln", EmployeeData.employees[EmployeeData.listIndex - 1].lastName);
                    cmd.Parameters.AddWithValue("@stat", "Open");
                    cmd.Parameters.AddWithValue("@type", helpType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@desc", ticketDesc.Text);
                    cmd.Parameters.AddWithValue("@userid", EmployeeData.employees[EmployeeData.listIndex - 1].userID);

                    try
                    { // ticket added
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Ticket Successfully Added!");
                        con.Close();
                        clearTextSelection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
        // clear the text after submitting
        private void clearTextSelection()
        {
            helpType.ResetText();
            prgType.ResetText();
            prgName.ResetText();
            ticketName.Clear();
            ticketDesc.Clear();
        }
        //need this to reset the selections for the comboboxes
        private void resetComboBoxes()
        {

            helpType.Items.Clear();
            prgType.Items.Clear();
            prgName.Items.Clear();
            lblProgName.Visible = false;
            lblProgType.Visible = false;
            prgType.Visible = false;
            prgType.Enabled = false;
            prgName.Visible = false;
            prgName.Enabled = false;

            helpType.Items.AddRange(new string[] { "General", "Networking", "Program" });
            
            addProgramType();
            prgType.SelectedIndexChanged += new EventHandler(prgTypeSelectedItem);
            helpType.SelectedIndex = -1;
            prgType.SelectedIndex = -1;
            prgName.SelectedIndex = -1;
        }

        private void ticketReq_Load(object sender, EventArgs e)
        {
            FormHelper.newLocation(this);
        }
    }
}
