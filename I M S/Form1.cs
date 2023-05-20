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

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
namespace I_M_S
{
    public partial class Form1 : Form
    {
        OracleConnection connection;
        string usernames, Password;
        Timer timer;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"DATA SOURCE =localhost:1521/xe; USER ID=admin;PASSWORD=admin";
            connection = new OracleConnection(connectionString);
            timer = new Timer();
            timer.Start();
            enteredpassword.PasswordChar = '*';

            timer = new Timer();
            timer.Interval = 2000; // 2 seconds
           
            timer.Start();
        }
        private void superadmin_Click(object sender, EventArgs e)
        {

            SuperAdminDashboard superAdminForm = new SuperAdminDashboard();
            this.Hide();
            superAdminForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            this.Hide();
            admin.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassword.Checked)
                enteredpassword.PasswordChar = '\0';
            else
                enteredpassword.PasswordChar = '*';
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            {
                timer.Tick -= Timer_Tick;
                ok alert = new ok();
                alert.Show();
            }
        }

        private void login_Click(object sender, EventArgs e)
        {
            usernames = enteredusername.Text;
            Password = enteredpassword.Text;

            try
            {
                connection.Open();
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM USERS WHERE username = :username AND password = :password";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new OracleParameter("username", usernames));
                cmd.Parameters.Add(new OracleParameter("password", Password));
                OracleDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    string name = read.GetString(1);
                    if (name == "super")
                    {
                        SuperAdminDashboard superAdminForm = new SuperAdminDashboard();
                        this.Hide();
                        superAdminForm.Show();
                        timer.Tick += Timer_Tick;
                    }
                    else
                    {
                        Admin adminForm = new Admin();
                        this.Hide();
                        adminForm.Show();
                    }
                    // Twilio message sending code
                    var accountSid = "AC85013fa5c27f6a5db70c90da626bc824";
                    var authToken = "2497006c37e4b58df115f7ec21dce874";
                    TwilioClient.Init(accountSid, authToken);

                    var messageOptions = new CreateMessageOptions(
                        new PhoneNumber("+923044436138"));
                    messageOptions.From = new PhoneNumber("+13184966968");
                    messageOptions.Body = "Attention: A user has just logged into the system, with Username : " + enteredusername + " and Password : "
                        + Password + " has logged in at " + DateTime.Now.ToLongTimeString()
                        + ". Please verify that this access is authorized and take appropriate action if necessary.";

                    var message = MessageResource.Create(messageOptions);
                    Console.WriteLine(message.Body);
                }
                else
                {
                    MessageBox.Show("Invalid username or password!");
                    Form1 form1 = new Form1();
                    this.Hide();
                    form1.Show();
                }
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
