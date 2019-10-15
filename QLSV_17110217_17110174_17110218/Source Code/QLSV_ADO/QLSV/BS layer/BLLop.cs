using QLSV.BD_layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.BS_layer
{
    class BLLop
    {
        DataProvider db = null;
        public BLLop()
        {
            db = new DataProvider();
        }
        public DataTable GetLop()
        {
            return db.MyExecuteQuery("select * from Lop");
        }
        public bool DeleteLop(string maLop)
        {
            string sqlString = string.Format("Delete From Lop Where maLop=N'{0}'", maLop);
            int result = db.MyExecuteNonQuery(sqlString);
            return result > 0;
        }
        public bool InsertLop(string maLop, string tenLop,string maKhoa)
        {
            string sqlString =
           string.Format("Insert Lop (maLop,tenLop,maKhoa)" +
           "VALUES(N'{0}',N'{1}',N'{2}')",maLop,tenLop,maKhoa);
            int result = db.MyExecuteNonQuery(sqlString);
            return result > 0;
        }
        public bool UpdateLop(string maLop, string tenLop,string maKhoa)
        {
            string sqlString =
            string.Format("Update Khoa SET tenLop=N'{1}' , maKhoa=N'{2}' where maLop={0}",maLop,tenLop, maKhoa);
            int result = db.MyExecuteNonQuery(sqlString);
            return result > 0;
        }
        public DataTable GetLopByKhoa(string maKhoa)
        {
            string sqlString =string.Format("select * from Lop where Lop.maKhoa = N'{0}'",maKhoa);
            return db.MyExecuteQuery(sqlString);
        }
        public DataTable SearchLopByMaLop(string MaLop)
        {
            string sqlstring =
                string.Format("select * from Lop where maLop like N'%{0}%'", MaLop);
            return db.MyExecuteQuery(sqlstring);
        }
        public DataTable SearchLopByTenLop(string TenLop)
        {
            string sqlstring =
                string.Format("select * from Lop where tenLop like N'%{0}%'", TenLop);
            return db.MyExecuteQuery(sqlstring);
        }
    }

}
