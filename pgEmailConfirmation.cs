using System;
using System.Windows.Forms;

namespace SwiftSend.C_
{
    public partial class pgEmailConfirmation : Form
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        public pgEmailConfirmation()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Email = txtEmail.Text.Trim();
            Password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
