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
    public partial class SocietyItemRequired : Form
    {
        OracleConnection connection;
        int count = 0;
        string selectedSociety, selecteditem;
        public SocietyItemRequired()
        {
            Load += SocietyItemRequired_Load;
            InitializeComponent();
        }

        private void SocietyItemRequired_Load(object sender, EventArgs e)
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

                OracleCommand command = new OracleCommand("SELECT s.name,r.quantity as required_quantity, i.name as item_name FROM items i INNER JOIN requirements r ON i.id = r.item_id INNER JOIN societies s ON s.id = r.society_id", connection);
                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["name"].ToString());
                    item.SubItems.Add(reader["required_quantity"].ToString());
                    item.SubItems.Add(reader["item_name"].ToString());
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0 && count == 1)
            {
                selectedSociety = listView1.SelectedItems[0].SubItems[1].Text = society.Text;
                selecteditem = listView1.SelectedItems[0].SubItems[2].Text = itemnam.Text;
                count++;
            }
        }

        private void assignitem_Click(object sender, EventArgs e)
        {
            try
            {
                count = 1;
                listView1_SelectedIndexChanged(sender, e);
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE requirements SET quantity = :quantity WHERE society_id = (SELECT id FROM societies WHERE name = :societyName) AND item_id = (SELECT id FROM items WHERE name = :itemName)";
                command.CommandType = CommandType.Text;
                command.Parameters.Add(":quantity", OracleDbType.Int32).Value = quentityee.Text; // corrected line
                command.Parameters.Add(":societyName", OracleDbType.Varchar2).Value = selectedSociety;
                command.Parameters.Add(":itemName", OracleDbType.Varchar2).Value = selecteditem;
                DialogResult result = MessageBox.Show("Are you sure you want to Edit this Item Quantity?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    recall();
                    MessageBox.Show("Item Quantity Edited SuccessFully");
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

        private void recall()
        {
           SocietyItemRequired societyItemRequired123 = new SocietyItemRequired();
            this.Hide();
            societyItemRequired123.Show();
        }


    }
}
