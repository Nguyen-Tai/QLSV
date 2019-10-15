using QLSV.BD_layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.BS_layer
{
    class BLKhoa
    {
        DataProvider db = null;
        public BLKhoa()
        {
            db = new DataProvider();
        }
        public DataTable GetKhoa()
        {
            return db.MyExecuteQuery("select * from Khoa");
        }
        public bool DeleteKhoa(string maKhoa)
        {
            string sqlString = string.Format("Delete From Khoa Where maKhoa=N'{0}'", maKhoa);
            int result = db.MyExecuteNonQuery(sqlString);
            return result > 0;
        }
        public bool InsertKhoa(string maKhoa, string tenKhoa)
        {
            string sqlString =
           string.Format("Insert Khoa (maKhoa,tenKhoa)" +
           "VALUES(N'{0}',N'{1}')", maKhoa, tenKhoa);
            int result = db.MyExecuteNonQuery(sqlString);
            return result > 0;
        }
        public bool UpdateKhoa(string maKhoa, string tenKhoa)
        {
            string sqlString =
            string.Format("Update Khoa SET tenKhoa=N'{1}'  where maKhoa={0}", maKhoa, tenKhoa);
            int result = db.MyExecuteNonQuery(sqlString);
            return result > 0;
        }
        public DataTable SearchKhoaByMaKhoa(string MaKhoa)
        {
            string sqlstring =
                string.Format("select * from Khoa where maKhoa like N'%{0}%'", MaKhoa);
            return db.MyExecuteQuery(sqlstring);
        }
        public DataTable SearchKhoaByTenKhoa(string TenKhoa)
        {
            string sqlstring =
                string.Format("select * from Khoa where tenKhoa like N'%{0}%'", TenKhoa);
            return db.MyExecuteQuery(sqlstring);
        }
    }
}
