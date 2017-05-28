using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnHDT.Object
{
    class PhieuBH
    {
        private int _mapbh;

        public int MaPBH
        {
            get { return _mapbh; }
            set { _mapbh = value; }
        }
        private int _makh;

        public int MaKH
        {
            get { return _makh; }
            set { _makh = value; }
        }
        private string _mamh;

        public string MaMH
        {
            get { return _mamh; }
            set { _mamh = value; }
        }
        private int _mahdb;

        public int MaHDB
        {
            get { return _mahdb; }
            set { _mahdb = value; }
        }
        private DateTime _ngaybatdau;

        public DateTime NgayBatDau
        {
            get { return _ngaybatdau; }
            set { _ngaybatdau = value; }
        }
        private DateTime _ngayketthuc;

        public DateTime NgayKetThuc
        {
            get { return _ngayketthuc; }
            set { _ngayketthuc = value; }
        }

        public PhieuBH()
        {
        }
        public PhieuBH(int _makh, string _mamh, int _mahdb, DateTime _ngaybatdau, DateTime _ngayketthuc)
        {
            this._makh = _makh;
            this._mamh = _mamh;
            this._mahdb = _mahdb;
            this._ngaybatdau = _ngaybatdau;
            this._ngayketthuc = _ngayketthuc;
        }
    }
}
