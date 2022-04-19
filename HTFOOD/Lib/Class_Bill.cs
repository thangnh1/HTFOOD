using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTFOOD.Lib
{
    class Class_Bill
    {
        private Class_Database db = new Class_Database();
        public DataTable searchBill(string command)
        {
            string query = string.Format("SELECT h.mahd as [Mã HD], h.tenkhach as [Tên khách hàng], n.ten as [Tên nhân viên], h.ngayhd as [Ngày mua], h.tongtien as [Tổng tiền] FROM tbl_hoadon h, tbl_nhanvien n WHERE n.manv = h.manv AND h.mahd LIKE N'%{0}%'", command);
            DataTable temp = db.TableRead(query);
            return temp;
        }
    }
}
