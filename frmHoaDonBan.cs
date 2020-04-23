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
    public partial class frmHoaDonBan : Form
    {
        public frmHoaDonBan()
        {
            InitializeComponent();
        }
        private bool _isHoaDon;

        public bool isHoaDon
        {
            get { return _isHoaDon; }
        }
        private String _isSach;
        public string IsSach
        {
            get { return _isSach; }
            set { _isSach = value; }
        }

        private void DSMaKH()
        {
            AllBusiness maKh = new AllBusiness();
            DataTable dt = maKh.LayTheoKh();


            //hiển thị lên combobox
            cboMaKH.ValueMember = "MaKH";
            cboMaKH.DisplayMember = "TenKH";
            cboMaKH.DataSource = dt;
        }

        //hiển thị thông tin hoa đơn
        private void DanhSachHoaDon()
        {
            gridHoaDon.DataSource = null;
            DataTable dtHoaDon = DataProvider.HoaDonBusiness.LayDSHoaDon();
            gridHoaDon.DataSource = dtHoaDon;
        }
        private void btnThemHd_Click(object sender, EventArgs e)
        {
            bool check = Common.KiemTraBatLoi(txtMaHD);

            if (!check)
            {
                return;
            }

            HoaDon hd = new HoaDon();
            hd.MaHd = txtMaHD.Text;
            hd.TenHd = txtTenHD.Text;
            hd.MaKh = cboMaKH.SelectedValue.ToString();
            hd.NgayBan = Convert.ToString(dtpNgayBan.Value.ToString("yyyy/MM/dd"));
            hd.TongTienHd = 0;
            hd.TongTienHd = Convert.ToDouble(txtTongTienHD.Text);
           
            if (String.IsNullOrEmpty(_isSach))
            {
                DataProvider.HoaDonBusiness.ThemMoiHoaDon(hd);
                //  DataProvider.SachBusi.soLuongTonSauMua(hd.SoLuong, _isSach);
                _isHoaDon = true;
            }
            //load lại danh sách
            DanhSachHoaDon();
        }

        private void TongTienHDBanDauBang0()
        {
            HoaDon hd = new HoaDon();

            hd.TongTienHd = 0;
            txtTongTienHD.Text = Convert.ToString(hd.TongTienHd);
        }
        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            //hiển thị danh sách khách hàng lên form load
            DSMaKH();

            //hiển thị danh sách hóa đơn
            DanhSachHoaDon();

            //hiển thị ô textTongTienHD =0
            TongTienHDBanDauBang0();
        }

        private void btnXoaHd_Click(object sender, EventArgs e)
        {
            String maXoa = gridHoaDon.CurrentRow.Cells[0].Value.ToString();
            DialogResult dlg = MessageBox.Show("Bạn có chắc chắn xóa??", "Xóa", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (dlg == DialogResult.Yes)
            {
                // DataProvider.SachBusi.XoaSachTrongKhanhHang(maXoa);
                DataProvider.HoaDonBusiness.XoaHoaDon(maXoa);
            }

            //cập nhật lại gridview
            DanhSachHoaDon();
        }

        private void btnTimKiemHd_Click_1(object sender, EventArgs e)
        {
            String strma = txtHoaDon.Text;
            String strNgayFrom = Convert.ToString(dtpNgayFrom.Value.ToString("yyyy/MM/dd"));
            String strNgayTo = Convert.ToString(dtpNgayTo.Value.ToString("yyyy/MM/dd"));

            if (rbtnTimMaHD.Checked)
            {
                gridHoaDon.DataSource = null;
                DataTable dt = DataProvider.HoaDonBusiness.TimKiemMaHd(strma);
                gridHoaDon.DataSource = dt;
            }
            else if (rbtnTheoNgay.Checked)
            {
                gridHoaDon.DataSource = null;
                DataTable dt = DataProvider.HoaDonBusiness.TimKiemTuNgayNgayDenNgayKia(strNgayFrom,strNgayTo);
                gridHoaDon.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Mời bạn chọn kiểu tìm kiếm !!");
                return;
            }
        }

        private void btnLoadHd_Click_1(object sender, EventArgs e)
        {
            DanhSachHoaDon();
        }

        private void btnThoatHd_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
