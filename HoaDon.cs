using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach
{
    public class HoaDon
    {
        private String MaHD;
        private String TenHD;
        private String _MaKH;
        private String _ngayBan;
        private Double _TongTienHD;
        public string MaHd
        {
            get { return MaHD; }
            set { MaHD = value; }
        }

        public string MaKh
        {
            get { return _MaKH; }
            set { _MaKH = value; }
        }

        public string NgayBan
        {
            get { return _ngayBan; }
            set { _ngayBan = value; }
        }

        public string TenHd
        {
            get { return TenHD; }
            set { TenHD = value; }
        }

        public double TongTienHd
        {
            get { return _TongTienHD; }
            set { _TongTienHD = value; }
        }
    }
}
