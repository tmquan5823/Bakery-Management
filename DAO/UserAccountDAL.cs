using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class UserAccountDAL : DataBase
    {
        public Boolean CheckLogin(UserAccount acc)
        {
            OpenConnection();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "select * from UserAccount where Account = '" + acc.Account + "' and PassWord = '" + acc.PassWord + "'";
            sqlcmd.Connection = sqlCon;
            SqlDataReader dr = sqlcmd.ExecuteReader();
            if(dr.Read())
            {
                acc.ID_User = dr.GetInt32(0);
                acc.Role = dr.GetString(3);
                dr.Close();
                return true;
            }
            dr.Close();
            return false;
        }

        public Boolean CheckAccount(string acc)
        {
            OpenConnection();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "select * from UserAccount where Account = '" + acc + "'";
            sqlcmd.Connection = sqlCon;
            SqlDataReader dr = sqlcmd.ExecuteReader();
            if(dr.Read()) {
                dr.Close();
                return false; 
            }
            dr.Close();
            return true;
        }

        public void AddUserAccount(UserAccount acc)
        {
            OpenConnection();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "insert into UserAccount values('" + acc.Account + "','" + acc.PassWord + "','" + acc.Role + "')";
            sqlcmd.Connection = sqlCon;

            sqlcmd.ExecuteNonQuery();
        }

        public int GetLastID()
        {
            OpenConnection();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "select MAX(ID_User) from UserAccount";
            sqlcmd.Connection = sqlCon;

            return (int)sqlcmd.ExecuteScalar();  
        }

        public void DeleteUserAccount(int s)
        {
            OpenConnection();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "delete from UserAccount where ID_User = " + s;
            sqlcmd.Connection = sqlCon;

            sqlcmd.ExecuteNonQuery();   
        }

        public UserAccount GetAccountByID(int id)
        {
            UserAccount uc = new UserAccount();
            OpenConnection();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "select * from UserAccount where ID_User = " + id;
            sqlcmd.Connection = sqlCon;

            SqlDataReader reader = sqlcmd.ExecuteReader();
            if (reader.Read())
            {
                uc.ID_User = reader.GetInt32(0);
                uc.Account = reader.GetString(1);
                uc.PassWord = reader.GetString(2);
                uc.Role = reader.GetString(3);

            }
            reader.Close();
            return uc;
        }

        public void UpdatePassword(UserAccount acc)
        {
            OpenConnection();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "update UserAccount set PassWord = '" + acc.PassWord + "' where ID_User = " + acc.ID_User;
            sqlcmd.Connection = sqlCon;

            sqlcmd.ExecuteNonQuery();
        }
    }
}
