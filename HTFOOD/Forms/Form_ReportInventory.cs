using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HTFOOD.Reports;

namespace HTFOOD.Forms
{
    public partial class Form_ReportInventory : Form
    {
        public Form_ReportInventory()
        {
            InitializeComponent();
            rp_inventory rpI = new rp_inventory();
            rpI.Load(Application.StartupPath + @"Report\rp_inventory.rpt");
            crystalReportViewer1.ReportSource = rpI;
            crystalReportViewer1.RefreshReport();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
