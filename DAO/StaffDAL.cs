using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class StaffDAL : DataBase
    {
        //Danh sach nhan vien
        public List<Staff> DanhSachNhanVien()
        {
            List<Staff> list = new List<Staff>();
            OpenConnection();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "select * from Staff";
            sqlcmd.Connection = sqlCon;

            SqlDataReader reader = sqlcmd.ExecuteReader();
            while (reader.Read())
            {
                Staff nv = new Staff();
                nv.ID_Staff = reader.GetString(0);
                nv.Staff_Name = reader.GetString(1);
                nv.BirthDay = reader.GetDateTime(2);
                nv.Sex = reader.GetString(3);
                nv.CCCD = reader.GetString(4);
                nv.PhoneNumber = reader.GetString(5);
                nv.Address = reader.GetString(6);
                nv.Shift = reader.GetString(7);
                nv.Salary = reader.GetInt32(8);
                list.Add(nv);
            }
            reader.Close();
            return list;
        }
        //Sap xep nhan vien
        public List<Staff> SapXepNhanVien(string s)
        {
            List<Staff> list = new List<Staff>();
            OpenConnection();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = "select * from Staff order by " + s;
            sqlcmd.Connection = sqlCon;

            SqlDataReader reader = sqlcmd.ExecuteReader();
            while (reader.Read())
            {
                Staff nv = new Staff();
                nv.ID_Staff = reader.GetString(0);
                nv.Staff_Name = reader.GetString(1);
                nv.BirthDay = reader.GetDateTime(2);
                nv.Sex = reader.GetString(3);
                nv.CCCD = reader.GetString(4);
                nv.PhoneNumber = reader.GetString(5);
                nv.Address = reader.GetString(6);
                nv.Shift = reader.GetString(7);
                nv.Salary = reader.GetInt32(8);
                list.Add(nv);
            }
            reader.Close(); return list;
        }

        //Tim kiem nhan vien
        public Staff GetStaffByID(string s)
        {
            OpenConnection();
            Staff nv = new Staff();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "select * from Staff where ID_Staff = '" + s + "'";
            sqlcmd.Connection = sqlCon;

            SqlDataReader reader = sqlcmd.ExecuteReader();
            if (reader.Read())
            {
                nv.ID_Staff = reader.GetString(0);
                nv.Staff_Name = reader.GetString(1);
                nv.BirthDay = reader.GetDateTime(2);
                nv.Sex = reader.GetString(3);
                nv.CCCD = reader.GetString(4);
                nv.PhoneNumber = reader.GetString(5);
                nv.Address = reader.GetString(6);
                nv.Shift = reader.GetString(7);
                nv.Salary = reader.GetInt32(8);
                nv.ID_User = reader.GetInt32(9);
                nv.urlImage = (byte[])reader.GetValue(10);
            }
            reader.Close();
            return nv;
        }

        public List<Staff> TimKiem(string s)
        {
            OpenConnection();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "select * from Staff where Staff_Name like '%" + s + "%'";
            sqlcmd.Connection = sqlCon;

            List<Staff> list = new List<Staff>();
            SqlDataReader reader = sqlcmd.ExecuteReader();
            while (reader.Read())
            {
                Staff st = new Staff();
                st.ID_Staff = reader.GetString(0);
                st.Staff_Name = reader.GetString(1);
                st.BirthDay = reader.GetDateTime(2);
                st.Sex = reader.GetString(3);
                st.CCCD = reader.GetString(4);
                st.PhoneNumber = reader.GetString(5);
                st.Address = reader.GetString(6);
                st.Shift = reader.GetString(7);
                st.Salary = reader.GetInt32(8);
                list.Add(st);
            }
            reader.Close();
            CloseConnection();
            return list;
        }

        //Them nhan vien
        public void ThemNhanVien(Staff s)
        {
            OpenConnection();
            Staff nv = new Staff();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcmd.CommandText = "addStaff";
            sqlcmd.Parameters.Add("@id",SqlDbType.VarChar).Value = s.ID_Staff;
            sqlcmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = s.Staff_Name;
            sqlcmd.Parameters.Add("@birth", SqlDbType.Date).Value = s.BirthDay;
            sqlcmd.Parameters.Add("@sex", SqlDbType.NVarChar).Value = s.Sex;
            sqlcmd.Parameters.Add("@cccd", SqlDbType.VarChar).Value = s.CCCD;
            sqlcmd.Parameters.Add("@sdt", SqlDbType.VarChar).Value = s.PhoneNumber;
            sqlcmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = s.Address;
            sqlcmd.Parameters.Add("@shift", SqlDbType.NVarChar).Value = s.Shift;
            sqlcmd.Parameters.Add("@salary", SqlDbType.Int).Value = s.Salary;
            sqlcmd.Parameters.Add("@userID", SqlDbType.Int).Value = s.ID_User;
            sqlcmd.Parameters.Add("@url", SqlDbType.Image).Value = s.urlImage;
            sqlcmd.Connection = sqlCon;

            sqlcmd.ExecuteNonQuery();
        }

        //Xoa nhan vien
        public void XoaNhanVien(Staff s)
        {
            OpenConnection();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "delete from Staff where ID_Staff = '" + s.ID_Staff + "'";
            sqlcmd.Connection = sqlCon;
            sqlcmd.ExecuteNonQuery();
        }

        //Cap nhat tt nhan vien
        public void CapNhatNhanVien(Staff s)
        {
            OpenConnection();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "CapNhatTTNhanVien";
            sqlcmd.Parameters.Add("@id", SqlDbType.VarChar).Value = s.ID_Staff;
            sqlcmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = s.Staff_Name;
            sqlcmd.Parameters.Add("@birth", SqlDbType.Date).Value = s.BirthDay;
            sqlcmd.Parameters.Add("@sex", SqlDbType.NVarChar).Value = s.Sex;
            sqlcmd.Parameters.Add("@cccd", SqlDbType.VarChar).Value = s.CCCD;
            sqlcmd.Parameters.Add("@sdt", SqlDbType.VarChar).Value = s.PhoneNumber;
            sqlcmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = s.Address;
            sqlcmd.Parameters.Add("@salary", SqlDbType.Int).Value = s.Salary;
            sqlcmd.Parameters.Add("@shift", SqlDbType.NVarChar).Value = s.Shift;
            sqlcmd.Connection = sqlCon;

            sqlcmd.ExecuteNonQuery();
        }
        
        //Lay thong tin nhan vien bang userID
        public Staff GetStaffByUserID(int id)
        {
            Staff s = new Staff();
            OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Staff where ID_User = " + id;
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                s.ID_Staff = reader.GetString(0);
                s.Staff_Name = reader.GetString(1);
            }
            reader.Close(); 
            return s;
        }

        public int GetNumberOfStaff()
        {
            OpenConnection();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = "select count(*) from staff";
            sqlcmd.Connection = sqlCon; 
            return (int)sqlcmd.ExecuteScalar();   
        }
    }
}
