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
    class Class_Employess
    {
        private Class_Database db = new Class_Database();

        public DataTable showList()
        {
            string sqlcomm = string.Format("SELECT manv AS [Mã NV], vitri AS [Vị trí], ten AS [Họ & tên], ngaysinh AS [Ngày sinh], cmnd AS [CMND], dienthoai AS [SĐT], email AS [Email], diachi AS [Địa chỉ] FROM tbl_nhanvien WHERE per=0");
            return db.TableRead(sqlcomm);
        }

        public string getID(string name)
        {
            string sqlcomm = string.Format("SELECT manv FROM tbl_nhanvien WHERE ten LIKE N'{0}'", name);

            DataTable dt = new DataTable();

            dt = db.TableRead(sqlcomm);
            string temp = "";

            foreach (DataRow dr in dt.Rows)
            {
                temp = dr[0].ToString();
            }

            return temp;
        }

        public int addEmployess(string id, string permission, string name, string dob, string cmnd, string phone, string email, string address, string password)
        {
            try
            {
                string sqlcomm = string.Format("INSERT INTO tbl_nhanvien(manv, vitri, ten, matkhau, ngaysinh, cmnd, dienthoai, email, diachi, per) VALUES ('{0}', N'{1}', N'{2}', '{3}', '{4}', {5}, {6}, N'{7}', N'{8}', {9})", "NV" + id, permission, name, password, dob, cmnd, phone, email, address, 0);
                db.ADE(sqlcomm);
            }
            catch (SqlException)
            {
                MessageBox.Show("Có lỗi trong quá trình thêm nhân viên. Vui lòng kiểm tra và thử lại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            return 1;
        }

        public int updateEmployess(string id, string permission, string name, string dob, string cmnd, string phone, string email, string address, string password)
        {
            try
            {
                string sqlcomm = string.Format("UPDATE tbl_nhanvien SET ten=N'{0}', vitri=N'{1}', cmnd='{2}', ngaysinh='{3}', dienthoai='{4}', email=N'{5}', diachi=N'{6}', matkhau='{7}' WHERE manv='{8}'", name, permission, cmnd, dob, phone, email, address, password, id);
                db.ADE(sqlcomm);
            }
            catch (SqlException)
            {
                MessageBox.Show("Có lỗi trong quá trình cập nhật thông tin nhân viên. Vui lòng kiểm tra và thử lại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            return 1;
        }

        public int delEmployess(string id)
        {
            try
            {
                string sqlcomm = "DELETE FROM tbl_nhanvien WHERE manv='" + id + "'";
                db.ADE(sqlcomm);
            }
            catch (SqlException)
            {
                MessageBox.Show("Có lỗi trong quá trình xóa thông tin nhân viên. Vui lòng kiểm tra và thử lại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            return 1;
        }

        public DataTable Search(string name)
        {
            string sqlcomm = string.Format("SELECT manv AS [Mã nv], vitri AS [Vị trí], ten AS [Họ & Tên], ngaysinh AS [Ngày sinh], cmnd AS [CMND], dienthoai AS [SĐT], email AS [Email], diachi AS [Địa chỉ] FROM tbl_nhanvien WHERE ten LIKE N'{0}%' OR ten LIKE N'%{0}' OR ten LIKE N'%{0}%' AND per=0", name);
            DataTable dt = db.TableRead(sqlcomm);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(string.Format("Không tìm thấy tên với từ khóa {0}", name), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return showList();
            }
            else
            {
                return dt;
            }
        }
    }
}
