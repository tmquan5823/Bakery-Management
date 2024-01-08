using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NguyenLieu
    {
        public string ID_NguyenLieu { get; set; }
        public string TenNguyenLieu { get; set; }
        public int SoLuong { get; set; }
        public string LoHang { get; set; }
        public string NoiCungCap { get; set; }
        public DateTime HanSuDung { get; set; }
        public string ID_Staff { get; set; }
        public DateTime NgayNhapKho { get; set; }
    }
}
