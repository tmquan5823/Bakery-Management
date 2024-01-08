using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPham
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime NSX { get; set; }
        public DateTime HSD { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
