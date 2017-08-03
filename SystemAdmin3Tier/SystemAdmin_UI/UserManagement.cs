using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SystemAdmin_CRUD_Ops;

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

        private void UserManagement_Load(object sender, EventArgs e)
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
    }
}
