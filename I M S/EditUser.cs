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
    public partial class EditUser : Form
    {
        OracleConnection connection;
        int selectedID, count = 0;
        string selectedUserNmae, selectedPassword;

        public EditUser()
        {
            InitializeComponent();
            Load += EditUser_Load;
        }

        private void EditUser_Load(object sender, EventArgs e)
        {
            string connectionString = @"DATA SOURCE =localhost:1521/xe; USER ID=admin;PASSWORD=admin";
            connection = new OracleConnection(connectionString);
            LoadUserData();
        }
        private void recall()
        {
            EditUser edituser = new EditUser();
            this.Hide();
            edituser.Show();
        }

        private void Edit_Click_1(object sender, EventArgs e)
        {
            try
            {
                count = 1;
                listView1_SelectedIndexChanged(sender, e);
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE Users SET username = :name, password = :password WHERE id = :Id";
                command.CommandType = CommandType.Text;
                command.Parameters.Add(":name", OracleDbType.Varchar2).Value = newUserName.Text;
                command.Parameters.Add(":password", OracleDbType.Varchar2).Value = NewPassword.Text;
                command.Parameters.Add(":Id", OracleDbType.Int32).Value = selectedID;
                DialogResult result = MessageBox.Show("Are you sure you want to Edit this User?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    recall();
                    MessageBox.Show("User Data Edited SuccessFully");
                }
                else recall();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void Delete_Click_1(object sender, EventArgs e)
        {
            try
            {
                count = 1;
                listView1_SelectedIndexChanged(sender, e);
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "Delete from Users WHERE id = :oldId";
                command.CommandType = CommandType.Text;
                command.Parameters.Add(":oldId", OracleDbType.Int32).Value = selectedID;
                DialogResult result = MessageBox.Show("Are you sure you want to delete this User?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    recall();
                    MessageBox.Show("User Data Deleted SuccessFully");

                }
                else recall();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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

        private void logingdetails_Click(object sender, EventArgs e)
        {
            UserLogoingDetails userLogoingDetails = new UserLogoingDetails();
            this.Hide();
            userLogoingDetails.Show();
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
               if (listView1.SelectedItems.Count > 0 && count == 1)
                {
                   selectedID = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
                   ID.Text = selectedID.ToString();
                   selectedUserNmae = listView1.SelectedItems[0].SubItems[1].Text;
                   userName.Text = selectedUserNmae;
                   selectedPassword = listView1.SelectedItems[0].SubItems[2].Text;
                   passwords.Text = selectedPassword;
                   count++;
               }
               else
               {
                   count = 0;
               }
        }

        private void logout2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

       


        private void LoadUserData()
        {
            listView1.Items.Clear();

            try
            {
                connection.Open();

                OracleCommand command = new OracleCommand("SELECT * FROM users where id <> 1 order by id asc", connection);
                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["id"].ToString());
                    item.SubItems.Add(reader["username"].ToString());
                    item.SubItems.Add(reader["password"].ToString());
                    item.SubItems.Add(reader["is_admin"].ToString());
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


    }
}
