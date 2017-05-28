using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnHDT.Object
{
    class KhachHang
    {
        private int _makh;
        private string _tenkh;
        private string _diachi;
        private string _dienthoai;

        public int MaKH
        {
            get { return _makh; }
            set { _makh = value; }
        }

        public string TenKH
        {
            get { return _tenkh; }
            set { _tenkh = value; }
        }
      
        public string DiaChi
        {
            get { return _diachi; }
            set { _diachi = value; }
        }     

        public string DienThoai
        {
            get { return _dienthoai; }
            set { _dienthoai = value; }
        }

        public KhachHang() { }

        public KhachHang(int _makh, string _tenkh, string _diachi, string _dienthoai)
        {
            this._makh = _makh;
            this._tenkh = _tenkh;
            this._diachi  = _diachi;
            this._dienthoai = _dienthoai;
        }
    }
}
