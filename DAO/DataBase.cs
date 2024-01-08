using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataBase
    {
        protected string strCon = @"Data Source=LAPTOP-0IQ7Q3Q3;Initial Catalog=PBL3_1;Integrated Security=True";
        protected SqlConnection sqlCon = null;

        public void OpenConnection()
        {
            if(sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if(sqlCon.State == System.Data.ConnectionState.Closed)
            {
                sqlCon.Open();
            }
        }
        public void CloseConnection()
        {
            if(sqlCon.State == System.Data.ConnectionState.Open && sqlCon != null)
            {
                sqlCon.Close();
            }
        }
    }
}
