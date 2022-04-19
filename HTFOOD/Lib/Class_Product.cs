using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTFOOD.Lib
{
    class Class_Product
    {
        private Class_Database db = new Class_Database();
        public DataTable showList(int choose)
        {
            string sqlcomm = string.Format("SELECT masp as [Mã SP], tensp as [Tên sản phẩm], nhacc as [Nhà cung cấp], giatien as [Giá tiền], giamgia as [Giảm giá], soluong as [Số lượng] FROM tbl_sanpham WHERE loai={0}", choose);
            return db.TableRead(sqlcomm);
        }
        // add new product
        public int Add(string id, int choose, string name, string ncc, int price, int discount, int num)
        {
            try
            {
                string sqlcomm = string.Format("INSERT INTO tbl_sanpham (masp, loai, tensp, nhacc, giatien, giamgia, soluong) VALUES ('{0}','{1}', N'{2}', N'{3}', {4}, {5}, {6})", "HT" + id, choose, name, ncc, price, discount, num);
                db.ADE(sqlcomm);
            }

            catch (SqlException)
            {
                MessageBox.Show("Có lỗi khi thêm sản phẩm. Vui lòng kiểm tra và thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }

            return 1;
        }
        //search product
        public DataTable Search(int choose, string command)
        {
            string sqlcomm = string.Format("SELECT masp as [Mã SP], tensp as [Tên sản phẩm], nhacc as [Nhà cung cấp], giatien as [Giá tiền], giamgia as [Giảm giá], soluong as [Số lượng] FROM tbl_sanpham WHERE loai={0} AND tensp LIKE N'{1}%' OR tensp LIKE N'%{1}'", choose, command);
            DataTable tmp = db.TableRead(sqlcomm);
            if (tmp.Rows.Count == 0)
            {
                MessageBox.Show(string.Format("Không tìm thấy với từ khóa {0}", command), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return showList(choose);
            }
            else
            {
                return tmp;
            }
        }
        //update product
        public int Update(string id, string name, string ncc, int price, int discount, int num)
        {
            try
            {
                string sqlcomm = string.Format("UPDATE tbl_sanpham SET tensp = N'{0}', nhacc=N'{1}', giatien={2}, giamgia={3}, soluong={4} WHERE masp='{5}'", name, ncc, price, discount, num, id);
                db.ADE(sqlcomm);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thể cập nhật CSDL. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            return 1;
        }
        //delete product
        public int delProduct(string id)
        {
            try
            {
                string sqlcomm = string.Format("DELETE FROM tbl_sanpham WHERE masp='{0}'", id);
                db.ADE(sqlcomm);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thể thực hiện xóa sản phẩm này khỏi CSDL. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            return 1;
        }
    }
}
