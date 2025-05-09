using System;
using System.Windows.Forms;

namespace ADBApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            unametxt.Focus();
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            string username = unametxt.Text.Trim();
            string password = pwdtxt.Text;

            if (username == "admin" && password == "password")
            {
                this.Hide();

                MDIParent1 mainForm = new MDIParent1();
                mainForm.FormClosed += (s, args) => this.Close(); // Ensures app closes fully
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pwdtxt.Clear();
                pwdtxt.Focus();
            }
        }

        private void Cnclbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
