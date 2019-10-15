using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QLSVLinq.BS_Layer
{
    class BLQLDiem
    {
        public System.Data.Linq.Table<KetQua> LayDiem()
        {
            DataSet ds = new DataSet();
            QLSVDataContext qlSV = new QLSVDataContext();
            return qlSV.KetQuas;
        }

        public void DeleteDiem(string MaSV, string maMon, string dgk, string dck)
        {
            QLSVDataContext qLSV = new QLSVDataContext();
            string sqlString = string.Format("Delete From KetQua Where maSV=N'{0}' and maMon=N'{1}' and diemGiuaKi={2} and diemCuoiKi={3}", MaSV, maMon, dgk, dck);
            qLSV.ExecuteQuery<KetQua>(sqlString);
        }
        public void InsertDiem(string maSV, string maMon, string dgk, string dck, string dtb, string kq)
        {
            QLSVDataContext qLSV = new QLSVDataContext();
            string sqlString =
           string.Format("Insert KetQua (maSV,maMon,diemGiuaKi,diemCuoiKi,diemTB,ketQua)" +
           "VALUES(N'{0}',N'{1}',{2},{3},{4},N'{5}')", maSV, maMon, dgk, dck, dtb, kq);
            qLSV.ExecuteQuery<KetQua>(sqlString);

        }
        public void UpdateDiem(string maSV, string maMon, string dgkc, string dckc, string dgk, string dck, string dtb, string kq)
        {
            QLSVDataContext qLSV = new QLSVDataContext();
            string sqlString =
            string.Format("Update KetQua SET diemGiuaKi='{4}',diemCuoiKi='{5}',diemTB='{6}',ketQua='{7}' where maSV=N'{0}' and maMon=N'{1}' and diemGiuaKi='{2}' and diemCuoiKi='{3}'",
                    maSV, maMon, dgkc, dckc, dgk, dck, dtb, kq);
            qLSV.ExecuteQuery<KetQua>(sqlString);
        }
        
    }
}
