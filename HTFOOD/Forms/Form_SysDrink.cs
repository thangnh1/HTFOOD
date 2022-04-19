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
    public partial class Form_SysDrink : Form
    {
        public Form_SysDrink()
        {
            InitializeComponent();
        }
        private Class_Product clsPr = new Class_Product();
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }


        private void resetForm()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtNCC.Text = "";
            txtPrice.Text = "";
            txtDiscount.Text = "";
            txtNum.Text = "";
        }

        private void sttButton(bool edit, bool update, bool back, bool grpinfo)
        {
            btnEdit.Enabled = edit;
            btnUpdate.Enabled = update;
            btnBack.Enabled = back;
            grpInfo.Enabled = grpinfo;
        }

        private void Form_SysDrink_Load(object sender, EventArgs e)
        {
            sttButton(true, false, false, false);
            dvwList.DataSource = clsPr.showList(2);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dvwList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món ăn cần sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                sttButton(false, true, true, true);

                int index = dvwList.CurrentCell.RowIndex;

                txtID.Enabled = false;
                txtID.Text = dvwList.Rows[index].Cells[0].Value.ToString();
                txtName.Text = dvwList.Rows[index].Cells[1].Value.ToString();
                txtNCC.Text = dvwList.Rows[index].Cells[2].Value.ToString();
                txtPrice.Text = dvwList.Rows[index].Cells[3].Value.ToString();
                txtDiscount.Text = dvwList.Rows[index].Cells[4].Value.ToString();
                txtNum.Text = dvwList.Rows[index].Cells[5].Value.ToString();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            resetForm();
            sttButton(true, false, false, false);
        }

        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                check.SetError(this.txtNum, "Vui lòng nhập số");
                txtNum.Focus();
            }
            else
            {
                check.SetError(this.txtNum, null);
            }
        }

        private void txtNum_Validating(object sender, CancelEventArgs e)
        {
            if (txtNum.TextLength == 0)
            {
                check.SetError(this.txtNum, "Số lượng sản phẩm không được để trống");
                //di chuyen con tro ve lai vi tri cua txtNum
                txtNum.Focus();
            }
            else
            {
                check.SetError(this.txtNum, null);
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.TextLength == 0)
            {
                check.SetError(this.txtName, "Tên sản phẩm không được để trống");
                //di chuyen con tro ve lai vi tri cua txtName
                txtName.Focus();
            }
            else
            {
                check.SetError(this.txtName, null);
            }
        }

        private void txtNCC_Validating(object sender, CancelEventArgs e)
        {
            if (txtNCC.TextLength == 0)
            {
                check.SetError(this.txtNCC, "Tên NCC không được để trống");
                //di chuyen con tro ve lai vi tri cua txtNCC
                txtNCC.Focus();
            }
            else
            {
                check.SetError(this.txtNCC, null);
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                check.SetError(this.txtPrice, "Vui lòng nhập số");
                txtPrice.Focus();
            }
            else
            {
                check.SetError(this.txtPrice, null);
            }
        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            if (txtPrice.TextLength == 0)
            {
                check.SetError(this.txtPrice, "Tên sản phẩm không được để trống");
                //di chuyen con tro ve lai vi tri cua txtPrice
                txtPrice.Focus();
            }
            else
            {
                check.SetError(this.txtPrice, null);
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                check.SetError(this.txtDiscount, "Vui lòng nhập số");
                txtDiscount.Focus();
            }
            else
            {
                check.SetError(this.txtDiscount, null);
            }
        }

        private void txtDiscount_Validating(object sender, CancelEventArgs e)
        {
            if (txtDiscount.TextLength == 0)
            {
                check.SetError(this.txtDiscount, "Giảm giá không được để trống. Nhập 0 nếu không giảm giá");
                //di chuyen con tro ve lai vi tri cua txtDiscount
                txtPrice.Focus();
            }
            else
            {
                check.SetError(this.txtDiscount, null);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtNum.Text == "" || txtName.Text == "" || txtNCC.Text == "" || txtPrice.Text == "" || txtDiscount.Text == "")
            {
                MessageBox.Show("Vui lòng kiểm tra lại các thông tin. Đảm bảo thông tin nhập đầy đủ và chính xác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int rs = clsPr.Update(txtID.Text, txtName.Text, txtNCC.Text, int.Parse(txtPrice.Text), int.Parse(txtDiscount.Text), int.Parse(txtNum.Text));
                if (rs == 1)
                {
                    MessageBox.Show("Cập nhật thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dvwList.DataSource = null;
                    dvwList.DataSource = clsPr.showList(2);

                    resetForm();
                    txtSearch.Focus();
                    sttButton(true, false, false, false);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                dvwList.DataSource = null;
                dvwList.DataSource = clsPr.showList(2);
                txtSearch.Focus();
            }
            else
            {
                dvwList.DataSource = null;
                dvwList.DataSource = clsPr.Search(1, txtSearch.Text);

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dvwList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món ăn cần xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int index = dvwList.CurrentCell.RowIndex;
                string id = dvwList.Rows[index].Cells[0].Value.ToString();

                DialogResult result = MessageBox.Show("Bạn có muốn xóa nước uống này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int rs = clsPr.delProduct(id);
                    if (rs == 1)
                    {
                        MessageBox.Show(string.Format("Xóa thành công sản phẩm có mã {0}", id), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dvwList.DataSource = null;
                        dvwList.DataSource = clsPr.showList(2);

                    }
                }
            }
        }
    }
}
