using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnHDT.Object
{
    class PhieuGNBH
    {
        private int _mapbh;

        public int MaPBH
        {
            get { return _mapbh; }
            set { _mapbh = value; }
        }
        private DateTime _ngaybh;

        public DateTime NgayBH
        {
            get { return _ngaybh; }
            set { _ngaybh = value; }
        }
        private string _ghichu;

        public string GhiChu
        {
            get { return _ghichu; }
            set { _ghichu = value; }
        }

        public PhieuGNBH() { }
        public PhieuGNBH(int _mapbh, DateTime _ngaybh, string _ghichu)
        {
            this._mapbh = _mapbh;
            this._ngaybh = _ngaybh;
            this._ghichu = _ghichu;
        }
    }
}
