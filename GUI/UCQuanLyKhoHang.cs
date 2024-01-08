using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI
{
    public partial class UCQuanLyKhoHang : UserControl
    {
        
        NguyenLieuBUS nlBUS = new NguyenLieuBUS();
        StaffBUS sBUS = new StaffBUS();
        Staff staff = new Staff();
        UserAccount acc = new UserAccount();
        public UCQuanLyKhoHang()
        {
            InitializeComponent();
        }
        public UCQuanLyKhoHang(UserAccount uc)
        {
            acc = uc;
            InitializeComponent();
        }
        private void UCQuanLyKhoHang_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        public void HienThi()
        {
            listView1.Items.Clear();
            foreach(var item in nlBUS.DanhSachNguyenLieu())
            {
                ListViewItem lvi = new ListViewItem(item.ID_NguyenLieu);
                lvi.SubItems.Add(item.TenNguyenLieu);
                lvi.SubItems.Add(item.SoLuong.ToString());
                lvi.SubItems.Add(item.LoHang);
                lvi.SubItems.Add(item.NoiCungCap);
                lvi.SubItems.Add(item.NgayNhapKho.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(item.HanSuDung.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(item.ID_Staff);
                listView1.Items.Add(lvi);
            }
            staff = sBUS.GetStaffByUserID(acc.ID_User);
            txt_tenNV.Text = staff.Staff_Name;
            txt_idNV.Text = staff.ID_Staff;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            ListViewItem lvi = listView1.SelectedItems[0];
            txt_ID.Text = lvi.SubItems[0].Text;
            txt_tenNL.Text = lvi.SubItems[1].Text;
            txt_soluong.Text = lvi.SubItems[2].Text;
            txt_lohang.Text = lvi.SubItems[3].Text;
            txt_noicungcap.Text = lvi.SubItems[4].Text;
            {
                string[] str = lvi.SubItems[5].Text.Split('/');
                dtp_ngaynhap.Value = new DateTime(Int32.Parse(str[2]), Int32.Parse(str[1]), Int32.Parse(str[0]));
            }
            {
                string[] str = lvi.SubItems[6].Text.Split('/');
                dtp_hsd.Value = new DateTime(Int32.Parse(str[2]), Int32.Parse(str[1]), Int32.Parse(str[0]));
            }
            txt_idNV.Text = lvi.SubItems[7].Text;
            txt_tenNV.Text = sBUS.GetStaffByID(txt_idNV.Text).Staff_Name;
        }
        public void EditMode()
        {
            if (txt_ID.ReadOnly == true)
            {
                txt_ID.ReadOnly = txt_tenNL.ReadOnly = txt_soluong.ReadOnly = txt_lohang.ReadOnly = txt_noicungcap.ReadOnly = txt_idNV.ReadOnly = false;
                dtp_ngaynhap.Enabled = dtp_hsd.Enabled = true;
            }
            else
            {
                txt_ID.ReadOnly = txt_tenNL.ReadOnly = txt_soluong.ReadOnly = txt_lohang.ReadOnly = txt_noicungcap.ReadOnly = txt_idNV.ReadOnly = true;
                dtp_ngaynhap.Enabled = dtp_hsd.Enabled = false;
            }
        }

        public void SetNull()
        {
            txt_ID.Text = "";
            txt_tenNL.Text = "";
            txt_soluong.Text = "";
            txt_lohang.Text = "";
            txt_noicungcap.Text = "";
            txt_tenNV.Text = "";
            txt_idNV.Text = "";
            dtp_ngaynhap.Value = dtp_hsd.Value = DateTime.Today;
        }
        public void HideButton()
        {
            if(btn_them.Visible == true)
            {
                btn_them.Visible = btn_capnhat.Visible = btn_xoa.Visible = false;
            }
            else
            {
                btn_them.Visible = btn_capnhat.Visible = btn_xoa.Visible = true;
            }
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            SetNull();
            EditMode();
            HideButton();
            btn_xacnhan.Visible = true;
        }

        public void ThemNguyenLieu()
        {
            NguyenLieu nl = new NguyenLieu();
            nl.ID_NguyenLieu = txt_ID.Text;
            nl.TenNguyenLieu = txt_tenNL.Text;
            {
                if (txt_soluong.Text != "") { nl.SoLuong = Int32.Parse(txt_soluong.Text); }
                else nl.SoLuong = 0;

            }
            nl.LoHang = txt_lohang.Text;
            nl.NoiCungCap = txt_noicungcap.Text;
            nl.ID_Staff = txt_idNV.Text;
            nl.NgayNhapKho = dtp_ngaynhap.Value;
            nl.HanSuDung = dtp_hsd.Value;
            nlBUS.ThemNguyenLieu(nl);
        }

        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            EditMode();
            btn_xacnhan.Visible = false;
            HideButton();
            ThemNguyenLieu();
            SetNull();
            HienThi();
        }
        private void btn_capnhat_Click(object sender, EventArgs e)
        {

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {

        }

    }
}
