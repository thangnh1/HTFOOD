using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using HTFOOD.Lib;



namespace HTFOOD.Forms
{
    public partial class Form_Login : Form
    {

        public static string id_user = "";
        public static string user_name = "";
        public static int user_permission = 0;
        private Class_Encrypt _Encrypt = new Class_Encrypt();
        private Class_Login login = new Class_Login();
        public Form_Login()
        {
            Thread t = new Thread(new ThreadStart(SplashScreen));
            t.Start();
            Thread.Sleep(4000);
            InitializeComponent();
            t.Abort();
        }

        private void SplashScreen()
        {
            Application.Run(new Form_Splash());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            id_user = login.getID(txtUsername.Text, _Encrypt.SHA1(txtPassword.Text));

            if (id_user != "")
            {
                user_name = login.getUserName(txtUsername.Text, _Encrypt.SHA1(txtPassword.Text));
                user_permission = login.getPermission(txtUsername.Text, _Encrypt.SHA1(txtPassword.Text));
                using (Form_Main fm = new Form_Main())
                {
                    this.Hide();
                    fm.ShowDialog();
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
