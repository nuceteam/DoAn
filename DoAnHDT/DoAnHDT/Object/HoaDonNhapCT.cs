using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnHDT.Object
{
    class HoaDonNhapCT
    {
        private int _mahdn;

        public int MaHDN
        {
            get { return _mahdn; }
            set { _mahdn = value; }
        }
        private string _mamh;

        public string MyProperty
        {
            get { return _mamh; }
            set { _mamh = value; }
        }
        private int _soluong;

        public int SoLuong
        {
            get { return _soluong; }
            set { _soluong = value; }
        }
        private float _gianhap;

        public float GiaNhap
        {
            get { return _gianhap; }
            set { _gianhap = value; }
        }

        public HoaDonNhapCT()
        {
        }
        public HoaDonNhapCT(string _mamh, int _soluong, float _gianhap)
        {
            this._mahdn = _mahdn;
            this._mamh = _mamh;
            this._soluong = _soluong;
            this._gianhap = _gianhap;
        }
    }
}
