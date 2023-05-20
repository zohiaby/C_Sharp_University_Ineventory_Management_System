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
    public partial class SuperAdminDashboard : Form
    {
        OracleConnection connection;
        int outStockInevtory = 0;
        public SuperAdminDashboard()
        {
            InitializeComponent();
        }
        private void SuperAdminDashboard_Load(object sender, EventArgs e)
        {
            string connectionString = @"DATA SOURCE=localhost:1521/xe; USER ID=admin; PASSWORD=admin";
            connection = new OracleConnection(connectionString);

            

            loadData();
            currenttime.Text = DateTime.Now.ToLongTimeString();// + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");

        }

        private void loadData()
        {
            try
            {

                connection.Open();

                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select CATEGORY,count(*) as count from items group by CATEGORY";
                cmd.CommandType = CommandType.Text;
                OracleDataReader read = cmd.ExecuteReader();

                int totalsoc = 0;
                while (read.Read())
                {
                    string categoryName = read.GetString(0);
                    int totalQuantity = read.GetInt32(1);
                    totalsoc = totalsoc + totalQuantity;
                    string shortenedName = categoryName.Substring(0, Math.Min(10, categoryName.Length));
                    chart3.Series["Inventory"].Points.AddXY(shortenedName, totalQuantity);
                }
                inStock.Text = totalsoc.ToString();
                connection.Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            try
            {
                connection.Open();

                OracleCommand cmd1 = connection.CreateCommand();
                cmd1.CommandText = "SELECT id, COUNT(*) AS outStock FROM items WHERE quantity <= 0 group by id";
                cmd1.CommandType = CommandType.Text;
                OracleDataReader reader = cmd1.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    int outStockProducts = reader.GetInt32(1);
                    outStock.Text = outStockProducts.ToString();
                    outStockInevtory = outStockProducts;
                }
                else
                    outStock.Text = "0";
                connection.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            try
            {
                connection.Open();

                OracleCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "SELECT COUNT(*) AS totalUsers FROM users";
                cmd2.CommandType = CommandType.Text;
                OracleDataReader reader = cmd2.ExecuteReader();
                reader.Read();
                int totalusers = reader.GetInt32(0) - 1;
                tUsers.Text = totalusers.ToString();
                connection.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            try
            {
                connection.Open();

                OracleCommand cmd3 = connection.CreateCommand();
                cmd3.CommandText = "SELECT COUNT(*) AS pendingRequests FROM requirements where status IN ('PENDING', 'Pending', 'pending') ";
                cmd3.CommandType = CommandType.Text;
                OracleDataReader reader = cmd3.ExecuteReader();
                reader.Read();
                string status = reader.GetString(0);
                pRequests.Text = status.ToString();
                connection.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            try
            {

                connection.Open();

                OracleCommand cmd4 = connection.CreateCommand();
                cmd4.CommandText = "SELECT s.name, i.quantity FROM items i JOIN societies s ON i.id = s.id ";
                cmd4.CommandType = CommandType.Text;
                OracleDataReader read = cmd4.ExecuteReader();

                int count = 0;
                while (read.Read())
                {
                    string societyName = read.GetString(0);
                    int totalQuantity = read.GetInt32(1);
                    string shortenedName = societyName.Substring(0, Math.Min(10, societyName.Length));
                    chart1.Series["Societies Inventory"].Points.AddXY(shortenedName, totalQuantity);
                    count++;
                }
                connection.Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            try
            {
                connection.Open();

                OracleCommand cmd5 = connection.CreateCommand();
                cmd5.CommandText = "select count(*) as totalSocie from societies";
                cmd5.CommandType = CommandType.Text;
                OracleDataReader reader = cmd5.ExecuteReader();
                reader.Read();
                int totalsoc = reader.GetInt32(0);
                totalSocieties.Text = totalsoc.ToString();
                connection.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }



        private void adduser_Click(object sender, EventArgs e)
        {
            ManageUsers managedUser = new ManageUsers();
            this.Hide();
            managedUser.Show();
        }

        private void edituser_Click(object sender, EventArgs e)
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

        private void approve_Click(object sender, EventArgs e)
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
