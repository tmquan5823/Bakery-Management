using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUS
{
    public class DetailBillBUS
    {
        DetailBillDAL dbDAL = new DetailBillDAL();
        public void AddDetailBill(DetailBill db)
        {
            dbDAL.AddDetailBill(db);
        }
    }
}
