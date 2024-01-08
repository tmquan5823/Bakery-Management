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
using System.Diagnostics.Eventing.Reader;
using System.Runtime.Remoting.Messaging;
using System.IO;
using System.Drawing.Imaging;

namespace GUI
{
    public partial class UCQuanLyNhanVien : UserControl
    {
        StaffBUS sBUS = new StaffBUS();
        Staff s = new Staff();
        UserAccount acc = null;
        UserAccount staffAcc = new UserAccount();

        public delegate void CreateAccount(UserAccount uc);

        public UCQuanLyNhanVien()
        {
            InitializeComponent();
        }
        public void setNull()
        {
            txt_ID.Text = txt_name.Text = txt_CCCD.Text = txt_sdt.Text = txt_DiaChi.Text =cbb_shift.Text = txt_salary.Text = "";
            radbtn_Nam.Checked = radbtn_Nu.Checked = false;
            dateTimePicker1.Value = DateTime.Today;
            //pictureBox1.Image = imageList1.Images[0];
        }
        public void EditMode()
        {
            if (txt_name.ReadOnly == true)
            {
                txt_name.ReadOnly = txt_CCCD.ReadOnly = txt_sdt.ReadOnly = txt_DiaChi.ReadOnly = txt_salary.ReadOnly = false;
                btn_upload.Enabled = true;
                cbb_shift.Enabled = true;
                dateTimePicker1.Enabled = true;
                panel_gioitinh.Enabled = true;
                panel1.Enabled = false;
            }
            else
            {
                txt_name.ReadOnly = txt_CCCD.ReadOnly = txt_sdt.ReadOnly = txt_DiaChi.ReadOnly = txt_salary.ReadOnly = true;
                btn_upload.Enabled = false;
                dateTimePicker1.Enabled = false;
                cbb_shift.Enabled = false;
                panel_gioitinh.Enabled = false;
                panel1.Enabled = true;
            }
        }
        public void hideButton()
        {
            if (btn_them.Visible == true)
            {
                btn_them.Visible = btn_sua.Visible = btn_xoa.Visible = false;
            }
            else
            {
                btn_them.Visible = btn_sua.Visible = btn_xoa.Visible = true;
            }
        }
        //HienThi
        public void HienThi()
        {
            listView1.Items.Clear();
            foreach (var item in sBUS.DanhSachNhanVien())
            {
                ListViewItem lvi = new ListViewItem(item.ID_Staff);
                lvi.SubItems.Add(item.Staff_Name);
                lvi.SubItems.Add(item.BirthDay.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(item.Sex);
                lvi.SubItems.Add(item.PhoneNumber);
                lvi.SubItems.Add(item.Shift);
                listView1.Items.Add(lvi);
            }
        }

        public void HienThi(List<Staff> list)
        {
            listView1.Items.Clear();
            foreach (var item in list)
            {
                ListViewItem lvi = new ListViewItem(item.ID_Staff);
                lvi.SubItems.Add(item.Staff_Name);
                lvi.SubItems.Add(item.BirthDay.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(item.Sex);
                lvi.SubItems.Add(item.PhoneNumber);
                lvi.SubItems.Add(item.Shift);
                listView1.Items.Add(lvi);
            }
        }

        //Form load 
        private void UCQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        //listview Event
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            ListViewItem lvi = listView1.SelectedItems[0];
            txt_ID.Text = lvi.SubItems[0].Text;
            Staff nv = sBUS.GetStaffByID(txt_ID.Text);
            txt_name.Text = lvi.SubItems[1].Text;
            dateTimePicker1.Value = nv.BirthDay;
            if (nv.Sex == "Nam") radbtn_Nam.Checked = true;
            if (nv.Sex == "Nữ") radbtn_Nu.Checked = true;
            txt_CCCD.Text = nv.CCCD;
            txt_sdt.Text = nv.PhoneNumber;
            txt_DiaChi.Text = nv.Address;
            cbb_shift.Text = "";
            cbb_shift.SelectedText = nv.Shift;
            txt_salary.Text = nv.Salary.ToString();
            pictureBox1.Image = Image.FromStream(new MemoryStream((nv.urlImage)));
            staffAcc = UserAccountBUS.instance.GetAccountByID(nv.ID_User);
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            setNull();
            EditMode();
            hideButton();
            pictureBox1.Image = imageList1.Images[0];
            txt_ID.Text = "NV1" + (sBUS.GetNumberOfStaff() + 1).ToString().Trim().PadLeft(4, '0');
            {
                btn_huy.Visible = btn_taoTK.Visible = btn_xacnhan.Visible = true;
                btn_xacnhan.Enabled = false;
            }
            


        }
        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            if (!ThemNhanVien()) return;
            EditMode();
            btn_doiMK.Visible = btn_huy.Visible = btn_taoTK.Visible = btn_xacnhan.Visible = false;
            hideButton();
            setNull();
            HienThi();
        }

        private Boolean ThemNhanVien()
        {
            s.ID_Staff = txt_ID.Text;
            s.Staff_Name = txt_name.Text;
            s.BirthDay = dateTimePicker1.Value;
            if (radbtn_Nam.Checked == true)
            {
                s.Sex = "Nam";
            }
            if (radbtn_Nu.Checked == true)
            {
                s.Sex = "Nữ";
            }
            s.CCCD = txt_CCCD.Text;
            s.PhoneNumber = txt_sdt.Text;
            s.Address = txt_DiaChi.Text;
            s.Shift = cbb_shift.Text;
            if (txt_salary.Text != "")
            {
                s.Salary = Int32.Parse(txt_salary.Text);
            }
            else s.Salary = 0;
            {
                MemoryStream ms = new MemoryStream();
                try
                {
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                }
                catch (Exception)
                {

                    imageList1.Images[0].Save(ms, imageList1.Images[0].RawFormat);
                }
                s.urlImage = ms.GetBuffer();
            }
            if (sBUS.CheckTTNhanVien(s))
            {
                UserAccountBUS.instance.AddUserAccount(acc);
                this.s.ID_User = UserAccountBUS.instance.GetLastID();
                sBUS.ThemNhanVien(s);
                MessageBox.Show("Thêm nhân viên thành công!");
                return true;
            }
            MessageBox.Show("Thông tin nhập vào không hợp lệ!");
            return false;
        }

        byte[] ConvertImageToBinary(Image img)
        {
            using(MemoryStream  ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        //sua
        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0) return;
            EditMode();
            hideButton();
            btn_doiMK.Visible = btn_huy.Visible = btn_luu.Visible = true;
        }
        private void btn_luu_Click(object sender, EventArgs e)
        {
            s.ID_Staff = txt_ID.Text;
            s.Staff_Name = txt_name.Text;
            s.BirthDay = dateTimePicker1.Value;
            if (radbtn_Nam.Checked == true)
            {
                s.Sex = "Nam";
            }
            if (radbtn_Nu.Checked == true)
            {
                s.Sex = "Nữ";
            }
            s.CCCD = txt_CCCD.Text;
            s.PhoneNumber = txt_sdt.Text;
            s.Address = txt_DiaChi.Text;
            s.Shift = cbb_shift.Text;
            try
            {
                s.Salary = Int32.Parse(txt_salary.Text);
            }
            catch (Exception)
            {

                s.Salary = 0;
            }
            hideButton();
            btn_huy.Visible = btn_doiMK.Visible = btn_luu.Visible = false;
            sBUS.CapNhatNhanVien(s);
            HienThi();
            EditMode();
            setNull();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                return;
            }
            if (comboBox1.SelectedItem.Equals("ID"))
            {
                HienThi(sBUS.SapXepNhanVien("ID_Staff"));
            }
            if (comboBox1.SelectedItem.Equals("Tên nhân viên"))
            {
                HienThi(sBUS.SapXepNhanVien("Staff_Name"));
            }
            if (comboBox1.SelectedItem.Equals("Ca làm việc"))
            {
                HienThi(sBUS.SapXepNhanVien("Shift"));
            }
        }

        private void txt_timkiem_TextChanged(object sender, EventArgs e)
        {
            HienThi(sBUS.TimKiem(txt_timkiem.Text));
        }

        private void btn_xoa_Click_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            DialogResult kq = MessageBox.Show("Bạn có muốn xóa nhân viên này không?", "Xóa nhân viên", MessageBoxButtons.YesNo);
            if (kq == DialogResult.Yes)
            {
                s.ID_Staff = txt_ID.Text;
                int userID = sBUS.GetStaffByID(s.ID_Staff).ID_User;
                sBUS.XoaNhanVien(s);
                UserAccountBUS.instance.DeleteUserAccount(userID);
                HienThi();
                setNull();
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            this.acc = null;
            hideButton();
            {
                btn_doiMK.Visible = btn_luu.Visible = btn_xacnhan.Visible = btn_huy.Visible = btn_taoTK.Visible = false;
            }
            setNull();
            EditMode();
        }

        private void btn_taoTK_Click(object sender, EventArgs e)
        {
            FormTaoTaiKhoan form = new FormTaoTaiKhoan(SetAccount);
            form.ShowDialog();
            if(this.acc != null)
            {
                btn_xacnhan.Enabled = true;
            }
        }

        private void SetAccount(UserAccount uc)
        {
            this.acc = uc;
            this.acc.Role = "Staff";
        }

        private void btn_doiMK_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để đổi mật khẩu!");
                return;
            }
            FormDoiMatKhau frm = new FormDoiMatKhau(staffAcc);
            frm.ShowDialog();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
            }
        }
    }
}
