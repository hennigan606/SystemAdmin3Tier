using System;
using System.Windows.Forms;
using SystemAdmin_CRUD_Ops;
using SystemAdminDataModel;

namespace SystemAdmin_UI
{
    public partial class EditAdditionalInfo : Form
    {
        public ServiceRequests Requests { get; set; }

        private int ServiceRequestID;
        private ServiceRequestService Service;
        private SystemAdminContext context;
        private CRUD_Operations CRUD;

        public EditAdditionalInfo(int ServiceRequestID)
        {
            context = new SystemAdminContext();
            CRUD = new CRUD_Operations(context);
            Service = new ServiceRequestService(CRUD);
            this.ServiceRequestID = ServiceRequestID;

            InitializeComponent();
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            Service.ProvideInfo(ServiceRequestID, textBox1.Text);
            Requests.LoadRequests();
            MessageBox.Show("Your comment has been added to the selected service request.");
            this.Close();
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
