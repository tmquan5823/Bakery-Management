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
    public partial class FormQuanLy : Form
    {
        UserAccount uc = new UserAccount();
        public FormQuanLy()
        {
            InitializeComponent();
        }

        public FormQuanLy(UserAccount acc)
        {
            uc = acc;
            InitializeComponent();
        }

        private void btn_user_Click(object sender, EventArgs e)
        {
            if(btn_DangXuat.Visible == false)
            {
                btn_DangXuat.Visible = true;
            }
            else
            {
                btn_DangXuat.Visible = false;
            }
        }
        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to logout?", "Logout message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
                FormLogin frm = new FormLogin();
                frm.ShowDialog();
            }
        }
        private void addUserControl(UserControl uc)
        {
            if (panel_main.Controls.Count > 0)
            {
                panel_main.Controls.Clear();
            }
            panel_main.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }
        private void btn_QuanLyNV_Click(object sender, EventArgs e)
        {
            UCQuanLyNhanVien uc = new UCQuanLyNhanVien();
            addUserControl(uc);
            lbl_form.Text = "Quản lý nhân viên";
        }

        private void btn_QuanLyDoanhThu_Click(object sender, EventArgs e)
        {
            UCQuanLyDoanhThu uc = new UCQuanLyDoanhThu();
            addUserControl(uc);
            lbl_form.Text = "Quản lý doanh thu";
        }

        private void btn_QuanLySP_Click(object sender, EventArgs e)
        {
            UCQuanLySanPham uc = new UCQuanLySanPham();
            addUserControl(uc);
            lbl_form.Text = "Quản lý sản phẩm";
        }

        private void btn_QuanLyKhoHang_Click(object sender, EventArgs e)
        {
            UCQuanLyKhoHang uc = new UCQuanLyKhoHang();
            addUserControl(uc);
            lbl_form.Text = "Quản lý kho hàng";
        }

        private void btn_QuanLyHoaDon_Click(object sender, EventArgs e)
        {
            UCQuanLyHoaDon uc = new UCQuanLyHoaDon();
            addUserControl(uc);
            lbl_form.Text = "Quản lý hóa đơn";
        }

        private void FormQuanLy_Load(object sender, EventArgs e)
        {

        }
    }
}
