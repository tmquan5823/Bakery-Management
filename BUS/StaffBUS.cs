using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace BUS
{
    public class StaffBUS
    {
        StaffDAL sDAL = new StaffDAL();

        public List<Staff> DanhSachNhanVien()
        {
            return sDAL.DanhSachNhanVien();
        }

        public List<Staff> SapXepNhanVien(string s)
        {
            return sDAL.SapXepNhanVien(s);
        }
        public Staff GetStaffByID(string s)
        {
            return sDAL.GetStaffByID(s);
        }

        public List<Staff> TimKiem(string s)
        {
            return sDAL.TimKiem(s);
        }

        public Boolean CheckTTNhanVien(Staff s)
        {
            if (s.ID_Staff == "" || s.Staff_Name == "" || s.Sex == null || s.CCCD == "" || s.PhoneNumber == "" || s.Address == "" || s.Shift == "" || s.Salary <= 0)
            {
                return true;
            }
            else return true;
        }
        public void ThemNhanVien(Staff s)
        {
            sDAL.ThemNhanVien(s);
            
        }
        public void XoaNhanVien(Staff s)
        {
            if (s.ID_Staff == "")
            {
                MessageBox.Show("Vui lòng chọn sản phẩm muốn xóa!");
            }
            else
            {
                sDAL.XoaNhanVien(s);
                MessageBox.Show("Xóa thành công!");
            }
        }
        public void CapNhatNhanVien(Staff s)
        {
            if (s.Staff_Name == "" || s.Sex == null || s.CCCD == "" || s.PhoneNumber == "" || s.Address == "" || s.Shift == "" || s.Salary <= 0)
            {
                MessageBox.Show("Thông tin nhập vào không hợp lệ!");
            }
            else
            {
                sDAL.CapNhatNhanVien(s);
                MessageBox.Show("Cập nhật thành công!");
            }
        }
        public Staff GetStaffByUserID(int id)
        {
            return sDAL.GetStaffByUserID(id);
        }

        public int GetNumberOfStaff()
        {
            return sDAL.GetNumberOfStaff();
        }
    }
}
