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
    public partial class AddSociety : Form
    {
        OracleConnection connection;

        public AddSociety()
        {
            InitializeComponent();
            Load += AddSociety_Load;
        }

        private void AddSociety_Load(object sender, EventArgs e)
        {
            string connectionString = @"DATA SOURCE =localhost:1521/xe; USER ID=admin;PASSWORD=admin";
            connection = new OracleConnection(connectionString);
        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO societies (id, name, address, contact_person, contact_email) VALUES (:id, :name, :address, :contact_person, :contact_email)";
                command.CommandType = CommandType.Text;
                command.Parameters.Add(":id", OracleDbType.Int32).Value = Convert.ToInt32(id.Text);
                command.Parameters.Add(":name", OracleDbType.Varchar2).Value = name.Text;
                command.Parameters.Add(":address", OracleDbType.Varchar2).Value = adress.Text;
                command.Parameters.Add(":contact_person", OracleDbType.Varchar2).Value = president.Text;
                command.Parameters.Add(":contact_email", OracleDbType.Varchar2).Value = email.Text;
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Society Added Successfully");
                AddSociety addSociety = new AddSociety();
                this.Hide();
                addSociety.Show();
            }
            catch (OracleException ex)
            {
                if (ex.Number == 1) // Unique constraint violation error number
                {
                    MessageBox.Show("Society with this ID already exists!");
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
    }
}

