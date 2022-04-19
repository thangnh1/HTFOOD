using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTFOOD.Lib
{
	class Class_Login
	{
		private Class_Database db = new Class_Database();

		public string getID(string username, string password)
		{
			string id = "";
			try
			{
				string sqlcomm = string.Format("SELECT * FROM tbl_nhanvien WHERE manv LIKE '{0}' AND matkhau = '{1}'", username, password);
				DataTable dt = new DataTable();
				dt = db.TableRead(sqlcomm);
				if (dt != null)
				{
					foreach (DataRow dr in dt.Rows)
					{
						id = dr[2].ToString();
					}
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Lỗi kết nối CSDL. Vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return id;
		}

		//get name user
		public string getUserName(string username, string password)
		{
			string user_name = "";
			try
			{
				string sqlcomm = string.Format("SELECT * FROM tbl_nhanvien WHERE manv LIKE '{0}' AND matkhau = '{1}'", username, password);
				DataTable dt = new DataTable();
				dt = db.TableRead(sqlcomm);
				if (dt != null)
				{
					foreach (DataRow dr in dt.Rows)
					{
						user_name = dr[2].ToString();
					}
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Lỗi kết nối CSDL. Vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return user_name;
		}

		//get permision 
		public int getPermission(string username, string password)
		{
			string user_per = "";
			try
			{
				string sqlcomm = string.Format("SELECT * FROM tbl_nhanvien WHERE manv LIKE '{0}' AND matkhau = '{1}'", username, password);
				DataTable dt = new DataTable();
				dt = db.TableRead(sqlcomm);
				if (dt != null)
				{
					foreach (DataRow dr in dt.Rows)
					{
						user_per = dr[9].ToString();
						if (dr[1].ToString() == "Quản lý")
						{
							user_per = "2";
						}
					}
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Lỗi kết nối CSDL. Vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return int.Parse(user_per);
		}
	}
}