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
    public partial class UCQuanLyHoaDon : UserControl
    {
        StaffBUS sBUS = new StaffBUS();
        BillBus bBUS = new BillBus();
        SanPhamBUS spBUS = new SanPhamBUS();
        public UCQuanLyHoaDon()
        {
            InitializeComponent();
        }
        public void HienThi()
        {
            listView2.Items.Clear();
            foreach(var item in bBUS.DanhSach())
            {
                ListViewItem lvi = new ListViewItem(item.ID_Bill);
                lvi.SubItems.Add(item.CustomerName);
                lvi.SubItems.Add(item.PhoneNumber);
                lvi.SubItems.Add(item.Transaction.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(item.TotalBill.ToString());
                lvi.SubItems.Add(item.ID_Staff);
                listView2.Items.Add(lvi);
            }
        }

        private void UCQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            HienThi();
        }
        public void ThongTinHoaDon()
        {
            dtp_tgThanhToan.Value.ToString("dd/MM/yyyy");
        }

        private void listView2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 0) return;
            ListViewItem lvi = listView2.SelectedItems[0];
            txt_idHoaDon.Text = lvi.SubItems[0].Text;
            txt_tenKhachHang.Text = lvi.SubItems[1].Text;
            txt_sdt.Text = lvi.SubItems[2].Text;
            string[] str = lvi.SubItems[3].Text.Split('/');
            txt_IDnhanVien.Text = lvi.SubItems[5].Text; dtp_tgThanhToan.Value = new DateTime(Int32.Parse(str[2]), Int32.Parse(str[1]), Int32.Parse(str[0]));
            lbl_total.Text = lvi.SubItems[4].Text;
            txt_tenNV.Text = sBUS.GetStaffByID(txt_IDnhanVien.Text).Staff_Name;
            listView1.Items.Clear();
            foreach (var item in bBUS.ChiTietHoaDon(txt_idHoaDon.Text))
            {
                ListViewItem lvi1 = new ListViewItem(item.ID_Product);
                lvi1.SubItems.Add(spBUS.TimKiemSanPham(item.ID_Product).Name);
                lvi1.SubItems.Add(item.NSX.ToString("dd/MM/yyyy"));
                lvi1.SubItems.Add(spBUS.TimKiemSanPham(item.ID_Product).Price.ToString());
                lvi1.SubItems.Add(item.Quantity.ToString());
                listView1.Items.Add(lvi1);
            }
        }
    }
}
