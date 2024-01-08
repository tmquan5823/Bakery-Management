using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class SanPhamDAL : DataBase
    {
        public SanPham TimKiemSanPham(string s)
        {
            OpenConnection();
            SanPham sp = new SanPham();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "select * from Product where ID_Product = '" + s + "'";
            sqlcmd.Connection = sqlCon;

            SqlDataReader reader = sqlcmd.ExecuteReader();
            if (reader.Read())
            {  
                sp.ID = reader.GetString(0);
                sp.Name = reader.GetString(1);
                sp.NSX = reader.GetDateTime(2);
                sp.HSD = reader.GetDateTime(3);
                sp.Quantity = reader.GetInt32(4);
                sp.Price = reader.GetInt32(5);
            }
            reader.Close();
            CloseConnection();
            return sp;
        }

        public SanPham TimKiemSanPhamTheoTen(string s)
        {
            OpenConnection();
            SanPham sp = new SanPham();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "select * from Product where Product_Name = '" + s + "'";
            sqlcmd.Connection = sqlCon;

            SqlDataReader reader = sqlcmd.ExecuteReader();
            if (reader.Read())
            {
                sp.ID = reader.GetString(0);
                sp.Name = reader.GetString(1);
                sp.NSX = reader.GetDateTime(2);
                sp.HSD = reader.GetDateTime(3);
                sp.Quantity = reader.GetInt32(4);
                sp.Price = reader.GetInt32(5);
            }
            reader.Close();
            CloseConnection();
            return sp;
        }
        public List<SanPham> dsSanPham()
        {
            OpenConnection();
            List<SanPham> dsSanPham = new List<SanPham>();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "select * from Product";
            sqlcmd.Connection = sqlCon;

            SqlDataReader reader = sqlcmd.ExecuteReader();
            while (reader.Read())
            {
                SanPham sp = new SanPham();
                sp.ID = reader.GetString(0);
                sp.Name = reader.GetString(1);
                sp.NSX = reader.GetDateTime(2);
                sp.HSD = reader.GetDateTime(3);
                sp.Quantity = reader.GetInt32(4);
                sp.Price = reader.GetInt32(5);
                dsSanPham.Add(sp);
            }
            reader.Close();
            CloseConnection();
            return dsSanPham;
        }
        public void ThemSanPham(SanPham sp)
        {
            OpenConnection();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "insert into Product values('" + sp.ID + "', N'" + sp.Name + "', '" + sp.NSX + "', '" + sp.HSD + "', " + sp.Quantity + ", " + sp.Price + ")";
            sqlcmd.Connection = sqlCon;
            sqlcmd.ExecuteNonQuery();
            CloseConnection();
        }
        public void CapNhatSanPham(SanPham sp)
        {
            OpenConnection();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "update Product set Product_Name = N'" + sp.Name + "', NSX = '" + sp.NSX + "', HSD = '" + sp.HSD + "', Quantity = " + sp.Quantity + ", Price = " + sp.Price + " where ID_Product = '" + sp.ID + "'";
            sqlcmd.Connection = sqlCon;
            sqlcmd.ExecuteNonQuery();
            CloseConnection();
        }

        public void CapNhatSoLuongSP(string ID, int sl)
        {
            OpenConnection();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "update Product set Quantity = Quantity - " + sl + " where ID_Product = '" + ID + "'"; 
            sqlcmd.Connection = sqlCon;
            sqlcmd.ExecuteNonQuery();
            CloseConnection();
        }

        public void XoaSanPham(SanPham sp)
        {
            OpenConnection();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "delete from Product where ID_Product = '" + sp.ID + "'";
            sqlcmd.Connection = sqlCon;
            sqlcmd.ExecuteNonQuery();
            CloseConnection();
        }
        public List<SanPham> SapXep(string s)
        {
            OpenConnection();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "select * from Product order by " + s;
            sqlcmd.Connection = sqlCon;

            List<SanPham> list = new List<SanPham>();   
            SqlDataReader reader = sqlcmd.ExecuteReader();
            while (reader.Read())
            {
                SanPham sp = new SanPham();
                sp.ID = reader.GetString(0);
                sp.Name = reader.GetString(1);
                sp.NSX = reader.GetDateTime(2);
                sp.HSD = reader.GetDateTime(3);
                sp.Quantity = reader.GetInt32(4);
                sp.Price = reader.GetInt32(5);
                list.Add(sp);
            }
            reader.Close();
            CloseConnection();
            return list;
        }
        public List<SanPham> TimKiem(string s)
        {
            OpenConnection();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "select * from Product where Product_Name like '%" + s + "%'";
            sqlcmd.Connection = sqlCon;

            List<SanPham> list = new List<SanPham>();
            SqlDataReader reader = sqlcmd.ExecuteReader();
            while (reader.Read())
            {
                SanPham sp = new SanPham();
                sp.ID = reader.GetString(0);
                sp.Name = reader.GetString(1);
                sp.NSX = reader.GetDateTime(2);
                sp.HSD = reader.GetDateTime(3);
                sp.Quantity = reader.GetInt32(4);
                sp.Price = reader.GetInt32(5);
                list.Add(sp);
            }
            reader.Close();
            CloseConnection();
            return list;
        }
    }
}
