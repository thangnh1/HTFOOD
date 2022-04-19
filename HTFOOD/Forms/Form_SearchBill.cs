using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HTFOOD.Lib;

namespace HTFOOD.Forms
{
    public partial class Form_SearchBill : Form
    {
        Class_Bill clsBill = new Class_Bill();
        public Form_SearchBill()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            listHD.DataSource = null;
            listHD.DataSource = clsBill.searchBill(txtSearch.Text);
        }

        private void btnViewInfo_Click(object sender, EventArgs e)
        {
            int index = listHD.CurrentCell.RowIndex;
            string numReceipt = listHD.Rows[index].Cells[0].Value.ToString();
            using(Form_BillDetail billDetail = new Form_BillDetail())
            {
                billDetail.numReceipt = numReceipt;
                billDetail.ShowDialog();
            }
        }
    }
}
