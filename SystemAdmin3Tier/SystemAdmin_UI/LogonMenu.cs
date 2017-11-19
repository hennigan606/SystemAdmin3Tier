using System;
using System.Windows.Forms;
using SystemAdmin_CRUD_Ops;
using SystemAdminDataModel;

namespace SystemAdmin_UI
{
    public partial class LogonMenu : Form
    {
        private LogonService logon;
        private SystemAdminContext context;
        private CRUD_Operations CRUD;

        public LogonMenu()
        {
            context = new SystemAdminContext();
            CRUD = new CRUD_Operations(context);
            logon = new LogonService(CRUD);

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
            logon = new LogonService(CRUD);
        }
    }
}
