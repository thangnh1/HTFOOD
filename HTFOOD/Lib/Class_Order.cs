using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTFOOD.Lib
{
    class Class_Order
    {
        private Class_Database db = new Class_Database();
        
        //add new order
        public int orderFood(string id_bill, string id_employess, string name_user, int total_money)
        {
            try
            {
                string date = DateTime.Now.ToString("MM/dd/yyyy");
                string sqlcomm = string.Format("INSERT INTO tbl_hoadon(mahd, tenkhach, manv, ngayhd, tongtien) VALUES ('{0}', N'{1}', '{2}', '{3}',{4})", id_bill, name_user, id_employess, date, total_money);
                db.ADE(sqlcomm);
            }

            catch (Exception)
            {
                MessageBox.Show("Lỗi khi thao tác với CSDL. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            return 1;
        }

        //update cthd
        public void updateCTHD(string mahd, string masp, int soluong)
        {
            try
            {
                string sqlcomm = string.Format("INSERT INTO tbl_cthd(mahd, masp, slmua) VALUES ('{0}', '{1}', {2})", mahd, masp, soluong);
                db.ADE(sqlcomm);
            }

            catch (Exception)
            {
                MessageBox.Show("Lỗi khi thao tác với CSDL. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //order search
        public DataTable orderSearch(string command)
        {
            string sqlcomm = string.Format("SELECT masp as [Mã SP], tensp as [Tên sản phẩm], giatien as [Giá tiền], soluong as [Số lượng], giamgia as [Giảm giá] FROM tbl_sanpham WHERE tensp LIKE N'{0}%' OR tensp LIKE N'%{0}%' OR tensp LIKE N'%{0}'", command);
            DataTable tmp = db.TableRead(sqlcomm);
            return tmp;
        }

        //update sp
        public void updateSP(string masp, int slmua)
        {
            int slban = 0;
            try
            {
                //get so luong sp trong kho
                string sqlcomm = string.Format("SELECT soluong FROM tbl_sanpham WHERE masp='{0}'", masp);
                DataTable dt = new DataTable();
                dt = db.TableRead(sqlcomm);
                foreach (DataRow dr in dt.Rows)
                {
                    slban = Convert.ToInt32(dr[0].ToString());
                }

                int update = slban - slmua;
                string sqlcomm1 = string.Format("UPDATE tbl_sanpham SET soluong={0} WHERE masp='{1}'", update, masp);

                db.ADE(sqlcomm1);
            }

            catch (Exception)
            {
                MessageBox.Show("Lỗi khi thao tác với CSDL. Vui lòng thử lại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
