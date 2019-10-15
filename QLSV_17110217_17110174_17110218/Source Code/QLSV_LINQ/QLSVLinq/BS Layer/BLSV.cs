using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QLSVLinq.BS_Layer
{
    class BLSV
    {
        public System.Data.Linq.Table<SinhVien> LaySinhVien()
        {
            DataSet ds = new DataSet();
            QLSVDataContext qlSV = new QLSVDataContext();
            return qlSV.SinhViens;
        }
        public bool ThemSinhVien(string MaSV, string HoTen, DateTime NgaySinh, string GioiTinh, string DiaChi, string MaLop, ref string err)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            SinhVien kh = new SinhVien();
            kh.maSV = MaSV;
            kh.hoTen = HoTen;
            kh.ngaySinh = NgaySinh;
            kh.gioiTinh = GioiTinh;
            kh.diaChi = DiaChi;
            kh.maLop = MaLop;
            qlSV.SinhViens.InsertOnSubmit(kh);
            qlSV.SinhViens.Context.SubmitChanges();
            return true;
        }
        public bool XoaSinhVien(ref string err, string MaSV)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = from tp in qlSV.SinhViens
                          where tp.maSV == MaSV
                          select tp;
            qlSV.SinhViens.DeleteAllOnSubmit(tpQuery);
            qlSV.SubmitChanges();
            return true;
        }
        public bool CapNhatSinhVien(string MaSV, string HoTen, DateTime NgaySinh, string GioiTinh, string DiaChi, string MaLop, ref string err)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = (from tp in qlSV.SinhViens
                           where tp.maSV == MaSV
                           select tp).SingleOrDefault();
            if (tpQuery != null)
            {
                tpQuery.hoTen = HoTen;
                tpQuery.ngaySinh = NgaySinh;
                tpQuery.gioiTinh = GioiTinh;
                tpQuery.diaChi = DiaChi;
                tpQuery.maLop = MaLop;
                qlSV.SubmitChanges();
            }
            return true;
        }
        public List<SinhVien> TimMaSinhVien(string MaSV)
        {

            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = (from tp in qlSV.SinhViens
                           where tp.maSV.Contains(MaSV)
                           select tp).ToList();
            return tpQuery;
        }
        public List<SinhVien> TimTenSinhVien(string HoTen)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = (from tp in qlSV.SinhViens
                           where tp.hoTen.Contains(HoTen)
                           select tp).ToList();
            return tpQuery;
        }
        public List<SinhVien> LaySinhVienTrongKhoaLop(string MaKhoa, string MaLop)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = (from tp in qlSV.SinhViens
                           from vp in qlSV.Lops
                           where vp.maKhoa.Contains(MaKhoa) 
                           && tp.maLop.Contains(MaLop) &&  tp.maLop == vp.maLop                           
                           select tp ).ToList();
            return tpQuery;
        }
    }
}
