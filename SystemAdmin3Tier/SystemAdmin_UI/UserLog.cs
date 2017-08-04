using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            TextReader reader = new StreamReader(@"C:\Users\Michael\Source\"
                + @"Repos\SystemAdmin3Tier\SystemAdmin3Tier\SystemAdmin_UI\mylogfile.txt");

            UserLogBox.Text = reader.ReadToEnd();
            reader.Close();
        }
    }
}
