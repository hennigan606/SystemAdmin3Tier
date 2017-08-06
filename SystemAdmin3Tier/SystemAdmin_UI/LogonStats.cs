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
    public partial class LogonStats : Form
    {
        public LogonMenu logonMenu { get; set; }
        public MainMenu Main { get; set; }

        public LogonStats()
        {
            InitializeComponent();
        }

        private void SuccessfulLogons_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_SystemAdminDataModel_SystemAdminContextDataSet.LogonAttempts' table. You can move, or remove it, as needed.
            this.logonAttemptsTableAdapter.Fill(this._SystemAdminDataModel_SystemAdminContextDataSet.LogonAttempts);

        }

        private void ReturnMainMenuButton_Click(object sender, EventArgs e)
        {
            Main.Show();
            this.Close();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            logonMenu.Show();
            Main.Close();
            this.Close();
        }
    }
}
