using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnHDT.Object
{
    class DonDatHang
    {
        private int _maddh;
        private DateTime _ngaydat;
        private int _mancc;

        public int MaDDH
        {
            get { return _maddh; }
            set { _maddh = value; }
        }

        public int MaNCC
        {
            get { return _mancc; }
            set { _mancc = value; }
        }

        public DateTime NgayDat
        {
            get { return _ngaydat; }
            set { _ngaydat = value; }
        }

        public DonDatHang() { }
        public DonDatHang(int _mancc, DateTime _ngaydat)
        {
            this._mancc = _mancc;
            this._ngaydat = _ngaydat;
        }
    }
}
