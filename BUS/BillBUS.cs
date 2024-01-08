using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BUS
{
    public class BillBus
    {
        BillDAL bDAL = new BillDAL();
        public List<Bill> DanhSach()
        {
            return bDAL.DanhSach();
        }
        public List<DetailBill> ChiTietHoaDon(string s)
        {
            return bDAL.ChiTietHoaDon(s);
        }
        public void AddBill(Bill b)
        {
            bDAL.AddBill(b);    
        }
        public int GetCountBillByID(string id)
        {
            return bDAL.GetCountBillByID(id);
        }
    }
}
