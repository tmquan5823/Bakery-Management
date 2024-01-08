using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormNhanVien : Form
    {
        UserAccount acc = new UserAccount();
        public FormNhanVien()
        {
            InitializeComponent();
        }

        public FormNhanVien(UserAccount uc)
        {
            acc = uc;
            InitializeComponent();
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

        private void btn_LapHoaDon_Click(object sender, EventArgs e)
        {
            UCLapHoaDon uc = new UCLapHoaDon(acc);
            addUserControl(uc);
            lbl_form.Text = "Lập hóa đơn";
        }

        private void btn_user_Click(object sender, EventArgs e)
        {
            if(btn_DangXuat.Visible == true) btn_DangXuat.Visible = false;
            else btn_DangXuat.Visible = true;
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
                this.Dispose();
                FormLogin frm = new FormLogin();
                frm.ShowDialog();
        }

        private void btn_QuanLyKhoHang_Click(object sender, EventArgs e)
        {
            UCQuanLyKhoHang uc = new UCQuanLyKhoHang();
            addUserControl(uc);
            lbl_form.Text = "Quản lý kho hàng";
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {

        }
    }
}
