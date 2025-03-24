namespace SwiftSend.C_
{
    public partial class pgMenu : Form
    {
        public pgMenu()
        {
            InitializeComponent();
        }

        private void X_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Menu_Click(object sender, EventArgs e)
        {

        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            pgEmailCommunication pgEmailCommunication = new();
            pgEmailCommunication.Show();
            this.Hide();
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            pgClasses pgClasses = new();
            pgClasses.Show();
            this.Hide();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            pgStudents pgStudents = new();
            pgStudents.Show();
            this.Hide();
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {   
            pgEmailTemplate pgEmailTemplate = new();
            pgEmailTemplate.Show();
            this.Hide();
        }

        private void pgMenu_Load(object sender, EventArgs e)
        {

        }
    }
}