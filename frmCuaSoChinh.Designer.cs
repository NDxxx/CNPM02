namespace QuanLyBanSach
{
    partial class frmCuaSoChinh
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCuaSoChinh));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.heToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NguoiDungMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DangXuatMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThoatMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nghiệpVụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemThongTinSach = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemQuaySach = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemChiTietHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSoLuongTon = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.heToolStripMenuItem,
            this.nghiệpVụToolStripMenuItem,
            this.báoCáoToolStripMenuItem,
            this.trợGiúpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(798, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(798, 529);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // heToolStripMenuItem
            // 
            this.heToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NguoiDungMenuItem,
            this.DangXuatMenuItem,
            this.ThoatMenuItem});
            this.heToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.heToolStripMenuItem.Image = global::QuanLyBanSach.Properties.Resources.settings_16;
            this.heToolStripMenuItem.Name = "heToolStripMenuItem";
            this.heToolStripMenuItem.Size = new System.Drawing.Size(102, 25);
            this.heToolStripMenuItem.Text = "Hệ thống";
            // 
            // NguoiDungMenuItem
            // 
            this.NguoiDungMenuItem.Image = global::QuanLyBanSach.Properties.Resources.user;
            this.NguoiDungMenuItem.Name = "NguoiDungMenuItem";
            this.NguoiDungMenuItem.Size = new System.Drawing.Size(166, 26);
            this.NguoiDungMenuItem.Text = "Người Dùng";
            this.NguoiDungMenuItem.Click += new System.EventHandler(this.NguoiDungMenuItem_Click);
            // 
            // DangXuatMenuItem
            // 
            this.DangXuatMenuItem.Image = global::QuanLyBanSach.Properties.Resources.logout;
            this.DangXuatMenuItem.Name = "DangXuatMenuItem";
            this.DangXuatMenuItem.Size = new System.Drawing.Size(166, 26);
            this.DangXuatMenuItem.Text = "Đăng Xuất";
            this.DangXuatMenuItem.Click += new System.EventHandler(this.DangXuatMenuItem_Click);
            // 
            // ThoatMenuItem
            // 
            this.ThoatMenuItem.Image = global::QuanLyBanSach.Properties.Resources.cancel3;
            this.ThoatMenuItem.Name = "ThoatMenuItem";
            this.ThoatMenuItem.Size = new System.Drawing.Size(166, 26);
            this.ThoatMenuItem.Text = "Thoát";
            this.ThoatMenuItem.Click += new System.EventHandler(this.ThoatMenuItem_Click);
            // 
            // nghiệpVụToolStripMenuItem
            // 
            this.nghiệpVụToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemThongTinSach,
            this.MenuItemQuaySach,
            this.MenuItemHoaDon});
            this.nghiệpVụToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.nghiệpVụToolStripMenuItem.Image = global::QuanLyBanSach.Properties.Resources.graphhs;
            this.nghiệpVụToolStripMenuItem.Name = "nghiệpVụToolStripMenuItem";
            this.nghiệpVụToolStripMenuItem.Size = new System.Drawing.Size(110, 25);
            this.nghiệpVụToolStripMenuItem.Text = "Nghiệp vụ";
            // 
            // MenuItemThongTinSach
            // 
            this.MenuItemThongTinSach.BackColor = System.Drawing.Color.GhostWhite;
            this.MenuItemThongTinSach.Image = global::QuanLyBanSach.Properties.Resources.top_work_out2;
            this.MenuItemThongTinSach.Name = "MenuItemThongTinSach";
            this.MenuItemThongTinSach.Size = new System.Drawing.Size(181, 26);
            this.MenuItemThongTinSach.Text = "Thông tin sách";
            this.MenuItemThongTinSach.Click += new System.EventHandler(this.thôngTinSáchToolStripMenuItem_Click);
            // 
            // MenuItemQuaySach
            // 
            this.MenuItemQuaySach.Image = global::QuanLyBanSach.Properties.Resources.library_icon;
            this.MenuItemQuaySach.Name = "MenuItemQuaySach";
            this.MenuItemQuaySach.Size = new System.Drawing.Size(181, 26);
            this.MenuItemQuaySach.Text = "Quầy Sách";
            this.MenuItemQuaySach.Click += new System.EventHandler(this.quầySáchToolStripMenuItem_Click);
            // 
            // MenuItemHoaDon
            // 
            this.MenuItemHoaDon.Image = global::QuanLyBanSach.Properties.Resources.EditTableHS;
            this.MenuItemHoaDon.Name = "MenuItemHoaDon";
            this.MenuItemHoaDon.Size = new System.Drawing.Size(181, 26);
            this.MenuItemHoaDon.Text = "Hóa Đơn";
            this.MenuItemHoaDon.Click += new System.EventHandler(this.MenuItemHoaDon_Click);
            // 
            // báoCáoToolStripMenuItem
            // 
            this.báoCáoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemChiTietHoaDon,
            this.MenuItemSoLuongTon});
            this.báoCáoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.báoCáoToolStripMenuItem.Image = global::QuanLyBanSach.Properties.Resources.blockdevice32x32;
            this.báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            this.báoCáoToolStripMenuItem.Size = new System.Drawing.Size(95, 25);
            this.báoCáoToolStripMenuItem.Text = "Báo Cáo";
            // 
            // MenuItemChiTietHoaDon
            // 
            this.MenuItemChiTietHoaDon.Image = global::QuanLyBanSach.Properties.Resources.top_work_calendar;
            this.MenuItemChiTietHoaDon.Name = "MenuItemChiTietHoaDon";
            this.MenuItemChiTietHoaDon.Size = new System.Drawing.Size(198, 26);
            this.MenuItemChiTietHoaDon.Text = "Chi Tiết Hóa Đơn";
            this.MenuItemChiTietHoaDon.Click += new System.EventHandler(this.MenuItemChiTietHoaDon_Click);
            // 
            // MenuItemSoLuongTon
            // 
            this.MenuItemSoLuongTon.Image = global::QuanLyBanSach.Properties.Resources.calendar;
            this.MenuItemSoLuongTon.Name = "MenuItemSoLuongTon";
            this.MenuItemSoLuongTon.Size = new System.Drawing.Size(198, 26);
            this.MenuItemSoLuongTon.Text = "Số Lượng Tồn";
            this.MenuItemSoLuongTon.Click += new System.EventHandler(this.MenuItemSoLuongTon_Click);
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.trợGiúpToolStripMenuItem.Image = global::QuanLyBanSach.Properties.Resources.Help_16x16;
            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(99, 25);
            this.trợGiúpToolStripMenuItem.Text = "Trợ Giúp";
            // 
            // frmCuaSoChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 558);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmCuaSoChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống bán Sách";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem heToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nghiệpVụToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemThongTinSach;
        private System.Windows.Forms.ToolStripMenuItem MenuItemQuaySach;
        private System.Windows.Forms.ToolStripMenuItem MenuItemHoaDon;
        private System.Windows.Forms.ToolStripMenuItem báoCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem NguoiDungMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DangXuatMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThoatMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemChiTietHoaDon;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSoLuongTon;
    }
}