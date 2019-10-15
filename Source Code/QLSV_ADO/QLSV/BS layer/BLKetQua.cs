using QLSV.BD_layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.BS_layer
{
    class BLKetQua
    {
        DataProvider db = null;
        public BLKetQua()
        {
            db = new DataProvider();
        }
        public DataTable GetSinhvien()
        {
            return db.MyExecuteQuery("select * from SinhVien");
        }
        public bool DeleteDiem(string MaSV,string maMon,string dgk,string dck)
        {
            string sqlString = string.Format("Delete From KetQua Where maSV=N'{0}' and maMon=N'{1}' and diemGiuaKi={2} and diemCuoiKi={3}",MaSV,maMon,dgk,dck);
            int result = db.MyExecuteNonQuery(sqlString);
            return result >0 ;
        }
        public bool InsertDiem(string maSV, string maMon, string dgk, string dck,string dtb,string kq)
        {
            string sqlString =
           string.Format("Insert KetQua (maSV,maMon,diemGiuaKi,diemCuoiKi,diemTB,ketQua)" +
           "VALUES(N'{0}',N'{1}',{2},{3},{4},N'{5}')", maSV,maMon,dgk,dck,dtb,kq);
            int result = db.MyExecuteNonQuery(sqlString);
            return result >0;
        }
        public bool UpdateDiem(string maSV,  string maMon,string dgkc,string dckc, string dgk, string dck, string dtb, string kq)
        {
            string sqlString =
            string.Format("Update KetQua SET diemGiuaKi='{4}',diemCuoiKi='{5}',diemTB='{6}',ketQua='{7}' where maSV=N'{0}' and maMon=N'{1}' and diemGiuaKi='{2}' and diemCuoiKi='{3}'",
                    maSV,maMon,dgkc,dckc,dgk,dck,dtb,kq);
            int result = db.MyExecuteNonQuery(sqlString);
            return result >0;
        }
        public DataTable SearchKQByMaSV(string maSV)
        {
            string sqlString =
            string.Format("select KetQua.maMon,tenMon,diemGiuaKi,diemCuoiKi,diemTB,Mon.hocKi,ketQua,soTinChi from KetQua,Mon where maSV = N'{0}' and Mon.maMon=KetQua.maMon", maSV);
            return db.MyExecuteQuery(sqlString);
        }
    }
}
