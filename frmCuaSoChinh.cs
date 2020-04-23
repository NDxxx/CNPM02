using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanSach
{
    public partial class frmCuaSoChinh : Form
    {
        public frmCuaSoChinh()
        {
            InitializeComponent();
        }

        private void thôngTinSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHienThiSach frmHienThi = new frmHienThiSach();
            this.Visible = false;
            frmHienThi.ShowDialog();
            this.Visible = true;
        }

        private void quầySáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuaySach frmQuay = new frmQuaySach();
            this.Visible = false;
            frmQuay.ShowDialog();
            this.Visible = true;
        }

        private void DangXuatMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap frmDangNhap = new frmDangNhap();
            this.Visible = false;
            frmDangNhap.ShowDialog();
            
        }

        private void NguoiDungMenuItem_Click(object sender, EventArgs e)
        {
            //frmDangNhap frmDang = new frmDangNhap();

            //String strTen = frmDang.txtId.Text;
            //String str = Convert.ToString(DataProvider.SachBusi.LayTenNguoiDung(strTen));
            //MessageBox.Show(String.Format("Tài khoản " + str + " đang được sử dụng!"));
        }

        private void MenuItemHoaDon_Click(object sender, EventArgs e)
        {
            frmHoaDonBan frmHD = new frmHoaDonBan();
            this.Visible = false;
            frmHD.ShowDialog();
            this.Visible = true;
        }

        private void MenuItemChiTietHoaDon_Click(object sender, EventArgs e)
        {
            frmHienThiBaoCao frm = new frmHienThiBaoCao();
            frm.StrTenBaoCao = "rptChiTietHoaDon.rdlc";
            frm.ShowDialog();
        }

        private void MenuItemSoLuongTon_Click(object sender, EventArgs e)
        {
            frmHienThiBaoCao frm = new frmHienThiBaoCao();
            frm.StrTenBaoCao = "rptSoLuongSachTon.rdlc";
            frm.ShowDialog();
        }

        private void ThoatMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
