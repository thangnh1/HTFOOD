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
    public partial class Form_BillDetail : Form
    {
        public Form_BillDetail()
        {
            InitializeComponent();
        }
        public string numReceipt
        {
            get { return message; }
            set { message = value; }
        }
        private string message;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_BillDetail_Load(object sender, EventArgs e)
        {
            rp_BillDetail billDetail = new rp_BillDetail();
            billDetail.SetParameterValue("ma_hd", message);
            rpBillDetail.ReportSource = billDetail;
        }
    }
}
