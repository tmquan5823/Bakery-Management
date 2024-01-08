using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DetailBill
    {
        public string ID_DetailBill { get; set; }
        public string ID_Product { get; set; }
        public DateTime NSX { get; set; }   
        public int Quantity { get; set; } 
    }
}
