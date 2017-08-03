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
    public partial class UserLog : Form
    {
        public LogonMenu logonMenu { get; set; }
        public MainMenu Main { get; set; }

        public UserLog()
        {
            InitializeComponent();
        }

        private void UserLog_Load(object sender, EventArgs e)
        {

        }
    }
}
