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
    public partial class ok : Form
    {
        OracleConnection connection;
        int outStockInevtory = 0;
        Timer timer;
        public ok()
        {
            InitializeComponent();
        }

        private void Alert_Load(object sender, EventArgs e)
        {
            string connectionString = @"DATA SOURCE=localhost:1521/xe; USER ID=admin; PASSWORD=admin";
            connection = new OracleConnection(connectionString);
            loadData();
            // Initialize Timer control
            if (outStockInevtory !=0)
            {
                timer = new Timer();
                timer.Interval = 10000; // 2 seconds
                timer.Tick += Timer_Tick;
                timer.Start();
            }
            else
            {
                timer = new Timer();
                timer.Interval = 1;
                timer.Tick += Timer_Tick;
                timer.Start();
            }
        }

        private void loadData()
        {
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
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Tick -= Timer_Tick;
            this.Hide();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            timer.Tick -= Timer_Tick;
            this.Hide();
        }
    }
}
