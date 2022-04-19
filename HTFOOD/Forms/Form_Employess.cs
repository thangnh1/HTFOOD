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
using System.Globalization;

namespace HTFOOD.Forms
{
    public partial class Form_Employess : Form
    {
        public Form_Employess()
        {
            InitializeComponent();
        }
        private Class_Employess clEmp = new Class_Employess();
        private Class_Encrypt _Encrypt = new Class_Encrypt();
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void resetForm()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtCMND.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtRePassword.Text = "";
            txtAddress.Text = "";
        }
        private void sttButton(bool edit, bool update, bool back, bool grpinfo)
        {
            btnEdit.Enabled = edit;
            btnUpdate.Enabled = update;
            btnBack.Enabled = back;
            grpInfo.Enabled = grpinfo;
        }
        private void Form_Employess_Load(object sender, EventArgs e)
        {
            sttButton(true, false, false, false);

            dvwList.DataSource = clEmp.showList();
            cboPermission.Items.Add("Quản lý");
            cboPermission.Items.Add("Nhân viên");
            cboPermission.Items.Add("Đầu bếp");
            cboPermission.Items.Add("Bảo vệ");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dvwList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                sttButton(false, true, true, true);

                int index = dvwList.CurrentCell.RowIndex;

                txtID.Text = dvwList.Rows[index].Cells[0].Value.ToString();
                txtID.Enabled = false;
                cboPermission.Text = dvwList.Rows[index].Cells[1].Value.ToString();
                txtName.Text = dvwList.Rows[index].Cells[2].Value.ToString();
                dtmDOB.Value = Convert.ToDateTime(dvwList.Rows[index].Cells[3].Value.ToString());
                txtCMND.Text = dvwList.Rows[index].Cells[4].Value.ToString();
                txtPhone.Text = dvwList.Rows[index].Cells[5].Value.ToString();
                txtEmail.Text = dvwList.Rows[index].Cells[6].Value.ToString();
                txtAddress.Text = dvwList.Rows[index].Cells[7].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtCMND.Text == "" || txtPhone.Text == "" || txtEmail.Text == "" || txtAddress.Text == "" || txtPassword.Text == "" || txtRePassword.Text == "" || txtRePassword.Text != txtPassword.Text)
            {
                MessageBox.Show("Vui lòng kiểm tra lại các thông tin. Đảm bảo thông tin nhập đầy đủ và chính xác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           else
           {
                string date = dtmDOB.Value.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                int rs = clEmp.updateEmployess(txtID.Text, cboPermission.Text, txtName.Text, date, txtCMND.Text, txtPhone.Text, txtEmail.Text, txtAddress.Text, _Encrypt.SHA1(txtPassword.Text));
                if (rs == 1)
                {
                    MessageBox.Show("Cập nhật thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dvwList.DataSource = null;
                    dvwList.DataSource = clEmp.showList();

                    resetForm();
                    txtSearch.Focus();
                    sttButton(true, false, false, false);
                }
           }
            
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
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

            if (txtID.Text == "")
            {
                check.SetError(this.txtID, "Mã nhân viên không được trống");
                txtID.Focus();
            }
            else
            {
                check.SetError(this.txtID, null);
            }

            if (txtID.TextLength > 3)
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
            if (txtPhone.TextLength > 11 || txtPhone.TextLength == 0 || txtPhone.Text[0] != '0')
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

            for (int i = 0; i < txtEmail.TextLength; i++)
            {
                if (txtEmail.Text[i] == '@')
                {
                    temp++;
                }
            }

            if (temp != 1)
            {
                check.SetError(txtEmail, "Vui lòng kiểm tra lại email !");
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
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
            if (txtAddress.TextLength == 0)
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
            if (txtPassword.TextLength < 6)
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
            if (txtPassword.Text != txtRePassword.Text)
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
            if (txtCMND.TextLength > 11)
            {
                check.SetError(this.txtCMND, "Vui lòng kiểm tra lại số CMND");
                txtCMND.Focus();
            }
            else
            {
                check.SetError(this.txtCMND, null);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dvwList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int index = dvwList.CurrentCell.RowIndex;
                string id = Convert.ToString(dvwList.Rows[index].Cells[0].Value);

                DialogResult result = MessageBox.Show("Bạn có muốn xóa nhân viên này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    int rs = clEmp.delEmployess(id);
                    if(rs == 1)
                    {
                        MessageBox.Show(string.Format("Xóa thành công nhân viên có mã {0}", id), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dvwList.DataSource = null;
                        dvwList.DataSource = clEmp.showList();
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            resetForm();
            sttButton(true, false, false, false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            if (txtSearch.Text == "")
            {
                dvwList.DataSource = null;
                dvwList.DataSource = clEmp.showList();
                txtSearch.Focus();
            }
            else
            {
                dvwList.DataSource = null;
                dvwList.DataSource = clEmp.Search(txtSearch.Text);
            }
            
        }
    }
}
