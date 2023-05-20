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
    public partial class UserLogoingDetails : Form
    {
        OracleConnection connection;

        public UserLogoingDetails()
        {
            InitializeComponent();
            Load += UserLogoingDetails_Load;
        }

        private void UserLogoingDetails_Load(object sender, EventArgs e)
        {
            string connectionString = @"DATA SOURCE=localhost:1521/xe;USER ID=admin;PASSWORD=admin;";
            connection = new OracleConnection(connectionString);
            LoadUserData();
        }

        private void LoadUserData()
        {
            listView1.Items.Clear();

            try
            {
                connection.Open();

                OracleCommand command = new OracleCommand("SELECT logs.id AS log_id, items.name AS item_name, societies.name AS society_name, users.username, logs.action_type, logs.quantity, logs.timestamp FROM logs INNER JOIN items ON logs.item_id = items.id INNER JOIN societies ON logs.society_id = societies.id INNER JOIN users ON logs.user_id = users.id", connection);
                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["log_id"].ToString());
                    item.SubItems.Add(reader["username"].ToString());
                    item.SubItems.Add(reader["item_name"].ToString());
                    item.SubItems.Add(reader["society_name"].ToString());
                    item.SubItems.Add(reader["action_type"].ToString());
                    item.SubItems.Add(reader["quantity"].ToString());
                    item.SubItems.Add(reader["timestamp"].ToString());
                    listView1.Items.Add(item);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void dasboard_Click(object sender, EventArgs e)
        {
            SuperAdminDashboard superAdminForm = new SuperAdminDashboard();
            this.Hide();
            superAdminForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManageUsers managedUser = new ManageUsers();
            this.Hide();
            managedUser.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EditUser edituser = new EditUser();
            this.Hide();
            edituser.Show();
        }

        private void approve_Click(object sender, EventArgs e)
        {
            ApproveRequirements approverequirement = new ApproveRequirements();
            this.Hide();
            approverequirement.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }
    }
}
