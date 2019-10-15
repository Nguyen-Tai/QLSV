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
        public List<Login> LoginAdmin(string userName, string passWord)
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
        public bool ThemAc(string user, string pass, string Hoten, string GT, string phone, string email)
        {
            try
            {
                QLSVDataContext qlSV = new QLSVDataContext();
                Login kh = new Login();
                kh.userName = user;
                kh.passWord = pass;
                kh.hoTen = Hoten;
                kh.gioiTinh = GT;
                kh.Phone = phone;
                kh.Email = email;
                kh.Quyen = "Member";
                qlSV.Logins.InsertOnSubmit(kh);
                qlSV.Logins.Context.SubmitChanges();
                return true;
            }catch
            {
                return false;
            }
        }
        public bool XoaAc( string user)
        {
            try
            {
                QLSVDataContext qlSV = new QLSVDataContext();
                var tpQuery = from tp in qlSV.Logins
                              where tp.userName == user
                              select tp;
                qlSV.Logins.DeleteAllOnSubmit(tpQuery);
                qlSV.SubmitChanges();
                return true;
            }catch
            {
                return false;
            }
        }
        public bool CapNhatAc(string user, string pass, string Hoten, string GT, string phone, string email)
        {
            //try
            {
                QLSVDataContext qlSV = new QLSVDataContext();
                var query = (from tp in qlSV.Logins
                               where tp.userName == user.Trim()
                               select tp);
                foreach (var item in query)
                { 
                  item.passWord = pass;
                    item.hoTen = Hoten;
                    item.gioiTinh = GT;
                    item.Phone = phone;
                    item.Email = email;
                }
                qlSV.SubmitChanges();
                return true;
            }//catch
            {
                return false;
            }
        }
        
        public bool ChangePassAccount(string username, string pass, string newpass, string comfimMK, string quyen)
        {
            if(quyen=="Member")
            {
                if (LoginMember(username, pass).Count > 0)
                {
                    if (newpass == comfimMK)
                    {
                        QLSVDataContext qlSV = new QLSVDataContext();
                        var query = (from tp in qlSV.Logins
                                       where tp.userName == username
                                       select tp);
                        foreach (var item in query)
                        {
                            item.passWord = newpass;                
                        }
                        qlSV.SubmitChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            else //admin
            {
                if (newpass == comfimMK)
                {
                    QLSVDataContext qlSV = new QLSVDataContext();
                    var query = (from tp in qlSV.Logins
                                   where tp.userName == username
                                   select tp);

                    foreach (var item in query)
                    {
                        item.passWord = newpass;
                    }
                    qlSV.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
