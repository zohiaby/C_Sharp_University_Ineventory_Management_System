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
    public partial class EditItem : Form
    {
        OracleConnection connection;
        int selectedID, selectedQuanity, count = 0;
        string selectedNmae, selectedCatageory;
        public EditItem()
        {
            InitializeComponent();
        }
        private void EditItem_Load(object sender, EventArgs e)
        {
            string connectionString = @"DATA SOURCE =localhost:1521/xe; USER ID=admin;PASSWORD=admin";
            connection = new OracleConnection(connectionString);
            LoadUserData();
        }
        private void recall()
        {
            EditItem edititem = new EditItem();
            this.Hide();
            edititem.Show();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            try
            {
                count = 1;
                listView1_SelectedIndexChanged(sender, e);
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE items SET name = :name, category = :catageory, quantity = :quantity WHERE id = :Id";
                command.CommandType = CommandType.Text;
                command.Parameters.Add(":name", OracleDbType.Varchar2).Value = editname.Text;
                command.Parameters.Add(":category", OracleDbType.Varchar2).Value = editcatageory.Text;
                command.Parameters.Add(":quantity", OracleDbType.Int32).Value = editquentity.Text; // corrected line
                command.Parameters.Add(":Id", OracleDbType.Int32).Value = selectedID;
                DialogResult result = MessageBox.Show("Are you sure you want to Edit this Item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    recall();
                    MessageBox.Show("Item Data Edited SuccessFully");
                }
                else recall();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            count = 0;
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                count = 1;
                listView1_SelectedIndexChanged(sender, e);
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "Delete from items WHERE id = :oldId";
                command.CommandType = CommandType.Text;
                command.Parameters.Add(":oldId", OracleDbType.Int32).Value = selectedID;
                DialogResult result = MessageBox.Show("Are you sure you want to delete this Item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    recall();
                    MessageBox.Show("Item Data Deleted SuccessFully");

                }
                else recall();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            count = 0;

        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0 && count == 1)
            {
                selectedID = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
                listView1.SelectedItems[0].SubItems[0].Text = ID.Text;
                selectedNmae = listView1.SelectedItems[0].SubItems[1].Text = name.Text;
                selectedCatageory = listView1.SelectedItems[0].SubItems[2].Text = catageory.Text;
                selectedQuanity = Convert.ToInt32(listView1.SelectedItems[0].SubItems[3].Text);
                listView1.SelectedItems[0].SubItems[3].Text = quantity.Text;
                count++;
            }
        }


        private void LoadUserData()
        {
            listView1.Items.Clear();

            try
            {
                connection.Open();

                OracleCommand command = new OracleCommand("SELECT * FROM items order by id asc", connection);
                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["id"].ToString());
                    item.SubItems.Add(reader["name"].ToString());
                    item.SubItems.Add(reader["category"].ToString());
                    item.SubItems.Add(reader["quantity"].ToString());
                    item.SubItems.Add(reader["description"].ToString());
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

        private void additems_Click(object sender, EventArgs e)
        {
            AddItem addItem = new AddItem();
            this.Hide();
            addItem.Show();
        }


        private void addsocieties_Click(object sender, EventArgs e)
        {
            AddSociety addSociety = new AddSociety();
            this.Hide();
            addSociety.Show();
        }

        private void editsocieties_Click(object sender, EventArgs e)
        {
            EditSocietie editSocietie = new EditSocietie();
            this.Hide();
            editSocietie.Show();

        }

        private void getrequirements_Click(object sender, EventArgs e)
        {
            RequirementGathering getrequirements = new RequirementGathering();
            this.Hide();
            getrequirements.Show();
        }

        private void editname_TextChanged(object sender, EventArgs e)
        {
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
    }
}
