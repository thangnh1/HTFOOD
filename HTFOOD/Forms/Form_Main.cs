using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HTFOOD.UsersControls;

namespace HTFOOD.Forms
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
            timerTime.Start();
            UC_Home uch = new UC_Home();
            addControlsToPanel(uch);
            lblUsername.Text = Form_Login.user_name;
            if (Form_Login.user_permission == 0)
            {
                btnSystems.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Dispose();
            }
        }

        //function di chuyen thanh panel left
        private void moveSidePanel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;
        }

        private void addControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControls.Controls.Clear();
            panelControls.Controls.Add(c);
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnHome);
            UC_Home uch = new UC_Home();
            addControlsToPanel(uch);
            
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnStore);
            UC_Store uC_Store = new UC_Store();
            addControlsToPanel(uC_Store);
        }

        private void btnStatistical_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnStatistical);
            UC_Statistical uC_Statistical = new UC_Statistical();
            addControlsToPanel(uC_Statistical);
        }

        private void btnSystems_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnSystems);
            UC_Systems uC_Systems = new UC_Systems();
            addControlsToPanel(uC_Systems);
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnContact);
            UC_Contacts uC_Contacts = new UC_Contacts();
            addControlsToPanel(uC_Contacts);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //moveSidePanel(btnLogout);
            DialogResult a = MessageBox.Show("Bạn có muốn đăng xuất ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(a == DialogResult.Yes)
            {
                //xoa session
                Form_Login.id_user = "";
                Form_Login.user_name = "";
                Form_Login.user_permission = 0;
                //thoat form main
                this.Close();
            }
        }

        private void TimerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:MM:ss");
        }
    }
}
