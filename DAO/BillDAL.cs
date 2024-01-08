using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BillDAL : DataBase
    {
        //danh sach hoa don
        public List<Bill> DanhSach()
        {
            List<Bill> list = new List<Bill>();
            OpenConnection();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "select * from Bill";
            sqlcmd.Connection = sqlCon;

            SqlDataReader reader = sqlcmd.ExecuteReader();
            while (reader.Read())
            {
                Bill bill = new Bill();
                bill.ID_Bill = reader.GetString(0);
                bill.CustomerName = reader.GetString(1);
                bill.PhoneNumber = reader.GetString(2);
                bill.Transaction = reader.GetDateTime(3);
                bill.TotalBill = reader.GetInt32(4);
                bill.ID_Staff = reader.GetString(5);
                list.Add(bill);
            }
            reader.Close();
            return list;
        }

        //chi tiet hoa don
        public List<DetailBill> ChiTietHoaDon(string s)
        {
            List<DetailBill> list = new List<DetailBill>();
            OpenConnection();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "select * from DetailBill where ID_DetailBill = '" + s + "'";
            sqlcmd.Connection = sqlCon;

            SqlDataReader reader = sqlcmd.ExecuteReader();
            while (reader.Read())
            {
                DetailBill bill = new DetailBill();
                bill.ID_DetailBill = reader.GetString(0);
                bill.ID_Product = reader.GetString(1);
                bill.NSX = reader.GetDateTime(2);
                bill.Quantity = reader.GetInt32(3);
                list.Add(bill);
            }
            reader.Close();
            return list;
        }

        //Them hoa don
        public void AddBill(Bill bill)
        {
            OpenConnection();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "insert into Bill values('" + bill.ID_Bill + "', N'" + bill.CustomerName + "', '" + bill.PhoneNumber +"', '" + bill.Transaction.ToString("yyyy/MM/dd") + "'," + bill.TotalBill + ", '" + bill.ID_Staff + "')";
            sqlcmd.Connection = sqlCon;
            sqlcmd.ExecuteNonQuery();
        }

        //Dem so luong hoa don de set ID hoa don
        public int GetCountBillByID(string id)
        {
            OpenConnection();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "select count(*) from Bill where ID_Bill like '" + id + "%'";
            sqlcmd.Connection = sqlCon;
            int count = (int)sqlcmd.ExecuteScalar();
            return count + 1;
        }
    }
}
