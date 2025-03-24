using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SwiftSend.C_
{
    public partial class pgAuthentication : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public pgAuthentication()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void pgAuthentication_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Basic validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (AuthenticateUser(username, password))
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pgMenu pgMenu = new pgMenu();
                pgMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            bool isAuthenticated = false;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("AuthenticateUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add input parameters for username and password
                    cmd.Parameters.Add(new MySqlParameter("@username", username));
                    cmd.Parameters.Add(new MySqlParameter("@password", password));  // Plain password

                    conn.Open();
                    var result = cmd.ExecuteScalar();

                    // Check if result is 1 (authenticated)
                    if (result != null && Convert.ToInt32(result) == 1)
                    {
                        isAuthenticated = true;
                    }
                }
            }

            return isAuthenticated;
        }

        private void X_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
