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
using System.Runtime.CompilerServices;

namespace GUI
{
    public partial class UCLapHoaDon : UserControl
    {
        SanPhamBUS spBUS = new SanPhamBUS();
        BillBus bBUS = new BillBus();   
        DetailBillBUS dbBUS = new DetailBillBUS();  
        StaffBUS sBUS = new StaffBUS();
        List<DetailBill> bill = new List<DetailBill>();
        UserAccount uc = new UserAccount();
        Staff staff = new Staff();

        public UCLapHoaDon(UserAccount acc)
        {
            uc = acc;
            InitializeComponent();
        }

        private void UCLapHoaDon_Load(object sender, EventArgs e)
        {
            cbb_sanpham.DataSource = spBUS.dsSanPham();
            cbb_sanpham.DisplayMember = "Name";
            cbb_sanpham.ValueMember = "ID";
            staff = sBUS.GetStaffByUserID(uc.ID_User);
            txtMaNhanVien.Text = staff.ID_Staff;
            txtTenNV.Text = staff.Staff_Name;
            txt_TenKhachHang.Text = "";
            txtSoLuong.Text = "";
            txt_SDT.Text = "";
            {
                string tmp = dtp_tgNgayBan.Value.ToString("dd/MM/yy");
                string[] tmp1 = tmp.Split('/');
                string dayID = tmp1[0] + tmp1[1] + tmp1[2];
                string numID = bBUS.GetCountBillByID(dayID).ToString().PadLeft(3, '0');
                txtMaHoaDon.Text = dayID + numID;
            }
            HienThiDSBill();
        }

        private void cbb_sanpham_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb_sanpham.ValueMember = "ID";
            SanPham sp = spBUS.TimKiemSanPham(cbb_sanpham.SelectedValue.ToString());
            txt_maSP.Text = cbb_sanpham.SelectedValue.ToString();
            txt_giaSP.Text = sp.Price.ToString();
            {
                string[] str = sp.NSX.ToString("yyyy/MM/dd").Split('/');
                dtp_NSX.Value = new DateTime(Int32.Parse(str[0]), Int32.Parse(str[1]), Int32.Parse(str[2]));
            }
            {
                string[] str = sp.HSD.ToString("yyyy/MM/dd").Split('/');
                dtp_HSD.Value = new DateTime(Int32.Parse(str[0]), Int32.Parse(str[1]), Int32.Parse(str[2]));
            }
            txtSoLuong.Text = "";
            txt_conLai.Text = sp.Quantity.ToString();
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            int amount = 0;
            try
            {
                amount = Int32.Parse(txtSoLuong.Text);
            }
            catch (Exception)
            {
                amount = 0;
            }
            if (amount > 0) { 
                txt_conLai.Text = (spBUS.TimKiemSanPham(cbb_sanpham.SelectedValue.ToString()).Quantity - amount).ToString();
                txtThanhTien.Text = (amount * Int32.Parse(txt_giaSP.Text)).ToString();
            }
            if (txtSoLuong.Text == "")
            {
                txt_conLai.Text = spBUS.TimKiemSanPham(cbb_sanpham.SelectedValue.ToString()).Quantity.ToString();
                txtThanhTien.Text = "";
            }
        }

        private void btnThemDetailBill_Click(object sender, EventArgs e)
        {
            DetailBill db = new DetailBill();
            db.ID_Product = txt_maSP.Text;
            db.NSX = dtp_NSX.Value;
            try
            {
                db.Quantity = Int32.Parse(txtSoLuong.Text);
            }
            catch (Exception)
            {

                db.Quantity = 0;
            }
            if(spBUS.TimKiemSanPham(db.ID_Product).Quantity < db.Quantity)
            {
                MessageBox.Show("Sản phẩm trong kho không đủ!");
                txtSoLuong.Text = "";
                return;
            }
            if (checkDetailBill(db))
            {
                bill.Add(db);
            }
            HienThiDSBill();
        }

        public void HienThiDSBill()
        {
            listView1.Items.Clear();
            double total = 0;
            foreach(var item in bill)
            {
                SanPham sp = spBUS.TimKiemSanPham(item.ID_Product);
                ListViewItem lvi = new ListViewItem(sp.ID);
                lvi.SubItems.Add(sp.Name);
                lvi.SubItems.Add(sp.NSX.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(sp.HSD.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(sp.Price.ToString());
                lvi.SubItems.Add(item.Quantity.ToString());
                lvi.SubItems.Add((sp.Price * item.Quantity).ToString());
                listView1.Items.Add(lvi);
                total += sp.Price * item.Quantity;
            }
            lbl_tongtien.Text = total.ToString();   
        }

        public Boolean checkDetailBill(DetailBill db)
        {
            if (db.Quantity <= 0) return false;
            foreach(var item in bill)
            {
                if(db.ID_Product == item.ID_Product)
                {
                    if(db.Quantity == 0)
                    {
                        bill.Remove(item);
                    }
                    item.Quantity = db.Quantity;
                    return false;
                }
            }
            return true;
        }

        private void bntXoaDetailBill_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            ListViewItem lvi = listView1.SelectedItems[0];
            bill.RemoveAt(listView1.Items.IndexOf(listView1.SelectedItems[0]));
            HienThiDSBill();
            bntXoaDetailBill.Visible = false;   
        }

        private void bntLuuHoaDon_Click(object sender, EventArgs e)
        {
            if (bill.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm sản phẩm");
                return;
            }
            Bill b = new Bill();
            b.ID_Bill = txtMaHoaDon.Text;
            b.CustomerName = txt_TenKhachHang.Text;
            b.PhoneNumber = txt_SDT.Text;
            b.Transaction = DateTime.Now;
            b.TotalBill = Int32.Parse(lbl_tongtien.Text);
            b.ID_Staff = txtMaNhanVien.Text;
            bBUS.AddBill(b);
            foreach(var item in bill)
            {
                item.ID_DetailBill = b.ID_Bill;
                dbBUS.AddDetailBill(item);
                spBUS.CapNhatSoLuongSP(item.ID_Product, item.Quantity);
            }
            bill.Clear();
            txtSoLuong.Text = "";
            MessageBox.Show("Xác nhận hóa đơn thành công!");
            this.UCLapHoaDon_Load(sender, e);
        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {

        }
        
        private void InHoaDon()
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string tentiem = "Tiệm bánh mỳ";
            string diachi = "54 Nguyễn Lương Bằng, Hòa Khánh Bắc, Liên Chiểu, Đà Nẵng";
            string phone = "0948628477";

            var width = printDocument1.DefaultPageSettings.PaperSize.Width;

            e.Graphics.DrawString(
                tentiem.ToUpper(),
                new Font("Courier New", 30, FontStyle.Bold),
                Brushes.Black,
                new Point(250, 20));

            e.Graphics.DrawString(
               "Mã hóa đơn: " + txtMaHoaDon.Text.ToUpper(),
               new Font("Courier New", 16, FontStyle.Bold),
               Brushes.Black,
               new Point(250, 80));

                //e.Graphics.DrawString(
                //"Địa chỉ: " + diachi,
                //new Font("Courier New", 14),
               // Brushes.Black,
                //new Point(10, 120)); 

            e.Graphics.DrawString(
                "Thời gian thanh toán: " + DateTime.Now.ToString("dd/MMMM/yyyy"),
                new Font("Courier New", 14, FontStyle.Italic),
                Brushes.Black,
                new Point(10, 120));

            e.Graphics.DrawString(
                "Tên khách hàng: " + txt_TenKhachHang.Text,
                new Font("Courier New", 14, FontStyle.Italic),
                Brushes.Black,
                new Point(10, 150));

            e.Graphics.DrawString(
                "Số điện thoại: " + txt_SDT.Text,
                new Font("Courier New", 14, FontStyle.Italic),
                Brushes.Black,
                new Point(width/2, 150));

            e.Graphics.DrawString(
                "ID nhân viên: " + txtMaNhanVien.Text,
                new Font("Courier New", 14, FontStyle.Italic),
                Brushes.Black,
                new Point(10, 180));

            e.Graphics.DrawString(
               "Tên nhân viên: " + sBUS.GetStaffByID(txtMaNhanVien.Text).Staff_Name,
               new Font("Courier New", 14, FontStyle.Italic),
               Brushes.Black,
               new Point(width/2, 180));

            Pen blackPen = new Pen(Color.Black, 1);
            e.Graphics.DrawLine(blackPen, new Point(10, 210), new Point(width - 10, 210));

            e.Graphics.DrawString("Tên sản phẩm", new Font("Courier New", 14, FontStyle.Bold), Brushes.Black, new Point(20, 220));
            e.Graphics.DrawString("Đơn giá", new Font("Courier New", 14, FontStyle.Bold), Brushes.Black, new Point(300, 220));
            e.Graphics.DrawString("Số lượng", new Font("Courier New", 14, FontStyle.Bold), Brushes.Black, new Point(500, 220));
            e.Graphics.DrawString("Thành tiền", new Font("Courier New", 14, FontStyle.Bold), Brushes.Black, new Point(650, 220));

            e.Graphics.DrawLine(blackPen, new Point(10, 250), new Point(width - 10, 250));

            int i = 260;
            foreach (ListViewItem item in listView1.Items)
            {
                e.Graphics.DrawString(item.SubItems[1].Text, new Font("Courier New", 14, FontStyle.Bold), Brushes.Black, new Point(20, i));
                e.Graphics.DrawString(item.SubItems[4].Text, new Font("Courier New", 14, FontStyle.Bold), Brushes.Black, new Point(300, i));
                e.Graphics.DrawString(item.SubItems[5].Text, new Font("Courier New", 14, FontStyle.Bold), Brushes.Black, new Point(500, i));
                e.Graphics.DrawString(item.SubItems[6].Text, new Font("Courier New", 14, FontStyle.Bold), Brushes.Black, new Point(650, i));
                i += 30;
            }
            e.Graphics.DrawLine(blackPen, new Point(10, i), new Point(width - 10, i));

            e.Graphics.DrawString(
                "Mãi iu <3" ,
                new Font("Courier New", 20, FontStyle.Bold),
                Brushes.Black,
                new Point(350, i + 30));
        }
        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            InHoaDon();
        }

        private void bntHuyHoaDon_Click(object sender, EventArgs e)
        {
            bill.Clear();
            this.UCLapHoaDon_Load(sender, e);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                bntXoaDetailBill.Visible = true;
            }
        }

    }     
}

