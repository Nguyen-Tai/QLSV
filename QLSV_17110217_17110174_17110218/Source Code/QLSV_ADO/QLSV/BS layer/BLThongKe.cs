using QLSV.BD_layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.BS_layer
{
    class BLThongKe
    {
        DataProvider db = null;
        public BLThongKe()
        {
            db = new DataProvider();
        }
        public DataTable GetTC(string MaSV)
        {
            string sqlString = 
                string.Format("select  a.maSV,a.stcHoc,a.hocKi,b.stcDau "+
"from(select maSV, Sum(soTinChi) as stcHoc, hocKi from KetQua, Mon where ketQua.maMon = Mon.maMon  and maSV = N'{0}' group by maSV, hocKi) a,"
+" (select maSV, Sum(soTinChi) as stcDau, hocKi from KetQua, Mon where ketQua.maMon = Mon.maMon and KetQua.ketQua = 1 and maSV = N'{0}' group by maSV, hocKi) b"
   +"  where a.hocKi = b.hocKi", MaSV);
            return db.MyExecuteQuery(sqlString);
        }
    }
}
