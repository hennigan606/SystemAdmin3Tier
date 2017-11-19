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
    public partial class AddNewUser : Form
    {
        public UserManagement UserMgmt { get; set; }

        private UserManagementService userMgmt;
        private SystemAdminContext context;
        private CRUD_Operations CRUD;

        public AddNewUser()
        {
            context = new SystemAdminContext();
            CRUD = new CRUD_Operations(context);
            userMgmt = new UserManagementService(CRUD);

            InitializeComponent();
        }

        private void AddUserbutton_Click(object sender, EventArgs e)
        {
            if (userMgmt.AddUser(fNametextBox.Text, lNametextBox.Text, Email_textBox.Text,
                Password_textBox.Text) == true)
            {
                UserMgmt.LoadUsers();
                MessageBox.Show("New user " + fNametextBox.Text + " " + lNametextBox.Text
                    + " has been successfully added to the system.");
                this.Close();
            }

            else
            {
                MessageBox.Show("Failed to add new user to the system. A user already exists "
                    + "on the system with the email that you have provided.");
                this.Close();
            }
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
