using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using SystemAdmin_CRUD_Ops;
using SystemAdminClasses;

namespace SystemAdmin_UI
{
    public partial class UserManagement : Form
    {
        public LogonMenu logonMenu { get; set; }
        public MainMenu Main { get; set; }
        private UserManagementService userMgmt;

        public UserManagement()
        {
            userMgmt = new UserManagementService();

            InitializeComponent();
        }

        public void LoadUsers()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog="
                + @"SystemAdminDataModel.SystemAdminContext;Integrated Security=True;Connect "
                + @"Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;"
                + @"MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Users", connection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Users");
            DataView dataView = new DataView(dataSet.Tables["Users"]);
            dataGridView1.DataSource = dataView;
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            AddNewUser addNewUser = new AddNewUser();
            addNewUser.UserMgmt = this;
            addNewUser.Show();
        }

        private void DeleteUserButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                int UserID;

                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                UserID = Convert.ToInt32(row.Cells["UserID"].Value);

                DialogResult dialogResult = MessageBox.Show("Are you sure you would like to delete this user?",
                    "Delete User", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    userMgmt.DeleteUser(UserID);
                    LoadUsers();
                }

                else if (dialogResult == DialogResult.No)
                {
                    //Do nothing
                }
            }
        }

        private void BanUserButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                int UserID;

                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                UserID = Convert.ToInt32(row.Cells["UserID"].Value);

                DialogResult dialogResult = MessageBox.Show("Are you sure you would like to ban this user?",
                    "Temporarily Ban User", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    userMgmt.BanUser(UserID);
                    LoadUsers();
                }

                else if (dialogResult == DialogResult.No)
                {
                    //Do nothing
                }
            }
        }

        private void LiftBanbtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                int UserID;

                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                UserID = Convert.ToInt32(row.Cells["UserID"].Value);

                DialogResult dialogResult = MessageBox.Show("Are you sure you would like " +
                    "to lift the ban on this user?", "Temporarily Ban User", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    userMgmt.LiftBanOnUser(UserID);
                    LoadUsers();
                }

                else if (dialogResult == DialogResult.No)
                {
                    //Do nothing
                }
            }
        }

        private void SetUserPermissionsButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                int UserID;

                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                UserID = Convert.ToInt32(row.Cells["UserID"].Value);

                SetUserPermissions SetPermissions = new SetUserPermissions(UserID);
                SetPermissions.Show();
            }
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
