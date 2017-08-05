using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using SystemAdmin_CRUD_Ops;

namespace SystemAdmin_UI
{
    public partial class SetUserPermissions : Form
    {
        private UserManagementService UserMgmt;
        private int UserID;

        public SetUserPermissions(int UserID)
        {
            UserMgmt = new UserManagementService();
            this.UserID = UserID;

            InitializeComponent();
        }

        private void SetUserPermissions_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog="
                + @"SystemAdminDataModel.SystemAdminContext;Integrated Security=True;Connect "
                + @"Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;"
                + @"MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM UserAccessGroups", connection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "UserAccessGroups");
            DataView dataView = new DataView(dataSet.Tables["UserAccessGroups"]);
            dataGridView1.DataSource = dataView;
        }

        private void AddUserToGroupbutton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                int UserAccessGroupID;

                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                UserAccessGroupID = Convert.ToInt32(row.Cells["UserAccessGroupID"].Value);

                UserMgmt.AddUserToGroup(UserID, UserAccessGroupID);
                MessageBox.Show("The selected user was successfully added to the selected access group.");
                this.Close();
            }
        }

        private void RemoveUserFromGroupbutton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                int UserAccessGroupID;

                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                UserAccessGroupID = Convert.ToInt32(row.Cells["UserAccessGroupID"].Value);

                UserMgmt.RemoveUserFromGroup(UserID, UserAccessGroupID);
                MessageBox.Show("The selected user was successfully removed from the selected access group.");
                this.Close();
            }
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
