using System;
using System.Windows.Forms;
using SystemAdmin_CRUD_Ops;

namespace SystemAdmin_UI
{
    public partial class LogonMenu : Form
    {
        private LogonService logon;

        public LogonMenu()
        {
            logon = new LogonService();

            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (logon.AttemptLogon(emailAddress_textBox.Text,
                password_textBox.Text) == true)
            {
                MainMenu Main = new MainMenu();
                Main.logonMenu = this;
                Main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Failed. You have not entered valid login credentials.");
            }
        }

        public void Reload()
        {
            logon = new LogonService();
        }
    }
}
