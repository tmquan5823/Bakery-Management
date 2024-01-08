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
    public partial class FormLogin : Form
    {
        UserAccount acc = new UserAccount();
        UserAccountBUS ucBUS = new UserAccountBUS();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
        private Boolean openNewForm()
        {
            if (txt_username.Text.Trim() == "" || txt_password.Text.Trim() == "")
            {
                return false;
            }
            else
            {
                acc.Account = txt_username.Text;
                acc.PassWord = txt_password.Text;
                if (ucBUS.CheckLogin(acc))
                {
                    if (acc.Role == "Staff")
                    {
                        FormNhanVien frm = new FormNhanVien(acc);
                        frm.ShowDialog();
                    }
                    if (acc.Role == "Admin")
                    {
                        FormQuanLy frm = new FormQuanLy(acc);
                        frm.ShowDialog();
                    }
                    return true;
                } 
                else return false;
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (openNewForm() == true) { this.Dispose(); }
            else MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ!");
        }
    }
}
