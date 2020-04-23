using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach
{
    public class Sach
    {
        private String _MaSach;
        private String _TenSach;
        private String _MaTL;
        private int _SoLuongTon;
        private String _MaTG;
        private String _MaNXB;
        private String _NgayNhap;
        private Double _GiaBan;

        public string MaSach
        {
            get { return _MaSach; }
            set { _MaSach = value; }
        }

        public string TenSach
        {
            get { return _TenSach; }
            set { _TenSach = value; }
        }

        public string MaTL
        {
            get { return _MaTL; }
            set { _MaTL = value; }
        }

        public int SoLuongTon
        {
            get { return _SoLuongTon; }
            set { _SoLuongTon = value; }
        }

        public string MaTG
        {
            get { return _MaTG; }
            set { _MaTG = value; }
        }

        public string MaNXB
        {
            get { return _MaNXB; }
            set { _MaNXB = value; }
        }

        public string NgayNhap
        {
            get { return _NgayNhap; }
            set { _NgayNhap = value; }
        }

        public double GiaBan
        {
            get { return _GiaBan; }
            set { _GiaBan = value; }
        }

       
    }
}
