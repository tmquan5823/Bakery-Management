namespace GUI
{
    partial class UCQuanLySanPham
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCQuanLySanPham));
            this.lbl_id = new System.Windows.Forms.Label();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_tenSP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_nsx = new System.Windows.Forms.DateTimePicker();
            this.dtp_hsd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_soLuong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_gia = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_luu = new System.Windows.Forms.Button();
            this.btn_xacNhan = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_capNhat = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pic_sanpham = new System.Windows.Forms.PictureBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbo_sapXep = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_timkiem = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.panel_list = new System.Windows.Forms.Panel();
            this.pro_Image = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_sanpham)).BeginInit();
            this.panel_list.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_id.Location = new System.Drawing.Point(22, 39);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(122, 25);
            this.lbl_id.TabIndex = 0;
            this.lbl_id.Text = "ID sản phẩm";
            // 
            // txt_id
            // 
            this.txt_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_id.Location = new System.Drawing.Point(177, 36);
            this.txt_id.Name = "txt_id";
            this.txt_id.ReadOnly = true;
            this.txt_id.Size = new System.Drawing.Size(281, 30);
            this.txt_id.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên sản phẩm";
            // 
            // txt_tenSP
            // 
            this.txt_tenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tenSP.Location = new System.Drawing.Point(177, 103);
            this.txt_tenSP.Name = "txt_tenSP";
            this.txt_tenSP.ReadOnly = true;
            this.txt_tenSP.Size = new System.Drawing.Size(281, 30);
            this.txt_tenSP.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(516, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "NSX";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(516, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "HSD";
            // 
            // dtp_nsx
            // 
            this.dtp_nsx.Enabled = false;
            this.dtp_nsx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_nsx.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_nsx.Location = new System.Drawing.Point(590, 34);
            this.dtp_nsx.Name = "dtp_nsx";
            this.dtp_nsx.Size = new System.Drawing.Size(224, 30);
            this.dtp_nsx.TabIndex = 6;
            // 
            // dtp_hsd
            // 
            this.dtp_hsd.Enabled = false;
            this.dtp_hsd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_hsd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_hsd.Location = new System.Drawing.Point(591, 106);
            this.dtp_hsd.Name = "dtp_hsd";
            this.dtp_hsd.Size = new System.Drawing.Size(224, 30);
            this.dtp_hsd.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Số lượng";
            // 
            // txt_soLuong
            // 
            this.txt_soLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_soLuong.Location = new System.Drawing.Point(178, 170);
            this.txt_soLuong.Name = "txt_soLuong";
            this.txt_soLuong.ReadOnly = true;
            this.txt_soLuong.Size = new System.Drawing.Size(281, 30);
            this.txt_soLuong.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(516, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Giá";
            // 
            // txt_gia
            // 
            this.txt_gia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_gia.Location = new System.Drawing.Point(591, 168);
            this.txt_gia.Name = "txt_gia";
            this.txt_gia.ReadOnly = true;
            this.txt_gia.Size = new System.Drawing.Size(224, 30);
            this.txt_gia.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_luu);
            this.groupBox1.Controls.Add(this.btn_xacNhan);
            this.groupBox1.Controls.Add(this.btn_xoa);
            this.groupBox1.Controls.Add(this.btn_capNhat);
            this.groupBox1.Controls.Add(this.btn_them);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.pic_sanpham);
            this.groupBox1.Controls.Add(this.txt_gia);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_soLuong);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtp_hsd);
            this.groupBox1.Controls.Add(this.dtp_nsx);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_tenSP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_id);
            this.groupBox1.Controls.Add(this.lbl_id);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(30, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1132, 308);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sản phẩm";
            // 
            // btn_luu
            // 
            this.btn_luu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_luu.Location = new System.Drawing.Point(329, 227);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(166, 59);
            this.btn_luu.TabIndex = 17;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.Visible = false;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // btn_xacNhan
            // 
            this.btn_xacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xacNhan.Location = new System.Drawing.Point(48, 226);
            this.btn_xacNhan.Name = "btn_xacNhan";
            this.btn_xacNhan.Size = new System.Drawing.Size(166, 59);
            this.btn_xacNhan.TabIndex = 16;
            this.btn_xacNhan.Text = "Xác nhận";
            this.btn_xacNhan.UseVisualStyleBackColor = true;
            this.btn_xacNhan.Visible = false;
            this.btn_xacNhan.Click += new System.EventHandler(this.btn_xacNhan_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoa.Location = new System.Drawing.Point(610, 226);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(166, 59);
            this.btn_xoa.TabIndex = 15;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_capNhat
            // 
            this.btn_capNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_capNhat.Location = new System.Drawing.Point(329, 227);
            this.btn_capNhat.Name = "btn_capNhat";
            this.btn_capNhat.Size = new System.Drawing.Size(166, 59);
            this.btn_capNhat.TabIndex = 15;
            this.btn_capNhat.Text = "Cập nhật ";
            this.btn_capNhat.UseVisualStyleBackColor = true;
            this.btn_capNhat.Click += new System.EventHandler(this.btn_capNhat_Click);
            // 
            // btn_them
            // 
            this.btn_them.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_them.Location = new System.Drawing.Point(48, 227);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(166, 59);
            this.btn_them.TabIndex = 14;
            this.btn_them.Text = "Thêm ";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(700, 274);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(8, 8);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // pic_sanpham
            // 
            this.pic_sanpham.Image = global::GUI.Properties.Resources.signage;
            this.pic_sanpham.Location = new System.Drawing.Point(850, 18);
            this.pic_sanpham.Name = "pic_sanpham";
            this.pic_sanpham.Size = new System.Drawing.Size(250, 268);
            this.pic_sanpham.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_sanpham.TabIndex = 12;
            this.pic_sanpham.TabStop = false;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(14, 47);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1112, 401);
            this.listView1.TabIndex = 45;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 108;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Tên sản phẩm";
            this.columnHeader8.Width = 276;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "NSX";
            this.columnHeader9.Width = 188;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "HSD";
            this.columnHeader10.Width = 182;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Số lượng";
            this.columnHeader11.Width = 157;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Giá";
            this.columnHeader12.Width = 193;
            // 
            // cbo_sapXep
            // 
            this.cbo_sapXep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_sapXep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_sapXep.FormattingEnabled = true;
            this.cbo_sapXep.Items.AddRange(new object[] {
            "ID",
            "Tên sản phẩm",
            "Số lượng",
            "Giá"});
            this.cbo_sapXep.Location = new System.Drawing.Point(100, 5);
            this.cbo_sapXep.Name = "cbo_sapXep";
            this.cbo_sapXep.Size = new System.Drawing.Size(223, 33);
            this.cbo_sapXep.TabIndex = 44;
            this.cbo_sapXep.SelectedIndexChanged += new System.EventHandler(this.cbo_sapXep_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 25);
            this.label9.TabIndex = 43;
            this.label9.Text = "Sắp xếp";
            // 
            // txt_timkiem
            // 
            this.txt_timkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_timkiem.Location = new System.Drawing.Point(823, 2);
            this.txt_timkiem.Name = "txt_timkiem";
            this.txt_timkiem.Size = new System.Drawing.Size(254, 30);
            this.txt_timkiem.TabIndex = 40;
            this.txt_timkiem.TextChanged += new System.EventHandler(this.txt_timkiem_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(726, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 25);
            this.label8.TabIndex = 41;
            this.label8.Text = "Tìm kiếm";
            // 
            // iconButton1
            // 
            this.iconButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.SearchDollar;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.iconButton1.Location = new System.Drawing.Point(1083, 2);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(34, 30);
            this.iconButton1.TabIndex = 42;
            this.iconButton1.UseVisualStyleBackColor = true;
            // 
            // panel_list
            // 
            this.panel_list.Controls.Add(this.listView1);
            this.panel_list.Controls.Add(this.cbo_sapXep);
            this.panel_list.Controls.Add(this.label9);
            this.panel_list.Controls.Add(this.iconButton1);
            this.panel_list.Controls.Add(this.txt_timkiem);
            this.panel_list.Controls.Add(this.label8);
            this.panel_list.Location = new System.Drawing.Point(22, 356);
            this.panel_list.Name = "panel_list";
            this.panel_list.Size = new System.Drawing.Size(1139, 444);
            this.panel_list.TabIndex = 46;
            // 
            // pro_Image
            // 
            this.pro_Image.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("pro_Image.ImageStream")));
            this.pro_Image.TransparentColor = System.Drawing.Color.Transparent;
            this.pro_Image.Images.SetKeyName(0, "bánh-mì.jpg");
            this.pro_Image.Images.SetKeyName(1, "27-620x620-4.jpg");
            this.pro_Image.Images.SetKeyName(2, "photo.jpg");
            this.pro_Image.Images.SetKeyName(3, "10_1.jpg");
            // 
            // UCQuanLySanPham
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel_list);
            this.Controls.Add(this.groupBox1);
            this.Name = "UCQuanLySanPham";
            this.Size = new System.Drawing.Size(1182, 803);
            this.Load += new System.EventHandler(this.UCQuanLySanPham_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_sanpham)).EndInit();
            this.panel_list.ResumeLayout(false);
            this.panel_list.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_tenSP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_nsx;
        private System.Windows.Forms.DateTimePicker dtp_hsd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_soLuong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_gia;
        private System.Windows.Forms.PictureBox pic_sanpham;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_capNhat;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ComboBox cbo_sapXep;
        private System.Windows.Forms.Label label9;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.TextBox txt_timkiem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_xacNhan;
        private System.Windows.Forms.Panel panel_list;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.ImageList pro_Image;
    }
}
