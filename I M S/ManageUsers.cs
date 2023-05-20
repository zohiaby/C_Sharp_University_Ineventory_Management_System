using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace I_M_S
{
    public partial class ManageUsers : Form
    {
        OracleConnection connection;

        public ManageUsers()
        {
            InitializeComponent();
            Load += ManageUsers_Load;
        }
        private void ManageUsers_Load(object sender, EventArgs e)
        {
            string connectionString = @"DATA SOURCE =localhost:1521/xe; USER ID=admin;PASSWORD=admin";
            connection = new OracleConnection(connectionString);
        }

        private void addnewusers_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO users (id, username, password) VALUES (:id, :username, :password)";
                command.CommandType = CommandType.Text;
                command.Parameters.Add(":id", OracleDbType.Int32).Value = Convert.ToInt32(newid.Text);
                command.Parameters.Add(":username", OracleDbType.Varchar2).Value = newUserName.Text;
                command.Parameters.Add(":password", OracleDbType.Varchar2).Value = NewPassword.Text;
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (OracleException ex)
            {
                if (ex.Number == 1) // Unique constraint violation error number
                {
                    MessageBox.Show("User with this ID already exists!");
                    ManageUsers managedUser = new ManageUsers();
                    this.Hide();
                    managedUser.Show();
                }
                else
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dasboard_Click_1(object sender, EventArgs e)
        {
            SuperAdminDashboard superAdminForm = new SuperAdminDashboard();
            this.Hide();
            superAdminForm.Show();
        }

        private void edituser_Click(object sender, EventArgs e)
        {
            EditUser edituser = new EditUser();
            this.Hide();
            edituser.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UserLogoingDetails userLogoingDetails = new UserLogoingDetails();
            this.Hide();
            userLogoingDetails.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ApproveRequirements approverequirement = new ApproveRequirements();
            this.Hide();
            approverequirement.Show();
        }

        private void logout1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void logout2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

    }
}
