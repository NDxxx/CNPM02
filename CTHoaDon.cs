using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach
{
    public class CTHoaDon
    {
        private String _maCTHD;
        private String MaHD;

        private String _maS;
        private int _SoLuong;
        private Double _DonGia;
        public string MaHd
        {
            get { return MaHD; }
            set { MaHD = value; }
        }

        public string MaS
        {
            get { return _maS; }
            set { _maS = value; }
        }

        public int SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }

        public double Tien
        {
            get { return _DonGia; }
            set { _DonGia = value; }
        }

        public string MaCthd
        {
            get { return _maCTHD; }
            set { _maCTHD = value; }
        }
    }
}
