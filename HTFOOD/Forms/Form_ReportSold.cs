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
    public partial class Form_ReportSold : Form
    {
        public Form_ReportSold()
        {
            InitializeComponent();
            rp_ListSold rpS = new rp_ListSold();
            rpS.Load(Application.StartupPath + @"\rp_ListSold.rpt");
            rpSold.ReportSource = rpS;
            rpSold.RefreshReport();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
