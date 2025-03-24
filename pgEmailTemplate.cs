using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SwiftSend.C_
{
    public partial class pgEmailTemplate : Form
    {
        private readonly string connectionString;

        public pgEmailTemplate()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"]?.ConnectionString ?? string.Empty;
            LoadTemplateNames();
        }

        private void LoadTemplateNames()
        {
            comboBoxTemplates.Items.Clear();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT templateName FROM tblTemplate";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxTemplates.Items.Add(reader["templateName"].ToString());
                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtTemplateName.Text.Trim();
            string title = txtTemplateTitle.Text.Trim();
            string message = txtMessage.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "UPDATE tblTemplate SET templateTitle = @title, templateMessage = @message WHERE templateName = @name";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@message", message);
                    cmd.ExecuteNonQuery();
                }
            }

            LoadTemplateNames();
            MessageBox.Show("Template saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBoxTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTemplateName = comboBoxTemplates.SelectedItem.ToString();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM tblTemplate WHERE templateName = @name";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", selectedTemplateName);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtTemplateName.Text = reader["templateName"].ToString();
                            txtTemplateTitle.Text = reader["templateTitle"].ToString();
                            txtMessage.Text = reader["templateMessage"].ToString();
                        }
                    }
                }
            }
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            var menuForm = new pgMenu();
            menuForm.Show();
            this.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string name = txtTemplateName.Text.Trim();
            string title = txtTemplateTitle.Text.Trim();
            string message = txtMessage.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "INSERT INTO tblTemplate (templateName, templateTitle, templateMessage) VALUES (@name, @title, @message)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@message", message);
                    cmd.ExecuteNonQuery();
                }
            }

            LoadTemplateNames();
            MessageBox.Show("Template inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            string name = txtTemplateName.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please select a template to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "DELETE FROM tblTemplate WHERE templateName = @name";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                }
            }

            LoadTemplateNames();
            MessageBox.Show("Template deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtTemplateName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
