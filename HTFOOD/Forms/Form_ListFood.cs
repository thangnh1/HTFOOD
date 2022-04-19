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
    public partial class Form_ListFood : Form
    {
        public Form_ListFood()
        {
            InitializeComponent();
        }
        private Class_Product clProduct = new Class_Product();
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void Form_ListFood_Load(object sender, EventArgs e)
        {
            tbListFood.DataSource = clProduct.showList(1);
            txtSearch.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                tbListFood.DataSource = null;
                tbListFood.DataSource = clProduct.showList(1);
                txtSearch.Focus();
            }
            else
            {
                tbListFood.DataSource = null;
                tbListFood.DataSource = clProduct.Search(1, txtSearch.Text);
            }
        }
    }
}
