using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Bill
    {
        public string ID_Bill { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Transaction { get; set; }
        public int TotalBill { get; set; }
        public string ID_Staff { get; set; }
    }
}
