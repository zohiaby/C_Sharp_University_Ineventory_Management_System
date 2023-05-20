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
    public partial class RequirementGathering : Form
    {
        OracleConnection connection;
        public RequirementGathering()
        {
            InitializeComponent();
            Load += RequirementGathering_Load;
        }

        private void RequirementGathering_Load(object sender, EventArgs e)
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

                OracleCommand command = new OracleCommand("SELECT * FROM requirements order by id asc", connection);
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
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO requirements (id, society_id, item_id, quantity) VALUES (:id, :society_id, :item_id, :quantity)";
                command.CommandType = CommandType.Text;
                command.Parameters.Add(":id", OracleDbType.Int32).Value = Convert.ToInt32(rid.Text);
                command.Parameters.Add(":society_id", OracleDbType.Int32).Value = Convert.ToInt32(rsocietyid.Text);
                command.Parameters.Add(":item_id", OracleDbType.Int32).Value = Convert.ToInt32(ritemid.Text);
                command.Parameters.Add(":quantity", OracleDbType.Int32).Value = Convert.ToInt32(rquantity.Text);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Requirement Locked Successfully");
                RequirementGathering getrequirement = new RequirementGathering();
                this.Hide();
                getrequirement.Show();
            }
            catch (OracleException ex)
            {
                if (ex.Number == 1) // Unique constraint violation error number
                {
                    MessageBox.Show("Requirement with this ID already exists!");
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
