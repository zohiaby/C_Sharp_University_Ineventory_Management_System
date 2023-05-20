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
    public partial class ApproveRequirements : Form
    {
        OracleConnection connection;
        int selectedid, count = 0;
        public ApproveRequirements()
        {
            InitializeComponent();
            Load += ApproveRequirements_Load;
        }

        private void ApproveRequirements_Load(object sender, EventArgs e)
        {
            string connectionString = @"DATA SOURCE =localhost:1521/xe; USER ID=admin;PASSWORD=admin";
            connection = new OracleConnection(connectionString);
            LoadUserData();
        }
        private void LoadUserData()
        {
            listView1.Items.Clear();

            try
            {
                connection.Open();

                OracleCommand command = new OracleCommand("SELECT * FROM requirements where status = 'PENDING' order by id asc", connection);
                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["id"].ToString());
                    item.SubItems.Add(reader["society_id"].ToString());
                    item.SubItems.Add(reader["item_id"].ToString());
                    item.SubItems.Add(reader["quantity"].ToString());
                    item.SubItems.Add(reader["status"].ToString());
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
        private void recall()
        {
            ApproveRequirements approverequirement = new ApproveRequirements();
            this.Hide();
            approverequirement.Show();
        }
        private void approve_Click_1(object sender, EventArgs e)
        {
            try
            {
                count = 1;
                listView1_SelectedIndexChanged_1(sender, e);
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE requirements SET status = 'APPROVED' WHERE id = :Id";
                command.CommandType = CommandType.Text;
                command.Parameters.Add(":Id", OracleDbType.Int32).Value = selectedid;
                DialogResult result = MessageBox.Show("Are you sure you want to Approve this Requirement?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    recall();
                    MessageBox.Show("Requirement Approved SuccessFully");
                }
                else recall();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void dasboard_Click_1(object sender, EventArgs e)
        {
            SuperAdminDashboard superAdminForm = new SuperAdminDashboard();
            this.Hide();
            superAdminForm.Show();
        }

        private void addusers_Click(object sender, EventArgs e)
        {
            ManageUsers managedUser = new ManageUsers();
            this.Hide();
            managedUser.Show();
        }

        private void editusers_Click(object sender, EventArgs e)
        {
            EditUser edituser = new EditUser();
            this.Hide();
            edituser.Show();
        }

        private void logingdetails_Click(object sender, EventArgs e)
        {
            UserLogoingDetails userLogoingDetails = new UserLogoingDetails();
            this.Hide();
            userLogoingDetails.Show();
        }

        private void logout_Click(object sender, EventArgs e)
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

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0 && count == 1)
            {
                selectedid = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
                listView1.SelectedItems[0].SubItems[0].Text = ID.Text;
                count++;
            }
        }
    }
}
