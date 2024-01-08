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
    public class NguyenLieuBUS
    {
        NguyenLieuDAL nlDAL = new NguyenLieuDAL();
        public List<NguyenLieu> DanhSachNguyenLieu()
        {
            return nlDAL.DanhSachNguyenLieu();
        }
        public void ThemNguyenLieu(NguyenLieu nl)
        {
            if(nl.ID_NguyenLieu == "" || nl.TenNguyenLieu == "" || nl.SoLuong <= 0 || nl.NoiCungCap == "" || nl.LoHang == ""|| nl.NgayNhapKho > nl.HanSuDung || nl.ID_Staff == "")
            {
                MessageBox.Show("Thông tin nhập vào không hợp lệ!");
                return;
            }
            nlDAL.ThemNguyenLieu(nl);
            MessageBox.Show("Thêm thành công!");
        }
    }
}
