using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using HTFOOD.Lib;

namespace HTFOOD.Forms
{
    public partial class Form_AddDrink : Form
    {
        public Form_AddDrink()
        {
            InitializeComponent();
        }

        private Class_Product clP = new Class_Product();



        //kiem tra du lieu nhap vao
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtName.Text == "" || txtNum.Text == "" || txtPrice.Text == "" || txtNCC.Text == "" || txtDiscount.Text == "")
            {
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
            }
        }

        //function clear form
        private void resetForm()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtNum.Text = "";
            txtPrice.Text = "";
            txtNCC.Text = "";
            txtDiscount.Text = "";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetForm();
            //dua con tro ve lai txtID
            txtID.Focus();
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                check.SetError(this.txtID, "Vui lòng nhập số");
                txtID.Focus();
            }
            else
            {
                check.SetError(this.txtID, null);
            }
        }

        private void txtID_Validating(object sender, CancelEventArgs e)
        {
            //kiem tra txtID trong hay khong
            if (txtID.TextLength == 0)
            {
                check.SetError(this.txtID, "ID sản phẩm không được để trống");
                //di chuyen con tro ve lai vi tri cua txtID
                txtID.Focus();
            }
            else
            {
                check.SetError(this.txtID, null);
            }


            //kiem tra do dai cua ID
            if (txtID.TextLength > 3)
            {
                check.SetError(this.txtID, "ID sản phẩm không được quá 999");
                //di chuyen con tro ve lai vi tri cua txtID
                txtID.Focus();
            }
            else
            {
                check.SetError(this.txtID, null);
            }
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

            //kiem tra txtNum trong hay khong
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
            //kiem tra txtName trong hay khong
            if (txtName.TextLength == 0)
            {
                check.SetError(this.txtName, "Số lượng sản phẩm không được để trống");
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
            //kiem tra txtNCC trong hay khong
            if (txtNCC.TextLength == 0)
            {
                check.SetError(this.txtNCC, "Tên sản phẩm không được để trống");
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
            //kiem tra txtPrice trong hay khong
            if (txtPrice.TextLength == 0)
            {
                check.SetError(this.txtPrice, "Giá tiền không được để trống");
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
            //kiem tra txtDiscount trong hay khong
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            int rs = clP.Add(txtID.Text, 2, txtName.Text, txtNCC.Text, int.Parse(txtPrice.Text), int.Parse(txtDiscount.Text), int.Parse(txtNum.Text));
            
            if(rs == 1)
            {
                DialogResult result = MessageBox.Show("Thêm sản phầm thành công. Tiếp tục thêm sản phẩm mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    resetForm();
                    txtID.Focus();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
