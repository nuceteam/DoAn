using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnHDT.Object
{
    class HoaDonNhap
    {
        private int _mahdn;

        public int MaHDN
        {
            get { return _mahdn; }
            set { _mahdn = value; }
        }
        private int _mancc;

        public int MaNCC
        {
            get { return _mancc; }
            set { _mancc = value; }
        }
        private int _maddh;

        public int MaDDH
        {
            get { return _maddh; }
            set { _maddh = value; }
        }
        private DateTime _ngaynhap;

        public DateTime NgayNhap
        {
            get { return _ngaynhap; }
            set { _ngaynhap = value; }
        }
        private float _tongtien;

        public float TongTien
        {
            get { return _tongtien; }
            set { _tongtien = value; }
        }

        public HoaDonNhap() { }
        public HoaDonNhap(int _mancc, int _maddh, DateTime _ngaynhap, float _tongtien)
        {
            this._mancc = _mancc;
            this._maddh = _maddh;
            this._ngaynhap = _ngaynhap;
            this._tongtien = _tongtien;
        }
    }
}
