using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnHDT.Object
{
    class MatHang
    {
        private string _mamh;
        private int _giaban;
        private string _tenmh;
        private string _hangsx;
        private int _soluong;

        public string MaMH
        {
            get { return _mamh; }
            set { _mamh = value; }
        }

        public string TenMH
        {
            get { return _tenmh; }
            set { _tenmh = value; }
        }

        public string HangSx
        {
            get { return _hangsx; }
            set { _hangsx = value; }
        }

        public int SoLuong
        {
            get { return _soluong; }
            set { _soluong = value; }
        }

        public int GiaBan
        {
            get { return _giaban; }
            set { _giaban = value; }
        }

        public MatHang() { }

        public MatHang(string _mamh, string _tenmh, string _hangsx, int _soluong, int _giaban)
        {
            this._mamh = _mamh;
            this._giaban = _giaban;
            this._tenmh = _tenmh;
            this._hangsx = _hangsx;
            this._soluong = _soluong;
        }
    }
}
