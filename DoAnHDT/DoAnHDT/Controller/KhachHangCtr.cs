using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnHDT.Model;
using DoAnHDT.Object;
using System.Data;

namespace DoAnHDT.Controller
{
    class KhachHangCtr
    {
        KhachHangMod nvMod = new KhachHangMod();
        public DataTable GetData(string keysearch)
        {
            return nvMod.GetData(keysearch);
        }
        public bool AddData(KhachHang kh)
        {
            return nvMod.AddData(kh);
        }
        public bool UpdData(KhachHang kh)
        {
            return nvMod.UpdData(kh);
        }
        public bool DelData(string ma)
        {
            return nvMod.DelData(ma);
        }
    }
}
