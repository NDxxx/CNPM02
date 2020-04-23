using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach
{
    public class AllBusiness
    {
        public DataTable LayTheoMaTheLoai()
        {
            String strTheLoai = "select MaTL,TenTheLoai from TheLoai";
            return DataProvider._ExCuteDataTable(strTheLoai);
        }

        public DataTable LayTheoTacGia()
        {
            String strTacGia = "select MaTG,TenTG from TacGia";
            return DataProvider._ExCuteDataTable(strTacGia);
        }

        public DataTable LayTheoNxb()
        {
            String strNxb = "select MaNXB,TenNXB from NXB";
            return DataProvider._ExCuteDataTable(strNxb);
        }
        public DataTable LayTheoKh()
        {
            String strLayKh = "select MaKH,TenKH from KhachHang";
            return DataProvider._ExCuteDataTable(strLayKh);
        }

        public DataTable LayTheoMaHoaDon()
        {
            String strLayhd = "select MaHD,TenHD from HoaDon";
            return DataProvider._ExCuteDataTable(strLayhd);
        }
    }
}
