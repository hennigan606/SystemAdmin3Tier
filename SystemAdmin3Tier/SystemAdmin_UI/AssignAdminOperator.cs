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

namespace SystemAdmin_UI
{
    public partial class AssignAdminOperator : Form
    {
        public ServiceRequests Requests { get; set; }
        private int RequestID;
        private ServiceRequestService Service;

        public AssignAdminOperator(int RequestID)
        {
            Service = new ServiceRequestService();
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
