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
    public partial class Form_ListDrink : Form
    {
        private Class_Product clProduct = new Class_Product();
        public Form_ListDrink()
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
        private void Form_ListDrink_Load(object sender, EventArgs e)
        {
            tbListDrink.DataSource = clProduct.showList(2);
            txtSearch.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                tbListDrink.DataSource = null;
                tbListDrink.DataSource = clProduct.showList(2);
                txtSearch.Focus();
            }
            else
            {
                tbListDrink.DataSource = null;
                tbListDrink.DataSource = clProduct.Search(2, txtSearch.Text);
            }
        }
    }
}
