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
    public partial class frmQuaySach : Form
    {
        public frmQuaySach()
        {
            InitializeComponent();
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


        //khai báo biến hiển thị thông tin vào quầy sách
        private void HienThiQuaySach()
        {
            gridQuaySach.DataSource = null;
            DataTable dtQuaySach = DataProvider.SachBusi.LaySachVaoQuay();
            gridQuaySach.DataSource = dtQuaySach;
        }

        //khai báo biển đổ dữ liệu thông tin người mua
        private void HienThiNguoiMua()
        {
            gridNguoiMua.DataSource = null;
            DataTable dtQuaySach = DataProvider.KhachBusiness.LayDanhSachNguoiMua();
            gridNguoiMua.DataSource = dtQuaySach;
        }

        //lấy dánh sách chi tiết hóa đơn
        private void HienThiChiTietHoaDon()
        {
            gridCTHoaDon.DataSource = null;
            DataTable dtQuaySach = DataProvider.ChiTietHoaDonBusiness.LayDanhSachCTHoaDon();
            gridCTHoaDon.DataSource = dtQuaySach;
        }

       
        //khai báo hàm trả về tổng doanh thu
        private void TongDoanhThu()
        {
            txtTongDoanhThu.Text = null;
            DataTable dt = DataProvider.SachBusi.TongDoanhThu();
            txtTongDoanhThu.Text = dt.Rows[0][0].ToString();
        }

        private void frmQuaySach_Load(object sender, EventArgs e)
        {
            //hiển thị danh sách trong quầy 
            HienThiQuaySach();

            //hiển thị dánh sách người mua
            HienThiNguoiMua();

            //hiển thị thông tin thể loại sách
            DSMaTheLoai();

            //hiển thị thông tin tác giả
            DSMaTacGia();

            //hiển thị danh sách chi tiết háo đơn
            HienThiChiTietHoaDon();

            //hiển thị tông doanh thu
            TongDoanhThu();
        }

        private void btnMua_Click(object sender, EventArgs e)
        {
            frmAddChiTietHoaDon frmMua = new frmAddChiTietHoaDon();

            //lấy ra mã cần mua để hiển thị thông tin trong form add khách hàng
            String maMua = gridQuaySach.CurrentRow.Cells[0].Value.ToString();


            //khởi tạo 1 biến lấy ra giá trị số lượng để kiểm tra xem cso <= 0 hay k
            String maSoLuong = gridQuaySach.CurrentRow.Cells[3].Value.ToString();
            if (Convert.ToInt32(maSoLuong) <= 0)
            {
                MessageBox.Show("Sách này đã bán hết,Mời bạn chọn sách khác !");
                return;
            }

            frmMua.IsMaSach = maMua;
            frmMua.ShowDialog();
            if (frmMua.isCTHoaDon == true)
            {
                HienThiChiTietHoaDon();
            }

            ////load lại gridview quầy bán sách
            HienThiQuaySach();

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbtnAll_CheckedChanged_1(object sender, EventArgs e)
        {
            HienThiNguoiMua();
        }

        //khai báo 1 biến kiểm tra
        private String isKhach;

        public string IsKhach
        {
            get { return isKhach; }
            set { isKhach = value; }
        }

        //khai báo 1 biến kiểm tra thêm đúng k
        private bool isKhachThem;

        public bool IsKhachThem
        {
            get { return isKhachThem; }
        }

        //viết sự kiện cho nút thêm khách hàng
        private void btnThemKH_Click(object sender, EventArgs e)
        {
            bool check = Common.KiemTraBatLoi(txtMaKH);
            if (!check)
            {
                MessageBox.Show("Bạn cần nhập vào Mã KH");
                return;
            }
            check = Common.KiemTraBatLoi(txtTenKh);
            if (!check)
            {
                MessageBox.Show("Bạn cần nhập vào Tên KH");
                return;
            }

            KhachHang kh = new KhachHang();
            kh.MaKh = txtMaKH.Text;
            kh.Tenkh = txtTenKh.Text;
            kh.DiaChi = txtDiaChi.Text;
            kh.Sdt = txtSoDT.Text;
            if (String.IsNullOrEmpty(isKhach))
            {
                //gọi đến hàm thêm khách hàng
                DataProvider.KhachBusiness.ThemMoiKhachHang(kh);
                isKhachThem = true;

                //load lại thông tin sau khi thêm
                HienThiNguoiMua();
            }
        }

        private void btnXoaKh_Click(object sender, EventArgs e)
        {
            String maXoa = gridNguoiMua.CurrentRow.Cells[0].Value.ToString();
            DialogResult dlg = MessageBox.Show("Bạn có chắc chắn xóa??", "Xóa", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (dlg == DialogResult.Yes)
            {
                // DataProvider.SachBusi.XoaSachTrongKhanhHang(maXoa);
                DataProvider.KhachBusiness.XoaKhachHang(maXoa);
            }

            //cập nhật lại gridview
            HienThiNguoiMua();
        }


        //khi click vào dòng nào sẽ hiển thị ra thông tin khách hàng lên textbox
        private void gridNguoiMua_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selected = gridNguoiMua.Rows[index];
            txtMaKH.Text = selected.Cells[0].Value.ToString();
            txtTenKh.Text = selected.Cells[1].Value.ToString();
            txtDiaChi.Text = selected.Cells[2].Value.ToString();
            txtSoDT.Text = selected.Cells[3].Value.ToString();
        }


        private void txtThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            String strten = txtTenSach.Text;
            String strTheLoai = cboTheLoai.SelectedValue.ToString();
            String strTacGia = cboTacGia.SelectedValue.ToString();
            if (rbtnTenSach.Checked)
            {
                gridQuaySach.DataSource = DataProvider.SachBusi.TimKiemSach(strten, strten);
            }
            else if (rbtnTheLoai.Checked)
            {
                gridQuaySach.DataSource = DataProvider.SachBusi.TimKiemTacTheLoai(strTheLoai);
            }
            else if (rbtnTacGia.Checked)
            {
                gridQuaySach.DataSource = DataProvider.SachBusi.TimKiemTacGia(strTacGia);
            }
            else
            {
                MessageBox.Show("Mời bạn chọn kiểu tìm kiếm !");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            HienThiQuaySach();
        }

        private void btnTimKiemKh_Click(object sender, EventArgs e)
        {
            String strMa = txtTimKiemKH.Text;
            String strTen = txtTimKiemKH.Text;
            if (rbtnTheoMaKh.Checked)
            {
                gridNguoiMua.DataSource = DataProvider.KhachBusiness.TimKiemKhTheoMa(strMa);
            }
            else if (rbtnTheoTenKh.Checked)
            {
                gridNguoiMua.DataSource = DataProvider.KhachBusiness.TimKiemKhTheoTen(strTen);
            }
            else
            {
                MessageBox.Show("Mời bạn chọn kiểu tìm kiếm !");
            }
        }


        //load lại bảng khách hàng
        private void btnResetKh_Click(object sender, EventArgs e)
        {
            HienThiNguoiMua();
        }

        private void btnTongDoanhThu_Click(object sender, EventArgs e)
        {
            txtTongDoanhThu.Text = null;
            DataTable dt = DataProvider.SachBusi.TongDoanhThu();
            txtTongDoanhThu.Text = dt.Rows[0][0].ToString();
        }

        private void btnSuaCTHD_Click(object sender, EventArgs e)
        {
            frmEditCTHoaDon frmSua = new frmEditCTHoaDon();

            String strMaSua = gridCTHoaDon.CurrentRow.Cells[0].Value.ToString();
            frmSua.IsMaHoaDon = strMaSua;
            frmSua.ShowDialog();
            if (frmSua.isCTHoaDon)
            {
                HienThiChiTietHoaDon();
            }
        }

        private void btnXoaCTHd_Click(object sender, EventArgs e)
        {
            //lấy cột Mã chi tiết hóa đơn
            String strMaSua = gridCTHoaDon.CurrentRow.Cells[0].Value.ToString();

            //lấy cột mã sách
            String strMaSach = gridCTHoaDon.CurrentRow.Cells[2].Value.ToString();

            //lấy cột số lượng
            int strSoLuong = Convert.ToInt32(gridCTHoaDon.CurrentRow.Cells[3].Value.ToString());
            DialogResult dlg = MessageBox.Show("Bạn có chắc chắn xóa??", "Xóa", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (dlg == DialogResult.Yes)
            {
                DataProvider.ChiTietHoaDonBusiness.XoaCTHoaDon(strMaSua);

                //cập nhật lại số lượng sách trong quầy sau khi hủy hóa đơn
                DataProvider.SachBusi.soLuongTonTraLai(strSoLuong, strMaSach);
            }

            //cập nhật lại danh sách chi tiết hóa đơn sau xóa
            HienThiChiTietHoaDon();

            //cập nhật lại quầy sách sau khi hủy hóa đơn
            HienThiQuaySach();
        }

        private void btnXoaCTHDTheoMaS_Click(object sender, EventArgs e)
        {
            String strMaSua = gridCTHoaDon.CurrentRow.Cells[2].Value.ToString();
            int strSoLuong = Convert.ToInt32(gridCTHoaDon.CurrentRow.Cells[3].Value.ToString());
            DialogResult dlg = MessageBox.Show("Bạn có chắc chắn xóa??", "Xóa", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (dlg == DialogResult.Yes)
            {
                DataProvider.ChiTietHoaDonBusiness.XoaCTHoaDonTheoMaS(strMaSua);

                //cập nhật lại số lượng sách trong quầy sau khi hủy hóa đơn
                DataProvider.SachBusi.soLuongTonTraLai(strSoLuong,strMaSua);
            }

            //cập nhật lại danh sách chi tiết hóa đơn sau xóa
            HienThiChiTietHoaDon();


            //cập nhật lại quầy sách sau khi hủy hóa đơn
            HienThiQuaySach();
        }

        private void btnThoatHd_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
