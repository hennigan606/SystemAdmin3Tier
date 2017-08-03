using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemAdmin_CRUD_Ops;
using SystemAdminDataModel;

namespace SystemAdmin_UI
{
    public partial class LogonMenu : Form
    {
        LogonService logon;

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
    }
}
