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
    public partial class UC_Systems : UserControl
    {
        public UC_Systems()
        {
            InitializeComponent();

            // check permission account
            if (Form_Login.user_permission == 2)
            {
                grpEmployess.Enabled = false;
            }
        }

        private void btnAddEmployess_Click(object sender, EventArgs e)
        {
            using(Form_AddEmployess frm_AddEmployess = new Form_AddEmployess() )
            {
                frm_AddEmployess.ShowDialog();
            }
        }

        private void btnListEmployess_Click(object sender, EventArgs e)
        {
            using (Form_Employess frm_Employess = new Form_Employess())
            {
                frm_Employess.ShowDialog();
            }
        }

        private void btnSysFood_Click(object sender, EventArgs e)
        {
            using(Form_SysFood frm_SysFood = new Form_SysFood())
            {
                frm_SysFood.ShowDialog();
            }
        }

        private void btnSysDrink_Click(object sender, EventArgs e)
        {
            using (Form_SysDrink frm_SysDrink = new Form_SysDrink())
            {
                frm_SysDrink.ShowDialog();
            }
        }
    }
}
