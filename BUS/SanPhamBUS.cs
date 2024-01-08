using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Windows;

namespace BUS
{
    public class SanPhamBUS
    {
        SanPhamDAL spDAL = new SanPhamDAL();
        public List<SanPham> dsSanPham()
        {
            return spDAL.dsSanPham();
        }
        public SanPham TimKiemSanPham(string s)
        {
            return spDAL.TimKiemSanPham(s);
        }
        public void ThemSanPham(SanPham sp) { 
            if(sp.ID == "" || sp.Name == "" || sp.Quantity <= 0 || sp.Price <= 0)
            {
                MessageBox.Show("Dữ liệu nhập vào không hợp lệ");
            }
            else
            {
                spDAL.ThemSanPham(sp);
                MessageBox.Show("Thêm thành công!");
            }
        }
        public void CapNhatSanPham(SanPham sp)
        {
            if(sp.Name == "" || sp.HSD < sp.NSX || sp.Price <= 0 || sp.Quantity <= 0)
            {
                MessageBox.Show("Giá trị cập nhật không hợp lệ!");
            }
            else
            {
                spDAL.CapNhatSanPham(sp);
                MessageBox.Show("Cập nhật thành công!");
            }
        }

        public void CapNhatSoLuongSP(string ID, int sl)
        {
            spDAL.CapNhatSoLuongSP(ID, sl);
        }

        public void XoaSanPham(SanPham sp)
        {
            if(sp.ID == "")
            {
                MessageBox.Show("Vui lòng chọn sản phẩm muốn xóa!");
            }
            else
            {
                spDAL.XoaSanPham(sp);
                MessageBox.Show("Xóa thành công!");
            }
        }
        public List<SanPham> SapXep(string s)
        {
            return spDAL.SapXep(s);
        }
        public List<SanPham> TimKiem(string s)
        {
            return spDAL.TimKiem(s);
        }
        public SanPham TimKiemSanPhamTheoTen(string s)
        {
            return spDAL.TimKiemSanPhamTheoTen(s);
        }
    }
}
