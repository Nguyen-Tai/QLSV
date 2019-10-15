using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QLSVLinq.BS_Layer
{
    class BLKhoa
    {
        public System.Data.Linq.Table<Khoa> LayKhoa()
        {
            DataSet ds = new DataSet();
            QLSVDataContext qlSV = new QLSVDataContext();
            return qlSV.Khoas;
        }
        public bool ThemKhoa(string MaKhoa, string TenKhoa, ref string err)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            Khoa kh = new Khoa();
            kh.maKhoa = MaKhoa;
            kh.tenKhoa = TenKhoa;
            qlSV.Khoas.InsertOnSubmit(kh);
            qlSV.Khoas.Context.SubmitChanges();
            return true;
        }
        public bool XoaKhoa(ref string err, string MaKhoa)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = from tp in qlSV.Khoas
                          where tp.maKhoa == MaKhoa
                          select tp;
            qlSV.Khoas.DeleteAllOnSubmit(tpQuery);
            qlSV.SubmitChanges();
            return true;
        }
        public bool CapNhatKhoa(string MaKhoa, string TenKhoa, ref string err)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = (from tp in qlSV.Khoas
                           where tp.maKhoa == MaKhoa
                           select tp).SingleOrDefault();
            if (tpQuery != null)
            {
                tpQuery.tenKhoa = TenKhoa;

                qlSV.SubmitChanges();
            }
            return true;
        }
        public List<Khoa> TimMaKhoa(string MaKhoa)
        {

            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = (from tp in qlSV.Khoas
                           where tp.maKhoa.Contains(MaKhoa)
                           select tp).ToList();
            return tpQuery;
        }
        public List<Khoa> TimTenKhoa(string TenKhoa)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = (from tp in qlSV.Khoas
                           where tp.tenKhoa.Contains(TenKhoa)
                           select tp).ToList();
            return tpQuery;
        }
    }
}
