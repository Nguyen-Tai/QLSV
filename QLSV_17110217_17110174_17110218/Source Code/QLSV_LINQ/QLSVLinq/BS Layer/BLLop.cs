using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QLSVLinq.BS_Layer
{
    class BLLop
    {
        public System.Data.Linq.Table<Lop> LayLop()
        {
            DataSet ds = new DataSet();
            QLSVDataContext qlSV = new QLSVDataContext();
            return qlSV.Lops;
        }
        public bool ThemLop(string MaLop, string TenLop, string MaKhoa, ref string err)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            Lop kh = new Lop();
            kh.maLop = MaLop;
            kh.tenLop = TenLop;
            kh.maKhoa = MaKhoa;
            qlSV.Lops.InsertOnSubmit(kh);
            qlSV.Lops.Context.SubmitChanges();
            return true;
        }
        public bool XoaLop(ref string err, string MaLop)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = from tp in qlSV.Lops
                          where tp.maLop == MaLop
                          select tp;
            qlSV.Lops.DeleteAllOnSubmit(tpQuery);
            qlSV.SubmitChanges();
            return true;
        }
        public bool CapNhatLop(string MaLop, string TenLop,string MaKhoa, ref string err)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = (from tp in qlSV.Lops
                           where tp.maLop == MaLop
                           select tp).SingleOrDefault();
            if (tpQuery != null)
            {
                tpQuery.tenLop = TenLop;
                tpQuery.maKhoa = MaKhoa;
                qlSV.SubmitChanges();
            }
            return true;
        }
        public List<Lop> TimMaLop(string MaLop)
        {

            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = (from tp in qlSV.Lops
                           where tp.maLop.Contains(MaLop)
                           select tp).ToList();
            return tpQuery;
        }
        public List<Lop> TimTenLop(string TenLop)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = (from tp in qlSV.Lops
                           where tp.tenLop.Contains(TenLop)
                           select tp).ToList();
            return tpQuery;
        }
        public List<Lop> LayKhoaInLop(string MaKhoa)
        {
            QLSVDataContext qLSV = new QLSVDataContext();
            var tpQuery = (from tp in qLSV.Lops
                           where tp.maKhoa == MaKhoa
                           select tp).ToList();
            return tpQuery;
        }
    }
}
