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

        public bool ThemDiem(string maSV, string maMon, string dgk, string dck, string dtb, bool kq)
        {
            try
            {
                QLSVDataContext qlSV = new QLSVDataContext();
                KetQua kh = new KetQua();
                kh.maSV = maSV;
                kh.maMon = maMon;
                kh.diemGiuaKi = Convert.ToDouble(dgk);
                kh.diemCuoiKi = Convert.ToDouble(dck);
                kh.diemTB = Convert.ToDouble(dtb);
                kh.ketQua = kq;
                qlSV.KetQuas.InsertOnSubmit(kh);
                qlSV.KetQuas.Context.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool XoaDiem( string MaSV, string MaMon, string dgk, string dck)
        {
            try
            {
                QLSVDataContext qlSV = new QLSVDataContext();
                var tpQuery = from tp in qlSV.KetQuas
                              where tp.maSV == MaSV && tp.maMon == MaMon && tp.diemGiuaKi == Convert.ToDouble(dgk) && tp.diemCuoiKi == Convert.ToDouble(dck)
                              select tp;
                qlSV.KetQuas.DeleteAllOnSubmit(tpQuery);
                qlSV.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CapNhatDiem(string maSV, string maMon, string dgk, string dck, string dtb, bool kq)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = (from tp in qlSV.KetQuas
                           where tp.maMon == maMon && tp.maSV == maSV
                           select tp).SingleOrDefault();
            if (tpQuery != null)
            {
                tpQuery.diemGiuaKi = Convert.ToDouble(dgk);
                tpQuery.diemCuoiKi = Convert.ToDouble(dck);
                tpQuery.diemTB = Convert.ToDouble(dtb);
                tpQuery.ketQua = kq;
                qlSV.SubmitChanges();
            }
            return true;
        }
        //public List<KetQua> TimMaKetQua(string MaKetQua)
        //{

        //    QLSVDataContext qlSV = new QLSVDataContext();
        //    var tpQuery = (from tp in qlSV.KetQuas
        //                   where tp.maKetQua.Contains(MaKetQua)
        //                   select tp).ToList();
        //    return tpQuery;
        //}
        //public List<KetQua> TimTenKetQua(string TenKetQua)
        //{
        //    QLSVDataContext qlSV = new QLSVDataContext();
        //    var tpQuery = (from tp in qlSV.KetQuas
        //                   where tp.tenKetQua.Contains(TenKetQua)
        //                   select tp).ToList();
        //    return tpQuery;
        //}

        
    }
}
