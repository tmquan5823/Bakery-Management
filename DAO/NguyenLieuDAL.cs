using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace DAL
{
    public class NguyenLieuDAL : DataBase
    {
        public List<NguyenLieu> DanhSachNguyenLieu()
        {
            OpenConnection();

            List<NguyenLieu> list = new List<NguyenLieu>();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "select * from NguyenLieu";
            sqlcmd.Connection = sqlCon;

            SqlDataReader reader = sqlcmd.ExecuteReader();
            while (reader.Read())
            {
                NguyenLieu nl = new NguyenLieu();
                nl.ID_NguyenLieu = reader.GetString(0);
                nl.TenNguyenLieu = reader.GetString(1);
                nl.SoLuong = reader.GetInt32(2);
                nl.LoHang = reader.GetString(3);
                nl.NoiCungCap = reader.GetString(4);
                nl.HanSuDung = reader.GetDateTime(5);
                nl.ID_Staff = reader.GetString(6);
                nl.NgayNhapKho = reader.GetDateTime(7);
                list.Add(nl);
            }
            reader.Close();
            CloseConnection();
            return list;
        }

        public void ThemNguyenLieu(NguyenLieu nl)
        {
            OpenConnection();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcmd.CommandText = "ThemNguyenLieu";
            sqlcmd.Parameters.Add("@id", SqlDbType.VarChar).Value = nl.ID_NguyenLieu;
            sqlcmd.Parameters.Add ("@tenNL", SqlDbType.NVarChar).Value = nl.TenNguyenLieu;
            sqlcmd.Parameters.Add("@soluong", SqlDbType.Int).Value = nl.SoLuong;
            sqlcmd.Parameters.Add("@loHang", SqlDbType.NVarChar).Value = nl.LoHang;
            sqlcmd.Parameters.Add("@noiCC", SqlDbType.NVarChar).Value = nl.NoiCungCap;
            sqlcmd.Parameters.Add("@ngayNhap", SqlDbType.Date).Value = nl.NgayNhapKho;
            sqlcmd.Parameters.Add("@hsd", SqlDbType.Date).Value = nl.HanSuDung;
            sqlcmd.Parameters.Add("@idNV", SqlDbType.VarChar).Value = nl.ID_Staff;
            sqlcmd.Connection = sqlCon;

            sqlcmd.ExecuteNonQuery();

            CloseConnection();
        }
    }
}
