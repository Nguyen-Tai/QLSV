using QLSV.BD_layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV.BS_layer
{
    class BLAccount
    {
        DataProvider db = null;
        public BLAccount()
        {
            db = new DataProvider();
        }
        public DataTable LoginAdmin(string userName, string passWord)
        {
            string query = string.Format("Select * From Login where userName=N'{0}' and passWord=N'{1}' and Quyen=N'{2}'",userName,passWord,"Admin"); 
            return db.MyExecuteQuery(query);
        }
        public DataTable LoginMember(string userName, string passWord)
        {
            string query = string.Format("Select * From Login where userName=N'{0}' and passWord=N'{1}' and Quyen=N'{2}'", userName, passWord,"Member");
            return db.MyExecuteQuery(query);         
        }
        public bool ChangePassAccount(string username,string pass, string newpass,string comfimMK, string quyen)
        {
            DataTable tb = new DataTable();
            if (quyen == "Member") //member
            {
                if (LoginMember(username, pass).Rows.Count > 0) //nhập đúng mk cũ
                {
                    if (newpass == comfimMK)
                    {
                        string query = string.Format("UPDATE Login SET passWord = N'{1}' WHERE UserName = N'{0}'", username, newpass);
                        int result = db.MyExecuteNonQuery(query);
                        return result > 0;
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
                    string query = string.Format("UPDATE Login SET passWord = N'{1}' WHERE UserName = N'{0}'", username, newpass);
                    int result = db.MyExecuteNonQuery(query);
                    return result > 0;
                }
                else
                {
                    return false;
                }
            }
        }
        public DataTable GetAccount()
        {
            return db.MyExecuteQuery("select * from Login");
        }
        public bool DeleteAccount(string user)
        {
            string sqlString =string.Format("Delete From Login Where userName=N'{0}'",user);
            int result= db.MyExecuteNonQuery(sqlString);
            return result > 0;
        }
        public bool InsertAccount(string user,string pass,string Hoten,string GT,string phone,string email)
        {
            string sqlString =
           string.Format("Insert Login (userName ,passWord,hoTen,gioiTinh,Phone,Email,Quyen)" +
           "VALUES(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}')",user,pass,Hoten,GT,phone,email,"Member");
            int result = db.MyExecuteNonQuery(sqlString);
            return result > 0;
        }
        public bool UpdateAccount(string user, string pass, string Hoten, string GT, string phone, string email)
        {
            string sqlString =
            string.Format("Update Login SET passWord=N'{1}',hoTen=N'{2}',gioiTinh=N'{3}',Phone=N'{4}',Email=N'{5}' where userName=N'{0}'",user,pass,Hoten,GT,phone,email);
            int result = db.MyExecuteNonQuery(sqlString);
            return result > 0;
        }
    }
}
