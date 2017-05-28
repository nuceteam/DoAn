using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnHDT.Object
{
    class DonDatHangCT
    {
        private int _maddh;

        public int MaDDH
        {
            get { return _maddh; }
            set { _maddh = value; }
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

        public DonDatHangCT() { }
        public DonDatHangCT(string _mamh, int _soluong)
        {
            this._mamh = _mamh;
            this._soluong = _soluong;
        }
    }
}
