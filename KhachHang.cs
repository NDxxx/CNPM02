using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach
{
    public class KhachHang
    {
        private String _MaKH;
        private String _Tenkh;
        private String _DiaChi;
        private String _SDT;

        public string MaKh
        {
            get { return _MaKH; }
            set { _MaKH = value; }
        }

        public string Tenkh
        {
            get { return _Tenkh; }
            set { _Tenkh = value; }
        }

        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }

        public string Sdt
        {
            get { return _SDT; }
            set { _SDT = value; }
        }

    }
}
