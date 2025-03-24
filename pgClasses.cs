using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace SwiftSend.C_
{
    public partial class pgClasses : Form
    {
        private DataTable classTable;
        private int currentIndex = 0;

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public pgClasses()
        {
            InitializeComponent();
            LoadClassData();
            DisplayCurrentRecord();
        }

        private void LoadClassData()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblclass", connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    classTable = new DataTable();
                    adapter.Fill(classTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentIndex < classTable.Rows.Count - 1)
            {
                currentIndex++;
                DisplayCurrentRecord();
            }
        }

        private void txtClassName_TextChanged(object sender, EventArgs e)
        {
            // Handle text changed event if needed
        }

        private void DisplayCurrentRecord()
        {
            if (classTable.Rows.Count > 0)
            {
                DataRow row = classTable.Rows[currentIndex];
                txtClid.Text = row["clid"].ToString();
                txtClassName.Text = row["nameClass"].ToString();
                txtYearGroup.Text = row["yearGroup"].ToString();
                txtNumber.Text = row["numbr"].ToString();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentIndex = 0;
            DisplayCurrentRecord();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentIndex = classTable.Rows.Count - 1;
            DisplayCurrentRecord();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayCurrentRecord();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO tblClass (nameClass, yearGroup, numbr) VALUES (@nameClass, @yearGroup, @numbr)", connection);
                    cmd.Parameters.AddWithValue("@nameClass", txtClassName.Text);
                    cmd.Parameters.AddWithValue("@yearGroup", txtYearGroup.Text);
                    cmd.Parameters.AddWithValue("@numbr", int.Parse(txtNumber.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Class added successfully.");
                    LoadClassData();
                    currentIndex = classTable.Rows.Count - 1; // Move to the last record
                    DisplayCurrentRecord();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding class: " + ex.Message);
                }
            }
        }

        private void pgClasses_Load(object sender, EventArgs e)
        {
            // Handle form load event if needed
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string classId = txtClid.Text.Trim();

            if (string.IsNullOrEmpty(classId))
            {
                MessageBox.Show("Please select a class to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM tblClass WHERE clid = @clid", connection);
                    cmd.Parameters.AddWithValue("@clid", classId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Class deleted successfully.");
                    LoadClassData();
                    if (currentIndex >= classTable.Rows.Count)
                    {
                        currentIndex = classTable.Rows.Count - 1;
                    }
                    DisplayCurrentRecord();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting class: " + ex.Message);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var menuForm = new pgMenu();
            menuForm.Show();
            this.Close();
        }
    }
}
