using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HTFOOD.Reports;

namespace HTFOOD.Forms
{
    public partial class Form_ReportSoldMonth : Form
    {
        public Form_ReportSoldMonth()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            string from_date = dtmFromDate.Value.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            string to_date = dtmToDate.Value.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            rp_SoldMonth _SoldMonth = new rp_SoldMonth();
            _SoldMonth.SetParameterValue("from_date", from_date);
            _SoldMonth.SetParameterValue("to_date", to_date);
            rpSoldMonth.ReportSource = _SoldMonth;
        }
    }
}
