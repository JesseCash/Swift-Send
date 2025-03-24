using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace SwiftSend.C_
{
    public partial class pgStudents : Form
    {
        private DataTable studentTable;
        private int currentIndex = 0;
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public pgStudents()
        {
            InitializeComponent();
            LoadClassNames();
        }

        private void LoadClassNames()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT clid, nameClass FROM tblClass";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxClasses.Items.Add(new { clid = reader["clid"], nameClass = reader["nameClass"].ToString() });
                        }
                    }
                }
            }
            comboBoxClasses.DisplayMember = "nameClass";
            comboBoxClasses.ValueMember = "clid";
        }

        private void LoadStudentData(int classId)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblStudents WHERE clid = @clid", connection);
                    cmd.Parameters.AddWithValue("@clid", classId);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    studentTable = new DataTable();
                    adapter.Fill(studentTable);
                    DisplayCurrentRecord();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void DisplayCurrentRecord()
        {
            if (studentTable.Rows.Count > 0)
            {
                DataRow row = studentTable.Rows[currentIndex];
                txtStid.Text = row["stid"].ToString();
                txtTitle.Text = row["title"].ToString();
                txtForename.Text = row["forename"].ToString();
                txtSurname.Text = row["surname"].ToString();
                txtEmail.Text = row["email"].ToString();
            }
        }

        private void comboBoxClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxClasses.SelectedItem != null)
            {
                LoadStudentData(((dynamic)comboBoxClasses.SelectedItem).clid);
            }
        }

        private void btnFirst_Click_1(object sender, EventArgs e)
        {
            currentIndex = 0;
            DisplayCurrentRecord();
        }

        private void btnLast_Click_1(object sender, EventArgs e)
        {
            currentIndex = studentTable.Rows.Count - 1;
            DisplayCurrentRecord();
        }

        private void btnPrevious_Click_1(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayCurrentRecord();
            }
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            if (currentIndex < studentTable.Rows.Count - 1)
            {
                currentIndex++;
                DisplayCurrentRecord();
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO tblStudents (clid, title, forename, surname, email) VALUES (@clid, @title, @forename, @surname, @email)", connection);
                    cmd.Parameters.AddWithValue("@clid", ((dynamic)comboBoxClasses.SelectedItem).clid);
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@forename", txtForename.Text);
                    cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student added successfully.");
                    LoadStudentData(((dynamic)comboBoxClasses.SelectedItem).clid);
                    currentIndex = studentTable.Rows.Count - 1; // Move to the last record
                    DisplayCurrentRecord();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding student: " + ex.Message);
                }
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE tblStudents SET title = @title, forename = @forename, surname = @surname, email = @email WHERE stid = @stid", connection);
                    cmd.Parameters.AddWithValue("@stid", txtStid.Text);
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@forename", txtForename.Text);
                    cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student updated successfully.");
                    LoadStudentData(((dynamic)comboBoxClasses.SelectedItem).clid);
                    DisplayCurrentRecord();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating student: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM tblStudents WHERE stid = @stid", connection);
                    cmd.Parameters.AddWithValue("@stid", txtStid.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student deleted successfully.");
                    LoadStudentData(((dynamic)comboBoxClasses.SelectedItem).clid);
                    if (currentIndex >= studentTable.Rows.Count)
                    {
                        currentIndex = studentTable.Rows.Count - 1;
                    }
                    DisplayCurrentRecord();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting student: " + ex.Message);
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
