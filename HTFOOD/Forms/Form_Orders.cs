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
using HTFOOD.Lib;
using HTFOOD.Reports;

namespace HTFOOD.Forms
{
    public partial class Form_Orders : Form
    {
        DataTable tbOrder = new DataTable();
        private Class_Order clOr = new Class_Order();
        private Class_Employess clEm = new Class_Employess();
        public Form_Orders()
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

        private void btnGuide_Click(object sender, EventArgs e)
        {
            using (Form_Guide form_Guide = new Form_Guide())
            {
                form_Guide.ShowDialog();
            }
        }

        private void Form_Orders_Load(object sender, EventArgs e)
        {

            txtSearch.Focus();

            for(int i = 1; i < 10; i++)
            {
                cboTableNumber.Items.Add(i);
            }

            cboTableNumber.Text = "1";

            txtEmployess.Text = Form_Login.user_name;
            txtEmployess.Enabled = false;
            //create datacridview choose product
            tbOrder.Columns.Add("Mã SP");
            tbOrder.Columns.Add("Tên sản phẩm");
            tbOrder.Columns.Add("Số lượng");
            tbOrder.Columns.Add("Số tiền");
            tbOrder.Columns.Add("Tiền giảm");


            btnPrint.Enabled = false;
            btnDone.Enabled = false;
            txtMoney.Enabled = false;
            txtDiscount.Enabled = false;
            txtRefund.Enabled = false;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            dtSearch.DataSource = null;
            dtSearch.DataSource = clOr.orderSearch(txtSearch.Text);
            dtSearch.Columns[0].Width = 70;
            dtSearch.Columns[1].Width = 250;
        }

        private int sumPrice(DataTable dt, int rows)
        {
            int sum = 0;

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                sum = sum + Convert.ToInt32(dt.Rows[i][rows]);
            }

            return sum;
        }

        private int productSelect(string ten_mon, DataTable dt)
        {
            int select = -1;

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                if(dt.Rows[i][1].ToString() == ten_mon)
                {
                    select = i;
                    break;
                }
            }

            return select;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(dtSearch.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn món ăn nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if(dtSearch.SelectedRows[0].Cells[3].ToString() == "0")
                {
                    MessageBox.Show("Món bạn chọn đã hết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string id_product = dtSearch.SelectedRows[0].Cells[0].Value.ToString();
                    string product_name = dtSearch.SelectedRows[0].Cells[1].Value.ToString();
                    int product_price = Convert.ToInt32(dtSearch.SelectedRows[0].Cells[2].Value);
                    int discount_price = Convert.ToInt32(dtSearch.SelectedRows[0].Cells[2].Value) * Convert.ToInt32(dtSearch.SelectedRows[0].Cells[4].Value) / 100;

                    DataRow dtr = tbOrder.NewRow();

                    int temp = productSelect(product_name, tbOrder);
                    
                    if(temp != -1)
                    {
                        tbOrder.Rows[temp][2] = Convert.ToInt32(tbOrder.Rows[temp][2]) + 1;
                        tbOrder.Rows[temp][3] = Convert.ToInt32(tbOrder.Rows[temp][3]) + product_price;
                        tbOrder.Rows[temp][4] = Convert.ToInt32(tbOrder.Rows[temp][4]) + discount_price;
                    }
                    else
                    {
                        dtr[0] = id_product;
                        dtr[1] = product_name;
                        dtr[2] = 1;
                        dtr[3] = Convert.ToInt32(dtr[2].ToString()) * product_price;
                        dtr[4] = discount_price;
                        tbOrder.Rows.Add(dtr);
                    }

                    dtChoose.DataSource = tbOrder;
                    dtChoose.Columns[0].Width = 70;
                    dtChoose.Columns[1].Width = 250;
                    //sum money
                    txtMoney.Text = sumPrice(tbOrder, 3).ToString();
                    //sum discount
                    txtDiscount.Text = sumPrice(tbOrder, 4).ToString();
                    //echo totalmoney
                    int total_money = sumPrice(tbOrder, 3) - sumPrice(tbOrder, 4);
                    lblTotalMoney.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", total_money);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Hủy đơn hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.Yes)
            {
                dtChoose.DataSource = null;
                txtMoney.Text = "";
                txtSearch.Text = "";
                txtDiscount.Text = "";
                lblTotalMoney.Text = "0";
                txtSearch.Focus();

                btnPrint.Enabled = false;
                btnDone.Enabled = false;
                btnCancel.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dtChoose.SelectedRows.Count > 0)
            {
                string product_name = dtChoose.SelectedRows[0].Cells[1].Value.ToString();
                int product_price = Convert.ToInt32(dtChoose.SelectedRows[0].Cells[3].Value) / Convert.ToInt32(dtChoose.SelectedRows[0].Cells[2].Value);
                int discount_price = Convert.ToInt32(dtSearch.SelectedRows[0].Cells[2].Value) * Convert.ToInt32(dtSearch.SelectedRows[0].Cells[4].Value) / 100;

                int temp = productSelect(product_name, tbOrder);
                int num = Convert.ToInt32(tbOrder.Rows[temp][2]);

                if(num == 1)
                {
                    tbOrder.Rows.RemoveAt(temp);
                    txtMoney.Text = sumPrice(tbOrder, 3).ToString();
                    txtDiscount.Text = sumPrice(tbOrder, 4).ToString();
                    int total_money = sumPrice(tbOrder, 3) - sumPrice(tbOrder, 4);
                    lblTotalMoney.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", total_money);
                }
                else
                {
                    tbOrder.Rows[temp][2] = Convert.ToInt32(tbOrder.Rows[temp][2]) - 1;
                    tbOrder.Rows[temp][3] = Convert.ToInt32(tbOrder.Rows[temp][3]) - product_price;
                    tbOrder.Rows[temp][4] = Convert.ToInt32(tbOrder.Rows[temp][4]) - discount_price;
                    txtMoney.Text = sumPrice(tbOrder, 3).ToString();
                    txtDiscount.Text = sumPrice(tbOrder, 4).ToString();
                    int total_money = sumPrice(tbOrder, 3) - sumPrice(tbOrder, 4);
                    lblTotalMoney.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", total_money) ;
                }
            }
            else
            {
                MessageBox.Show("Vui long chọn món cần xóa !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtBill.Text == "" || cboTableNumber.Text == "" || txtUser.Text == "" || txtEmployess.Text == "" || dtChoose.Rows.Count == 0 || txtReceive.Text == "")
            {
                MessageBox.Show("Vui lòng điền đủ thông tin và kiểm tra lại danh sách món ăn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBill.Focus();
            }
            else
            {
                string manv = clEm.getID(txtEmployess.Text);

                string smahd = "";
                smahd = "HD" + txtBill.Text;

                int receive = int.Parse(txtReceive.Text);
                int total_money = sumPrice(tbOrder, 3) - sumPrice(tbOrder, 4);

                if (receive >= total_money)
                {
                    txtRefund.Text = (receive - total_money).ToString();
                    if (clOr.orderFood(smahd, manv, txtUser.Text, total_money) == 1)
                    {
                        MessageBox.Show("Đã lưu đơn hàng vào csdl", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        for (int i = 0; i < dtChoose.Rows.Count; i++)
                        {
                            clOr.updateCTHD(smahd, tbOrder.Rows[i][0].ToString(), Convert.ToInt32(tbOrder.Rows[i][2].ToString()));
                            clOr.updateSP(tbOrder.Rows[i][0].ToString(), Convert.ToInt32(tbOrder.Rows[i][2].ToString()));
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng kiểm tra tiền nhận từ khách", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btnPrint.Enabled = true;
                btnDone.Enabled = true;
                btnCancel.Enabled = false;
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Order hoàn tất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dtChoose.DataSource = null;
            txtBill.Text = "";
            cboTableNumber.Text = "";
            txtUser.Text = "";
            txtSearch.Text = "";
            txtMoney.Text = "";
            txtReceive.Text = "";
            txtRefund.Text = "";
            txtDiscount.Text = "";
            lblTotalMoney.Text = "0,00";
            txtSearch.Focus();

            btnPrint.Enabled = false;
            btnDone.Enabled = false;
            btnCancel.Enabled = true;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (Form_PrintBill frm_PrintBill = new Form_PrintBill())
            {
                string receipt = "HD" + txtBill.Text;
                int _total_money = Convert.ToInt32(txtMoney.Text);
                int _refund = Convert.ToInt32(txtRefund.Text);
                int _recvie = Convert.ToInt32(txtReceive.Text);
                int _discount = Convert.ToInt32(txtDiscount.Text);
                string refund = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", _refund);
                string recvie = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", _recvie);
                string total_money = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", _total_money);
                string discount = string.Format(new CultureInfo("vi-VN"), "{0:#,##}", _discount);
                this.Hide();
                frm_PrintBill.numReceipt = receipt;
                frm_PrintBill._discount = discount;
                frm_PrintBill._receive = recvie;
                frm_PrintBill._money = total_money;
                frm_PrintBill._total = lblTotalMoney.Text;
                frm_PrintBill._refund = refund;
                frm_PrintBill.ShowDialog();
                this.Show();
            }
        }

        private void txtReceive_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                check.SetError(this.txtReceive, "Vui lòng nhập số");
                txtReceive.Focus();
            }
            else
            {
               check.SetError(this.txtReceive, null);
            }
        }
    }
}
