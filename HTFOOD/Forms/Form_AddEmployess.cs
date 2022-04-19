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
using System.Globalization;
using HTFOOD.Lib;

namespace HTFOOD.Forms
{
    public partial class Form_AddEmployess : Form
    {
        public Form_AddEmployess()
        {
            InitializeComponent();
        }
        private Class_Employess clEmp = new Class_Employess();
        private Class_Encrypt _Encrypt = new Class_Encrypt();
        private void resetForm()
        {
            txtID.Text = "";
            cboPermission.Text = "Nhân viên";
            txtName.Text = "";
            txtCMND.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtRePassword.Text = "";
            txtAddress.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_AddEmployess_Load(object sender, EventArgs e)
        {
            cboPermission.Items.Add("Quản lý");
            cboPermission.Items.Add("Nhân viên");
            cboPermission.Items.Add("Đầu bếp");
            cboPermission.Items.Add("Bảo vệ");
            cboPermission.Text = "Nhân viên";
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

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                check.SetError(this.txtPhone, "Vui lòng nhập số");
                txtPhone.Focus();
            }
            else
            {
                check.SetError(this.txtPhone, null);
            }
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                check.SetError(this.txtCMND, "Vui lòng nhập số");
                txtCMND.Focus();
            }
            else
            {
                check.SetError(this.txtCMND, null);
            }
        }

        private void txtID_Validating(object sender, CancelEventArgs e)
        {
           
            if(txtID.Text == "")
            {
                check.SetError(this.txtID, "Mã nhân viên không được trống");
                txtID.Focus();
            }
            else
            {
                check.SetError(this.txtID, null);
            }

            if(txtID.TextLength > 3)
            {
                check.SetError(this.txtID, "Mã nhân viên không được quá 999");
                txtID.Focus();
            }
            else
            {
                check.SetError(this.txtID, null);
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                check.SetError(this.txtName, "Không được nhập số.");
                txtName.Focus();
            }
            else
            {
                check.SetError(this.txtName, null);
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {

            if(txtPhone.TextLength > 11 || txtPhone.TextLength == 0 || txtPhone.Text[0] != '0')
            {
                check.SetError(this.txtPhone, "Vui lòng kiểm tra lại sđt");
                txtPhone.Focus();
            }
            else
            {
                check.SetError(this.txtPhone, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            int temp = 0;

            for(int i = 0; i < txtEmail.TextLength; i++)
            {
                if(txtEmail.Text[i] == '@')
                {
                    temp++;
                }
            }
            
            if(temp != 1)
            {
                check.SetError(txtEmail, "Vui lòng kiểm tra lại email !");
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {

            if(e.KeyChar == ' ')
            {
                check.SetError(this.txtEmail, "Vui lòng điền email !");
                txtEmail.Focus();
            }
            else
            {
                check.SetError(this.txtEmail, null);
            }
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if(txtAddress.TextLength == 0)
            {
                check.SetError(this.txtAddress, "Vui lòng điền địa chỉ");
                txtAddress.Focus();
            }
            else
            {
                check.SetError(this.txtAddress, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if(txtPassword.TextLength < 6)
            {
                check.SetError(this.txtPassword, "Mật khẩu có ít nhất 6 kí tự");
                txtPassword.Focus();
            }
            else
            {
                check.SetError(this.txtPassword, null);
            }
        }

        private void txtRePassword_Validating(object sender, CancelEventArgs e)
        {
            if(txtPassword.Text != txtRePassword.Text)
            {
                check.SetError(this.txtRePassword, "Mật khẩu không trùng khớp");
                txtRePassword.Focus();
            }
            else
            {
                check.SetError(this.txtRePassword, null);
            }
        }

        private void txtCMND_Validating(object sender, CancelEventArgs e)
        {
            if(txtCMND.TextLength > 11)
            {
                check.SetError(this.txtCMND, "Vui lòng kiểm tra lại số CMND");
                txtCMND.Focus();
            }
            else
            {
                check.SetError(this.txtCMND, null);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(txtID.Text == "" || txtName.Text == "" || txtCMND.Text == "" || txtPhone.Text == "" || txtEmail.Text == "" || txtAddress.Text == "" || txtPassword.Text == "" || txtRePassword.Text == "")
            {
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string date = dtmDOB.Value.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            int rs = clEmp.addEmployess(txtID.Text, cboPermission.Text, txtName.Text, date, txtCMND.Text, txtPhone.Text, txtEmail.Text, txtAddress.Text, _Encrypt.SHA1(txtPassword.Text));
            if(rs == 1)
            {
                DialogResult result = MessageBox.Show("Thêm nhân viên thành công. Bạn muốn tiếp tục thêm mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetForm();
            txtID.Focus();
        }
    }
}
