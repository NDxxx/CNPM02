using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach
{
    public class HoaDonBusiness
    {
        public void ThemMoiHoaDon(HoaDon hd)
        {
            try
            {
                String strThem = String.Format("INSERT INTO HoaDon(MaHD, TenHD,MaKH ,NgayHD,TongTien) VALUES('{0}',N'{1}','{2}','{3}',{4})"
                    , hd.MaHd
                    , hd.TenHd
                    , hd.MaKh
                    , hd.NgayBan
                    ,hd.TongTienHd
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
        //lấy ra danh sách hóa đơn
        public DataTable LayDSHoaDon()
        {
            String strHd =
                "LayDSHoaDon";
            return DataProvider.StoreExCuteDataTable(strHd);
        }

        public DataTable TimKiemMaHd(String maHoaDon)
        {
            String strMaHd = "Select * from HoaDon where MaHD Like '%" + maHoaDon + "%'";
            return DataProvider._ExCuteDataTable(strMaHd);
        }

        public DataTable TimKiemTuNgayNgayDenNgayKia(String dateNay, String dateKia)
        {
            String strNgay =
                "select * from HoaDon where NgayHD BETWEEN CAST('" + dateNay + "' AS DATE) AND CAST('" + dateKia + "' AS DATE)";
            return DataProvider._ExCuteDataTable(strNgay);
        }
    }
}
