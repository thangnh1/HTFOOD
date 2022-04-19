using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HTFOOD.Forms;

namespace HTFOOD.UsersControls
{
    public partial class UC_Contacts : UserControl
    {
        public UC_Contacts()
        {
            InitializeComponent();
        }

        private void btnInfoStore_Click(object sender, EventArgs e)
        {
            using(Form_InfoStore infoStore = new Form_InfoStore())
            {
                infoStore.ShowDialog();
            }
        }

        private void btnInfoPro_Click(object sender, EventArgs e)
        {
            using (Form_About about = new Form_About())
            {
                about.ShowDialog();
            }
        }
    }
}
