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
    public partial class frmEditCTHoaDon : Form
    {
        public frmEditCTHoaDon()
        {
            InitializeComponent();
        }
        private String _isMaHoaDon;
        public string IsMaHoaDon
        {
            get { return _isMaHoaDon; }
            set { _isMaHoaDon = value; }
        }
        private bool _isCTHoaDon;

        public bool isCTHoaDon
        {
            get { return _isCTHoaDon; }
        }
        private void HienThiThongCTHoaDon()
        {
            DataTable dt = DataProvider.ChiTietHoaDonBusiness.LayCTHoaDonTheoMa(_isMaHoaDon);
            if (!String.IsNullOrEmpty(_isMaHoaDon))
            {
                txtMaCTHD.Text = _isMaHoaDon;
                cboMaHD.Text = dt.Rows[0]["MaHD"].ToString();
                txtMaSach.Text = dt.Rows[0]["MaS"].ToString();
                txtGiaCa.Text = Convert.ToString(dt.Rows[0]["DonGia"]);
                txtSoLuong.Text = Convert.ToString(dt.Rows[0]["SoLuong"]);
            }
        }

        private void frmEditCTHoaDon_Load(object sender, EventArgs e)
        {
            HienThiThongCTHoaDon();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            CTHoaDon hd = new CTHoaDon();
            //bool check = Common.KiemTraBatLoi(txtMaSach);

            //if (!check)
            //{
            //    return;
            //}

            hd.MaCthd = txtMaCTHD.Text;
            hd.MaHd = cboMaHD.SelectedValue.ToString();
            hd.MaS = txtMaSach.Text;
            hd.SoLuong = Convert.ToInt32(txtSoLuong.Text);
            hd.Tien = Convert.ToDouble(txtGiaCa.Text);
            if (!String.IsNullOrEmpty(_isMaHoaDon))
            {
                DataProvider.ChiTietHoaDonBusiness.SuaChiTietHoaDon(hd);
                DataProvider.SachBusi.soLuongTonSauMua(hd.SoLuong, _isMaHoaDon);
                _isCTHoaDon = true;
            }
            this.Close();
        }
    }
}
