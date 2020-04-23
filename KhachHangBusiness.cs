using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanSach
{
    public class KhachHangBusiness
    {
        //thêm mới khách hàng
        public void ThemMoiKhachHang(KhachHang kh)
        {
            try
            {

                String strThem = "ThemKhachHang";
                SqlParameter[] pars = new SqlParameter[4];

                pars[0] = new SqlParameter("@MaKH", SqlDbType.Char, 10);
                pars[0].Value = kh.MaKh;

                pars[1] = new SqlParameter("@TenKh", SqlDbType.NVarChar, 30);
                pars[1].Value = kh.Tenkh;

                pars[2] = new SqlParameter("@DiaChi", SqlDbType.NVarChar, 50);
                pars[2].Value = kh.DiaChi;

                pars[3] = new SqlParameter("@SDT", SqlDbType.Char, 10);
                pars[3].Value = kh.Sdt;

                DataProvider.StoreExcuteNonQuery(strThem, pars);

                MessageBox.Show("Insert done", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //xóa khách hàng
        public void XoaKhachHang(String maKh)
        {
            String strXoa = "XoaKhachHang";
            SqlParameter[] pars = new SqlParameter[1];
            pars[0] = new SqlParameter("MaKH", SqlDbType.Char, 10);
            pars[0].Value = maKh;

            DataProvider.StoreExcuteNonQuery(strXoa, pars);
        }

        //khởi tạo hàm lấy dữ liệu người mua sau khi mua sách
        public DataTable LayDanhSachNguoiMua()
        {
            String strNguoiMua =
                "LayTatCaKhachHang";
            return DataProvider.StoreExCuteDataTable(strNguoiMua);
        }

        //tìm kiếm khách hàng theo mã
        public DataTable TimKiemKhTheoMa(String maKh)
        {
            String strMaKh = "Select * from KhachHang where MaKH ='" + maKh + "'";
            return DataProvider._ExCuteDataTable(strMaKh);
        }

        //tìm kiếm khách hàng theo tên
        public DataTable TimKiemKhTheoTen(String tenKh)
        {
            String strTenKh = "Select * from KhachHang where Tenkh Like '%" + tenKh + "%'";
            return DataProvider._ExCuteDataTable(strTenKh);
        }
    }
}
