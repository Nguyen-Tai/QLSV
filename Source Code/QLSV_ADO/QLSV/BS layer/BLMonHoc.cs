using QLSV.BD_layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.BS_layer
{
    class BLMonhoc
    {
        DataProvider db = null;
        public BLMonhoc()
        {
            db = new DataProvider();
        }
        public DataTable GetMonhoc()
        {
            return db.MyExecuteQuery("select * from Mon");
        }
        public bool DeleteMonhoc(string maMon)
        {
            string sqlString = string.Format("Delete From Mon Where maMon=N'{0}'", maMon);
            int result = db.MyExecuteNonQuery(sqlString);
            return result > 0;
        }
        public bool InsertMonhoc(string maMon, string tenMon, string maKhoa, string soTinChi, string hk)
        {
            string sqlString =
           string.Format("Insert Mon (maMon ,tenMon,maKhoa,soTinChi,hocKi)" +
           "VALUES(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')", maMon,tenMon,maKhoa,soTinChi,hk);
            int result = db.MyExecuteNonQuery(sqlString);
            return result > 0;
        }
        public bool UpdateMonhoc(string maMon, string tenMon, string maKhoa, string soTinChi, string hk)
        {
            string sqlString =
            string.Format("Update Mon SET tenMon=N'{1}',maKhoa=N'{2}',soTinChi=N'{3}',hocKi=N'{4}' where maMon=N'{0}'", maMon,tenMon,maKhoa,soTinChi,hk);
            int result = db.MyExecuteNonQuery(sqlString);
            return result > 0;
        }
        public DataTable SearchMonByMaMon(string MaMon)
        {
            string sqlstring =
               string.Format("select * from Mon where maMon like N'%{0}%'", MaMon);
            return db.MyExecuteQuery(sqlstring);
        }
        public DataTable SearchMonByTenMon(string TenMon)
        {
            string sqlstring =
               string.Format("select * from Mon where tenMon like N'%{0}%'", TenMon);
            return db.MyExecuteQuery(sqlstring);
        }
        public DataTable LoadMonByMaLop(string MaLop)
        {
            string sqlstring =
               string.Format("select Mon.maMon from Mon,Khoa,Lop where Lop.maLop=N'{0}' and Lop.maKhoa=Khoa.maKhoa and Khoa.maKhoa=Mon.maKhoa",MaLop);
            return db.MyExecuteQuery(sqlstring);
        }
    }
}
