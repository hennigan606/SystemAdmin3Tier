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
    }
}
