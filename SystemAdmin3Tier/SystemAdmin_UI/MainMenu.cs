using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemAdmin_UI
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        public LogonMenu logonMenu { get; set; }

        private void UserMgmtButton_Click(object sender, EventArgs e)
        {
            UserManagement userMgmt = new UserManagement();
            userMgmt.logonMenu = logonMenu;
            userMgmt.Main = this;
            userMgmt.Show();
            this.Hide();
        }

        private void ServiceRequestsButton_Click(object sender, EventArgs e)
        {
            ServiceRequests serviceRequests = new ServiceRequests();
            serviceRequests.logonMenu = logonMenu;
            serviceRequests.Main = this;
            serviceRequests.Show();
            this.Hide();
        }

        private void UserLogsButton_Click(object sender, EventArgs e)
        {
            UserLog userLog = new UserLog();
            userLog.logonMenu = logonMenu;
            userLog.Main = this;
            userLog.Show();
            this.Hide();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            logonMenu.Show();
            this.Close();
        }
    }
}
