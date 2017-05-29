using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnHDT.Object
{
    class HoaDonBan
    {
        private int _mahdb;

        public int MaHDB
        {
            get { return _mahdb; }
            set { _mahdb = value; }
        }
        private int _makh;

        public int MaKH
        {
            get { return _makh; }
            set { _makh = value; }
        }
        private string _ngayban;

        public string NgayBan
        {
            get { return _ngayban; }
            set { _ngayban = value; }
        }
        private int _tonggiamgia;

        public int TongGiamGia
        {
            get { return _tonggiamgia; }
            set { _tonggiamgia = value; }
        }
        private int _tongtien;

        public int TongTien
        {
            get { return _tongtien; }
            set { _tongtien = value; }
        }
        private string _ghichu;

        public string GhiChu
        {
            get { return _ghichu; }
            set { _ghichu = value; }
        }

        public HoaDonBan()
        {

        }
        public HoaDonBan(int _makh, string _ngayban, int _tonggiamgia, int _tongtien, string _ghichu)
        {
            this._makh = _makh;
            this._ngayban = _ngayban;
            this._tonggiamgia = _tonggiamgia;
            this._tongtien = _tongtien;
            this._ghichu = _ghichu;
        }
    }
}
