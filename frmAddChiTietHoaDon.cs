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
    public partial class frmAddChiTietHoaDon : Form
    {
        public frmAddChiTietHoaDon()
        {
            InitializeComponent();
        }
        private bool _isCTHoaDon;

        public bool isCTHoaDon
        {
            get { return _isCTHoaDon; }
        }
        private String _isMaSach;
        public string IsMaSach
        {
            get { return _isMaSach; }
            set { _isMaSach = value; }
        }

        private void DSMaHoaDon()
        {
            AllBusiness maHD = new AllBusiness();
            DataTable dt = maHD.LayTheoMaHoaDon();


            //hiển thị lên combobox
            cboMaHD.ValueMember = "MaHD";
            cboMaHD.DisplayMember = "MaHD";
            cboMaHD.DataSource = dt;
        }

        private void HienThiThongTinSach()
        {
            DataTable dt = DataProvider.SachBusi.LaySachTheoMa(_isMaSach);
            if (!String.IsNullOrEmpty(_isMaSach))
            {
                txtMaSach.Text = _isMaSach;
                txtGiaCa.Text = Convert.ToString(dt.Rows[0]["Gia"]);
                txtSoLuong.Text = Convert.ToString(dt.Rows[0]["SLuong"]);
            }
        }

        private void frmAddChiTietHoaDon_Load(object sender, EventArgs e)
        {
            //hiển thi dánh sách hóa đơn
            DSMaHoaDon();

            //load lên thông tin sách
            HienThiThongTinSach();

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            bool check = Common.KiemTraBatLoi(txtMaSach);

            if (!check)
            {
                return;
            }

            CTHoaDon hd = new CTHoaDon();
            hd.MaCthd = txtMaCTHD.Text;
            hd.MaHd = cboMaHD.SelectedValue.ToString();
            hd.MaS = txtMaSach.Text;
            hd.SoLuong = Convert.ToInt32(txtSoLuong.Text);
            hd.Tien = Convert.ToDouble(txtGiaCa.Text);
            if (!String.IsNullOrEmpty(_isMaSach))
            {
                DataProvider.ChiTietHoaDonBusiness.ThemMoiCTHoaDon(hd);
                DataProvider.SachBusi.soLuongTonSauMua(hd.SoLuong, _isMaSach);
                _isCTHoaDon = true;
            }
            this.Close();


        }
    }
}
