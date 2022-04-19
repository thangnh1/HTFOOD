using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTFOOD.Forms
{
    public partial class Form_InfoStore : Form
    {
        public Form_InfoStore()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_InfoStore_Load(object sender, EventArgs e)
        {
            txtName.Enabled = false;
            txtEmail.Enabled = false;
            txtAddress.Enabled = false;
            txtPhone.Enabled = false;
        }
    }
}
