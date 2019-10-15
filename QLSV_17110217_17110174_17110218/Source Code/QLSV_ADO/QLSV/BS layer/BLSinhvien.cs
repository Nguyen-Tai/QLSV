using QLSV.BD_layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.BS_layer
{
    class BLSinhvien
    {
        DataProvider db = null;
        public BLSinhvien()
        {
            db = new DataProvider();
        }
        public DataTable GetSinhvien()
        {
            return db.MyExecuteQuery("select * from SinhVien");
        }
        public bool DeleteSV(string maSV)
        {
            string sqlString = string.Format("Delete From SinhVien Where maSV=N'{0}'", maSV);
            int result = db.MyExecuteNonQuery(sqlString);
            return result > 0;
        }
        public bool InsertSV(string maSV, string hoTen, string ns,string gt,string diachi,string maLop)
        { 
            string sqlString =
           string.Format("Insert SinhVien (maSV,hoTen,ngaySinh,gioiTinh,diaChi,maLop)" +
           "VALUES(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')", maSV, hoTen,ns, gt,diachi,maLop);
            int result = db.MyExecuteNonQuery(sqlString);
            return result > 0;
        }
        public bool UpdateSV(string maSV, string hoTen, string ns, string gt, string diachi, string maLop)
        {
                string sqlString =
                string.Format("Update SinhVien SET hoTen=N'{1}',ngaySinh=N'{2}',gioiTinh=N'{3}',diaChi=N'{4}',maLop=N'{5}' where maSV=N'{0}'",
                        maSV, hoTen,ns, gt, diachi, maLop);
                int result = db.MyExecuteNonQuery(sqlString);
                return result > 0;
        }
        public DataTable GetSVByKhoaandLop(string maKhoa,string MaLop)
        {
            if (maKhoa == "Tất cả" && MaLop=="Tất cả")
            {
                string sqlString =
                string.Format("select * from SinhVien");
                return db.MyExecuteQuery(sqlString);
            }
            else if(maKhoa=="Tất cả")
            {
                string sqlString =
                string.Format("select maSV,ngaySinh,gioiTinh,diaChi,SinhVien.maLop,hoTen from Lop,SinhVien where Lop.maLop=N'{0}'", MaLop);
                return db.MyExecuteQuery(sqlString);
            }
            else if(MaLop=="Tất cả")
            {
                string sqlString =
                string.Format("select maSV,ngaySinh,gioiTinh,diaChi,SinhVien.maLop,hoTen from Lop,SinhVien where Lop.maKhoa=N'{0}' and Lop.maLop=SinhVien.maLop", maKhoa);
                return db.MyExecuteQuery(sqlString);
            }
            else
            {
                string sqlString =
                string.Format("select maSV,ngaySinh,gioiTinh,diaChi,SinhVien.maLop,hoTen from Lop,SinhVien where Lop.maKhoa=N'{0}' and SinhVien.maLop=N'{1}'and Lop.maLop = SinhVien.maLop", maKhoa, MaLop);
                return db.MyExecuteQuery(sqlString);
            }          
        }
        public DataTable SearchSVByMaSVKL(string MaSV,string maKhoa, string MaLop)
        {
            if (maKhoa == "Tất cả" && MaLop == "Tất cả")
            {
                string sqlString =
                string.Format("select * from SinhVien where maSV like N'%{0}%'",MaSV);
                return db.MyExecuteQuery(sqlString);
            }
            else if (maKhoa == "Tất cả")
            {
                string sqlString =
                string.Format("select maSV,ngaySinh,gioiTinh,diaChi,SinhVien.maLop,hoTen from Lop,SinhVien where Lop.maLop=N'{0}' and maSV like N'%{1}%'", MaLop,MaSV);
                return db.MyExecuteQuery(sqlString);
            }
            else if (MaLop == "Tất cả")
            {
                string sqlString =
                string.Format("select maSV,ngaySinh,gioiTinh,diaChi,SinhVien.maLop,hoTen from Lop,SinhVien where Lop.maKhoa=N'{0}' and Lop.maLop=SinhVien.maLop and maSV like N'%{1}%'", maKhoa,MaSV);
                return db.MyExecuteQuery(sqlString);
            }
            else
            {
                string sqlString =
                string.Format("select maSV,ngaySinh,gioiTinh,diaChi,SinhVien.maLop,hoTen from Lop,SinhVien where Lop.maKhoa=N'{0}' and SinhVien.maLop=N'{1}'and Lop.maLop = SinhVien.maLop and maSV like N'%{2}%'", maKhoa, MaLop,MaSV);
                return db.MyExecuteQuery(sqlString);
            }
        }
        public DataTable SearchSVByMaSV(string MaSV)
        {
        
                string sqlString =
                string.Format("select maSV,ngaySinh,gioiTinh,diaChi,SinhVien.maLop,hoTen from Lop,SinhVien where Lop.maLop = SinhVien.maLop and maSV like N'%{0}%'",MaSV);
                return db.MyExecuteQuery(sqlString);
        }
        public DataTable SearchSVByHoTenSVKL(string HoTenSV, string maKhoa, string MaLop)
        {
            if (maKhoa == "Tất cả" && MaLop == "Tất cả")
            {
                string sqlString =
                string.Format("select * from SinhVien where hoTen like N'%{0}%'", HoTenSV);
                return db.MyExecuteQuery(sqlString);
            }
            else if (maKhoa == "Tất cả")
            {
                string sqlString =
                string.Format("select maSV,ngaySinh,gioiTinh,diaChi,SinhVien.maLop,hoTen from Lop,SinhVien where Lop.maLop=N'{0}' and hoTen like N'%{1}%'", MaLop, HoTenSV);
                return db.MyExecuteQuery(sqlString);
            }
            else if (MaLop == "Tất cả")
            {
                string sqlString =
                string.Format("select maSV,ngaySinh,gioiTinh,diaChi,SinhVien.maLop,hoTen from Lop,SinhVien where Lop.maKhoa=N'{0}' and Lop.maLop=SinhVien.maLop and hoTen like N'%{1}%'", maKhoa, HoTenSV);
                return db.MyExecuteQuery(sqlString);
            }
            else
            {
                string sqlString =
                string.Format("select maSV,ngaySinh,gioiTinh,diaChi,SinhVien.maLop,hoTen from Lop,SinhVien where Lop.maKhoa=N'{0}' and SinhVien.maLop=N'{1}'and Lop.maLop = SinhVien.maLop and hoTen like N'%{2}%'", maKhoa, MaLop,HoTenSV);
                return db.MyExecuteQuery(sqlString);
            }
        }
        public DataTable SearchSVByHoTenSV(string HoTenSV)
        {
           
                string sqlString =
                string.Format("select maSV,ngaySinh,gioiTinh,diaChi,SinhVien.maLop,hoTen from Lop,SinhVien where Lop.maLop = SinhVien.maLop and hoTen like N'%{0}%'",  HoTenSV);
                return db.MyExecuteQuery(sqlString);
            
        }
    }
}
