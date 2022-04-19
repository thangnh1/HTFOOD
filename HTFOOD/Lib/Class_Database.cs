using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTFOOD.Lib
{
    class Class_Database
    {
        SqlConnection conn;
        SqlDataAdapter dbA;
        DataSet dbSet;

        public Class_Database()
        {
            string strConn = "Data Source=.\\SQLEXPRESS; Database=HTFOOD; Integrated Security=True";
            conn = new SqlConnection(strConn);
        }

        //function view table
        public DataTable TableRead(string strSQL)
        {
            dbA = new SqlDataAdapter(strSQL, conn);
            dbSet = new DataSet();
            dbA.Fill(dbSet);
            return dbSet.Tables[0];
        }

        //function edit, delete, add new
        public void ADE(string strSQL)
        {
            SqlCommand sqlcomm = new SqlCommand(strSQL, conn);
            conn.Open();
            sqlcomm.ExecuteNonQuery();
            conn.Close();
        }
    }
}
