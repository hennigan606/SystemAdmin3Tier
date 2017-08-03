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
using System.Data.SqlClient;

namespace SystemAdmin_UI
{
    public partial class ServiceRequests : Form
    {
        public LogonMenu logonMenu { get; set; }
        public MainMenu Main { get; set; }

        private ServiceRequestService serviceRequests;

        public ServiceRequests()
        {
            serviceRequests = new ServiceRequestService();

            InitializeComponent();
        }

        private void ServiceRequests_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog="
                + @"SystemAdminDataModel.SystemAdminContext;Integrated Security=True;Connect "
                + @"Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;"
                + @"MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM ServiceRequests", connection);

            DataSet dataSet1 = new DataSet();
            dataAdapter.Fill(dataSet1, "ServiceRequests");
            DataView dataView1 = new DataView(dataSet1.Tables["ServiceRequests"]);
            dataGridView1.DataSource = dataView1;
            dataView1.RowFilter = "Status = 0";

            DataSet dataSet2 = new DataSet();
            dataAdapter.Fill(dataSet2, "ServiceRequests");
            DataView dataView2 = new DataView(dataSet2.Tables["ServiceRequests"]);
            dataGridView2.DataSource = dataView2;
            dataView2.RowFilter = "Status = 1";

            DataSet dataSet3 = new DataSet();
            dataAdapter.Fill(dataSet3, "ServiceRequests");
            DataView dataView3 = new DataView(dataSet3.Tables["ServiceRequests"]);
            dataGridView3.DataSource = dataView3;
            dataView3.RowFilter = "Status = 2";
        }
    }
}
