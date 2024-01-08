using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUS
{
    public class UserAccountBUS
    {
        UserAccountDAL ucDAL = new UserAccountDAL();

        public static UserAccountBUS instance = new UserAccountBUS();   

        public Boolean CheckLogin(UserAccount acc)
        {
            return ucDAL.CheckLogin(acc);  
        }
        public string CheckInfo(UserAccount acc)
        {
            if(acc.Account.Length < 6 || acc.PassWord.Length < 6)
            {
                return "Vui lòng nhập tên đăng nhập và mật khẩu lớn hơn 6 ký tự!";
            }
            if(!CheckAccount(acc.Account))
            {
                return "Tên đăng nhập đã tồn tại!";
            }
            return "";
        }

        public Boolean CheckAccount(string acc)
        {
            return ucDAL.CheckAccount(acc);
        }

        public void AddUserAccount(UserAccount acc)
        {
            ucDAL.AddUserAccount(acc);
        }

        public int GetLastID()
        {
            return ucDAL.GetLastID();
        }

        public void DeleteUserAccount(int s)
        {
            ucDAL.DeleteUserAccount(s);
        }

        public UserAccount GetAccountByID(int id)
        {
            return ucDAL.GetAccountByID(id);
        }

        public void UpdatePassword(UserAccount acc)
        {
            ucDAL.UpdatePassword(acc);
        }
    }
}
