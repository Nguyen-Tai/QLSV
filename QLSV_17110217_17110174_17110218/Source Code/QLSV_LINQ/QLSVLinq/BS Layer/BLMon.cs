using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QLSVLinq.BS_Layer
{
    class BLMon
    {
        public System.Data.Linq.Table<Mon> LayMon()
        {
            DataSet ds = new DataSet();
            QLSVDataContext qlSV = new QLSVDataContext();
            return qlSV.Mons;
        }
        public bool ThemMon(string MaMon, string TenMon, string MaKhoa, int SoTinChi, string HK, ref string err)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            Mon kh = new Mon();
            kh.maMon = MaMon;
            kh.tenMon = TenMon;
            kh.maKhoa = MaKhoa;
            kh.soTinChi = SoTinChi;
            kh.hocKi = HK;
            qlSV.Mons.InsertOnSubmit(kh);
            qlSV.Mons.Context.SubmitChanges();
            return true;
        }
        public bool XoaMon(ref string err, string MaMon)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = from tp in qlSV.Mons
                          where tp.maMon == MaMon
                          select tp;
            qlSV.Mons.DeleteAllOnSubmit(tpQuery);
            qlSV.SubmitChanges();
            return true;
        }
        public bool CapNhatMon(string MaMon, string TenMon, string MaKhoa, int SoTinChi, string HK, ref string err)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = (from tp in qlSV.Mons
                           where tp.maMon == MaMon
                           select tp).SingleOrDefault();
            if (tpQuery != null)
            {
                tpQuery.tenMon = TenMon;
                tpQuery.maKhoa = MaKhoa;
                tpQuery.soTinChi = SoTinChi;
                tpQuery.hocKi = HK;
                qlSV.SubmitChanges();
            }
            return true;
        }
        public List<Mon> TimMaMon(string MaMon)
        {

            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = (from tp in qlSV.Mons
                           where tp.maMon.Contains(MaMon)
                           select tp).ToList();
            return tpQuery;
        }
        public List<Mon> TimTenMon(string TenMon)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = (from tp in qlSV.Mons
                           where tp.tenMon.Contains(TenMon)
                           select tp).ToList();
            return tpQuery;
        }
        
        public List<Mon> LoadMonTrongMaLop(string MaLop)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = (from tp in qlSV.Lops
                           from vp in qlSV.Khoas
                           from up in qlSV.Mons
                           where vp.maKhoa == tp.maKhoa
                           && tp.maLop == MaLop && vp.maKhoa == up.maKhoa
                           select up).ToList();
            return tpQuery;
        }
    }
}
