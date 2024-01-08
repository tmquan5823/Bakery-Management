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
    public partial class FormDoiMatKhau : Form
    {
        UserAccount acc = new UserAccount();
        public FormDoiMatKhau(UserAccount ua)
        {
            InitializeComponent();
            acc = ua;
        }

        private void FormDoiMatKhau_Load(object sender, EventArgs e)
        {
            txt_tenDN.Text = acc.Account;
        }

        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            if(txt_MK.Text == "" || txt_xacnhanMK.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return; 
            }
            if(txt_MK.Text.Length < 6)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu với tối thiểu 6 ký tự!");
                return;
            }
            if(txt_MK.Text != txt_xacnhanMK.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!");
                return;
            }
            acc.PassWord = txt_MK.Text;
            UserAccountBUS.instance.UpdatePassword(acc);
            MessageBox.Show("Đổi mật khẩu thành công!");
            this.Dispose();
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
