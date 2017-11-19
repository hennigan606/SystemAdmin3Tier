using System;
using System.Windows.Forms;
using SystemAdmin_CRUD_Ops;
using SystemAdminDataModel;

namespace SystemAdmin_UI
{
    public partial class AssignAdminOperator : Form
    {
        public ServiceRequests Requests { get; set; }

        private int RequestID;
        private ServiceRequestService Service;
        private SystemAdminContext context;
        private CRUD_Operations CRUD;

        public AssignAdminOperator(int RequestID)
        {
            context = new SystemAdminContext();
            CRUD = new CRUD_Operations(context);
            Service = new ServiceRequestService(CRUD);
            this.RequestID = RequestID;

            InitializeComponent();
        }

        private void AssignOperatorbtn_Click(object sender, EventArgs e)
        {
            Service.AssignOperator(RequestID, textBox1.Text);
            Requests.LoadRequests();
            MessageBox.Show(textBox1.Text + " has been assigned to the selected service request.");
            this.Close();
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
