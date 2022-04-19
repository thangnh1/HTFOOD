using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HTFOOD.Forms;

namespace HTFOOD.UsersControls
{
    public partial class UC_Store : UserControl
    {
        public UC_Store()
        {
            InitializeComponent();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            using (Form_Orders frm_Order = new Form_Orders())
            {
                frm_Order.ShowDialog();
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            using (Form_AddFood frm_AddFood = new Form_AddFood())
            {
                frm_AddFood.ShowDialog();
            }
        }

        private void btnAddDrink_Click(object sender, EventArgs e)
        {
            using (Form_AddDrink frm_AddDrink = new Form_AddDrink())
            {
                frm_AddDrink.ShowDialog();
            }
        }

        private void btnListFood_Click(object sender, EventArgs e)
        {
            using (Form_ListFood frm_Listfood = new Form_ListFood())
            {
                frm_Listfood.ShowDialog();
            }
        }

        private void btnListDrink_Click(object sender, EventArgs e)
        {
            using (Form_ListDrink frm_ListDrink = new Form_ListDrink())
            {
                frm_ListDrink.ShowDialog();
            }
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            using(Form_SearchBill frm_SearchBill = new Form_SearchBill())
            {
                frm_SearchBill.ShowDialog();
            }
        }
    }
}
