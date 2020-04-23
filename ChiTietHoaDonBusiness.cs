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
    public class ChiTietHoaDonBusiness
    {
        //lấy ra danh sách hóa đơn
        public DataTable LayDanhSachCTHoaDon()
        {
            String strHd =
                "DanhSachCTHoaDon";
            return DataProvider.StoreExCuteDataTable(strHd);
        }

        public void ThemMoiCTHoaDon(CTHoaDon hd)
        {
            try
            {
                String strThem = String.Format("INSERT INTO CTHoaDon(MaCTHD,MaHD, MaS, SoLuong ,DonGia) VALUES('{0}','{1}','{2}',{3},{4})"
                    ,hd.MaCthd
                    , hd.MaHd
                    , hd.MaS
                    , hd.SoLuong
                    , hd.Tien
                );
                DataProvider._ExcuteNonQuery(strThem);

                //cập nhật hóa đơn sau khi tổng tiền đã có
                String strCapNhatLaiTongTien = String.Format("UPDATE HOADON SET TongTien+= " + hd.SoLuong * hd.Tien + " WHERE MaHD = '" + hd.MaHd + "'");
                DataProvider._ExcuteNonQuery(strCapNhatLaiTongTien);
                
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
            String strMa = String.Format("select * from CTHoaDon where MaCTHD='{0}'", maHD);
            return DataProvider._ExCuteDataTable(strMa);
        }

        //khới tạo hàm sửa chi tiết hóa đơn
        public void SuaChiTietHoaDon(CTHoaDon ctHoaDon)
        {
            try
            {
                String strSua = "SuaCTHoaDon";
                SqlParameter[] pars = new SqlParameter[5];

                pars[0] = new SqlParameter("@MaHD", SqlDbType.Char, 10);
                pars[0].Value = ctHoaDon.MaHd;

                pars[1] = new SqlParameter("@MaS", SqlDbType.Char, 10);
                pars[1].Value = ctHoaDon.MaS;

                pars[2] = new SqlParameter("@SoLuong", SqlDbType.Int);
                pars[2].Value = ctHoaDon.SoLuong;

                pars[3] = new SqlParameter("@DonGia", SqlDbType.Float);
                pars[3].Value = ctHoaDon.Tien;

                pars[4] = new SqlParameter("@MaCTHD", SqlDbType.Char, 10);
                pars[4].Value = ctHoaDon.MaCthd;

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
            String strMa = "delete from CTHoaDon where MaCTHD = '" + maHd + "'";
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
