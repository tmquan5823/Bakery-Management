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
    public partial class FormTaoTaiKhoan : Form
    {
        private UserAccount acc = new UserAccount();
        private UCQuanLyNhanVien.CreateAccount creAcc;
        public FormTaoTaiKhoan(UCQuanLyNhanVien.CreateAccount uc)
        {
            InitializeComponent();
            this.creAcc = uc;
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            if(txt_tenDN.Text == "" || txt_MK.Text == "" || txt_xacnhanMK.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            acc.Account = txt_tenDN.Text;
            acc.PassWord = txt_MK.Text; 
            if(UserAccountBUS.instance.CheckInfo(acc) == "")
            {
                this.creAcc(acc);
                this.Dispose();
            }
            else
            {
                MessageBox.Show(UserAccountBUS.instance.CheckInfo(acc));
            }
        }
    }
}
