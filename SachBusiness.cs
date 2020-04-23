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
    public class SachBusiness
    {
        public void ThemMoiSach(Sach sachThem)
        {
            try
            {

                String strThem = "ThemSach";
                SqlParameter[] pars = new SqlParameter[8];

                pars[0] = new SqlParameter("@TenS", SqlDbType.NVarChar, 50);
                pars[0].Value = sachThem.TenSach;

                pars[1] = new SqlParameter("@MaTL", SqlDbType.Char, 10);
                pars[1].Value = sachThem.MaTL;

                pars[2] = new SqlParameter("@SLuong", SqlDbType.Int);
                pars[2].Value = sachThem.SoLuongTon;

                pars[3] = new SqlParameter("@NgayNhap", SqlDbType.Date);
                pars[3].Value = sachThem.NgayNhap;

                pars[4] = new SqlParameter("@MaTG", SqlDbType.Char, 10);
                pars[4].Value = sachThem.MaTG;

                pars[5] = new SqlParameter("@MaNXB", SqlDbType.Char, 10);
                pars[5].Value = sachThem.MaNXB;

                pars[6] = new SqlParameter("@Gia", SqlDbType.Float);
                pars[6].Value = sachThem.GiaBan;

                pars[7] = new SqlParameter("@MaS", SqlDbType.Char, 10);
                pars[7].Value = sachThem.MaSach;

                DataProvider.StoreExcuteNonQuery(strThem,pars);

                MessageBox.Show("Insert done", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }

        //khới tạo hàm sửa sách
        public void SuaThongTinSach(Sach _sach)
        {
            try
            {
                String strSua = "SuaSach";
                SqlParameter[] pars = new SqlParameter[8];

                pars[0] = new SqlParameter("@TenS", SqlDbType.NVarChar, 50);
                pars[0].Value = _sach.TenSach;

                pars[1] = new SqlParameter("@MaTL", SqlDbType.Char, 10);
                pars[1].Value = _sach.MaTL;

                pars[2] = new SqlParameter("@SLuong", SqlDbType.Int);
                pars[2].Value = _sach.SoLuongTon;

                pars[3] = new SqlParameter("@NgayNhap", SqlDbType.Date);
                pars[3].Value = _sach.NgayNhap;

                pars[4] = new SqlParameter("@MaTG", SqlDbType.Char, 10);
                pars[4].Value = _sach.MaTG;

                pars[5] = new SqlParameter("@MaNXB", SqlDbType.Char, 10);
                pars[5].Value = _sach.MaNXB;

                pars[6] = new SqlParameter("@Gia", SqlDbType.Float);
                pars[6].Value = _sach.GiaBan;

                pars[7] = new SqlParameter("@MaS", SqlDbType.Char, 10);
                pars[7].Value = _sach.MaSach;

                DataProvider.StoreExcuteNonQuery(strSua,pars);

                MessageBox.Show("Update done", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //khởi tạo hàm xóa sách
        public void XoaSach(String _maXoaSach)
        {
            String strXoa = "XoaSach";
            SqlParameter[] pars = new SqlParameter[1];
            pars[0] = new SqlParameter("MaS", SqlDbType.Char, 10);
            pars[0].Value = _maXoaSach;

            DataProvider.StoreExcuteNonQuery(strXoa,pars);
        }

        
        //hiển thị trong form thêm, sửa ,xóa
        public DataTable LayTableSach()
        {
            String strXoa = "TatCaSach";

            return DataProvider.StoreExCuteDataTable(strXoa);
        }


        //khởi tạo hàm đổ dữ liệu vào form quầy sách để bán
        public DataTable LaySachVaoQuay()
        {
            String query = "LaySachVaoQuay";
            return DataProvider.StoreExCuteDataTable(query);
        }


        ////khởi tạo hàm lấy dữ liệu người mua sau khi mua sách
        //public DataTable LayDanhSachNguoiMua()
        //{
        //    String strNguoiMua =
        //        "LayTatCaKhachHang";
        //    return DataProvider.StoreExCuteDataTable(strNguoiMua);
        //}

        ////lấy ra danh sách hóa đơn
        //public DataTable LayDSHoaDon()
        //{
        //    String strHd =
        //        "LayDSHoaDon";
        //    return DataProvider.StoreExCuteDataTable(strHd);
        //}

        ////lấy ra danh sách hóa đơn
        //public DataTable LayDanhSachCTHoaDon()
        //{
        //    String strHd =
        //        "DanhSachCTHoaDon";
        //    return DataProvider.StoreExCuteDataTable(strHd);
        //}

        //khởi tạo hàm lấy sách theo mã
        public DataTable LaySachTheoMa(String maSach)
        {
            String strMa = String.Format("select * from Sach where MaS='{0}'",maSach);
            return DataProvider._ExCuteDataTable(strMa);
        }

        //tiếm kiểm sách 
        public DataTable TimKiemSach(String _maSach, String _tenSach)
        {
            String strTimKiem = "select * from Sach where MaS like '%" + _maSach + "%' or TenS Like N'%" + _tenSach + "%'";
            return DataProvider._ExCuteDataTable(strTimKiem);
        }
        //tìm kiếm sách theo tác giả
        public DataTable TimKiemTacGia(String maTacGia)
        {
            String strTimKiem = "TimTheoTacGia";
            DataTable dt = new DataTable();

            //tạo conection đến sql
            SqlConnection conn = new SqlConnection(ConnectToDB.ConnectionString);

            SqlCommand command = new SqlCommand(strTimKiem,conn);
            command.Connection = conn; //chỉ ra connection đnag làm việc
            command.CommandType = CommandType.StoredProcedure; //chỉ ra kiểu command
            command.Parameters.AddWithValue("MaTG", maTacGia);
            //thực hieennj câu lệnh
            try
            {
                //mở kết nối
                conn.Open();

                //chạy câu lệnh
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                //đổ dữ liệu vào bảng
                adapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối: " + e.StackTrace, "Lỗi");
            }

            return dt;
        }

        //tìm kiếm theo thể loại
        public DataTable TimKiemTacTheLoai(String maTheLoai)
        {
            String strTimKiem = "TimTheoTheLoai";
            DataTable dt = new DataTable();

            //tạo conection đến sql
            SqlConnection conn = new SqlConnection(ConnectToDB.ConnectionString);

            SqlCommand command = new SqlCommand(strTimKiem, conn);
            command.Connection = conn; //chỉ ra connection đnag làm việc
            command.CommandType = CommandType.StoredProcedure; //chỉ ra kiểu command
            command.Parameters.AddWithValue("MaTL", maTheLoai);
            //thực hieennj câu lệnh
            try
            {
                //mở kết nối
                conn.Open();

                //chạy câu lệnh
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                //đổ dữ liệu vào bảng
                adapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối: " + e.StackTrace, "Lỗi");
            }

            return dt;
        }

        //comment
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

        //lấy ra tên người dùng
        public DataTable LayTenNguoiDung(String TenNguoiDung)
        {
            String strTen = "Select TaiKhoan from NguoiDung where TaiKhoan = N'" + TenNguoiDung + "'";
            return DataProvider.StoreExCuteDataTable(strTen);
        }
        //bán n cuốn sách
        //khởi tạo hàm update lại số lượng tồn sau khi mua

        //số lượng tồn sau khi bán
        public void soLuongTonSauMua(int slTon, String ma)
        {
            String strTon = "update SACH set SLuong=Sluong-" + slTon + " where MaS='" + ma + "'";
            DataProvider._ExcuteNonQuery(strTon);
        }

        //số lượng tồn sau khi trả lại sách k mua nữa
        public void soLuongTonTraLai(int slTon, String ma)
        {
            String strTon = "update SACH set SLuong=Sluong+" + slTon + " where MaS='" + ma + "'";
            DataProvider._ExcuteNonQuery(strTon);
        }

        //hàm tính tổng tiền chi tiết của từng hóa đơn

        public DataTable TongDoanhThu()
        {
            String strThanhTien =
                " select Sum(SoLuong*DonGia) as Tong_Doanh_Thu from CTHoaDon";
            return DataProvider._ExCuteDataTable(strThanhTien);
        }
        //comment
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


        //thêm mới hóa đơn
        public void ThemMoiHoaDon(HoaDon hd)
        {
            try
            {
                String strThem = String.Format("INSERT INTO HoaDon(MaHD, TenHD,MaKH ,NgayHD) VALUES('{0}',N'{1}','{2}','{3}')"
                    , hd.MaHd
                    , hd.TenHd
                    , hd.MaKh
                    , hd.NgayBan
                    );
                DataProvider._ExcuteNonQuery(strThem);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //xóa hóa đơn theo mã
        public void XoaHoaDon(String maHd)
        {
            String strMa = "delete from HoaDon where MaHD = '" + maHd + "'";
            DataProvider._ExcuteNonQuery(strMa);
        }

        //tìm kiếm và láy mã hóa đơn
        public DataTable TimKiemMaHd(String maHoaDon)
        {
            String strMaHd = "Select * from HoaDon where MaHD Like '%" + maHoaDon + "%'";
            return DataProvider._ExCuteDataTable(strMaHd);
        }
        //tìm kiesm hóa đơn từ ngày này đến ngày nào đó
        public DataTable TimKiemTuNgayNgayDenNgayKia(String dateNay, String dateKia)
        {
            String strNgay =
                "select * from HoaDon where NgayHD BETWEEN CAST('" + dateNay + "' AS DATE) AND CAST('" + dateKia + "' AS DATE)";
            return DataProvider._ExCuteDataTable(strNgay);
        }
        //thêm mới hóa đơn
        public void ThemMoiCTHoaDon(CTHoaDon hd)
        {
            try
            {
                String strThem = String.Format("INSERT INTO CTHoaDon(MaHD, MaS, SoLuong ,DonGia) VALUES('{0}','{1}',{2},{3})"
                    , hd.MaHd
                    , hd.MaS
                    , hd.SoLuong
                    , hd.Tien
                );
                DataProvider._ExcuteNonQuery(strThem);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        //khởi tạo hàm lấy sách theo mã
        public DataTable LayCTHoaDonTheoMa(String maHD)
        {
            String strMa = String.Format("select * from CTHoaDon where MaHD='{0}'", maHD);
            return DataProvider._ExCuteDataTable(strMa);
        }

        //khới tạo hàm sửa chi tiết hóa đơn
        public void SuaChiTietHoaDon(CTHoaDon ctHoaDon)
        {
            try
            {
                String strSua = "SuaCTHoaDon";
                SqlParameter[] pars = new SqlParameter[4];

                pars[0] = new SqlParameter("@MaS", SqlDbType.Char, 10);
                pars[0].Value = ctHoaDon.MaS;

                pars[1] = new SqlParameter("@SoLuong", SqlDbType.Int);
                pars[1].Value = ctHoaDon.SoLuong;

                pars[2] = new SqlParameter("@DonGia", SqlDbType.Float);
                pars[2].Value = ctHoaDon.Tien;

                pars[3] = new SqlParameter("@MaHD", SqlDbType.Char, 10);
                pars[3].Value = ctHoaDon.MaHd;

                DataProvider.StoreExcuteNonQuery(strSua, pars);

                MessageBox.Show("Update done", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        //xóa chi tiết hóa đơn theo mã
        public void XoaCTHoaDon(String maHd)
        {
            String strMa = "delete from CTHoaDon where MaHD = '" + maHd + "'";
            DataProvider._ExcuteNonQuery(strMa);
        }

        //xóa chi tiết hóa đơn theo mã
        public void XoaCTHoaDonTheoMaS(String maHd)
        {
            String strMa = "delete from CTHoaDon where MaS = '" + maHd + "'";
            DataProvider._ExcuteNonQuery(strMa);
        }
        //in ra thông tin top 5 sách bán chạy nhất
        public DataTable Top5()
        {
            try
            {
                String strTop5 = "select top 5 * from hoadon order by SoLuong Desc";
                return DataProvider._ExCuteDataTable(strTop5);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
