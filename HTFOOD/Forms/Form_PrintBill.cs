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
    public partial class Form_PrintBill : Form
    {
        
        public Form_PrintBill()
        {
            InitializeComponent();
        }
        private string _message;
        private string refund;
        private string receive;
        private string discount;
        private string total;
        private string money;
        public string numReceipt
        {
            get { return _message; }
            set { _message = value; }
        }
        public string _refund
        {
            get { return refund; }
            set { refund = value; }
        }

        public string _receive
        {
            get { return receive; }
            set { receive = value; }
        }
        public string _discount
        {
            get { return discount; }
            set { discount = value; }
        }
        public string _total
        {
            get { return total; }
            set { total = value; }
        }
        public string _money
        {
            get { return money; }
            set { money = value; }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_PrintBill_Load(object sender, EventArgs e)
        {
            rp_printbill r = new rp_printbill();
            r.SetParameterValue("ma_hd", _message);
            r.SetParameterValue("money", money);
            r.SetParameterValue("discount", discount);
            r.SetParameterValue("receive", receive);
            r.SetParameterValue("refund", refund);
            r.SetParameterValue("total", total);
            rpBill.ReportSource = r;
        }
    }
}
