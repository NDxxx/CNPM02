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
    public partial class frmAddSach : Form
    {
        public frmAddSach()
        {
            InitializeComponent();
        }

        private bool _isThem;

        public bool IsThem
        {
            get { return _isThem; }
        }
        private bool _isSua;

        public bool IsSua
        {
            get { return _isSua; }
        }

        private String _isMaSua;
        public string IsMaSua
        {
            get { return _isMaSua; }
            set { _isMaSua = value; }
        }

        private void DSMaTheLoai()
        {
            AllBusiness maTL = new AllBusiness();
            DataTable dt = maTL.LayTheoMaTheLoai();


            //hiển thị lên combobox
            cboTheLoai.ValueMember = "MaTL";
            cboTheLoai.DisplayMember = "TenTheLoai";
            cboTheLoai.DataSource = dt;
        }

        private void DSMaTacGia()
        {
            AllBusiness maTg = new AllBusiness();
            DataTable dt = maTg.LayTheoTacGia();

            cboTacGia.ValueMember = "MaTG";
            cboTacGia.DisplayMember = "TenTG";
            cboTacGia.DataSource = dt;
        }

        private void DsMaNxb()
        {
            AllBusiness maNsb = new AllBusiness();
            DataTable dt = maNsb.LayTheoNxb();

            cboNxb.ValueMember = "MaNXB";
            cboNxb.DisplayMember = "TenNXB";
            cboNxb.DataSource = dt;

        }
        private void frmAddSach_Load(object sender, EventArgs e)
        {
            DSMaTheLoai();
            DSMaTacGia();
            DsMaNxb();

            //gọi lại from hiển thị nếu click nút sửa
            HienThiFormSua();
        }

        private void HienThiFormSua()
        {
            //MaS, TenS ,MaTL, SLuong ,NgayNhap,MaTG ,MaNXB ,Gia
            DataTable dt = DataProvider.SachBusi.LaySachTheoMa(IsMaSua);

            if (!String.IsNullOrEmpty(IsMaSua))
            {
                txtMaSach.Enabled = false;
                txtMaSach.Text = _isMaSua;
                txtTenSach.Text = dt.Rows[0]["TenS"].ToString();
                txtGiaCa.Text = Convert.ToString(dt.Rows[0]["Gia"]);
                txtSoLuong.Text = Convert.ToString(dt.Rows[0]["SLuong"]);

                dtpNgayNhap.Text = dt.Rows[0]["NgayNhap"].ToString();
                cboTacGia.SelectedValue = dt.Rows[0]["MaTG"].ToString();
                cboNxb.SelectedValue = dt.Rows[0]["MaNXB"].ToString();
                cboTheLoai.SelectedValue = dt.Rows[0]["MaTL"].ToString();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            Sach sach = new Sach();
            bool check = Common.KiemTraBatLoi(txtMaSach);
            if (!check)
            {
                return;
            }
            check = Common.KiemTraBatLoi(txtTenSach);
            if (!check)
            {
                return;
            }

            //MaS, TenS ,MaTL, SLuong ,NgayNhap,MaTG ,MaNXB ,Gia
            
            sach.MaSach = txtMaSach.Text;
            sach.TenSach = txtTenSach.Text;
            sach.MaTL = cboTheLoai.SelectedValue.ToString();
            sach.SoLuongTon = Convert.ToInt32(txtSoLuong.Text);
            sach.NgayNhap = Convert.ToString(dtpNgayNhap.Value.ToString("yyyy/MM/dd"));
            sach.MaTG = cboTacGia.SelectedValue.ToString();
            sach.MaNXB = cboNxb.SelectedValue.ToString();
            sach.GiaBan = Convert.ToDouble(txtGiaCa.Text);


            if (String.IsNullOrEmpty(IsMaSua))
            {
                DataProvider.SachBusi.ThemMoiSach(sach);
                _isThem = true;
            }
            else
            {
                DataProvider.SachBusi.SuaThongTinSach(sach);
                _isSua = true;
            }
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
