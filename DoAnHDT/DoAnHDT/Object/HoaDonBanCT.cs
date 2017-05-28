using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnHDT.Object
{
    class HoaDonBanCT
    {
        private int _mahdb;

        public int MaHDB
        {
            get { return _mahdb; }
            set { _mahdb = value; }
        }
        private string _mamh;

        public string MaMH
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
        private float _giamgia;

        public float GiamGia
        {
            get { return _giamgia; }
            set { _giamgia = value; }
        }

        public HoaDonBanCT()
        {

        }
        public HoaDonBanCT(int _mahdb, string _mamh, int _soluong, float _giamgia)
        {
            this._mahdb = _mahdb;
            this._mamh = _mamh;
            this._soluong = _soluong;
            this._giamgia = _giamgia;
        }
    }
}
