using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnHDT.Object
{
    class NhaCungCap
    {
        private int _mancc;
        private string _tenncc;
        private string _diachi;
        private string _dienthoai;
        private string _sofax;

        public int MaNCC
        {
            get { return _mancc; }
            set { _mancc = value; }
        }

        public string TenNCC
        {
            get { return _tenncc; }
            set { _tenncc = value; }
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

        public string SoFax
        {
            get { return _sofax; }
            set { _sofax = value; }
        }

        public NhaCungCap() { }

        public NhaCungCap(int _mancc, string _tenncc, string _diachi, string _dienthoai, string _sofax)
        {
            this._mancc = _mancc;
            this._tenncc = _tenncc;
            this._diachi = _diachi;
            this._dienthoai = _dienthoai;
            this._sofax = _sofax;
        }

    }
}
