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
    public partial class EditSocietie : Form
    {
        OracleConnection connection;
        int selectedID, count = 0;
        string selectedname, selectedaddress, selectedPresident, selectedemail;
        public EditSocietie()
        {
            InitializeComponent();
            Load += EditSocietie_Load;
        }


        private void EditSocietie_Load(object sender, EventArgs e)
        {
            string connectionString = @"DATA SOURCE =localhost:1521/xe; USER ID=admin;PASSWORD=admin";
            connection = new OracleConnection(connectionString);
            LoadUserData();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                count = 1;
                listView1_SelectedIndexChanged(sender, e);
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "Delete from societies WHERE id = :oldId";
                command.CommandType = CommandType.Text;
                command.Parameters.Add(":oldId", OracleDbType.Int32).Value = selectedID;
                DialogResult result = MessageBox.Show("Are you sure you want to delete this Society?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    recall();
                    MessageBox.Show("Society Deleted SuccessFully");

                }
                else recall();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            count = 0;
        }

        private void additems_Click(object sender, EventArgs e)
        {
            AddItem addItem = new AddItem();
            this.Hide();
            addItem.Show();

        }

        private void edititems_Click(object sender, EventArgs e)
        {
            EditItem edititem = new EditItem();
            this.Hide();
            edititem.Show();
        }

        private void addsocieties_Click(object sender, EventArgs e)
        {
            AddSociety addSociety = new AddSociety();
            this.Hide();
            addSociety.Show();
        }

        private void getrequirements_Click(object sender, EventArgs e)
        {
            RequirementGathering getrequirements = new RequirementGathering();
            this.Hide();
            getrequirements.Show();
        }

        private void societyRequirements_Click(object sender, EventArgs e)
        {
            SocietyItemRequired societyItemRequired123 = new SocietyItemRequired();
            this.Hide();
            societyItemRequired123.Show();
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

        private void Edit_Click(object sender, EventArgs e)
        {

            try
            {
                count = 1;
                listView1_SelectedIndexChanged(sender, e);
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE societies SET name = :name, CONTACT_PERSON = :CONTACT_PERSON, CONTACT_EMAIL = :CONTACT_EMAIL WHERE id = :Id";
                command.CommandType = CommandType.Text;
                command.Parameters.Add(":name", OracleDbType.Varchar2).Value = societyname.Text;
                command.Parameters.Add(":CONTACT_PERSON", OracleDbType.Varchar2).Value = societypresident.Text;
                command.Parameters.Add(":CONTACT_EMAIL", OracleDbType.Varchar2).Value = societyemail.Text; // corrected line
                command.Parameters.Add(":Id", OracleDbType.Int32).Value = selectedID;
                DialogResult result = MessageBox.Show("Are you sure you want to Edit this Society?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    recall();
                    MessageBox.Show("Society Data Edited SuccessFully");
                }
                else recall();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            count = 0;
        }

        private void recall()
        {
            EditSocietie editSocietie = new EditSocietie();
            this.Hide();
            editSocietie.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0 && count == 1)
            {
                selectedID = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
                listView1.SelectedItems[0].SubItems[0].Text = ID.Text;
                selectedname = listView1.SelectedItems[0].SubItems[1].Text = societyname.Text;
                selectedaddress = listView1.SelectedItems[0].SubItems[2].Text;
                selectedPresident = listView1.SelectedItems[0].SubItems[3].Text = contact.Text;
                selectedemail = listView1.SelectedItems[0].SubItems[4].Text = societyemail.Text;
                count++;
            }
        }

        private void LoadUserData()
        {
            listView1.Items.Clear();

            try
            {
                connection.Open();

                OracleCommand command = new OracleCommand("SELECT * FROM societies order by id asc", connection);
                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["id"].ToString());
                    item.SubItems.Add(reader["name"].ToString());
                    item.SubItems.Add(reader["address"].ToString());
                    item.SubItems.Add(reader["contact_person"].ToString());
                    item.SubItems.Add(reader["contact_email"].ToString());
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
