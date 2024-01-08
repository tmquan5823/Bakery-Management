using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DetailBillDAL : DataBase
    {
       public void AddDetailBill(DetailBill db)
        {
            OpenConnection();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.CommandText = "insert into DetailBill values('" + db.ID_DetailBill + "', '" + db.ID_Product + "','" + db.NSX.ToString("yyyy/MM/dd") + "'," + db.Quantity + ")";
            sqlcmd.Connection = sqlCon;
            sqlcmd.ExecuteNonQuery();
        }
    }
}
