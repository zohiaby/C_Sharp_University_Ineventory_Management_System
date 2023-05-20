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
    public partial class AddItem : Form
    {
        OracleConnection connection;
        public AddItem()
        {
            InitializeComponent();
            Load += AddItem_Load;
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


        private void AddItem_Load(object sender, EventArgs e)
        {
            string connectionString = @"DATA SOURCE =localhost:1521/xe; USER ID=admin;PASSWORD=admin";
            connection = new OracleConnection(connectionString);
        }
        private void addnewitems_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO items (id, name, category, quantity, description) VALUES (:id, :name, :category, :quantity, :description)";
                command.CommandType = CommandType.Text;
                command.Parameters.Add(":id", OracleDbType.Int32).Value = Convert.ToInt32(itemid.Text);
                command.Parameters.Add(":name", OracleDbType.Varchar2).Value = itemName.Text;
                command.Parameters.Add(":category", OracleDbType.Varchar2).Value = itemCategory.Text;
                command.Parameters.Add(":quantity", OracleDbType.Int32).Value = Convert.ToInt32(itemquantity.Text);
                command.Parameters.Add(":description", OracleDbType.Varchar2).Value = itemdiscription.Text;
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Item Added Successfully");
                AddItem addItem = new AddItem();
                this.Hide();
                addItem.Show();
            }
            catch (OracleException ex)
            {
                if (ex.Number == 1) // Unique constraint violation error number
                {
                    MessageBox.Show("Item with this ID already exists!");
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
    }
}
