using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QLSVLinq.BS_Layer
{
    class BLLogin
    {
        public System.Data.Linq.Table<Login> LayLogin()
        {
            DataSet ds = new DataSet();
            QLSVDataContext qlSV = new QLSVDataContext();
            return qlSV.Logins;
        }
        public List<Login> LoginAdmin(string userName, string passWord, ref string err)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = (from tp in qlSV.Logins
                           where tp.userName == userName && tp.passWord == passWord && tp.Quyen == "Admin"
                           select tp).ToList();
            return tpQuery ;
        }
        public List<Login> LoginMember(string userName, string passWord)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = (from tp in qlSV.Logins
                           where tp.userName == userName && tp.passWord == passWord && tp.Quyen == "Member"
                           select tp).ToList();
            return tpQuery;
        }
        public bool ThemAc(string user, string pass, string Hoten, string GT, string phone, string email, ref string err)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            Login kh = new Login();
            kh.userName = user;
            kh.passWord = pass;
            kh.hoTen = Hoten;
            kh.gioiTinh = GT;
            kh.Phone = phone;
            kh.Email = email;
            qlSV.Logins.InsertOnSubmit(kh);
            qlSV.Logins.Context.SubmitChanges();
            return true;
        }
        public bool XoaAc(ref string err, string user)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = from tp in qlSV.Logins
                          where tp.userName == user
                          select tp;
            qlSV.Logins.DeleteAllOnSubmit(tpQuery);
            qlSV.SubmitChanges();
            return true;
        }
        public bool CapNhatAc(string user, string pass, string Hoten, string GT, string phone, string email, ref string err)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = (from tp in qlSV.Logins
                           where tp.userName == user
                           select tp).SingleOrDefault();
            if (tpQuery != null)
            {
                tpQuery.passWord = pass;
                tpQuery.hoTen = Hoten;
                tpQuery.gioiTinh = GT;
                tpQuery.Phone = phone;
                tpQuery.Email = email;
                qlSV.SubmitChanges();
            }
            return true;
        }
        //public List<Login> ChangePass(string username, string pass, string newpass, string comfimMK, string quyen)
        //{

        //    QLSVDataContext qlSV = new QLSVDataContext();
        //    if (quyen == "Member")
        //    {
        //        if(LoginMember(username, pass))
        //        var tpQuery = (from tp in qlSV.Acs
        //                       where tp.maAc.Contains(MaAc)
        //                       select tp).ToList();
        //        return tpQuery;
        //    }
        //}
        

        //public List<Ac> LoadAcTrongMaLop(string MaLop)
        //{
        //    QLSVDataContext qlSV = new QLSVDataContext();
        //    var tpQuery = (from tp in qlSV.Lops
        //                   from vp in qlSV.Khoas
        //                   from up in qlSV.Acs
        //                   where vp.maKhoa == tp.maKhoa
        //                   && tp.maLop == MaLop && vp.maKhoa == up.maKhoa
        //                   select up).ToList();
        //    return tpQuery;
        //}
    }
}
