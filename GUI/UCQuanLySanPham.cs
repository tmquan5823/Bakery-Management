using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class UCQuanLySanPham : UserControl
    {
        SanPham sp = new SanPham();
        SanPhamBUS bus = new SanPhamBUS(); 
        String imageLocation = "";
        public UCQuanLySanPham()
        {
            InitializeComponent();
        }
        public void hienThi()
        {
            List<SanPham> list = new List<SanPham>();
            SanPhamBUS spBUS = new SanPhamBUS();
            list = spBUS.dsSanPham();
            listView1.Items.Clear();
            foreach (SanPham sp in list)
                {
                 ListViewItem lvi = new ListViewItem(sp.ID);
                 lvi.SubItems.Add(sp.Name);
                 lvi.SubItems.Add(sp.NSX.ToString("dd/MM/yyyy"));
                 lvi.SubItems.Add(sp.HSD.ToString("dd/MM/yyyy"));
                 lvi.SubItems.Add(sp.Quantity.ToString());
                 lvi.SubItems.Add(sp.Price.ToString());
                 listView1.Items.Add(lvi);
            }
        }
        public void hienThi(List<SanPham> list)
        {
            listView1.Items.Clear();
            foreach (SanPham sp in list)
            {
                ListViewItem lvi = new ListViewItem(sp.ID);
                lvi.SubItems.Add(sp.Name);
                lvi.SubItems.Add(sp.NSX.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(sp.HSD.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(sp.Quantity.ToString());
                lvi.SubItems.Add(sp.Price.ToString());
                listView1.Items.Add(lvi);
            }
        }
        private void UCQuanLySanPham_Load(object sender, EventArgs e)
        {
            hienThi();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem lvi = listView1.SelectedItems[0];
                txt_id.Text = lvi.SubItems[0].Text;
                txt_tenSP.Text = lvi.SubItems[1].Text;
                {
                    string[] strArr = lvi.SubItems[2].Text.Split('/');
                    int year = Int32.Parse(strArr[2]);
                    int month = Int32.Parse(strArr[1]);
                    int day = Int32.Parse(strArr[0]);
                    dtp_nsx.Value = new DateTime(year, month, day);
                }
                {
                    string[] strArr = lvi.SubItems[3].Text.Split('/');
                    int year = Int32.Parse(strArr[2]);
                    int month = Int32.Parse(strArr[1]);
                    int day = Int32.Parse(strArr[0]);
                    dtp_hsd.Value = new DateTime(year, month, day);
                }
                txt_soLuong.Text = lvi.SubItems[4].Text;
                txt_gia.Text = lvi.SubItems[5].Text;
                try
                {
                    pic_sanpham.Image = pro_Image.Images[listView1.FocusedItem.Index];
                }
                catch (Exception)
                {

                    pic_sanpham.Image=null;
                }
            }
            else return;
        }

        private void cbo_sapXep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_sapXep.SelectedIndex == -1)
            {
                return;
            }
            else if (cbo_sapXep.SelectedItem.Equals("ID"))
            {
                hienThi(bus.SapXep("ID_Product"));
            }
            else if (cbo_sapXep.SelectedItem.Equals("Tên sản phẩm"))
            {
                hienThi(bus.SapXep("Product_Name"));
            }
            else if (cbo_sapXep.SelectedItem.Equals("Số lượng"))
            {
                hienThi(bus.SapXep("Quantity"));
            }
            else if (cbo_sapXep.SelectedItem.Equals("Giá"))
            {
                hienThi(bus.SapXep("Price"));
            }
            else return;
        }
        public void setNull()
        {
            txt_id.Text = txt_tenSP.Text = txt_gia.Text = txt_soLuong.Text = "";
            dtp_nsx.Value = dtp_hsd.Value = DateTime.Today;
            pic_sanpham.Image = null;
        }
        public void setEditMode()
        {
            if(txt_id.ReadOnly == true)
            {
                txt_id.ReadOnly = txt_tenSP.ReadOnly = txt_soLuong.ReadOnly = txt_gia.ReadOnly = false;
                dtp_nsx.Enabled = dtp_hsd.Enabled = true;
                panel_list.Enabled = false;
            }
            else
            {
                txt_id.ReadOnly = txt_tenSP.ReadOnly = txt_soLuong.ReadOnly = txt_gia.ReadOnly = true;
                dtp_nsx.Enabled = dtp_hsd.Enabled = false ;
                panel_list.Enabled = true;
            }
            
        }
        public void hideButton()
        {
            if (btn_them.Visible == true)
            {
                btn_them.Visible = btn_capNhat.Visible = btn_xoa.Visible = false;
            }
            else
            {
                btn_them.Visible = btn_capNhat.Visible = btn_xoa.Visible = true;
            }
                
        }
        //Them san pham
        public void ThemSanPham()
        {
            sp.ID = txt_id.Text;
            sp.Name = txt_tenSP.Text;
            if(txt_gia.Text == "")
            {
                sp.Price = 0;
            }
            else
            {
                sp.Price = Int32.Parse(txt_gia.Text);
            }
            if (txt_soLuong.Text == "")
            {
                sp.Quantity = 0;
            }
            else
            {
                sp.Quantity = Int32.Parse(txt_soLuong.Text);
            }
            sp.NSX = dtp_nsx.Value;
            sp.HSD = dtp_hsd.Value;
            bus.ThemSanPham(sp);
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            setNull();
            setEditMode();
            hideButton();
            btn_xacNhan.Visible = true;
        }

        private void btn_xacNhan_Click(object sender, EventArgs e)
        {
            setEditMode();
            btn_xacNhan.Visible = false;
            hideButton();
            ThemSanPham();
            setNull();
            hienThi();
        }

        //Cap nhan san pham
        private void btn_capNhat_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            setEditMode();
            txt_id.ReadOnly = true;
            hideButton();
            btn_luu.Visible = true;

        }
        private void btn_luu_Click(object sender, EventArgs e)
        {
            sp.ID = txt_id.Text;
            sp.Name = txt_tenSP.Text;
            sp.NSX = dtp_nsx.Value;
            sp.HSD = dtp_hsd.Value;
            sp.Quantity = Int32.Parse(txt_soLuong.Text);
            sp.Price = Int32.Parse(txt_gia.Text);

            hideButton();
            btn_luu.Visible = false;
            bus.CapNhatSanPham(sp);
            hienThi();
            txt_id.ReadOnly = false;
            setEditMode();
            setNull();
            
        }
        //Xoa san pham
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn xóa sản phẩm này không?", "Xóa sản phẩm", MessageBoxButtons.YesNo);
            if(kq == DialogResult.Yes)
            {
                sp.ID = txt_id.Text;
                bus.XoaSanPham(sp);
                hienThi();
                setNull();
            }
        }

        private void txt_timkiem_TextChanged(object sender, EventArgs e)
        {
            hienThi(bus.TimKiem(txt_timkiem.Text));
        }
    }
}
