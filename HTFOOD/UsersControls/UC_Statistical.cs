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
    public partial class UC_Statistical : UserControl
    {
        public UC_Statistical()
        {
            InitializeComponent();
        }

        private void btnEmployess_Click(object sender, EventArgs e)
        {
            using(Form_ReportEmployess frm_ReportEmployess = new Form_ReportEmployess())
            {
                frm_ReportEmployess.ShowDialog();
            }
        }

        private void btnListInventory_Click(object sender, EventArgs e)
        {
            using(Form_ReportInventory frm_RpInventory = new Form_ReportInventory())
            {
                frm_RpInventory.ShowDialog();
            }
        }

        private void btnListSold_Click(object sender, EventArgs e)
        {
            using (Form_ReportSold frm_RpSold = new Form_ReportSold())
            {
                frm_RpSold.ShowDialog();
            }
        }

        private void btnStatisticsMonth_Click(object sender, EventArgs e)
        {
            using(Form_ReportSoldMonth frm_ReportSoldMonth = new Form_ReportSoldMonth())
            {
                frm_ReportSoldMonth.ShowDialog();
            }
        }
    }
}
