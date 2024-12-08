using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using prismProject;

namespace prismProject
{
    public partial class loginScreen : BaseForm
    {

        string lisname, department = "";
        short user_id = 0;
        public loginScreen()
        {
            InitializeComponent();
            //key press handler for the enter key
            txtUser.KeyPress += new KeyPressEventHandler(textBoxEnter);
            txtPass.KeyPress += new KeyPressEventHandler(textBoxEnter);
        }

        // the enter button can also be used using this method
        private void textBoxEnter(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                submitLogin();
            }
        }


        private void loginScreen_Load(object sender, EventArgs e)
        {
            //Connect to the database
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=prismDatabase.accdb");
            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            cmd.Connection = con;
            // use to fetch rows from employee table
            cmd.CommandText = "Select * from Employee";

            // to execute the sql statement
            cmd.ExecuteNonQuery();
            // use to read each row in table
            OleDbDataReader datareader = cmd.ExecuteReader();


            int employee_index = 0;
            string uid, un, pw, dp, fn, ln;
            short uid2 = 0;
            // for one by one reading row
            while (datareader.Read())
            {
                uid = datareader["UserID"].ToString(); // convert to string
                un = datareader["Username"].ToString();
                pw = datareader["Password"].ToString();
                dp = datareader["Department"].ToString();
                fn = datareader["FirstName"].ToString();
                ln = datareader["LastName"].ToString();

                //convert strings to numbers
                uid2 = Int16.Parse(uid); //convert to short
                //Add to the vector
                //Employee emplyrec = new Employee(uid2, un, pw, dp, fn, ln);
                EmployeeData.addEmployee(new Employee(uid2, un, pw, dp, fn, ln));
                //employees.Add(emplyrec);
                employee_index++;
            }

            con.Close();
        }

        private void submitLogin()
        {
            string entUser = "", entPass = "";
            bool loginOK = false;

            entUser = txtUser.Text;
            entPass = txtPass.Text;

            for (int u = 0; u < EmployeeData.employees.Count; u++)
            {
                // check if login is in the database
                if (entUser == EmployeeData.employees[u].username && entPass == EmployeeData.employees[u].password)
                {
                    loginOK = true;
                    lisname = EmployeeData.employees[u].username;
                    user_id = EmployeeData.employees[u].userID;
                    department = EmployeeData.employees[u].department;
                    EmployeeData.setListIndex(user_id);
                    break;

                }
            }

            txtUser.Text = "";
            txtPass.Text = "";

            if (loginOK)
            {
                if (department.Contains("IT"))
                {
                    FormHelper.saveLocation(this);
                    //open Display 
                    menuAdmin d = new menuAdmin();
                    d.lblLIS.Text = "Welcome to PRISM, " + lisname;
                    d.lblLIS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    d.Show();
                    this.Hide();
                } else
                {
                    FormHelper.saveLocation(this);
                    //open Display 
                    menuEmployee display = new menuEmployee();
                    display.lblLIS.Text = "Welcome to PRISM, " + lisname;
                    display.lblLIS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    display.Show();
                    this.Hide();
                }

               
            }
            else
            {
                MessageBox.Show("Wrong Username or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {

            string entUser = "", entPass = "";
            bool loginOK = false;

            entUser = txtUser.Text;
            entPass = txtPass.Text;

            for (int u = 0; u < EmployeeData.employees.Count; u++)
            {
                // check if login is in the database
                if (entUser == EmployeeData.employees[u].username && entPass == EmployeeData.employees[u].password)
                {
                    loginOK = true;
                    lisname = EmployeeData.employees[u].username;
                    user_id = EmployeeData.employees[u].userID;
                    department = EmployeeData.employees[u].department;
                    
                    EmployeeData.setListIndex(user_id);
                    break;

                }
            }

            txtUser.Text = "";
            txtPass.Text = "";

            if (loginOK)
            {
                if (department.Contains("IT"))
                {
                    FormHelper.saveLocation(this);
                    //open Display 
                    menuAdmin d = new menuAdmin();
                    d.lblLIS.Text = "Welcome to PRISM, " + lisname;
                    d.lblLIS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    d.Show();
                    this.Hide();
                }
                else
                {
                    FormHelper.saveLocation(this);
                    //open Display 
                    menuEmployee display = new menuEmployee();
                    display.lblLIS.Text = "Welcome to PRISM, " + lisname;
                    display.lblLIS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    display.Show();
                    this.Hide();
                }
            }
            else
            {

                MessageBox.Show("Wrong Username or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
