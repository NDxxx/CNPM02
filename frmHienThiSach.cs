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
    public partial class frmHienThiSach : Form
    {
        public frmHienThiSach()
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
        private void frmHienThiSach_Load(object sender, EventArgs e)
        {
            //hiển thị tên tác giả lên cboTacGia
            DSMaTacGia();

            //hiển thị tên thể loại
            DSMaTheLoai();

            //hiển thị tất cả sách
            HienThiDanhSach();
        }

        private void HienThiDanhSach()
        {
            gridSach.DataSource = null;
            DataTable dt = DataProvider.SachBusi.LayTableSach();

            gridSach.DataSource = dt;

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            frmAddSach frm = new frmAddSach();
            frm.ShowDialog();
            if (frm.IsThem)
            {
                HienThiDanhSach();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            frmAddSach frmSua = new frmAddSach();

            String maSua = gridSach.CurrentRow.Cells[0].Value.ToString();
            frmSua.IsMaSua = maSua;

            frmSua.ShowDialog();
            if (frmSua.IsSua)
            {
                HienThiDanhSach();
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            String maXoa = gridSach.CurrentRow.Cells[0].Value.ToString();
            DialogResult dlg = MessageBox.Show("Bạn có chắc chắn xóa??", "Xóa", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (dlg == DialogResult.Yes)
            {
                // DataProvider.SachBusi.XoaSachTrongKhanhHang(maXoa);
                DataProvider.SachBusi.XoaSach(maXoa);
            }

            //cập nhật lại gridview
            HienThiDanhSach();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            String tenSach = txtTenSach.Text;
            String maSach = txtTenSach.Text;
            String maTacGia = cboTacGia.SelectedValue.ToString();
            String maTheLoai = cboTheLoai.SelectedValue.ToString();
            if (rbtnTenS.Checked)
            {
                gridSach.DataSource = DataProvider.SachBusi.TimKiemSach(maSach, tenSach);
            }
            else if (rbtnTacGia.Checked)
            {
                gridSach.DataSource = DataProvider.SachBusi.TimKiemTacGia(maTacGia);
            }
            else if (rbtnTheLoai.Checked)
            {
                gridSach.DataSource = DataProvider.SachBusi.TimKiemTacTheLoai(maTheLoai);
            }
            else
            {
                MessageBox.Show("Mời bạn chọn kiểu tìm kiếm !!");
            }
            txtTenSach.Text = "";
            txtTenSach.Focus();

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }
    }
}
