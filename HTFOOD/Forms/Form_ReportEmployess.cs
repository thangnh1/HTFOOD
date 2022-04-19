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
    public partial class Form_ReportEmployess : Form
    {
        public Form_ReportEmployess()
        {
            InitializeComponent();
            rp_Employess rpE = new rp_Employess();
            rpE.Load(Application.StartupPath + @"\rp_Employess.rpt");
            crystalReportViewer1.ReportSource = rpE;
            crystalReportViewer1.RefreshReport();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
