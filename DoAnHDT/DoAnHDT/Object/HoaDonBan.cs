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
        private DateTime _ngayban;

        public DateTime NgayBan
        {
            get { return _ngayban; }
            set { _ngayban = value; }
        }
        private float _tonggiamgia;

        public float TongGiamGia
        {
            get { return _tonggiamgia; }
            set { _tonggiamgia = value; }
        }
        private float _tongtien;

        public float TongTien
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
        public HoaDonBan(int _makh, DateTime _ngayban, float _tonggiamgia, float _tongtien, string _ghichu)
        {
            this._makh = _makh;
            this._ngayban = _ngayban;
            this._tonggiamgia = _tonggiamgia;
            this._tongtien = _tongtien;
            this._ghichu = _ghichu;
        }
    }
}
