using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SwiftSend.C_
{
    public partial class pgEmailCommunication : Form
    {
        private readonly string connectionString;
        private int currentClassIndex = 0;
        private DataTable classData;
        private string? attachmentPath = null; // To store the file path of the attachment
        private List<EmailTemplate> templates = new List<EmailTemplate>();

        public pgEmailCommunication()
        {
            InitializeComponent();

            // Initialize the connection string
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"]?.ConnectionString ?? string.Empty;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Connection string is missing. Please check App.config.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1); // Exit the application
            }

            LoadClasses();
            LoadTemplateNames();
        }

        private void LoadClasses()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "SELECT DISTINCT clid FROM tblstudents";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            classData = new DataTable();
                            adapter.Fill(classData);

                            if (classData.Rows.Count > 0)
                            {
                                SetCurrentClass();
                            }
                            else
                            {
                                MessageBox.Show("No classes found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBox1.Text = string.Empty;
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetCurrentClass()
        {
            if (classData.Rows.Count > 0)
            {
                textBox1.Text = classData.Rows[currentClassIndex]["clid"].ToString();
                LoadEmailsForClass(textBox1.Text.Trim());
            }
        }

        private void LoadEmailsForClass(string classId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = @"SELECT email, forename, surname FROM tblstudents WHERE clid = @clid";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@clid", classId);

                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            checkedListBox1.Items.Clear(); // Clear the list for new data

                            if (!reader.HasRows)
                            {
                                MessageBox.Show("No students found in this class.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            while (reader.Read())
                            {
                                string email = reader["email"].ToString();
                                string fullName = $"{reader["forename"]} {reader["surname"]}";

                                // Add email with student name as display text to CheckedListBox
                                checkedListBox1.Items.Add($"{fullName} <{email}>", true);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            // Cycle through the classes
            if (classData.Rows.Count > 0)
            {
                currentClassIndex = (currentClassIndex + 1) % classData.Rows.Count;
                SetCurrentClass();
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string subject = txtTitle.Text.Trim();
            string message = txtMessage.Text.Trim();

            if (string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get all checked email addresses
            var selectedEmails = checkedListBox1.CheckedItems.Cast<string>()
                                .Select(item => item.Split('<')[1].Trim('>'))
                                .ToList();

            if (selectedEmails.Count == 0)
            {
                MessageBox.Show("Please select at least one email recipient.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Show the pgEmailConfirmation form to get the email and password
            using (var confirmationForm = new pgEmailConfirmation())
            {
                if (confirmationForm.ShowDialog() == DialogResult.OK)
                {
                    string email = confirmationForm.Email;
                    string password = confirmationForm.Password;

                    // Send emails
                    SendEmails(selectedEmails, subject, message, email, password);
                }
            }
        }

        private void SendEmails(List<string> emails, string subject, string message, string email, string password)
        {
            try
            {
                foreach (var recipient in emails)
                {
                    SendEmail(recipient, subject, message, email, password);
                }

                MessageBox.Show("Emails sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while sending emails: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendEmail(string recipient, string subject, string message, string email, string password)
        {
            try
            {
                using (SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com"))
                {
                    smtp.Port = 587;
                    smtp.Credentials = new NetworkCredential(email, password);
                    smtp.EnableSsl = true;

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(email, "Your Name"); // Replace "Your Name" with your name
                        mail.Subject = subject;
                        mail.Body = $"Dear Recipient,\n\n{message}";
                        mail.IsBodyHtml = false;

                        mail.To.Add(recipient);

                        // Attach files if available
                        if (!string.IsNullOrEmpty(attachmentPath))
                        {
                            foreach (var filePath in attachmentPath.Split(';'))
                            {
                                if (File.Exists(filePath))
                                {
                                    Attachment attachment = new Attachment(filePath);
                                    mail.Attachments.Add(attachment);
                                }
                            }
                        }

                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to send email to {recipient}: {ex.Message}");
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif|All Files|*.*";
                openFileDialog.Title = "Select Image Files to Attach";
                openFileDialog.Multiselect = true; // Allow multiple file selection

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    attachmentPath = string.Join(";", openFileDialog.FileNames); // Store the file paths as a semicolon-separated string
                    listBoxAttachments.Items.Clear();
                    foreach (var fileName in openFileDialog.FileNames)
                    {
                        listBoxAttachments.Items.Add(Path.GetFileName(fileName));
                    }
                    MessageBox.Show($"Files selected for attachment: {string.Join(", ", openFileDialog.FileNames.Select(Path.GetFileName))}", "Files Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void LoadTemplateNames()
        {
            comboBoxTemplates.Items.Clear();
            templates.Clear();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT tpid, templateName, templateTitle, templateMessage FROM tblTemplate ORDER BY tpid";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var template = new EmailTemplate
                            {
                                Tpid = reader.GetInt32("tpid"),
                                Name = reader.GetString("templateName"),
                                Title = reader.GetString("templateTitle"),
                                Message = reader.GetString("templateMessage")
                            };
                            templates.Add(template);
                            comboBoxTemplates.Items.Add(template.Name);
                        }
                    }
                }
            }
        }

        private void comboBoxTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedTemplate = templates.Find(t => t.Name == comboBoxTemplates.SelectedItem.ToString());
            if (selectedTemplate != null)
            {
                txtTitle.Text = selectedTemplate.Title;
                txtMessage.Text = selectedTemplate.Message;
            }
        }

        private void btnManageTemplates_Click(object sender, EventArgs e)
        {
            using (var templateForm = new pgEmailTemplate())
            {
                templateForm.ShowDialog();
                LoadTemplateNames();
            }
        }

        private void listBoxAttachments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var menuForm = new pgMenu();
            menuForm.Show();
            this.Close();
        }
    }

    public class EmailTemplate
    {
        public int Tpid { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
